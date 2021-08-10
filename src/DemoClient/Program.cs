using CommandLine;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using PiClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DemoClient
{
  class CommandLineOptions
  {
    [Option(shortName: 'u', longName: "endpointUrl", Required = true, HelpText = "Server endpoint Url")]
    public string EndpointUrl { get; set; }
  }
  // Example:  DemoClient --endpointUrl opc.tcp://192.168.0.200:43101

  class Program
  {
    private static ILogger<Program> logger = NullLogger<Program>.Instance;

    private const int ParseOK = 0;
    private const int ParseFailed = 1;

    static void Main(string[] args)
    {
      string endpointUrl = null;

      int result = Parser.Default
        .ParseArguments<CommandLineOptions>(args)
        .MapResult(
          options =>
          {
            endpointUrl = options.EndpointUrl;
            return ParseOK;
          },
          errors =>
          {
            return ParseFailed;
          });

      if (result != ParseOK)
      {
        Environment.Exit(result);
      }

      var loggerFactory = LoggerFactory.Create(configure => configure.AddConsole());
      logger = loggerFactory.CreateLogger<Program>();

      var client = new OpcUaPiClient(options =>
      {
        options.EndpointUrl = endpointUrl;
        options.AutoAccept = true;
        options.Logger = loggerFactory.CreateLogger<OpcUaPiClient>();
      });

      SenseHatClient senseHat;
      Timer updateTimer = null;

      try
      {
        OpcUaPiClient.LaunchClient(client, "Resources/Configuration/PiClient.Config.xml").Wait();

        senseHat = new SenseHatClient(client, loggerFactory.CreateLogger<SenseHatClient>());
        senseHat.Initialize();

        updateTimer = new Timer(_ =>
        {
          StringBuilder builder = new StringBuilder();
          builder.AppendLine($"Temperature: {senseHat.Temperature}");
          builder.AppendLine($"Pressure: {senseHat.Pressure}");
          builder.AppendLine($"Humidity: {senseHat.Humidity}");

          logger.LogInformation(builder.ToString());
        }, null, 1000, 5000);

        ManualResetEvent quitEvent = new ManualResetEvent(false);
        Console.CancelKeyPress += (sender, eArgs) =>
        {
          quitEvent.Set();
          eArgs.Cancel = true;
        };

        logger.LogInformation("Running client...");
        quitEvent.WaitOne(Timeout.Infinite);
        logger.LogWarning("Stopping client...");
      }
      catch (Exception ex)
      {
        logger.LogError($"Launch failed: {ex.Message}");
      }
      finally
      {
        OpcUaPiClient.StopClient(client);

        updateTimer?.Dispose();
        updateTimer = null;
      }
    }
  }
}
