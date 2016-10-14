namespace SomeONe
{
    partial class W3CreateAuthForm
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
            this.b_next = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.l_deviceName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tB_deviceName = new System.Windows.Forms.TextBox();
            this.tB_devicePassword = new System.Windows.Forms.TextBox();
            this.l_devicePassword = new System.Windows.Forms.Label();
            this.tB_devicePrevPassword = new System.Windows.Forms.TextBox();
            this.l_devicePrevPassword = new System.Windows.Forms.Label();
            this.b_back = new System.Windows.Forms.Button();
            this.l_error = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // b_next
            // 
            this.b_next.Location = new System.Drawing.Point(516, 426);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(75, 23);
            this.b_next.TabIndex = 9;
            this.b_next.Text = "Next";
            this.b_next.UseVisualStyleBackColor = true;
            this.b_next.Click += new System.EventHandler(this.b_next_Click);
            // 
            // b_cancel
            // 
            this.b_cancel.Location = new System.Drawing.Point(597, 426);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(75, 23);
            this.b_cancel.TabIndex = 8;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // l_deviceName
            // 
            this.l_deviceName.AutoSize = true;
            this.l_deviceName.Location = new System.Drawing.Point(363, 139);
            this.l_deviceName.Name = "l_deviceName";
            this.l_deviceName.Size = new System.Drawing.Size(75, 13);
            this.l_deviceName.TabIndex = 10;
            this.l_deviceName.Text = "Device Name:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 437);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // tB_deviceName
            // 
            this.tB_deviceName.Location = new System.Drawing.Point(366, 155);
            this.tB_deviceName.Name = "tB_deviceName";
            this.tB_deviceName.Size = new System.Drawing.Size(225, 20);
            this.tB_deviceName.TabIndex = 12;
            // 
            // tB_devicePassword
            // 
            this.tB_devicePassword.Location = new System.Drawing.Point(366, 196);
            this.tB_devicePassword.Name = "tB_devicePassword";
            this.tB_devicePassword.Size = new System.Drawing.Size(225, 20);
            this.tB_devicePassword.TabIndex = 14;
            // 
            // l_devicePassword
            // 
            this.l_devicePassword.AutoSize = true;
            this.l_devicePassword.Location = new System.Drawing.Point(363, 180);
            this.l_devicePassword.Name = "l_devicePassword";
            this.l_devicePassword.Size = new System.Drawing.Size(93, 13);
            this.l_devicePassword.TabIndex = 13;
            this.l_devicePassword.Text = "Device Password:";
            // 
            // tB_devicePrevPassword
            // 
            this.tB_devicePrevPassword.Location = new System.Drawing.Point(366, 239);
            this.tB_devicePrevPassword.Name = "tB_devicePrevPassword";
            this.tB_devicePrevPassword.Size = new System.Drawing.Size(225, 20);
            this.tB_devicePrevPassword.TabIndex = 16;
            this.tB_devicePrevPassword.Visible = false;
            // 
            // l_devicePrevPassword
            // 
            this.l_devicePrevPassword.AutoSize = true;
            this.l_devicePrevPassword.Location = new System.Drawing.Point(363, 223);
            this.l_devicePrevPassword.Name = "l_devicePrevPassword";
            this.l_devicePrevPassword.Size = new System.Drawing.Size(137, 13);
            this.l_devicePrevPassword.TabIndex = 15;
            this.l_devicePrevPassword.Text = "Device Previous Password:";
            this.l_devicePrevPassword.Visible = false;
            // 
            // b_back
            // 
            this.b_back.Location = new System.Drawing.Point(435, 426);
            this.b_back.Name = "b_back";
            this.b_back.Size = new System.Drawing.Size(75, 23);
            this.b_back.TabIndex = 17;
            this.b_back.Text = "Back";
            this.b_back.UseVisualStyleBackColor = true;
            this.b_back.Click += new System.EventHandler(this.b_back_Click);
            // 
            // l_error
            // 
            this.l_error.AutoSize = true;
            this.l_error.BackColor = System.Drawing.Color.Red;
            this.l_error.ForeColor = System.Drawing.Color.White;
            this.l_error.Location = new System.Drawing.Point(367, 273);
            this.l_error.Margin = new System.Windows.Forms.Padding(0);
            this.l_error.Name = "l_error";
            this.l_error.Padding = new System.Windows.Forms.Padding(5);
            this.l_error.Size = new System.Drawing.Size(224, 62);
            this.l_error.TabIndex = 18;
            this.l_error.Text = "Device was alredy configurated with            \r\n another password. \r\nPlease writ" +
    "e the previous password. \r\nIf you do not remember it, reset the device.";
            this.l_error.Visible = false;
            // 
            // W3CreateAuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.l_error);
            this.Controls.Add(this.b_back);
            this.Controls.Add(this.tB_devicePrevPassword);
            this.Controls.Add(this.l_devicePrevPassword);
            this.Controls.Add(this.tB_devicePassword);
            this.Controls.Add(this.l_devicePassword);
            this.Controls.Add(this.tB_deviceName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.l_deviceName);
            this.Controls.Add(this.b_next);
            this.Controls.Add(this.b_cancel);
            this.Name = "W3CreateAuthForm";
            this.Text = "W3CreateAuthForm";
            this.Load += new System.EventHandler(this.W3CreateAuthForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_next;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Label l_deviceName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tB_deviceName;
        private System.Windows.Forms.TextBox tB_devicePassword;
        private System.Windows.Forms.Label l_devicePassword;
        private System.Windows.Forms.TextBox tB_devicePrevPassword;
        private System.Windows.Forms.Label l_devicePrevPassword;
        private System.Windows.Forms.Button b_back;
        private System.Windows.Forms.Label l_error;
    }
}