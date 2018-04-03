<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogSerialPort
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
        Me.CSerialUI1 = New CMarqueeObjects.CSerialUI()
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CSerialUI1
        '
        Me.CSerialUI1.Location = New System.Drawing.Point(13, 13)
        Me.CSerialUI1.Name = "CSerialUI1"
        Me.CSerialUI1.Size = New System.Drawing.Size(283, 54)
        Me.CSerialUI1.TabIndex = 0
        '
        'ButtonOk
        '
        Me.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOk.Location = New System.Drawing.Point(210, 76)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOk.TabIndex = 1
        Me.ButtonOk.Text = "OK"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(129, 76)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'DialogSerialPort
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(297, 111)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOk)
        Me.Controls.Add(Me.CSerialUI1)
        Me.Name = "DialogSerialPort"
        Me.Text = "DialogSerialPort"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CSerialUI1 As CMarqueeObjects.CSerialUI
    Friend WithEvents ButtonOk As Button
    Friend WithEvents ButtonCancel As Button
End Class
