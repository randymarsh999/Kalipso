//================================================================================================== 
// 
// Title      : TcpipResourceVerifiicationUtility.cs 
// Copyright  : National Instruments 2002. All Rights Reserved. 
// Author     : Mika Fukuchi 
// Purpose    : This application shows the user how to verify the existance of
//				TCP/IP resources. Property TcpipResourceNames is a string array that	
//				contains the verified TCP/IP resource names.
// 
//================================================================================================== 

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using NationalInstruments.VisaNS;

namespace NationalInstruments.Examples.FindResources
{
	/// <summary>
	/// Summary description for TcpipResourceVerifiicationUtilityForm.
	/// </summary>
	public class TcpipResourceVerifiicationUtilityForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private System.Windows.Forms.GroupBox instrumentResourceGroupBox;
        private System.Windows.Forms.GroupBox socketResourceGroupBox;
        private System.Windows.Forms.Label deviceNameLabel;
        private System.Windows.Forms.Label portNumberLabel;
        private System.Windows.Forms.Button verifySocketButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ListBox resourcesVerifiedListBox;
        private System.Windows.Forms.Label resourcesVerifiedLabel;
        private System.Windows.Forms.TextBox boardInstrTextBox;
        private System.Windows.Forms.TextBox hostAddressInstrTextBox;
        private System.Windows.Forms.TextBox deviceNameTextBox;
        private System.Windows.Forms.TextBox boardSocketTextBox;
        private System.Windows.Forms.Label boardSocketLabel;
        private System.Windows.Forms.Label boardInstrLabel;
        private System.Windows.Forms.TextBox hostAddressSocketTextBox;
        private System.Windows.Forms.Label hostAddressSocketLabel;
        private System.Windows.Forms.Label hostAddressInstrLabel;
        private System.Windows.Forms.TextBox portNumberTextBox;
        private System.Windows.Forms.Label optionalLabel;
        private System.Windows.Forms.Button verifyInstrButton;

		public TcpipResourceVerifiicationUtilityForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TcpipResourceVerifiicationUtilityForm));
            this.resourcesVerifiedListBox = new System.Windows.Forms.ListBox();
            this.hostAddressInstrTextBox = new System.Windows.Forms.TextBox();
            this.deviceNameTextBox = new System.Windows.Forms.TextBox();
            this.hostAddressInstrLabel = new System.Windows.Forms.Label();
            this.portNumberLabel = new System.Windows.Forms.Label();
            this.hostAddressSocketTextBox = new System.Windows.Forms.TextBox();
            this.portNumberTextBox = new System.Windows.Forms.TextBox();
            this.hostAddressSocketLabel = new System.Windows.Forms.Label();
            this.deviceNameLabel = new System.Windows.Forms.Label();
            this.instrumentResourceGroupBox = new System.Windows.Forms.GroupBox();
            this.optionalLabel = new System.Windows.Forms.Label();
            this.boardInstrTextBox = new System.Windows.Forms.TextBox();
            this.boardInstrLabel = new System.Windows.Forms.Label();
            this.verifyInstrButton = new System.Windows.Forms.Button();
            this.socketResourceGroupBox = new System.Windows.Forms.GroupBox();
            this.boardSocketTextBox = new System.Windows.Forms.TextBox();
            this.boardSocketLabel = new System.Windows.Forms.Label();
            this.verifySocketButton = new System.Windows.Forms.Button();
            this.resourcesVerifiedLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.instrumentResourceGroupBox.SuspendLayout();
            this.socketResourceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // resourcesVerifiedListBox
            // 
            this.resourcesVerifiedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.resourcesVerifiedListBox.Location = new System.Drawing.Point(288, 48);
            this.resourcesVerifiedListBox.Name = "resourcesVerifiedListBox";
            this.resourcesVerifiedListBox.Size = new System.Drawing.Size(248, 251);
            this.resourcesVerifiedListBox.TabIndex = 0;
            // 
            // hostAddressInstrTextBox
            // 
            this.hostAddressInstrTextBox.Location = new System.Drawing.Point(112, 56);
            this.hostAddressInstrTextBox.Name = "hostAddressInstrTextBox";
            this.hostAddressInstrTextBox.Size = new System.Drawing.Size(128, 20);
            this.hostAddressInstrTextBox.TabIndex = 2;
            this.hostAddressInstrTextBox.Text = "";
            // 
            // deviceNameTextBox
            // 
            this.deviceNameTextBox.Location = new System.Drawing.Point(112, 88);
            this.deviceNameTextBox.Name = "deviceNameTextBox";
            this.deviceNameTextBox.Size = new System.Drawing.Size(128, 20);
            this.deviceNameTextBox.TabIndex = 3;
            this.deviceNameTextBox.Text = "";
            // 
            // hostAddressInstrLabel
            // 
            this.hostAddressInstrLabel.Location = new System.Drawing.Point(8, 56);
            this.hostAddressInstrLabel.Name = "hostAddressInstrLabel";
            this.hostAddressInstrLabel.Size = new System.Drawing.Size(88, 16);
            this.hostAddressInstrLabel.TabIndex = 4;
            this.hostAddressInstrLabel.Text = "Host Address:";
            // 
            // portNumberLabel
            // 
            this.portNumberLabel.Location = new System.Drawing.Point(8, 88);
            this.portNumberLabel.Name = "portNumberLabel";
            this.portNumberLabel.Size = new System.Drawing.Size(72, 16);
            this.portNumberLabel.TabIndex = 5;
            this.portNumberLabel.Text = "Port Number:";
            // 
            // hostAddressSocketTextBox
            // 
            this.hostAddressSocketTextBox.Location = new System.Drawing.Point(112, 56);
            this.hostAddressSocketTextBox.Name = "hostAddressSocketTextBox";
            this.hostAddressSocketTextBox.Size = new System.Drawing.Size(128, 20);
            this.hostAddressSocketTextBox.TabIndex = 6;
            this.hostAddressSocketTextBox.Text = "";
            // 
            // portNumberTextBox
            // 
            this.portNumberTextBox.Location = new System.Drawing.Point(112, 88);
            this.portNumberTextBox.Name = "portNumberTextBox";
            this.portNumberTextBox.Size = new System.Drawing.Size(128, 20);
            this.portNumberTextBox.TabIndex = 7;
            this.portNumberTextBox.Text = "";
            // 
            // hostAddressSocketLabel
            // 
            this.hostAddressSocketLabel.Location = new System.Drawing.Point(8, 56);
            this.hostAddressSocketLabel.Name = "hostAddressSocketLabel";
            this.hostAddressSocketLabel.Size = new System.Drawing.Size(88, 24);
            this.hostAddressSocketLabel.TabIndex = 8;
            this.hostAddressSocketLabel.Text = "Host Address:";
            // 
            // deviceNameLabel
            // 
            this.deviceNameLabel.Location = new System.Drawing.Point(8, 88);
            this.deviceNameLabel.Name = "deviceNameLabel";
            this.deviceNameLabel.Size = new System.Drawing.Size(104, 16);
            this.deviceNameLabel.TabIndex = 9;
            this.deviceNameLabel.Text = "LAN Device Name:";
            // 
            // instrumentResourceGroupBox
            // 
            this.instrumentResourceGroupBox.Controls.Add(this.optionalLabel);
            this.instrumentResourceGroupBox.Controls.Add(this.boardInstrTextBox);
            this.instrumentResourceGroupBox.Controls.Add(this.boardInstrLabel);
            this.instrumentResourceGroupBox.Controls.Add(this.verifyInstrButton);
            this.instrumentResourceGroupBox.Controls.Add(this.deviceNameTextBox);
            this.instrumentResourceGroupBox.Controls.Add(this.deviceNameLabel);
            this.instrumentResourceGroupBox.Controls.Add(this.hostAddressInstrLabel);
            this.instrumentResourceGroupBox.Controls.Add(this.hostAddressInstrTextBox);
            this.instrumentResourceGroupBox.Location = new System.Drawing.Point(16, 16);
            this.instrumentResourceGroupBox.Name = "instrumentResourceGroupBox";
            this.instrumentResourceGroupBox.Size = new System.Drawing.Size(256, 152);
            this.instrumentResourceGroupBox.TabIndex = 10;
            this.instrumentResourceGroupBox.TabStop = false;
            this.instrumentResourceGroupBox.Text = "TCP/IP Instrument Resource";
            // 
            // optionalLabel
            // 
            this.optionalLabel.Location = new System.Drawing.Point(8, 104);
            this.optionalLabel.Name = "optionalLabel";
            this.optionalLabel.Size = new System.Drawing.Size(56, 16);
            this.optionalLabel.TabIndex = 17;
            this.optionalLabel.Text = "(optional)";
            // 
            // boardInstrTextBox
            // 
            this.boardInstrTextBox.Location = new System.Drawing.Point(112, 24);
            this.boardInstrTextBox.Name = "boardInstrTextBox";
            this.boardInstrTextBox.Size = new System.Drawing.Size(128, 20);
            this.boardInstrTextBox.TabIndex = 16;
            this.boardInstrTextBox.Text = "";
            // 
            // boardInstrLabel
            // 
            this.boardInstrLabel.Location = new System.Drawing.Point(8, 24);
            this.boardInstrLabel.Name = "boardInstrLabel";
            this.boardInstrLabel.Size = new System.Drawing.Size(88, 16);
            this.boardInstrLabel.TabIndex = 15;
            this.boardInstrLabel.Text = "Board (optional):";
            // 
            // verifyInstrButton
            // 
            this.verifyInstrButton.Location = new System.Drawing.Point(96, 120);
            this.verifyInstrButton.Name = "verifyInstrButton";
            this.verifyInstrButton.TabIndex = 13;
            this.verifyInstrButton.Text = "Verify";
            this.verifyInstrButton.Click += new System.EventHandler(this.verifyInstrButton_Click);
            // 
            // socketResourceGroupBox
            // 
            this.socketResourceGroupBox.Controls.Add(this.boardSocketTextBox);
            this.socketResourceGroupBox.Controls.Add(this.boardSocketLabel);
            this.socketResourceGroupBox.Controls.Add(this.verifySocketButton);
            this.socketResourceGroupBox.Controls.Add(this.hostAddressSocketTextBox);
            this.socketResourceGroupBox.Controls.Add(this.portNumberTextBox);
            this.socketResourceGroupBox.Controls.Add(this.portNumberLabel);
            this.socketResourceGroupBox.Controls.Add(this.hostAddressSocketLabel);
            this.socketResourceGroupBox.Location = new System.Drawing.Point(16, 184);
            this.socketResourceGroupBox.Name = "socketResourceGroupBox";
            this.socketResourceGroupBox.Size = new System.Drawing.Size(256, 152);
            this.socketResourceGroupBox.TabIndex = 11;
            this.socketResourceGroupBox.TabStop = false;
            this.socketResourceGroupBox.Text = "TCP/IP Socket Resource";
            // 
            // boardSocketTextBox
            // 
            this.boardSocketTextBox.Location = new System.Drawing.Point(112, 24);
            this.boardSocketTextBox.Name = "boardSocketTextBox";
            this.boardSocketTextBox.Size = new System.Drawing.Size(128, 20);
            this.boardSocketTextBox.TabIndex = 10;
            this.boardSocketTextBox.Text = "";
            // 
            // boardSocketLabel
            // 
            this.boardSocketLabel.Location = new System.Drawing.Point(8, 24);
            this.boardSocketLabel.Name = "boardSocketLabel";
            this.boardSocketLabel.Size = new System.Drawing.Size(88, 16);
            this.boardSocketLabel.TabIndex = 9;
            this.boardSocketLabel.Text = "Board (optional):";
            // 
            // verifySocketButton
            // 
            this.verifySocketButton.Location = new System.Drawing.Point(96, 120);
            this.verifySocketButton.Name = "verifySocketButton";
            this.verifySocketButton.TabIndex = 0;
            this.verifySocketButton.Text = "Verify";
            this.verifySocketButton.Click += new System.EventHandler(this.verifySocketButton_Click);
            // 
            // resourcesVerifiedLabel
            // 
            this.resourcesVerifiedLabel.Location = new System.Drawing.Point(288, 24);
            this.resourcesVerifiedLabel.Name = "resourcesVerifiedLabel";
            this.resourcesVerifiedLabel.Size = new System.Drawing.Size(144, 16);
            this.resourcesVerifiedLabel.TabIndex = 12;
            this.resourcesVerifiedLabel.Text = "TCP/IP Resources Verified:";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(464, 312);
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 13;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // TcpipResourceVerifiicationUtilityForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(560, 357);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.resourcesVerifiedLabel);
            this.Controls.Add(this.resourcesVerifiedListBox);
            this.Controls.Add(this.instrumentResourceGroupBox);
            this.Controls.Add(this.socketResourceGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(560, 328);
            this.Name = "TcpipResourceVerifiicationUtilityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TCP/IP Resource Verification Utility";
            this.instrumentResourceGroupBox.ResumeLayout(false);
            this.socketResourceGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

		private void verifyInstrButton_Click(object sender, System.EventArgs e)
		{
			string resourceName;
			
			if (boardInstrTextBox.TextLength == 0)
			{
				resourceName = "TCPIP::" + hostAddressInstrTextBox.Text;
			}
			else
			{
				resourceName = "TCPIP" + boardInstrTextBox.Text + "::" + hostAddressInstrTextBox.Text;
			}
 
			if (deviceNameTextBox.TextLength == 0)
			{
				resourceName += "::INSTR";
			}
			else
			{
				resourceName += "::" + deviceNameTextBox.Text + "::INSTR";
			}

			VerifyAndUpdateResourcename(resourceName);
		}

		private void verifySocketButton_Click(object sender, System.EventArgs e)
		{
			string resourceName;
			
			if (boardSocketTextBox.TextLength == 0)
			{
				resourceName = "TCPIP::" + hostAddressSocketTextBox.Text;
			}
			else
			{
				resourceName = "TCPIP" + boardSocketTextBox.Text + "::" + hostAddressSocketTextBox.Text;
			}
	
			resourceName += "::" + portNumberTextBox.Text + "::SOCKET";

			VerifyAndUpdateResourcename(resourceName);
		}

		private void VerifyAndUpdateResourcename(string resourceName)
		{
			string resourceFullName = ValidResourceName(resourceName);
			if (resourceFullName != null)
			{
				if (!resourcesVerifiedListBox.Items.Contains(resourceFullName))
				{
					resourcesVerifiedListBox.Items.Add(resourceFullName);
				}
			}
			else
			{
				MessageBox.Show("Invalid Resource Name");
			}
		}

		// Returns the full name of the resource if it is valid. If it's
		// an invalid resource name, it returns null.
		private string ValidResourceName(string resourceName)
		{
			Session session = null;
			string fullName = null;
			try
			{
				session = ResourceManager.GetLocalManager().Open(resourceName);
				fullName = session.ResourceName;
			}
			catch (VisaException)
			{
				// Don't do anything
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			if (session != null)
			{
				session.Dispose();
			}

			return fullName;
		}

		private void okButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		public string[] TcpipResourceNames
		{
			get
			{
				string[] resourceNames = new String[resourcesVerifiedListBox.Items.Count];
				resourcesVerifiedListBox
                    .Items.CopyTo(resourceNames, 0);
				return resourceNames;
			}
		}
	}	
}
