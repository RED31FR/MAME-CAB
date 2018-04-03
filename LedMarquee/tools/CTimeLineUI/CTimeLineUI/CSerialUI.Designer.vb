<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CSerialUI
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxBaud = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxSerialPorts = New System.Windows.Forms.ComboBox()
        Me.ButtonOpen = New System.Windows.Forms.Button()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Select Speed :"
        '
        'ComboBoxBaud
        '
        Me.ComboBoxBaud.FormattingEnabled = True
        Me.ComboBoxBaud.Items.AddRange(New Object() {"9600", "19200", "38400", "57600", "74880", "115200", "230400"})
        Me.ComboBoxBaud.Location = New System.Drawing.Point(103, 27)
        Me.ComboBoxBaud.Name = "ComboBoxBaud"
        Me.ComboBoxBaud.Size = New System.Drawing.Size(173, 21)
        Me.ComboBoxBaud.TabIndex = 6
        Me.ComboBoxBaud.Text = "9600"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Select Serial Port :"
        '
        'ComboBoxSerialPorts
        '
        Me.ComboBoxSerialPorts.FormattingEnabled = True
        Me.ComboBoxSerialPorts.Location = New System.Drawing.Point(103, 0)
        Me.ComboBoxSerialPorts.Name = "ComboBoxSerialPorts"
        Me.ComboBoxSerialPorts.Size = New System.Drawing.Size(173, 21)
        Me.ComboBoxSerialPorts.TabIndex = 4
        '
        'ButtonOpen
        '
        Me.ButtonOpen.Location = New System.Drawing.Point(201, 54)
        Me.ButtonOpen.Name = "ButtonOpen"
        Me.ButtonOpen.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOpen.TabIndex = 8
        Me.ButtonOpen.Text = "Open"
        Me.ButtonOpen.UseVisualStyleBackColor = False
        '
        'ButtonClose
        '
        Me.ButtonClose.BackColor = System.Drawing.Color.Red
        Me.ButtonClose.Location = New System.Drawing.Point(120, 54)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClose.TabIndex = 8
        Me.ButtonClose.Text = "Close"
        Me.ButtonClose.UseVisualStyleBackColor = False
        '
        'CSerialUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.ButtonOpen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBoxBaud)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBoxSerialPorts)
        Me.Name = "CSerialUI"
        Me.Size = New System.Drawing.Size(283, 90)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents ComboBoxBaud As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents ComboBoxSerialPorts As Windows.Forms.ComboBox
    Friend WithEvents ButtonOpen As Windows.Forms.Button
    Friend WithEvents ButtonClose As Windows.Forms.Button
End Class
