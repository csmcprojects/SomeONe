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
        public string NetworkName { get; set; }
        public int SignalStrength { get; set; }
    }

    /// <summary>
    /// This class holds configuration information related with the device.
    /// </summary>
    public class SomeONeConfig
    {
        public const int DeviceBaudRate = 9600;  // The baud rate of the device serial port.
        public string DevicePort { get; set; } // The device com port name
        public string DeviceUsername { get; set; } // The name of the device.
        public string DevicePassword { get; set; } // The device password (optional).
        public string DeviceWifiNetworkName { get; set; } // The wifi network that the device connects to.
        public string DeviceNetworkPassword { get; set; } // The wifi network password.
        public string WebInterfaceUrl { get; set; } // The url to which the state data will be sent.
        public string UrlAuthToken { get; set; } // The authentication token is used to validate
        public string WebServerHost { get; set; } // The server host
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
        public const string AreYouASomeoneDevice = "AYASD" ;
        public const string GiveMeEspNetworkList = "GMENL";
        public const string DeviceBoolTResponse = "DBTR";
        public const string DeviceBoolFResponse = "DBFR";
        public const string EspWifiNetworkAuth = "EWNA";
        public const string NeedsUserAuth = "NUA";
        public const string UserAuth = "UA";
        public const string RegisterUser = "RU";
        public const string SaveConfig = "SC";
        public static string Reset = "RD";
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
            if(_port.IsOpen) _port.Dispose();
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
            _port.DiscardInBuffer();
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
            try
            {
                System.Threading.Thread.Sleep(10);
                var terminator = '\n';
                string tString = String.Empty;
                _port.ReadTimeout = 20000;
                do
                {
                    byte[] buffer = new byte[_port.ReadBufferSize];

                    //There is no accurate method for checking how many bytes are read 
                    //unless you check the return from the Read method 
                    int bytesRead = _port.Read(buffer, 0, buffer.Length);

                    //For the example assume the data we are received is ASCII data. 

                    tString += Encoding.ASCII.GetString(buffer, 0, bytesRead);
                } while (!tString.Contains("\r\n"));

                //Check if string contains the terminator  
                if (tString.IndexOf((char)terminator) > -1)
                {
                    //If tString does contain terminator we cannot assume that it is the last character received 
                    message = tString.Substring(0, tString.IndexOf((char)terminator));
                    message = message.Replace("\r", "");

                    //Do something with workingString
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            
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
            //In case the response comes empty just return
            switch (response)
            {  
                case "":
                    return;
                case DeviceMessage.GiveMeEspNetworkList:
                    return;
            }

            var responseLines = response.Split('#');
            foreach (var networkInfo in responseLines)
            {
                var networkDataLine = networkInfo.Split('$');
                if (networkDataLine.Length != 3) continue;
                EspNetworkDescriptior descriptor = new EspNetworkDescriptior();
                descriptor.NetworkName = networkDataLine[0];
                var dBm = networkDataLine[1];
                int quality = 0;
                int dBmInt = 0;
                if (dBm != String.Empty)
                {
                    dBmInt = Convert.ToInt32(dBm);
                    if (dBmInt <= -100)
                    {
                        quality = 0;
                    }
                    else if (dBmInt >= -50)
                    {
                        quality = 100;
                    }
                }
                quality = 2 * (dBmInt + 100);
                descriptor.SignalStrength = quality;
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

        public bool DeviceNeedsUserAuth()
        {
            Open();
            if (SendLine(DeviceMessage.NeedsUserAuth))
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

        public bool AuthenticateUser(string password)
        {
            Open();
            if (SendLine(DeviceMessage.UserAuth+";"+password+";"))
            {
                string response = "";
                if (ReceiveLine(ref response))
                {
                    Close();
                    return (response == DeviceMessage.DeviceBoolTResponse) ;
                }
            }
            Close();
            return false;          
        }

        public bool SaveConfig(SomeONeConfig config)
        {
            Open();

            //Message Format:
            //SC;deviceUsername;devicePassword;wifiNetworkName;wifiNetoworkPassword;serverURL
            var message = DeviceMessage.SaveConfig + ";" + config.DeviceUsername + ";" + config.DevicePassword + ";" +
                          config.DeviceWifiNetworkName + ";" + config.DeviceNetworkPassword + ";" +
                          config.WebServerHost + ";" + config.WebInterfaceUrl + ";" + config.UrlAuthToken + ";";

            if (SendLine(message))
            {
                string response = "";
                if (ReceiveLine(ref response))
                {
                    Close();
                    return  response == DeviceMessage.DeviceBoolTResponse;
                }
            }
            Close();
            return false;
        }

        public bool ResetDevice()
        {
            Open();

            if (SendLine(DeviceMessage.Reset))
            {
                Close();
                return true;
            }
            else
            {
                Close();
                return false;
            }
        }
    }
}