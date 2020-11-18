namespace Kalipso
{
	partial class frmDataBase
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
            this.btnSetSever = new System.Windows.Forms.Button();
            this.btnSetLogin = new System.Windows.Forms.Button();
            this.btnSetDB = new System.Windows.Forms.Button();
            this.eServer = new System.Windows.Forms.TextBox();
            this.eLogin = new System.Windows.Forms.TextBox();
            this.ePass = new System.Windows.Forms.TextBox();
            this.eDB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ePort = new System.Windows.Forms.TextBox();
            this.btnSetPort = new System.Windows.Forms.Button();
            this.btnConnectDB = new System.Windows.Forms.Button();
            this.btnSetPass = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRequsetDB = new System.Windows.Forms.TextBox();
            this.btnSentDBRequest = new System.Windows.Forms.Button();
            this.dataSet1 = new System.Data.DataSet();
            this.npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            this.npgsqlConnection1 = new Npgsql.NpgsqlConnection();
            this.dbView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetSever
            // 
            this.btnSetSever.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSetSever.Location = new System.Drawing.Point(128, 21);
            this.btnSetSever.Name = "btnSetSever";
            this.btnSetSever.Size = new System.Drawing.Size(75, 20);
            this.btnSetSever.TabIndex = 0;
            this.btnSetSever.Text = "Set server";
            this.btnSetSever.UseVisualStyleBackColor = true;
            this.btnSetSever.Click += new System.EventHandler(this.btnSetSever_Click);
            // 
            // btnSetLogin
            // 
            this.btnSetLogin.Location = new System.Drawing.Point(128, 102);
            this.btnSetLogin.Name = "btnSetLogin";
            this.btnSetLogin.Size = new System.Drawing.Size(75, 20);
            this.btnSetLogin.TabIndex = 1;
            this.btnSetLogin.Text = "Set login";
            this.btnSetLogin.UseVisualStyleBackColor = true;
            this.btnSetLogin.Click += new System.EventHandler(this.btnSetLogin_Click);
            // 
            // btnSetDB
            // 
            this.btnSetDB.Location = new System.Drawing.Point(128, 63);
            this.btnSetDB.Name = "btnSetDB";
            this.btnSetDB.Size = new System.Drawing.Size(75, 20);
            this.btnSetDB.TabIndex = 2;
            this.btnSetDB.Text = "Set DB";
            this.btnSetDB.UseVisualStyleBackColor = true;
            this.btnSetDB.Click += new System.EventHandler(this.btnSetDB_Click);
            // 
            // eServer
            // 
            this.eServer.Location = new System.Drawing.Point(22, 21);
            this.eServer.Name = "eServer";
            this.eServer.Size = new System.Drawing.Size(100, 20);
            this.eServer.TabIndex = 4;
            this.eServer.Text = "192.168.3.200";
            this.eServer.TextChanged += new System.EventHandler(this.eServer_TextChanged);
            // 
            // eLogin
            // 
            this.eLogin.Location = new System.Drawing.Point(22, 102);
            this.eLogin.Name = "eLogin";
            this.eLogin.Size = new System.Drawing.Size(100, 20);
            this.eLogin.TabIndex = 5;
            this.eLogin.Text = "postgres";
            this.eLogin.TextChanged += new System.EventHandler(this.eLogin_TextChanged);
            // 
            // ePass
            // 
            this.ePass.Location = new System.Drawing.Point(22, 141);
            this.ePass.Name = "ePass";
            this.ePass.PasswordChar = '*';
            this.ePass.Size = new System.Drawing.Size(100, 20);
            this.ePass.TabIndex = 6;
            this.ePass.Text = "nii011235813";
            this.ePass.TextChanged += new System.EventHandler(this.ePass_TextChanged);
            // 
            // eDB
            // 
            this.eDB.Location = new System.Drawing.Point(22, 60);
            this.eDB.Name = "eDB";
            this.eDB.Size = new System.Drawing.Size(100, 20);
            this.eDB.TabIndex = 7;
            this.eDB.Text = "nii_db";
            this.eDB.TextChanged += new System.EventHandler(this.eDB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Data base";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Login";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Port";
            // 
            // ePort
            // 
            this.ePort.Location = new System.Drawing.Point(22, 182);
            this.ePort.Name = "ePort";
            this.ePort.Size = new System.Drawing.Size(100, 20);
            this.ePort.TabIndex = 13;
            this.ePort.Text = "5432";
            this.ePort.TextChanged += new System.EventHandler(this.ePort_TextChanged);
            // 
            // btnSetPort
            // 
            this.btnSetPort.Location = new System.Drawing.Point(128, 182);
            this.btnSetPort.Name = "btnSetPort";
            this.btnSetPort.Size = new System.Drawing.Size(75, 20);
            this.btnSetPort.TabIndex = 12;
            this.btnSetPort.Text = "Set port";
            this.btnSetPort.UseVisualStyleBackColor = true;
            this.btnSetPort.Click += new System.EventHandler(this.btnSetPort_Click);
            // 
            // btnConnectDB
            // 
            this.btnConnectDB.Location = new System.Drawing.Point(79, 208);
            this.btnConnectDB.Name = "btnConnectDB";
            this.btnConnectDB.Size = new System.Drawing.Size(87, 29);
            this.btnConnectDB.TabIndex = 15;
            this.btnConnectDB.Text = "Connect";
            this.btnConnectDB.UseVisualStyleBackColor = true;
            this.btnConnectDB.Click += new System.EventHandler(this.btnConnectDB_Click);
            // 
            // btnSetPass
            // 
            this.btnSetPass.Location = new System.Drawing.Point(128, 140);
            this.btnSetPass.Name = "btnSetPass";
            this.btnSetPass.Size = new System.Drawing.Size(75, 20);
            this.btnSetPass.TabIndex = 16;
            this.btnSetPass.Text = "Password";
            this.btnSetPass.UseVisualStyleBackColor = true;
            this.btnSetPass.Click += new System.EventHandler(this.btnSetPass_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Request";
            // 
            // txtRequsetDB
            // 
            this.txtRequsetDB.Location = new System.Drawing.Point(22, 259);
            this.txtRequsetDB.Name = "txtRequsetDB";
            this.txtRequsetDB.Size = new System.Drawing.Size(100, 20);
            this.txtRequsetDB.TabIndex = 19;
            // 
            // btnSentDBRequest
            // 
            this.btnSentDBRequest.Location = new System.Drawing.Point(128, 259);
            this.btnSentDBRequest.Name = "btnSentDBRequest";
            this.btnSentDBRequest.Size = new System.Drawing.Size(103, 20);
            this.btnSentDBRequest.TabIndex = 18;
            this.btnSentDBRequest.Text = "Send Request";
            this.btnSentDBRequest.UseVisualStyleBackColor = true;
            this.btnSentDBRequest.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // npgsqlDataAdapter1
            // 
            this.npgsqlDataAdapter1.DeleteCommand = null;
            this.npgsqlDataAdapter1.InsertCommand = null;
            this.npgsqlDataAdapter1.SelectCommand = null;
            this.npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // npgsqlConnection1
            // 
            this.npgsqlConnection1.ProvideClientCertificatesCallback = null;
            this.npgsqlConnection1.UserCertificateValidationCallback = null;
            // 
            // dbView
            // 
            this.dbView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbView.Location = new System.Drawing.Point(270, 21);
            this.dbView.Name = "dbView";
            this.dbView.Size = new System.Drawing.Size(367, 139);
            this.dbView.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // frmDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 379);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dbView);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRequsetDB);
            this.Controls.Add(this.btnSentDBRequest);
            this.Controls.Add(this.btnSetPass);
            this.Controls.Add(this.btnConnectDB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ePort);
            this.Controls.Add(this.btnSetPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eDB);
            this.Controls.Add(this.ePass);
            this.Controls.Add(this.eLogin);
            this.Controls.Add(this.eServer);
            this.Controls.Add(this.btnSetDB);
            this.Controls.Add(this.btnSetLogin);
            this.Controls.Add(this.btnSetSever);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data base connection";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmDataBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSetSever;
		private System.Windows.Forms.Button btnSetLogin;
		private System.Windows.Forms.Button btnSetDB;
		private System.Windows.Forms.TextBox eServer;
		private System.Windows.Forms.TextBox eLogin;
		private System.Windows.Forms.TextBox ePass;
		private System.Windows.Forms.TextBox eDB;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox ePort;
		private System.Windows.Forms.Button btnSetPort;
		private System.Windows.Forms.Button btnConnectDB;
		private System.Windows.Forms.Button btnSetPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRequsetDB;
        private System.Windows.Forms.Button btnSentDBRequest;
        private System.Data.DataSet dataSet1;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
        private Npgsql.NpgsqlConnection npgsqlConnection1;
        private System.Windows.Forms.DataGridView dbView;
        private System.Windows.Forms.Button button1;
    }
}