//================================================================================================== 
// 
// Title      : MainForm.cs 
// Purpose    : This application shows the user how to use ResourceManager to 
//              find all of the available resources on their system. In the example, 
//              they can select between several filters to narrow the list. Public
//              property ResourceName contains the resource name selected in tvwResourceTree
// 
//================================================================================================== 

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using NationalInstruments.VisaNS;

namespace NationalInstruments.Examples.FindResources
{
    /// <summary>
    /// This application shows the user how to use ResourceManager to 
    /// find all of the available resources on their system.  In the 
    /// example, they can select between several filters to narrow the 
    /// list.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {

        private TreeNode ndGpib;
        private TreeNode ndVxi;
        private TreeNode ndGpibVxi;
        private TreeNode ndSerial;
        private TreeNode ndPxi;
        private TreeNode ndTcpip;
        private TreeNode ndUSB;
        private TreeNode ndFireWire;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private string filter;
        private System.Windows.Forms.Button useCustomStringButton;
        private System.Windows.Forms.Label filterStringLabel;
        private System.Windows.Forms.Button findResourcesButton;
        private System.Windows.Forms.Button findTcpipResourcesButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label availableResourcesLabel;
        private System.Windows.Forms.ListBox filterStringsListBox;
        private System.Windows.Forms.TreeView resourceTreeView;
        private bool ndTcpipAdded = false;

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            ndGpib = new TreeNode("GPIB");
            ndVxi = new TreeNode("VXI");
            ndGpibVxi = new TreeNode("GPIB VXI");
            ndSerial = new TreeNode("Serial");
            ndPxi = new TreeNode("PXI");
            ndTcpip = new TreeNode("TCP/IP");
            ndUSB = new TreeNode("USB");
            ndFireWire = new TreeNode("FireWire");
            CleanResourceNodes();

