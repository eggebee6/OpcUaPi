using Microsoft.Extensions.Logging;
using PiServer.Nodes.SenseHat;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading;

namespace DemoServer
{
  public class SenseHatSimulated : ISenseHat
  {
    private readonly Random rng = new Random();

    public event EventHandler TemperatureChanged;
    public event EventHandler PressureChanged;
    public event EventHandler HumidityChanged;
    public event EventHandler MagnetometerChanged;
    public event EventHandler AccelerometerChanged;
    public event EventHandler AngularRateChanged;
    public event EventHandler JoystickChanged;

    private readonly ILogger<ISenseHat> logger;
    private readonly Timer updateTimer;

    public SenseHatSimulated(ILogger<ISenseHat> logger)
    {
      this.logger = logger;
      updateTimer = new Timer(InvokeUpdates, null, 500, 500);
    }

    private void InvokeUpdates(object state)
    {
      TemperatureChanged?.Invoke(null, null);
      PressureChanged?.Invoke(null, null);
      HumidityChanged?.Invoke(null, null);
      MagnetometerChanged?.Invoke(null, null);
      AccelerometerChanged?.Invoke(null, null);
      AngularRateChanged?.Invoke(null, null);
      JoystickChanged?.Invoke(null, null);
    }

    private void Log(string msg)
    {
      logger?.LogInformation(msg);
    }

    public string TemperatureUnits => "Celsius";
    public double Temperature()
    {
      return 20.0 + rng.NextDouble() * 2;
    }

    public string PressureUnits => "Hectopascals";
    public double Pressure()
    {
      return 1013.25 + (rng.NextDouble() - rng.NextDouble()) * 5;
    }

    public string HumidityUnits => "Relative humidity";
    public double Humidity()
    {
      return 60 + (rng.NextDouble() - rng.NextDouble()) * 10;
    }

    public string MagnetometerUnits => "Gauss";
    public Vector3 Magnetometer()
    {
      float x = (float)(rng.NextDouble() - rng.NextDouble());
      float y = (float)(rng.NextDouble() - rng.NextDouble());
      float z = (float)(rng.NextDouble() - rng.NextDouble());

      return new Vector3(x, y, z);
    }

    public string AccelerometerUnits => "G";
    public Vector3 Accelerometer()
    {
      float x = (float)(rng.NextDouble() - rng.NextDouble());
      float y = (float)(rng.NextDouble() - rng.NextDouble());
      float z = (float)(rng.NextDouble() - rng.NextDouble());

      return new Vector3(x, y, z);
    }

    public string AngularRateUnits => "Degrees/second";
    public Vector3 AngularRate()
    {
      float x = (float)(rng.NextDouble() - rng.NextDouble());
      float y = (float)(rng.NextDouble() - rng.NextDouble());
      float z = (float)(rng.NextDouble() - rng.NextDouble());

      return new Vector3(x, y, z);
    }

    public bool JoystickDown()
    {
      return (rng.Next(0, 2) == 1);
    }

    public bool JoystickLeft()
    {
      return (rng.Next(0, 2) == 1);
    }

    public bool JoystickPushbutton()
    {
      return (rng.Next(0, 2) == 1);
    }

    public bool JoystickRight()
    {
      return (rng.Next(0, 2) == 1);
    }

    public bool JoystickUp()
    {
      return (rng.Next(0, 2) == 1);
    }

    public void SetLED(byte red, byte green, byte blue)
    {
      Log($"LED: {red}R {green}G {blue}B");
    }
  }
}
