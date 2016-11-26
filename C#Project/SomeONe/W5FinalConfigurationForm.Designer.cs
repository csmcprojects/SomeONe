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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(W5FinalConfigurationForm));
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
            this.l_serverHost = new System.Windows.Forms.Label();
            this.l_ServeUrl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.l_serverAuthKey = new System.Windows.Forms.Label();
            this.b_Back = new System.Windows.Forms.Button();
            this.l_title = new System.Windows.Forms.Label();
            this.l_error = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // b_Cancel
            // 
            this.b_Cancel.Location = new System.Drawing.Point(714, 420);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(91, 30);
            this.b_Cancel.TabIndex = 21;
            this.b_Cancel.Text = "Cancel";
            this.b_Cancel.UseVisualStyleBackColor = true;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // b_Config
            // 
            this.b_Config.Location = new System.Drawing.Point(714, 348);
            this.b_Config.Name = "b_Config";
            this.b_Config.Size = new System.Drawing.Size(91, 30);
            this.b_Config.TabIndex = 22;
            this.b_Config.Text = "Save";
            this.b_Config.UseVisualStyleBackColor = true;
            this.b_Config.Click += new System.EventHandler(this.b_Config_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "Device Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "Device Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "Wifi Network:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(316, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "Wifi Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(316, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "Server Page:";
            // 
            // l_deviceName
            // 
            this.l_deviceName.AutoSize = true;
            this.l_deviceName.Location = new System.Drawing.Point(436, 175);
            this.l_deviceName.Name = "l_deviceName";
            this.l_deviceName.Size = new System.Drawing.Size(26, 12);
            this.l_deviceName.TabIndex = 28;
            this.l_deviceName.Text = "--o";
            // 
            // l_devicePassword
            // 
            this.l_devicePassword.AutoSize = true;
            this.l_devicePassword.Location = new System.Drawing.Point(436, 196);
            this.l_devicePassword.Name = "l_devicePassword";
            this.l_devicePassword.Size = new System.Drawing.Size(26, 12);
            this.l_devicePassword.TabIndex = 29;
            this.l_devicePassword.Text = "--o";
            // 
            // l_wifNetwork
            // 
            this.l_wifNetwork.AutoSize = true;
            this.l_wifNetwork.Location = new System.Drawing.Point(436, 219);
            this.l_wifNetwork.Name = "l_wifNetwork";
            this.l_wifNetwork.Size = new System.Drawing.Size(26, 12);
            this.l_wifNetwork.TabIndex = 30;
            this.l_wifNetwork.Text = "--o";
            // 
            // l_wifiPassword
            // 
            this.l_wifiPassword.AutoSize = true;
            this.l_wifiPassword.Location = new System.Drawing.Point(436, 243);
            this.l_wifiPassword.Name = "l_wifiPassword";
            this.l_wifiPassword.Size = new System.Drawing.Size(26, 12);
            this.l_wifiPassword.TabIndex = 31;
            this.l_wifiPassword.Text = "--o";
            // 
            // l_serverHost
            // 
            this.l_serverHost.AutoSize = true;
            this.l_serverHost.Location = new System.Drawing.Point(436, 264);
            this.l_serverHost.Name = "l_serverHost";
            this.l_serverHost.Size = new System.Drawing.Size(26, 12);
            this.l_serverHost.TabIndex = 32;
            this.l_serverHost.Text = "--o";
            // 
            // l_ServeUrl
            // 
            this.l_ServeUrl.AutoSize = true;
            this.l_ServeUrl.Location = new System.Drawing.Point(436, 285);
            this.l_ServeUrl.Name = "l_ServeUrl";
            this.l_ServeUrl.Size = new System.Drawing.Size(26, 12);
            this.l_ServeUrl.TabIndex = 34;
            this.l_ServeUrl.Text = "--o";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(316, 306);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "Server Auth Key:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(316, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 35;
            this.label6.Text = "Server Host:";
            // 
            // l_serverAuthKey
            // 
            this.l_serverAuthKey.AutoSize = true;
            this.l_serverAuthKey.Location = new System.Drawing.Point(436, 306);
            this.l_serverAuthKey.Name = "l_serverAuthKey";
            this.l_serverAuthKey.Size = new System.Drawing.Size(26, 12);
            this.l_serverAuthKey.TabIndex = 36;
            this.l_serverAuthKey.Text = "--o";
            // 
            // b_Back
            // 
            this.b_Back.Font = new System.Drawing.Font("Andale Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Back.Location = new System.Drawing.Point(714, 384);
            this.b_Back.Name = "b_Back";
            this.b_Back.Size = new System.Drawing.Size(91, 30);
            this.b_Back.TabIndex = 37;
            this.b_Back.Text = "Back";
            this.b_Back.UseVisualStyleBackColor = true;
            this.b_Back.Click += new System.EventHandler(this.b_Back_Click);
            // 
            // l_title
            // 
            this.l_title.AutoSize = true;
            this.l_title.Font = new System.Drawing.Font("Andale Mono", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_title.Location = new System.Drawing.Point(321, 104);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(141, 32);
            this.l_title.TabIndex = 38;
            this.l_title.Text = "someONe";
            // 
            // l_error
            // 
            this.l_error.AutoSize = true;
            this.l_error.BackColor = System.Drawing.Color.Coral;
            this.l_error.Font = new System.Drawing.Font("Andale Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_error.ForeColor = System.Drawing.Color.White;
            this.l_error.Location = new System.Drawing.Point(316, 348);
            this.l_error.Margin = new System.Windows.Forms.Padding(0);
            this.l_error.Name = "l_error";
            this.l_error.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.l_error.Size = new System.Drawing.Size(52, 22);
            this.l_error.TabIndex = 39;
            this.l_error.Text = "Label";
            this.l_error.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(714, 319);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(91, 23);
            this.progressBar1.TabIndex = 40;
            this.progressBar1.Visible = false;
            // 
            // W5FinalConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 462);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.l_error);
            this.Controls.Add(this.l_title);
            this.Controls.Add(this.b_Back);
            this.Controls.Add(this.l_serverAuthKey);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.l_ServeUrl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.l_serverHost);
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
            this.Font = new System.Drawing.Font("Andale Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "W5FinalConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "W5FinalConfigurationForm";
            this.Load += new System.EventHandler(this.W5FinalConfigurationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Label l_serverHost;
        private System.Windows.Forms.Label l_ServeUrl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label l_serverAuthKey;
        private System.Windows.Forms.Button b_Back;
        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.Label l_error;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}