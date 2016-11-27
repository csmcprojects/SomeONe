namespace SomeONe
{
    partial class W2WirelessNetworkSelectionAuthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(W2WirelessNetworkSelectionAuthForm));
            this.l_description = new System.Windows.Forms.Label();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.l_password = new System.Windows.Forms.Label();
            this.tB_password = new System.Windows.Forms.TextBox();
            this.lB_device_list = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.l_title = new System.Windows.Forms.Label();
            this.b_Back = new System.Windows.Forms.Button();
            this.l_error = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.b_Nextt = new System.Windows.Forms.Button();
            this.l_goodStatus = new System.Windows.Forms.Label();
            this.l_mehStatus = new System.Windows.Forms.Label();
            this.l_badStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // l_description
            // 
            this.l_description.AutoSize = true;
            this.l_description.Location = new System.Drawing.Point(182, 166);
            this.l_description.Name = "l_description";
            this.l_description.Size = new System.Drawing.Size(159, 12);
            this.l_description.TabIndex = 9;
            this.l_description.Text = "Select a wifi network:";
            // 
            // b_Cancel
            // 
            this.b_Cancel.Location = new System.Drawing.Point(578, 416);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(91, 33);
            this.b_Cancel.TabIndex = 6;
            this.b_Cancel.Text = "Cancel";
            this.b_Cancel.UseVisualStyleBackColor = true;
            this.b_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // l_password
            // 
            this.l_password.AutoSize = true;
            this.l_password.Location = new System.Drawing.Point(182, 334);
            this.l_password.Name = "l_password";
            this.l_password.Size = new System.Drawing.Size(68, 12);
            this.l_password.TabIndex = 11;
            this.l_password.Text = "Password:";
            // 
            // tB_password
            // 
            this.tB_password.Location = new System.Drawing.Point(184, 349);
            this.tB_password.Name = "tB_password";
            this.tB_password.Size = new System.Drawing.Size(294, 20);
            this.tB_password.TabIndex = 12;
            this.tB_password.Text = "5BM49GG7J76";
            this.tB_password.UseSystemPasswordChar = true;
            // 
            // lB_device_list
            // 
            this.lB_device_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lB_device_list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lB_device_list.HideSelection = false;
            this.lB_device_list.Location = new System.Drawing.Point(184, 181);
            this.lB_device_list.MultiSelect = false;
            this.lB_device_list.Name = "lB_device_list";
            this.lB_device_list.ShowGroups = false;
            this.lB_device_list.Size = new System.Drawing.Size(294, 139);
            this.lB_device_list.TabIndex = 15;
            this.lB_device_list.UseCompatibleStateImageBehavior = false;
            this.lB_device_list.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 230;
            // 
            // l_title
            // 
            this.l_title.AutoSize = true;
            this.l_title.Font = new System.Drawing.Font("Andale Mono", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_title.Location = new System.Drawing.Point(261, 105);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(141, 32);
            this.l_title.TabIndex = 16;
            this.l_title.Text = "someONe";
            // 
            // b_Back
            // 
            this.b_Back.Location = new System.Drawing.Point(578, 377);
            this.b_Back.Name = "b_Back";
            this.b_Back.Size = new System.Drawing.Size(91, 33);
            this.b_Back.TabIndex = 17;
            this.b_Back.Text = "Back";
            this.b_Back.UseVisualStyleBackColor = true;
            this.b_Back.Click += new System.EventHandler(this.b_Back_Click);
            // 
            // l_error
            // 
            this.l_error.AutoSize = true;
            this.l_error.BackColor = System.Drawing.Color.Coral;
            this.l_error.Font = new System.Drawing.Font("Andale Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_error.ForeColor = System.Drawing.Color.White;
            this.l_error.Location = new System.Drawing.Point(182, 388);
            this.l_error.Margin = new System.Windows.Forms.Padding(0);
            this.l_error.Name = "l_error";
            this.l_error.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.l_error.Size = new System.Drawing.Size(52, 22);
            this.l_error.TabIndex = 18;
            this.l_error.Text = "Label";
            this.l_error.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(578, 309);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(91, 23);
            this.progressBar1.TabIndex = 19;
            this.progressBar1.Visible = false;
            // 
            // b_Nextt
            // 
            this.b_Nextt.Location = new System.Drawing.Point(578, 338);
            this.b_Nextt.Name = "b_Nextt";
            this.b_Nextt.Size = new System.Drawing.Size(91, 33);
            this.b_Nextt.TabIndex = 20;
            this.b_Nextt.Text = "Next";
            this.b_Nextt.UseVisualStyleBackColor = true;
            this.b_Nextt.Click += new System.EventHandler(this.b_Nextt_Click);
            // 
            // l_goodStatus
            // 
            this.l_goodStatus.AutoSize = true;
            this.l_goodStatus.ForeColor = System.Drawing.Color.GreenYellow;
            this.l_goodStatus.Location = new System.Drawing.Point(12, 228);
            this.l_goodStatus.Name = "l_goodStatus";
            this.l_goodStatus.Size = new System.Drawing.Size(33, 12);
            this.l_goodStatus.TabIndex = 21;
            this.l_goodStatus.Text = "good";
            // 
            // l_mehStatus
            // 
            this.l_mehStatus.AutoSize = true;
            this.l_mehStatus.ForeColor = System.Drawing.Color.Coral;
            this.l_mehStatus.Location = new System.Drawing.Point(12, 255);
            this.l_mehStatus.Name = "l_mehStatus";
            this.l_mehStatus.Size = new System.Drawing.Size(26, 12);
            this.l_mehStatus.TabIndex = 22;
            this.l_mehStatus.Text = "meh";
            // 
            // l_badStatus
            // 
            this.l_badStatus.AutoSize = true;
            this.l_badStatus.BackColor = System.Drawing.Color.White;
            this.l_badStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.l_badStatus.Location = new System.Drawing.Point(12, 283);
            this.l_badStatus.Name = "l_badStatus";
            this.l_badStatus.Size = new System.Drawing.Size(26, 12);
            this.l_badStatus.TabIndex = 23;
            this.l_badStatus.Text = "bad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "Wifi signal strenght:";
            // 
            // W2WirelessNetworkSelectionAuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.l_badStatus);
            this.Controls.Add(this.l_mehStatus);
            this.Controls.Add(this.l_goodStatus);
            this.Controls.Add(this.b_Nextt);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.l_error);
            this.Controls.Add(this.b_Back);
            this.Controls.Add(this.l_title);
            this.Controls.Add(this.lB_device_list);
            this.Controls.Add(this.tB_password);
            this.Controls.Add(this.l_password);
            this.Controls.Add(this.l_description);
            this.Controls.Add(this.b_Cancel);
            this.Font = new System.Drawing.Font("Andale Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "W2WirelessNetworkSelectionAuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "someONe - Wifi Network Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label l_description;
        private System.Windows.Forms.Button b_Cancel;
        private System.Windows.Forms.Label l_password;
        private System.Windows.Forms.TextBox tB_password;
        private System.Windows.Forms.ListView lB_device_list;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.Button b_Back;
        private System.Windows.Forms.Label l_error;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button b_Nextt;
        private System.Windows.Forms.Label l_goodStatus;
        private System.Windows.Forms.Label l_mehStatus;
        private System.Windows.Forms.Label l_badStatus;
        private System.Windows.Forms.Label label1;
    }
}