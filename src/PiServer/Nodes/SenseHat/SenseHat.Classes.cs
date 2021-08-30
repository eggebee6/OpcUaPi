/* ========================================================================
 * Copyright (c) 2005-2021 The OPC Foundation, Inc. All rights reserved.
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
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;

namespace PiServer.Nodes.SenseHat
{
    #region GenericSensorState Class
    #if (!OPCUA_EXCLUDE_GenericSensorState)
    /// <summary>
    /// Stores an instance of the GenericSensorType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GenericSensorState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public GenericSensorState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(PiServer.Nodes.SenseHat.ObjectTypes.GenericSensorType, PiServer.Nodes.SenseHat.Namespaces.SenseHat, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACYAAABodHRwOi8vbWtlY3liZXJ0ZWNoLmNvbS9VQS9QaS9TZW5zZUhhdP////8EYIACAQAAAAEA" +
           "GQAAAEdlbmVyaWNTZW5zb3JUeXBlSW5zdGFuY2UBAQEAAQEBAAEAAAD/////AgAAADVgiQoCAAAAAQAG" +
           "AAAAT3V0cHV0AQECAAMAAAAAEwAAAFNlbnNvciBvdXRwdXQgdmFsdWUALwA/AgAAAAAL/////wEB////" +
           "/wAAAAA1YIkKAgAAAAEABQAAAFVuaXRzAQEDAAMAAAAADAAAAFNlbnNvciB1bml0cwAuAEQDAAAAAAz/" +
           "////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseDataVariableState<double> Output
        {
            get
            {
                return m_output;
            }

            set
            {
                if (!Object.ReferenceEquals(m_output, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_output = value;
            }
        }

        /// <remarks />
        public PropertyState<string> Units
        {
            get
            {
                return m_units;
            }

            set
            {
                if (!Object.ReferenceEquals(m_units, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_units = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_output != null)
            {
                children.Add(m_output);
            }

            if (m_units != null)
            {
                children.Add(m_units);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case PiServer.Nodes.SenseHat.BrowseNames.Output:
                {
                    if (createOrReplace)
                    {
                        if (Output == null)
                        {
                            if (replacement == null)
                            {
                                Output = new BaseDataVariableState<double>(this);
                            }
                            else
                            {
                                Output = (BaseDataVariableState<double>)replacement;
                            }
                        }
                    }

                    instance = Output;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.Units:
                {
                    if (createOrReplace)
                    {
                        if (Units == null)
                        {
                            if (replacement == null)
                            {
                                Units = new PropertyState<string>(this);
                            }
                            else
                            {
                                Units = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Units;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseDataVariableState<double> m_output;
        private PropertyState<string> m_units;
        #endregion
    }
    #endif
    #endregion

    #region GenericSensor3DState Class
    #if (!OPCUA_EXCLUDE_GenericSensor3DState)
    /// <summary>
    /// Stores an instance of the GenericSensor3DType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GenericSensor3DState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public GenericSensor3DState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(PiServer.Nodes.SenseHat.ObjectTypes.GenericSensor3DType, PiServer.Nodes.SenseHat.Namespaces.SenseHat, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACYAAABodHRwOi8vbWtlY3liZXJ0ZWNoLmNvbS9VQS9QaS9TZW5zZUhhdP////8EYIACAQAAAAEA" +
           "GwAAAEdlbmVyaWNTZW5zb3IzRFR5cGVJbnN0YW5jZQEBBAABAQQABAAAAP////8EAAAANWCJCgIAAAAB" +
           "AAEAAABYAQEFAAMAAAAADQAAAFgtYXhpcyBvdXRwdXQALwA/BQAAAAAL/////wEB/////wAAAAA1YIkK" +
           "AgAAAAEAAQAAAFkBAQYAAwAAAAANAAAAWS1heGlzIG91dHB1dAAvAD8GAAAAAAv/////AQH/////AAAA" +
           "ADVgiQoCAAAAAQABAAAAWgEBBwADAAAAAA0AAABaLWF4aXMgb3V0cHV0AC8APwcAAAAAC/////8BAf//" +
           "//8AAAAANWCJCgIAAAABAAUAAABVbml0cwEBCAADAAAAAAwAAABTZW5zb3IgdW5pdHMALgBECAAAAAAM" +
           "/////wEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseDataVariableState<double> X
        {
            get
            {
                return m_x;
            }

            set
            {
                if (!Object.ReferenceEquals(m_x, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_x = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<double> Y
        {
            get
            {
                return m_y;
            }

            set
            {
                if (!Object.ReferenceEquals(m_y, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_y = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<double> Z
        {
            get
            {
                return m_z;
            }

            set
            {
                if (!Object.ReferenceEquals(m_z, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_z = value;
            }
        }

        /// <remarks />
        public PropertyState<string> Units
        {
            get
            {
                return m_units;
            }

            set
            {
                if (!Object.ReferenceEquals(m_units, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_units = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_x != null)
            {
                children.Add(m_x);
            }

            if (m_y != null)
            {
                children.Add(m_y);
            }

            if (m_z != null)
            {
                children.Add(m_z);
            }

            if (m_units != null)
            {
                children.Add(m_units);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case PiServer.Nodes.SenseHat.BrowseNames.X:
                {
                    if (createOrReplace)
                    {
                        if (X == null)
                        {
                            if (replacement == null)
                            {
                                X = new BaseDataVariableState<double>(this);
                            }
                            else
                            {
                                X = (BaseDataVariableState<double>)replacement;
                            }
                        }
                    }

                    instance = X;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.Y:
                {
                    if (createOrReplace)
                    {
                        if (Y == null)
                        {
                            if (replacement == null)
                            {
                                Y = new BaseDataVariableState<double>(this);
                            }
                            else
                            {
                                Y = (BaseDataVariableState<double>)replacement;
                            }
                        }
                    }

                    instance = Y;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.Z:
                {
                    if (createOrReplace)
                    {
                        if (Z == null)
                        {
                            if (replacement == null)
                            {
                                Z = new BaseDataVariableState<double>(this);
                            }
                            else
                            {
                                Z = (BaseDataVariableState<double>)replacement;
                            }
                        }
                    }

                    instance = Z;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.Units:
                {
                    if (createOrReplace)
                    {
                        if (Units == null)
                        {
                            if (replacement == null)
                            {
                                Units = new PropertyState<string>(this);
                            }
                            else
                            {
                                Units = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Units;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseDataVariableState<double> m_x;
        private BaseDataVariableState<double> m_y;
        private BaseDataVariableState<double> m_z;
        private PropertyState<string> m_units;
        #endregion
    }
    #endif
    #endregion

    #region PushbuttonEventState Class
    #if (!OPCUA_EXCLUDE_PushbuttonEventState)
    /// <summary>
    /// Stores an instance of the PushbuttonEventType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class PushbuttonEventState : BaseEventState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public PushbuttonEventState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(PiServer.Nodes.SenseHat.ObjectTypes.PushbuttonEventType, PiServer.Nodes.SenseHat.Namespaces.SenseHat, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACYAAABodHRwOi8vbWtlY3liZXJ0ZWNoLmNvbS9VQS9QaS9TZW5zZUhhdP////8EYIACAQAAAAEA" +
           "GwAAAFB1c2hidXR0b25FdmVudFR5cGVJbnN0YW5jZQEBCQABAQkACQAAAP////8JAAAAFWCJCgIAAAAA" +
           "AAcAAABFdmVudElkAQEKAAAuAEQKAAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRU" +
           "eXBlAQELAAAuAEQLAAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEBDAAA" +
           "LgBEDAAAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAQ0AAC4ARA0AAAAA" +
           "DP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQEOAAAuAEQOAAAAAQAmAf////8BAf////8A" +
           "AAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEBDwAALgBEDwAAAAEAJgH/////AQH/////AAAAABVg" +
           "iQoCAAAAAAAHAAAATWVzc2FnZQEBEQAALgBEEQAAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAA" +
           "AFNldmVyaXR5AQESAAAuAEQSAAAAAAX/////AQH/////AAAAABVgiQoCAAAAAQAPAAAAUHVzaGJ1dHRv" +
           "blN0YXRlAQETAAAuAEQTAAAAAAH/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public PropertyState<bool> PushbuttonState
        {
            get
            {
                return m_pushbuttonState;
            }

            set
            {
                if (!Object.ReferenceEquals(m_pushbuttonState, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_pushbuttonState = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_pushbuttonState != null)
            {
                children.Add(m_pushbuttonState);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case PiServer.Nodes.SenseHat.BrowseNames.PushbuttonState:
                {
                    if (createOrReplace)
                    {
                        if (PushbuttonState == null)
                        {
                            if (replacement == null)
                            {
                                PushbuttonState = new PropertyState<bool>(this);
                            }
                            else
                            {
                                PushbuttonState = (PropertyState<bool>)replacement;
                            }
                        }
                    }

                    instance = PushbuttonState;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<bool> m_pushbuttonState;
        #endregion
    }
    #endif
    #endregion

    #region JoystickState Class
    #if (!OPCUA_EXCLUDE_JoystickState)
    /// <summary>
    /// Stores an instance of the JoystickType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class JoystickState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public JoystickState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(PiServer.Nodes.SenseHat.ObjectTypes.JoystickType, PiServer.Nodes.SenseHat.Namespaces.SenseHat, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACYAAABodHRwOi8vbWtlY3liZXJ0ZWNoLmNvbS9VQS9QaS9TZW5zZUhhdP////+EYIACAQAAAAEA" +
           "FAAAAEpveXN0aWNrVHlwZUluc3RhbmNlAQEUAAEBFAAUAAAAAQEAAAAAJAABARkABQAAADVgiQoCAAAA" +
           "AQACAAAAVXABARUAAwAAAAAMAAAAVXAgZGlyZWN0aW9uAC8APxUAAAAAAf////8BAf////8AAAAANWCJ" +
           "CgIAAAABAAQAAABEb3duAQEWAAMAAAAADgAAAERvd24gZGlyZWN0aW9uAC8APxYAAAAAAf////8BAf//" +
           "//8AAAAANWCJCgIAAAABAAQAAABMZWZ0AQEXAAMAAAAADgAAAExlZnQgZGlyZWN0aW9uAC8APxcAAAAA" +
           "Af////8BAf////8AAAAANWCJCgIAAAABAAUAAABSaWdodAEBGAADAAAAAA8AAABSaWdodCBkaXJlY3Rp" +
           "b24ALwA/GAAAAAAB/////wEB/////wAAAAA1YIkKAgAAAAEACgAAAFB1c2hidXR0b24BARkAAwAAAAAK" +
           "AAAAUHVzaGJ1dHRvbgAvAD8ZAAAAAAH/////AQEBAAAAACQBAQEUAAAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseDataVariableState<bool> Up
        {
            get
            {
                return m_up;
            }

            set
            {
                if (!Object.ReferenceEquals(m_up, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_up = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<bool> Down
        {
            get
            {
                return m_down;
            }

            set
            {
                if (!Object.ReferenceEquals(m_down, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_down = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<bool> Left
        {
            get
            {
                return m_left;
            }

            set
            {
                if (!Object.ReferenceEquals(m_left, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_left = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<bool> Right
        {
            get
            {
                return m_right;
            }

            set
            {
                if (!Object.ReferenceEquals(m_right, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_right = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<bool> Pushbutton
        {
            get
            {
                return m_pushbutton;
            }

            set
            {
                if (!Object.ReferenceEquals(m_pushbutton, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_pushbutton = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_up != null)
            {
                children.Add(m_up);
            }

            if (m_down != null)
            {
                children.Add(m_down);
            }

            if (m_left != null)
            {
                children.Add(m_left);
            }

            if (m_right != null)
            {
                children.Add(m_right);
            }

            if (m_pushbutton != null)
            {
                children.Add(m_pushbutton);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case PiServer.Nodes.SenseHat.BrowseNames.Up:
                {
                    if (createOrReplace)
                    {
                        if (Up == null)
                        {
                            if (replacement == null)
                            {
                                Up = new BaseDataVariableState<bool>(this);
                            }
                            else
                            {
                                Up = (BaseDataVariableState<bool>)replacement;
                            }
                        }
                    }

                    instance = Up;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.Down:
                {
                    if (createOrReplace)
                    {
                        if (Down == null)
                        {
                            if (replacement == null)
                            {
                                Down = new BaseDataVariableState<bool>(this);
                            }
                            else
                            {
                                Down = (BaseDataVariableState<bool>)replacement;
                            }
                        }
                    }

                    instance = Down;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.Left:
                {
                    if (createOrReplace)
                    {
                        if (Left == null)
                        {
                            if (replacement == null)
                            {
                                Left = new BaseDataVariableState<bool>(this);
                            }
                            else
                            {
                                Left = (BaseDataVariableState<bool>)replacement;
                            }
                        }
                    }

                    instance = Left;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.Right:
                {
                    if (createOrReplace)
                    {
                        if (Right == null)
                        {
                            if (replacement == null)
                            {
                                Right = new BaseDataVariableState<bool>(this);
                            }
                            else
                            {
                                Right = (BaseDataVariableState<bool>)replacement;
                            }
                        }
                    }

                    instance = Right;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.Pushbutton:
                {
                    if (createOrReplace)
                    {
                        if (Pushbutton == null)
                        {
                            if (replacement == null)
                            {
                                Pushbutton = new BaseDataVariableState<bool>(this);
                            }
                            else
                            {
                                Pushbutton = (BaseDataVariableState<bool>)replacement;
                            }
                        }
                    }

                    instance = Pushbutton;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseDataVariableState<bool> m_up;
        private BaseDataVariableState<bool> m_down;
        private BaseDataVariableState<bool> m_left;
        private BaseDataVariableState<bool> m_right;
        private BaseDataVariableState<bool> m_pushbutton;
        #endregion
    }
    #endif
    #endregion

    #region SetRGBLEDColorMethodState Class
    #if (!OPCUA_EXCLUDE_SetRGBLEDColorMethodState)
    /// <summary>
    /// Stores an instance of the SetRGBLEDColor Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class SetRGBLEDColorMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public SetRGBLEDColorMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new SetRGBLEDColorMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACYAAABodHRwOi8vbWtlY3liZXJ0ZWNoLmNvbS9VQS9QaS9TZW5zZUhhdP////8EYYIKBAAAAAEA" +
           "DgAAAFNldFJHQkxFRENvbG9yAQEaAAAvAQEaABoAAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1" +
           "dEFyZ3VtZW50cwEBGwAALgBEGwAAAJYDAAAAAQAqAQESAAAAAwAAAFJlZAAD/////wAAAAAAAQAqAQEU" +
           "AAAABQAAAEdyZWVuAAP/////AAAAAAABACoBARMAAAAEAAAAQmx1ZQAD/////wAAAAAAAQAoAQEAAAAB" +
           "AAAAAAAAAAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public SetRGBLEDColorMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        protected override ServiceResult Call(
            ISystemContext _context,
            NodeId _objectId,
            IList<object> _inputArguments,
            IList<object> _outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(_context, _objectId, _inputArguments, _outputArguments);
            }

            ServiceResult result = null;

            byte red = (byte)_inputArguments[0];
            byte green = (byte)_inputArguments[1];
            byte blue = (byte)_inputArguments[2];

            if (OnCall != null)
            {
                result = OnCall(
                    _context,
                    this,
                    _objectId,
                    red,
                    green,
                    blue);
            }

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult SetRGBLEDColorMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        byte red,
        byte green,
        byte blue);
    #endif
    #endregion

    #region RGBLEDState Class
    #if (!OPCUA_EXCLUDE_RGBLEDState)
    /// <summary>
    /// Stores an instance of the RGBLEDType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class RGBLEDState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public RGBLEDState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(PiServer.Nodes.SenseHat.ObjectTypes.RGBLEDType, PiServer.Nodes.SenseHat.Namespaces.SenseHat, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACYAAABodHRwOi8vbWtlY3liZXJ0ZWNoLmNvbS9VQS9QaS9TZW5zZUhhdP////8EYIACAQAAAAEA" +
           "EgAAAFJHQkxFRFR5cGVJbnN0YW5jZQEBHAABARwAHAAAAP////8EAAAANWCJCgIAAAABAAMAAABSZWQB" +
           "AR0AAwAAAAANAAAAUmVkIGludGVuc2l0eQAvAD8dAAAAAAP/////AQH/////AAAAADVgiQoCAAAAAQAF" +
           "AAAAR3JlZW4BAR4AAwAAAAAPAAAAR3JlZW4gaW50ZW5zaXR5AC8APx4AAAAAA/////8BAf////8AAAAA" +
           "NWCJCgIAAAABAAQAAABCbHVlAQEfAAMAAAAADgAAAEJsdWUgaW50ZW5zaXR5AC8APx8AAAAAA/////8B" +
           "Af////8AAAAABGGCCgQAAAABAAgAAABTZXRDb2xvcgEBIAAALwEBIAAgAAAAAQH/////AQAAABdgqQoC" +
           "AAAAAAAOAAAASW5wdXRBcmd1bWVudHMBASEAAC4ARCEAAACWAwAAAAEAKgEBEgAAAAMAAABSZWQAA///" +
           "//8AAAAAAAEAKgEBFAAAAAUAAABHcmVlbgAD/////wAAAAAAAQAqAQETAAAABAAAAEJsdWUAA/////8A" +
           "AAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseDataVariableState<byte> Red
        {
            get
            {
                return m_red;
            }

            set
            {
                if (!Object.ReferenceEquals(m_red, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_red = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<byte> Green
        {
            get
            {
                return m_green;
            }

            set
            {
                if (!Object.ReferenceEquals(m_green, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_green = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<byte> Blue
        {
            get
            {
                return m_blue;
            }

            set
            {
                if (!Object.ReferenceEquals(m_blue, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_blue = value;
            }
        }

        /// <remarks />
        public SetRGBLEDColorMethodState SetColor
        {
            get
            {
                return m_setColorMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_setColorMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_setColorMethod = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_red != null)
            {
                children.Add(m_red);
            }

            if (m_green != null)
            {
                children.Add(m_green);
            }

            if (m_blue != null)
            {
                children.Add(m_blue);
            }

            if (m_setColorMethod != null)
            {
                children.Add(m_setColorMethod);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case PiServer.Nodes.SenseHat.BrowseNames.Red:
                {
                    if (createOrReplace)
                    {
                        if (Red == null)
                        {
                            if (replacement == null)
                            {
                                Red = new BaseDataVariableState<byte>(this);
                            }
                            else
                            {
                                Red = (BaseDataVariableState<byte>)replacement;
                            }
                        }
                    }

                    instance = Red;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.Green:
                {
                    if (createOrReplace)
                    {
                        if (Green == null)
                        {
                            if (replacement == null)
                            {
                                Green = new BaseDataVariableState<byte>(this);
                            }
                            else
                            {
                                Green = (BaseDataVariableState<byte>)replacement;
                            }
                        }
                    }

                    instance = Green;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.Blue:
                {
                    if (createOrReplace)
                    {
                        if (Blue == null)
                        {
                            if (replacement == null)
                            {
                                Blue = new BaseDataVariableState<byte>(this);
                            }
                            else
                            {
                                Blue = (BaseDataVariableState<byte>)replacement;
                            }
                        }
                    }

                    instance = Blue;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.SetColor:
                {
                    if (createOrReplace)
                    {
                        if (SetColor == null)
                        {
                            if (replacement == null)
                            {
                                SetColor = new SetRGBLEDColorMethodState(this);
                            }
                            else
                            {
                                SetColor = (SetRGBLEDColorMethodState)replacement;
                            }
                        }
                    }

                    instance = SetColor;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseDataVariableState<byte> m_red;
        private BaseDataVariableState<byte> m_green;
        private BaseDataVariableState<byte> m_blue;
        private SetRGBLEDColorMethodState m_setColorMethod;
        #endregion
    }
    #endif
    #endregion

    #region SenseHatState Class
    #if (!OPCUA_EXCLUDE_SenseHatState)
    /// <summary>
    /// Stores an instance of the SenseHatType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class SenseHatState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public SenseHatState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(PiServer.Nodes.SenseHat.ObjectTypes.SenseHatType, PiServer.Nodes.SenseHat.Namespaces.SenseHat, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACYAAABodHRwOi8vbWtlY3liZXJ0ZWNoLmNvbS9VQS9QaS9TZW5zZUhhdP////+EYIACAQAAAAEA" +
           "FAAAAFNlbnNlSGF0VHlwZUluc3RhbmNlAQEiAAEBIgAiAAAAAQIAAAAAMAABATsAADABAQDNCAgAAAAE" +
           "YMAKAQAAAAsAAABUZW1wZXJhdHVyZQEAEgAAAFRlbXBlcmF0dXJlIHNlbnNvcgEBIwAALwEBAQAjAAAA" +
           "/////wIAAAA1YIkKAgAAAAEABgAAAE91dHB1dAEBJAADAAAAABMAAABTZW5zb3Igb3V0cHV0IHZhbHVl" +
           "AC8APyQAAAAAC/////8BAf////8AAAAANWCJCgIAAAABAAUAAABVbml0cwEBJQADAAAAAAwAAABTZW5z" +
           "b3IgdW5pdHMALgBEJQAAAAAM/////wEB/////wAAAAAEYMAKAQAAAAgAAABQcmVzc3VyZQEADwAAAFBy" +
           "ZXNzdXJlIHNlbnNvcgEBJgAALwEBAQAmAAAA/////wIAAAA1YIkKAgAAAAEABgAAAE91dHB1dAEBJwAD" +
           "AAAAABMAAABTZW5zb3Igb3V0cHV0IHZhbHVlAC8APycAAAAAC/////8BAf////8AAAAANWCJCgIAAAAB" +
           "AAUAAABVbml0cwEBKAADAAAAAAwAAABTZW5zb3IgdW5pdHMALgBEKAAAAAAM/////wEB/////wAAAAAE" +
           "YMAKAQAAAAgAAABIdW1pZGl0eQEADwAAAEh1bWlkaXR5IHNlbnNvcgEBKQAALwEBAQApAAAA/////wIA" +
           "AAA1YIkKAgAAAAEABgAAAE91dHB1dAEBKgADAAAAABMAAABTZW5zb3Igb3V0cHV0IHZhbHVlAC8APyoA" +
           "AAAAC/////8BAf////8AAAAANWCJCgIAAAABAAUAAABVbml0cwEBKwADAAAAAAwAAABTZW5zb3IgdW5p" +
           "dHMALgBEKwAAAAAM/////wEB/////wAAAAAEYIAKAQAAAAEADAAAAE1hZ25ldG9tZXRlcgEBLAAALwEB" +
           "BAAsAAAA/////wQAAAA1YIkKAgAAAAEAAQAAAFgBAS0AAwAAAAANAAAAWC1heGlzIG91dHB1dAAvAD8t" +
           "AAAAAAv/////AQH/////AAAAADVgiQoCAAAAAQABAAAAWQEBLgADAAAAAA0AAABZLWF4aXMgb3V0cHV0" +
           "AC8APy4AAAAAC/////8BAf////8AAAAANWCJCgIAAAABAAEAAABaAQEvAAMAAAAADQAAAFotYXhpcyBv" +
           "dXRwdXQALwA/LwAAAAAL/////wEB/////wAAAAA1YIkKAgAAAAEABQAAAFVuaXRzAQEwAAMAAAAADAAA" +
           "AFNlbnNvciB1bml0cwAuAEQwAAAAAAz/////AQH/////AAAAAARggAoBAAAAAQANAAAAQWNjZWxlcm9t" +
           "ZXRlcgEBMQAALwEBBAAxAAAA/////wQAAAA1YIkKAgAAAAEAAQAAAFgBATIAAwAAAAANAAAAWC1heGlz" +
           "IG91dHB1dAAvAD8yAAAAAAv/////AQH/////AAAAADVgiQoCAAAAAQABAAAAWQEBMwADAAAAAA0AAABZ" +
           "LWF4aXMgb3V0cHV0AC8APzMAAAAAC/////8BAf////8AAAAANWCJCgIAAAABAAEAAABaAQE0AAMAAAAA" +
           "DQAAAFotYXhpcyBvdXRwdXQALwA/NAAAAAAL/////wEB/////wAAAAA1YIkKAgAAAAEABQAAAFVuaXRz" +
           "AQE1AAMAAAAADAAAAFNlbnNvciB1bml0cwAuAEQ1AAAAAAz/////AQH/////AAAAAARgwAoBAAAACwAA" +
           "AEFuZ3VsYXJSYXRlAQATAAAAQW5ndWxhciByYXRlIHNlbnNvcgEBNgAALwEBBAA2AAAA/////wQAAAA1" +
           "YIkKAgAAAAEAAQAAAFgBATcAAwAAAAANAAAAWC1heGlzIG91dHB1dAAvAD83AAAAAAv/////AQH/////" +
           "AAAAADVgiQoCAAAAAQABAAAAWQEBOAADAAAAAA0AAABZLWF4aXMgb3V0cHV0AC8APzgAAAAAC/////8B" +
           "Af////8AAAAANWCJCgIAAAABAAEAAABaAQE5AAMAAAAADQAAAFotYXhpcyBvdXRwdXQALwA/OQAAAAAL" +
           "/////wEB/////wAAAAA1YIkKAgAAAAEABQAAAFVuaXRzAQE6AAMAAAAADAAAAFNlbnNvciB1bml0cwAu" +
           "AEQ6AAAAAAz/////AQH/////AAAAAIRgwAoBAAAACAAAAEpveXN0aWNrAQAnAAAARm91ci1kaXJlY3Rp" +
           "b24gam95c3RpY2sgd2l0aCBwdXNoYnV0dG9uAQE7AAAvAQEUADsAAAABAgAAAAAwAQEBIgAAJAABAUAA" +
           "BQAAADVgiQoCAAAAAQACAAAAVXABATwAAwAAAAAMAAAAVXAgZGlyZWN0aW9uAC8APzwAAAAAAf////8B" +
           "Af////8AAAAANWCJCgIAAAABAAQAAABEb3duAQE9AAMAAAAADgAAAERvd24gZGlyZWN0aW9uAC8APz0A" +
           "AAAAAf////8BAf////8AAAAANWCJCgIAAAABAAQAAABMZWZ0AQE+AAMAAAAADgAAAExlZnQgZGlyZWN0" +
           "aW9uAC8APz4AAAAAAf////8BAf////8AAAAANWCJCgIAAAABAAUAAABSaWdodAEBPwADAAAAAA8AAABS" +
           "aWdodCBkaXJlY3Rpb24ALwA/PwAAAAAB/////wEB/////wAAAAA1YIkKAgAAAAEACgAAAFB1c2hidXR0" +
           "b24BAUAAAwAAAAAKAAAAUHVzaGJ1dHRvbgAvAD9AAAAAAAH/////AQEBAAAAACQBAQE7AAAAAAAEYMAK" +
           "AQAAAAMAAABMRUQBAAcAAABSR0IgTEVEAQFBAAAvAQEcAEEAAAD/////BAAAADVgiQoCAAAAAQADAAAA" +
           "UmVkAQFCAAMAAAAADQAAAFJlZCBpbnRlbnNpdHkALwA/QgAAAAAD/////wEB/////wAAAAA1YIkKAgAA" +
           "AAEABQAAAEdyZWVuAQFDAAMAAAAADwAAAEdyZWVuIGludGVuc2l0eQAvAD9DAAAAAAP/////AQH/////" +
           "AAAAADVgiQoCAAAAAQAEAAAAQmx1ZQEBRAADAAAAAA4AAABCbHVlIGludGVuc2l0eQAvAD9EAAAAAAP/" +
           "////AQH/////AAAAAARhggoEAAAAAQAIAAAAU2V0Q29sb3IBAUUAAC8BASAARQAAAAEB/////wEAAAAX" +
           "YKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQFGAAAuAERGAAAAlgMAAAABACoBARIAAAADAAAAUmVk" +
           "AAP/////AAAAAAABACoBARQAAAAFAAAAR3JlZW4AA/////8AAAAAAAEAKgEBEwAAAAQAAABCbHVlAAP/" +
           "////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public GenericSensorState Temperature
        {
            get
            {
                return m_temperature;
            }

            set
            {
                if (!Object.ReferenceEquals(m_temperature, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_temperature = value;
            }
        }

        /// <remarks />
        public GenericSensorState Pressure
        {
            get
            {
                return m_pressure;
            }

            set
            {
                if (!Object.ReferenceEquals(m_pressure, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_pressure = value;
            }
        }

        /// <remarks />
        public GenericSensorState Humidity
        {
            get
            {
                return m_humidity;
            }

            set
            {
                if (!Object.ReferenceEquals(m_humidity, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_humidity = value;
            }
        }

        /// <remarks />
        public GenericSensor3DState Magnetometer
        {
            get
            {
                return m_magnetometer;
            }

            set
            {
                if (!Object.ReferenceEquals(m_magnetometer, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_magnetometer = value;
            }
        }

        /// <remarks />
        public GenericSensor3DState Accelerometer
        {
            get
            {
                return m_accelerometer;
            }

            set
            {
                if (!Object.ReferenceEquals(m_accelerometer, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_accelerometer = value;
            }
        }

        /// <remarks />
        public GenericSensor3DState AngularRate
        {
            get
            {
                return m_angularRate;
            }

            set
            {
                if (!Object.ReferenceEquals(m_angularRate, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_angularRate = value;
            }
        }

        /// <remarks />
        public JoystickState Joystick
        {
            get
            {
                return m_joystick;
            }

            set
            {
                if (!Object.ReferenceEquals(m_joystick, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_joystick = value;
            }
        }

        /// <remarks />
        public RGBLEDState LED
        {
            get
            {
                return m_lED;
            }

            set
            {
                if (!Object.ReferenceEquals(m_lED, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_lED = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_temperature != null)
            {
                children.Add(m_temperature);
            }

            if (m_pressure != null)
            {
                children.Add(m_pressure);
            }

            if (m_humidity != null)
            {
                children.Add(m_humidity);
            }

            if (m_magnetometer != null)
            {
                children.Add(m_magnetometer);
            }

            if (m_accelerometer != null)
            {
                children.Add(m_accelerometer);
            }

            if (m_angularRate != null)
            {
                children.Add(m_angularRate);
            }

            if (m_joystick != null)
            {
                children.Add(m_joystick);
            }

            if (m_lED != null)
            {
                children.Add(m_lED);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case PiServer.Nodes.SenseHat.BrowseNames.Temperature:
                {
                    if (createOrReplace)
                    {
                        if (Temperature == null)
                        {
                            if (replacement == null)
                            {
                                Temperature = new GenericSensorState(this);
                            }
                            else
                            {
                                Temperature = (GenericSensorState)replacement;
                            }
                        }
                    }

                    instance = Temperature;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.Pressure:
                {
                    if (createOrReplace)
                    {
                        if (Pressure == null)
                        {
                            if (replacement == null)
                            {
                                Pressure = new GenericSensorState(this);
                            }
                            else
                            {
                                Pressure = (GenericSensorState)replacement;
                            }
                        }
                    }

                    instance = Pressure;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.Humidity:
                {
                    if (createOrReplace)
                    {
                        if (Humidity == null)
                        {
                            if (replacement == null)
                            {
                                Humidity = new GenericSensorState(this);
                            }
                            else
                            {
                                Humidity = (GenericSensorState)replacement;
                            }
                        }
                    }

                    instance = Humidity;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.Magnetometer:
                {
                    if (createOrReplace)
                    {
                        if (Magnetometer == null)
                        {
                            if (replacement == null)
                            {
                                Magnetometer = new GenericSensor3DState(this);
                            }
                            else
                            {
                                Magnetometer = (GenericSensor3DState)replacement;
                            }
                        }
                    }

                    instance = Magnetometer;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.Accelerometer:
                {
                    if (createOrReplace)
                    {
                        if (Accelerometer == null)
                        {
                            if (replacement == null)
                            {
                                Accelerometer = new GenericSensor3DState(this);
                            }
                            else
                            {
                                Accelerometer = (GenericSensor3DState)replacement;
                            }
                        }
                    }

                    instance = Accelerometer;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.AngularRate:
                {
                    if (createOrReplace)
                    {
                        if (AngularRate == null)
                        {
                            if (replacement == null)
                            {
                                AngularRate = new GenericSensor3DState(this);
                            }
                            else
                            {
                                AngularRate = (GenericSensor3DState)replacement;
                            }
                        }
                    }

                    instance = AngularRate;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.Joystick:
                {
                    if (createOrReplace)
                    {
                        if (Joystick == null)
                        {
                            if (replacement == null)
                            {
                                Joystick = new JoystickState(this);
                            }
                            else
                            {
                                Joystick = (JoystickState)replacement;
                            }
                        }
                    }

                    instance = Joystick;
                    break;
                }

                case PiServer.Nodes.SenseHat.BrowseNames.LED:
                {
                    if (createOrReplace)
                    {
                        if (LED == null)
                        {
                            if (replacement == null)
                            {
                                LED = new RGBLEDState(this);
                            }
                            else
                            {
                                LED = (RGBLEDState)replacement;
                            }
                        }
                    }

                    instance = LED;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private GenericSensorState m_temperature;
        private GenericSensorState m_pressure;
        private GenericSensorState m_humidity;
        private GenericSensor3DState m_magnetometer;
        private GenericSensor3DState m_accelerometer;
        private GenericSensor3DState m_angularRate;
        private JoystickState m_joystick;
        private RGBLEDState m_lED;
        #endregion
    }
    #endif
    #endregion
}