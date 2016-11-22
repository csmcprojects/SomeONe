namespace SomeONe
{
    partial class W1DeviceSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Next = new System.Windows.Forms.Button();
            this.lB_device_list = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.l_error = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new System.Drawing.Point(597, 426);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(75, 23);
            this.B_Cancel.TabIndex = 0;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // B_Next
            // 
            this.B_Next.Location = new System.Drawing.Point(516, 426);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(75, 23);
            this.B_Next.TabIndex = 1;
            this.B_Next.Text = "Next";
            this.B_Next.UseVisualStyleBackColor = true;
            this.B_Next.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // lB_device_list
            // 
            this.lB_device_list.FormattingEnabled = true;
            this.lB_device_list.Location = new System.Drawing.Point(338, 215);
            this.lB_device_list.Name = "lB_device_list";
            this.lB_device_list.Size = new System.Drawing.Size(253, 82);
            this.lB_device_list.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select the device that you want to configure.";
            // 
            // l_error
            // 
            this.l_error.AutoSize = true;
            this.l_error.BackColor = System.Drawing.Color.Red;
            this.l_error.ForeColor = System.Drawing.Color.White;
            this.l_error.Location = new System.Drawing.Point(338, 300);
            this.l_error.Margin = new System.Windows.Forms.Padding(0);
            this.l_error.Name = "l_error";
            this.l_error.Padding = new System.Windows.Forms.Padding(5);
            this.l_error.Size = new System.Drawing.Size(139, 23);
            this.l_error.TabIndex = 5;
            this.l_error.Text = "You must select a device.";
            this.l_error.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SomeONe.Properties.Resources.cooltext209842929666486;
            this.pictureBox1.Location = new System.Drawing.Point(33, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // W1DeviceSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.l_error);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lB_device_list);
            this.Controls.Add(this.B_Next);
            this.Controls.Add(this.B_Cancel);
            this.Name = "W1DeviceSelectionForm";
            this.Text = "DeviceSelectionForm";
            this.Load += new System.EventHandler(this.DeviceSelectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Next;
        private System.Windows.Forms.ListBox lB_device_list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_error;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}