using System;
using System.Collections.Generic;
using System.Text;

namespace PiServer.Nodes.SenseHat
{
  public interface ISenseHat
  {
    double Temperature();
    string TemperatureUnits { get; }
    event EventHandler TemperatureChanged;

    double Pressure();
    string PressureUnits { get; }
    event EventHandler PressureChanged;

    double Humidity();
    string HumidityUnits { get; }
    event EventHandler HumidityChanged;

    System.Numerics.Vector3 Magnetometer();
    string MagnetometerUnits { get; }
    event EventHandler MagnetometerChanged;

    System.Numerics.Vector3 Accelerometer();
    string AccelerometerUnits { get; }
    event EventHandler AccelerometerChanged;

    System.Numerics.Vector3 AngularRate();
    string AngularRateUnits { get; }
    event EventHandler AngularRateChanged;

    bool JoystickUp();
    bool JoystickDown();
    bool JoystickLeft();
    bool JoystickRight();
    bool JoystickPushbutton();
    event EventHandler JoystickChanged;

    void SetLED(byte red, byte green, byte blue);
  }
}
