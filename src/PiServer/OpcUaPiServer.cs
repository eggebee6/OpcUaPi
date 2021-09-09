﻿/* ========================================================================
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
using System.Security.Cryptography.X509Certificates;
using Opc.Ua;
using Opc.Ua.Server;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Opc.Ua.Configuration;
using PiServer.Nodes.SenseHat;

namespace PiServer
{
  /// <summary>
  /// Implements a basic Quickstart Server.
  /// </summary>
  /// <remarks>
  /// Each server instance must have one instance of a StandardServer object which is
  /// responsible for reading the configuration file, creating the endpoints and dispatching
  /// incoming requests to the appropriate handler.
  /// 
  /// This sub-class specifies non-configurable metadata such as Product Name and initializes
  /// the EmptyNodeManager which provides access to the data exposed by the Server.
  /// </remarks>
  public partial class OpcUaPiServer : StandardServer
  {
    #region Overridden Methods
    /// <summary>
    /// Creates the node managers for the server.
    /// </summary>
    /// <remarks>
    /// This method allows the sub-class create any additional node managers which it uses. The SDK
    /// always creates a CoreNodeManager which handles the built-in nodes defined by the specification.
    /// Any additional NodeManagers are expected to handle application specific nodes.
    /// </remarks>
    protected override MasterNodeManager CreateMasterNodeManager(IServerInternal server, ApplicationConfiguration configuration)
    {
      Log("Creating node managers");

      List<INodeManager> nodeManagers = new List<INodeManager>();

      // create the custom node managers.
      nodeManagers.Add(new PiServerNodeManager(server, configuration, SenseHat));

      // create master node manager.
      return new MasterNodeManager(server, configuration, null, nodeManagers.ToArray());
    }

    /// <summary>
    /// Loads the non-configurable properties for the application.
    /// </summary>
    /// <remarks>
    /// These properties are exposed by the server but cannot be changed by administrators.
    /// </remarks>
    protected override ServerProperties LoadServerProperties()
    {
      ServerProperties properties = new ServerProperties();

      properties.ManufacturerName = "Milwaukee Cybertech";
      properties.ProductName = "PiServer";
      properties.ProductUri = "http://mkecybertech.com/UA/PiServer";
      properties.SoftwareVersion = Utils.GetAssemblySoftwareVersion();
      properties.BuildNumber = Utils.GetAssemblyBuildNumber();
      properties.BuildDate = Utils.GetAssemblyTimestamp();

      // TBD - All applications have software certificates that need to added to the properties.

      return properties;
    }

    /// <summary>
    /// Creates the resource manager for the server.
    /// </summary>
    protected override ResourceManager CreateResourceManager(IServerInternal server, ApplicationConfiguration configuration)
    {
      ResourceManager resourceManager = new ResourceManager(server, configuration);

      System.Reflection.FieldInfo[] fields = typeof(StatusCodes).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

      foreach (System.Reflection.FieldInfo field in fields)
      {
        uint? id = field.GetValue(typeof(StatusCodes)) as uint?;

        if (id != null)
        {
          resourceManager.Add(id.Value, "en-US", field.Name);
        }
      }

      return resourceManager;
    }

    /// <summary>
    /// Initializes the server before it starts up.
    /// </summary>
    /// <remarks>
    /// This method is called before any startup processing occurs. The sub-class may update the 
    /// configuration object or do any other application specific startup tasks.
    /// </remarks>
    protected override void OnServerStarting(ApplicationConfiguration configuration)
    {
      Log("Server starting");

      base.OnServerStarting(configuration);

      // it is up to the application to decide how to validate user identity tokens.
      // this function creates validator for X509 identity tokens.
      CreateUserIdentityValidators(configuration);
    }

    /// <summary>
    /// Called after the server has been started.
    /// </summary>
    protected override void OnServerStarted(IServerInternal server)
    {
      base.OnServerStarted(server);

      // request notifications when the user identity is changed. all valid users are accepted by default.
      server.SessionManager.ImpersonateUser += new ImpersonateEventHandler(SessionManager_ImpersonateUser);

      try
      {
        // allow a faster sampling interval for CurrentTime node.
        server.Status.Variable.CurrentTime.MinimumSamplingInterval = 250;
      }
      catch
      { }
    }

    /// <summary>
    /// Initializes the address space after the NodeManagers have started.
    /// </summary>
    /// <remarks>
    /// This method can be used to create any initialization that requires access to node managers.
    /// </remarks>
    protected override void OnNodeManagerStarted(IServerInternal server)
    {
      Log("NodeManagers started");

      // allow base class processing to happen first.
      base.OnNodeManagerStarted(server);
    }

    protected override void OnServerStopping()
    {
      Log("Server stopping");

      base.OnServerStopping();
    }

    #endregion
    #region User Validation Functions
    /// <summary>
    /// Creates the objects used to validate the user identity tokens supported by the server.
    /// </summary>
    private void CreateUserIdentityValidators(ApplicationConfiguration configuration)
    {
      for (int ii = 0; ii < configuration.ServerConfiguration.UserTokenPolicies.Count; ii++)
      {
        UserTokenPolicy policy = configuration.ServerConfiguration.UserTokenPolicies[ii];

        // create a validator for a certificate token policy.
        if (policy.TokenType == UserTokenType.Certificate)
        {
          // check if user certificate trust lists are specified in configuration.
          if (configuration.SecurityConfiguration.TrustedUserCertificates != null &&
              configuration.SecurityConfiguration.UserIssuerCertificates != null)
          {
            CertificateValidator certificateValidator = new CertificateValidator();
            certificateValidator.Update(configuration.SecurityConfiguration).Wait();
            certificateValidator.Update(configuration.SecurityConfiguration.UserIssuerCertificates,
                configuration.SecurityConfiguration.TrustedUserCertificates,
                configuration.SecurityConfiguration.RejectedCertificateStore);

            // set custom validator for user certificates.
            m_certificateValidator = certificateValidator.GetChannelValidator();
          }
        }
      }
    }

    /// <summary>
    /// Called when a client tries to change its user identity.
    /// </summary>
    private void SessionManager_ImpersonateUser(Session session, ImpersonateEventArgs args)
    {
      // check for x509 user token.
      X509IdentityToken x509Token = args.NewIdentity as X509IdentityToken;

      if (x509Token != null)
      {
        VerifyUserTokenCertificate(x509Token.Certificate);
        args.Identity = new UserIdentity(x509Token);
        Log($"X509 Token Accepted: {args.Identity.DisplayName}");
        return;
      }
    }

    /// <summary>
    /// Verifies that a certificate user token is trusted.
    /// </summary>
    private void VerifyUserTokenCertificate(X509Certificate2 certificate)
    {
      try
      {
        if (m_certificateValidator != null)
        {
          m_certificateValidator.Validate(certificate);
        }
        else
        {
          CertificateValidator.Validate(certificate);
        }
      }
      catch (Exception e)
      {
        TranslationInfo info;
        StatusCode result = StatusCodes.BadIdentityTokenRejected;
        ServiceResultException se = e as ServiceResultException;
        if (se != null && se.StatusCode == StatusCodes.BadCertificateUseNotAllowed)
        {
          info = new TranslationInfo(
              "InvalidCertificate",
              "en-US",
              "'{0}' is an invalid user certificate.",
              certificate.Subject);

          result = StatusCodes.BadIdentityTokenInvalid;
        }
        else
        {
          // construct translation object with default text.
          info = new TranslationInfo(
              "UntrustedCertificate",
              "en-US",
              "'{0}' is not a trusted user certificate.",
              certificate.Subject);
        }

        // create an exception with a vendor defined sub-code.
        throw new ServiceResultException(new ServiceResult(
            result,
            info.Key,
            LoadServerProperties().ProductUri,
            new LocalizedText(info)));
      }
    }
    #endregion

    #region Utility
    public static async Task LaunchServer(
      OpcUaPiServer server,
      string configFile,
      X509Certificate2 certificate = null,
      ICertificatePasswordProvider passwordProvider = null)
    {
      if (string.IsNullOrWhiteSpace(configFile))
      {
        throw new ArgumentException("Invalid config file", nameof(configFile));
      }

      ApplicationInstance app = new ApplicationInstance();
      app.ApplicationType = ApplicationType.Server;
      app.ConfigSectionName = "PiServer";

      try
      {
        if (app.ProcessCommandLine())
        {
          return;
        }

        if (!Environment.UserInteractive)
        {
          app.StartAsService(server);
          return;
        }

        ApplicationConfiguration config = await app.LoadApplicationConfiguration(configFile, false);

        if (certificate != null)
        {
          config.SecurityConfiguration.ApplicationCertificate = new CertificateIdentifier(certificate);
          config.SecurityConfiguration.CertificatePasswordProvider = passwordProvider;
        }

        bool haveAppCertificate = await app.CheckApplicationInstanceCertificate(false, 0);
        if (!haveAppCertificate)
        {
          throw new Exception("Application instance certificate invalid!");
        }

        if (!config.SecurityConfiguration.AutoAcceptUntrustedCertificates)
        {
          config.CertificateValidator.CertificateValidation += server.CertificateValidation;
        }

        await app.Start(server);

        server.CurrentInstance.SessionManager.SessionActivated += server.EventStatus;
        server.CurrentInstance.SessionManager.SessionClosing += server.EventStatus;
        server.CurrentInstance.SessionManager.SessionCreated += server.EventStatus;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static Task StopServer(OpcUaPiServer server)
    {
      server.Stop();
      return Task.CompletedTask;
    }

    private void Log(string msg, LogLevel level = LogLevel.Information)
    {
      logger?.Log(level, msg);
    }

    private string GetSessionStatusString(Session session, string reason, bool lastContact = false)
    {
      lock (session.DiagnosticsLock)
      {
        string item = String.Format("{0,9}:{1,20}:", reason, session.SessionDiagnostics.SessionName);
        if (lastContact)
        {
          item += String.Format("Last Event:{0:HH:mm:ss}", session.SessionDiagnostics.ClientLastContactTime.ToLocalTime());
        }
        else
        {
          if (session.Identity != null)
          {
            item += String.Format(":{0,20}", session.Identity.DisplayName);
          }
          item += String.Format(":{0}", session.Id);
        }

        return item;
      }
    }

    private void EventStatus(Session session, SessionEventReason reason)
    {
      string str = GetSessionStatusString(session, reason.ToString());
      Log(str);
    }

    private void CertificateValidation(CertificateValidator validator, CertificateValidationEventArgs e)
    {
      if (e.Error.StatusCode == StatusCodes.BadCertificateUntrusted)
      {
        e.Accept = AutoAccept;
        if (AutoAccept)
        {
          Log($"Accepted certificate: {e.Certificate.Subject}");
        }
        else
        {
          Log($"Rejected certificate: {e.Certificate.Subject}");
        }
      }
    }
    #endregion

    public OpcUaPiServer(Action<PiServerOptions> optionsConfig)
    {
      PiServerOptions opts = new PiServerOptions();
      optionsConfig(opts);

      SenseHat = opts.SenseHat;
      AutoAccept = opts.AutoAccept;
      logger = opts.Logger;
    }

    #region Fields
    private ICertificateValidator m_certificateValidator;

    private ISenseHat SenseHat { get; }
    public bool AutoAccept { get; }

    private readonly ILogger<OpcUaPiServer> logger;
    #endregion
  }
}