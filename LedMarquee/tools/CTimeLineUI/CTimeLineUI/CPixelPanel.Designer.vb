<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CPixelPanel
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
        Me.PictureBoxPixels = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBoxPixels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBoxPixels
        '
        Me.PictureBoxPixels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxPixels.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxPixels.Name = "PictureBoxPixels"
        Me.PictureBoxPixels.Size = New System.Drawing.Size(150, 150)
        Me.PictureBoxPixels.TabIndex = 0
        Me.PictureBoxPixels.TabStop = False
        '
        'CPixelPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PictureBoxPixels)
        Me.Name = "CPixelPanel"
        CType(Me.PictureBoxPixels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBoxPixels As Windows.Forms.PictureBox
End Class
