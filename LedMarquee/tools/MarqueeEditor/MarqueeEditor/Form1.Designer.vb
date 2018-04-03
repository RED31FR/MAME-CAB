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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SerialPortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenSerialPortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TrackBarBrigthness = New System.Windows.Forms.TrackBar()
        Me.CPixelsPanel1 = New CMarqueeObjects.CPixelsPanel()
        Me.CSerialUI1 = New CMarqueeObjects.CSerialUI()
        Me.CTimeLine1 = New CMarqueeObjects.CTimeLine()
        Me.CToolsPaletteUI2 = New CMarqueeObjects.CToolsPaletteUI()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.TrackBarBrigthness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(999, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.ReloadToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.NewToolStripMenuItem.Text = "&New..."
        '
        'ReloadToolStripMenuItem
        '
        Me.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem"
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ReloadToolStripMenuItem.Text = "&Reload"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.OpenToolStripMenuItem.Text = "&Open..."
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.SaveAsToolStripMenuItem.Text = "s&ave as..."
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SerialPortToolStripMenuItem, Me.OpenSerialPortToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'SerialPortToolStripMenuItem
        '
        Me.SerialPortToolStripMenuItem.Name = "SerialPortToolStripMenuItem"
        Me.SerialPortToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.SerialPortToolStripMenuItem.Text = "&Serial Port"
        '
        'OpenSerialPortToolStripMenuItem
        '
        Me.OpenSerialPortToolStripMenuItem.Name = "OpenSerialPortToolStripMenuItem"
        Me.OpenSerialPortToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.OpenSerialPortToolStripMenuItem.Text = "&Open Serial Port "
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(289, 373)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "send compress"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(404, 373)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Send Normal"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TrackBarBrigthness
        '
        Me.TrackBarBrigthness.Location = New System.Drawing.Point(725, 28)
        Me.TrackBarBrigthness.Maximum = 255
        Me.TrackBarBrigthness.Minimum = 1
        Me.TrackBarBrigthness.Name = "TrackBarBrigthness"
        Me.TrackBarBrigthness.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarBrigthness.Size = New System.Drawing.Size(45, 422)
        Me.TrackBarBrigthness.TabIndex = 12
        Me.TrackBarBrigthness.Value = 1
        '
        'CPixelsPanel1
        '
        Me.CPixelsPanel1.Cols = 28
        Me.CPixelsPanel1.Enabled = False
        Me.CPixelsPanel1.Image = CType(resources.GetObject("CPixelsPanel1.Image"), System.Drawing.Image)
        Me.CPixelsPanel1.Location = New System.Drawing.Point(13, 28)
        Me.CPixelsPanel1.Name = "CPixelsPanel1"
        Me.CPixelsPanel1.PasteStart = False
        Me.CPixelsPanel1.Rows = 10
        Me.CPixelsPanel1.ScaleFactor = 20
        Me.CPixelsPanel1.Size = New System.Drawing.Size(561, 201)
        Me.CPixelsPanel1.SmallImage = CType(resources.GetObject("CPixelsPanel1.SmallImage"), System.Drawing.Image)
        Me.CPixelsPanel1.TabIndex = 11
        '
        'CSerialUI1
        '
        Me.CSerialUI1.Location = New System.Drawing.Point(0, 306)
        Me.CSerialUI1.Name = "CSerialUI1"
        Me.CSerialUI1.Size = New System.Drawing.Size(283, 90)
        Me.CSerialUI1.TabIndex = 8
        '
        'CTimeLine1
        '
        Me.CTimeLine1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CTimeLine1.Enabled = False
        Me.CTimeLine1.Location = New System.Drawing.Point(0, 418)
        Me.CTimeLine1.Name = "CTimeLine1"
        Me.CTimeLine1.Size = New System.Drawing.Size(801, 135)
        Me.CTimeLine1.TabIndex = 7
        '
        'CToolsPaletteUI2
        '
        Me.CToolsPaletteUI2._backgroundColor = System.Drawing.Color.Black
        Me.CToolsPaletteUI2._foreColor = System.Drawing.Color.Red
        Me.CToolsPaletteUI2.Dock = System.Windows.Forms.DockStyle.Right
        Me.CToolsPaletteUI2.Location = New System.Drawing.Point(801, 24)
        Me.CToolsPaletteUI2.Name = "CToolsPaletteUI2"
        Me.CToolsPaletteUI2.Size = New System.Drawing.Size(198, 529)
        Me.CToolsPaletteUI2.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 553)
        Me.Controls.Add(Me.TrackBarBrigthness)
        Me.Controls.Add(Me.CPixelsPanel1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CSerialUI1)
        Me.Controls.Add(Me.CTimeLine1)
        Me.Controls.Add(Me.CToolsPaletteUI2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.TrackBarBrigthness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CToolsPaletteUI2 As CMarqueeObjects.CToolsPaletteUI
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CTimeLine1 As CMarqueeObjects.CTimeLine
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SerialPortToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenSerialPortToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSerialUI1 As CMarqueeObjects.CSerialUI
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents CPixelsPanel1 As CMarqueeObjects.CPixelsPanel
    Friend WithEvents ReloadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TrackBarBrigthness As TrackBar
    'Friend WithEvents CPixelsPanel1 As CMarqueeObjects.CPixelsPanel
End Class
