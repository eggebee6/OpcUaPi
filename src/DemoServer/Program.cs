using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using PiServer;
using PiServer.Nodes.SenseHat;
using System;
using System.Threading;

namespace DemoServer
{
  class Program
  {
    private static ILogger<Program> logger = NullLogger<Program>.Instance;

    static void Main(string[] args)
    {
      var loggerFactory = LoggerFactory.Create(configure => configure.AddConsole());
      logger = loggerFactory.CreateLogger<Program>();

      ISenseHat senseHat = CreateSenseHat(loggerFactory.CreateLogger<ISenseHat>());

      var piServer = new OpcUaPiServer(options =>
      {
        options.SenseHat = senseHat;
        options.AutoAccept = true;
        options.Logger = loggerFactory.CreateLogger<OpcUaPiServer>();
      });

      try
      {
        OpcUaPiServer.LaunchServer(piServer, "Resources/Configuration/PiServer.Config.xml").Wait();

        ManualResetEvent quitEvent = new ManualResetEvent(false);
        Console.CancelKeyPress += (sender, eArgs) =>
        {
          quitEvent.Set();
          eArgs.Cancel = true;
        };

        logger.LogInformation("Running server...");
        quitEvent.WaitOne(Timeout.Infinite);
        logger.LogWarning("Stopping server...");
      }
      catch (Exception ex)
      {
        logger.LogError($"Launch failed: {ex.Message}");
      }
      finally
      {
        OpcUaPiServer.StopServer(piServer);
      }
    }

    private static ISenseHat CreateSenseHat(ILogger<ISenseHat> logger)
    {
      try
      {
        return new SenseHatDevice(logger);
      }
      catch (Exception)
      {
        logger.LogWarning("Failed to create SenseHat device, using simulated SenseHat");
        return new SenseHatSimulated(logger);
      }
    }
  }
}
