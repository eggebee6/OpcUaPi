using Microsoft.Extensions.Logging;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PiClient
{
  public class OpcUaPiClient
  {
    private string EndpointUrl { get; }
    private bool AutoAccept { get; }
    private ILogger<OpcUaPiClient> Logger { get; }

    public Session Session => opcSession;
    private Session opcSession;
    private SessionReconnectHandler reconnectHandler;
    private const int reconnectPeriod = 10;

    public OpcUaPiClient(Action<PiClientOptions> optionsConfig)
    {
      PiClientOptions opts = new PiClientOptions();
      optionsConfig(opts);

      EndpointUrl = opts.EndpointUrl;
      AutoAccept = opts.AutoAccept;
      Logger = opts.Logger;
    }

    private void Log(string msg, LogLevel level = LogLevel.Information)
    {
      Logger?.Log(level, msg);
    }

    public static async Task LaunchClient(OpcUaPiClient client, string configFile)
    {
      if (client is null)
      {
        throw new ArgumentNullException(nameof(client));
      }

      if (configFile is null)
      {
        throw new ArgumentNullException(nameof(configFile));
      }

      ApplicationInstance app = new ApplicationInstance
      {
        ApplicationName = "Pi Client",
        ApplicationType = ApplicationType.Client,
        ConfigSectionName = "PiClient"
      };

      ApplicationConfiguration config = await app.LoadApplicationConfiguration(configFile, false);

      bool haveAppCertificate = await app.CheckApplicationInstanceCertificate(false, 0);
      if (!haveAppCertificate)
      {
        throw new Exception("Application instance certificate invalid!");
      }

      config.ApplicationUri = X509Utils.GetApplicationUriFromCertificate(config.SecurityConfiguration.ApplicationCertificate.Certificate);
      config.CertificateValidator.CertificateValidation += client.CertificateValidation;

      var selectedEndpoint = CoreClientUtils.SelectEndpoint(client.EndpointUrl, haveAppCertificate, 15000);
      var endpointConfig = EndpointConfiguration.Create(config);
      var endpoint = new ConfiguredEndpoint(null, selectedEndpoint, endpointConfig);

      client.opcSession = await Session.Create(
        config,
        endpoint,
        false,
        "Pi Client",
        60000,
        new UserIdentity(new AnonymousIdentityToken()),
        null);

      client.opcSession.KeepAlive += client.KeepAlive;
    }

    public static Task StopClient(OpcUaPiClient client)
    {
      client.opcSession.CloseSession(null, true);
      return Task.CompletedTask;
    }

    private void KeepAlive(Session session, KeepAliveEventArgs e)
    {
      if ((e.Status != null) && ServiceResult.IsNotGood(e.Status))
      {
        if (reconnectHandler != null)
        {
          Log($"Reconnecting session");

          reconnectHandler = new SessionReconnectHandler();
          reconnectHandler.BeginReconnect(session, reconnectPeriod * 1000, (object senderObj, EventArgs args) =>
          {
            opcSession = reconnectHandler.Session;
            reconnectHandler.Dispose();
            reconnectHandler = null;
          });
        }
      }
    }

    private void CertificateValidation(CertificateValidator sender, CertificateValidationEventArgs e)
    {
      if (e.Error.StatusCode == StatusCodes.BadCertificateUntrusted)
      {
        e.Accept = AutoAccept;
        if (AutoAccept)
        {
          Log($"Accepted Certificate: {e.Certificate.Subject}");
        }
        else
        {
          Log($"Rejected Certificate: {e.Certificate.Subject}");
        }
      }
    }
  }
}
