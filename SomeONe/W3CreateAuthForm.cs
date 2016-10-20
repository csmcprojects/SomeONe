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
    public partial class W3CreateAuthForm : Form
    {
        private EntrypointForm EntryPoint { get; set; }
        private W2WirelessNetworkSelectionAuthForm BackForm { get; set; }
        private SomeONeConfig Config { get; set; }
        private bool NeedsUserAuth = true;

        public W3CreateAuthForm(EntrypointForm entryForm, W2WirelessNetworkSelectionAuthForm backForm, SomeONeConfig config)
        {
            EntryPoint = entryForm;
            BackForm = backForm;
            Config = config;
            
            InitializeComponent();
        }

        private void W3CreateAuthForm_Load(object sender, EventArgs e)
        {
            SomeONeSerial port = new SomeONeSerial(Config.DevicePort);
            var response = port.DeviceNeedsUserAuth();
            if (response.ErrorFlag)
            {
                MessageBox.Show(@"SomeONe Error: " + response.Error);
            }
            else
            {
                if (response.Result == false)
                {
                    l_devicePrevPassword.Visible = true;
                    tB_devicePrevPassword.Visible = true;
                    NeedsUserAuth = true;
                }
                else
                {
                    NeedsUserAuth = false;
                }
            }
        }

        private void b_back_Click(object sender, EventArgs e)
        {
            BackForm.Show();
            this.Dispose();
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            //Check if the device has any authentication already
            SomeONeSerial port = new SomeONeSerial(Config.DevicePort);
            //If first time checkinf
            if (NeedsUserAuth == true)
            {
                if (tB_devicePrevPassword.Text.Trim() != "")
                {
                    var response = port.AuthenticateUser(tB_devicePrevPassword.Text.ToString());
                    if (response.ErrorFlag)
                    {
                        MessageBox.Show(@"SomeONe Error: " + response.Error);
                    }
                    else
                    {
                        if (response.Result)
                        {
                            if (tB_deviceName.Text.Trim() != "" && tB_devicePassword.Text.Trim() != "")
                            {
                                if (tB_deviceName.Text.Contains(';') || tB_devicePassword.Text.Contains(';'))
                                {
                                    MessageBox.Show(@"The device name or password cannot have the ; character.");
                                }
                                    Config.DeviceUsername = tB_deviceName.Text;
                                    Config.DevicePassword = tB_devicePassword.Text;
                                    W4DeviceServerURLForm form = new W4DeviceServerURLForm(EntryPoint, this, Config);
                                    form.Show();
                                    this.Dispose();
                                }
                            }                           
                        }
                    }
                }
        }         


        private void b_cancel_Click(object sender, EventArgs e)
        {
            EntryPoint.Show();
            this.Dispose();
        }
    }
}
