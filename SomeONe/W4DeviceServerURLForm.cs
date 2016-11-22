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
    public partial class W4DeviceServerURLForm : Form
    {
        private EntrypointForm CancelForm { get; set; }
        private W3CreateAuthForm BackForm { get; set; }
        private SomeONeConfig Config { get; set; }

        public W4DeviceServerURLForm(EntrypointForm cancelForm, W3CreateAuthForm backForm, SomeONeConfig config)
        {
            CancelForm = cancelForm;
            BackForm = backForm;
            Config = config;

            InitializeComponent();
        }

        private void W4DeviceServerURLForm_Load(object sender, EventArgs e)
        {

        }

        private void B_Next_Click(object sender, EventArgs e)
        {
            if (IsValidURL(tB_url.Text))
            {
                //Saves the data
                Config.WebInterfaceUrl = tB_url.Text;
                W5FinalConfigurationForm form = new W5FinalConfigurationForm(CancelForm, this, Config);
                this.Dispose();
            }
            else
            {
                MessageBox.Show(@"The url is not valid.");
            }
        }

        private bool IsValidURL(string url)
        {
            Uri result;
            return Uri.TryCreate(url, UriKind.Absolute, out result)
            && (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
        }

        private void B_Back_Click(object sender, EventArgs e)
        {
            BackForm.Show();
            this.Dispose();
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            CancelForm.Show();
        }
    }
}
