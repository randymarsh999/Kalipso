'================================================================================================== 
' 
' Title      : TcpipResourceVerifiicationUtility.cs 
' Copyright  : National Instruments 2002. All Rights Reserved. 
' Author     : Mika Fukuchi 
' Purpose    : This application shows the user how to verify the existance of
'				TCP/IP resources. Property TcpipResourceNames is a string array that	
'				contains the verified TCP/IP resource names.
' 
'================================================================================================== 
Imports NationalInstruments.VisaNS

Public Class TcpipResourceVerifiicationUtilityForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents instrumentResourceGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents socketResourceGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents boardInstrLabel As System.Windows.Forms.Label
    Friend WithEvents hostAddressInstrLabel As System.Windows.Forms.Label
    Friend WithEvents deviceNameLabel As System.Windows.Forms.Label
    Friend WithEvents optionalLabel As System.Windows.Forms.Label
    Friend WithEvents verifyInstrButton As System.Windows.Forms.Button
    Friend WithEvents boardInstrTextBox As System.Windows.Forms.TextBox
    Friend WithEvents hostAddressInstrTextBox As System.Windows.Forms.TextBox
    Friend WithEvents deviceNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents resourcesVerifiedLabel As System.Windows.Forms.Label
    Friend WithEvents resourcesVerifiedListBox As System.Windows.Forms.ListBox
    Friend WithEvents okButton As System.Windows.Forms.Button
    Friend WithEvents hostAddressSocketLabel As System.Windows.Forms.Label
    Friend WithEvents boardSocketLabel As System.Windows.Forms.Label
    Friend WithEvents portNumberLabel As System.Windows.Forms.Label
    Friend WithEvents boardSocketTextBox As System.Windows.Forms.TextBox
    Friend WithEvents hostAddressSocketTextBox As System.Windows.Forms.TextBox
    Friend WithEvents portNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents verifySocketButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TcpipResourceVerifiicationUtilityForm))
        Me.instrumentResourceGroupBox = New System.Windows.Forms.GroupBox
        Me.optionalLabel = New System.Windows.Forms.Label
        Me.verifyInstrButton = New System.Windows.Forms.Button
        Me.deviceNameTextBox = New System.Windows.Forms.TextBox
        Me.hostAddressInstrTextBox = New System.Windows.Forms.TextBox
        Me.boardInstrTextBox = New System.Windows.Forms.TextBox
        Me.deviceNameLabel = New System.Windows.Forms.Label
        Me.hostAddressInstrLabel = New System.Windows.Forms.Label
        Me.boardInstrLabel = New System.Windows.Forms.Label
        Me.socketResourceGroupBox = New System.Windows.Forms.GroupBox
        Me.portNumberTextBox = New System.Windows.Forms.TextBox
        Me.hostAddressSocketTextBox = New System.Windows.Forms.TextBox
        Me.boardSocketTextBox = New System.Windows.Forms.TextBox
        Me.verifySocketButton = New System.Windows.Forms.Button
        Me.portNumberLabel = New System.Windows.Forms.Label
        Me.hostAddressSocketLabel = New System.Windows.Forms.Label
        Me.boardSocketLabel = New System.Windows.Forms.Label
        Me.resourcesVerifiedLabel = New System.Windows.Forms.Label
        Me.resourcesVerifiedListBox = New System.Windows.Forms.ListBox
        Me.okButton = New System.Windows.Forms.Button
        Me.instrumentResourceGroupBox.SuspendLayout()
        Me.socketResourceGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'instrumentResourceGroupBox
        '
        Me.instrumentResourceGroupBox.Controls.Add(Me.optionalLabel)
        Me.instrumentResourceGroupBox.Controls.Add(Me.verifyInstrButton)
        Me.instrumentResourceGroupBox.Controls.Add(Me.deviceNameTextBox)
        Me.instrumentResourceGroupBox.Controls.Add(Me.hostAddressInstrTextBox)
        Me.instrumentResourceGroupBox.Controls.Add(Me.boardInstrTextBox)
        Me.instrumentResourceGroupBox.Controls.Add(Me.deviceNameLabel)
        Me.instrumentResourceGroupBox.Controls.Add(Me.hostAddressInstrLabel)
        Me.instrumentResourceGroupBox.Controls.Add(Me.boardInstrLabel)
        Me.instrumentResourceGroupBox.Location = New System.Drawing.Point(16, 16)
        Me.instrumentResourceGroupBox.Name = "instrumentResourceGroupBox"
        Me.instrumentResourceGroupBox.Size = New System.Drawing.Size(256, 152)
        Me.instrumentResourceGroupBox.TabIndex = 0
        Me.instrumentResourceGroupBox.TabStop = False
        Me.instrumentResourceGroupBox.Text = "TCP/IP Instrument Resource"
        '
        'optionalLabel
        '
        Me.optionalLabel.Location = New System.Drawing.Point(8, 104)
        Me.optionalLabel.Name = "optionalLabel"
        Me.optionalLabel.Size = New System.Drawing.Size(64, 16)
        Me.optionalLabel.TabIndex = 7
        Me.optionalLabel.Text = "(optional)"
        '
        'verifyInstrButton
        '
        Me.verifyInstrButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.verifyInstrButton.Location = New System.Drawing.Point(96, 120)
        Me.verifyInstrButton.Name = "verifyInstrButton"
        Me.verifyInstrButton.Size = New System.Drawing.Size(72, 24)
        Me.verifyInstrButton.TabIndex = 6
        Me.verifyInstrButton.Text = "Verify"
        '
        'deviceNameTextBox
        '
        Me.deviceNameTextBox.Location = New System.Drawing.Point(112, 88)
        Me.deviceNameTextBox.Name = "deviceNameTextBox"
        Me.deviceNameTextBox.Size = New System.Drawing.Size(128, 20)
        Me.deviceNameTextBox.TabIndex = 5
        Me.deviceNameTextBox.Text = ""
        '
        'hostAddressInstrTextBox
        '
        Me.hostAddressInstrTextBox.Location = New System.Drawing.Point(112, 56)
        Me.hostAddressInstrTextBox.Name = "hostAddressInstrTextBox"
        Me.hostAddressInstrTextBox.Size = New System.Drawing.Size(128, 20)
        Me.hostAddressInstrTextBox.TabIndex = 4
        Me.hostAddressInstrTextBox.Text = ""
        '
        'boardInstrTextBox
        '
        Me.boardInstrTextBox.Location = New System.Drawing.Point(112, 24)
        Me.boardInstrTextBox.Name = "boardInstrTextBox"
        Me.boardInstrTextBox.Size = New System.Drawing.Size(128, 20)
        Me.boardInstrTextBox.TabIndex = 3
        Me.boardInstrTextBox.Text = ""
        '
        'deviceNameLabel
        '
        Me.deviceNameLabel.Location = New System.Drawing.Point(8, 88)
        Me.deviceNameLabel.Name = "deviceNameLabel"
        Me.deviceNameLabel.Size = New System.Drawing.Size(104, 16)
        Me.deviceNameLabel.TabIndex = 2
        Me.deviceNameLabel.Text = "LAN Device Name:"
        '
        'hostAddressInstrLabel
        '
        Me.hostAddressInstrLabel.Location = New System.Drawing.Point(8, 56)
        Me.hostAddressInstrLabel.Name = "hostAddressInstrLabel"
        Me.hostAddressInstrLabel.Size = New System.Drawing.Size(96, 16)
        Me.hostAddressInstrLabel.TabIndex = 1
        Me.hostAddressInstrLabel.Text = "Host Address:"
        '
        'boardInstrLabel
        '
        Me.boardInstrLabel.Location = New System.Drawing.Point(8, 24)
        Me.boardInstrLabel.Name = "boardInstrLabel"
        Me.boardInstrLabel.Size = New System.Drawing.Size(104, 16)
        Me.boardInstrLabel.TabIndex = 0
        Me.boardInstrLabel.Text = "Board (optional):"
        '
        'socketResourceGroupBox
        '
        Me.socketResourceGroupBox.Controls.Add(Me.portNumberTextBox)
        Me.socketResourceGroupBox.Controls.Add(Me.hostAddressSocketTextBox)
        Me.socketResourceGroupBox.Controls.Add(Me.boardSocketTextBox)
        Me.socketResourceGroupBox.Controls.Add(Me.verifySocketButton)
        Me.socketResourceGroupBox.Controls.Add(Me.portNumberLabel)
        Me.socketResourceGroupBox.Controls.Add(Me.hostAddressSocketLabel)
        Me.socketResourceGroupBox.Controls.Add(Me.boardSocketLabel)
        Me.socketResourceGroupBox.Location = New System.Drawing.Point(16, 184)
        Me.socketResourceGroupBox.Name = "socketResourceGroupBox"
        Me.socketResourceGroupBox.Size = New System.Drawing.Size(256, 152)
        Me.socketResourceGroupBox.TabIndex = 1
        Me.socketResourceGroupBox.TabStop = False
        Me.socketResourceGroupBox.Text = "TCP/IP Socket Resource"
        '
        'portNumberTextBox
        '
        Me.portNumberTextBox.Location = New System.Drawing.Point(112, 88)
        Me.portNumberTextBox.Name = "portNumberTextBox"
        Me.portNumberTextBox.Size = New System.Drawing.Size(128, 20)
        Me.portNumberTextBox.TabIndex = 6
        Me.portNumberTextBox.Text = ""
        '
        'hostAddressSocketTextBox
        '
        Me.hostAddressSocketTextBox.Location = New System.Drawing.Point(112, 56)
        Me.hostAddressSocketTextBox.Name = "hostAddressSocketTextBox"
        Me.hostAddressSocketTextBox.Size = New System.Drawing.Size(128, 20)
        Me.hostAddressSocketTextBox.TabIndex = 5
        Me.hostAddressSocketTextBox.Text = ""
        '
        'boardSocketTextBox
        '
        Me.boardSocketTextBox.Location = New System.Drawing.Point(112, 24)
        Me.boardSocketTextBox.Name = "boardSocketTextBox"
        Me.boardSocketTextBox.Size = New System.Drawing.Size(128, 20)
        Me.boardSocketTextBox.TabIndex = 4
        Me.boardSocketTextBox.Text = ""
        '
        'verifySocketButton
        '
        Me.verifySocketButton.Location = New System.Drawing.Point(96, 120)
        Me.verifySocketButton.Name = "verifySocketButton"
        Me.verifySocketButton.TabIndex = 3
        Me.verifySocketButton.Text = "Verify"
        '
        'portNumberLabel
        '
        Me.portNumberLabel.Location = New System.Drawing.Point(8, 88)
        Me.portNumberLabel.Name = "portNumberLabel"
        Me.portNumberLabel.Size = New System.Drawing.Size(88, 24)
        Me.portNumberLabel.TabIndex = 2
        Me.portNumberLabel.Text = "Port Number:"
        '
        'hostAddressSocketLabel
        '
        Me.hostAddressSocketLabel.Location = New System.Drawing.Point(8, 56)
        Me.hostAddressSocketLabel.Name = "hostAddressSocketLabel"
        Me.hostAddressSocketLabel.Size = New System.Drawing.Size(96, 16)
        Me.hostAddressSocketLabel.TabIndex = 1
        Me.hostAddressSocketLabel.Text = "Host Address:"
        '
        'boardSocketLabel
        '
        Me.boardSocketLabel.Location = New System.Drawing.Point(8, 24)
        Me.boardSocketLabel.Name = "boardSocketLabel"
        Me.boardSocketLabel.Size = New System.Drawing.Size(96, 16)
        Me.boardSocketLabel.TabIndex = 0
        Me.boardSocketLabel.Text = "Board (optional):"
        '
        'resourcesVerifiedLabel
        '
        Me.resourcesVerifiedLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.resourcesVerifiedLabel.Location = New System.Drawing.Point(288, 24)
        Me.resourcesVerifiedLabel.Name = "resourcesVerifiedLabel"
        Me.resourcesVerifiedLabel.Size = New System.Drawing.Size(168, 16)
        Me.resourcesVerifiedLabel.TabIndex = 2
        Me.resourcesVerifiedLabel.Text = "TCP/IP Resources Verified:"
        '
        'resourcesVerifiedListBox
        '
        Me.resourcesVerifiedListBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.resourcesVerifiedListBox.Location = New System.Drawing.Point(288, 48)
        Me.resourcesVerifiedListBox.Name = "resourcesVerifiedListBox"
        Me.resourcesVerifiedListBox.Size = New System.Drawing.Size(248, 251)
        Me.resourcesVerifiedListBox.TabIndex = 3
        '
        'okButton
        '
        Me.okButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.okButton.Location = New System.Drawing.Point(464, 312)
        Me.okButton.Name = "okButton"
        Me.okButton.TabIndex = 4
        Me.okButton.Text = "OK"
        '
        'TcpipResourceVerifiicationUtilityForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(560, 357)
        Me.Controls.Add(Me.okButton)
        Me.Controls.Add(Me.resourcesVerifiedListBox)
        Me.Controls.Add(Me.resourcesVerifiedLabel)
        Me.Controls.Add(Me.socketResourceGroupBox)
        Me.Controls.Add(Me.instrumentResourceGroupBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(568, 384)
        Me.Name = "TcpipResourceVerifiicationUtilityForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TCP/IP Resource Verification Utility"
        Me.instrumentResourceGroupBox.ResumeLayout(False)
        Me.socketResourceGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub verifyInstrButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles verifyInstrButton.Click
        Dim resourceName As String

        If boardInstrTextBox.TextLength = 0 Then
            resourceName = "TCPIP::" + hostAddressInstrTextBox.Text
        Else
            resourceName = "TCPIP" + boardInstrTextBox.Text + "::" + hostAddressInstrTextBox.Text
        End If

        If deviceNameTextBox.TextLength = 0 Then
            resourceName += "::INSTR"
        Else
            resourceName += "::" + deviceNameTextBox.Text + "::INSTR"
        End If

        VerifyAndUpdateResourcename(resourceName)
    End Sub

    Private Sub verifySocketButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles verifySocketButton.Click
        Dim resourceName As String
        If boardSocketTextBox.TextLength = 0 Then
            resourceName = "TCPIP::" + hostAddressSocketTextBox.Text
        Else
            resourceName = "TCPIP" + boardSocketTextBox.Text + "::" + hostAddressSocketTextBox.Text
        End If

        resourceName += "::" + portNumberTextBox.Text + "::SOCKET"
        VerifyAndUpdateResourcename(resourceName)
    End Sub

    Private Sub VerifyAndUpdateResourcename(ByVal resourceName As String)
        Dim resourceFullName As String = ValidResourceName(resourceName)
        If resourceFullName <> Nothing Then
            If Not resourcesVerifiedListBox.Items.Contains(resourceFullName) Then
                resourcesVerifiedListBox.Items.Add(resourceFullName)
            End If
        Else
            MessageBox.Show("Invalid Resource Name")
        End If
    End Sub

    Private Function ValidResourceName(ByVal resourceName As String) As String
        Dim session As Session = Nothing
        Dim fullName As String = String.Empty

        Try
            session = ResourceManager.GetLocalManager().Open(resourceName)
            fullName = session.ResourceName
        Catch ex As VisaException
            ' Don't do anything
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        If Not (session Is Nothing) Then
            session.Dispose()
        End If

        Return fullName
    End Function

    Private Sub okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okButton.Click
        Me.Close()
    End Sub

    Public ReadOnly Property TcpipResourceNames() As String()
        Get
            Dim resourceNames(resourcesVerifiedListBox.Items.Count - 1) As String
            resourcesVerifiedListBox.Items.CopyTo(resourceNames, 0)
            Return resourceNames
        End Get
    End Property
End Class
