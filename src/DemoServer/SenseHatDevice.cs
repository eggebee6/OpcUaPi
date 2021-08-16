using Microsoft.Extensions.Logging;
using PiServer.Nodes.SenseHat;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading;

namespace DemoServer
{
  class SenseHatDevice : ISenseHat
  {
    private ILogger<ISenseHat> logger { get; }
    private Timer updateTimer;

    private readonly Iot.Device.SenseHat.SenseHat senseHat;

    public event EventHandler TemperatureChanged;
    public event EventHandler PressureChanged;
    public event EventHandler HumidityChanged;
    public event EventHandler MagnetometerChanged;
    public event EventHandler AccelerometerChanged;
    public event EventHandler AngularRateChanged;
    public event EventHandler JoystickChanged;

    public SenseHatDevice(ILogger<ISenseHat> logger)
    {
      this.logger = logger;

      senseHat = new Iot.Device.SenseHat.SenseHat();
      if (senseHat is null)
      {
        Log("Failed to create SenseHat device object");
        throw new Exception("Failed to create SenseHAT device object");
      }

      updateTimer = new Timer(InvokeUpdates, null, 500, 500);
    }

    private void Log(string msg)
    {
      logger?.LogInformation(msg);
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

    public string TemperatureUnits => "Celsius";
    public double Temperature() =>
      (senseHat.Temperature.DegreesCelsius + senseHat.Temperature2.DegreesCelsius) / 2.0;

    public string PressureUnits => "Hectopascals";
    public double Pressure() =>
      senseHat.Pressure.Hectopascals;

    public string HumidityUnits => "Relative humidity";
    public double Humidity() =>
      senseHat.Humidity.Percent;

    public string MagnetometerUnits => "Gauss";
    public Vector3 Magnetometer() =>
      senseHat.Magnetometer.MagneticInduction;

    public string AccelerometerUnits => "G";
    public Vector3 Accelerometer() =>
      senseHat.Acceleration;

    public string AngularRateUnits => "Degrees/second";
    public Vector3 AngularRate() =>
      senseHat.AngularRate;

    public bool JoystickDown()
    {
      senseHat.Joystick.Read();
      return senseHat.Joystick.HoldingDown;
    }

    public bool JoystickLeft()
    {
      senseHat.Joystick.Read();
      return senseHat.Joystick.HoldingLeft;
    }

    public bool JoystickRight()
    {
      senseHat.Joystick.Read();
      return senseHat.Joystick.HoldingRight;
    }

    public bool JoystickUp()
    {
      senseHat.Joystick.Read();
      return senseHat.Joystick.HoldingUp;
    }

    public bool JoystickPushbutton()
    {
      senseHat.Joystick.Read();
      return senseHat.Joystick.HoldingButton;
    }

    public void SetLED(byte red, byte green, byte blue)
    {
      senseHat.LedMatrix.Fill(System.Drawing.Color.FromArgb(red, green, blue));
    }
  }
}
