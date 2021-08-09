using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiClient
{
  public class PiClientOptions
  {
    public string EndpointUrl { get; set; }
    public bool AutoAccept { get; set; }
    public ILogger<OpcUaPiClient> Logger { get; set; }
  }
}
