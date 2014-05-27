<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.buttonCrash = New System.Windows.Forms.Button()
        Me.comboBoxServerName = New System.Windows.Forms.ComboBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.textBoxServerIP = New System.Windows.Forms.TextBox()
        Me.textBoxServerPort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.buttonSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.linkLabelDisclaimer = New System.Windows.Forms.LinkLabel()
        Me.buttonDelete = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'buttonCrash
        '
        Me.buttonCrash.Font = New System.Drawing.Font("Showcard Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonCrash.Location = New System.Drawing.Point(237, 225)
        Me.buttonCrash.Name = "buttonCrash"
        Me.buttonCrash.Size = New System.Drawing.Size(121, 37)
        Me.buttonCrash.TabIndex = 0
        Me.buttonCrash.Text = "Crash!"
        Me.buttonCrash.UseVisualStyleBackColor = True
        '
        'comboBoxServerName
        '
        Me.comboBoxServerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.comboBoxServerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.comboBoxServerName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboBoxServerName.ForeColor = System.Drawing.Color.Black
        Me.comboBoxServerName.FormattingEnabled = True
        Me.comboBoxServerName.Location = New System.Drawing.Point(30, 134)
        Me.comboBoxServerName.Name = "comboBoxServerName"
        Me.comboBoxServerName.Size = New System.Drawing.Size(130, 24)
        Me.comboBoxServerName.TabIndex = 2
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Crasher"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackColor = System.Drawing.Color.White
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Showcard Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 26)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.ExitToolStripMenuItem.Text = "Exit!"
        '
        'textBoxServerIP
        '
        Me.textBoxServerIP.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textBoxServerIP.Location = New System.Drawing.Point(210, 135)
        Me.textBoxServerIP.Name = "textBoxServerIP"
        Me.textBoxServerIP.Size = New System.Drawing.Size(154, 26)
        Me.textBoxServerIP.TabIndex = 4
        '
        'textBoxServerPort
        '
        Me.textBoxServerPort.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textBoxServerPort.Location = New System.Drawing.Point(391, 135)
        Me.textBoxServerPort.Name = "textBoxServerPort"
        Me.textBoxServerPort.Size = New System.Drawing.Size(73, 26)
        Me.textBoxServerPort.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Gabriola", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(50, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 35)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Server Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Gabriola", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(248, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 35)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "IP Address"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Gabriola", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(408, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 35)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Port"
        '
        'buttonSave
        '
        Me.buttonSave.Font = New System.Drawing.Font("Showcard Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonSave.Location = New System.Drawing.Point(505, 107)
        Me.buttonSave.Name = "buttonSave"
        Me.buttonSave.Size = New System.Drawing.Size(70, 35)
        Me.buttonSave.TabIndex = 9
        Me.buttonSave.Text = "Save"
        Me.buttonSave.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Showcard Gothic", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(171, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(175, 44)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Crasher"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(361, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(63, 46)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'linkLabelDisclaimer
        '
        Me.linkLabelDisclaimer.AutoSize = True
        Me.linkLabelDisclaimer.BackColor = System.Drawing.Color.Transparent
        Me.linkLabelDisclaimer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.linkLabelDisclaimer.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linkLabelDisclaimer.LinkColor = System.Drawing.Color.White
        Me.linkLabelDisclaimer.Location = New System.Drawing.Point(503, 248)
        Me.linkLabelDisclaimer.Name = "linkLabelDisclaimer"
        Me.linkLabelDisclaimer.Size = New System.Drawing.Size(79, 14)
        Me.linkLabelDisclaimer.TabIndex = 13
        Me.linkLabelDisclaimer.TabStop = True
        Me.linkLabelDisclaimer.Text = "DISCLAIMER"
        '
        'buttonDelete
        '
        Me.buttonDelete.Font = New System.Drawing.Font("Showcard Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonDelete.Location = New System.Drawing.Point(505, 148)
        Me.buttonDelete.Name = "buttonDelete"
        Me.buttonDelete.Size = New System.Drawing.Size(70, 35)
        Me.buttonDelete.TabIndex = 14
        Me.buttonDelete.Text = "Delete"
        Me.buttonDelete.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Gabriola", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(367, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 35)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = ":"
        '
        'MainForm
        '
        Me.AcceptButton = Me.buttonCrash
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(594, 274)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.buttonDelete)
        Me.Controls.Add(Me.linkLabelDisclaimer)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.buttonSave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.textBoxServerPort)
        Me.Controls.Add(Me.textBoxServerIP)
        Me.Controls.Add(Me.comboBoxServerName)
        Me.Controls.Add(Me.buttonCrash)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crasher"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents buttonCrash As System.Windows.Forms.Button
    Friend WithEvents comboBoxServerName As System.Windows.Forms.ComboBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents textBoxServerIP As System.Windows.Forms.TextBox
    Friend WithEvents textBoxServerPort As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents buttonSave As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents linkLabelDisclaimer As System.Windows.Forms.LinkLabel
    Friend WithEvents buttonDelete As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
