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
        public W2WirelessNetworkSelectionAuthForm BackForm { get; set; }
        private SomeONeConfig Config { get; set; }
        private bool _arduinoQueryResponse = false;
        private bool _arduinoQueryResponse2 = false;

        public W3CreateAuthForm(EntrypointForm entryForm, W2WirelessNetworkSelectionAuthForm backForm, SomeONeConfig config)
        {
            EntryPoint = entryForm;
            BackForm = backForm;
            Config = config;
            
            InitializeComponent();

            //Checks if the device needs authentication
            var task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(UserNeedsAuth);
            task.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ArduinoQueryCompleted);
            task.RunWorkerAsync();
            StartWaitAnimation();
        }

        private void UserNeedsAuth(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            //Creates a serial connection with the device
            SomeONeSerial port = new SomeONeSerial(Config.DevicePort);
            _arduinoQueryResponse = port.DeviceNeedsUserAuth();
        }

        private void ArduinoQueryCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            StopWaitAnimation();
            if (_arduinoQueryResponse)
            {                
                tB_devicePrevPassword.Visible = true;
                l_devicePrevPassword.Visible = true;
            }
        }

        void StartWaitAnimation()
        {
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            b_Next.Enabled = false;
            b_Back.Enabled = false;
            b_Cancel.Enabled = false;
        }

        void StopWaitAnimation()
        {

            progressBar1.Visible = false;
            b_Next.Enabled = true;
            b_Back.Enabled = true;
            b_Cancel.Enabled = true;
        }

        private void W3CreateAuthForm_Load(object sender, EventArgs e)
        {
             }

        private
            void b_back_Click(object sender, EventArgs e)
        {
            BackForm.Show();
            this.Dispose();
        }

        private void AuthenticateUser(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            SomeONeSerial port = new SomeONeSerial(Config.DevicePort);
            _arduinoQueryResponse2 = port.AuthenticateUser(tB_devicePrevPassword.Text.ToString());
        }

        private void ArduinoQueryCompleted2(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            StopWaitAnimation();
            if (_arduinoQueryResponse2)
            {
                //Adds the information to the configuration structure
                Config.DeviceUsername = tB_deviceName.Text;
                Config.DevicePassword = tB_devicePassword.Text;
                //Goes to next form
                W4DeviceServerURLForm form = new W4DeviceServerURLForm(EntryPoint, this, Config);
                form.Show();
                this.Hide();
            }
            else
            {
                l_error.Text = @"The authentication failed.";
                l_error.Visible = true;
            }           
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            //Checks if the username and new password are valid
            if (tB_deviceName.Text.Trim() != "" && tB_devicePassword.Text.Trim() != "")
            {
                //The password only contains numbers and the name only letters
                if (!(Regex.IsMatch(tB_deviceName.Text, @"^[a-zA-Z]+$") &&
                      Regex.IsMatch(tB_devicePassword.Text, @"^[0-9]+$")))
                {
                    l_error.Text = (@"The device name can only contain letters" + Environment.NewLine + @"and the password can only contain numbers.");
                    l_error.Visible = true;
                    return;
                } //end if
            }
            else
            {
                l_error.Text = @"You must define a name and password for your device.";
                l_error.Visible = true;
                return;
            }

            //If user authentication is necessary
            if (_arduinoQueryResponse == true)
            {
                //Try to authenticate with the old password
                if (tB_devicePrevPassword.Text.Trim() != string.Empty && Regex.IsMatch(tB_devicePrevPassword.Text, @"^[0-9]+$"))
                {
                    StartWaitAnimation();
                    //Checks if the device needs authentication
                    var task = new BackgroundWorker();
                    task.DoWork += new DoWorkEventHandler(AuthenticateUser);
                    task.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ArduinoQueryCompleted2);
                    task.RunWorkerAsync();
                    l_error.Text = @"Trying to authenticate the user...";
                    l_error.Visible = true;
                }
                else
                {
                    l_error.Text = @"You must insert the current device password.";
                }
            }
            else
            {
                //If old password is valid
                if (tB_deviceName.Text.Trim() != "" && tB_devicePassword.Text.Trim() != "")
                {
                    //The password only contains numbers and the name only letters
                    if (!(Regex.IsMatch(tB_deviceName.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(tB_devicePassword.Text, @"^[0-9]+$")))
                    {
                        MessageBox.Show(@"The device name can only contain letters\r\n and the password can only contain numbers.");
                        return;
                    } //end if
                      //Adds the information to the configuration structure
                    Config.DeviceUsername = tB_deviceName.Text;
                    Config.DevicePassword = tB_devicePassword.Text;
                    //Goes to next form
                    W4DeviceServerURLForm form = new W4DeviceServerURLForm(EntryPoint, this, Config);
                    form.Show();
                    this.Hide();
                } //end if
            }
        }         


        private void b_cancel_Click(object sender, EventArgs e)
        {
            EntryPoint.Show();
            BackForm.Dispose();
            this.Dispose();
        }
    }
}
