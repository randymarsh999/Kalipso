Imports NationalInstruments.VisaNS

Public Class CustomFilterForm
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
    Friend WithEvents customFilterLabel As System.Windows.Forms.Label
    Friend WithEvents customFilterTextBox As System.Windows.Forms.TextBox
    Friend WithEvents okButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CustomFilterForm))
        Me.customFilterLabel = New System.Windows.Forms.Label
        Me.okButton = New System.Windows.Forms.Button
        Me.customFilterTextBox = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'customFilterLabel
        '
        Me.customFilterLabel.Location = New System.Drawing.Point(16, 8)
        Me.customFilterLabel.Name = "customFilterLabel"
        Me.customFilterLabel.Size = New System.Drawing.Size(152, 16)
        Me.customFilterLabel.TabIndex = 0
        Me.customFilterLabel.Text = "Enter Custom Filter String:"
        '
        'okButton
        '
        Me.okButton.Location = New System.Drawing.Point(56, 56)
        Me.okButton.Name = "okButton"
        Me.okButton.TabIndex = 1
        Me.okButton.Text = "OK"
        '
        'customFilterTextBox
        '
        Me.customFilterTextBox.Location = New System.Drawing.Point(16, 24)
        Me.customFilterTextBox.Name = "customFilterTextBox"
        Me.customFilterTextBox.Size = New System.Drawing.Size(152, 20)
        Me.customFilterTextBox.TabIndex = 2
        Me.customFilterTextBox.Text = "?*"
        '
        'CustomFilterForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(184, 85)
        Me.Controls.Add(Me.customFilterTextBox)
        Me.Controls.Add(Me.okButton)
        Me.Controls.Add(Me.customFilterLabel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(192, 224)
        Me.MinimumSize = New System.Drawing.Size(192, 112)
        Me.Name = "CustomFilterForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Custom  Filter"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okButton.Click
        Me.Close()
    End Sub

    Public ReadOnly Property CustomFilter() As String
        Get
            Return customFilterTextBox.Text
        End Get
    End Property

End Class
