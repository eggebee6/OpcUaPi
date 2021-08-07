using System;
using System.Collections.Generic;
using System.Text;

namespace PiServer.Nodes.SenseHat
{
  public interface ISenseHat
  {
    double Temperature();
    string TemperatureUnits { get; }

    double Pressure();
    string PressureUnits { get; }

    double Humidity();
    string HumidityUnits { get; }

    System.Numerics.Vector3 Magnetometer();
    string MagnetometerUnits { get; }

    System.Numerics.Vector3 Accelerometer();
    string AccelerometerUnits { get; }

    System.Numerics.Vector3 AngularRate();
    string AngularRateUnits { get; }

    bool JoystickUp();
    bool JoystickDown();
    bool JoystickLeft();
    bool JoystickRight();
    bool JoystickPushbutton();

    void SetLED(byte red, byte green, byte blue);

    int SensorUpdateRate { get; }
  }
}
