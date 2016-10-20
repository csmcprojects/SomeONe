using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Windows.Forms;
using SomeONe;

namespace SomeONe
{
    public class EspNetworkDescriptior
    {
        public string NetworkId { get; set; }
        public string NetworkName { get; set; }
        public string SignalStrength { get; set; }
        public string NetworkType { get; set; }
    }

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
        public string DeviceWifiNetworkName { get; set; } // The wifi network that the device connects to.
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
        public const string UserAuth = "tuserauth";
        public const string RegisterUser = "reguser";
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
        private bool Open()
        {
            if (_deviceName.Trim() == "" || _deviceName == null)
            {
                return false;
            }
            _port = new SerialPort(_deviceName, SomeONeConfig.DeviceBaudRate);
            if (_port == null) return false;
            _port.Open();
            return _port.IsOpen;
        }

        /// <summary>
        /// Closes the connection to the port.
        /// </summary>
        private void Close()
        {
            if (_port == null) return;
            if(_port.IsOpen) _port.Close();
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
            byte[] asciiBytes = Encoding.UTF8.GetBytes(message);
            _port.Write(asciiBytes, 0, asciiBytes.Length);
            return true;         
        }

        /// <summary>
        /// Waits for a message (line with \n) from the device.
        /// </summary>
        /// <param name="message">The message received.</param>
        /// <returns>Returns true if a message was received. False if the port was unavailable.</returns>
        private bool ReceiveLine(ref string message)
        {
            int index = 0;
            string response = "";
            string finalResponse = "";
            int trys = 3;
            do
            {
                if (trys == 0) break;
                int dataLength = _port.BytesToRead;
                byte[] data = new byte[dataLength];
                int nbrDataRead = _port.Read(data, 0, dataLength);
                response = Encoding.UTF8.GetString(data);
                finalResponse += response;
                trys--;

            }
            while (finalResponse.Contains("\r") == false);
            index = response.IndexOf("\r", StringComparison.Ordinal);
            if (index > 0)
                response = response.Substring(0, index);
            message = response;
            _port.DiscardInBuffer();
            return true;
        }

        /// <summary>
        /// Returns a data structure with all the available information of the device.
        /// </summary>
        /// <returns>DeviceInfo</returns>
        public SomeONeConfig GetDeviceInfo()
        {
            //Finish method
            return new SomeONeConfig();
        }

        /// <summary>
        /// Sends a message to the device asking if he is a SomeONe device.
        /// </summary>
        /// <returns>Returns true if it is a SomeONe device.</returns>
        public bool IsSomeoneDevice()
        {
            Open();
            if (SendLine(DeviceMessage.AreYouASomeoneDevice))
            {
                string response = "";
                if (ReceiveLine(ref response))
                {
                    Close();
                    return (response.Equals(DeviceMessage.DeviceBoolTResponse));
                }
            }
            Close();
            return false;
        }

        /// <summary>
        /// Sends a message to the device asking if he is a SomeONe device.
        /// </summary>
        /// <returns>Returns true if it is a SomeONe device.</returns>
        public List<EspNetworkDescriptior> GetWifiNetworksList()
        {
            Open();
            List<EspNetworkDescriptior> networkList = new List<EspNetworkDescriptior>();
            if (SendLine(DeviceMessage.GiveMeEspNetworkList))
            {
                string response = "";
                if (ReceiveLine(ref response))
                {
                    ParseNetworkList(ref response, ref networkList);
                    Close();
                    return networkList;
                }
            }
            Close();
            return networkList;
        }

        private void ParseNetworkList(ref string response, ref List<EspNetworkDescriptior> networkList)
        {
            if (response == "") return;
            if (response == DeviceMessage.GiveMeEspNetworkList) return;
            //Removes the '{"', '"}' characters from the string
            response = response.Replace("{\"", "").Replace("\"}", "");
            //Splits the string in the \n
           

            var responseLines = response.Split('\n');
            foreach (var networkInfo in responseLines)
            {
                //Fills the data in for each network
                var data = networkInfo.Split(',');
                EspNetworkDescriptior descriptor = new EspNetworkDescriptior();
                descriptor.NetworkId = data[0];
                descriptor.NetworkType = data[1];
                descriptor.NetworkName = data[2];
                networkList.Add(descriptor);
            }
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
            Open();
            if (SendLine(messageString))
            {
                string message = "";
                if (ReceiveLine(ref message))
                {
                    Close();
                    return message == DeviceMessage.DeviceBoolTResponse;
                }
            }
            Close();
            return false;
        }

        public SomeBool DeviceNeedsUserAuth()
        {
            Open();
            if (SendLine(DeviceMessage.NeedsUserAuth))
            {
                string message = "";
                if (ReceiveLine(ref message))
                {
                    Close();
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
                    Close();
                    return new SomeBool(true, "An error occurred while trying to receive from the device.", true);
                }
            }
            else
            {
                Close();
                return new SomeBool(true, "An error occurred while trying to communicate with the device.", true);
            }
        }

        public SomeBool AuthenticateUser(string password)
        {
            Open();
            if (SendLine(DeviceMessage.UserAuth))
            {
                string response = "";
                if (ReceiveLine(ref response))
                {
                    Close();
                    return new SomeBool(false, "", response == DeviceMessage.DeviceBoolTResponse);
                }
                else
                {
                    Close();
                    return new SomeBool(true, "Failed to listen the device.", true);
                }
            }
            else
            {
                Close();
                return new SomeBool(true,"Failed to communicate with the device.", true);
            }
        }

        public SomeBool CreateUserAuthentication(string deviceName, string devicePassword)
        {
            Open();
            var message = DeviceMessage.RegisterUser + ";" + deviceName + ";" + devicePassword;
            if (SendLine(message))
            {
                string response = "";
                if (ReceiveLine(ref response))
                {
                    Close();
                    return new SomeBool(false, "", response == DeviceMessage.DeviceBoolTResponse);
                }
                else
                {
                    Close();
                    return new SomeBool(true, "Failed to listen the device.", true);
                }
            }
            else
            {
                Close();
                return new SomeBool(true, "Failed to communicate with the device.", true);
            }
        }
    }
}