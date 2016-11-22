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

        private EntrypointForm _entrypointForm { get; set; }

        public W1DeviceSelectionForm(EntrypointForm entrypointForm)
        {
            _entrypointForm = entrypointForm;

            InitializeComponent();
        }

        ///<summary>
        ///Initializes the devices list and populates it.
        ///</summary>
        private void DeviceSelectionForm_Load(object sender, EventArgs e)
        {
            //Appearance
            this.Width = 700;
            this.Height = 500;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            
            //Device population
            string[] devices = PopulateDeviceList();
            foreach (var device in devices)
            {
                lB_device_list.Items.Add(device);
            }
            if (devices.Length == 0)
            {
                l_error.Text = @"No devices were found.";
                l_error.BackColor = Color.DarkOrange;
                l_error.Visible = true;
            }
        }

        ///<summary>
        ///Gets a string array of the COM devices available
        ///</summary>
        private string[] PopulateDeviceList()
        {
            return SerialPort.GetPortNames();
        }

        ///<summary>
        ///Goes to the next step of the configuration if a device has been selected.
        ///</summary>
        private void B_Next_Click(object sender, EventArgs e)
        {
            try
            {
                //Saves the name of the port of the selected device
                string device = "";
                      
                //Gets the selected device text
                if (lB_device_list.SelectedItem != null)  device = lB_device_list.SelectedItem.ToString();

                if (device != null)
                {              
                    //Initializes a serial connection
                    SomeONeSerial port = new SomeONeSerial(device);
                    //Ask the device if it is a a someONe device
                    if (port.IsSomeoneDevice())
                    {
                        //Create the config structure with all the necessary data to config the device in the final form
                        SomeONeConfig config = new SomeONeConfig();
                        //Adds the device port information
                        config.DevicePort = device;
                        //Goes to next form
                        W2WirelessNetworkSelectionAuthForm form = new W2WirelessNetworkSelectionAuthForm(
                            _entrypointForm, this, config);
                        form.Show();
                        this.Dispose();
                    }
                    else
                    {
                        l_error.Text = @"The device is not a SomeONe device.";
                        l_error.BackColor = Color.Red;
                        l_error.Visible = true;
                    }
                }
                else
                {
                    l_error.Text = @"You must select a device.";
                    l_error.BackColor = Color.Red;
                    l_error.Visible = true;
                }
            }
            catch (Exception er)
            {
                    MessageBox.Show(@"SomeONe Error: " + er.Message);
            }
        }

        ///<summary>
        ///Goes back to the entry point form.
        ///</summary>
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            _entrypointForm.Show();
            this.Dispose();
        }

    }
}
