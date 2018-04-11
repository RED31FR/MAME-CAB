<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CAuthentificationUI
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
        Me.UserName = New System.Windows.Forms.TextBox()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.ButtonConnect = New System.Windows.Forms.Button()
        Me.ButtonDisconnect = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'UserName
        '
        Me.UserName.Location = New System.Drawing.Point(4, 4)
        Me.UserName.Name = "UserName"
        Me.UserName.Size = New System.Drawing.Size(219, 20)
        Me.UserName.TabIndex = 0
        '
        'Password
        '
        Me.Password.Location = New System.Drawing.Point(4, 30)
        Me.Password.Name = "Password"
        Me.Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Password.Size = New System.Drawing.Size(219, 20)
        Me.Password.TabIndex = 1
        '
        'ButtonConnect
        '
        Me.ButtonConnect.Location = New System.Drawing.Point(148, 56)
        Me.ButtonConnect.Name = "ButtonConnect"
        Me.ButtonConnect.Size = New System.Drawing.Size(75, 23)
        Me.ButtonConnect.TabIndex = 2
        Me.ButtonConnect.Text = "Connect"
        Me.ButtonConnect.UseVisualStyleBackColor = True
        '
        'ButtonDisconnect
        '
        Me.ButtonDisconnect.Location = New System.Drawing.Point(4, 4)
        Me.ButtonDisconnect.Name = "ButtonDisconnect"
        Me.ButtonDisconnect.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDisconnect.TabIndex = 3
        Me.ButtonDisconnect.Text = "Disconnect"
        Me.ButtonDisconnect.UseVisualStyleBackColor = True
        '
        'CAuthentificationUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ButtonDisconnect)
        Me.Controls.Add(Me.ButtonConnect)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.UserName)
        Me.Name = "CAuthentificationUI"
        Me.Size = New System.Drawing.Size(226, 87)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UserName As Windows.Forms.TextBox
    Friend WithEvents Password As Windows.Forms.TextBox
    Friend WithEvents ButtonConnect As Windows.Forms.Button
    Friend WithEvents ButtonDisconnect As Windows.Forms.Button
End Class
