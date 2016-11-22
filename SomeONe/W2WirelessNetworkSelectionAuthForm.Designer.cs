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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.B_Next = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tB_password = new System.Windows.Forms.TextBox();
            this.tB_username = new System.Windows.Forms.TextBox();
            this.l_username = new System.Windows.Forms.Label();
            this.lB_device_list = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SomeONe.Properties.Resources.cooltext209842929666486;
            this.pictureBox1.Location = new System.Drawing.Point(12, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 195);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select a wifi network:";
            // 
            // B_Next
            // 
            this.B_Next.Location = new System.Drawing.Point(516, 426);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(75, 23);
            this.B_Next.TabIndex = 7;
            this.B_Next.Text = "Next";
            this.B_Next.UseVisualStyleBackColor = true;
            this.B_Next.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new System.Drawing.Point(597, 426);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(75, 23);
            this.B_Cancel.TabIndex = 6;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password";
            // 
            // tB_password
            // 
            this.tB_password.Location = new System.Drawing.Point(338, 315);
            this.tB_password.Name = "tB_password";
            this.tB_password.Size = new System.Drawing.Size(253, 20);
            this.tB_password.TabIndex = 12;
            this.tB_password.UseSystemPasswordChar = true;
            // 
            // tB_username
            // 
            this.tB_username.Location = new System.Drawing.Point(338, 276);
            this.tB_username.Name = "tB_username";
            this.tB_username.Size = new System.Drawing.Size(253, 20);
            this.tB_username.TabIndex = 14;
            this.tB_username.Visible = false;
            // 
            // l_username
            // 
            this.l_username.AutoSize = true;
            this.l_username.Location = new System.Drawing.Point(335, 260);
            this.l_username.Name = "l_username";
            this.l_username.Size = new System.Drawing.Size(55, 13);
            this.l_username.TabIndex = 13;
            this.l_username.Text = "Username";
            this.l_username.Visible = false;
            // 
            // lB_device_list
            // 
            this.lB_device_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lB_device_list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lB_device_list.HideSelection = false;
            this.lB_device_list.Location = new System.Drawing.Point(338, 107);
            this.lB_device_list.MultiSelect = false;
            this.lB_device_list.Name = "lB_device_list";
            this.lB_device_list.ShowGroups = false;
            this.lB_device_list.Size = new System.Drawing.Size(253, 150);
            this.lB_device_list.TabIndex = 15;
            this.lB_device_list.UseCompatibleStateImageBehavior = false;
            this.lB_device_list.View = System.Windows.Forms.View.Details;
            this.lB_device_list.SelectedIndexChanged += new System.EventHandler(this.lB_device_list_SelectedIndexChanged_1);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 230;
            // 
            // W2WirelessNetworkSelectionAuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.lB_device_list);
            this.Controls.Add(this.tB_username);
            this.Controls.Add(this.l_username);
            this.Controls.Add(this.tB_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_Next);
            this.Controls.Add(this.B_Cancel);
            this.Name = "W2WirelessNetworkSelectionAuthForm";
            this.Text = "WirelessNetworkSelectionAuthForm";
            this.Load += new System.EventHandler(this.W2WirelessNetworkSelectionAuthForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_Next;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tB_password;
        private System.Windows.Forms.TextBox tB_username;
        private System.Windows.Forms.Label l_username;
        private System.Windows.Forms.ListView lB_device_list;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}