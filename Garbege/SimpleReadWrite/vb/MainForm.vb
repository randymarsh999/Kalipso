Imports NationalInstruments.VisaNS

Public Class MainForm
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
    Private mbSession As MessageBasedSession
    Private lastResourceString As String = Nothing
    Private WithEvents writeTextBox As System.Windows.Forms.TextBox
    Private WithEvents readTextBox As System.Windows.Forms.TextBox

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private WithEvents queryButton As System.Windows.Forms.Button
    Private WithEvents writeButton As System.Windows.Forms.Button
    Private WithEvents readButton As System.Windows.Forms.Button
    Private WithEvents openSessionButton As System.Windows.Forms.Button
    Private WithEvents clearButton As System.Windows.Forms.Button
    Private WithEvents closeSessionButton As System.Windows.Forms.Button
    Private WithEvents stringToWriteLabel As System.Windows.Forms.Label
    Private WithEvents stringToReadLabel As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainForm))
        Me.queryButton = New System.Windows.Forms.Button
        Me.writeButton = New System.Windows.Forms.Button
        Me.readButton = New System.Windows.Forms.Button
        Me.openSessionButton = New System.Windows.Forms.Button
        Me.writeTextBox = New System.Windows.Forms.TextBox
        Me.readTextBox = New System.Windows.Forms.TextBox
        Me.clearButton = New System.Windows.Forms.Button
        Me.closeSessionButton = New System.Windows.Forms.Button
        Me.stringToWriteLabel = New System.Windows.Forms.Label
        Me.stringToReadLabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'queryButton
        '
        Me.queryButton.Enabled = False
        Me.queryButton.Location = New System.Drawing.Point(5, 83)
        Me.queryButton.Name = "queryButton"
        Me.queryButton.Size = New System.Drawing.Size(74, 23)
        Me.queryButton.TabIndex = 3
        Me.queryButton.Text = "Query"
        '
        'writeButton
        '
        Me.writeButton.Enabled = False
        Me.writeButton.Location = New System.Drawing.Point(79, 83)
        Me.writeButton.Name = "writeButton"
        Me.writeButton.Size = New System.Drawing.Size(74, 23)
        Me.writeButton.TabIndex = 4
        Me.writeButton.Text = "Write"
        '
        'readButton
        '
        Me.readButton.Enabled = False
        Me.readButton.Location = New System.Drawing.Point(153, 83)
        Me.readButton.Name = "readButton"
        Me.readButton.Size = New System.Drawing.Size(74, 23)
        Me.readButton.TabIndex = 5
        Me.readButton.Text = "Read"
        '
        'openSessionButton
        '
        Me.openSessionButton.Location = New System.Drawing.Point(5, 5)
        Me.openSessionButton.Name = "openSessionButton"
        Me.openSessionButton.Size = New System.Drawing.Size(92, 22)
        Me.openSessionButton.TabIndex = 0
        Me.openSessionButton.Text = "Open Session"
        '
        'writeTextBox
        '
        Me.writeTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.writeTextBox.Enabled = False
        Me.writeTextBox.Location = New System.Drawing.Point(5, 54)
        Me.writeTextBox.Name = "writeTextBox"
        Me.writeTextBox.Size = New System.Drawing.Size(275, 20)
        Me.writeTextBox.TabIndex = 2
        Me.writeTextBox.Text = "*IDN?\n"
        '
        'readTextBox
        '
        Me.readTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.readTextBox.Location = New System.Drawing.Point(5, 136)
        Me.readTextBox.Multiline = True
        Me.readTextBox.Name = "readTextBox"
        Me.readTextBox.ReadOnly = True
        Me.readTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.readTextBox.Size = New System.Drawing.Size(275, 119)
        Me.readTextBox.TabIndex = 6
        Me.readTextBox.TabStop = False
        Me.readTextBox.Text = ""
        '
        'clearButton
        '
        Me.clearButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clearButton.Enabled = False
        Me.clearButton.Location = New System.Drawing.Point(6, 257)
        Me.clearButton.Name = "clearButton"
        Me.clearButton.Size = New System.Drawing.Size(275, 24)
        Me.clearButton.TabIndex = 7
        Me.clearButton.Text = "Clear"
        '
        'closeSessionButton
        '
        Me.closeSessionButton.Enabled = False
        Me.closeSessionButton.Location = New System.Drawing.Point(97, 5)
        Me.closeSessionButton.Name = "closeSessionButton"
        Me.closeSessionButton.Size = New System.Drawing.Size(92, 22)
        Me.closeSessionButton.TabIndex = 1
        Me.closeSessionButton.Text = "Close Session"
        '
        'stringToWriteLabel
        '
        Me.stringToWriteLabel.Location = New System.Drawing.Point(5, 34)
        Me.stringToWriteLabel.Name = "stringToWriteLabel"
        Me.stringToWriteLabel.Size = New System.Drawing.Size(91, 14)
        Me.stringToWriteLabel.TabIndex = 8
        Me.stringToWriteLabel.Text = "String to Write:"
        '
        'stringToReadLabel
        '
        Me.stringToReadLabel.Location = New System.Drawing.Point(5, 117)
        Me.stringToReadLabel.Name = "stringToReadLabel"
        Me.stringToReadLabel.Size = New System.Drawing.Size(101, 15)
        Me.stringToReadLabel.TabIndex = 9
        Me.stringToReadLabel.Text = "String to Read:"
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(287, 289)
        Me.Controls.Add(Me.stringToReadLabel)
        Me.Controls.Add(Me.stringToWriteLabel)
        Me.Controls.Add(Me.closeSessionButton)
        Me.Controls.Add(Me.clearButton)
        Me.Controls.Add(Me.readTextBox)
        Me.Controls.Add(Me.writeTextBox)
        Me.Controls.Add(Me.openSessionButton)
        Me.Controls.Add(Me.readButton)
        Me.Controls.Add(Me.writeButton)
        Me.Controls.Add(Me.queryButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(295, 316)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Simple Read/Write"
        Me.ResumeLayout(False)

    End Sub

#End Region

    <STAThread()> _
    Public Shared Sub Main()
        Application.Run(New MainForm)
    End Sub


    Private Sub openSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles openSessionButton.Click
        Dim sr As SelectResource = New SelectResource
        If lastResourceString <> Nothing Then
            sr.ResourceName = lastResourceString
        End If
        Dim result As DialogResult = sr.ShowDialog(Me)
        If result = Windows.Forms.DialogResult.OK Then
            lastResourceString = sr.ResourceName
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Try
                mbSession = CType(ResourceManager.GetLocalManager().Open(sr.ResourceName), MessageBasedSession)
                SetupControlState(True)
            Catch exp As InvalidCastException
                MessageBox.Show("Resource selected must be a message-based session")
            Catch exp As Exception
                MessageBox.Show(exp.Message)
            Finally
                Windows.Forms.Cursor.Current = Cursors.Default
            End Try
        End If
        sr.Dispose()
    End Sub

    Private Sub closeSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeSessionButton.Click
        SetupControlState(False)
        mbSession.Dispose()
    End Sub

    Private Sub query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles queryButton.Click
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences(writeTextBox.Text)
            Dim responseString As String = mbSession.Query(textToWrite)
            readTextBox.Text = InsertCommonEscapeSequences(responseString)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub write_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles writeButton.Click
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences(writeTextBox.Text)
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try
    End Sub

    Private Sub read_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles readButton.Click
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Try
            Dim responseString As String = mbSession.ReadString()
            readTextBox.Text = InsertCommonEscapeSequences(responseString)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearButton.Click
        readTextBox.Text = String.Empty
    End Sub

    Private Sub SetupControlState(ByVal isSessionOpen As Boolean)
        openSessionButton.Enabled = Not isSessionOpen
        closeSessionButton.Enabled = isSessionOpen
        queryButton.Enabled = isSessionOpen
        writeButton.Enabled = isSessionOpen
        readButton.Enabled = isSessionOpen
        writeTextBox.Enabled = isSessionOpen
        clearButton.Enabled = isSessionOpen
        If isSessionOpen Then
            readTextBox.Text = String.Empty
            writeTextBox.Focus()
        End If
    End Sub

    Private Function ReplaceCommonEscapeSequences(ByVal s As String) As String
        Return s.Replace("\n", vbLf).Replace("\r", vbCr)
    End Function

    Private Function InsertCommonEscapeSequences(ByVal s As String) As String
        Return s.Replace(vbLf, "\n").Replace(vbCr, "\r")
    End Function

End Class