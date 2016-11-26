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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(W1DeviceSelectionForm));
            this.b_Cancel = new System.Windows.Forms.Button();
            this.b_Next = new System.Windows.Forms.Button();
            this.lB_deviceList = new System.Windows.Forms.ListBox();
            this.l_listBoxDescription = new System.Windows.Forms.Label();
            this.l_error = new System.Windows.Forms.Label();
            this.l_title = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // b_Cancel
            // 
            this.b_Cancel.Font = new System.Drawing.Font("Andale Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Cancel.Location = new System.Drawing.Point(581, 416);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(91, 33);
            this.b_Cancel.TabIndex = 0;
            this.b_Cancel.Text = "Cancel";
            this.b_Cancel.UseVisualStyleBackColor = true;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // b_Next
            // 
            this.b_Next.Font = new System.Drawing.Font("Andale Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Next.Location = new System.Drawing.Point(581, 375);
            this.b_Next.Name = "b_Next";
            this.b_Next.Size = new System.Drawing.Size(91, 35);
            this.b_Next.TabIndex = 1;
            this.b_Next.Text = "Next";
            this.b_Next.UseVisualStyleBackColor = true;
            this.b_Next.Click += new System.EventHandler(this.b_Next_Click);
            // 
            // lB_deviceList
            // 
            this.lB_deviceList.Font = new System.Drawing.Font("Andale Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lB_deviceList.FormattingEnabled = true;
            this.lB_deviceList.ItemHeight = 12;
            this.lB_deviceList.Location = new System.Drawing.Point(169, 208);
            this.lB_deviceList.Name = "lB_deviceList";
            this.lB_deviceList.Size = new System.Drawing.Size(318, 88);
            this.lB_deviceList.TabIndex = 2;
            // 
            // l_listBoxDescription
            // 
            this.l_listBoxDescription.AutoSize = true;
            this.l_listBoxDescription.Font = new System.Drawing.Font("Andale Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_listBoxDescription.Location = new System.Drawing.Point(167, 193);
            this.l_listBoxDescription.Name = "l_listBoxDescription";
            this.l_listBoxDescription.Size = new System.Drawing.Size(320, 12);
            this.l_listBoxDescription.TabIndex = 3;
            this.l_listBoxDescription.Text = "Select the device that you want to configure.";
            // 
            // l_error
            // 
            this.l_error.AutoSize = true;
            this.l_error.BackColor = System.Drawing.Color.Coral;
            this.l_error.Font = new System.Drawing.Font("Andale Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_error.ForeColor = System.Drawing.Color.White;
            this.l_error.Location = new System.Drawing.Point(167, 309);
            this.l_error.Margin = new System.Windows.Forms.Padding(0);
            this.l_error.Name = "l_error";
            this.l_error.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.l_error.Size = new System.Drawing.Size(192, 22);
            this.l_error.TabIndex = 5;
            this.l_error.Text = "You must select a device.";
            this.l_error.Visible = false;
            // 
            // l_title
            // 
            this.l_title.AutoSize = true;
            this.l_title.Font = new System.Drawing.Font("Andale Mono", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_title.Location = new System.Drawing.Point(261, 105);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(141, 32);
            this.l_title.TabIndex = 9;
            this.l_title.Text = "someONe";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(581, 346);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(91, 23);
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Visible = false;
            // 
            // W1DeviceSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.l_title);
            this.Controls.Add(this.l_error);
            this.Controls.Add(this.l_listBoxDescription);
            this.Controls.Add(this.lB_deviceList);
            this.Controls.Add(this.b_Next);
            this.Controls.Add(this.b_Cancel);
            this.Font = new System.Drawing.Font("Andale Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "W1DeviceSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "someONe - Device Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_Cancel;
        private System.Windows.Forms.Button b_Next;
        private System.Windows.Forms.ListBox lB_deviceList;
        private System.Windows.Forms.Label l_listBoxDescription;
        private System.Windows.Forms.Label l_error;
        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}