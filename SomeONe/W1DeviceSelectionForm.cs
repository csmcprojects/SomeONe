using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using SomeONe;

namespace SomeONe
{
    public partial class W1DeviceSelectionForm : Form
    {

        public W1DeviceSelectionForm()
        {
            InitializeComponent();
        }

        ///<summary>
        ///Initializes the devices list and populates it.
        ///</summary>
        private void DeviceSelectionForm_Load(object sender, EventArgs e)
        {
            string[] devices = PopulateDeviceList();
            foreach (var device in devices)
            {
                lB_device_list.Items.Add(device);
            }
        }

        ///<summary>
        ///Gets a string array of the COM devices available
        ///</summary>
        private string[] PopulateDeviceList()
        {
            return SerialPort.GetPortNames();
        }

        private void B_Next_Click(object sender, EventArgs e)
        {
            try
            {
                string device = null;
           
                if (lB_device_list.SelectedItem != null)  device = lB_device_list.SelectedItem.ToString();

                if (device != null)
                {
                    
                }
                else
                {
                    l_error_selectdevice.Visible = true;
                }
            }
            catch (Exception er)
            {
                    MessageBox.Show(@"SomeONe Error: " + er.Message);
                    throw;
            }
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            EntrypointForm frm = new EntrypointForm();
            frm.Show();
            this.Dispose();
        }
    }
}
