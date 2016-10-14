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
        private Form EntryPoint { get; set; }
        private Form BackForm { get; set; }
        private SomeONeConfig Config { get; set; }
        private int NeedsUserAuth = -1;

        public W3CreateAuthForm(EntrypointForm entryForm, W2WirelessNetworkSelectionAuthForm backForm, SomeONeConfig config)
        {
            EntryPoint = entryForm;
            BackForm = backForm;
            Config = config;
            
            InitializeComponent();
        }

        private void W3CreateAuthForm_Load(object sender, EventArgs e)
        {

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
            if (NeedsUserAuth == -1)
            {
                var result = port.NeedsUserAuth();
                if (result.ErrorFlag)
                {
                    MessageBox.Show(@"SomeONe Error: " + result.Error);
                }
                else
                {
                    if (result.Result == true)
                    {
                        l_devicePrevPassword.Visible = true;
                        tB_devicePrevPassword.Visible = true;
                        NeedsUserAuth = 1;
                        return;
                    }
                    else
                    {
                        NeedsUserAuth = 0;
                    }
                }
            } else if (NeedsUserAuth == 1)
            {
                
            } else if (NeedsUserAuth == 0)
            {
                Config.DeviceUsername = tB_deviceName.Text.ToString();
                Config.DevicePassword = tB_devicePassword.Text.ToString();

            }

           
            
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            EntryPoint.Show();
            this.Dispose();
        }
    }
}
