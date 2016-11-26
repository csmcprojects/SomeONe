using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomeONe
{
    public partial class ResetForm : Form
    {
        private bool _arduinoQueryResult = false;
        private bool _arduinoQueryResult2 = false;
        private bool _arduinoQueryResult3 = false;
        private EntrypointForm _entrypointForm { get; set; }
        private string _port = "";

        public ResetForm(EntrypointForm entrypointForm)
        {
            _entrypointForm = entrypointForm;

            InitializeComponent();

            PopulateDeviceListBox();
        }

        private void IsValidDevice(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            //Initializes a serial connection
            SomeONeSerial port = new SomeONeSerial(_port);
            //Ask the device if it is a a someONe device
            _arduinoQueryResult = port.IsSomeoneDevice();
        }
        
        private void AuthenticateUser(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            SomeONeSerial port = new SomeONeSerial(_port);
            //Ask the device if it is a a someONe device
            _arduinoQueryResult2 = port.AuthenticateUser(tB_devicePassword.Text);
        }

        private void ResetDevice(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            SomeONeSerial port = new SomeONeSerial(_port);
            //Ask the device if it is a a someONe device
            _arduinoQueryResult3 = port.ResetDevice();
        }

        private void ArduinoQueryCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            StopWaitAnimation();
            //Is a valid device
            if (_arduinoQueryResult)
            {
                if (tB_devicePassword.Text != String.Empty)
                {
                    StartWaitAnimation();
                    var task = new BackgroundWorker();
                    task.DoWork += new DoWorkEventHandler(AuthenticateUser);
                    task.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ArduinoQueryCompleted2);
                    task.RunWorkerAsync();
                    l_error.Text = @"Authenticating...";
                    l_error.Visible = true;
                }
                else
                {
                    l_error.Text = @"A password is required to authenticate.";
                    l_error.Visible = true;
                }
            }
            else
            {
                l_error.Text = @"The selected device is not a someONe device.";
                l_error.Visible = true;
            }
        }

        private void ArduinoQueryCompleted2(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            //Authenticated
            StopWaitAnimation();
            if (_arduinoQueryResult2)
            {
                var task = new BackgroundWorker();
                task.DoWork += new DoWorkEventHandler(ResetDevice);
                task.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ArduinoQueryCompleted3);
                task.RunWorkerAsync();
                l_error.Text = @"The device is being rebooted...";
                l_error.Visible = true;
                StartWaitAnimation();
            }
            else
            {
                l_error.Text = @"The authentication failed.";
                l_error.Visible = true;
            }

        }

        private void ArduinoQueryCompleted3(object sender, RunWorkerCompletedEventArgs e)
        {
            StopWaitAnimation();
            l_error.Text = @"Device rebooted successfully.";
            b_Reset.Visible = false;
            b_Cancel.Text = @"Exit";
        }

        void StartWaitAnimation()
        {
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            b_Reset.Enabled = false;
            b_Cancel.Enabled = false;
        }

        void StopWaitAnimation()
        {
            progressBar1.Visible = false;
            b_Reset.Enabled = true;
            b_Cancel.Enabled = true;
        }

        private void b_Reset_Click(object sender, EventArgs e)
        {
        //Saves the name of the port of the selected device
        string device = "";
        
        //Gets the selected device text
        if (lB_device_list.SelectedItem != null) device = lB_device_list.SelectedItem.ToString();

            if (device != string.Empty)
            {
                _port = device;
                StartWaitAnimation();
                var task = new BackgroundWorker();
                task.DoWork += new DoWorkEventHandler(IsValidDevice);
                task.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ArduinoQueryCompleted);
                task.RunWorkerAsync();
                l_error.Text = @"Checking device...";
                l_error.Visible = true;
            }
            else
            {
                l_error.Text = @"No device was selected.";
                l_error.Visible = true;
            }
        }

        private void StopAnimation(object sender, RunWorkerCompletedEventArgs e)
        {
            StopWaitAnimation();
            l_error.Visible = false;
        }

        ///<summary>
        ///Gets a string array of the COM devices available
        ///</summary>
        private void PopulateDeviceListBox()
        {
            //Get the available devices
            string[] devices = SerialPort.GetPortNames();
            //If there are no devices show a message to the user
            if (devices.Length == 0)
            {
                l_error.Text = @"No devices were found.";
                l_error.Visible = true;
                return;
            }
            //If there are devices populate the listBox with them.
            foreach (var device in devices)
            {
                lB_device_list.Items.Add(device);
            }
        }

        private void b_Cancel_Click(object sender, EventArgs e)
        {
            _entrypointForm.Show();
            this.Dispose();
        }
    }
}