            PopulateFilterList();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
            this.availableResourcesLabel = new System.Windows.Forms.Label();
            this.findTcpipResourcesButton = new System.Windows.Forms.Button();
            this.resourceTreeView = new System.Windows.Forms.TreeView();
            this.findResourcesButton = new System.Windows.Forms.Button();
            this.filterStringsListBox = new System.Windows.Forms.ListBox();
            this.filterStringLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.useCustomStringButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // availableResourcesLabel
            // 
            this.availableResourcesLabel.Location = new System.Drawing.Point(16, 216);
            this.availableResourcesLabel.Name = "availableResourcesLabel";
            this.availableResourcesLabel.Size = new System.Drawing.Size(152, 16);
            this.availableResourcesLabel.TabIndex = 0;
            this.availableResourcesLabel.Text = "Available Resources Found:";
            // 
            // findTcpipResourcesButton
            // 
            this.findTcpipResourcesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findTcpipResourcesButton.Location = new System.Drawing.Point(128, 168);
            this.findTcpipResourcesButton.Name = "findTcpipResourcesButton";
            this.findTcpipResourcesButton.Size = new System.Drawing.Size(136, 23);
            this.findTcpipResourcesButton.TabIndex = 4;
            this.findTcpipResourcesButton.Text = "Find TCP/IP Resources";
            this.findTcpipResourcesButton.Click += new System.EventHandler(this.findTcpipResourcesButton_Click);
            // 
            // resourceTreeView
            // 
            this.resourceTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.resourceTreeView.ImageIndex = -1;
            this.resourceTreeView.Location = new System.Drawing.Point(16, 232);
            this.resourceTreeView.Name = "resourceTreeView";
            this.resourceTreeView.SelectedImageIndex = -1;
            this.resourceTreeView.Size = new System.Drawing.Size(248, 136);
            this.resourceTreeView.TabIndex = 5;
            // 
            // findResourcesButton
            // 
            this.findResourcesButton.Location = new System.Drawing.Point(16, 168);
            this.findResourcesButton.Name = "findResourcesButton";
            this.findResourcesButton.Size = new System.Drawing.Size(104, 23);
            this.findResourcesButton.TabIndex = 8;
            this.findResourcesButton.Text = "Find Resources";
            this.findResourcesButton.Click += new System.EventHandler(this.findResourcesButton_Click);
            // 
            // filterStringsListBox
            // 
            this.filterStringsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.filterStringsListBox.Location = new System.Drawing.Point(16, 40);
            this.filterStringsListBox.Name = "filterStringsListBox";
            this.filterStringsListBox.Size = new System.Drawing.Size(248, 121);
            this.filterStringsListBox.TabIndex = 9;
            // 
            // filterStringLabel
            // 
            this.filterStringLabel.Location = new System.Drawing.Point(16, 24);
            this.filterStringLabel.Name = "filterStringLabel";
            this.filterStringLabel.Size = new System.Drawing.Size(72, 16);
            this.filterStringLabel.TabIndex = 10;
            this.filterStringLabel.Text = "Filter String:";
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(192, 200);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(72, 24);
            this.clearButton.TabIndex = 11;
            this.clearButton.Text = "Clear";
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // useCustomStringButton
            // 
            this.useCustomStringButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.useCustomStringButton.Location = new System.Drawing.Point(152, 8);
            this.useCustomStringButton.Name = "useCustomStringButton";
            this.useCustomStringButton.Size = new System.Drawing.Size(112, 24);
            this.useCustomStringButton.TabIndex = 12;
            this.useCustomStringButton.Text = "Use Custom String";
            this.useCustomStringButton.Click += new System.EventHandler(this.useCustomStringButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(280, 373);
            this.Controls.Add(this.useCustomStringButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.filterStringLabel);
            this.Controls.Add(this.filterStringsListBox);
            this.Controls.Add(this.findResourcesButton);
            this.Controls.Add(this.resourceTreeView);
            this.Controls.Add(this.findTcpipResourcesButton);
            this.Controls.Add(this.availableResourcesLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(288, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Available Resouces List";
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new MainForm());
        }

        private void PopulateFilterList()
        {
            filterStringsListBox.Items.Clear();
            filterStringsListBox.Items.Add("?*");
            filterStringsListBox.Items.Add("GPIB?*");
            filterStringsListBox.Items.Add("GPIB?*INSTR");
            filterStringsListBox.Items.Add("GPIB?*INTFC");
            filterStringsListBox.Items.Add("GPIB?*SERVANT");
            filterStringsListBox.Items.Add("GPIB-VXI?*");
            filterStringsListBox.Items.Add("GPIB-VXI?*INSTR");
            filterStringsListBox.Items.Add("GPIB-VXI?*MEMACC");
            filterStringsListBox.Items.Add("GPIB-VXI?*BACKPLANE");
            filterStringsListBox.Items.Add("PXI?*INSTR");
            filterStringsListBox.Items.Add("ASRL?*INSTR");
            filterStringsListBox.Items.Add("VXI?*");
            filterStringsListBox.Items.Add("VXI?*INSTR");
            filterStringsListBox.Items.Add("VXI?*MEMACC");
            filterStringsListBox.Items.Add("VXI?*BACKPLANE");
            filterStringsListBox.Items.Add("VXI?*SERVANT");
            filterStringsListBox.Items.Add("USB?*");
            filterStringsListBox.Items.Add("FIREWIRE?*");
            filterStringsListBox.SelectedIndex = 0;
        }
        
        private void AddToResourceTree()
        {
            if (ndGpib.Nodes.Count != 0)
                resourceTreeView.Nodes.Add(ndGpib);
            if (ndVxi.Nodes.Count != 0)
                resourceTreeView.Nodes.Add(ndVxi);
            if (ndGpibVxi.Nodes.Count != 0)
                resourceTreeView.Nodes.Add(ndGpibVxi);
            if (ndSerial.Nodes.Count != 0)
                resourceTreeView.Nodes.Add(ndSerial);
            if (ndPxi.Nodes.Count != 0)
                resourceTreeView.Nodes.Add(ndPxi);
            if (ndUSB.Nodes.Count != 0)
                resourceTreeView.Nodes.Add(ndUSB);
            if (ndFireWire.Nodes.Count != 0)
                resourceTreeView.Nodes.Add(ndFireWire);
        }

        private void AddToResourceNode(string resourceName, HardwareInterfaceType intType)
        {
            switch (intType)
            {
                case HardwareInterfaceType.Gpib:
                    ndGpib.Nodes.Add(new TreeNode(resourceName));
                    break;
                case HardwareInterfaceType.Vxi:
                    ndVxi.Nodes.Add(new TreeNode(resourceName));
                    break;
                case HardwareInterfaceType.GpibVxi:
                    ndGpibVxi.Nodes.Add(new TreeNode(resourceName));
                    break;
                case HardwareInterfaceType.Serial:
                    ndSerial.Nodes.Add(new TreeNode(resourceName));
                    break;
                case HardwareInterfaceType.Pxi:
                    ndPxi.Nodes.Add(new TreeNode(resourceName));
                    break;
                case HardwareInterfaceType.Tcpip:
                    ndTcpip.Nodes.Add(new TreeNode(resourceName));
                    break;
                case HardwareInterfaceType.Usb:
                    ndUSB.Nodes.Add(new TreeNode(resourceName));
                    break;
                case HardwareInterfaceType.Firewire:
                    ndFireWire.Nodes.Add(new TreeNode(resourceName));
                    break;
                default:
                    break;
            }
        }

        private void findTcpipResourcesButton_Click(object sender, System.EventArgs e)
        {
            TcpipResourceVerifiicationUtilityForm trf = new TcpipResourceVerifiicationUtilityForm();
            trf.ShowDialog();

            if (trf.TcpipResourceNames.Length != 0 
                && (!ndTcpipAdded || resourceTreeView.Nodes.Count == 0))
            {
                resourceTreeView.Nodes.Add(ndTcpip);
                ndTcpipAdded = true;
            }

            foreach (string s in trf.TcpipResourceNames)
            {
                if (!InResourceTree(s))
                {
                    AddToResourceNode(s, HardwareInterfaceType.Tcpip);
                }
            }

            ndTcpip.ExpandAll();
        }

        private bool InResourceTree(string resource)
        {
            foreach(TreeNode nd in ndTcpip.Nodes)
            {
                if (nd.Text == resource)
                    return true;
            }

            return false;
        }

        private void FindResources()
        {
            try
            {
                string[] resources = ResourceManager.GetLocalManager().FindResources(filter);
 
                if (resources.Length == 0)
                {
                    MessageBox.Show("There was no resource found on your system.");
                }

                foreach(string s in resources)
                {
                    HardwareInterfaceType intType;
                    short intNum;
                    ResourceManager.GetLocalManager().ParseResource(s, out intType, out intNum);
                    AddToResourceNode(s, intType);
                }
                AddToResourceTree();
            }
            catch(VisaException)
            {
                // Don't do anything
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CleanResourceNodes()
        {
            ndGpib.Nodes.Clear();
            ndVxi.Nodes.Clear();
            ndGpibVxi.Nodes.Clear();
            ndSerial.Nodes.Clear();
            ndPxi.Nodes.Clear();
            ndTcpip.Nodes.Clear();
            ndUSB.Nodes.Clear();
            ndFireWire.Nodes.Clear();
        }

        private void findResourcesButton_Click(object sender, System.EventArgs e)
        {
            filter = filterStringsListBox.Text;
            DisplayResources();
        }

        private string getCustomFilter()
        {
            CustomFilterForm cff = new CustomFilterForm();
            cff.ShowDialog();
            return cff.CustomFilter;
        }

        private void clearButton_Click(object sender, System.EventArgs e)
        {
            resourceTreeView.Nodes.Clear(); 
            CleanResourceNodes();
        }

        private void useCustomStringButton_Click(object sender, System.EventArgs e)
        {
            filter = getCustomFilter();
            DisplayResources();
        }

        private void DisplayResources()
        {
            resourceTreeView.Nodes.Clear(); 
            ndTcpipAdded = false;
            CleanResourceNodes();
            FindResources();        
            resourceTreeView.ExpandAll();       
        }

        public string ResourceName
        {
            get
            {
                try
                {
                    return resourceTreeView.SelectedNode.Text;
                }
                catch(Exception)
                {
                    return "";
                }
            }
        }   
    }
}
