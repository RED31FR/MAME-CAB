<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CMarqueeWebUI
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
        Me.components = New System.ComponentModel.Container()
        Me.TreeViewMarquees = New System.Windows.Forms.TreeView()
        Me.TreeViewCImages = New System.Windows.Forms.TreeView()
        Me.TreeViewLayer = New System.Windows.Forms.TreeView()
        Me.PictureBoxWeb = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStripMarquee = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddCImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStripCImage = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStripLayer = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddCImageToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddLayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PictureBoxWeb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripMarquee.SuspendLayout()
        Me.ContextMenuStripCImage.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeViewMarquees
        '
        Me.TreeViewMarquees.ContextMenuStrip = Me.ContextMenuStripMarquee
        Me.TreeViewMarquees.Location = New System.Drawing.Point(3, 4)
        Me.TreeViewMarquees.Name = "TreeViewMarquees"
        Me.TreeViewMarquees.Size = New System.Drawing.Size(204, 254)
        Me.TreeViewMarquees.TabIndex = 0
        '
        'TreeViewCImages
        '
        Me.TreeViewCImages.ContextMenuStrip = Me.ContextMenuStripCImage
        Me.TreeViewCImages.Location = New System.Drawing.Point(213, 4)
        Me.TreeViewCImages.Name = "TreeViewCImages"
        Me.TreeViewCImages.Size = New System.Drawing.Size(204, 254)
        Me.TreeViewCImages.TabIndex = 0
        '
        'TreeViewLayer
        '
        Me.TreeViewLayer.Location = New System.Drawing.Point(423, 4)
        Me.TreeViewLayer.Name = "TreeViewLayer"
        Me.TreeViewLayer.Size = New System.Drawing.Size(204, 254)
        Me.TreeViewLayer.TabIndex = 0
        '
        'PictureBoxWeb
        '
        Me.PictureBoxWeb.Location = New System.Drawing.Point(634, 4)
        Me.PictureBoxWeb.Name = "PictureBoxWeb"
        Me.PictureBoxWeb.Size = New System.Drawing.Size(213, 254)
        Me.PictureBoxWeb.TabIndex = 1
        Me.PictureBoxWeb.TabStop = False
        '
        'ContextMenuStripMarquee
        '
        Me.ContextMenuStripMarquee.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddCImageToolStripMenuItem, Me.AddCImageToolStripMenuItem1})
        Me.ContextMenuStripMarquee.Name = "ContextMenuStripMarquee"
        Me.ContextMenuStripMarquee.Size = New System.Drawing.Size(156, 48)
        '
        'AddCImageToolStripMenuItem
        '
        Me.AddCImageToolStripMenuItem.Name = "AddCImageToolStripMenuItem"
        Me.AddCImageToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AddCImageToolStripMenuItem.Text = "Add Marquee..."
        '
        'ContextMenuStripCImage
        '
        Me.ContextMenuStripCImage.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddLayerToolStripMenuItem})
        Me.ContextMenuStripCImage.Name = "ContextMenuStripCImage"
        Me.ContextMenuStripCImage.Size = New System.Drawing.Size(137, 26)
        '
        'ContextMenuStripLayer
        '
        Me.ContextMenuStripLayer.Name = "ContextMenuStripLayer"
        Me.ContextMenuStripLayer.Size = New System.Drawing.Size(61, 4)
        '
        'AddCImageToolStripMenuItem1
        '
        Me.AddCImageToolStripMenuItem1.Name = "AddCImageToolStripMenuItem1"
        Me.AddCImageToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.AddCImageToolStripMenuItem1.Text = "Add CImage..."
        '
        'AddLayerToolStripMenuItem
        '
        Me.AddLayerToolStripMenuItem.Name = "AddLayerToolStripMenuItem"
        Me.AddLayerToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AddLayerToolStripMenuItem.Text = "Add Layer..."
        '
        'CMarqueeWebUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PictureBoxWeb)
        Me.Controls.Add(Me.TreeViewLayer)
        Me.Controls.Add(Me.TreeViewCImages)
        Me.Controls.Add(Me.TreeViewMarquees)
        Me.Name = "CMarqueeWebUI"
        Me.Size = New System.Drawing.Size(850, 263)
        CType(Me.PictureBoxWeb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripMarquee.ResumeLayout(False)
        Me.ContextMenuStripCImage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TreeViewMarquees As Windows.Forms.TreeView
    Friend WithEvents TreeViewCImages As Windows.Forms.TreeView
    Friend WithEvents TreeViewLayer As Windows.Forms.TreeView
    Friend WithEvents PictureBoxWeb As Windows.Forms.PictureBox
    Friend WithEvents ContextMenuStripMarquee As Windows.Forms.ContextMenuStrip
    Friend WithEvents AddCImageToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripCImage As Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuStripLayer As Windows.Forms.ContextMenuStrip
    Friend WithEvents AddCImageToolStripMenuItem1 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddLayerToolStripMenuItem As Windows.Forms.ToolStripMenuItem
End Class
