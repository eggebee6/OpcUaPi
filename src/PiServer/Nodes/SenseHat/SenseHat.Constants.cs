/* ========================================================================
 * Copyright (c) 2005-2021 The OPC Foundation, Inc. All rights reserved.
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
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;

namespace PiServer.Nodes.SenseHat
{
    #region Method Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Methods
    {
        /// <summary>
        /// The identifier for the SetRGBLEDColor Method.
        /// </summary>
        public const uint SetRGBLEDColor = 15;

        /// <summary>
        /// The identifier for the RGBLEDType_SetColor Method.
        /// </summary>
        public const uint RGBLEDType_SetColor = 21;

        /// <summary>
        /// The identifier for the SenseHat_LED_SetColor Method.
        /// </summary>
        public const uint SenseHat_LED_SetColor = 58;
    }
    #endregion

    #region Object Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Objects
    {
        /// <summary>
        /// The identifier for the SenseHat_Temperature Object.
        /// </summary>
        public const uint SenseHat_Temperature = 24;

        /// <summary>
        /// The identifier for the SenseHat_Pressure Object.
        /// </summary>
        public const uint SenseHat_Pressure = 27;

        /// <summary>
        /// The identifier for the SenseHat_Humidity Object.
        /// </summary>
        public const uint SenseHat_Humidity = 30;

        /// <summary>
        /// The identifier for the SenseHat_Magnetometer Object.
        /// </summary>
        public const uint SenseHat_Magnetometer = 33;

        /// <summary>
        /// The identifier for the SenseHat_Accelerometer Object.
        /// </summary>
        public const uint SenseHat_Accelerometer = 38;

        /// <summary>
        /// The identifier for the SenseHat_AngularRate Object.
        /// </summary>
        public const uint SenseHat_AngularRate = 43;

        /// <summary>
        /// The identifier for the SenseHat_Joystick Object.
        /// </summary>
        public const uint SenseHat_Joystick = 48;

        /// <summary>
        /// The identifier for the SenseHat_LED Object.
        /// </summary>
        public const uint SenseHat_LED = 54;
    }
    #endregion

    #region ObjectType Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <summary>
        /// The identifier for the GenericSensorType ObjectType.
        /// </summary>
        public const uint GenericSensorType = 1;

        /// <summary>
        /// The identifier for the GenericSensor3DType ObjectType.
        /// </summary>
        public const uint GenericSensor3DType = 4;

        /// <summary>
        /// The identifier for the JoystickType ObjectType.
        /// </summary>
        public const uint JoystickType = 9;

        /// <summary>
        /// The identifier for the RGBLEDType ObjectType.
        /// </summary>
        public const uint RGBLEDType = 17;

        /// <summary>
        /// The identifier for the SenseHat ObjectType.
        /// </summary>
        public const uint SenseHat = 23;
    }
    #endregion

    #region Variable Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <summary>
        /// The identifier for the GenericSensorType_Output Variable.
        /// </summary>
        public const uint GenericSensorType_Output = 2;

        /// <summary>
        /// The identifier for the GenericSensorType_Units Variable.
        /// </summary>
        public const uint GenericSensorType_Units = 3;

        /// <summary>
        /// The identifier for the GenericSensor3DType_X Variable.
        /// </summary>
        public const uint GenericSensor3DType_X = 5;

        /// <summary>
        /// The identifier for the GenericSensor3DType_Y Variable.
        /// </summary>
        public const uint GenericSensor3DType_Y = 6;

        /// <summary>
        /// The identifier for the GenericSensor3DType_Z Variable.
        /// </summary>
        public const uint GenericSensor3DType_Z = 7;

        /// <summary>
        /// The identifier for the GenericSensor3DType_Units Variable.
        /// </summary>
        public const uint GenericSensor3DType_Units = 8;

        /// <summary>
        /// The identifier for the JoystickType_Up Variable.
        /// </summary>
        public const uint JoystickType_Up = 10;

        /// <summary>
        /// The identifier for the JoystickType_Down Variable.
        /// </summary>
        public const uint JoystickType_Down = 11;

        /// <summary>
        /// The identifier for the JoystickType_Left Variable.
        /// </summary>
        public const uint JoystickType_Left = 12;

        /// <summary>
        /// The identifier for the JoystickType_Right Variable.
        /// </summary>
        public const uint JoystickType_Right = 13;

        /// <summary>
        /// The identifier for the JoystickType_Pushbutton Variable.
        /// </summary>
        public const uint JoystickType_Pushbutton = 14;

        /// <summary>
        /// The identifier for the SetRGBLEDColor_InputArguments Variable.
        /// </summary>
        public const uint SetRGBLEDColor_InputArguments = 16;

        /// <summary>
        /// The identifier for the RGBLEDType_Red Variable.
        /// </summary>
        public const uint RGBLEDType_Red = 18;

        /// <summary>
        /// The identifier for the RGBLEDType_Green Variable.
        /// </summary>
        public const uint RGBLEDType_Green = 19;

        /// <summary>
        /// The identifier for the RGBLEDType_Blue Variable.
        /// </summary>
        public const uint RGBLEDType_Blue = 20;

        /// <summary>
        /// The identifier for the RGBLEDType_SetColor_InputArguments Variable.
        /// </summary>
        public const uint RGBLEDType_SetColor_InputArguments = 22;

        /// <summary>
        /// The identifier for the SenseHat_Temperature_Output Variable.
        /// </summary>
        public const uint SenseHat_Temperature_Output = 25;

        /// <summary>
        /// The identifier for the SenseHat_Temperature_Units Variable.
        /// </summary>
        public const uint SenseHat_Temperature_Units = 26;

        /// <summary>
        /// The identifier for the SenseHat_Pressure_Output Variable.
        /// </summary>
        public const uint SenseHat_Pressure_Output = 28;

        /// <summary>
        /// The identifier for the SenseHat_Pressure_Units Variable.
        /// </summary>
        public const uint SenseHat_Pressure_Units = 29;

        /// <summary>
        /// The identifier for the SenseHat_Humidity_Output Variable.
        /// </summary>
        public const uint SenseHat_Humidity_Output = 31;

        /// <summary>
        /// The identifier for the SenseHat_Humidity_Units Variable.
        /// </summary>
        public const uint SenseHat_Humidity_Units = 32;

        /// <summary>
        /// The identifier for the SenseHat_Magnetometer_X Variable.
        /// </summary>
        public const uint SenseHat_Magnetometer_X = 34;

        /// <summary>
        /// The identifier for the SenseHat_Magnetometer_Y Variable.
        /// </summary>
        public const uint SenseHat_Magnetometer_Y = 35;

        /// <summary>
        /// The identifier for the SenseHat_Magnetometer_Z Variable.
        /// </summary>
        public const uint SenseHat_Magnetometer_Z = 36;

        /// <summary>
        /// The identifier for the SenseHat_Magnetometer_Units Variable.
        /// </summary>
        public const uint SenseHat_Magnetometer_Units = 37;

        /// <summary>
        /// The identifier for the SenseHat_Accelerometer_X Variable.
        /// </summary>
        public const uint SenseHat_Accelerometer_X = 39;

        /// <summary>
        /// The identifier for the SenseHat_Accelerometer_Y Variable.
        /// </summary>
        public const uint SenseHat_Accelerometer_Y = 40;

        /// <summary>
        /// The identifier for the SenseHat_Accelerometer_Z Variable.
        /// </summary>
        public const uint SenseHat_Accelerometer_Z = 41;

        /// <summary>
        /// The identifier for the SenseHat_Accelerometer_Units Variable.
        /// </summary>
        public const uint SenseHat_Accelerometer_Units = 42;

        /// <summary>
        /// The identifier for the SenseHat_AngularRate_X Variable.
        /// </summary>
        public const uint SenseHat_AngularRate_X = 44;

        /// <summary>
        /// The identifier for the SenseHat_AngularRate_Y Variable.
        /// </summary>
        public const uint SenseHat_AngularRate_Y = 45;

        /// <summary>
        /// The identifier for the SenseHat_AngularRate_Z Variable.
        /// </summary>
        public const uint SenseHat_AngularRate_Z = 46;

        /// <summary>
        /// The identifier for the SenseHat_AngularRate_Units Variable.
        /// </summary>
        public const uint SenseHat_AngularRate_Units = 47;

        /// <summary>
        /// The identifier for the SenseHat_Joystick_Up Variable.
        /// </summary>
        public const uint SenseHat_Joystick_Up = 49;

        /// <summary>
        /// The identifier for the SenseHat_Joystick_Down Variable.
        /// </summary>
        public const uint SenseHat_Joystick_Down = 50;

        /// <summary>
        /// The identifier for the SenseHat_Joystick_Left Variable.
        /// </summary>
        public const uint SenseHat_Joystick_Left = 51;

        /// <summary>
        /// The identifier for the SenseHat_Joystick_Right Variable.
        /// </summary>
        public const uint SenseHat_Joystick_Right = 52;

        /// <summary>
        /// The identifier for the SenseHat_Joystick_Pushbutton Variable.
        /// </summary>
        public const uint SenseHat_Joystick_Pushbutton = 53;

        /// <summary>
        /// The identifier for the SenseHat_LED_Red Variable.
        /// </summary>
        public const uint SenseHat_LED_Red = 55;

        /// <summary>
        /// The identifier for the SenseHat_LED_Green Variable.
        /// </summary>
        public const uint SenseHat_LED_Green = 56;

        /// <summary>
        /// The identifier for the SenseHat_LED_Blue Variable.
        /// </summary>
        public const uint SenseHat_LED_Blue = 57;

        /// <summary>
        /// The identifier for the SenseHat_LED_SetColor_InputArguments Variable.
        /// </summary>
        public const uint SenseHat_LED_SetColor_InputArguments = 59;
    }
    #endregion

    #region Method Node Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class MethodIds
    {
        /// <summary>
        /// The identifier for the SetRGBLEDColor Method.
        /// </summary>
        public static readonly ExpandedNodeId SetRGBLEDColor = new ExpandedNodeId(PiServer.Nodes.SenseHat.Methods.SetRGBLEDColor, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the RGBLEDType_SetColor Method.
        /// </summary>
        public static readonly ExpandedNodeId RGBLEDType_SetColor = new ExpandedNodeId(PiServer.Nodes.SenseHat.Methods.RGBLEDType_SetColor, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_LED_SetColor Method.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_LED_SetColor = new ExpandedNodeId(PiServer.Nodes.SenseHat.Methods.SenseHat_LED_SetColor, PiServer.Nodes.SenseHat.Namespaces.SenseHat);
    }
    #endregion

    #region Object Node Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectIds
    {
        /// <summary>
        /// The identifier for the SenseHat_Temperature Object.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Temperature = new ExpandedNodeId(PiServer.Nodes.SenseHat.Objects.SenseHat_Temperature, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Pressure Object.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Pressure = new ExpandedNodeId(PiServer.Nodes.SenseHat.Objects.SenseHat_Pressure, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Humidity Object.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Humidity = new ExpandedNodeId(PiServer.Nodes.SenseHat.Objects.SenseHat_Humidity, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Magnetometer Object.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Magnetometer = new ExpandedNodeId(PiServer.Nodes.SenseHat.Objects.SenseHat_Magnetometer, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Accelerometer Object.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Accelerometer = new ExpandedNodeId(PiServer.Nodes.SenseHat.Objects.SenseHat_Accelerometer, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_AngularRate Object.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_AngularRate = new ExpandedNodeId(PiServer.Nodes.SenseHat.Objects.SenseHat_AngularRate, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Joystick Object.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Joystick = new ExpandedNodeId(PiServer.Nodes.SenseHat.Objects.SenseHat_Joystick, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_LED Object.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_LED = new ExpandedNodeId(PiServer.Nodes.SenseHat.Objects.SenseHat_LED, PiServer.Nodes.SenseHat.Namespaces.SenseHat);
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <summary>
        /// The identifier for the GenericSensorType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType = new ExpandedNodeId(PiServer.Nodes.SenseHat.ObjectTypes.GenericSensorType, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the GenericSensor3DType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensor3DType = new ExpandedNodeId(PiServer.Nodes.SenseHat.ObjectTypes.GenericSensor3DType, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the JoystickType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId JoystickType = new ExpandedNodeId(PiServer.Nodes.SenseHat.ObjectTypes.JoystickType, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the RGBLEDType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId RGBLEDType = new ExpandedNodeId(PiServer.Nodes.SenseHat.ObjectTypes.RGBLEDType, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat = new ExpandedNodeId(PiServer.Nodes.SenseHat.ObjectTypes.SenseHat, PiServer.Nodes.SenseHat.Namespaces.SenseHat);
    }
    #endregion

    #region Variable Node Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <summary>
        /// The identifier for the GenericSensorType_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType_Output = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.GenericSensorType_Output, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the GenericSensorType_Units Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType_Units = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.GenericSensorType_Units, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the GenericSensor3DType_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensor3DType_X = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.GenericSensor3DType_X, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the GenericSensor3DType_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensor3DType_Y = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.GenericSensor3DType_Y, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the GenericSensor3DType_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensor3DType_Z = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.GenericSensor3DType_Z, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the GenericSensor3DType_Units Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensor3DType_Units = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.GenericSensor3DType_Units, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the JoystickType_Up Variable.
        /// </summary>
        public static readonly ExpandedNodeId JoystickType_Up = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.JoystickType_Up, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the JoystickType_Down Variable.
        /// </summary>
        public static readonly ExpandedNodeId JoystickType_Down = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.JoystickType_Down, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the JoystickType_Left Variable.
        /// </summary>
        public static readonly ExpandedNodeId JoystickType_Left = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.JoystickType_Left, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the JoystickType_Right Variable.
        /// </summary>
        public static readonly ExpandedNodeId JoystickType_Right = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.JoystickType_Right, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the JoystickType_Pushbutton Variable.
        /// </summary>
        public static readonly ExpandedNodeId JoystickType_Pushbutton = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.JoystickType_Pushbutton, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SetRGBLEDColor_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId SetRGBLEDColor_InputArguments = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SetRGBLEDColor_InputArguments, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the RGBLEDType_Red Variable.
        /// </summary>
        public static readonly ExpandedNodeId RGBLEDType_Red = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.RGBLEDType_Red, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the RGBLEDType_Green Variable.
        /// </summary>
        public static readonly ExpandedNodeId RGBLEDType_Green = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.RGBLEDType_Green, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the RGBLEDType_Blue Variable.
        /// </summary>
        public static readonly ExpandedNodeId RGBLEDType_Blue = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.RGBLEDType_Blue, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the RGBLEDType_SetColor_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId RGBLEDType_SetColor_InputArguments = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.RGBLEDType_SetColor_InputArguments, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Temperature_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Temperature_Output = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Temperature_Output, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Temperature_Units Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Temperature_Units = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Temperature_Units, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Pressure_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Pressure_Output = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Pressure_Output, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Pressure_Units Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Pressure_Units = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Pressure_Units, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Humidity_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Humidity_Output = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Humidity_Output, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Humidity_Units Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Humidity_Units = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Humidity_Units, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Magnetometer_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Magnetometer_X = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Magnetometer_X, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Magnetometer_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Magnetometer_Y = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Magnetometer_Y, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Magnetometer_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Magnetometer_Z = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Magnetometer_Z, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Magnetometer_Units Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Magnetometer_Units = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Magnetometer_Units, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Accelerometer_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Accelerometer_X = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Accelerometer_X, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Accelerometer_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Accelerometer_Y = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Accelerometer_Y, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Accelerometer_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Accelerometer_Z = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Accelerometer_Z, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Accelerometer_Units Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Accelerometer_Units = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Accelerometer_Units, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_AngularRate_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_AngularRate_X = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_AngularRate_X, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_AngularRate_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_AngularRate_Y = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_AngularRate_Y, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_AngularRate_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_AngularRate_Z = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_AngularRate_Z, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_AngularRate_Units Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_AngularRate_Units = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_AngularRate_Units, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Joystick_Up Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Joystick_Up = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Joystick_Up, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Joystick_Down Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Joystick_Down = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Joystick_Down, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Joystick_Left Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Joystick_Left = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Joystick_Left, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Joystick_Right Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Joystick_Right = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Joystick_Right, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_Joystick_Pushbutton Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_Joystick_Pushbutton = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_Joystick_Pushbutton, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_LED_Red Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_LED_Red = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_LED_Red, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_LED_Green Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_LED_Green = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_LED_Green, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_LED_Blue Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_LED_Blue = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_LED_Blue, PiServer.Nodes.SenseHat.Namespaces.SenseHat);

        /// <summary>
        /// The identifier for the SenseHat_LED_SetColor_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId SenseHat_LED_SetColor_InputArguments = new ExpandedNodeId(PiServer.Nodes.SenseHat.Variables.SenseHat_LED_SetColor_InputArguments, PiServer.Nodes.SenseHat.Namespaces.SenseHat);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the Accelerometer component.
        /// </summary>
        public const string Accelerometer = "Accelerometer";

        /// <summary>
        /// The BrowseName for the AngularRate component.
        /// </summary>
        public const string AngularRate = "Angular rate sensor";

        /// <summary>
        /// The BrowseName for the Blue component.
        /// </summary>
        public const string Blue = "Blue";

        /// <summary>
        /// The BrowseName for the Down component.
        /// </summary>
        public const string Down = "Down";

        /// <summary>
        /// The BrowseName for the GenericSensor3DType component.
        /// </summary>
        public const string GenericSensor3DType = "GenericSensor3DType";

        /// <summary>
        /// The BrowseName for the GenericSensorType component.
        /// </summary>
        public const string GenericSensorType = "GenericSensorType";

        /// <summary>
        /// The BrowseName for the Green component.
        /// </summary>
        public const string Green = "Green";

        /// <summary>
        /// The BrowseName for the Humidity component.
        /// </summary>
        public const string Humidity = "Humidity sensor";

        /// <summary>
        /// The BrowseName for the Joystick component.
        /// </summary>
        public const string Joystick = "Four-direction joystick with pushbutton";

        /// <summary>
        /// The BrowseName for the JoystickType component.
        /// </summary>
        public const string JoystickType = "JoystickType";

        /// <summary>
        /// The BrowseName for the LED component.
        /// </summary>
        public const string LED = "RGB LED";

        /// <summary>
        /// The BrowseName for the Left component.
        /// </summary>
        public const string Left = "Left";

        /// <summary>
        /// The BrowseName for the Magnetometer component.
        /// </summary>
        public const string Magnetometer = "Magnetometer";

        /// <summary>
        /// The BrowseName for the Output component.
        /// </summary>
        public const string Output = "Output";

        /// <summary>
        /// The BrowseName for the Pressure component.
        /// </summary>
        public const string Pressure = "Pressure sensor";

        /// <summary>
        /// The BrowseName for the Pushbutton component.
        /// </summary>
        public const string Pushbutton = "Pushbutton";

        /// <summary>
        /// The BrowseName for the Red component.
        /// </summary>
        public const string Red = "Red";

        /// <summary>
        /// The BrowseName for the RGBLEDType component.
        /// </summary>
        public const string RGBLEDType = "RGBLEDType";

        /// <summary>
        /// The BrowseName for the Right component.
        /// </summary>
        public const string Right = "Right";

        /// <summary>
        /// The BrowseName for the SenseHat component.
        /// </summary>
        public const string SenseHat = "SenseHat";

        /// <summary>
        /// The BrowseName for the SetColor component.
        /// </summary>
        public const string SetColor = "SetColor";

        /// <summary>
        /// The BrowseName for the SetRGBLEDColor component.
        /// </summary>
        public const string SetRGBLEDColor = "SetRGBLEDColor";

        /// <summary>
        /// The BrowseName for the Temperature component.
        /// </summary>
        public const string Temperature = "Temperature sensor";

        /// <summary>
        /// The BrowseName for the Units component.
        /// </summary>
        public const string Units = "Units";

        /// <summary>
        /// The BrowseName for the Up component.
        /// </summary>
        public const string Up = "Up";

        /// <summary>
        /// The BrowseName for the X component.
        /// </summary>
        public const string X = "X";

        /// <summary>
        /// The BrowseName for the Y component.
        /// </summary>
        public const string Y = "Y";

        /// <summary>
        /// The BrowseName for the Z component.
        /// </summary>
        public const string Z = "Z";
    }
    #endregion

    #region Namespace Declarations
    /// <summary>
    /// Defines constants for all namespaces referenced by the model design.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";

        /// <summary>
        /// The URI for the SenseHat namespace (.NET code namespace is 'PiServer.Nodes.SenseHat').
        /// </summary>
        public const string SenseHat = "http://mkecybertech.com/UA/Pi/SenseHat";
    }
    #endregion
}