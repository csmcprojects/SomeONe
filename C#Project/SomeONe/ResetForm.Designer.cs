namespace SomeONe
{
    partial class ResetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetForm));
            this.l_error = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lB_device_list = new System.Windows.Forms.ListBox();
            this.b_Reset = new System.Windows.Forms.Button();
            this.tB_devicePassword = new System.Windows.Forms.TextBox();
            this.l_devicePassword = new System.Windows.Forms.Label();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.l_title = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // l_error
            // 
            this.l_error.AutoSize = true;
            this.l_error.BackColor = System.Drawing.Color.Coral;
            this.l_error.ForeColor = System.Drawing.Color.White;
            this.l_error.Location = new System.Drawing.Point(189, 342);
            this.l_error.Margin = new System.Windows.Forms.Padding(0);
            this.l_error.Name = "l_error";
            this.l_error.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.l_error.Size = new System.Drawing.Size(192, 22);
            this.l_error.TabIndex = 11;
            this.l_error.Text = "You must select a device.";
            this.l_error.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select the device that you want to configure.";
            // 
            // lB_device_list
            // 
            this.lB_device_list.FormattingEnabled = true;
            this.lB_device_list.ItemHeight = 12;
            this.lB_device_list.Location = new System.Drawing.Point(188, 200);
            this.lB_device_list.Name = "lB_device_list";
            this.lB_device_list.Size = new System.Drawing.Size(294, 76);
            this.lB_device_list.TabIndex = 9;
            // 
            // b_Reset
            // 
            this.b_Reset.Location = new System.Drawing.Point(579, 373);
            this.b_Reset.Name = "b_Reset";
            this.b_Reset.Size = new System.Drawing.Size(93, 35);
            this.b_Reset.TabIndex = 8;
            this.b_Reset.Text = "Reset";
            this.b_Reset.UseVisualStyleBackColor = true;
            this.b_Reset.Click += new System.EventHandler(this.b_Reset_Click);
            // 
            // tB_devicePassword
            // 
            this.tB_devicePassword.Location = new System.Drawing.Point(191, 305);
            this.tB_devicePassword.Name = "tB_devicePassword";
            this.tB_devicePassword.Size = new System.Drawing.Size(291, 20);
            this.tB_devicePassword.TabIndex = 16;
            // 
            // l_devicePassword
            // 
            this.l_devicePassword.AutoSize = true;
            this.l_devicePassword.Location = new System.Drawing.Point(188, 290);
            this.l_devicePassword.Name = "l_devicePassword";
            this.l_devicePassword.Size = new System.Drawing.Size(117, 12);
            this.l_devicePassword.TabIndex = 15;
            this.l_devicePassword.Text = "Device Password:";
            // 
            // b_Cancel
            // 
            this.b_Cancel.Location = new System.Drawing.Point(579, 414);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(93, 35);
            this.b_Cancel.TabIndex = 17;
            this.b_Cancel.Text = "Cancel";
            this.b_Cancel.UseVisualStyleBackColor = true;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // l_title
            // 
            this.l_title.AutoSize = true;
            this.l_title.Font = new System.Drawing.Font("Andale Mono", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_title.Location = new System.Drawing.Point(261, 105);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(141, 32);
            this.l_title.TabIndex = 30;
            this.l_title.Text = "someONe";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(579, 341);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(93, 23);
            this.progressBar1.TabIndex = 31;
            this.progressBar1.Visible = false;
            // 
            // ResetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.l_title);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.tB_devicePassword);
            this.Controls.Add(this.l_devicePassword);
            this.Controls.Add(this.l_error);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lB_device_list);
            this.Controls.Add(this.b_Reset);
            this.Font = new System.Drawing.Font("Andale Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ResetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResetForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label l_error;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lB_device_list;
        private System.Windows.Forms.Button b_Reset;
        private System.Windows.Forms.TextBox tB_devicePassword;
        private System.Windows.Forms.Label l_devicePassword;
        private System.Windows.Forms.Button b_Cancel;
        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}