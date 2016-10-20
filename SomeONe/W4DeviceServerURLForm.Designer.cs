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
            this.tB_url = new System.Windows.Forms.TextBox();
            this.l_username = new System.Windows.Forms.Label();
            this.B_Next = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.B_Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tB_url
            // 
            this.tB_url.Location = new System.Drawing.Point(336, 133);
            this.tB_url.Name = "tB_url";
            this.tB_url.Size = new System.Drawing.Size(253, 20);
            this.tB_url.TabIndex = 23;
            this.tB_url.Visible = false;
            // 
            // l_username
            // 
            this.l_username.AutoSize = true;
            this.l_username.Location = new System.Drawing.Point(333, 117);
            this.l_username.Name = "l_username";
            this.l_username.Size = new System.Drawing.Size(69, 13);
            this.l_username.TabIndex = 22;
            this.l_username.Text = "Server  URL:";
            this.l_username.Visible = false;
            // 
            // B_Next
            // 
            this.B_Next.Location = new System.Drawing.Point(516, 426);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(75, 23);
            this.B_Next.TabIndex = 16;
            this.B_Next.Text = "Next";
            this.B_Next.UseVisualStyleBackColor = true;
            this.B_Next.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new System.Drawing.Point(597, 426);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(75, 23);
            this.B_Cancel.TabIndex = 15;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SomeONe.Properties.Resources.cooltext209842929666486;
            this.pictureBox1.Location = new System.Drawing.Point(12, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 195);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // B_Back
            // 
            this.B_Back.Location = new System.Drawing.Point(435, 426);
            this.B_Back.Name = "B_Back";
            this.B_Back.Size = new System.Drawing.Size(75, 23);
            this.B_Back.TabIndex = 24;
            this.B_Back.Text = "Back";
            this.B_Back.UseVisualStyleBackColor = true;
            this.B_Back.Click += new System.EventHandler(this.B_Back_Click);
            // 
            // W4DeviceServerURLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.B_Back);
            this.Controls.Add(this.tB_url);
            this.Controls.Add(this.l_username);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.B_Next);
            this.Controls.Add(this.B_Cancel);
            this.Name = "W4DeviceServerURLForm";
            this.Text = "W4DeviceServerURLForm";
            this.Load += new System.EventHandler(this.W4DeviceServerURLForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tB_url;
        private System.Windows.Forms.Label l_username;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button B_Next;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Back;
    }
}