/* ========================================================================
* Copyright (c) 2005-2019 The OPC Foundation, Inc. All rights reserved.
*
* OPC Foundation MIT License 1.00
* 
* Permission is hereby granted, free of charge, to any person
* obtaining a copy of this software and associated documentation
* files (the "Software"), to deal in the Software without
* restriction, including without limitation the rights to use,
* copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the
* Software is furnished to do so, subject to the following
* conditions:
* 
* The above copyright notice and this permission notice shall be
* included in all copies or substantial portions of the Software.
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
* OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
* NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
* HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
* WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
* FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
* OTHER DEALINGS IN THE SOFTWARE.
*
* The complete license agreement can be found here:
* http://opcfoundation.org/License/MIT/1.00/
* ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.Threading;
using System.Reflection;
using Opc.Ua;
using Opc.Ua.Server;
using PiServer.Nodes.SenseHat;

namespace PiServer
{
  /// <summary>
  /// A node manager for a server that exposes several variables.
  /// </summary>
  public class PiServerNodeManager : CustomNodeManager2
  {
    public const string PiServerNamespace = "http://mkecybertech.com/UA/PiServer";

    #region Constructors
    /// <summary>
    /// Initializes the node manager.
    /// </summary>
    public PiServerNodeManager(IServerInternal server, ApplicationConfiguration configuration, ISenseHat senseHat)
    :
        base(server, configuration, PiServerNamespace)
    {
      SystemContext.NodeIdFactory = this;

      List<string> namespaceUris = new List<string>();
      namespaceUris.Add(Nodes.SenseHat.Namespaces.SenseHat);
      namespaceUris.Add(Nodes.SenseHat.Namespaces.SenseHat + "/Instance");
      NamespaceUris = namespaceUris;

      m_typeNamespaceIndex = Server.NamespaceUris.GetIndexOrAppend(namespaceUris[0]);
      m_namespaceIndex = Server.NamespaceUris.GetIndexOrAppend(namespaceUris[1]);

      SenseHat = senseHat;
    }
    #endregion

    #region IDisposable Members
    /// <summary>
    /// An overrideable version of the Dispose.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
      }
    }
    #endregion

    #region INodeIdFactory Members
    /// <summary>
    /// Creates the NodeId for the specified node.
    /// </summary>
    public override NodeId New(ISystemContext context, NodeState node)
    {
      return node.NodeId;
    }
    #endregion

    #region INodeManager Members
    /// <summary>
    /// Does any initialization required before the address space can be used.
    /// </summary>
    /// <remarks>
    /// The externalReferences is an out parameter that allows the node manager to link to nodes
    /// in other node managers. For example, the 'Objects' node is managed by the CoreNodeManager and
    /// should have a reference to the root folder node(s) exposed by this node manager.  
    /// </remarks>
    public override void CreateAddressSpace(IDictionary<NodeId, IList<IReference>> externalReferences)
    {
      lock (Lock)
      {
        base.CreateAddressSpace(externalReferences);

        LoadPredefinedNodes(SystemContext, externalReferences);

        IList<IReference> references = null;
        if (!externalReferences.TryGetValue(Opc.Ua.ObjectIds.ObjectsFolder, out references))
        {
          externalReferences[Opc.Ua.ObjectIds.ObjectsFolder] = references = new List<IReference>();
        }

        FolderState piFolder = new FolderState(null);
        piFolder.Create(
          SystemContext,
          new NodeId(Guid.NewGuid(), NamespaceIndex),
          new QualifiedName("Pi", m_namespaceIndex),
          null,
          false);

        references.Add(new NodeStateReference(ReferenceTypeIds.Organizes, false, piFolder.NodeId));
        piFolder.AddReference(ReferenceTypeIds.Organizes, true, Opc.Ua.ObjectIds.ObjectsFolder);

        AddPredefinedNode(SystemContext, piFolder);

        SenseHatNode = new SenseHatState(null);
        SenseHatNode.Create(
          SystemContext,
          null,
          new QualifiedName("SenseHat", m_namespaceIndex),
          null,
          true);

        SenseHatNode.AddReference(ReferenceTypeIds.Organizes, true, piFolder.NodeId);
        piFolder.AddReference(ReferenceTypeIds.Organizes, false, SenseHatNode.NodeId);

        SenseHatNode.AddReference(ReferenceTypeIds.HasNotifier, true, piFolder.NodeId);
        piFolder.AddReference(ReferenceTypeIds.HasNotifier, false, SenseHatNode.NodeId);

        AddPredefinedNode(SystemContext, SenseHatNode);

        InitializeSenseHatNode(SenseHatNode);
      }
    }

    /// <summary>
    /// Frees any resources allocated for the address space.
    /// </summary>
    public override void DeleteAddressSpace()
    {
      lock (Lock)
      {
        base.DeleteAddressSpace();
      }
    }

    /// <summary>
    /// Returns a unique handle for the node.
    /// </summary>
    protected override NodeHandle GetManagerHandle(ServerSystemContext context, NodeId nodeId, IDictionary<NodeId, NodeState> cache)
    {
      lock (Lock)
      {
        // quickly exclude nodes that are not in the namespace. 
        if (!IsNodeIdInNamespace(nodeId))
        {
          return null;
        }

        NodeState node = null;

        if (!PredefinedNodes.TryGetValue(nodeId, out node))
        {
          return null;
        }

        NodeHandle handle = new NodeHandle();

        handle.NodeId = nodeId;
        handle.Node = node;
        handle.Validated = true;

        return handle;
      }
    }

    /// <summary>
    /// Verifies that the specified node exists.
    /// </summary>
    protected override NodeState ValidateNode(
        ServerSystemContext context,
        NodeHandle handle,
        IDictionary<NodeId, NodeState> cache)
    {
      // not valid if no root.
      if (handle == null)
      {
        return null;
      }

      // check if previously validated.
      if (handle.Validated)
      {
        return handle.Node;
      }

      // TBD

      return null;
    }
    #endregion

    #region Overridden Methods
    /// <summary>
    /// Loads a node set from a file or resource and addes them to the set of predefined nodes.
    /// </summary>
    protected override NodeStateCollection LoadPredefinedNodes(ISystemContext context)
    {
      string resourcePrefix = "PiServer.Resources.PredefinedNodes";
      string resourceName = $"{resourcePrefix}.SenseHat.PredefinedNodes.uanodes";

      Stream fileStream = Assembly.GetAssembly(this.GetType())
        .GetManifestResourceStream(resourceName);

      NodeStateCollection predefinedNodes = new NodeStateCollection();
      predefinedNodes.LoadFromBinary(context, fileStream, true);

      return predefinedNodes;
    }
    #endregion

    #region Custom Methods
    public void InitializeSenseHatNode(SenseHatState node)
    {
      node.Temperature.Units.Value = SenseHat.TemperatureUnits;
      node.Pressure.Units.Value = SenseHat.PressureUnits;
      node.Humidity.Units.Value = SenseHat.HumidityUnits;
      node.Magnetometer.Units.Value = SenseHat.MagnetometerUnits;
      node.Accelerometer.Units.Value = SenseHat.AccelerometerUnits;
      node.AngularRate.Units.Value = SenseHat.AngularRateUnits;

      SenseHat.AccelerometerChanged += SenseHat_AccelerometerChanged;
      SenseHat.AngularRateChanged += SenseHat_AngularRateChanged;
      SenseHat.HumidityChanged += SenseHat_HumidityChanged;
      SenseHat.JoystickChanged += SenseHat_JoystickChanged;
      SenseHat.JoystickChanged += SenseHat_JoystickEventGenerator;
      SenseHat.MagnetometerChanged += SenseHat_MagnetometerChanged;
      SenseHat.PressureChanged += SenseHat_PressureChanged;
      SenseHat.TemperatureChanged += SenseHat_TemperatureChanged;

      node.LED.SetColor.OnCall = SetLEDColor;
    }

    private void SenseHat_JoystickEventGenerator(object sender, EventArgs e)
    {
      try
      {
        bool pushbutton = SenseHat.JoystickPushbutton();
        if (pushbutton != prevPushbuttonState)
        {
          var pushbuttonEvent = new PushbuttonEventState(SenseHatNode.Joystick.Pushbutton);
          pushbuttonEvent.Initialize(
            SystemContext,
            SenseHatNode.Joystick.Pushbutton,
            EventSeverity.Min,
            pushbutton ? "Button pressed" : "Button released");

          pushbuttonEvent.SetChildValue(
            SystemContext,
            Opc.Ua.BrowseNames.SourceName,
            "SenseHat joystick pushbutton",
            false);
          pushbuttonEvent.SetChildValue(
            SystemContext,
            new QualifiedName(Nodes.SenseHat.BrowseNames.PushbuttonState, NamespaceIndex),
            pushbutton,
            false);

          SenseHatNode.Joystick.Pushbutton.ReportEvent(SystemContext, pushbuttonEvent);
        }

        prevPushbuttonState = pushbutton;
      }
      catch (Exception)
      {
      }
    }

    private void SenseHat_TemperatureChanged(object sender, EventArgs e)
    {
      try
      {
        SenseHatNode.Temperature.Output.Value = SenseHat.Temperature();
        SenseHatNode.ClearChangeMasks(SystemContext, true);
      }
      catch (Exception)
      {
      }
    }

    private void SenseHat_PressureChanged(object sender, EventArgs e)
    {
      try
      {
        SenseHatNode.Pressure.Output.Value = SenseHat.Pressure();
        SenseHatNode.ClearChangeMasks(SystemContext, true);
      }
      catch (Exception)
      {
      }
    }

    private void SenseHat_MagnetometerChanged(object sender, EventArgs e)
    {
      try
      {
        var mag = SenseHat.Magnetometer();
        SenseHatNode.Magnetometer.X.Value = mag.X;
        SenseHatNode.Magnetometer.Y.Value = mag.Y;
        SenseHatNode.Magnetometer.Z.Value = mag.Z;
        SenseHatNode.ClearChangeMasks(SystemContext, true);
      }
      catch (Exception)
      {
      }
    }

    private void SenseHat_JoystickChanged(object sender, EventArgs e)
    {
      try
      {
        SenseHatNode.Joystick.Up.Value = SenseHat.JoystickUp();
        SenseHatNode.Joystick.Down.Value = SenseHat.JoystickDown();
        SenseHatNode.Joystick.Left.Value = SenseHat.JoystickLeft();
        SenseHatNode.Joystick.Right.Value = SenseHat.JoystickRight();
        SenseHatNode.Joystick.Pushbutton.Value = SenseHat.JoystickPushbutton();
        SenseHatNode.ClearChangeMasks(SystemContext, true);
      }
      catch (Exception)
      {
      }
    }

    private void SenseHat_HumidityChanged(object sender, EventArgs e)
    {
      try
      {
        SenseHatNode.Humidity.Output.Value = SenseHat.Humidity();
        SenseHatNode.ClearChangeMasks(SystemContext, true);
      }
      catch (Exception)
      {
      }
    }

    private void SenseHat_AngularRateChanged(object sender, EventArgs e)
    {
      try
      {
        var angular = SenseHat.AngularRate();
        SenseHatNode.AngularRate.X.Value = angular.X;
        SenseHatNode.AngularRate.Y.Value = angular.Y;
        SenseHatNode.AngularRate.Z.Value = angular.Z;
        SenseHatNode.ClearChangeMasks(SystemContext, true);
      }
      catch (Exception)
      {
      }
    }

    private void SenseHat_AccelerometerChanged(object sender, EventArgs e)
    {
      try
      {
        var accel = SenseHat.Accelerometer();
        SenseHatNode.Accelerometer.X.Value = accel.X;
        SenseHatNode.Accelerometer.Y.Value = accel.Y;
        SenseHatNode.Accelerometer.Z.Value = accel.Z;
        SenseHatNode.ClearChangeMasks(SystemContext, true);
      }
      catch (Exception)
      {
      }
    }

    private ServiceResult SetLEDColor(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        byte red,
        byte green,
        byte blue)
    {
      try
      {
        SenseHat.SetLED(red, green, blue);
      }
      catch (Exception ex)
      {
        return new ServiceResult(ex);
      }

      return ServiceResult.Good;
    }
    #endregion

    #region Private Fields
    private ushort m_namespaceIndex;
    private ushort m_typeNamespaceIndex;

    private ISenseHat SenseHat;

    private SenseHatState SenseHatNode;
    private bool prevPushbuttonState;
    #endregion
  }
}
