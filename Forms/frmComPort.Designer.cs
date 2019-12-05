using System.IO.Ports;

namespace Kalipso
{
    partial class frmComPort
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.btnClosePorts = new System.Windows.Forms.Button();
            this.btnOpenPortDif = new System.Windows.Forms.Button();
            this.btnTransmitCMD = new System.Windows.Forms.Button();
            this.txtTransmit = new System.Windows.Forms.TextBox();
            this.btnTransmitDataComPort = new System.Windows.Forms.Button();
            this.btnShowPorts = new System.Windows.Forms.Button();
            this.cmbComPortList = new System.Windows.Forms.ComboBox();
            this.tComPort = new System.Windows.Forms.Timer(this.components);
            this.cbComDevice = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.txtComLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReadString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tComPortVarta = new System.Windows.Forms.Timer(this.components);
            this.timerArduinoIn = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btnClosePorts);
            this.panel1.Controls.Add(this.btnOpenPortDif);
            this.panel1.Controls.Add(this.btnTransmitCMD);
            this.panel1.Controls.Add(this.txtTransmit);
            this.panel1.Controls.Add(this.btnTransmitDataComPort);
            this.panel1.Controls.Add(this.btnShowPorts);
            this.panel1.Location = new System.Drawing.Point(3, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 324);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(75, 174);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // btnClosePorts
            // 
            this.btnClosePorts.Location = new System.Drawing.Point(3, 74);
            this.btnClosePorts.Name = "btnClosePorts";
            this.btnClosePorts.Size = new System.Drawing.Size(213, 32);
            this.btnClosePorts.TabIndex = 7;
            this.btnClosePorts.Text = "Close ComPort";
            this.btnClosePorts.UseVisualStyleBackColor = true;
            this.btnClosePorts.Click += new System.EventHandler(this.btnClosePorts_Click);
            // 
            // btnOpenPortDif
            // 
            this.btnOpenPortDif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenPortDif.Location = new System.Drawing.Point(3, 38);
            this.btnOpenPortDif.Name = "btnOpenPortDif";
            this.btnOpenPortDif.Size = new System.Drawing.Size(213, 32);
            this.btnOpenPortDif.TabIndex = 6;
            this.btnOpenPortDif.Text = "Open ComPort";
            this.btnOpenPortDif.UseVisualStyleBackColor = true;
            this.btnOpenPortDif.Click += new System.EventHandler(this.btnOpenPortDif_Click);
            // 
            // btnTransmitCMD
            // 
            this.btnTransmitCMD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransmitCMD.Location = new System.Drawing.Point(3, 245);
            this.btnTransmitCMD.Name = "btnTransmitCMD";
            this.btnTransmitCMD.Size = new System.Drawing.Size(213, 22);
            this.btnTransmitCMD.TabIndex = 5;
            this.btnTransmitCMD.Text = "Transmit CMD";
            this.btnTransmitCMD.UseVisualStyleBackColor = true;
            this.btnTransmitCMD.Click += new System.EventHandler(this.btnTransmitCMD_Click);
            // 
            // txtTransmit
            // 
            this.txtTransmit.Location = new System.Drawing.Point(3, 218);
            this.txtTransmit.Name = "txtTransmit";
            this.txtTransmit.Size = new System.Drawing.Size(213, 20);
            this.txtTransmit.TabIndex = 5;
            // 
            // btnTransmitDataComPort
            // 
            this.btnTransmitDataComPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransmitDataComPort.Location = new System.Drawing.Point(3, 111);
            this.btnTransmitDataComPort.Name = "btnTransmitDataComPort";
            this.btnTransmitDataComPort.Size = new System.Drawing.Size(213, 32);
            this.btnTransmitDataComPort.TabIndex = 4;
            this.btnTransmitDataComPort.Text = "Transmit TERMO";
            this.btnTransmitDataComPort.UseVisualStyleBackColor = true;
            this.btnTransmitDataComPort.Click += new System.EventHandler(this.btnTransmitDataComPort_Click);
            // 
            // btnShowPorts
            // 
            this.btnShowPorts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowPorts.Location = new System.Drawing.Point(3, 3);
            this.btnShowPorts.Name = "btnShowPorts";
            this.btnShowPorts.Size = new System.Drawing.Size(213, 32);
            this.btnShowPorts.TabIndex = 1;
            this.btnShowPorts.Text = "Show all Ports";
            this.btnShowPorts.UseVisualStyleBackColor = true;
            this.btnShowPorts.Click += new System.EventHandler(this.btnShowPorts_Click);
            // 
            // cmbComPortList
            // 
            this.cmbComPortList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbComPortList.FormattingEnabled = true;
            this.cmbComPortList.Location = new System.Drawing.Point(3, 12);
            this.cmbComPortList.Name = "cmbComPortList";
            this.cmbComPortList.Size = new System.Drawing.Size(219, 21);
            this.cmbComPortList.TabIndex = 0;
            // 
            // tComPort
            // 
            this.tComPort.Interval = 1000;
            this.tComPort.Tick += new System.EventHandler(this.tComPort_Tick);
            // 
            // cbComDevice
            // 
            this.cbComDevice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbComDevice.FormattingEnabled = true;
            this.cbComDevice.Items.AddRange(new object[] {
            "Varta703I",
            "LakeShore",
            "ITR2523",
            "ArduinoUno",
            "VoltageMeter HY-AV51-T",
            "E7-20"});
            this.cbComDevice.Location = new System.Drawing.Point(3, 39);
            this.cbComDevice.Name = "cbComDevice";
            this.cbComDevice.Size = new System.Drawing.Size(219, 21);
            this.cbComDevice.TabIndex = 2;
            this.cbComDevice.SelectedIndexChanged += new System.EventHandler(this.cbTermoControllers_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbBaudRate);
            this.panel2.Controls.Add(this.txtComLog);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtReadString);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(231, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(687, 331);
            this.panel2.TabIndex = 3;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "75",
            "110",
            "134",
            "150",
            "300",
            "600",
            "1200",
            "1800",
            "2400",
            "4800",
            "7200",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "128000",
            "115200"});
            this.cmbBaudRate.Location = new System.Drawing.Point(14, 25);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(106, 21);
            this.cmbBaudRate.TabIndex = 12;
            this.cmbBaudRate.Text = "9600";
            // 
            // txtComLog
            // 
            this.txtComLog.Location = new System.Drawing.Point(14, 96);
            this.txtComLog.Multiline = true;
            this.txtComLog.Name = "txtComLog";
            this.txtComLog.Size = new System.Drawing.Size(670, 224);
            this.txtComLog.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Out Com port";
            // 
            // txtReadString
            // 
            this.txtReadString.Location = new System.Drawing.Point(14, 70);
            this.txtReadString.Name = "txtReadString";
            this.txtReadString.Size = new System.Drawing.Size(670, 20);
            this.txtReadString.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Baud Rate";
            // 
            // tComPortVarta
            // 
            this.tComPortVarta.Interval = 1000;
            this.tComPortVarta.Tick += new System.EventHandler(this.tComPortVarta_Tick);
            // 
            // timerArduinoIn
            // 
            this.timerArduinoIn.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(231, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(688, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "Read Data from TERMO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(231, 429);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(688, 32);
            this.button2.TabIndex = 9;
            this.button2.Text = "Read Data from TERMO";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(3, 289);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(213, 32);
            this.button4.TabIndex = 14;
            this.button4.Text = "checkITR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // frmComPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 483);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cbComDevice);
            this.Controls.Add(this.cmbComPortList);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmComPort";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Com Port options";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmComPort_FormClosed);
            this.Load += new System.EventHandler(this.frmComPort_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnShowPorts;
        private System.Windows.Forms.Button btnTransmitDataComPort;
        private System.Windows.Forms.ComboBox cmbComPortList;
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmComPort.txtTransmit"
        public System.Windows.Forms.TextBox txtTransmit;
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmComPort.txtTransmit"
        private System.Windows.Forms.Timer tComPort;
        private System.Windows.Forms.ComboBox cbComDevice;
        private System.Windows.Forms.Button btnOpenPortDif;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReadString;
        private System.Windows.Forms.TextBox txtComLog;
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmComPort.btnTransmitCMD"
        public System.Windows.Forms.Button btnTransmitCMD;
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmComPort.btnTransmitCMD"
        private System.Windows.Forms.Timer tComPortVarta;
        private System.Windows.Forms.Button btnClosePorts;
        private System.Windows.Forms.Timer timerArduinoIn;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button4;
    }
}