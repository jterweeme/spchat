namespace spclient
{
    partial class ConnectForm
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
            this.LabelServerAddress = new System.Windows.Forms.Label();
            this.TextBoxServerAddress = new System.Windows.Forms.TextBox();
            this.TextBoxServerPort = new System.Windows.Forms.TextBox();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.LabelPort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelServerAddress
            // 
            this.LabelServerAddress.AutoSize = true;
            this.LabelServerAddress.Location = new System.Drawing.Point(12, 22);
            this.LabelServerAddress.Name = "LabelServerAddress";
            this.LabelServerAddress.Size = new System.Drawing.Size(38, 13);
            this.LabelServerAddress.TabIndex = 0;
            this.LabelServerAddress.Text = "Server";
            // 
            // TextBoxServerAddress
            // 
            this.TextBoxServerAddress.Location = new System.Drawing.Point(92, 19);
            this.TextBoxServerAddress.Name = "TextBoxServerAddress";
            this.TextBoxServerAddress.Size = new System.Drawing.Size(100, 20);
            this.TextBoxServerAddress.TabIndex = 3;
            // 
            // TextBoxServerPort
            // 
            this.TextBoxServerPort.Location = new System.Drawing.Point(92, 50);
            this.TextBoxServerPort.Name = "TextBoxServerPort";
            this.TextBoxServerPort.Size = new System.Drawing.Size(100, 20);
            this.TextBoxServerPort.TabIndex = 4;
            this.TextBoxServerPort.Text = "1234";
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Location = new System.Drawing.Point(15, 84);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(75, 23);
            this.ButtonConnect.TabIndex = 6;
            this.ButtonConnect.Text = "Connect";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(117, 84);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 7;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // LabelPort
            // 
            this.LabelPort.AutoSize = true;
            this.LabelPort.Location = new System.Drawing.Point(12, 53);
            this.LabelPort.Name = "LabelPort";
            this.LabelPort.Size = new System.Drawing.Size(26, 13);
            this.LabelPort.TabIndex = 1;
            this.LabelPort.Text = "Port";
            // 
            // ConnectForm
            // 
            this.AcceptButton = this.ButtonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(213, 124);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonConnect);
            this.Controls.Add(this.TextBoxServerPort);
            this.Controls.Add(this.TextBoxServerAddress);
            this.Controls.Add(this.LabelPort);
            this.Controls.Add(this.LabelServerAddress);
            this.Name = "ConnectForm";
            this.Text = "Connect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelServerAddress;
        private System.Windows.Forms.TextBox TextBoxServerAddress;
        private System.Windows.Forms.TextBox TextBoxServerPort;
        private System.Windows.Forms.Button ButtonConnect;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label LabelPort;
    }
}