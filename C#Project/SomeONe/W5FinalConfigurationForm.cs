using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomeONe
{
    public partial class W5FinalConfigurationForm : Form
    {
        private EntrypointForm CancelForm { get; set; }
        private W4DeviceServerURLForm BackForm { get; set; } 
        private SomeONeConfig Config { get; set; }
        private bool _arduinoQueryResult = false;

        public W5FinalConfigurationForm(EntrypointForm cancelForm, W4DeviceServerURLForm backForm, SomeONeConfig config)
        {
            CancelForm = cancelForm;
            BackForm = backForm;
            Config = config;

            InitializeComponent();
        }

        private void W5FinalConfigurationForm_Load(object sender, EventArgs e)
        {
            l_deviceName.Text = Config.DeviceUsername;
            l_devicePassword.Text = Config.DevicePassword;
            l_wifNetwork.Text = Config.DeviceWifiNetworkName;
            l_wifiPassword.Text = Config.DeviceNetworkPassword;
            l_serverHost.Text = Config.WebServerHost;
            l_serverAuthKey.Text = Config.UrlAuthToken;
            l_ServeUrl.Text = Config.WebInterfaceUrl;
        }
        void StartWaitAnimation()
        {
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            b_Back.Enabled = false;
            b_Cancel.Enabled = false;
        }

        void StopWaitAnimation()
        {
            progressBar1.Visible = false;
            b_Back.Enabled = true;
            b_Cancel.Enabled = true;
        }

        private void SaveConfig(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            SomeONeSerial serial = new SomeONeSerial(Config.DevicePort);
            _arduinoQueryResult = serial.SaveConfig(Config);
        }

        private void ArduinoQueryCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            StopWaitAnimation();
            if (_arduinoQueryResult)
            {
                l_error.Text = @"Configuration saved.";
                l_error.Visible = true;
                b_Back.Visible = false;
                b_Config.Visible = false;
                b_Cancel.Text = @"Close";
            }
            else
            {
                l_error.Text = @"Failed to save configuration.";
            }
        }

        private void b_Config_Click(object sender, EventArgs e)
        {
            StartWaitAnimation();
            //Checks if the device needs authentication
            var task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SaveConfig);
            task.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ArduinoQueryCompleted);
            task.RunWorkerAsync();
            l_error.Text = @"Saving configuration...";
            l_error.Visible = true; 
        }

        private void b_Back_Click(object sender, EventArgs e)
        {
            BackForm.Show();
            this.Dispose();
        }

        private void b_Cancel_Click(object sender, EventArgs e)
        {
            BackForm.BackForm.BackForm.Dispose();
            BackForm.BackForm.Dispose();
            BackForm.Dispose();
            CancelForm.Show();
            this.Dispose();
        }
    }
}
