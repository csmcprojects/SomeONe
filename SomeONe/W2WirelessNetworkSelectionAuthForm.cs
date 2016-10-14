using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using NativeWifi;

namespace SomeONe
{
    public partial class W2WirelessNetworkSelectionAuthForm : Form
    {
        private EntrypointForm _cancelForm { get; set; }
        public W1DeviceSelectionForm _backForm { get; set; }
        private SomeONeConfig _config { get; set; }

        public void DisposeAll()
        {
            _backForm.Dispose();
        }
        public W2WirelessNetworkSelectionAuthForm(EntrypointForm cancelForm, W1DeviceSelectionForm backForm, SomeONeConfig config)
        {
            _cancelForm = cancelForm;
            _backForm = backForm;
            _config = config;

            //Appearance
            this.Width = 700;
            this.Height = 500;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
        }

        private void W2WirelessNetworkSelectionAuthForm_Load(object sender, EventArgs e)
        {
            SomeONeSerial port = new SomeONeSerial(_config.DevicePort);
            GetDeviceList();
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            _cancelForm.Show();
            this.Dispose();
        }

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
                    SomeONeSerial port = new SomeONeSerial(_config.DevicePort);
                    if (port.IsEspWifiAuthValid(wifiNetworkName, wifiNetworkPassword))
                    {
                        _config.DeviceNetworkUsername = wifiNetworkName;
                        _config.DeviceNetworkPassword = wifiNetworkPassword;

                        W3CreateAuthForm form = new W3CreateAuthForm(_cancelForm, this, _config);
                        form.Show();

                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("You need to select a network and write it's password.");
                }
                
            }
            catch (Exception er)
            {
                MessageBox.Show(@"SomeONe Error: " + er.Message);
                throw;
            }
        }

        private void rB_device_CheckedChanged(object sender, EventArgs e)
        {
            GetDeviceList();
        }

        /// <summary>
        /// Gets the wifi network list from the device.
        /// </summary>
        private void GetDeviceList()
        {
           /* SomeONeSerial port = new SomeONeSerial(_config.DevicePort);
            string[] networkList = port.GetWifiNetworksList();
            foreach (var network in networkList)
            {
                lB_device_list.Items.Add(network);
            }*/
        }

        private void GetComputerNetworkList()
        {
            lB_device_list.Items.Clear();
            WlanClient client = new WlanClient();
           
            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {
                Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);
                foreach (Wlan.WlanAvailableNetwork network in networks)
                {
                    lB_device_list.Items.Add(network.profileName);
                }
            }
           
        }
       
        private void rB_pc_CheckedChanged(object sender, EventArgs e)
        {
            GetComputerNetworkList();
        }
    }
}
