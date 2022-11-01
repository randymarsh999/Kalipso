﻿namespace Kalipso
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class frmMeasTempOpt
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.txtRoExp = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.cmbSolidState = new System.Windows.Forms.ComboBox();
            this.chTest = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtTempSint = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtComposition = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSampleNumber = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiameter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.Direct = new System.Windows.Forms.Label();
            this.cDirect = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbTempMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTempStep = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCycleCount = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTempEnd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTempStart = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNewCycleTemp = new System.Windows.Forms.TextBox();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.dGridMeters = new System.Windows.Forms.DataGridView();
            this.dGridMeters_NN = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MeterActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dGridMeters_Meters = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dGridMeterUD = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dGridMeters_Interface = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dGridMeters_TermoContr = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dGridMeter_ContollerInterface = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label33 = new System.Windows.Forms.Label();
            this.cbExportDBMeasTemp = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label51 = new System.Windows.Forms.Label();
            this.cbTermocontrollerDevModel = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbGPIBDevModel = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabControl5 = new System.Windows.Forms.TabControl();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.tTempList = new System.Windows.Forms.TextBox();
            this.DGTempData = new System.Windows.Forms.DataGridView();
            this.Temp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.dGridVolt = new System.Windows.Forms.DataGridView();
            this.colNN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVolt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFreq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.dGridFreqMeas = new System.Windows.Forms.DataGridView();
            this.DGridFreqMeas_NN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGridFreqMeas_Freq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.tFreqList = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddFreqUbias = new System.Windows.Forms.Button();
            this.cbClear = new System.Windows.Forms.CheckBox();
            this.cbDefaultFreq = new System.Windows.Forms.CheckBox();
            this.cbAllFreq = new System.Windows.Forms.CheckBox();
            this.cCUCycle = new System.Windows.Forms.ComboBox();
            this.btnAddTemp = new System.Windows.Forms.Button();
            this.btnAddFreq = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txtStepFreq = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtEndFreq = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtStartFreq = new System.Windows.Forms.TextBox();
            this.Coefficient = new System.Windows.Forms.Label();
            this.txtCoefficient = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtTimerReversive = new System.Windows.Forms.TextBox();
            this.btnTimer = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.txtPeriodU = new System.Windows.Forms.TextBox();
            this.btnAddUList = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.txtTimeStartU = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtPointCountU = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtUmax = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.cbGraphOptions = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtUmin = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtUcur = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtCBF = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtRHO = new System.Windows.Forms.TextBox();
            this.chListFreq = new System.Windows.Forms.CheckedListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cFreqMode = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cWorkMode = new System.Windows.Forms.ComboBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label37 = new System.Windows.Forms.Label();
            this.txtApproxC = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtApproxB = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtApproxA = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label41 = new System.Windows.Forms.Label();
            this.txtApproxCTE_B_2000 = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.txtApproxCTE_A_2000 = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtApproxCTE_B_200 = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtApproxCTE_A_200 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.txtApproxCTE_B_20 = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txtApproxCTE_A_20 = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label49 = new System.Windows.Forms.Label();
            this.txtApproxU_d33_B = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.txtApproxU_d33_A = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtApproxD33_B_2000 = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.txtApproxD33_A_2000 = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtApproxD33_B_200 = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.txtApproxD33_A_200 = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtApproxD33_B_20 = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.txtApproxD33_A_20 = new System.Windows.Forms.TextBox();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.tabControl6 = new System.Windows.Forms.TabControl();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRequsetDB = new System.Windows.Forms.TextBox();
            this.btnSentDBRequest = new System.Windows.Forms.Button();
            this.btnSetPass = new System.Windows.Forms.Button();
            this.btnConnectDB = new System.Windows.Forms.Button();
            this.label52 = new System.Windows.Forms.Label();
            this.ePort = new System.Windows.Forms.TextBox();
            this.btnSetPort = new System.Windows.Forms.Button();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.eDB = new System.Windows.Forms.TextBox();
            this.ePass = new System.Windows.Forms.TextBox();
            this.eLogin = new System.Windows.Forms.TextBox();
            this.eServer = new System.Windows.Forms.TextBox();
            this.btnSetDB = new System.Windows.Forms.Button();
            this.btnSetLogin = new System.Windows.Forms.Button();
            this.btnSetSever = new System.Windows.Forms.Button();
            this.tabPage16 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilevoltageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFiletimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileexcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opnFileVoltage = new System.Windows.Forms.OpenFileDialog();
            this.opnFileTimer = new System.Windows.Forms.OpenFileDialog();
            this.opnFileExcel = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridMeters)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGTempData)).BeginInit();
            this.tabPage12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridVolt)).BeginInit();
            this.tabPage13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridFreqMeas)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.tabControl6.SuspendLayout();
            this.tabPage15.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage14);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1172, 608);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1164, 582);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sample value";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage3);
            this.tabControl4.Controls.Add(this.tabPage9);
            this.tabControl4.Controls.Add(this.tabPage10);
            this.tabControl4.Location = new System.Drawing.Point(6, 6);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(613, 314);
            this.tabControl4.TabIndex = 38;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtComments);
            this.tabPage3.Controls.Add(this.label59);
            this.tabPage3.Controls.Add(this.label58);
            this.tabPage3.Controls.Add(this.txtRoExp);
            this.tabPage3.Controls.Add(this.label57);
            this.tabPage3.Controls.Add(this.cmbSolidState);
            this.tabPage3.Controls.Add(this.chTest);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.txtTempSint);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.txtComposition);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.txtSampleNumber);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.cmbOperator);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.txtDiameter);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.txtHeight);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(605, 288);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Sample Opt.";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Location = new System.Drawing.Point(239, 34);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(346, 214);
            this.txtComments.TabIndex = 47;
            this.txtComments.TextChanged += new System.EventHandler(this.txtComments_TextChanged);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label59.Location = new System.Drawing.Point(235, 8);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(92, 23);
            this.label59.TabIndex = 46;
            this.label59.Text = "Comments";
            this.label59.Click += new System.EventHandler(this.label59_Click);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label58.Location = new System.Drawing.Point(6, 190);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(68, 23);
            this.label58.TabIndex = 44;
            this.label58.Text = "Ro_exp";
            // 
            // txtRoExp
            // 
            this.txtRoExp.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtRoExp.Location = new System.Drawing.Point(6, 216);
            this.txtRoExp.Name = "txtRoExp";
            this.txtRoExp.Size = new System.Drawing.Size(100, 29);
            this.txtRoExp.TabIndex = 43;
            this.txtRoExp.Text = "4.45";
            this.txtRoExp.TextChanged += new System.EventHandler(this.txtRoExp_TextChanged);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label57.Location = new System.Drawing.Point(112, 175);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(89, 23);
            this.label57.TabIndex = 42;
            this.label57.Text = "Solid state";
            // 
            // cmbSolidState
            // 
            this.cmbSolidState.FormattingEnabled = true;
            this.cmbSolidState.Items.AddRange(new object[] {
            "polycrystal",
            "single crystal",
            "thin film"});
            this.cmbSolidState.Location = new System.Drawing.Point(112, 204);
            this.cmbSolidState.Name = "cmbSolidState";
            this.cmbSolidState.Size = new System.Drawing.Size(100, 21);
            this.cmbSolidState.TabIndex = 41;
            this.cmbSolidState.Text = "polycrystal";
            this.cmbSolidState.SelectedIndexChanged += new System.EventHandler(this.cmbSolidState_SelectedIndexChanged);
            // 
            // chTest
            // 
            this.chTest.AutoSize = true;
            this.chTest.Location = new System.Drawing.Point(112, 231);
            this.chTest.Name = "chTest";
            this.chTest.Size = new System.Drawing.Size(43, 17);
            this.chTest.TabIndex = 40;
            this.chTest.Text = "test";
            this.chTest.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.Location = new System.Drawing.Point(112, 67);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(71, 23);
            this.label22.TabIndex = 39;
            this.label22.Text = "Tsint., K";
            // 
            // txtTempSint
            // 
            this.txtTempSint.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTempSint.Location = new System.Drawing.Point(112, 93);
            this.txtTempSint.Name = "txtTempSint";
            this.txtTempSint.Size = new System.Drawing.Size(100, 29);
            this.txtTempSint.TabIndex = 38;
            this.txtTempSint.Text = "1470";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(112, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 23);
            this.label7.TabIndex = 37;
            this.label7.Text = "Composition";
            // 
            // txtComposition
            // 
            this.txtComposition.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtComposition.Location = new System.Drawing.Point(112, 35);
            this.txtComposition.Name = "txtComposition";
            this.txtComposition.Size = new System.Drawing.Size(100, 29);
            this.txtComposition.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(6, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 23);
            this.label8.TabIndex = 35;
            this.label8.Text = "№ of sample";
            // 
            // txtSampleNumber
            // 
            this.txtSampleNumber.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSampleNumber.Location = new System.Drawing.Point(6, 151);
            this.txtSampleNumber.Name = "txtSampleNumber";
            this.txtSampleNumber.Size = new System.Drawing.Size(100, 29);
            this.txtSampleNumber.TabIndex = 34;
            this.txtSampleNumber.Text = "1";
            this.txtSampleNumber.TextChanged += new System.EventHandler(this.txtSampleNumber_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(112, 125);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 23);
            this.label15.TabIndex = 33;
            this.label15.Text = "Operator";
            // 
            // cmbOperator
            // 
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Items.AddRange(new object[] {
            "Andryushin K.P.",
            "Andryushina I.N.",
            "Talanov M.V.",
            "Pavelko A.A.",
            "Pavlenko A.V.",
            "Boldyrev N.V.",
            "Glazunova E.V.",
            "Sadykov H.A."});
            this.cmbOperator.Location = new System.Drawing.Point(112, 151);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(100, 21);
            this.cmbOperator.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Diametr";
            // 
            // txtDiameter
            // 
            this.txtDiameter.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDiameter.Location = new System.Drawing.Point(6, 93);
            this.txtDiameter.Name = "txtDiameter";
            this.txtDiameter.Size = new System.Drawing.Size(100, 29);
            this.txtDiameter.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Height";
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtHeight.Location = new System.Drawing.Point(6, 35);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 29);
            this.txtHeight.TabIndex = 6;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.Direct);
            this.tabPage9.Controls.Add(this.cDirect);
            this.tabPage9.Controls.Add(this.label21);
            this.tabPage9.Controls.Add(this.cbTempMode);
            this.tabPage9.Controls.Add(this.label4);
            this.tabPage9.Controls.Add(this.txtTempStep);
            this.tabPage9.Controls.Add(this.label5);
            this.tabPage9.Controls.Add(this.txtCycleCount);
            this.tabPage9.Controls.Add(this.label20);
            this.tabPage9.Controls.Add(this.txtTempEnd);
            this.tabPage9.Controls.Add(this.label2);
            this.tabPage9.Controls.Add(this.txtTempStart);
            this.tabPage9.Controls.Add(this.label6);
            this.tabPage9.Controls.Add(this.txtNewCycleTemp);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(605, 288);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "Temp.";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // Direct
            // 
            this.Direct.AutoSize = true;
            this.Direct.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Direct.Location = new System.Drawing.Point(6, 194);
            this.Direct.Name = "Direct";
            this.Direct.Size = new System.Drawing.Size(54, 23);
            this.Direct.TabIndex = 39;
            this.Direct.Text = "Direct";
            // 
            // cDirect
            // 
            this.cDirect.FormattingEnabled = true;
            this.cDirect.Items.AddRange(new object[] {
            "Heat",
            "Cool",
            "Positive",
            "Negative"});
            this.cDirect.Location = new System.Drawing.Point(3, 220);
            this.cDirect.Name = "cDirect";
            this.cDirect.Size = new System.Drawing.Size(121, 21);
            this.cDirect.TabIndex = 38;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(120, 133);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(104, 23);
            this.label21.TabIndex = 37;
            this.label21.Text = "Temp. mode";
            this.label21.Visible = false;
            // 
            // cbTempMode
            // 
            this.cbTempMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.cbTempMode.FormattingEnabled = true;
            this.cbTempMode.Items.AddRange(new object[] {
            "Step",
            "Ramp",
            "Ramp_reversive"});
            this.cbTempMode.Location = new System.Drawing.Point(120, 161);
            this.cbTempMode.Name = "cbTempMode";
            this.cbTempMode.Size = new System.Drawing.Size(100, 30);
            this.cbTempMode.TabIndex = 36;
            this.cbTempMode.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 23);
            this.label4.TabIndex = 35;
            this.label4.Text = "Step";
            // 
            // txtTempStep
            // 
            this.txtTempStep.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTempStep.Location = new System.Drawing.Point(6, 162);
            this.txtTempStep.Name = "txtTempStep";
            this.txtTempStep.Size = new System.Drawing.Size(100, 29);
            this.txtTempStep.TabIndex = 34;
            this.txtTempStep.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(116, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 23);
            this.label5.TabIndex = 33;
            this.label5.Text = "Cycle col.";
            // 
            // txtCycleCount
            // 
            this.txtCycleCount.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCycleCount.Location = new System.Drawing.Point(120, 93);
            this.txtCycleCount.Name = "txtCycleCount";
            this.txtCycleCount.Size = new System.Drawing.Size(100, 29);
            this.txtCycleCount.TabIndex = 32;
            this.txtCycleCount.Text = "40";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(2, 67);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 23);
            this.label20.TabIndex = 31;
            this.label20.Text = "Temp. End";
            // 
            // txtTempEnd
            // 
            this.txtTempEnd.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTempEnd.Location = new System.Drawing.Point(6, 96);
            this.txtTempEnd.Name = "txtTempEnd";
            this.txtTempEnd.Size = new System.Drawing.Size(100, 29);
            this.txtTempEnd.TabIndex = 30;
            this.txtTempEnd.Text = "723";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 29;
            this.label2.Text = "Temp. Start";
            // 
            // txtTempStart
            // 
            this.txtTempStart.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTempStart.Location = new System.Drawing.Point(6, 29);
            this.txtTempStart.Name = "txtTempStart";
            this.txtTempStart.Size = new System.Drawing.Size(100, 29);
            this.txtTempStart.TabIndex = 28;
            this.txtTempStart.Text = "300";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(120, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "New cycle temp.";
            // 
            // txtNewCycleTemp
            // 
            this.txtNewCycleTemp.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNewCycleTemp.Location = new System.Drawing.Point(120, 29);
            this.txtNewCycleTemp.Name = "txtNewCycleTemp";
            this.txtNewCycleTemp.Size = new System.Drawing.Size(100, 29);
            this.txtNewCycleTemp.TabIndex = 12;
            this.txtNewCycleTemp.Text = "348";
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.dGridMeters);
            this.tabPage10.Controls.Add(this.label33);
            this.tabPage10.Controls.Add(this.cbExportDBMeasTemp);
            this.tabPage10.Controls.Add(this.panel3);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(605, 288);
            this.tabPage10.TabIndex = 2;
            this.tabPage10.Text = "Meters";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // dGridMeters
            // 
            this.dGridMeters.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dGridMeters.AllowUserToResizeColumns = false;
            this.dGridMeters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dGridMeters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridMeters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dGridMeters_NN,
            this.MeterActive,
            this.dGridMeters_Meters,
            this.dGridMeterUD,
            this.dGridMeters_Interface,
            this.dGridMeters_TermoContr,
            this.dGridMeter_ContollerInterface});
            this.dGridMeters.Location = new System.Drawing.Point(7, 130);
            this.dGridMeters.Name = "dGridMeters";
            this.dGridMeters.Size = new System.Drawing.Size(595, 144);
            this.dGridMeters.TabIndex = 128;
            // 
            // dGridMeters_NN
            // 
            this.dGridMeters_NN.HeaderText = "NN";
            this.dGridMeters_NN.Name = "dGridMeters_NN";
            this.dGridMeters_NN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dGridMeters_NN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MeterActive
            // 
            this.MeterActive.HeaderText = "Active";
            this.MeterActive.Name = "MeterActive";
            // 
            // dGridMeters_Meters
            // 
            this.dGridMeters_Meters.HeaderText = "Meter_model";
            this.dGridMeters_Meters.Name = "dGridMeters_Meters";
            this.dGridMeters_Meters.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dGridMeters_Meters.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dGridMeterUD
            // 
            this.dGridMeterUD.HeaderText = "Meter_UD";
            this.dGridMeterUD.Name = "dGridMeterUD";
            this.dGridMeterUD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dGridMeterUD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dGridMeters_Interface
            // 
            this.dGridMeters_Interface.HeaderText = "Meters_Interface";
            this.dGridMeters_Interface.Name = "dGridMeters_Interface";
            this.dGridMeters_Interface.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dGridMeters_Interface.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dGridMeters_TermoContr
            // 
            this.dGridMeters_TermoContr.HeaderText = "Termo_controller";
            this.dGridMeters_TermoContr.Name = "dGridMeters_TermoContr";
            this.dGridMeters_TermoContr.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dGridMeters_TermoContr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dGridMeter_ContollerInterface
            // 
            this.dGridMeter_ContollerInterface.HeaderText = "TermoContoller_Interface";
            this.dGridMeter_ContollerInterface.Name = "dGridMeter_ContollerInterface";
            this.dGridMeter_ContollerInterface.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dGridMeter_ContollerInterface.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label33.Location = new System.Drawing.Point(404, 16);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(97, 23);
            this.label33.TabIndex = 41;
            this.label33.Text = "Data export";
            // 
            // cbExportDBMeasTemp
            // 
            this.cbExportDBMeasTemp.FormattingEnabled = true;
            this.cbExportDBMeasTemp.Items.AddRange(new object[] {
            "None",
            "Export to DB parallel",
            "Export to DB(only)"});
            this.cbExportDBMeasTemp.Location = new System.Drawing.Point(408, 42);
            this.cbExportDBMeasTemp.Name = "cbExportDBMeasTemp";
            this.cbExportDBMeasTemp.Size = new System.Drawing.Size(121, 21);
            this.cbExportDBMeasTemp.TabIndex = 40;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label51);
            this.panel3.Controls.Add(this.cbTermocontrollerDevModel);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.cbGPIBDevModel);
            this.panel3.Location = new System.Drawing.Point(7, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(197, 108);
            this.panel3.TabIndex = 39;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label51.Location = new System.Drawing.Point(9, 56);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(183, 23);
            this.label51.TabIndex = 23;
            this.label51.Text = "Termocontroller model";
            // 
            // cbTermocontrollerDevModel
            // 
            this.cbTermocontrollerDevModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTermocontrollerDevModel.FormattingEnabled = true;
            this.cbTermocontrollerDevModel.Items.AddRange(new object[] {
            "Varta",
            "XMFT"});
            this.cbTermocontrollerDevModel.Location = new System.Drawing.Point(13, 79);
            this.cbTermocontrollerDevModel.Name = "cbTermocontrollerDevModel";
            this.cbTermocontrollerDevModel.Size = new System.Drawing.Size(176, 21);
            this.cbTermocontrollerDevModel.TabIndex = 22;
            this.cbTermocontrollerDevModel.Text = "Varta";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(9, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 23);
            this.label14.TabIndex = 21;
            this.label14.Text = "Meter model";
            // 
            // cbGPIBDevModel
            // 
            this.cbGPIBDevModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGPIBDevModel.FormattingEnabled = true;
            this.cbGPIBDevModel.Location = new System.Drawing.Point(13, 32);
            this.cbGPIBDevModel.Name = "cbGPIBDevModel";
            this.cbGPIBDevModel.Size = new System.Drawing.Size(176, 21);
            this.cbGPIBDevModel.TabIndex = 20;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1164, 582);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Work options";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage7);
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Location = new System.Drawing.Point(6, 6);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(1095, 570);
            this.tabControl3.TabIndex = 71;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.tabControl5);
            this.tabPage7.Controls.Add(this.panel1);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1087, 544);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Experiment mode";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tabPage11);
            this.tabControl5.Controls.Add(this.tabPage12);
            this.tabControl5.Controls.Add(this.tabPage13);
            this.tabControl5.Location = new System.Drawing.Point(454, 8);
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.SelectedIndex = 0;
            this.tabControl5.Size = new System.Drawing.Size(561, 517);
            this.tabControl5.TabIndex = 124;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.tTempList);
            this.tabPage11.Controls.Add(this.DGTempData);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(553, 491);
            this.tabPage11.TabIndex = 0;
            this.tabPage11.Text = "Temperature";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // tTempList
            // 
            this.tTempList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tTempList.Location = new System.Drawing.Point(446, 3);
            this.tTempList.Multiline = true;
            this.tTempList.Name = "tTempList";
            this.tTempList.Size = new System.Drawing.Size(104, 482);
            this.tTempList.TabIndex = 127;
            // 
            // DGTempData
            // 
            this.DGTempData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGTempData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Temp,
            this.TimeS,
            this.Cycle});
            this.DGTempData.Location = new System.Drawing.Point(6, 3);
            this.DGTempData.Name = "DGTempData";
            this.DGTempData.Size = new System.Drawing.Size(434, 482);
            this.DGTempData.TabIndex = 126;
            this.DGTempData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DGTempData_MouseClick);
            // 
            // Temp
            // 
            this.Temp.HeaderText = "Temperature, K";
            this.Temp.Name = "Temp";
            // 
            // TimeS
            // 
            this.TimeS.HeaderText = "Time, min";
            this.TimeS.Name = "TimeS";
            // 
            // Cycle
            // 
            this.Cycle.HeaderText = "CycleNum";
            this.Cycle.Name = "Cycle";
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.dGridVolt);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(553, 491);
            this.tabPage12.TabIndex = 1;
            this.tabPage12.Text = "Voltage";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // dGridVolt
            // 
            this.dGridVolt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dGridVolt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridVolt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNN,
            this.colTemp,
            this.ColTime,
            this.ColVolt,
            this.ColFreq});
            this.dGridVolt.Location = new System.Drawing.Point(3, 3);
            this.dGridVolt.Name = "dGridVolt";
            this.dGridVolt.Size = new System.Drawing.Size(449, 482);
            this.dGridVolt.TabIndex = 131;
            // 
            // colNN
            // 
            this.colNN.HeaderText = "NN";
            this.colNN.Name = "colNN";
            // 
            // colTemp
            // 
            this.colTemp.HeaderText = "Temperature, K";
            this.colTemp.Name = "colTemp";
            this.colTemp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColTime
            // 
            this.ColTime.HeaderText = "Time, sec";
            this.ColTime.Name = "ColTime";
            this.ColTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColVolt
            // 
            this.ColVolt.HeaderText = "Voltage, V";
            this.ColVolt.Name = "ColVolt";
            // 
            // ColFreq
            // 
            this.ColFreq.HeaderText = "Freq., Hz";
            this.ColFreq.Name = "ColFreq";
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.dGridFreqMeas);
            this.tabPage13.Controls.Add(this.label10);
            this.tabPage13.Controls.Add(this.tFreqList);
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(553, 491);
            this.tabPage13.TabIndex = 2;
            this.tabPage13.Text = "Frequency";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // dGridFreqMeas
            // 
            this.dGridFreqMeas.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dGridFreqMeas.AllowUserToResizeColumns = false;
            this.dGridFreqMeas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dGridFreqMeas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridFreqMeas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGridFreqMeas_NN,
            this.DGridFreqMeas_Freq});
            this.dGridFreqMeas.Location = new System.Drawing.Point(178, 40);
            this.dGridFreqMeas.Name = "dGridFreqMeas";
            this.dGridFreqMeas.Size = new System.Drawing.Size(241, 445);
            this.dGridFreqMeas.TabIndex = 127;
            // 
            // DGridFreqMeas_NN
            // 
            this.DGridFreqMeas_NN.HeaderText = "NN";
            this.DGridFreqMeas_NN.Name = "DGridFreqMeas_NN";
            // 
            // DGridFreqMeas_Freq
            // 
            this.DGridFreqMeas_Freq.HeaderText = "Frequency";
            this.DGridFreqMeas_Freq.Name = "DGridFreqMeas_Freq";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(13, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 23);
            this.label10.TabIndex = 126;
            this.label10.Text = "Frequency";
            // 
            // tFreqList
            // 
            this.tFreqList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tFreqList.Location = new System.Drawing.Point(6, 40);
            this.tFreqList.Multiline = true;
            this.tFreqList.Name = "tFreqList";
            this.tFreqList.Size = new System.Drawing.Size(166, 445);
            this.tFreqList.TabIndex = 125;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddFreqUbias);
            this.panel1.Controls.Add(this.cbClear);
            this.panel1.Controls.Add(this.cbDefaultFreq);
            this.panel1.Controls.Add(this.cbAllFreq);
            this.panel1.Controls.Add(this.cCUCycle);
            this.panel1.Controls.Add(this.btnAddTemp);
            this.panel1.Controls.Add(this.btnAddFreq);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.txtStepFreq);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txtEndFreq);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.txtStartFreq);
            this.panel1.Controls.Add(this.Coefficient);
            this.panel1.Controls.Add(this.txtCoefficient);
            this.panel1.Controls.Add(this.label31);
            this.panel1.Controls.Add(this.txtTimerReversive);
            this.panel1.Controls.Add(this.btnTimer);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.txtPeriodU);
            this.panel1.Controls.Add(this.btnAddUList);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.txtTimeStartU);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.txtPointCountU);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.txtUmax);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.cbGraphOptions);
            this.panel1.Controls.Add(this.label30);
            this.panel1.Controls.Add(this.txtUmin);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.txtUcur);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.txtCBF);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.txtRHO);
            this.panel1.Controls.Add(this.chListFreq);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cFreqMode);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.cWorkMode);
            this.panel1.Location = new System.Drawing.Point(6, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 559);
            this.panel1.TabIndex = 122;
            // 
            // btnAddFreqUbias
            // 
            this.btnAddFreqUbias.Location = new System.Drawing.Point(313, 354);
            this.btnAddFreqUbias.Name = "btnAddFreqUbias";
            this.btnAddFreqUbias.Size = new System.Drawing.Size(100, 23);
            this.btnAddFreqUbias.TabIndex = 145;
            this.btnAddFreqUbias.Text = "Add Freq_U_bias";
            this.btnAddFreqUbias.UseVisualStyleBackColor = true;
            this.btnAddFreqUbias.Click += new System.EventHandler(this.btnAddFreqUbias_Click);
            // 
            // cbClear
            // 
            this.cbClear.AutoSize = true;
            this.cbClear.Location = new System.Drawing.Point(102, 500);
            this.cbClear.Name = "cbClear";
            this.cbClear.Size = new System.Drawing.Size(50, 17);
            this.cbClear.TabIndex = 144;
            this.cbClear.Text = "Clear";
            this.cbClear.UseVisualStyleBackColor = true;
            // 
            // cbDefaultFreq
            // 
            this.cbDefaultFreq.AutoSize = true;
            this.cbDefaultFreq.Location = new System.Drawing.Point(16, 518);
            this.cbDefaultFreq.Name = "cbDefaultFreq";
            this.cbDefaultFreq.Size = new System.Drawing.Size(84, 17);
            this.cbDefaultFreq.TabIndex = 143;
            this.cbDefaultFreq.Text = "Default freq.";
            this.cbDefaultFreq.UseVisualStyleBackColor = true;
            // 
            // cbAllFreq
            // 
            this.cbAllFreq.AutoSize = true;
            this.cbAllFreq.Location = new System.Drawing.Point(16, 500);
            this.cbAllFreq.Name = "cbAllFreq";
            this.cbAllFreq.Size = new System.Drawing.Size(37, 17);
            this.cbAllFreq.TabIndex = 142;
            this.cbAllFreq.Text = "All";
            this.cbAllFreq.UseVisualStyleBackColor = true;
            // 
            // cCUCycle
            // 
            this.cCUCycle.FormattingEnabled = true;
            this.cCUCycle.Items.AddRange(new object[] {
            "Points full cycle",
            "Points hulf cycle",
            "Full cycle",
            "Half cycle"});
            this.cCUCycle.Location = new System.Drawing.Point(102, 310);
            this.cCUCycle.Name = "cCUCycle";
            this.cCUCycle.Size = new System.Drawing.Size(103, 21);
            this.cCUCycle.TabIndex = 141;
            // 
            // btnAddTemp
            // 
            this.btnAddTemp.Location = new System.Drawing.Point(102, 383);
            this.btnAddTemp.Name = "btnAddTemp";
            this.btnAddTemp.Size = new System.Drawing.Size(100, 23);
            this.btnAddTemp.TabIndex = 140;
            this.btnAddTemp.Text = "Add temp.";
            this.btnAddTemp.UseVisualStyleBackColor = true;
            this.btnAddTemp.Click += new System.EventHandler(this.btnAddTemp_Click_1);
            // 
            // btnAddFreq
            // 
            this.btnAddFreq.Location = new System.Drawing.Point(102, 354);
            this.btnAddFreq.Name = "btnAddFreq";
            this.btnAddFreq.Size = new System.Drawing.Size(100, 23);
            this.btnAddFreq.TabIndex = 139;
            this.btnAddFreq.Text = "Add freq.";
            this.btnAddFreq.UseVisualStyleBackColor = true;
            this.btnAddFreq.Click += new System.EventHandler(this.btnAddFreq_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(102, 240);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 23);
            this.label19.TabIndex = 138;
            this.label19.Text = "Step freq.";
            // 
            // txtStepFreq
            // 
            this.txtStepFreq.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtStepFreq.Location = new System.Drawing.Point(102, 266);
            this.txtStepFreq.Name = "txtStepFreq";
            this.txtStepFreq.Size = new System.Drawing.Size(100, 29);
            this.txtStepFreq.TabIndex = 137;
            this.txtStepFreq.Text = "1000";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(102, 180);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 23);
            this.label18.TabIndex = 136;
            this.label18.Text = "End freq.";
            // 
            // txtEndFreq
            // 
            this.txtEndFreq.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtEndFreq.Location = new System.Drawing.Point(102, 206);
            this.txtEndFreq.Name = "txtEndFreq";
            this.txtEndFreq.Size = new System.Drawing.Size(100, 29);
            this.txtEndFreq.TabIndex = 135;
            this.txtEndFreq.Text = "2000000";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(102, 121);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 23);
            this.label17.TabIndex = 134;
            this.label17.Text = "Start freq.";
            // 
            // txtStartFreq
            // 
            this.txtStartFreq.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtStartFreq.Location = new System.Drawing.Point(105, 147);
            this.txtStartFreq.Name = "txtStartFreq";
            this.txtStartFreq.Size = new System.Drawing.Size(100, 29);
            this.txtStartFreq.TabIndex = 133;
            this.txtStartFreq.Text = "20";
            // 
            // Coefficient
            // 
            this.Coefficient.AutoSize = true;
            this.Coefficient.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Coefficient.Location = new System.Drawing.Point(102, 57);
            this.Coefficient.Name = "Coefficient";
            this.Coefficient.Size = new System.Drawing.Size(91, 23);
            this.Coefficient.TabIndex = 132;
            this.Coefficient.Text = "Coefficient";
            // 
            // txtCoefficient
            // 
            this.txtCoefficient.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCoefficient.Location = new System.Drawing.Point(105, 83);
            this.txtCoefficient.Name = "txtCoefficient";
            this.txtCoefficient.Size = new System.Drawing.Size(100, 29);
            this.txtCoefficient.TabIndex = 131;
            this.txtCoefficient.Text = "1.3";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label31.Location = new System.Drawing.Point(207, 296);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(103, 23);
            this.label31.TabIndex = 130;
            this.label31.Text = "Timer Rev, s";
            // 
            // txtTimerReversive
            // 
            this.txtTimerReversive.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTimerReversive.Location = new System.Drawing.Point(207, 319);
            this.txtTimerReversive.Name = "txtTimerReversive";
            this.txtTimerReversive.Size = new System.Drawing.Size(100, 29);
            this.txtTimerReversive.TabIndex = 129;
            this.txtTimerReversive.Text = "300";
            // 
            // btnTimer
            // 
            this.btnTimer.Location = new System.Drawing.Point(210, 383);
            this.btnTimer.Name = "btnTimer";
            this.btnTimer.Size = new System.Drawing.Size(100, 23);
            this.btnTimer.TabIndex = 128;
            this.btnTimer.Text = "Add law time";
            this.btnTimer.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(210, 240);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(76, 23);
            this.label23.TabIndex = 127;
            this.label23.Text = "Period, s";
            // 
            // txtPeriodU
            // 
            this.txtPeriodU.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPeriodU.Location = new System.Drawing.Point(210, 266);
            this.txtPeriodU.Name = "txtPeriodU";
            this.txtPeriodU.Size = new System.Drawing.Size(100, 29);
            this.txtPeriodU.TabIndex = 126;
            this.txtPeriodU.Text = "20";
            // 
            // btnAddUList
            // 
            this.btnAddUList.Location = new System.Drawing.Point(210, 354);
            this.btnAddUList.Name = "btnAddUList";
            this.btnAddUList.Size = new System.Drawing.Size(100, 23);
            this.btnAddUList.TabIndex = 125;
            this.btnAddUList.Text = "Add U";
            this.btnAddUList.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label24.Location = new System.Drawing.Point(210, 180);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(91, 23);
            this.label24.TabIndex = 124;
            this.label24.Text = "Start Um, s";
            // 
            // txtTimeStartU
            // 
            this.txtTimeStartU.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTimeStartU.Location = new System.Drawing.Point(210, 206);
            this.txtTimeStartU.Name = "txtTimeStartU";
            this.txtTimeStartU.Size = new System.Drawing.Size(100, 29);
            this.txtTimeStartU.TabIndex = 123;
            this.txtTimeStartU.Text = "1";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label25.Location = new System.Drawing.Point(210, 121);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(112, 23);
            this.label25.TabIndex = 122;
            this.label25.Text = "U point count";
            // 
            // txtPointCountU
            // 
            this.txtPointCountU.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPointCountU.Location = new System.Drawing.Point(211, 147);
            this.txtPointCountU.Name = "txtPointCountU";
            this.txtPointCountU.Size = new System.Drawing.Size(96, 29);
            this.txtPointCountU.TabIndex = 121;
            this.txtPointCountU.Text = "40";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.Location = new System.Drawing.Point(315, 57);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(71, 23);
            this.label26.TabIndex = 120;
            this.label26.Text = "Umax, V";
            // 
            // txtUmax
            // 
            this.txtUmax.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtUmax.Location = new System.Drawing.Point(315, 83);
            this.txtUmax.Name = "txtUmax";
            this.txtUmax.Size = new System.Drawing.Size(100, 29);
            this.txtUmax.TabIndex = 119;
            this.txtUmax.Text = "40";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label32.Location = new System.Drawing.Point(311, 298);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(57, 23);
            this.label32.TabIndex = 118;
            this.label32.Text = "Graph";
            // 
            // cbGraphOptions
            // 
            this.cbGraphOptions.FormattingEnabled = true;
            this.cbGraphOptions.Items.AddRange(new object[] {
            "e(T)",
            "e(E)",
            "e(f)"});
            this.cbGraphOptions.Location = new System.Drawing.Point(313, 322);
            this.cbGraphOptions.Name = "cbGraphOptions";
            this.cbGraphOptions.Size = new System.Drawing.Size(103, 21);
            this.cbGraphOptions.TabIndex = 117;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label30.Location = new System.Drawing.Point(210, 57);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(67, 23);
            this.label30.TabIndex = 116;
            this.label30.Text = "Umin, V";
            // 
            // txtUmin
            // 
            this.txtUmin.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtUmin.Location = new System.Drawing.Point(210, 83);
            this.txtUmin.Name = "txtUmin";
            this.txtUmin.Size = new System.Drawing.Size(100, 29);
            this.txtUmin.TabIndex = 115;
            this.txtUmin.Text = "0";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label29.Location = new System.Drawing.Point(316, 240);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(64, 23);
            this.label29.TabIndex = 114;
            this.label29.Text = "Ucur, V";
            // 
            // txtUcur
            // 
            this.txtUcur.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtUcur.Location = new System.Drawing.Point(316, 266);
            this.txtUcur.Name = "txtUcur";
            this.txtUcur.Size = new System.Drawing.Size(100, 29);
            this.txtUcur.TabIndex = 113;
            this.txtUcur.Text = "0";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label28.Location = new System.Drawing.Point(316, 121);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(104, 23);
            this.label28.TabIndex = 112;
            this.label28.Text = "N basis func";
            // 
            // txtCBF
            // 
            this.txtCBF.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCBF.Location = new System.Drawing.Point(316, 147);
            this.txtCBF.Name = "txtCBF";
            this.txtCBF.Size = new System.Drawing.Size(100, 29);
            this.txtCBF.TabIndex = 111;
            this.txtCBF.Text = "60";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label27.Location = new System.Drawing.Point(309, 179);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(119, 23);
            this.label27.TabIndex = 110;
            this.label27.Text = "Regularization";
            // 
            // txtRHO
            // 
            this.txtRHO.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtRHO.Location = new System.Drawing.Point(316, 206);
            this.txtRHO.Name = "txtRHO";
            this.txtRHO.Size = new System.Drawing.Size(100, 29);
            this.txtRHO.TabIndex = 109;
            this.txtRHO.Text = "2.5";
            // 
            // chListFreq
            // 
            this.chListFreq.FormattingEnabled = true;
            this.chListFreq.Items.AddRange(new object[] {
            "20",
            "25",
            "30",
            "40",
            "50",
            "60",
            "80",
            "100",
            "120",
            "150",
            "200",
            "300",
            "400",
            "500",
            "600",
            "800",
            "1000",
            "1200",
            "1500",
            "2000",
            "2500",
            "3000",
            "4000",
            "5000",
            "6000",
            "8000",
            "10000",
            "12000",
            "15000",
            "20000",
            "30000",
            "40000",
            "50000",
            "60000",
            "80000",
            "100000",
            "120000",
            "150000",
            "200000",
            "300000",
            "400000",
            "500000",
            "600000",
            "750000",
            "800000",
            "1000000",
            "1200000",
            "1500000",
            "2000000",
            "3000000",
            "4000000",
            "5000000",
            "6000000",
            "7000000",
            "8000000",
            "9000000",
            "10000000",
            "11000000",
            "12000000",
            "13000000",
            "14000000",
            "15000000",
            "16000000",
            "17000000",
            "18000000",
            "19000000",
            "21000000",
            "22000000",
            "23000000",
            "24000000",
            "25000000",
            "26000000",
            "27000000",
            "28000000",
            "29000000",
            "30000000"});
            this.chListFreq.Location = new System.Drawing.Point(12, 55);
            this.chListFreq.MultiColumn = true;
            this.chListFreq.Name = "chListFreq";
            this.chListFreq.Size = new System.Drawing.Size(84, 439);
            this.chListFreq.TabIndex = 91;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(12, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 23);
            this.label13.TabIndex = 89;
            this.label13.Text = "Frequency Mode";
            // 
            // cFreqMode
            // 
            this.cFreqMode.FormattingEnabled = true;
            this.cFreqMode.Location = new System.Drawing.Point(12, 30);
            this.cFreqMode.Name = "cFreqMode";
            this.cFreqMode.Size = new System.Drawing.Size(121, 21);
            this.cFreqMode.TabIndex = 88;
            this.cFreqMode.SelectedIndexChanged += new System.EventHandler(this.cFreqMode_SelectedIndexChanged_1);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(147, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 23);
            this.label16.TabIndex = 76;
            this.label16.Text = "Work mode";
            // 
            // cWorkMode
            // 
            this.cWorkMode.FormattingEnabled = true;
            this.cWorkMode.Location = new System.Drawing.Point(150, 30);
            this.cWorkMode.Name = "cWorkMode";
            this.cWorkMode.Size = new System.Drawing.Size(203, 21);
            this.cWorkMode.TabIndex = 75;
            this.cWorkMode.SelectedIndexChanged += new System.EventHandler(this.cWorkMode_SelectedIndexChanged_1);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.tabControl2);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1087, 544);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "Experiment res.";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(6, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(477, 434);
            this.tabControl2.TabIndex = 58;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label37);
            this.tabPage4.Controls.Add(this.txtApproxC);
            this.tabPage4.Controls.Add(this.label34);
            this.tabPage4.Controls.Add(this.txtApproxB);
            this.tabPage4.Controls.Add(this.label35);
            this.tabPage4.Controls.Add(this.txtApproxA);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(469, 408);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Reversive non linerity";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label37.Location = new System.Drawing.Point(7, 131);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(21, 23);
            this.label37.TabIndex = 62;
            this.label37.Text = "C";
            // 
            // txtApproxC
            // 
            this.txtApproxC.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxC.Location = new System.Drawing.Point(7, 157);
            this.txtApproxC.Name = "txtApproxC";
            this.txtApproxC.Size = new System.Drawing.Size(100, 29);
            this.txtApproxC.TabIndex = 61;
            this.txtApproxC.Text = "-3.9299";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label34.Location = new System.Drawing.Point(7, 67);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(21, 23);
            this.label34.TabIndex = 59;
            this.label34.Text = "B";
            // 
            // txtApproxB
            // 
            this.txtApproxB.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxB.Location = new System.Drawing.Point(7, 93);
            this.txtApproxB.Name = "txtApproxB";
            this.txtApproxB.Size = new System.Drawing.Size(100, 29);
            this.txtApproxB.TabIndex = 58;
            this.txtApproxB.Text = "-3.9299";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label35.Location = new System.Drawing.Point(7, 7);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(21, 23);
            this.label35.TabIndex = 57;
            this.label35.Text = "A";
            // 
            // txtApproxA
            // 
            this.txtApproxA.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxA.Location = new System.Drawing.Point(7, 33);
            this.txtApproxA.Name = "txtApproxA";
            this.txtApproxA.Size = new System.Drawing.Size(100, 29);
            this.txtApproxA.TabIndex = 56;
            this.txtApproxA.Text = "21.13";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label41);
            this.tabPage5.Controls.Add(this.txtApproxCTE_B_2000);
            this.tabPage5.Controls.Add(this.label42);
            this.tabPage5.Controls.Add(this.txtApproxCTE_A_2000);
            this.tabPage5.Controls.Add(this.label39);
            this.tabPage5.Controls.Add(this.txtApproxCTE_B_200);
            this.tabPage5.Controls.Add(this.label40);
            this.tabPage5.Controls.Add(this.txtApproxCTE_A_200);
            this.tabPage5.Controls.Add(this.label36);
            this.tabPage5.Controls.Add(this.txtApproxCTE_B_20);
            this.tabPage5.Controls.Add(this.label38);
            this.tabPage5.Controls.Add(this.txtApproxCTE_A_20);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(469, 408);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "CTE";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label41.Location = new System.Drawing.Point(287, 69);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(66, 23);
            this.label41.TabIndex = 71;
            this.label41.Text = "B_2000";
            // 
            // txtApproxCTE_B_2000
            // 
            this.txtApproxCTE_B_2000.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxCTE_B_2000.Location = new System.Drawing.Point(287, 95);
            this.txtApproxCTE_B_2000.Name = "txtApproxCTE_B_2000";
            this.txtApproxCTE_B_2000.Size = new System.Drawing.Size(100, 29);
            this.txtApproxCTE_B_2000.TabIndex = 70;
            this.txtApproxCTE_B_2000.Text = "-3.9299";
            this.txtApproxCTE_B_2000.TextChanged += new System.EventHandler(this.txtApproxCTE_B_2000_TextChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label42.Location = new System.Drawing.Point(287, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(66, 23);
            this.label42.TabIndex = 69;
            this.label42.Text = "A_2000";
            // 
            // txtApproxCTE_A_2000
            // 
            this.txtApproxCTE_A_2000.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxCTE_A_2000.Location = new System.Drawing.Point(287, 35);
            this.txtApproxCTE_A_2000.Name = "txtApproxCTE_A_2000";
            this.txtApproxCTE_A_2000.Size = new System.Drawing.Size(100, 29);
            this.txtApproxCTE_A_2000.TabIndex = 68;
            this.txtApproxCTE_A_2000.Text = "21.13";
            this.txtApproxCTE_A_2000.TextChanged += new System.EventHandler(this.TextBox4_TextChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label39.Location = new System.Drawing.Point(149, 69);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(57, 23);
            this.label39.TabIndex = 67;
            this.label39.Text = "B_200";
            this.label39.Click += new System.EventHandler(this.label39_Click);
            // 
            // txtApproxCTE_B_200
            // 
            this.txtApproxCTE_B_200.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxCTE_B_200.Location = new System.Drawing.Point(149, 95);
            this.txtApproxCTE_B_200.Name = "txtApproxCTE_B_200";
            this.txtApproxCTE_B_200.Size = new System.Drawing.Size(100, 29);
            this.txtApproxCTE_B_200.TabIndex = 66;
            this.txtApproxCTE_B_200.Text = "-3.9299";
            this.txtApproxCTE_B_200.TextChanged += new System.EventHandler(this.txtApproxCTE_B_200_TextChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label40.Location = new System.Drawing.Point(149, 9);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(57, 23);
            this.label40.TabIndex = 65;
            this.label40.Text = "A_200";
            // 
            // txtApproxCTE_A_200
            // 
            this.txtApproxCTE_A_200.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxCTE_A_200.Location = new System.Drawing.Point(149, 35);
            this.txtApproxCTE_A_200.Name = "txtApproxCTE_A_200";
            this.txtApproxCTE_A_200.Size = new System.Drawing.Size(100, 29);
            this.txtApproxCTE_A_200.TabIndex = 64;
            this.txtApproxCTE_A_200.Text = "21.13";
            this.txtApproxCTE_A_200.TextChanged += new System.EventHandler(this.txtApproxCTE_A_200_TextChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label36.Location = new System.Drawing.Point(6, 69);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(48, 23);
            this.label36.TabIndex = 63;
            this.label36.Text = "B_20";
            // 
            // txtApproxCTE_B_20
            // 
            this.txtApproxCTE_B_20.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxCTE_B_20.Location = new System.Drawing.Point(6, 95);
            this.txtApproxCTE_B_20.Name = "txtApproxCTE_B_20";
            this.txtApproxCTE_B_20.Size = new System.Drawing.Size(100, 29);
            this.txtApproxCTE_B_20.TabIndex = 62;
            this.txtApproxCTE_B_20.Text = "-3.9299";
            this.txtApproxCTE_B_20.TextChanged += new System.EventHandler(this.txtApproxCTE_B_TextChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label38.Location = new System.Drawing.Point(6, 9);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(48, 23);
            this.label38.TabIndex = 61;
            this.label38.Text = "A_20";
            this.label38.Click += new System.EventHandler(this.label38_Click);
            // 
            // txtApproxCTE_A_20
            // 
            this.txtApproxCTE_A_20.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxCTE_A_20.Location = new System.Drawing.Point(6, 35);
            this.txtApproxCTE_A_20.Name = "txtApproxCTE_A_20";
            this.txtApproxCTE_A_20.Size = new System.Drawing.Size(100, 29);
            this.txtApproxCTE_A_20.TabIndex = 60;
            this.txtApproxCTE_A_20.Text = "21.13";
            this.txtApproxCTE_A_20.TextChanged += new System.EventHandler(this.txtApproxCTE_A_TextChanged);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox2);
            this.tabPage6.Controls.Add(this.groupBox1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(469, 408);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "d33rev";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label49);
            this.groupBox2.Controls.Add(this.txtApproxU_d33_B);
            this.groupBox2.Controls.Add(this.label50);
            this.groupBox2.Controls.Add(this.txtApproxU_d33_A);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(19, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 166);
            this.groupBox2.TabIndex = 85;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "convert U";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label49.Location = new System.Drawing.Point(10, 83);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(48, 23);
            this.label49.TabIndex = 95;
            this.label49.Text = "B_20";
            // 
            // txtApproxU_d33_B
            // 
            this.txtApproxU_d33_B.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxU_d33_B.Location = new System.Drawing.Point(10, 109);
            this.txtApproxU_d33_B.Name = "txtApproxU_d33_B";
            this.txtApproxU_d33_B.Size = new System.Drawing.Size(100, 29);
            this.txtApproxU_d33_B.TabIndex = 94;
            this.txtApproxU_d33_B.Text = "-3.9299";
            this.txtApproxU_d33_B.TextChanged += new System.EventHandler(this.txtApproxU_d33_B_TextChanged);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label50.Location = new System.Drawing.Point(10, 23);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(48, 23);
            this.label50.TabIndex = 93;
            this.label50.Text = "A_20";
            // 
            // txtApproxU_d33_A
            // 
            this.txtApproxU_d33_A.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxU_d33_A.Location = new System.Drawing.Point(10, 49);
            this.txtApproxU_d33_A.Name = "txtApproxU_d33_A";
            this.txtApproxU_d33_A.Size = new System.Drawing.Size(100, 29);
            this.txtApproxU_d33_A.TabIndex = 92;
            this.txtApproxU_d33_A.Text = "21.13";
            this.txtApproxU_d33_A.TextChanged += new System.EventHandler(this.txtApproxU_d33_A_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.Controls.Add(this.txtApproxD33_B_2000);
            this.groupBox1.Controls.Add(this.label44);
            this.groupBox1.Controls.Add(this.txtApproxD33_A_2000);
            this.groupBox1.Controls.Add(this.label45);
            this.groupBox1.Controls.Add(this.txtApproxD33_B_200);
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.Controls.Add(this.txtApproxD33_A_200);
            this.groupBox1.Controls.Add(this.label47);
            this.groupBox1.Controls.Add(this.txtApproxD33_B_20);
            this.groupBox1.Controls.Add(this.label48);
            this.groupBox1.Controls.Add(this.txtApproxD33_A_20);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(19, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 167);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "d33_approximation coefficients";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label43.Location = new System.Drawing.Point(287, 86);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(66, 23);
            this.label43.TabIndex = 95;
            this.label43.Text = "B_2000";
            // 
            // txtApproxD33_B_2000
            // 
            this.txtApproxD33_B_2000.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxD33_B_2000.Location = new System.Drawing.Point(287, 112);
            this.txtApproxD33_B_2000.Name = "txtApproxD33_B_2000";
            this.txtApproxD33_B_2000.Size = new System.Drawing.Size(100, 29);
            this.txtApproxD33_B_2000.TabIndex = 94;
            this.txtApproxD33_B_2000.Text = "-3.9299";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label44.Location = new System.Drawing.Point(287, 26);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(66, 23);
            this.label44.TabIndex = 93;
            this.label44.Text = "A_2000";
            // 
            // txtApproxD33_A_2000
            // 
            this.txtApproxD33_A_2000.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxD33_A_2000.Location = new System.Drawing.Point(287, 52);
            this.txtApproxD33_A_2000.Name = "txtApproxD33_A_2000";
            this.txtApproxD33_A_2000.Size = new System.Drawing.Size(100, 29);
            this.txtApproxD33_A_2000.TabIndex = 92;
            this.txtApproxD33_A_2000.Text = "21.13";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label45.Location = new System.Drawing.Point(149, 86);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(57, 23);
            this.label45.TabIndex = 91;
            this.label45.Text = "B_200";
            // 
            // txtApproxD33_B_200
            // 
            this.txtApproxD33_B_200.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxD33_B_200.Location = new System.Drawing.Point(149, 112);
            this.txtApproxD33_B_200.Name = "txtApproxD33_B_200";
            this.txtApproxD33_B_200.Size = new System.Drawing.Size(100, 29);
            this.txtApproxD33_B_200.TabIndex = 90;
            this.txtApproxD33_B_200.Text = "-3.9299";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label46.Location = new System.Drawing.Point(149, 26);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(57, 23);
            this.label46.TabIndex = 89;
            this.label46.Text = "A_200";
            // 
            // txtApproxD33_A_200
            // 
            this.txtApproxD33_A_200.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxD33_A_200.Location = new System.Drawing.Point(149, 52);
            this.txtApproxD33_A_200.Name = "txtApproxD33_A_200";
            this.txtApproxD33_A_200.Size = new System.Drawing.Size(100, 29);
            this.txtApproxD33_A_200.TabIndex = 88;
            this.txtApproxD33_A_200.Text = "21.13";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label47.Location = new System.Drawing.Point(6, 86);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(48, 23);
            this.label47.TabIndex = 87;
            this.label47.Text = "B_20";
            // 
            // txtApproxD33_B_20
            // 
            this.txtApproxD33_B_20.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxD33_B_20.Location = new System.Drawing.Point(6, 112);
            this.txtApproxD33_B_20.Name = "txtApproxD33_B_20";
            this.txtApproxD33_B_20.Size = new System.Drawing.Size(100, 29);
            this.txtApproxD33_B_20.TabIndex = 86;
            this.txtApproxD33_B_20.Text = "-3.9299";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label48.Location = new System.Drawing.Point(6, 26);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(48, 23);
            this.label48.TabIndex = 85;
            this.label48.Text = "A_20";
            // 
            // txtApproxD33_A_20
            // 
            this.txtApproxD33_A_20.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtApproxD33_A_20.Location = new System.Drawing.Point(6, 52);
            this.txtApproxD33_A_20.Name = "txtApproxD33_A_20";
            this.txtApproxD33_A_20.Size = new System.Drawing.Size(100, 29);
            this.txtApproxD33_A_20.TabIndex = 84;
            this.txtApproxD33_A_20.Text = "21.13";
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.tabControl6);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(1164, 582);
            this.tabPage14.TabIndex = 2;
            this.tabPage14.Text = "DataBase";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // tabControl6
            // 
            this.tabControl6.Controls.Add(this.tabPage15);
            this.tabControl6.Controls.Add(this.tabPage16);
            this.tabControl6.Location = new System.Drawing.Point(6, 6);
            this.tabControl6.Name = "tabControl6";
            this.tabControl6.SelectedIndex = 0;
            this.tabControl6.Size = new System.Drawing.Size(715, 441);
            this.tabControl6.TabIndex = 0;
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.label9);
            this.tabPage15.Controls.Add(this.txtRequsetDB);
            this.tabPage15.Controls.Add(this.btnSentDBRequest);
            this.tabPage15.Controls.Add(this.btnSetPass);
            this.tabPage15.Controls.Add(this.btnConnectDB);
            this.tabPage15.Controls.Add(this.label52);
            this.tabPage15.Controls.Add(this.ePort);
            this.tabPage15.Controls.Add(this.btnSetPort);
            this.tabPage15.Controls.Add(this.label53);
            this.tabPage15.Controls.Add(this.label54);
            this.tabPage15.Controls.Add(this.label55);
            this.tabPage15.Controls.Add(this.label56);
            this.tabPage15.Controls.Add(this.eDB);
            this.tabPage15.Controls.Add(this.ePass);
            this.tabPage15.Controls.Add(this.eLogin);
            this.tabPage15.Controls.Add(this.eServer);
            this.tabPage15.Controls.Add(this.btnSetDB);
            this.tabPage15.Controls.Add(this.btnSetLogin);
            this.tabPage15.Controls.Add(this.btnSetSever);
            this.tabPage15.Location = new System.Drawing.Point(4, 22);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(707, 415);
            this.tabPage15.TabIndex = 0;
            this.tabPage15.Text = "Connect";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(14, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.TabIndex = 39;
            this.label9.Text = "Request";
            // 
            // txtRequsetDB
            // 
            this.txtRequsetDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtRequsetDB.Location = new System.Drawing.Point(10, 323);
            this.txtRequsetDB.Name = "txtRequsetDB";
            this.txtRequsetDB.Size = new System.Drawing.Size(100, 26);
            this.txtRequsetDB.TabIndex = 38;
            // 
            // btnSentDBRequest
            // 
            this.btnSentDBRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSentDBRequest.Location = new System.Drawing.Point(116, 323);
            this.btnSentDBRequest.Name = "btnSentDBRequest";
            this.btnSentDBRequest.Size = new System.Drawing.Size(103, 26);
            this.btnSentDBRequest.TabIndex = 37;
            this.btnSentDBRequest.Text = "Send Request";
            this.btnSentDBRequest.UseVisualStyleBackColor = true;
            // 
            // btnSetPass
            // 
            this.btnSetPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSetPass.Location = new System.Drawing.Point(112, 197);
            this.btnSetPass.Name = "btnSetPass";
            this.btnSetPass.Size = new System.Drawing.Size(103, 26);
            this.btnSetPass.TabIndex = 36;
            this.btnSetPass.Text = "Password";
            this.btnSetPass.UseVisualStyleBackColor = true;
            // 
            // btnConnectDB
            // 
            this.btnConnectDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConnectDB.Location = new System.Drawing.Point(221, 41);
            this.btnConnectDB.Name = "btnConnectDB";
            this.btnConnectDB.Size = new System.Drawing.Size(87, 26);
            this.btnConnectDB.TabIndex = 35;
            this.btnConnectDB.Text = "Connect";
            this.btnConnectDB.UseVisualStyleBackColor = true;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label52.Location = new System.Drawing.Point(6, 226);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(38, 20);
            this.label52.TabIndex = 34;
            this.label52.Text = "Port";
            // 
            // ePort
            // 
            this.ePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ePort.Location = new System.Drawing.Point(6, 249);
            this.ePort.Name = "ePort";
            this.ePort.Size = new System.Drawing.Size(100, 26);
            this.ePort.TabIndex = 33;
            this.ePort.Text = "5432";
            // 
            // btnSetPort
            // 
            this.btnSetPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSetPort.Location = new System.Drawing.Point(112, 249);
            this.btnSetPort.Name = "btnSetPort";
            this.btnSetPort.Size = new System.Drawing.Size(103, 26);
            this.btnSetPort.TabIndex = 32;
            this.btnSetPort.Text = "Set port";
            this.btnSetPort.UseVisualStyleBackColor = true;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label53.Location = new System.Drawing.Point(6, 176);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(78, 20);
            this.label53.TabIndex = 31;
            this.label53.Text = "Password";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label54.Location = new System.Drawing.Point(6, 124);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(48, 20);
            this.label54.TabIndex = 30;
            this.label54.Text = "Login";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label55.Location = new System.Drawing.Point(6, 72);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(83, 20);
            this.label55.TabIndex = 29;
            this.label55.Text = "Data base";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label56.Location = new System.Drawing.Point(6, 18);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(55, 20);
            this.label56.TabIndex = 28;
            this.label56.Text = "Server";
            // 
            // eDB
            // 
            this.eDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eDB.Location = new System.Drawing.Point(6, 95);
            this.eDB.Name = "eDB";
            this.eDB.Size = new System.Drawing.Size(100, 26);
            this.eDB.TabIndex = 27;
            this.eDB.Text = "nii_db";
            // 
            // ePass
            // 
            this.ePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ePass.Location = new System.Drawing.Point(6, 197);
            this.ePass.Name = "ePass";
            this.ePass.PasswordChar = '*';
            this.ePass.Size = new System.Drawing.Size(100, 26);
            this.ePass.TabIndex = 26;
            this.ePass.Text = "nii011235813";
            // 
            // eLogin
            // 
            this.eLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eLogin.Location = new System.Drawing.Point(6, 147);
            this.eLogin.Name = "eLogin";
            this.eLogin.Size = new System.Drawing.Size(100, 26);
            this.eLogin.TabIndex = 25;
            this.eLogin.Text = "postgres";
            // 
            // eServer
            // 
            this.eServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eServer.Location = new System.Drawing.Point(6, 41);
            this.eServer.Name = "eServer";
            this.eServer.Size = new System.Drawing.Size(100, 26);
            this.eServer.TabIndex = 24;
            this.eServer.Text = "10.11.0.36";
            // 
            // btnSetDB
            // 
            this.btnSetDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSetDB.Location = new System.Drawing.Point(112, 95);
            this.btnSetDB.Name = "btnSetDB";
            this.btnSetDB.Size = new System.Drawing.Size(103, 26);
            this.btnSetDB.TabIndex = 23;
            this.btnSetDB.Text = "Set DB";
            this.btnSetDB.UseVisualStyleBackColor = true;
            // 
            // btnSetLogin
            // 
            this.btnSetLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSetLogin.Location = new System.Drawing.Point(112, 147);
            this.btnSetLogin.Name = "btnSetLogin";
            this.btnSetLogin.Size = new System.Drawing.Size(103, 26);
            this.btnSetLogin.TabIndex = 22;
            this.btnSetLogin.Text = "Set login";
            this.btnSetLogin.UseVisualStyleBackColor = true;
            // 
            // btnSetSever
            // 
            this.btnSetSever.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSetSever.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSetSever.Location = new System.Drawing.Point(112, 40);
            this.btnSetSever.Name = "btnSetSever";
            this.btnSetSever.Size = new System.Drawing.Size(103, 27);
            this.btnSetSever.TabIndex = 21;
            this.btnSetSever.Text = "Set server";
            this.btnSetSever.UseVisualStyleBackColor = true;
            // 
            // tabPage16
            // 
            this.tabPage16.Location = new System.Drawing.Point(4, 22);
            this.tabPage16.Name = "tabPage16";
            this.tabPage16.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage16.Size = new System.Drawing.Size(707, 415);
            this.tabPage16.TabIndex = 1;
            this.tabPage16.Text = "tabPage16";
            this.tabPage16.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFilevoltageToolStripMenuItem,
            this.openFiletimerToolStripMenuItem,
            this.openFileexcelToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFilevoltageToolStripMenuItem
            // 
            this.openFilevoltageToolStripMenuItem.Name = "openFilevoltageToolStripMenuItem";
            this.openFilevoltageToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.openFilevoltageToolStripMenuItem.Text = "Open file (voltage)";
            this.openFilevoltageToolStripMenuItem.Click += new System.EventHandler(this.openFilevoltageToolStripMenuItem_Click);
            // 
            // openFiletimerToolStripMenuItem
            // 
            this.openFiletimerToolStripMenuItem.Name = "openFiletimerToolStripMenuItem";
            this.openFiletimerToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.openFiletimerToolStripMenuItem.Text = "Open file (timer)";
            this.openFiletimerToolStripMenuItem.Click += new System.EventHandler(this.openFiletimerToolStripMenuItem_Click);
            // 
            // openFileexcelToolStripMenuItem
            // 
            this.openFileexcelToolStripMenuItem.Name = "openFileexcelToolStripMenuItem";
            this.openFileexcelToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.openFileexcelToolStripMenuItem.Text = "Open file (excel)";
            this.openFileexcelToolStripMenuItem.Click += new System.EventHandler(this.openFileexcelToolStripMenuItem_Click);
            // 
            // opnFileVoltage
            // 
            this.opnFileVoltage.FileName = "openFileDialog1";
            this.opnFileVoltage.FileOk += new System.ComponentModel.CancelEventHandler(this.opnFileVoltage_FileOk);
            // 
            // opnFileTimer
            // 
            this.opnFileTimer.FileName = "openFileDialog1";
            this.opnFileTimer.FileOk += new System.ComponentModel.CancelEventHandler(this.opnFileTimer_FileOk);
            // 
            // opnFileExcel
            // 
            this.opnFileExcel.FileName = "openFileDialog1";
            this.opnFileExcel.FileOk += new System.ComponentModel.CancelEventHandler(this.opnFileExcel_FileOk);
            // 
            // frmMeasTempOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 656);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMeasTempOpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Measure options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMeasTempOpt_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMeasTempOpt_FormClosed);
            this.Load += new System.EventHandler(this.frmMeasTempOpt_Load);
            this.VisibleChanged += new System.EventHandler(this.FrmMeasTempOpt_VisibleChanged);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridMeters)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabControl5.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGTempData)).EndInit();
            this.tabPage12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridVolt)).EndInit();
            this.tabPage13.ResumeLayout(false);
            this.tabPage13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridFreqMeas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage14.ResumeLayout(false);
            this.tabControl6.ResumeLayout(false);
            this.tabPage15.ResumeLayout(false);
            this.tabPage15.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtSampleNumber"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtSampleNumber"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtComposition"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtComposition"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtNewCycleTemp"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtNewCycleTemp"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtCycleCount"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtCycleCount"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtTempStep"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtTempStep"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtDiameter"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtDiameter"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtTempStart"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtTempStart"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtHeight"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtHeight"
        private System.Windows.Forms.TabPage tabPage2;
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.cmbOperator"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.cmbOperator"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.tTempList"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.tTempList"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.tFreqList"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.tFreqList"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.tVoltageList"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.tVoltageList"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.tTimerList"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.tTimerList"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.cFreqMode"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.cFreqMode"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.cbGPIBDevModel"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.cbGPIBDevModel"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.cWorkMode"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.cWorkMode"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtTempEnd"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtTempEnd"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.cDirect"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.cDirect"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.cbTempMode"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.cbTempMode"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtTempSint"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtTempSint"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtTimeStartU"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtTimeStartU"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtPointCountU"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtPointCountU"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtUmax"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtUmax"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.cCUCycle"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.cCUCycle"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtPeriodU"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtPeriodU"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtCBF"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtCBF"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtRHO"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtRHO"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.chTest"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.chTest"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtUcur"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtUcur"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.chExportToDB"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.chExportToDB"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.cbExportDBMeasTemp"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.cbExportDBMeasTemp"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.checkBox1"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.checkBox1"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtUmin"
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtUmin"
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtTimerReversive"
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFilevoltageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFiletimerToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog opnFileVoltage;
        private System.Windows.Forms.OpenFileDialog opnFileTimer;
        private System.Windows.Forms.ToolStripMenuItem openFileexcelToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog opnFileExcel;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label37;
        public System.Windows.Forms.TextBox txtApproxC;
        private System.Windows.Forms.Label label34;
        public System.Windows.Forms.TextBox txtApproxB;
        private System.Windows.Forms.Label label35;
        public System.Windows.Forms.TextBox txtApproxA;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label36;
        public System.Windows.Forms.TextBox txtApproxCTE_B_20;
        private System.Windows.Forms.Label label38;
        public System.Windows.Forms.TextBox txtApproxCTE_A_20;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label39;
        public System.Windows.Forms.TextBox txtApproxCTE_B_200;
        private System.Windows.Forms.Label label40;
        public System.Windows.Forms.TextBox txtApproxCTE_A_200;
        private System.Windows.Forms.Label label41;
        public System.Windows.Forms.TextBox txtApproxCTE_B_2000;
        private System.Windows.Forms.Label label42;
        public System.Windows.Forms.TextBox txtApproxCTE_A_2000;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label49;
        public System.Windows.Forms.TextBox txtApproxU_d33_B;
        private System.Windows.Forms.Label label50;
        public System.Windows.Forms.TextBox txtApproxU_d33_A;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label43;
        public System.Windows.Forms.TextBox txtApproxD33_B_2000;
        private System.Windows.Forms.Label label44;
        public System.Windows.Forms.TextBox txtApproxD33_A_2000;
        private System.Windows.Forms.Label label45;
        public System.Windows.Forms.TextBox txtApproxD33_B_200;
        private System.Windows.Forms.Label label46;
        public System.Windows.Forms.TextBox txtApproxD33_A_200;
        private System.Windows.Forms.Label label47;
        public System.Windows.Forms.TextBox txtApproxD33_B_20;
        private System.Windows.Forms.Label label48;
        public System.Windows.Forms.TextBox txtApproxD33_A_20;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbClear;
        private System.Windows.Forms.CheckBox cbDefaultFreq;
        private System.Windows.Forms.CheckBox cbAllFreq;
        public System.Windows.Forms.ComboBox cCUCycle;
        private System.Windows.Forms.Button btnAddTemp;
        private System.Windows.Forms.Button btnAddFreq;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtStepFreq;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtEndFreq;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtStartFreq;
        private System.Windows.Forms.Label Coefficient;
        private System.Windows.Forms.TextBox txtCoefficient;
        private System.Windows.Forms.Label label31;
        public System.Windows.Forms.TextBox txtTimerReversive;
        private System.Windows.Forms.Button btnTimer;
        private System.Windows.Forms.Label label23;
        public System.Windows.Forms.TextBox txtPeriodU;
        private System.Windows.Forms.Button btnAddUList;
        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.TextBox txtTimeStartU;
        private System.Windows.Forms.Label label25;
        public System.Windows.Forms.TextBox txtPointCountU;
        private System.Windows.Forms.Label label26;
        public System.Windows.Forms.TextBox txtUmax;
        private System.Windows.Forms.Label label32;
        public System.Windows.Forms.ComboBox cbGraphOptions;
        private System.Windows.Forms.Label label30;
        public System.Windows.Forms.TextBox txtUmin;
        private System.Windows.Forms.Label label29;
        public System.Windows.Forms.TextBox txtUcur;
        private System.Windows.Forms.Label label28;
        public System.Windows.Forms.TextBox txtCBF;
        private System.Windows.Forms.Label label27;
        public System.Windows.Forms.TextBox txtRHO;
        private System.Windows.Forms.CheckedListBox chListFreq;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.ComboBox cFreqMode;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.ComboBox cWorkMode;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtDiameter;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TabPage tabPage9;
        public System.Windows.Forms.CheckBox chTest;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.TextBox txtTempSint;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtComposition;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtSampleNumber;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.ComboBox cmbOperator;
        private System.Windows.Forms.Label Direct;
        public System.Windows.Forms.ComboBox cDirect;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.ComboBox cbTempMode;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtTempStep;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtCycleCount;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox txtTempEnd;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtTempStart;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtNewCycleTemp;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.Label label33;
        public System.Windows.Forms.ComboBox cbExportDBMeasTemp;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label51;
        public System.Windows.Forms.ComboBox cbTermocontrollerDevModel;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.ComboBox cbGPIBDevModel;
        private System.Windows.Forms.TabControl tabControl5;
        private System.Windows.Forms.TabPage tabPage11;
        public System.Windows.Forms.TextBox tTempList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temp;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cycle;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox tFreqList;
        public System.Windows.Forms.DataGridView DGTempData;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.TabControl tabControl6;
        private System.Windows.Forms.TabPage tabPage15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRequsetDB;
        private System.Windows.Forms.Button btnSentDBRequest;
        private System.Windows.Forms.Button btnSetPass;
        private System.Windows.Forms.Button btnConnectDB;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox ePort;
        private System.Windows.Forms.Button btnSetPort;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox eDB;
        private System.Windows.Forms.TextBox ePass;
        private System.Windows.Forms.TextBox eLogin;
        private System.Windows.Forms.TextBox eServer;
        private System.Windows.Forms.Button btnSetDB;
        private System.Windows.Forms.Button btnSetLogin;
        private System.Windows.Forms.Button btnSetSever;
        private System.Windows.Forms.TabPage tabPage16;
        private System.Windows.Forms.Label label57;
        public System.Windows.Forms.ComboBox cmbSolidState;
        private System.Windows.Forms.Label label58;
        public System.Windows.Forms.TextBox txtRoExp;
        public System.Windows.Forms.DataGridView dGridVolt;
        private System.Windows.Forms.Label label59;
        public System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.DataGridView dGridFreqMeas;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGridFreqMeas_NN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGridFreqMeas_Freq;
        public System.Windows.Forms.DataGridView dGridMeters;
        private System.Windows.Forms.Button btnAddFreqUbias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVolt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFreq;
        private System.Windows.Forms.DataGridViewComboBoxColumn dGridMeters_NN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MeterActive;
        private System.Windows.Forms.DataGridViewComboBoxColumn dGridMeters_Meters;
        private System.Windows.Forms.DataGridViewComboBoxColumn dGridMeterUD;
        private System.Windows.Forms.DataGridViewComboBoxColumn dGridMeters_Interface;
        private System.Windows.Forms.DataGridViewComboBoxColumn dGridMeters_TermoContr;
        private System.Windows.Forms.DataGridViewComboBoxColumn dGridMeter_ContollerInterface;
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMeasTempOpt.txtTimerReversive"
    }
}