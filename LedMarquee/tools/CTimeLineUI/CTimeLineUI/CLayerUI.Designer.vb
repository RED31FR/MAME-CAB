<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CLayerUI
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.imageListSmall = New System.Windows.Forms.ImageList(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddLayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteLayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DuplicateLayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportLayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MergeLayersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageListSmall
        '
        Me.imageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.imageListSmall.ImageSize = New System.Drawing.Size(28, 16)
        Me.imageListSmall.TransparentColor = System.Drawing.Color.Transparent
        '
        'ListView1
        '
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(497, 443)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddLayerToolStripMenuItem, Me.DeleteLayerToolStripMenuItem, Me.DuplicateLayerToolStripMenuItem, Me.ImportLayerToolStripMenuItem, Me.MergeLayersToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(192, 152)
        '
        'AddLayerToolStripMenuItem
        '
        Me.AddLayerToolStripMenuItem.Name = "AddLayerToolStripMenuItem"
        Me.AddLayerToolStripMenuItem.Size = New System.Drawing.Size(176, 24)
        Me.AddLayerToolStripMenuItem.Text = "add Layer"
        '
        'DeleteLayerToolStripMenuItem
        '
        Me.DeleteLayerToolStripMenuItem.Name = "DeleteLayerToolStripMenuItem"
        Me.DeleteLayerToolStripMenuItem.Size = New System.Drawing.Size(176, 24)
        Me.DeleteLayerToolStripMenuItem.Text = "delete Layer"
        '
        'DuplicateLayerToolStripMenuItem
        '
        Me.DuplicateLayerToolStripMenuItem.Name = "DuplicateLayerToolStripMenuItem"
        Me.DuplicateLayerToolStripMenuItem.Size = New System.Drawing.Size(176, 24)
        Me.DuplicateLayerToolStripMenuItem.Text = "duplicate layer"
        '
        'ImportLayerToolStripMenuItem
        '
        Me.ImportLayerToolStripMenuItem.Name = "ImportLayerToolStripMenuItem"
        Me.ImportLayerToolStripMenuItem.Size = New System.Drawing.Size(176, 24)
        Me.ImportLayerToolStripMenuItem.Text = "import layer..."
        '
        'MergeLayersToolStripMenuItem
        '
        Me.MergeLayersToolStripMenuItem.Name = "MergeLayersToolStripMenuItem"
        Me.MergeLayersToolStripMenuItem.Size = New System.Drawing.Size(191, 24)
        Me.MergeLayersToolStripMenuItem.Text = "Merge ALL layers"
        '
        'CLayerUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ListView1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "CLayerUI"
        Me.Size = New System.Drawing.Size(497, 443)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents imageListSmall As Windows.Forms.ImageList
    Friend WithEvents ListView1 As Windows.Forms.ListView
    Friend WithEvents ContextMenuStrip1 As Windows.Forms.ContextMenuStrip
    Friend WithEvents AddLayerToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteLayerToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents DuplicateLayerToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportLayerToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MergeLayersToolStripMenuItem As Windows.Forms.ToolStripMenuItem
End Class
