<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WebManager
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMarqueeWebUI1 = New CMarqueeObjects.CMarqueeWebUI()
        Me.CAuthentificationUI1 = New CMarqueeObjects.CAuthentificationUI()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(879, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'CMarqueeWebUI1
        '
        Me.CMarqueeWebUI1.CImageId = 0
        Me.CMarqueeWebUI1.LayerId = 0
        Me.CMarqueeWebUI1.Location = New System.Drawing.Point(12, 120)
        Me.CMarqueeWebUI1.MarqueeId = 0
        Me.CMarqueeWebUI1.Name = "CMarqueeWebUI1"
        Me.CMarqueeWebUI1.ServerWebPath = "http://127.0.0.1/edsa-ledmarquee"
        Me.CMarqueeWebUI1.Size = New System.Drawing.Size(850, 330)
        Me.CMarqueeWebUI1.TabIndex = 3
        Me.CMarqueeWebUI1.Visible = False
        '
        'CAuthentificationUI1
        '
        Me.CAuthentificationUI1.Location = New System.Drawing.Point(12, 27)
        Me.CAuthentificationUI1.Name = "CAuthentificationUI1"
        Me.CAuthentificationUI1.PasswordFieldName = "password"
        Me.CAuthentificationUI1.ServerPath = "http://127.0.0.1/edsa-ledmarquee"
        Me.CAuthentificationUI1.Size = New System.Drawing.Size(226, 87)
        Me.CAuthentificationUI1.TabIndex = 2
        Me.CAuthentificationUI1.TableUSerName = "users"
        Me.CAuthentificationUI1.UserNameFieldName = "username"
        '
        'WebManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(879, 450)
        Me.Controls.Add(Me.CMarqueeWebUI1)
        Me.Controls.Add(Me.CAuthentificationUI1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "WebManager"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CAuthentificationUI1 As CMarqueeObjects.CAuthentificationUI
    Friend WithEvents CMarqueeWebUI1 As CMarqueeObjects.CMarqueeWebUI
End Class
