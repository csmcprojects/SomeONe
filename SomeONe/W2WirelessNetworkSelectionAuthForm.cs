using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NativeWifi;

namespace SomeONe
{
    public partial class W2WirelessNetworkSelectionAuthForm : Form
    {
        private EntrypointForm CancelForm { get; set; }
        private W1DeviceSelectionForm BackForm { get; set; }
        private SomeONeConfig Config { get; set; }
        private List<EspNetworkDescriptior> Descriptors { get; set; } 

        public W2WirelessNetworkSelectionAuthForm(EntrypointForm cancelForm, W1DeviceSelectionForm backForm, SomeONeConfig config)
        {
            //Button callback methods
            CancelForm = cancelForm;
            BackForm = backForm;
            Config = config;

            //Appearance
            this.Width = 700;
            this.Height = 500;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;

            Descriptors = new List<EspNetworkDescriptior>();

            InitializeComponent();
        }

        /// <summary>
        /// Gets the device network list and populates the listbox with the network names
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void W2WirelessNetworkSelectionAuthForm_Load(object sender, EventArgs e)
        {
            //Gets the device network list and miscellaneous data
            GetDeviceList();
            //Populates the listBox with the available network names;
            foreach (var network in Descriptors)
            {
                lB_device_list.Items.Add(network.NetworkName);
            }
        }

        /// <summary>
        /// Cancels the configuration wizard and takes the user back to the EntryPointForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            CancelForm.Show();
            this.Dispose();
        }

        /// <summary>
        /// Validates the user credentials for the selected network and if successfull goes to the netxt
        /// step in the configuration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Next_Click(object sender, EventArgs e)
        {
            try
            {
                string wifiNetworkName = "";
                if (lB_device_list.SelectedItem != null)
                {
                    wifiNetworkName = lB_device_list.SelectedItem.ToString();
                }
                var wifiNetworkPassword = tB_password.Text;
                if (wifiNetworkName.Trim() != String.Empty && wifiNetworkPassword.Trim() != String.Empty)
                {
                    SomeONeSerial port = new SomeONeSerial(Config.DevicePort);
                    if (port.IsEspWifiAuthValid(wifiNetworkName, wifiNetworkPassword))
                    {
                        Config.DeviceNetworkUsername = wifiNetworkName;
                        Config.DeviceNetworkPassword = wifiNetworkPassword;

                        W3CreateAuthForm form = new W3CreateAuthForm(CancelForm, this, Config);
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(@"The authentication failed. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show(@"You need to select a network and write the correct password.");
                }
                
            }
            catch (Exception er)
            {
                MessageBox.Show(@"SomeONe Error: " + er.Message);
                throw;
            }
        }

        /// <summary>
        /// Gets the wifi network list from the device.
        /// </summary>
        private void GetDeviceList()
        {
            
            SomeONeSerial port = new SomeONeSerial(Config.DevicePort);
            Descriptors = port.GetWifiNetworksList();
        }

        /// <summary>
        /// Checks if the network needs a username authentication, usually seen in enterprise networks.
        /// And if so, makes visible the appropriate textBox to fill that information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lB_device_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lB_device_list.SelectedItem != null)
            {
                var networkName = lB_device_list.SelectedItem.ToString();
                if (NetworkNeedsUsername(networkName))
                {
                    l_username.Visible = true;
                    tB_username.Visible = true;
                }
                else
                {
                    l_username.Visible = false;
                    tB_username.Visible = false;
                }
            }
        }

        /// <summary>
        /// NOT FINISHED
        /// </summary>
        /// <param name="networkName"></param>
        /// <returns></returns>
        private bool NetworkNeedsUsername(string networkName)
        {
            return (from network in Descriptors where network.NetworkName == networkName select (network.NetworkType == "3")).FirstOrDefault();
        }
    }
}
