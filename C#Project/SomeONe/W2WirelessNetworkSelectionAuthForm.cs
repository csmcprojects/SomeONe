using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
        private SomeONeConfig Config { get; set; }
        private List<EspNetworkDescriptior> EspNetworkDescriptior { get; set; }

        //Saves the name of the selected wifi network
        private string _selectedWifiNetworkName = "";
        private string _wifiNetworkPassword = "";
        private bool _arduinoQueryResult = false;

        public W2WirelessNetworkSelectionAuthForm(EntrypointForm cancelForm, SomeONeConfig config)
        {
            //Initialize the form components
            InitializeComponent();
            //Initialize class variables
            CancelForm = cancelForm;
            Config = config;
            EspNetworkDescriptior = new List<EspNetworkDescriptior>();

            l_goodStatus.Text = ((char)0xDE).ToString() + @" good";
            l_mehStatus.Text = ((char)0xDE).ToString() + @" meh";
            l_badStatus.Text = ((char)0xDE).ToString() + @" bad";

            var task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(GetDeviceList);
            task.RunWorkerCompleted += new RunWorkerCompletedEventHandler(LoadList);
            task.RunWorkerAsync();
            l_error.Text = @"Searching for wifi network...";
            l_error.Visible = true;
            StartWaitAnimation();
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
        /// Gets the wifi network list from the device.
        /// </summary>
        private void GetDeviceList(object sender, DoWorkEventArgs doWorkEventArgs)
        {           
            SomeONeSerial port = new SomeONeSerial(Config.DevicePort);
            EspNetworkDescriptior = port.GetWifiNetworksList();
        }

        private void LoadList(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            //Populates the listBox with the available network names;
            foreach (var network in EspNetworkDescriptior)
            {
                var fString = network.NetworkName;

                lB_device_list.Items.Add(fString);
                if (network.SignalStrength > 0 && network.SignalStrength < 25)
                {
                    lB_device_list.Items[lB_device_list.Items.Count - 1].BackColor = Color.OrangeRed;
                }
                else if (network.SignalStrength >= 25 && network.SignalStrength < 60)
                {
                    lB_device_list.Items[lB_device_list.Items.Count - 1].BackColor = Color.Coral;
                }
                else
                {
                    lB_device_list.Items[lB_device_list.Items.Count - 1].BackColor = Color.GreenYellow;
                }

            }
            StopWaitAnimation();
            l_error.Visible = false;
        }

        private void TestConnection(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            //Creates a serial connection with the device
            SomeONeSerial port = new SomeONeSerial(Config.DevicePort);
            //Trys to authenticate with the credentials given.
            _arduinoQueryResult = port.IsEspWifiAuthValid(_selectedWifiNetworkName.Trim(), _wifiNetworkPassword);            
        }

        private void ArduinoQueryCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            if (_arduinoQueryResult)
            {
                //If the authentication is successful, save that information.
                Config.DeviceWifiNetworkName = _selectedWifiNetworkName.Trim();
                Config.DeviceNetworkPassword = _wifiNetworkPassword;
                //Go to the next form
                W3CreateAuthForm form = new W3CreateAuthForm(CancelForm, this, Config);
                form.Show();
                StopWaitAnimation();
                l_error.Visible = false;
                this.Hide();
            }
            else
            {
                l_error.Text = @"The authentication failed. Please try again.";
                l_error.Visible = true;
                StopWaitAnimation();
            }
        }

        void StartWaitAnimation()
        {
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            b_Nextt.Enabled = false;
            b_Back.Enabled = false;
            b_Cancel.Enabled = false;
        }

        void StopWaitAnimation()
        {
            
            progressBar1.Visible = false;
            b_Nextt.Enabled = true;
            b_Back.Enabled = true;
            b_Cancel.Enabled = true;
        }

        private void b_Back_Click(object sender, EventArgs e)
        {
            W1DeviceSelectionForm form = new W1DeviceSelectionForm(CancelForm);
            form.Show();
            this.Dispose();
        }

        // <summary>
        /// Validates the user credentials for the selected network and if successfull goes to the netxt
        /// step in the configuration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_Nextt_Click(object sender, EventArgs e)
        {
            //Gets the text of the selected network
            if (lB_device_list.SelectedItems.Count != 0)
            {
                _selectedWifiNetworkName = lB_device_list.SelectedItems[0].Text.ToString();

                if (_selectedWifiNetworkName.Trim() == String.Empty)
                {
                    l_error.Text = @"You need to select a network and password for authentication.";
                    l_error.Visible = true;
                }
                else
                {
                    //Gets the text of the password
                    _wifiNetworkPassword = tB_password.Text;

                    //Checks if the credentials work
                    var task = new BackgroundWorker();
                    task.DoWork += new DoWorkEventHandler(TestConnection);
                    task.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ArduinoQueryCompleted);
                    task.RunWorkerAsync();
                    l_error.Visible = true;
                    l_error.Text = @"Trying to connect to the wifi network.";

                    StartWaitAnimation();
                }
            }
            else
            {
                l_error.Text = @"You need to select a network to connect.";
                l_error.Visible = true;
            }
        }
    }
}
