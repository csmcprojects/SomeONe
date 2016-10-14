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
    public partial class MAuthForm : Form
    {
        private EntrypointForm _entryForm;

        public MAuthForm(EntrypointForm entryForm)
        {
            _entryForm = entryForm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (true)
            {
                DeviceManager form = new DeviceManager(_entryForm);
                form.Show();
                this.Dispose();
            }
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            _entryForm.Show();
            this.Dispose();
        }
    }
}
