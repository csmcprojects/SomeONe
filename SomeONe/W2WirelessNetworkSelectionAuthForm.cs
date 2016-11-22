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
                var fString = network.NetworkName;
                if (network.NetworkType == "2")
                {
                    fString += " (WEP)";
                } else if (network.NetworkType == "4")
                {
                    fString += " (WPA2 / PSK)";
                }
                else if (network.NetworkType == "5")
                {
                    fString += " (WEP)";
                }
                else if (network.NetworkType == "7")
                {
                    fString += " (Open Network)";
                }
                else if (network.NetworkType == "8")
                {
                    fString += " (AUTO)";
                }
                while (fString.Length < 80)
                {
                    fString += " ";
                }
                lB_device_list.Items.Add(fString);
                if (network.SignalStrength > 0 && network.SignalStrength < 25)
                {
                    lB_device_list.Items[lB_device_list.Items.Count - 1].BackColor = Color.Red;
                } else if (network.SignalStrength >= 25 && network.SignalStrength < 60)
                {
                    lB_device_list.Items[lB_device_list.Items.Count -1].BackColor = Color.Orange;
                }
                else
                {
                    lB_device_list.Items[lB_device_list.Items.Count - 1].BackColor = Color.GreenYellow;
                }
               
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
                //Saves the name of the selected wifi network
                string wifiNetworkName = "";

                //Gets the text of the selected network
                if (lB_device_list.SelectedItems.Count != 0)
                {
                    wifiNetworkName = lB_device_list.SelectedItems[0].Text.ToString();
                }
                else
                {
                    MessageBox.Show(@"You need to select a network to connect.");
                    return;
                }
                //Gets the text of the password
                var wifiNetworkPassword = tB_password.Text;

                if (wifiNetworkName.Trim() != String.Empty)
                {
                    //Creates a serial connection with the device
                    SomeONeSerial port = new SomeONeSerial(Config.DevicePort);
                    //Trys to authenticate with the credentials given.
                    if (port.IsEspWifiAuthValid(wifiNetworkName.Trim(), wifiNetworkPassword))
                    {
                        //If the authentication is successfull, save that information.
                        Config.DeviceNetworkUsername = wifiNetworkName.Trim();
                        Config.DeviceNetworkPassword = wifiNetworkPassword;
                        //Go to the next form
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
                    MessageBox.Show(@"You need to select a network and password for authentication.");
                }
                
            }
            catch (Exception er)
            {
                MessageBox.Show(@"SomeONe Error: " + er.Message);
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
            if (lB_device_list.SelectedItems[0] != null)
            {
                var networkName = lB_device_list.SelectedItems[0].Text.ToString();
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

        private void lB_device_list_DrawItem(object sender, DrawItemEventArgs e)
        {
           
        }

        private void lB_device_list_SelectedIndexChanged_1(object sender, EventArgs e)
        {
          
        }
    }
}
