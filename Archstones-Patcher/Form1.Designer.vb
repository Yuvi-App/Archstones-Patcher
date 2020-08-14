<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxRegion = New System.Windows.Forms.ComboBox()
        Me.cbxTitleID = New System.Windows.Forms.ComboBox()
        Me.btnPatch = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please select your version of the game"
        '
        'cbxRegion
        '
        Me.cbxRegion.FormattingEnabled = True
        Me.cbxRegion.Items.AddRange(New Object() {"North America", "Europe", "Asia"})
        Me.cbxRegion.Location = New System.Drawing.Point(39, 25)
        Me.cbxRegion.Name = "cbxRegion"
        Me.cbxRegion.Size = New System.Drawing.Size(121, 21)
        Me.cbxRegion.TabIndex = 1
        '
        'cbxTitleID
        '
        Me.cbxTitleID.FormattingEnabled = True
        Me.cbxTitleID.Location = New System.Drawing.Point(39, 52)
        Me.cbxTitleID.Name = "cbxTitleID"
        Me.cbxTitleID.Size = New System.Drawing.Size(121, 21)
        Me.cbxTitleID.TabIndex = 2
        '
        'btnPatch
        '
        Me.btnPatch.Location = New System.Drawing.Point(61, 79)
        Me.btnPatch.Name = "btnPatch"
        Me.btnPatch.Size = New System.Drawing.Size(75, 23)
        Me.btnPatch.TabIndex = 3
        Me.btnPatch.Text = "Patch Game"
        Me.btnPatch.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "EBOOT"
        Me.OpenFileDialog1.Filter = "elf files|*.elf"
        Me.OpenFileDialog1.Title = "Select EBOOT.elf"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(152, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 7)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Yuvi - V1.1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(196, 109)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnPatch)
        Me.Controls.Add(Me.cbxTitleID)
        Me.Controls.Add(Me.cbxRegion)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.Text = "The Archstones Patcher"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cbxRegion As ComboBox
    Friend WithEvents cbxTitleID As ComboBox
    Friend WithEvents btnPatch As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label2 As Label
End Class
