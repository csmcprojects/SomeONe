namespace SomeONe
{
    partial class W5FinalConfigurationForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.b_Config = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.l_deviceName = new System.Windows.Forms.Label();
            this.l_devicePassword = new System.Windows.Forms.Label();
            this.l_wifNetwork = new System.Windows.Forms.Label();
            this.l_wifiPassword = new System.Windows.Forms.Label();
            this.l_serverUrl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SomeONe.Properties.Resources.cooltext209842929666486;
            this.pictureBox1.Location = new System.Drawing.Point(12, 114);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 195);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // b_Cancel
            // 
            this.b_Cancel.Location = new System.Drawing.Point(597, 426);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(75, 23);
            this.b_Cancel.TabIndex = 21;
            this.b_Cancel.Text = "Cancel";
            this.b_Cancel.UseVisualStyleBackColor = true;
            // 
            // b_Config
            // 
            this.b_Config.Location = new System.Drawing.Point(516, 426);
            this.b_Config.Name = "b_Config";
            this.b_Config.Size = new System.Drawing.Size(75, 23);
            this.b_Config.TabIndex = 22;
            this.b_Config.Text = "Save";
            this.b_Config.UseVisualStyleBackColor = true;
            this.b_Config.Click += new System.EventHandler(this.b_Config_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Device Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Device Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Wifi Network:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Wifi Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Server URL:";
            // 
            // l_deviceName
            // 
            this.l_deviceName.AutoSize = true;
            this.l_deviceName.Location = new System.Drawing.Point(431, 114);
            this.l_deviceName.Name = "l_deviceName";
            this.l_deviceName.Size = new System.Drawing.Size(19, 13);
            this.l_deviceName.TabIndex = 28;
            this.l_deviceName.Text = "--o";
            // 
            // l_devicePassword
            // 
            this.l_devicePassword.AutoSize = true;
            this.l_devicePassword.Location = new System.Drawing.Point(431, 136);
            this.l_devicePassword.Name = "l_devicePassword";
            this.l_devicePassword.Size = new System.Drawing.Size(19, 13);
            this.l_devicePassword.TabIndex = 29;
            this.l_devicePassword.Text = "--o";
            // 
            // l_wifNetwork
            // 
            this.l_wifNetwork.AutoSize = true;
            this.l_wifNetwork.Location = new System.Drawing.Point(431, 161);
            this.l_wifNetwork.Name = "l_wifNetwork";
            this.l_wifNetwork.Size = new System.Drawing.Size(19, 13);
            this.l_wifNetwork.TabIndex = 30;
            this.l_wifNetwork.Text = "--o";
            // 
            // l_wifiPassword
            // 
            this.l_wifiPassword.AutoSize = true;
            this.l_wifiPassword.Location = new System.Drawing.Point(431, 187);
            this.l_wifiPassword.Name = "l_wifiPassword";
            this.l_wifiPassword.Size = new System.Drawing.Size(19, 13);
            this.l_wifiPassword.TabIndex = 31;
            this.l_wifiPassword.Text = "--o";
            // 
            // l_serverUrl
            // 
            this.l_serverUrl.AutoSize = true;
            this.l_serverUrl.Location = new System.Drawing.Point(431, 210);
            this.l_serverUrl.Name = "l_serverUrl";
            this.l_serverUrl.Size = new System.Drawing.Size(19, 13);
            this.l_serverUrl.TabIndex = 32;
            this.l_serverUrl.Text = "--o";
            // 
            // W5FinalConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.l_serverUrl);
            this.Controls.Add(this.l_wifiPassword);
            this.Controls.Add(this.l_wifNetwork);
            this.Controls.Add(this.l_devicePassword);
            this.Controls.Add(this.l_deviceName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_Config);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "W5FinalConfigurationForm";
            this.Text = "W5FinalConfigurationForm";
            this.Load += new System.EventHandler(this.W5FinalConfigurationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button b_Cancel;
        private System.Windows.Forms.Button b_Config;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label l_deviceName;
        private System.Windows.Forms.Label l_devicePassword;
        private System.Windows.Forms.Label l_wifNetwork;
        private System.Windows.Forms.Label l_wifiPassword;
        private System.Windows.Forms.Label l_serverUrl;
    }
}