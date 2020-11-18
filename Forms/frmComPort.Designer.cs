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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGetAllDataFromXMFT = new System.Windows.Forms.Button();
            this.dGridXMFT = new System.Windows.Forms.DataGridView();
            this.btnSendDataToXMFT = new System.Windows.Forms.Button();
            this.btnCheckXMFT = new System.Windows.Forms.Button();
            this.Command = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReadValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isReadValue = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isWriteValue = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button7 = new System.Windows.Forms.Button();
            this.officeDataSourceObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridXMFT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSourceObjectBindingSource)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(210, 381);
            this.panel1.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(3, 273);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(201, 32);
            this.button4.TabIndex = 14;
            this.button4.Text = "checkITR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
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
            this.btnOpenPortDif.Size = new System.Drawing.Size(204, 32);
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
            this.btnTransmitCMD.Size = new System.Drawing.Size(201, 22);
            this.btnTransmitCMD.TabIndex = 5;
            this.btnTransmitCMD.Text = "Transmit CMD";
            this.btnTransmitCMD.UseVisualStyleBackColor = true;
            this.btnTransmitCMD.Click += new System.EventHandler(this.btnTransmitCMD_Click);
            // 
            // txtTransmit
            // 
            this.txtTransmit.Location = new System.Drawing.Point(3, 218);
            this.txtTransmit.Name = "txtTransmit";
            this.txtTransmit.Size = new System.Drawing.Size(201, 20);
            this.txtTransmit.TabIndex = 5;
            // 
            // btnTransmitDataComPort
            // 
            this.btnTransmitDataComPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransmitDataComPort.Location = new System.Drawing.Point(3, 111);
            this.btnTransmitDataComPort.Name = "btnTransmitDataComPort";
            this.btnTransmitDataComPort.Size = new System.Drawing.Size(204, 32);
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
            this.btnShowPorts.Size = new System.Drawing.Size(204, 32);
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
            "E7-20",
            "XMTF"});
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
            this.panel2.Location = new System.Drawing.Point(231, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 373);
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
            this.txtComLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComLog.Location = new System.Drawing.Point(14, 96);
            this.txtComLog.Multiline = true;
            this.txtComLog.Name = "txtComLog";
            this.txtComLog.Size = new System.Drawing.Size(288, 274);
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
            this.txtReadString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReadString.Location = new System.Drawing.Point(14, 70);
            this.txtReadString.Name = "txtReadString";
            this.txtReadString.Size = new System.Drawing.Size(288, 20);
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
            this.button1.Size = new System.Drawing.Size(305, 32);
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
            this.button2.Size = new System.Drawing.Size(305, 32);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.btnGetAllDataFromXMFT);
            this.panel3.Controls.Add(this.dGridXMFT);
            this.panel3.Controls.Add(this.btnSendDataToXMFT);
            this.panel3.Controls.Add(this.btnCheckXMFT);
            this.panel3.Location = new System.Drawing.Point(542, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(404, 449);
            this.panel3.TabIndex = 18;
            // 
            // btnGetAllDataFromXMFT
            // 
            this.btnGetAllDataFromXMFT.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.btnGetAllDataFromXMFT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetAllDataFromXMFT.Location = new System.Drawing.Point(140, 379);
            this.btnGetAllDataFromXMFT.Name = "btnGetAllDataFromXMFT";
            this.btnGetAllDataFromXMFT.Size = new System.Drawing.Size(131, 22);
            this.btnGetAllDataFromXMFT.TabIndex = 22;
            this.btnGetAllDataFromXMFT.Text = "Get All Data From XMFT";
            this.btnGetAllDataFromXMFT.UseVisualStyleBackColor = true;
            this.btnGetAllDataFromXMFT.Click += new System.EventHandler(this.btnGetAllDataFromXMFT_Click);
            // 
            // dGridXMFT
            // 
            this.dGridXMFT.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGridXMFT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGridXMFT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridXMFT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Command,
            this.SetValue,
            this.ReadValue,
            this.isReadValue,
            this.isWriteValue});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGridXMFT.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGridXMFT.Location = new System.Drawing.Point(6, 3);
            this.dGridXMFT.Name = "dGridXMFT";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGridXMFT.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dGridXMFT.Size = new System.Drawing.Size(398, 367);
            this.dGridXMFT.TabIndex = 20;
            // 
            // btnSendDataToXMFT
            // 
            this.btnSendDataToXMFT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendDataToXMFT.Location = new System.Drawing.Point(3, 407);
            this.btnSendDataToXMFT.Name = "btnSendDataToXMFT";
            this.btnSendDataToXMFT.Size = new System.Drawing.Size(131, 22);
            this.btnSendDataToXMFT.TabIndex = 19;
            this.btnSendDataToXMFT.Text = "SendDataToXMFT";
            this.btnSendDataToXMFT.UseVisualStyleBackColor = true;
            this.btnSendDataToXMFT.Click += new System.EventHandler(this.btnSendDataToXMFT_Click);
            // 
            // btnCheckXMFT
            // 
            this.btnCheckXMFT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckXMFT.Location = new System.Drawing.Point(3, 379);
            this.btnCheckXMFT.Name = "btnCheckXMFT";
            this.btnCheckXMFT.Size = new System.Drawing.Size(131, 22);
            this.btnCheckXMFT.TabIndex = 18;
            this.btnCheckXMFT.Text = "checkXMFT";
            this.btnCheckXMFT.UseVisualStyleBackColor = true;
            // 
            // Command
            // 
            this.Command.HeaderText = "Command";
            this.Command.Name = "Command";
            this.Command.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SetValue
            // 
            this.SetValue.HeaderText = "SetValue";
            this.SetValue.Name = "SetValue";
            // 
            // ReadValue
            // 
            this.ReadValue.HeaderText = "ReadValue";
            this.ReadValue.Name = "ReadValue";
            this.ReadValue.Width = 50;
            // 
            // isReadValue
            // 
            this.isReadValue.HeaderText = "isReadValue";
            this.isReadValue.Name = "isReadValue";
            this.isReadValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isReadValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isReadValue.Width = 70;
            // 
            // isWriteValue
            // 
            this.isWriteValue.HeaderText = "isWriteValue";
            this.isWriteValue.Name = "isWriteValue";
            this.isWriteValue.Width = 70;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(140, 407);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 23;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(221, 407);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 24;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(952, 118);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(368, 264);
            this.chart1.TabIndex = 19;
            this.chart1.Text = "chart1";
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(307, 391);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(90, 38);
            this.button7.TabIndex = 25;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // officeDataSourceObjectBindingSource
            // 
            this.officeDataSourceObjectBindingSource.DataSource = typeof(Microsoft.Office.Core.OfficeDataSourceObject);
            // 
            // frmComPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 490);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel3);
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
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridXMFT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSourceObjectBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource officeDataSourceObjectBindingSource;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dGridXMFT;
        private System.Windows.Forms.Button btnSendDataToXMFT;
        private System.Windows.Forms.Button btnCheckXMFT;
        private System.Windows.Forms.Button btnGetAllDataFromXMFT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Command;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReadValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReadValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isWriteValue;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button7;
    }
}