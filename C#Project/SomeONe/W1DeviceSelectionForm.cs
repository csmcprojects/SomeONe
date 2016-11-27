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
using System.Windows.Forms.VisualStyles;
using SomeONe;

namespace SomeONe
{
    public partial class W1DeviceSelectionForm : Form
    {

        ///The entrypoint form object, necessary for the cancel button
        private EntrypointForm EntrypointForm { get; set; }
        //Saves the name of the port of the selected device
        private string _device = "";
        //The result of the query
        private bool _queryResult = false;

        ///<summary>
        ///The form constructor
        ///</summary>
        public W1DeviceSelectionForm(EntrypointForm entrypointForm)
        {
            //Initializes all the form components
            InitializeComponent();
            //Initializes the entrypoint form variable
            EntrypointForm = entrypointForm;
            //Populates the listBox with the available COM devices
            PopulateDeviceListBox();
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
                lB_deviceList.Items.Add(device);
            }        
        }

        ///<summary>
        ///Goes back to the entry point form.
        ///</summary>
        private void b_Cancel_Click(object sender, EventArgs e)
        {
            EntrypointForm.Show();
            this.Dispose();
        }

        ///<summary>
        ///Goes to the next form if the selected device is a someONe device
        ///</summary>
        private void b_Next_Click(object sender, EventArgs e)
        {
            //Gets the selected device text
            //if no port is selected show a error message to the user
            if (lB_deviceList.SelectedItem != null) { _device = lB_deviceList.SelectedItem.ToString(); }
            else { l_error.Text = @"A device must be selected."; l_error.Visible = true; return; }

            //Ask the device if it is a a someONe device
            var task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(CheckDevice);
            task.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ArduinoQueryCompleted);
            task.RunWorkerAsync();

            StartWaitAnimation();
        }

        private void CheckDevice(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            SomeONeSerial port = new SomeONeSerial(_device);
            _queryResult = port.IsSomeoneDevice();      
        }

        private void ArduinoQueryCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            StopWaitAnimation();
            if (_queryResult)
            {
                //Create the config structure with all the necessary data to config the device in the final form
                SomeONeConfig config = new SomeONeConfig();
                //Adds the device port information
                config.DevicePort = _device;
                //Goes to next form
                W2WirelessNetworkSelectionAuthForm form = new W2WirelessNetworkSelectionAuthForm(EntrypointForm, config);
                form.Show();
                //Disposes of this form
                this.Dispose();
            }
            else
            {
                l_error.Text = @"The selected device is not a someONe device."; l_error.Visible = true;             
            }
        }

        void StartWaitAnimation()
        {
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            b_Next.Enabled = false;
            b_Cancel.Enabled = false;
        }

        void StopWaitAnimation()
        {
            progressBar1.Visible = false;
            b_Next.Enabled = true;
            b_Cancel.Enabled = true;
        }
    }
}
