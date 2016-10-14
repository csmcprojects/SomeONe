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
    public partial class DeviceManager : Form
    {
        private readonly EntrypointForm _entryForm;

        public DeviceManager(EntrypointForm entryForm)
        {
            _entryForm = entryForm;
            InitializeComponent();
        }

        private void DeviceManager_Load(object sender, EventArgs e)
        {

        }

        private void DeviceManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            _entryForm.Show();
        }
    }
}
