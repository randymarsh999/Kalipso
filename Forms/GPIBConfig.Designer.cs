namespace Kalipso
{
    partial class frmGPIBConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.cbInterfaceType = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnCloseGPIB = new System.Windows.Forms.Button();
            this.ControllerAddressUD = new System.Windows.Forms.NumericUpDown();
            this.DeviceAddressUD = new System.Windows.Forms.NumericUpDown();
            this.txtLastIOStatus = new System.Windows.Forms.TextBox();
            this.txtElementsTransferred = new System.Windows.Forms.TextBox();
            this.btnReadGPIB = new System.Windows.Forms.Button();
            this.txtIpHost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIpPort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerAddressUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceAddressUD)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Location = new System.Drawing.Point(126, 208);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(107, 23);
            this.btnSendCommand.TabIndex = 0;
            this.btnSendCommand.Text = "Send command";
            this.btnSendCommand.UseVisualStyleBackColor = true;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(-1, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Controller name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(-1, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Command";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(-1, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Device address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(133, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Interface";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(129, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "IP address";
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(3, 121);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(107, 20);
            this.txtCommand.TabIndex = 18;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnswer.Location = new System.Drawing.Point(3, 323);
            this.txtAnswer.Multiline = true;
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(282, 176);
            this.txtAnswer.TabIndex = 22;
            this.txtAnswer.TextChanged += new System.EventHandler(this.txtAnswer_TextChanged);
            // 
            // cbInterfaceType
            // 
            this.cbInterfaceType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbInterfaceType.FormattingEnabled = true;
            this.cbInterfaceType.Items.AddRange(new object[] {
            "GPIB",
            "USB",
            "ETHERNET"});
            this.cbInterfaceType.Location = new System.Drawing.Point(133, 28);
            this.cbInterfaceType.Name = "cbInterfaceType";
            this.cbInterfaceType.Size = new System.Drawing.Size(107, 21);
            this.cbInterfaceType.TabIndex = 20;
            this.cbInterfaceType.SelectedIndexChanged += new System.EventHandler(this.cbInterfaceType_SelectedIndexChanged);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(3, 208);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(107, 23);
            this.btnFind.TabIndex = 23;
            this.btnFind.Text = "Find device";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnCloseGPIB
            // 
            this.btnCloseGPIB.Location = new System.Drawing.Point(3, 247);
            this.btnCloseGPIB.Name = "btnCloseGPIB";
            this.btnCloseGPIB.Size = new System.Drawing.Size(107, 23);
            this.btnCloseGPIB.TabIndex = 25;
            this.btnCloseGPIB.Text = "Close GPIB";
            this.btnCloseGPIB.UseVisualStyleBackColor = true;
            this.btnCloseGPIB.Click += new System.EventHandler(this.btnCloseGPIB_Click);
            // 
            // ControllerAddressUD
            // 
            this.ControllerAddressUD.Location = new System.Drawing.Point(3, 28);
            this.ControllerAddressUD.Name = "ControllerAddressUD";
            this.ControllerAddressUD.Size = new System.Drawing.Size(120, 20);
            this.ControllerAddressUD.TabIndex = 27;
            // 
            // DeviceAddressUD
            // 
            this.DeviceAddressUD.Location = new System.Drawing.Point(3, 75);
            this.DeviceAddressUD.Name = "DeviceAddressUD";
            this.DeviceAddressUD.Size = new System.Drawing.Size(120, 20);
            this.DeviceAddressUD.TabIndex = 28;
            // 
            // txtLastIOStatus
            // 
            this.txtLastIOStatus.Location = new System.Drawing.Point(133, 297);
            this.txtLastIOStatus.Name = "txtLastIOStatus";
            this.txtLastIOStatus.Size = new System.Drawing.Size(100, 20);
            this.txtLastIOStatus.TabIndex = 29;
            // 
            // txtElementsTransferred
            // 
            this.txtElementsTransferred.Location = new System.Drawing.Point(3, 297);
            this.txtElementsTransferred.Name = "txtElementsTransferred";
            this.txtElementsTransferred.Size = new System.Drawing.Size(107, 20);
            this.txtElementsTransferred.TabIndex = 30;
            // 
            // btnReadGPIB
            // 
            this.btnReadGPIB.Location = new System.Drawing.Point(126, 247);
            this.btnReadGPIB.Name = "btnReadGPIB";
            this.btnReadGPIB.Size = new System.Drawing.Size(107, 23);
            this.btnReadGPIB.TabIndex = 31;
            this.btnReadGPIB.Text = "Read GPIB";
            this.btnReadGPIB.UseVisualStyleBackColor = true;
            this.btnReadGPIB.Click += new System.EventHandler(this.btnReadGPIB_Click);
            // 
            // txtIpHost
            // 
            this.txtIpHost.Location = new System.Drawing.Point(133, 75);
            this.txtIpHost.Name = "txtIpHost";
            this.txtIpHost.Size = new System.Drawing.Size(107, 20);
            this.txtIpHost.TabIndex = 21;
            this.txtIpHost.Text = "192.168.3.188";
            this.txtIpHost.TextChanged += new System.EventHandler(this.txtIpHost_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(-1, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 21);
            this.label6.TabIndex = 32;
            this.label6.Text = "Elements transf.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(129, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 21);
            this.label7.TabIndex = 33;
            this.label7.Text = "Last IO status";
            // 
            // txtIpPort
            // 
            this.txtIpPort.Location = new System.Drawing.Point(133, 121);
            this.txtIpPort.Name = "txtIpPort";
            this.txtIpPort.Size = new System.Drawing.Size(107, 20);
            this.txtIpPort.TabIndex = 36;
            this.txtIpPort.Text = "5024";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(133, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 21);
            this.label8.TabIndex = 37;
            this.label8.Text = "Port";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(179, 150);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 38;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // frmGPIBConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 511);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtIpPort);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnReadGPIB);
            this.Controls.Add(this.txtElementsTransferred);
            this.Controls.Add(this.txtLastIOStatus);
            this.Controls.Add(this.DeviceAddressUD);
            this.Controls.Add(this.ControllerAddressUD);
            this.Controls.Add(this.btnCloseGPIB);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.txtIpHost);
            this.Controls.Add(this.cbInterfaceType);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendCommand);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGPIBConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPIB Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGPIBConfig_FormClosing);
            this.Load += new System.EventHandler(this.frmGPIBConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ControllerAddressUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceAddressUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.TextBox txtAnswer;
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmGPIBConfig.cbInterfaceType"
        public System.Windows.Forms.ComboBox cbInterfaceType;
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmGPIBConfig.cbInterfaceType"
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnCloseGPIB;
        private System.Windows.Forms.NumericUpDown ControllerAddressUD;
        private System.Windows.Forms.NumericUpDown DeviceAddressUD;
        private System.Windows.Forms.TextBox txtLastIOStatus;
        private System.Windows.Forms.TextBox txtElementsTransferred;
        private System.Windows.Forms.Button btnReadGPIB;
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmGPIBConfig.txtIpHost"
        public System.Windows.Forms.TextBox txtIpHost;
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmGPIBConfig.txtIpHost"
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmGPIBConfig.txtIpPort"
        public System.Windows.Forms.TextBox txtIpPort;
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmGPIBConfig.txtIpPort"
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
    }
}