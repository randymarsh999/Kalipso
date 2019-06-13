'================================================================================================== 
' 
' Title      : MainForm.vb 
' Purpose    : This application shows the user how to use ResourceManager to 
'				find all of the available resources on their system. In the example, 
'				they can select between several filters to narrow the list. Public
'				property ResourceName contains the resource name selected in tvwResourceTree
' 
'================================================================================================== 
Imports NationalInstruments.VisaNS


Namespace NationalInstruments.Examples.FindResources


    Public Class MainForm
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            ndGpib = New TreeNode("GPIB")
            ndVxi = New TreeNode("VXI")
            ndGpibVxi = New TreeNode("GPIB VXI")
            ndSerial = New TreeNode("Serial")
            ndPxi = New TreeNode("PXI")
            ndTcpip = New TreeNode("TCP/IP")
            ndUSB = New TreeNode("USB")
            ndFireWire = New TreeNode("FireWire")
            CleanResourceNodes()

            PopulateFilterList()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents filterStringLabel As System.Windows.Forms.Label
        Friend WithEvents useCustomStringButton As System.Windows.Forms.Button
        Friend WithEvents filterStringsListBox As System.Windows.Forms.ListBox
        Friend WithEvents findResourcesButton As System.Windows.Forms.Button
        Friend WithEvents findTcpipResourcesButton As System.Windows.Forms.Button
        Friend WithEvents clearButton As System.Windows.Forms.Button
        Friend WithEvents availableResourcesLabel As System.Windows.Forms.Label
        Friend WithEvents resourceTreeView As System.Windows.Forms.TreeView
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainForm))
            Me.filterStringLabel = New System.Windows.Forms.Label
            Me.availableResourcesLabel = New System.Windows.Forms.Label
            Me.filterStringsListBox = New System.Windows.Forms.ListBox
            Me.resourceTreeView = New System.Windows.Forms.TreeView
            Me.findResourcesButton = New System.Windows.Forms.Button
            Me.findTcpipResourcesButton = New System.Windows.Forms.Button
            Me.clearButton = New System.Windows.Forms.Button
            Me.useCustomStringButton = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'filterStringLabel
            '
            Me.filterStringLabel.Location = New System.Drawing.Point(16, 24)
            Me.filterStringLabel.Name = "filterStringLabel"
            Me.filterStringLabel.Size = New System.Drawing.Size(96, 16)
            Me.filterStringLabel.TabIndex = 0
            Me.filterStringLabel.Text = "Filter String:"
            '
            'availableResourcesLabel
            '
            Me.availableResourcesLabel.Location = New System.Drawing.Point(16, 216)
            Me.availableResourcesLabel.Name = "availableResourcesLabel"
            Me.availableResourcesLabel.Size = New System.Drawing.Size(152, 16)
            Me.availableResourcesLabel.TabIndex = 1
            Me.availableResourcesLabel.Text = "Available Resources Found:"
            '
            'filterStringsListBox
            '
            Me.filterStringsListBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.filterStringsListBox.Location = New System.Drawing.Point(16, 40)
            Me.filterStringsListBox.Name = "filterStringsListBox"
            Me.filterStringsListBox.Size = New System.Drawing.Size(248, 121)
            Me.filterStringsListBox.TabIndex = 2
            '
            'resourceTreeView
            '
            Me.resourceTreeView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.resourceTreeView.ImageIndex = -1
            Me.resourceTreeView.Location = New System.Drawing.Point(16, 232)
            Me.resourceTreeView.Name = "resourceTreeView"
            Me.resourceTreeView.SelectedImageIndex = -1
            Me.resourceTreeView.Size = New System.Drawing.Size(248, 136)
            Me.resourceTreeView.TabIndex = 3
            '
            'findResourcesButton
            '
            Me.findResourcesButton.Location = New System.Drawing.Point(16, 168)
            Me.findResourcesButton.Name = "findResourcesButton"
            Me.findResourcesButton.Size = New System.Drawing.Size(104, 24)
            Me.findResourcesButton.TabIndex = 4
            Me.findResourcesButton.Text = "Find Resources"
            '
            'findTcpipResourcesButton
            '
            Me.findTcpipResourcesButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.findTcpipResourcesButton.Location = New System.Drawing.Point(128, 168)
            Me.findTcpipResourcesButton.Name = "findTcpipResourcesButton"
            Me.findTcpipResourcesButton.Size = New System.Drawing.Size(136, 23)
            Me.findTcpipResourcesButton.TabIndex = 5
            Me.findTcpipResourcesButton.Text = "Find TCP/IP Resources"
            '
            'clearButton
            '
            Me.clearButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.clearButton.Location = New System.Drawing.Point(192, 200)
            Me.clearButton.Name = "clearButton"
            Me.clearButton.Size = New System.Drawing.Size(72, 23)
            Me.clearButton.TabIndex = 6
            Me.clearButton.Text = "Clear"
            '
            'useCustomStringButton
            '
            Me.useCustomStringButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.useCustomStringButton.Location = New System.Drawing.Point(144, 8)
            Me.useCustomStringButton.Name = "useCustomStringButton"
            Me.useCustomStringButton.Size = New System.Drawing.Size(120, 24)
            Me.useCustomStringButton.TabIndex = 7
            Me.useCustomStringButton.Text = "Use Custom String"
            '
            'MainForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(280, 373)
            Me.Controls.Add(Me.useCustomStringButton)
            Me.Controls.Add(Me.clearButton)
            Me.Controls.Add(Me.findTcpipResourcesButton)
            Me.Controls.Add(Me.findResourcesButton)
            Me.Controls.Add(Me.resourceTreeView)
            Me.Controls.Add(Me.filterStringsListBox)
            Me.Controls.Add(Me.availableResourcesLabel)
            Me.Controls.Add(Me.filterStringLabel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimumSize = New System.Drawing.Size(288, 384)
            Me.Name = "MainForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Available Resouces List"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private ndGpib As TreeNode
        Private ndVxi As TreeNode
        Private ndGpibVxi As TreeNode
        Private ndSerial As TreeNode
        Private ndPxi As TreeNode
        Private ndTcpip As TreeNode
        Private ndUSB As TreeNode
        Private ndFireWire As TreeNode

        Private filter As String
        Private ndTcpipAdded As Boolean = False

        <STAThread()> _
        Public Shared Sub Main()
            Application.Run(New MainForm())
        End Sub

        Private Sub PopulateFilterList()
            filterStringsListBox.Items.Clear()
            filterStringsListBox.Items.Add("?*")
            filterStringsListBox.Items.Add("GPIB?*")
            filterStringsListBox.Items.Add("GPIB?*INSTR")
            filterStringsListBox.Items.Add("GPIB?*INTFC")
            filterStringsListBox.Items.Add("GPIB?*SERVANT")
            filterStringsListBox.Items.Add("GPIB-VXI?*")
            filterStringsListBox.Items.Add("GPIB-VXI?*INSTR")
            filterStringsListBox.Items.Add("GPIB-VXI?*MEMACC")
            filterStringsListBox.Items.Add("GPIB-VXI?*BACKPLANE")
            filterStringsListBox.Items.Add("PXI?*INSTR")
            filterStringsListBox.Items.Add("ASRL?*INSTR")
            filterStringsListBox.Items.Add("VXI?*")
            filterStringsListBox.Items.Add("VXI?*INSTR")
            filterStringsListBox.Items.Add("VXI?*MEMACC")
            filterStringsListBox.Items.Add("VXI?*BACKPLANE")
            filterStringsListBox.Items.Add("VXI?*SERVANT")
            filterStringsListBox.Items.Add("USB?*")
            filterStringsListBox.Items.Add("FIREWIRE?*")

            filterStringsListBox.SelectedIndex = 0
        End Sub

        Private Sub AddToResourceTree()
            If ndGpib.Nodes.Count <> 0 Then
                resourceTreeView.Nodes.Add(ndGpib)
            End If
            If ndVxi.Nodes.Count <> 0 Then
                resourceTreeView.Nodes.Add(ndVxi)
            End If
            If ndGpibVxi.Nodes.Count <> 0 Then
                resourceTreeView.Nodes.Add(ndGpibVxi)
            End If
            If ndSerial.Nodes.Count <> 0 Then
                resourceTreeView.Nodes.Add(ndSerial)
            End If
            If ndPxi.Nodes.Count <> 0 Then
                resourceTreeView.Nodes.Add(ndPxi)
            End If
            If ndUSB.Nodes.Count <> 0 Then
                resourceTreeView.Nodes.Add(ndUSB)
            End If
            If ndFireWire.Nodes.Count <> 0 Then
                resourceTreeView.Nodes.Add(ndFireWire)
            End If
        End Sub

        Private Sub AddToResourceNode(ByVal resourceName As String, ByVal intType As HardwareInterfaceType)
            Select Case intType
                Case HardwareInterfaceType.Gpib
                    ndGpib.Nodes.Add(New TreeNode(resourceName))
                Case HardwareInterfaceType.Vxi
                    ndVxi.Nodes.Add(New TreeNode(resourceName))
                Case HardwareInterfaceType.GpibVxi
                    ndGpibVxi.Nodes.Add(New TreeNode(resourceName))
                Case HardwareInterfaceType.Serial
                    ndSerial.Nodes.Add(New TreeNode(resourceName))
                Case HardwareInterfaceType.Pxi
                    ndPxi.Nodes.Add(New TreeNode(resourceName))
                Case HardwareInterfaceType.Tcpip
                    ndTcpip.Nodes.Add(New TreeNode(resourceName))
                Case HardwareInterfaceType.Usb
                    ndUSB.Nodes.Add(New TreeNode(resourceName))
                Case HardwareInterfaceType.Firewire
                    ndFireWire.Nodes.Add(New TreeNode(resourceName))
            End Select
        End Sub

        Private Sub findTcpipResourcesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles findTcpipResourcesButton.Click
            Dim trf As TcpipResourceVerifiicationUtilityForm = New TcpipResourceVerifiicationUtilityForm
            trf.ShowDialog()

            If trf.TcpipResourceNames.Length <> 0 _
            And (Not ndTcpipAdded Or resourceTreeView.Nodes.Count = 0) Then
                resourceTreeView.Nodes.Add(ndTcpip)
                ndTcpipAdded = True
            End If

            Dim s As String
            For Each s In trf.TcpipResourceNames
                If (Not InResourceTree(s)) Then
                    AddToResourceNode(s, HardwareInterfaceType.Tcpip)
                End If
            Next

            ndTcpip.ExpandAll()
        End Sub

        Private Function InResourceTree(ByVal resource As String) As Boolean
            Dim nd As TreeNode
            For Each nd In ndTcpip.Nodes
                If nd.Text = resource Then
                    Return True
                End If
            Next

            Return False
        End Function

        Private Sub FindResources()
            Try
                Dim resources As String() = ResourceManager.GetLocalManager().FindResources(filter)

                If resources.Length = 0 Then
                    MessageBox.Show("There was no resource found on your system.")
                End If

                Dim s As String
                For Each s In resources
                    Dim intType As HardwareInterfaceType
                    Dim intNum As Short
                    ResourceManager.GetLocalManager().ParseResource(s, intType, intNum)
                    AddToResourceNode(s, intType)
                Next

                AddToResourceTree()
            Catch ex As VisaException
                ' Don't do anything
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Sub CleanResourceNodes()
            ndGpib.Nodes.Clear()
            ndVxi.Nodes.Clear()
            ndGpibVxi.Nodes.Clear()
            ndSerial.Nodes.Clear()
            ndPxi.Nodes.Clear()
            ndTcpip.Nodes.Clear()
            ndUSB.Nodes.Clear()
            ndFireWire.Nodes.Clear()
        End Sub

        Private Sub findResourcesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles findResourcesButton.Click
            filter = filterStringsListBox.Text
            DisplayResources()
        End Sub

        Private Function getCustomFilter() As String
            Dim cff As CustomFilterForm = New CustomFilterForm
            cff.ShowDialog()
            Return cff.CustomFilter
        End Function

        Private Sub clearButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearButton.Click
            resourceTreeView.Nodes.Clear()
            CleanResourceNodes()
        End Sub

        Private Sub useCustomStringButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles useCustomStringButton.Click
            filter = getCustomFilter()
            DisplayResources()
        End Sub

        Private Sub DisplayResources()
            resourceTreeView.Nodes.Clear()
            ndTcpipAdded = False
            CleanResourceNodes()
            FindResources()
            resourceTreeView.ExpandAll()
        End Sub

        Public ReadOnly Property ResourceName() As String
            Get
                Try
                    Return resourceTreeView.SelectedNode.Text
                Catch ex As Exception
                    Return ""
                End Try
            End Get
        End Property

    End Class
End Namespace
