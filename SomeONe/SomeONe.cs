using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace SomeONe
{

    public static class SomeONeConfig
    {
        public const string ComDeviceId = "SomeONe Device";
        public const int DeviceBaudRate = 9600;
  
    }

    public struct DeviceInfo
    {
        public string DeviceName { get; set; }
        public bool ServerId { get; set; }
        public string DeviceHashId { get; set; }
    }

    public struct DeviceMessage
    {
        public static string AreYouASomeoneDevice => "SOM+DEV";
        public static string GiveMeEspNetworkList => "ESP+NETLIST";
    }

    public class SomeONeSerial
    {
        private readonly string _deviceName;
        private SerialPort _port;

        public SomeONeSerial(string name)
        {
            _deviceName = name;
        }

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

        private bool SendLine(string message)
        {
            try
            {
                if (!_port.IsOpen) return false;
                _port.WriteLine(message);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(@"SomeONe Error: " + e.Message);
                throw;
            }
        }

        private bool ReceiveLine(ref string message)
        {
            try
            {
                if (!_port.IsOpen) return false;
                message = _port.ReadLine();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(@"SomeONe Error: " + e.Message);
                throw;
            }
        }

        public DeviceInfo GetDeviceInfo()
        {
            return new DeviceInfo();
        }

        public static bool IsAllowedDevice(string name)
        {
            return (name.Contains(SomeONeConfig.ComDeviceId));
        }

    }
}