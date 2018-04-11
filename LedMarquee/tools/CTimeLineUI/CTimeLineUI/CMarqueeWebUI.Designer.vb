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
        Me.ContextMenuStripMarquee = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddCImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddCImageToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteMarqueeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TreeViewCImages = New System.Windows.Forms.TreeView()
        Me.ContextMenuStripCImage = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddLayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteLayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TreeViewLayer = New System.Windows.Forms.TreeView()
        Me.ContextMenuStripLayer = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteLayerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBoxWeb = New System.Windows.Forms.PictureBox()
        Me.ImportMarqueeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ButtonReload = New System.Windows.Forms.Button()
        Me.ContextMenuStripMarquee.SuspendLayout()
        Me.ContextMenuStripCImage.SuspendLayout()
        Me.ContextMenuStripLayer.SuspendLayout()
        CType(Me.PictureBoxWeb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TreeViewMarquees
        '
        Me.TreeViewMarquees.ContextMenuStrip = Me.ContextMenuStripMarquee
        Me.TreeViewMarquees.Location = New System.Drawing.Point(0, 32)
        Me.TreeViewMarquees.Name = "TreeViewMarquees"
        Me.TreeViewMarquees.Size = New System.Drawing.Size(204, 254)
        Me.TreeViewMarquees.TabIndex = 0
        '
        'ContextMenuStripMarquee
        '
        Me.ContextMenuStripMarquee.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddCImageToolStripMenuItem, Me.AddCImageToolStripMenuItem1, Me.DeleteMarqueeToolStripMenuItem, Me.ImportMarqueeToolStripMenuItem})
        Me.ContextMenuStripMarquee.Name = "ContextMenuStripMarquee"
        Me.ContextMenuStripMarquee.Size = New System.Drawing.Size(161, 92)
        '
        'AddCImageToolStripMenuItem
        '
        Me.AddCImageToolStripMenuItem.Name = "AddCImageToolStripMenuItem"
        Me.AddCImageToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.AddCImageToolStripMenuItem.Text = "Add Marquee..."
        '
        'AddCImageToolStripMenuItem1
        '
        Me.AddCImageToolStripMenuItem1.Name = "AddCImageToolStripMenuItem1"
        Me.AddCImageToolStripMenuItem1.Size = New System.Drawing.Size(160, 22)
        Me.AddCImageToolStripMenuItem1.Text = "Add CImage..."
        '
        'DeleteMarqueeToolStripMenuItem
        '
        Me.DeleteMarqueeToolStripMenuItem.Name = "DeleteMarqueeToolStripMenuItem"
        Me.DeleteMarqueeToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.DeleteMarqueeToolStripMenuItem.Text = "Delete Marquee"
        '
        'TreeViewCImages
        '
        Me.TreeViewCImages.ContextMenuStrip = Me.ContextMenuStripCImage
        Me.TreeViewCImages.Location = New System.Drawing.Point(210, 32)
        Me.TreeViewCImages.Name = "TreeViewCImages"
        Me.TreeViewCImages.Size = New System.Drawing.Size(204, 254)
        Me.TreeViewCImages.TabIndex = 0
        '
        'ContextMenuStripCImage
        '
        Me.ContextMenuStripCImage.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddLayerToolStripMenuItem, Me.DeleteLayerToolStripMenuItem})
        Me.ContextMenuStripCImage.Name = "ContextMenuStripCImage"
        Me.ContextMenuStripCImage.Size = New System.Drawing.Size(144, 48)
        '
        'AddLayerToolStripMenuItem
        '
        Me.AddLayerToolStripMenuItem.Name = "AddLayerToolStripMenuItem"
        Me.AddLayerToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.AddLayerToolStripMenuItem.Text = "Add Layer..."
        '
        'DeleteLayerToolStripMenuItem
        '
        Me.DeleteLayerToolStripMenuItem.Name = "DeleteLayerToolStripMenuItem"
        Me.DeleteLayerToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.DeleteLayerToolStripMenuItem.Text = "Delete Image"
        '
        'TreeViewLayer
        '
        Me.TreeViewLayer.ContextMenuStrip = Me.ContextMenuStripLayer
        Me.TreeViewLayer.Location = New System.Drawing.Point(420, 32)
        Me.TreeViewLayer.Name = "TreeViewLayer"
        Me.TreeViewLayer.Size = New System.Drawing.Size(204, 254)
        Me.TreeViewLayer.TabIndex = 0
        '
        'ContextMenuStripLayer
        '
        Me.ContextMenuStripLayer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteLayerToolStripMenuItem1})
        Me.ContextMenuStripLayer.Name = "ContextMenuStripLayer"
        Me.ContextMenuStripLayer.Size = New System.Drawing.Size(139, 26)
        '
        'DeleteLayerToolStripMenuItem1
        '
        Me.DeleteLayerToolStripMenuItem1.Name = "DeleteLayerToolStripMenuItem1"
        Me.DeleteLayerToolStripMenuItem1.Size = New System.Drawing.Size(138, 22)
        Me.DeleteLayerToolStripMenuItem1.Text = "Delete Layer"
        '
        'PictureBoxWeb
        '
        Me.PictureBoxWeb.Location = New System.Drawing.Point(631, 32)
        Me.PictureBoxWeb.Name = "PictureBoxWeb"
        Me.PictureBoxWeb.Size = New System.Drawing.Size(213, 254)
        Me.PictureBoxWeb.TabIndex = 1
        Me.PictureBoxWeb.TabStop = False
        '
        'ImportMarqueeToolStripMenuItem
        '
        Me.ImportMarqueeToolStripMenuItem.Name = "ImportMarqueeToolStripMenuItem"
        Me.ImportMarqueeToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ImportMarqueeToolStripMenuItem.Text = "Import Marquee"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 288)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(843, 33)
        Me.ProgressBar1.TabIndex = 3
        '
        'ButtonReload
        '
        Me.ButtonReload.Location = New System.Drawing.Point(6, 3)
        Me.ButtonReload.Name = "ButtonReload"
        Me.ButtonReload.Size = New System.Drawing.Size(75, 23)
        Me.ButtonReload.TabIndex = 4
        Me.ButtonReload.Text = "Reload"
        Me.ButtonReload.UseVisualStyleBackColor = True
        '
        'CMarqueeWebUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ButtonReload)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.PictureBoxWeb)
        Me.Controls.Add(Me.TreeViewLayer)
        Me.Controls.Add(Me.TreeViewCImages)
        Me.Controls.Add(Me.TreeViewMarquees)
        Me.Name = "CMarqueeWebUI"
        Me.Size = New System.Drawing.Size(850, 328)
        Me.ContextMenuStripMarquee.ResumeLayout(False)
        Me.ContextMenuStripCImage.ResumeLayout(False)
        Me.ContextMenuStripLayer.ResumeLayout(False)
        CType(Me.PictureBoxWeb, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DeleteMarqueeToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteLayerToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteLayerToolStripMenuItem1 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportMarqueeToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgressBar1 As Windows.Forms.ProgressBar
    Friend WithEvents ButtonReload As Windows.Forms.Button
End Class
