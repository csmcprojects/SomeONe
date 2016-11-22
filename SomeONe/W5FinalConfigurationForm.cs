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
            l_serverUrl.Text = Config.WebInterfaceUrl;
        }

        private void b_Config_Click(object sender, EventArgs e)
        {
            SomeONeSerial serial = new SomeONeSerial(Config.DevicePort);
            var result = serial.SaveConfig(Config);
            if (result.ErrorFlag)
            {
                MessageBox.Show(@"SomeONe device error: " + result.Error);
            }
            else
            {
                if (result.Result)
                {
                    MessageBox.Show(@"Device configured successfully.");
                }
            }
        }
    }
}
