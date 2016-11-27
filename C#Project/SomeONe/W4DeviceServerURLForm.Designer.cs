namespace SomeONe
{
    partial class W4DeviceServerURLForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(W4DeviceServerURLForm));
            this.tB_url = new System.Windows.Forms.TextBox();
            this.l_username = new System.Windows.Forms.Label();
            this.B_Next = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Back = new System.Windows.Forms.Button();
            this.tB_AuthToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ServerHost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.l_title = new System.Windows.Forms.Label();
            this.l_error = new System.Windows.Forms.Label();
            this.b_GenerateToken = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tB_url
            // 
            this.tB_url.Location = new System.Drawing.Point(182, 251);
            this.tB_url.Name = "tB_url";
            this.tB_url.Size = new System.Drawing.Size(294, 20);
            this.tB_url.TabIndex = 23;
            this.tB_url.Text = "/someone/request.php";
            // 
            // l_username
            // 
            this.l_username.AutoSize = true;
            this.l_username.Location = new System.Drawing.Point(178, 236);
            this.l_username.Name = "l_username";
            this.l_username.Size = new System.Drawing.Size(89, 12);
            this.l_username.TabIndex = 22;
            this.l_username.Text = "Server Page:";
            // 
            // B_Next
            // 
            this.B_Next.Location = new System.Drawing.Point(579, 332);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(93, 35);
            this.B_Next.TabIndex = 16;
            this.B_Next.Text = "Next";
            this.B_Next.UseVisualStyleBackColor = true;
            this.B_Next.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new System.Drawing.Point(579, 414);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(93, 35);
            this.B_Cancel.TabIndex = 15;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // B_Back
            // 
            this.B_Back.Location = new System.Drawing.Point(579, 373);
            this.B_Back.Name = "B_Back";
            this.B_Back.Size = new System.Drawing.Size(93, 35);
            this.B_Back.TabIndex = 24;
            this.B_Back.Text = "Back";
            this.B_Back.UseVisualStyleBackColor = true;
            this.B_Back.Click += new System.EventHandler(this.B_Back_Click);
            // 
            // tB_AuthToken
            // 
            this.tB_AuthToken.Location = new System.Drawing.Point(182, 301);
            this.tB_AuthToken.Name = "tB_AuthToken";
            this.tB_AuthToken.Size = new System.Drawing.Size(294, 20);
            this.tB_AuthToken.TabIndex = 26;
            this.tB_AuthToken.Text = "l0kyOMiL8UZU2GIK";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "Authentication token:";
            // 
            // tb_ServerHost
            // 
            this.tb_ServerHost.Location = new System.Drawing.Point(182, 205);
            this.tb_ServerHost.Name = "tb_ServerHost";
            this.tb_ServerHost.Size = new System.Drawing.Size(294, 20);
            this.tb_ServerHost.TabIndex = 28;
            this.tb_ServerHost.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "Server  Host:";
            // 
            // l_title
            // 
            this.l_title.AutoSize = true;
            this.l_title.Font = new System.Drawing.Font("Andale Mono", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_title.Location = new System.Drawing.Point(261, 105);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(141, 32);
            this.l_title.TabIndex = 29;
            this.l_title.Text = "someONe";
            // 
            // l_error
            // 
            this.l_error.AutoSize = true;
            this.l_error.BackColor = System.Drawing.Color.Coral;
            this.l_error.Font = new System.Drawing.Font("Andale Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_error.ForeColor = System.Drawing.Color.White;
            this.l_error.Location = new System.Drawing.Point(180, 345);
            this.l_error.Margin = new System.Windows.Forms.Padding(0);
            this.l_error.Name = "l_error";
            this.l_error.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.l_error.Size = new System.Drawing.Size(52, 22);
            this.l_error.TabIndex = 30;
            this.l_error.Text = "Label";
            this.l_error.Visible = false;
            // 
            // b_GenerateToken
            // 
            this.b_GenerateToken.Location = new System.Drawing.Point(482, 301);
            this.b_GenerateToken.Name = "b_GenerateToken";
            this.b_GenerateToken.Size = new System.Drawing.Size(25, 20);
            this.b_GenerateToken.TabIndex = 31;
            this.b_GenerateToken.Text = "G";
            this.b_GenerateToken.UseVisualStyleBackColor = true;
            this.b_GenerateToken.Click += new System.EventHandler(this.b_GenerateToken_Click);
            // 
            // W4DeviceServerURLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.b_GenerateToken);
            this.Controls.Add(this.l_error);
            this.Controls.Add(this.l_title);
            this.Controls.Add(this.tb_ServerHost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tB_AuthToken);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_Back);
            this.Controls.Add(this.tB_url);
            this.Controls.Add(this.l_username);
            this.Controls.Add(this.B_Next);
            this.Controls.Add(this.B_Cancel);
            this.Font = new System.Drawing.Font("Andale Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "W4DeviceServerURLForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " someONe - Server Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tB_url;
        private System.Windows.Forms.Label l_username;
        private System.Windows.Forms.Button B_Next;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Back;
        private System.Windows.Forms.TextBox tB_AuthToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ServerHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.Label l_error;
        private System.Windows.Forms.Button b_GenerateToken;
    }
}