using Microsoft.Extensions.Logging;
using Opc.Ua;
using Opc.Ua.Client;
using PiClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoClient
{
  public class SenseHatClient
  {
    private readonly OpcUaPiClient client;
    private readonly ILogger<SenseHatClient> logger;

    public const string TemperatureSensorNode = "/SenseHat/Temperature sensor/Output";
    public const string PressureSensorNode = "/SenseHat/Pressure sensor/Output";
    public const string HumiditySensorNode = "/SenseHat/Humidity sensor/Output";

    private readonly List<string> nodePaths = new List<string>()
    {
      TemperatureSensorNode,
      PressureSensorNode,
      HumiditySensorNode
    };
    private readonly Dictionary<string, NodeId> nodeMap = new Dictionary<string, NodeId>();

    public double Temperature { get; private set; }
    public double Pressure { get; private set; }
    public double Humidity { get; private set; }

    private NodeId piFolder;

    Subscription subscription;

    public SenseHatClient(OpcUaPiClient client, ILogger<SenseHatClient> logger)
    {
      if (client is null)
      {
        throw new ArgumentNullException(nameof(client));
      }

      this.client = client;
      this.logger = logger;
    }

    private void Log(string msg, LogLevel level = LogLevel.Information)
    {
      logger?.Log(level, msg);
    }

    public void Initialize()
    {
      if (client.Session is null)
      {
        throw new ArgumentException("Client session is null");
      }

      piFolder = FindPiFolder() ?? throw new Exception("Failed to find Pi folder");

      FindNodeIdsByBrowseName(piFolder);
      ConfigureSubscriptions();
    }

    private void ConfigureSubscriptions()
    {
      subscription = new Subscription()
      {
        PublishingEnabled = true,
        PublishingInterval = 500
      };

      foreach (var key in nodeMap.Keys)
      {
        NodeId id = nodeMap[key];
        if (id is null)
        {
          continue;
        }

        var monitor = new MonitoredItem()
        {
          MonitoringMode = MonitoringMode.Reporting,
          StartNodeId = id,
          AttributeId = Attributes.Value
        };

        MonitoredItemNotificationEventHandler handler = key switch
        {
          TemperatureSensorNode => OnTemperatureChanged,
          PressureSensorNode => OnPressureChanged,
          HumiditySensorNode => OnHumidityChanged,
          _ => OnUnhandledChange
        };
        monitor.Notification += new MonitoredItemNotificationEventHandler(handler);

        subscription.AddItem(monitor);
      }

      client.Session.AddSubscription(subscription);
      subscription.Create();
    }

    private NodeId FindPiFolder()
    {
      client.Session.Browse(
        null,
        null,
        ObjectIds.ObjectsFolder,
        0,
        BrowseDirection.Forward,
        ReferenceTypeIds.HierarchicalReferences,
        true,
        (uint)(NodeClass.Object),
        out Byte[] continuationPoint,
        out ReferenceDescriptionCollection references);

      foreach (var reference in references)
      {
        if (reference.BrowseName.Name == "Pi")
        {
          return ExpandedNodeId.ToNodeId(reference.NodeId, client.Session.NamespaceUris);
        }
      }

      return null;
    }

    private void FindNodeIdsByBrowseName(NodeId parentId, string browsePath = "")
    {
      client.Session.Browse(
        null,
        null,
        ExpandedNodeId.ToNodeId(parentId, client.Session.NamespaceUris),
        0,
        BrowseDirection.Forward,
        ReferenceTypeIds.HierarchicalReferences,
        true,
        (uint)(NodeClass.Variable | NodeClass.Object | NodeClass.Method),
        out Byte[] continuationPoint,
        out ReferenceDescriptionCollection references);

      foreach (var reference in references)
      {
        var browseName = $"{browsePath}/{reference.BrowseName.Name}";
        if (nodePaths.Contains(browseName) && !nodeMap.ContainsKey(browseName))
        {
          nodeMap.Add(browseName, ExpandedNodeId.ToNodeId(reference.NodeId, client.Session.NamespaceUris));
        }
        else
        {
          FindNodeIdsByBrowseName(ExpandedNodeId.ToNodeId(reference.NodeId, client.Session.NamespaceUris), browseName);
        }
      }
    }

    private bool TryGetItemValue(MonitoredItem item, out double result)
    {
      result = default;

      foreach (var val in item.DequeueValues())
      {
        var obj = val.Value as double?;
        if (obj.HasValue)
        {
          result = obj.Value;
          return true;
        }
      }

      return false;
    }

    private void OnUnhandledChange(MonitoredItem item, MonitoredItemNotificationEventArgs evt)
    {
      return;
    }

    private void OnTemperatureChanged(MonitoredItem item, MonitoredItemNotificationEventArgs evt)
    {
      if (TryGetItemValue(item, out double res))
      {
        Temperature = res;
      }
    }

    private void OnPressureChanged(MonitoredItem item, MonitoredItemNotificationEventArgs evt)
    {
      if (TryGetItemValue(item, out double res))
      {
        Pressure = res;
      }
    }

    private void OnHumidityChanged(MonitoredItem item, MonitoredItemNotificationEventArgs evt)
    {
      if (TryGetItemValue(item, out double res))
      {
        Humidity = res;
      }
    }
  }
}
