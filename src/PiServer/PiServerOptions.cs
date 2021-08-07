using Microsoft.Extensions.Logging;
using PiServer.Nodes.SenseHat;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiServer
{
  public class PiServerOptions
  {
    public ISenseHat SenseHat { get; set; }
    public bool AutoAccept { get; set; }
    public ILogger<OpcUaPiServer> Logger { get; set; }
  }
}
