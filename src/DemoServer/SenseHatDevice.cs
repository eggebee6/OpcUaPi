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
    private ILogger<ISenseHat> Logger { get; }

    private readonly Iot.Device.SenseHat.SenseHat senseHat;

    public SenseHatDevice(ILogger<ISenseHat> logger)
    {
      Logger = logger;

      senseHat = new Iot.Device.SenseHat.SenseHat();
      if (senseHat is null)
      {
        Log("Failed to create SenseHat device object");
        throw new Exception("Failed to create SenseHAT device object");
      }
    }

    private void Log(string msg)
    {
      Logger?.LogInformation(msg);
    }

    public int SensorUpdateRate => 500;

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
