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
    public partial class W4DeviceServerURLForm : Form
    {
        private EntrypointForm CancelForm { get; set; }
        public W3CreateAuthForm BackForm { get; set; }
        private SomeONeConfig Config { get; set; }

        public W4DeviceServerURLForm(EntrypointForm cancelForm, W3CreateAuthForm backForm, SomeONeConfig config)
        {
            CancelForm = cancelForm;
            BackForm = backForm;
            Config = config;

            InitializeComponent();
        }

        private void B_Next_Click(object sender, EventArgs e)
        {
            if (!(tB_AuthToken.Text.Trim() != "" && Regex.IsMatch(tB_AuthToken.Text, @"^[a-zA-Z0-9]+$") &&
                tB_AuthToken.TextLength >= 16 && tB_AuthToken.TextLength < 65))
            {
                l_error.Text = @"The token must contain only letters and numbers and it must contain at least 16 characters.";
                l_error.Visible = true;
                return;
            }

            if (tB_url.Text != string.Empty && tb_ServerHost.Text != string.Empty && tB_AuthToken.Text != string.Empty)
            {
                //Saves the data
                Config.WebInterfaceUrl = tB_url.Text;
                Config.UrlAuthToken = tB_AuthToken.Text;
                Config.WebServerHost = tb_ServerHost.Text;
                //Show next form
                W5FinalConfigurationForm form = new W5FinalConfigurationForm(CancelForm, this, Config);
                form.Show();
                this.Hide();
            }
            else
            {
                l_error.Text = @"All fields are required.";
                l_error.Visible = true;
            }
        }

        private void B_Back_Click(object sender, EventArgs e)
        {
            BackForm.Show();
            this.Dispose();
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            //Show entrypoint
            CancelForm.Show();
            //Dispose W2
            BackForm.BackForm.Dispose();
            //Dispose W3
            BackForm.Dispose();
            //Dispose this
            this.Dispose();
        }

        private void b_GenerateToken_Click(object sender, EventArgs e)
        {
            tB_AuthToken.Text = GenerateRandomToken();
        }

        private string GenerateRandomToken()
        {
            string[] la =
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o",
                "p", "q", "r", "s", "t", "u", "v", "x", "w", "y", "z", "0", "1", "2", "3", "4",
                "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L",
                "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "W", "Y", "Z"
            };

            string token = "";
            Random rand = new Random();
            for (int i = 0; i < 16; ++i)
            {
                token += la[rand.Next(la.Length)];
            }

            return token;
        }
    }
}
