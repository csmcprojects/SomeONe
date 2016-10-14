using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SomeONe;

namespace SomeONe
{
    public class SomeBool
    {
        
        public SomeBool(bool errorFlag, string errorMessage, bool result)
        {
            Error = errorMessage;
            Result = result;
            ErrorFlag = errorFlag;
        }

        public bool ErrorFlag { get; set; }
        public string Error { get; set; }
        public bool Result { get; set; }
    }

    public class SomeString
    {
        public SomeString(bool errorFlag, string errorMessage, string result)
        {
            Error = errorMessage;
            Result = result;
            ErrorFlag = errorFlag;
        }

        public bool ErrorFlag { get; set; }
        public string Error { get; set; }
        public string Result { get; set; }
    }

    public enum DataProtocol
    {
        Json
    }

    /// <summary>
    /// This class holds configuration information related with the device.
    /// </summary>
    public class SomeONeConfig
    {
        public const int DeviceBaudRate = 9600;  // The baud rate of the device serial port.
        public string DevicePort { get; set; } // The device com port name
        public string DeviceWifiNetwork { get; set; } // The wifi network that the device connects to.
        public string DeviceNetworkUsername { get; set; } // The username required to connect to the network (may be required or not)
        public string DeviceNetworkPassword { get; set; } // The wifi network password.
        public string DeviceUsername { get; set; } // The name of the device.
        public string DevicePassword { get; set; } // The device password (optional).
        public string WebInterfaceUrl { get; set; } // The url to which the state data will be sent.
        public DataProtocol DataProtocolFormat { get; set; } // The format in which the data is sent to the url.
    }

    /// <summary>
    /// This data structure holds all the device information that the application needs.
    /// </summary>
    public struct DeviceInfo
    {
        public string DeviceName { get; set; }
        public bool ServerId { get; set; }
        public string DeviceHashId { get; set; }
    }

    /// <summary>
    /// The strings in this collection define the standard communication strings to which the device
    /// responds. 
    /// </summary>
    public class DeviceMessage
    {
        public const string AreYouASomeoneDevice = "som" ;
        public const string GiveMeEspNetworkList = "espnetlist";
        public const string DeviceBoolTResponse = "true";
        public const string DeviceBoolFResponse = "false";
        public const string EspWifiNetworkAuth = "espwificon";
        public const string NeedsUserAuth = "nuserauth";
    }

    /// <summary>
    /// This class is responsible for communicating with the device using a simple SerialPort interface.
    /// </summary>
    public class SomeONeSerial
    {
        private readonly string _deviceName;
        private SerialPort _port;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the serial device eg.:"COM3".</param>
        public SomeONeSerial(string name)
        {
            _deviceName = name;
        }

        /// <summary>
        /// Opens the connection to the port.
        /// </summary>
        private void Open()
        {
            try
            {
                _port = new SerialPort(_deviceName, SomeONeConfig.DeviceBaudRate);
                _port.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(@"SomeONe Error: " + e.Message);
                throw;
            }
            
        }

        /// <summary>
        /// Closes the connection to the port.
        /// </summary>
        private void Close()
        {
            try
            {
                _port.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(@"SomeONe Error: " + e.Message);
                throw;
            }
        }

        /// <summary>
        /// Disposes of the SerialPort resources. If this is used a new object must be instantiated.
        /// </summary>
        private void Dispose()
        {
            _port.Dispose();
        }

        /// <summary>
        /// Sends a message (line + \n) to the device.
        /// </summary>
        /// <param name="message">The message to send to the device</param>
        /// <returns>Returns true if the message was sent successfully.</returns>
        private bool SendLine(string message)
        {
            Open();
            if (!_port.IsOpen) return false;
            byte[] asciiBytes = Encoding.UTF8.GetBytes(message);
            _port.Write(asciiBytes, 0, asciiBytes.Length);
            Close();
            return true;   
        }

        /// <summary>
        /// Waits for a message (line with \n) from the device.
        /// </summary>
        /// <param name="message">The message received.</param>
        /// <returns>Returns true if a message was received. False if the port was unavailable.</returns>
        private bool ReceiveLine(ref string message)
        {
            Open();
            if (!_port.IsOpen) return false;

            int dataLength = _port.BytesToRead;
            byte[] data = new byte[dataLength];
            int nbrDataRead = _port.Read(data, 0, dataLength);
            message = Encoding.UTF8.GetString(data);
 
            Close();
            return true;
        }

        /// <summary>
        /// Returns a data structure with all the available information of the device.
        /// </summary>
        /// <returns>DeviceInfo</returns>
        public SomeONeConfig GetDeviceInfo()
        {
            return new SomeONeConfig();
        }

        /// <summary>
        /// Sends a message to the device asking if he is a SomeONe device.
        /// </summary>
        /// <returns>Returns true if it is a SomeONe device.</returns>
        public bool IsSomeoneDevice()
        {
            if (SendLine(DeviceMessage.AreYouASomeoneDevice))
            {
                string response = "";
                if (ReceiveLine(ref response))
                {
                    return (response.Replace("\r\n", "").Equals(DeviceMessage.DeviceBoolTResponse));
                }
            }
            return false;
        }

        /// <summary>
        /// Sends a message to the device asking if he is a SomeONe device.
        /// </summary>
        /// <returns>Returns true if it is a SomeONe device.</returns>
        public string[] GetWifiNetworksList()
        {
            if (SendLine(DeviceMessage.GiveMeEspNetworkList))
            {
                string response = "";
                if (ReceiveLine(ref response))
                {
                    return response.Split(';');
                }
            }
            return new string[0];
        }

        /// <summary>
        /// Sends the wifi network credentials for the arduino and tests if the esp connects to the network successfully.
        /// </summary>
        /// <param name="wifiNetworkName">The name of the wifi network</param>
        /// <param name="wifiNetworkPassword">The password of the wifi network</param>
        /// <returns></returns>
        public bool IsEspWifiAuthValid(string wifiNetworkName, string wifiNetworkPassword, string wifiNetworkUsername = "")
        {
            string messageString = "";

            if (wifiNetworkUsername == "")
            {
                messageString = DeviceMessage.EspWifiNetworkAuth + ";" + wifiNetworkName + ";" + wifiNetworkPassword;
            }
            else
            {
                messageString = DeviceMessage.EspWifiNetworkAuth + ";" + wifiNetworkName + ";" + wifiNetworkPassword +
                                ";" + wifiNetworkUsername;
            }

            if (SendLine(messageString))
            {
                string message = "";
                if (ReceiveLine(ref message))
                {
                    return message == DeviceMessage.DeviceBoolTResponse;
                }
            }
            return false;
        }

        public SomeBool NeedsUserAuth()
        {
            if (SendLine(DeviceMessage.NeedsUserAuth))
            {
                string message = "";
                if (ReceiveLine(ref message))
                {
                    if (message == DeviceMessage.DeviceBoolTResponse)
                    {
                        return new SomeBool(false, "", true);
                    }
                    else if (message == DeviceMessage.DeviceBoolFResponse)
                    {
                        return new SomeBool(false, "", false);
                    }
                    else
                    {
                        return new SomeBool(true,
                            "Unknown error while trying to retrieve information about user authentication.",
                            true);
                    }
                }
                else
                {
                    return new SomeBool(true, "An error occurred while trying to receive from the device.", true);
                }
            }
            else
            {
                return new SomeBool(true, "An error occurred while trying to communicate with the device.", true);
            }
        }
    }
}