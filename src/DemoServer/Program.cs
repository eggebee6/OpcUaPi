using CommandLine;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using PiServer;
using PiServer.Nodes.SenseHat;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace DemoServer
{
  class CommandLineOptions
  {
    [Option(shortName: 'c', longName: "certificate", Required = false, HelpText = "Server certificate filename")]
    public string CertificateFilename { get; set; }

    [Option(shortName: 'p', longName: "password", Required = false, HelpText = "Server certificate password")]
    public string CertificatePassword { get; set; }
  }
  // Example:  DemoServer --certificate ./Certificates/PiServer.pfx --password SuperSecret123

  class Program
  {
    private const int ParseOK = 0;
    private const int ParseFailed = 1;

    private static ILogger<Program> logger = NullLogger<Program>.Instance;

    static void Main(string[] args)
    {
      string certificateFilename = null;
      string certificatePassword = null;

      int result = Parser.Default
        .ParseArguments<CommandLineOptions>(args)
        .MapResult(
          options =>
          {
            certificateFilename = options.CertificateFilename;
            certificatePassword = options.CertificatePassword ?? string.Empty;

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

      ISenseHat senseHat = CreateSenseHat(loggerFactory.CreateLogger<ISenseHat>());

      var piServer = new OpcUaPiServer(options =>
      {
        options.SenseHat = senseHat;
        options.AutoAccept = true;
        options.Logger = loggerFactory.CreateLogger<OpcUaPiServer>();
      });

      X509Certificate2 certificate = null;
      if (certificateFilename != null)
      {
        try
        {
          certificate = new X509Certificate2(certificateFilename, certificatePassword);
        }
        catch (Exception ex)
        {
          certificate = null;
          logger.LogError($"Failed to load certificate: {ex.Message}");
        }
      }

      if (certificate != null)
      {
        logger.LogInformation($"Using certificate: {certificate.SubjectName.Name}");
      }
      else
      {
        logger.LogInformation($"Using default certificate");
      }

      try
      {
        OpcUaPiServer.LaunchServer(piServer, "Resources/Configuration/PiServer.Config.xml", certificate).Wait();

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
