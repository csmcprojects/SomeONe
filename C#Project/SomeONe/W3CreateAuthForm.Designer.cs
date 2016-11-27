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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(W3CreateAuthForm));
            this.b_Next = new System.Windows.Forms.Button();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.l_deviceName = new System.Windows.Forms.Label();
            this.tB_deviceName = new System.Windows.Forms.TextBox();
            this.tB_devicePassword = new System.Windows.Forms.TextBox();
            this.l_devicePassword = new System.Windows.Forms.Label();
            this.tB_devicePrevPassword = new System.Windows.Forms.TextBox();
            this.l_devicePrevPassword = new System.Windows.Forms.Label();
            this.b_Back = new System.Windows.Forms.Button();
            this.l_error = new System.Windows.Forms.Label();
            this.l_title = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // b_Next
            // 
            this.b_Next.Location = new System.Drawing.Point(579, 332);
            this.b_Next.Name = "b_Next";
            this.b_Next.Size = new System.Drawing.Size(93, 35);
            this.b_Next.TabIndex = 9;
            this.b_Next.Text = "Next";
            this.b_Next.UseVisualStyleBackColor = true;
            this.b_Next.Click += new System.EventHandler(this.b_next_Click);
            // 
            // b_Cancel
            // 
            this.b_Cancel.Location = new System.Drawing.Point(579, 414);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(93, 35);
            this.b_Cancel.TabIndex = 8;
            this.b_Cancel.Text = "Cancel";
            this.b_Cancel.UseVisualStyleBackColor = true;
            this.b_Cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // l_deviceName
            // 
            this.l_deviceName.AutoSize = true;
            this.l_deviceName.Location = new System.Drawing.Point(167, 172);
            this.l_deviceName.Name = "l_deviceName";
            this.l_deviceName.Size = new System.Drawing.Size(89, 12);
            this.l_deviceName.TabIndex = 10;
            this.l_deviceName.Text = "Device Name:";
            // 
            // tB_deviceName
            // 
            this.tB_deviceName.Location = new System.Drawing.Point(171, 187);
            this.tB_deviceName.Name = "tB_deviceName";
            this.tB_deviceName.Size = new System.Drawing.Size(262, 20);
            this.tB_deviceName.TabIndex = 12;
            this.tB_deviceName.Text = "MySecretDevice";
            // 
            // tB_devicePassword
            // 
            this.tB_devicePassword.Location = new System.Drawing.Point(171, 225);
            this.tB_devicePassword.Name = "tB_devicePassword";
            this.tB_devicePassword.Size = new System.Drawing.Size(262, 20);
            this.tB_devicePassword.TabIndex = 14;
            this.tB_devicePassword.Text = "1234";
            // 
            // l_devicePassword
            // 
            this.l_devicePassword.AutoSize = true;
            this.l_devicePassword.Location = new System.Drawing.Point(167, 210);
            this.l_devicePassword.Name = "l_devicePassword";
            this.l_devicePassword.Size = new System.Drawing.Size(117, 12);
            this.l_devicePassword.TabIndex = 13;
            this.l_devicePassword.Text = "Device Password:";
            // 
            // tB_devicePrevPassword
            // 
            this.tB_devicePrevPassword.Location = new System.Drawing.Point(171, 265);
            this.tB_devicePrevPassword.Name = "tB_devicePrevPassword";
            this.tB_devicePrevPassword.Size = new System.Drawing.Size(262, 20);
            this.tB_devicePrevPassword.TabIndex = 16;
            this.tB_devicePrevPassword.Text = "1234";
            this.tB_devicePrevPassword.Visible = false;
            // 
            // l_devicePrevPassword
            // 
            this.l_devicePrevPassword.AutoSize = true;
            this.l_devicePrevPassword.Location = new System.Drawing.Point(167, 250);
            this.l_devicePrevPassword.Name = "l_devicePrevPassword";
            this.l_devicePrevPassword.Size = new System.Drawing.Size(180, 12);
            this.l_devicePrevPassword.TabIndex = 15;
            this.l_devicePrevPassword.Text = "Device Previous Password:";
            this.l_devicePrevPassword.Visible = false;
            // 
            // b_Back
            // 
            this.b_Back.Location = new System.Drawing.Point(579, 373);
            this.b_Back.Name = "b_Back";
            this.b_Back.Size = new System.Drawing.Size(93, 35);
            this.b_Back.TabIndex = 17;
            this.b_Back.Text = "Back";
            this.b_Back.UseVisualStyleBackColor = true;
            this.b_Back.Click += new System.EventHandler(this.b_back_Click);
            // 
            // l_error
            // 
            this.l_error.AutoSize = true;
            this.l_error.BackColor = System.Drawing.Color.Coral;
            this.l_error.ForeColor = System.Drawing.Color.White;
            this.l_error.Location = new System.Drawing.Point(169, 309);
            this.l_error.Margin = new System.Windows.Forms.Padding(0);
            this.l_error.Name = "l_error";
            this.l_error.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.l_error.Size = new System.Drawing.Size(360, 58);
            this.l_error.TabIndex = 18;
            this.l_error.Text = "Device was alredy configurated with            \r\nanother password. \r\nPlease write" +
    " the previous password. \r\nIf you do not remember it, hard reset the device.";
            this.l_error.Visible = false;
            // 
            // l_title
            // 
            this.l_title.AutoSize = true;
            this.l_title.Font = new System.Drawing.Font("Andale Mono", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_title.Location = new System.Drawing.Point(261, 105);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(141, 32);
            this.l_title.TabIndex = 19;
            this.l_title.Text = "someONe";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(579, 303);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(93, 23);
            this.progressBar1.TabIndex = 20;
            this.progressBar1.Visible = false;
            // 
            // W3CreateAuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.l_title);
            this.Controls.Add(this.l_error);
            this.Controls.Add(this.b_Back);
            this.Controls.Add(this.tB_devicePrevPassword);
            this.Controls.Add(this.l_devicePrevPassword);
            this.Controls.Add(this.tB_devicePassword);
            this.Controls.Add(this.l_devicePassword);
            this.Controls.Add(this.tB_deviceName);
            this.Controls.Add(this.l_deviceName);
            this.Controls.Add(this.b_Next);
            this.Controls.Add(this.b_Cancel);
            this.Font = new System.Drawing.Font("Andale Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "W3CreateAuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "someONe - Authentication";
            this.Load += new System.EventHandler(this.W3CreateAuthForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_Next;
        private System.Windows.Forms.Button b_Cancel;
        private System.Windows.Forms.Label l_deviceName;
        private System.Windows.Forms.TextBox tB_deviceName;
        private System.Windows.Forms.TextBox tB_devicePassword;
        private System.Windows.Forms.Label l_devicePassword;
        private System.Windows.Forms.TextBox tB_devicePrevPassword;
        private System.Windows.Forms.Label l_devicePrevPassword;
        private System.Windows.Forms.Button b_Back;
        private System.Windows.Forms.Label l_error;
        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}