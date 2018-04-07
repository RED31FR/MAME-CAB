<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TestForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TestForm))
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CMarqueeWebUI1 = New CMarqueeObjects.CMarqueeWebUI()
        Me.CFullImage1 = New CMarqueeObjects.CFullImage()
        Me.CToolsPaletteUI1 = New CMarqueeObjects.CToolsPaletteUI()
        Me.CPixelsPanel1 = New CMarqueeObjects.CPixelsPanel()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 332)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(86, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Start Creation"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(104, 332)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(86, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Stop and Save"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(215, 324)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(149, 23)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Select Image"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'CMarqueeWebUI1
        '
        Me.CMarqueeWebUI1.CImageId = 0
        Me.CMarqueeWebUI1.LayerId = 0
        Me.CMarqueeWebUI1.Location = New System.Drawing.Point(373, 324)
        Me.CMarqueeWebUI1.MarqueeId = 0
        Me.CMarqueeWebUI1.Name = "CMarqueeWebUI1"
        Me.CMarqueeWebUI1.ServerWebPath = "http://127.0.0.1/edsa-ledmarquee"
        Me.CMarqueeWebUI1.Size = New System.Drawing.Size(808, 263)
        Me.CMarqueeWebUI1.TabIndex = 16
        '
        'CFullImage1
        '
        Me.CFullImage1.Image = CType(resources.GetObject("CFullImage1.Image"), System.Drawing.Image)
        Me.CFullImage1.Location = New System.Drawing.Point(863, 11)
        Me.CFullImage1.Margin = New System.Windows.Forms.Padding(4)
        Me.CFullImage1.Name = "CFullImage1"
        Me.CFullImage1.Size = New System.Drawing.Size(318, 315)
        Me.CFullImage1.SmallHeight = 10
        Me.CFullImage1.SmallWidth = 28
        Me.CFullImage1.StartPoint = New System.Drawing.Point(0, 0)
        Me.CFullImage1.TabIndex = 6
        '
        'CToolsPaletteUI1
        '
        Me.CToolsPaletteUI1._backgroundColor = System.Drawing.Color.Black
        Me.CToolsPaletteUI1._foreColor = System.Drawing.Color.Red
        Me.CToolsPaletteUI1.Location = New System.Drawing.Point(1202, 11)
        Me.CToolsPaletteUI1.Margin = New System.Windows.Forms.Padding(4)
        Me.CToolsPaletteUI1.Name = "CToolsPaletteUI1"
        Me.CToolsPaletteUI1.Size = New System.Drawing.Size(155, 233)
        Me.CToolsPaletteUI1.TabIndex = 4
        '
        'CPixelsPanel1
        '
        Me.CPixelsPanel1.Cols = 28
        Me.CPixelsPanel1.Image = CType(resources.GetObject("CPixelsPanel1.Image"), System.Drawing.Image)
        Me.CPixelsPanel1.Location = New System.Drawing.Point(12, 12)
        Me.CPixelsPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.CPixelsPanel1.Name = "CPixelsPanel1"
        Me.CPixelsPanel1.PasteStart = False
        Me.CPixelsPanel1.Rows = 10
        Me.CPixelsPanel1.ScaleFactor = 30
        Me.CPixelsPanel1.Size = New System.Drawing.Size(841, 301)
        Me.CPixelsPanel1.SmallImage = CType(resources.GetObject("CPixelsPanel1.SmallImage"), System.Drawing.Image)
        Me.CPixelsPanel1.TabIndex = 0
        '
        'TestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1367, 620)
        Me.Controls.Add(Me.CMarqueeWebUI1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CFullImage1)
        Me.Controls.Add(Me.CToolsPaletteUI1)
        Me.Controls.Add(Me.CPixelsPanel1)
        Me.Name = "TestForm"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CPixelsPanel1 As CMarqueeObjects.CPixelsPanel
    Friend WithEvents CToolsPaletteUI1 As CMarqueeObjects.CToolsPaletteUI
    Friend WithEvents CFullImage1 As CMarqueeObjects.CFullImage
    Friend WithEvents Button2 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents CMarqueeWebUI1 As CMarqueeObjects.CMarqueeWebUI
End Class
