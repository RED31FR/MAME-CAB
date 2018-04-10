<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FirstToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreviousToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LastToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayStopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DuplicateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSerialUI1 = New CMarqueeObjects.CSerialUI()
        Me.CTimeLine1 = New CMarqueeObjects.CTimeLine()
        Me.CToolsPaletteUI1 = New CMarqueeObjects.CToolsPaletteUI()
        Me.CLayerUI1 = New CMarqueeObjects.CLayerUI()
        Me.CImageUC1 = New CMarqueeObjects.CImageUC()
        Me.PublishToWebToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "image000.png")
        Me.ImageList1.Images.SetKeyName(1, "image001.png")
        Me.ImageList1.Images.SetKeyName(2, "image002.png")
        Me.ImageList1.Images.SetKeyName(3, "image003.png")
        Me.ImageList1.Images.SetKeyName(4, "image004.png")
        Me.ImageList1.Images.SetKeyName(5, "image005.png")
        Me.ImageList1.Images.SetKeyName(6, "image006.png")
        Me.ImageList1.Images.SetKeyName(7, "image007.png")
        Me.ImageList1.Images.SetKeyName(8, "image008.png")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ImageToolStripMenuItem, Me.LayerToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1066, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ExitToolStripMenuItem, Me.PublishToWebToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem2.Text = "&New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OpenToolStripMenuItem.Text = "&Open..."
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaveAsToolStripMenuItem.Text = "S&ave as..."
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'ImageToolStripMenuItem
        '
        Me.ImageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.RemoveToolStripMenuItem, Me.FirstToolStripMenuItem, Me.PreviousToolStripMenuItem, Me.NextToolStripMenuItem, Me.LastToolStripMenuItem, Me.PlayStopToolStripMenuItem})
        Me.ImageToolStripMenuItem.Name = "ImageToolStripMenuItem"
        Me.ImageToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.ImageToolStripMenuItem.Text = "Image"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.AddToolStripMenuItem.Text = "A&dd"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.RemoveToolStripMenuItem.Text = "&Remove"
        '
        'FirstToolStripMenuItem
        '
        Me.FirstToolStripMenuItem.Name = "FirstToolStripMenuItem"
        Me.FirstToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.FirstToolStripMenuItem.Text = "&First"
        '
        'PreviousToolStripMenuItem
        '
        Me.PreviousToolStripMenuItem.Name = "PreviousToolStripMenuItem"
        Me.PreviousToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.PreviousToolStripMenuItem.Text = "&Previous"
        '
        'NextToolStripMenuItem
        '
        Me.NextToolStripMenuItem.Name = "NextToolStripMenuItem"
        Me.NextToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.NextToolStripMenuItem.Text = "&Next"
        '
        'LastToolStripMenuItem
        '
        Me.LastToolStripMenuItem.Name = "LastToolStripMenuItem"
        Me.LastToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.LastToolStripMenuItem.Text = "&Last"
        '
        'PlayStopToolStripMenuItem
        '
        Me.PlayStopToolStripMenuItem.Name = "PlayStopToolStripMenuItem"
        Me.PlayStopToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.PlayStopToolStripMenuItem.Text = "&Play / Stop"
        '
        'LayerToolStripMenuItem
        '
        Me.LayerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem1, Me.DeleteToolStripMenuItem, Me.DuplicateToolStripMenuItem, Me.ImportToolStripMenuItem})
        Me.LayerToolStripMenuItem.Name = "LayerToolStripMenuItem"
        Me.LayerToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.LayerToolStripMenuItem.Text = "Layer"
        '
        'AddToolStripMenuItem1
        '
        Me.AddToolStripMenuItem1.Name = "AddToolStripMenuItem1"
        Me.AddToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
        Me.AddToolStripMenuItem1.Text = "Add"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'DuplicateToolStripMenuItem
        '
        Me.DuplicateToolStripMenuItem.Name = "DuplicateToolStripMenuItem"
        Me.DuplicateToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.DuplicateToolStripMenuItem.Text = "Duplicate"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ImportToolStripMenuItem.Text = "Import..."
        '
        'CSerialUI1
        '
        Me.CSerialUI1.Location = New System.Drawing.Point(13, 426)
        Me.CSerialUI1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CSerialUI1.Name = "CSerialUI1"
        Me.CSerialUI1.Size = New System.Drawing.Size(283, 90)
        Me.CSerialUI1.TabIndex = 5
        '
        'CTimeLine1
        '
        Me.CTimeLine1.Location = New System.Drawing.Point(12, 284)
        Me.CTimeLine1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CTimeLine1.Name = "CTimeLine1"
        Me.CTimeLine1.Size = New System.Drawing.Size(697, 135)
        Me.CTimeLine1.TabIndex = 3
        '
        'CToolsPaletteUI1
        '
        Me.CToolsPaletteUI1._backgroundColor = System.Drawing.Color.Black
        Me.CToolsPaletteUI1._foreColor = System.Drawing.Color.Red
        Me.CToolsPaletteUI1.Location = New System.Drawing.Point(720, 284)
        Me.CToolsPaletteUI1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CToolsPaletteUI1.Name = "CToolsPaletteUI1"
        Me.CToolsPaletteUI1.Size = New System.Drawing.Size(207, 233)
        Me.CToolsPaletteUI1.TabIndex = 2
        '
        'CLayerUI1
        '
        Me.CLayerUI1.Image = Nothing
        Me.CLayerUI1.Location = New System.Drawing.Point(720, 27)
        Me.CLayerUI1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CLayerUI1.Name = "CLayerUI1"
        Me.CLayerUI1.Size = New System.Drawing.Size(338, 251)
        Me.CLayerUI1.TabIndex = 1
        '
        'CImageUC1
        '
        Me.CImageUC1.Cols = 28
        Me.CImageUC1.Image = Nothing
        Me.CImageUC1.Location = New System.Drawing.Point(13, 27)
        Me.CImageUC1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CImageUC1.Modified = False
        Me.CImageUC1.Name = "CImageUC1"
        Me.CImageUC1.Rows = 10
        Me.CImageUC1.ScaleFactor = 25
        Me.CImageUC1.Size = New System.Drawing.Size(701, 251)
        Me.CImageUC1.TabIndex = 0
        '
        'PublishToWebToolStripMenuItem
        '
        Me.PublishToWebToolStripMenuItem.Name = "PublishToWebToolStripMenuItem"
        Me.PublishToWebToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PublishToWebToolStripMenuItem.Text = "Publish to Web"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1066, 561)
        Me.Controls.Add(Me.CSerialUI1)
        Me.Controls.Add(Me.CTimeLine1)
        Me.Controls.Add(Me.CToolsPaletteUI1)
        Me.Controls.Add(Me.CLayerUI1)
        Me.Controls.Add(Me.CImageUC1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents CImageUC1 As CMarqueeObjects.CImageUC
    Friend WithEvents CLayerUI1 As CMarqueeObjects.CLayerUI
    Friend WithEvents CToolsPaletteUI1 As CMarqueeObjects.CToolsPaletteUI
    Friend WithEvents CTimeLine1 As CMarqueeObjects.CTimeLine
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSerialUI1 As CMarqueeObjects.CSerialUI
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NextToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PreviousToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FirstToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LastToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlayStopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LayerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DuplicateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PublishToWebToolStripMenuItem As ToolStripMenuItem
End Class
