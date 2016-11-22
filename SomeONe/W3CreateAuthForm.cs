using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            //Setup form appearance
            this.Width = 700;
            this.Height = 500;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;

            //Check if the device needs user authentication. If it fails then it will not require a new password.
            SomeONeSerial port = new SomeONeSerial(Config.DevicePort);

            //If the device needs authentication show a textBox to insert the old password.
            var response = port.DeviceNeedsUserAuth();
            if (response.ErrorFlag)
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
            //Creates a serial connection with the device
            SomeONeSerial port = new SomeONeSerial(Config.DevicePort);
            //If user authentication is necessary
            if (NeedsUserAuth == true)
            {
                if (tB_devicePrevPassword.Text.Trim() != "")
                {
                    //Get the old password and test it
                    var response = port.AuthenticateUser(tB_devicePrevPassword.Text.ToString());
                    if (response.ErrorFlag)
                    {
                        //Device error
                        MessageBox.Show(@"SomeONe Error: " + response.Error);
                    } //end if
                    else
                    {
                        if (response.Result)
                        {
                            //If old password is valid
                            if (tB_deviceName.Text.Trim() != "" && tB_devicePassword.Text.Trim() != "")
                            {
                                //The password only contains numbers and the name only letters
                                if (Regex.IsMatch(tB_deviceName.Text, @"^[a-zA-Z]+$")|| Regex.IsMatch(tB_devicePassword.Text, @"^[0-9]+$"))
                                {
                                    MessageBox.Show(@"The device name can only contain letters and the password can only contain numbers.");
                                } //end if
                                    //Adds the information to the configuration structure
                                    Config.DeviceUsername = tB_deviceName.Text;
                                    Config.DevicePassword = tB_devicePassword.Text;
                                    //Goes to next form
                                    W4DeviceServerURLForm form = new W4DeviceServerURLForm(EntryPoint, this, Config);
                                    form.Show();
                                    this.Dispose();
                             } //end if
                         }
                         else
                         {

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
