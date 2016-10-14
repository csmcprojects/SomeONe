﻿using System;
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
    public partial class EntrypointForm : Form
    {
        public EntrypointForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 700;
            this.Height = 500;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Navy;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            W1DeviceSelectionForm frm = new W1DeviceSelectionForm(this);
            frm.Show();
            this.Hide();
        }

        private void EntrypointForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MAuthForm frm = new MAuthForm(this);
            frm.Show();
            this.Hide();
        }

        private void B_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
