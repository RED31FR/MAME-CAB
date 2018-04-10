Imports CMarqueeObjects

Public Class Form1
    Public Property m_Frames As New CFramesLayer("c:\temp\test\", "images", "png")
    Public Property m_Serial As New CSerial

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim img As CImage
        img = New CImage("image001")
        img.add(New CLayer("Layer 1", New Bitmap(CImageUC1.Cols, CImageUC1.Rows)))
        m_Frames.add(img)
        CImageUC1.Image = m_Frames.CurrentImage
        CImageUC1.Cols = 28
        CImageUC1.Rows = 10
        CLayerUI1.clear()
        CLayerUI1.Image = m_Frames.CurrentImage
        CTimeLine1.changeTrackBarPositionMinMaxPos(0, m_Frames.Count - 1, m_Frames.CurrentImageIndex)
        CSerialUI1.setSpeed(115200)
        m_Serial._serial.BaudRate = CSerialUI1.getSpeed
        m_Serial._serial.PortName = CSerialUI1.getPortName
    End Sub

    Private Sub CLayerUI1_ItemStateChange(index As Integer, state As Boolean) Handles CLayerUI1.ItemStateChange
        m_Frames.CurrentImage.setState(index, state)
        'CLayerUI1.Image = m_Frames.item(0)
        CImageUC1.Modified = True
        CImageUC1.Invalidate()
    End Sub

    Private Sub CToolsPaletteUI2__ForeColorChange() Handles CToolsPaletteUI1._ForeColorChange
        'CPixelPanel1._foreColor = CToolsPaletteUI2._foreColor
        CImageUC1.ForeColor = CToolsPaletteUI1._foreColor
    End Sub

    Private Sub CToolsPaletteUI2__backColorChange() Handles CToolsPaletteUI1._BackgroundColorChange
        'CPixelPanel1._foreColor = CToolsPaletteUI2._foreColor
        CImageUC1.BackColor = CToolsPaletteUI1._backgroundColor
    End Sub

    Private Sub CToolsPaletteUI1_ButtonClearClick() Handles CToolsPaletteUI1.ButtonClearClick
        CImageUC1.clearSelectedLayer()
        'CImageUC1.Invalidate()
    End Sub

    Private Sub CLayerUI1_LayersChanged() Handles CLayerUI1.LayersChanged
        CImageUC1.Modified = True
    End Sub

    Private Sub CImageUC1_PixelsChanged() Handles CImageUC1.PixelsChanged
        CLayerUI1.Image = m_Frames.CurrentImage
    End Sub

    Private Sub CToolsPaletteUI1_ButtonLeftClick() Handles CToolsPaletteUI1.ButtonLeftClick
        CImageUC1.MoveLeft()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonDownClick() Handles CToolsPaletteUI1.ButtonDownClick
        CImageUC1.MoveDown()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonRightClick() Handles CToolsPaletteUI1.ButtonRightClick
        CImageUC1.MoveRight()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonUpClick() Handles CToolsPaletteUI1.ButtonUpClick
        CImageUC1.MoveUp()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonPickColorClick() Handles CToolsPaletteUI1.ButtonPickColorClick
        CImageUC1.startPickColor()
    End Sub

    Private Sub CImageUC1_ColorPicked(c As Color) Handles CImageUC1.ColorPicked
        CToolsPaletteUI1.setColor(c)
    End Sub

    Private Sub CToolsPaletteUI1_ButtonFillClick() Handles CToolsPaletteUI1.ButtonFillClick

    End Sub

    Private Sub CToolsPaletteUI1_ButtonFlipXClick() Handles CToolsPaletteUI1.ButtonFlipXClick
        CImageUC1.FlipX()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonFlipYClick() Handles CToolsPaletteUI1.ButtonFlipYClick
        CImageUC1.FlipY()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonReplaceColorClick(c As Color) Handles CToolsPaletteUI1.ButtonReplaceColorClick
        CImageUC1.startReplaceColor(c)
    End Sub

    Private Sub CToolsPaletteUI1_ButtonRotateLeftClick() Handles CToolsPaletteUI1.ButtonRotateLeftClick
        'CImageUC1.RotateLeft()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonRotateRightClick() Handles CToolsPaletteUI1.ButtonRotateRightClick
        'CImageUC1.RotateRight()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonSeletionClick() Handles CToolsPaletteUI1.ButtonSeletionClick
        CImageUC1.startSelection()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonCopyClick() Handles CToolsPaletteUI1.ButtonCopyClick
        CImageUC1.copy()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonDuplicateClick() Handles CToolsPaletteUI1.ButtonDuplicateClick
        Dim index As Integer = m_Frames.Count + 1
        Dim indexStr As String
        If index < 10 Then
            indexStr = "00" & index.ToString
        ElseIf index < 100 Then
            indexStr = "0" & index.ToString
        Else
            indexStr = index.ToString
        End If

        Dim cImg As CImage = m_Frames.CurrentImage
        Dim newCImg As CImage = New CImage("image" & indexStr)
        For Each layer In cImg.Layers
            Dim l As CLayer
            l = New CLayer(layer.Name)
            l.Image = layer.Image.Clone
            newCImg.add(l)
        Next
        m_Frames.add(newCImg)
        CImageUC1.Image = m_Frames.CurrentImage
        CLayerUI1.clear()
        CLayerUI1.Image = m_Frames.CurrentImage
        CTimeLine1.changeTrackBarPositionMinMaxPos(0, m_Frames.Count - 1, m_Frames.Count - 1)
    End Sub

    Private Sub CToolsPaletteUI1_ButtonMoveClick() Handles CToolsPaletteUI1.ButtonMoveClick

    End Sub

    Private Sub CToolsPaletteUI1_ButtonPasteClick() Handles CToolsPaletteUI1.ButtonPasteClick
        CImageUC1.startPaste()
    End Sub

    Private Sub UpdateControls()
        CImageUC1.Image = m_Frames.CurrentImage
        CImageUC1.Modified = True
        CImageUC1.Invalidate()
        CLayerUI1.clear()
        CLayerUI1.Image = m_Frames.CurrentImage
        CLayerUI1.Invalidate()
        CTimeLine1.changeTrackBarPositionMinMaxPos(0, m_Frames.Count - 1, m_Frames.CurrentImageIndex)
    End Sub

    Private Sub AddCImage()
        Dim index As Integer = m_Frames.Count + 1
        Dim indexStr As String
        If index < 10 Then
            indexStr = "00" & index.ToString
        ElseIf index < 100 Then
            indexStr = "0" & index.ToString
        Else
            indexStr = index.ToString
        End If

        Dim img As CImage = New CImage("image" & indexStr)
        img.add(New CLayer("Layer 1", New Bitmap(CImageUC1.Cols, CImageUC1.Rows)))
        m_Frames.add(img)
        UpdateControls()
    End Sub

    Private Sub PreviousCimage()
        m_Frames.CurrentImageIndex = m_Frames.CurrentImageIndex - 1
        UpdateControls()
    End Sub

    Private Sub NextCimage()
        m_Frames.CurrentImageIndex = m_Frames.CurrentImageIndex + 1
        UpdateControls()
    End Sub

    Private Sub RemoveImage()
        m_Frames.removeAt(m_Frames.CurrentImageIndex)
        If m_Frames.Count = 0 Then
            Dim img As CImage = New CImage("image" & m_Frames.Count.ToString + 1)
            img.add(New CLayer("layer 1", New Bitmap(CImageUC1.Cols, CImageUC1.Rows)))
            m_Frames.add(img)
        End If
        UpdateControls()
    End Sub

    Private Sub LastCImage()
        m_Frames.CurrentImageIndex = m_Frames.Count - 1
        UpdateControls()
    End Sub

    Private Sub FirstCImage()
        m_Frames.CurrentImageIndex = 0
        UpdateControls()
    End Sub

    Private Sub PlayStopAnimation()
        CTimeLine1.changeTimerState()
    End Sub

    Private Sub CTimeLine1_buttonAddClick() Handles CTimeLine1.buttonAddClick
        AddCImage()
    End Sub

    Private Sub CTimeLine1_buttonPreviousClick() Handles CTimeLine1.buttonPreviousClick
        PreviousCimage()
    End Sub

    Private Sub CTimeLine1_buttonNextClick() Handles CTimeLine1.buttonNextClick
        NextCimage()
    End Sub

    Private Sub CTimeLine1_buttonFirstClick() Handles CTimeLine1.buttonFirstClick
        FirstCImage()
    End Sub

    Private Sub CTimeLine1_buttonLastClick() Handles CTimeLine1.buttonLastClick
        LastCImage()
    End Sub

    Private Sub CTimeLine1_buttonRemoveClick() Handles CTimeLine1.buttonRemoveClick
        RemoveImage()
    End Sub

    Private Sub CTimeLine1_buttonPlayClick() Handles CTimeLine1.buttonPlayClick
        PlayStopAnimation()
    End Sub

    Private Sub CTimeLine1_trackTPositionValueChange() Handles CTimeLine1.trackTPositionValueChange
        m_Frames.CurrentImageIndex = CTimeLine1.getTrackBarPosition
        CImageUC1.Image = m_Frames.CurrentImage
        UpdateControls()
    End Sub

    Private Sub CTimeLine1_timerTick() Handles CTimeLine1.timerTick
        If m_Frames.CurrentImageIndex = m_Frames.Count - 1 Then
            m_Frames.CurrentImageIndex = 0
        Else
            m_Frames.CurrentImageIndex = m_Frames.CurrentImageIndex + 1
        End If

        CImageUC1.Image = m_Frames.CurrentImage
        UpdateControls()
        sendBlock()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        m_Frames.save(CTimeLine1.getSpeed, 10, m_Serial._serial.PortName, m_Serial._serial.BaudRate)
    End Sub

    Private Sub CSerialUI1_openPort() Handles CSerialUI1.openPort
        m_Serial.open()
    End Sub

    Private Sub CSerialUI1_closePort() Handles CSerialUI1.closePort
        m_Serial.close()
    End Sub

    Private Sub CSerialUI1_speedChange() Handles CSerialUI1.speedChange
        m_Serial._serial.BaudRate = CSerialUI1.getSpeed
    End Sub

    Private Sub CSerialUI1_serialPortChange() Handles CSerialUI1.serialPortChange
        m_Serial._serial.PortName = CSerialUI1.getPortName
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim folderBrowserDialog1 As New FolderBrowserDialog
        folderBrowserDialog1.Description = "Select a folder in which to save your workspace..."
        folderBrowserDialog1.SelectedPath = "c:\temp\v2" 'Application.StartupPath

        Dim result As DialogResult = folderBrowserDialog1.ShowDialog()
        If (result = DialogResult.OK) Then

            m_Frames = Nothing
            m_Frames = New CFramesLayer(folderBrowserDialog1.SelectedPath & "\", "image", "png")
            m_Frames.open()
            'm_Frames.CurrentImageIndex = CTimeLine1.getTrackBarPosition
            CImageUC1.Image = m_Frames.CurrentImage
            CImageUC1.Modified = True
            CImageUC1.Invalidate()
            CLayerUI1.clear()
            CLayerUI1.Image = m_Frames.CurrentImage
            CLayerUI1.Invalidate()
            CTimeLine1.setSpeed(m_Frames.getSpeed())
            CSerialUI1.setPortName(m_Frames.getPortName)
            CSerialUI1.setSpeed(m_Frames.getSerialSpeed)
            CTimeLine1.changeTrackBarPositionMinMaxPos(0, m_Frames.Count - 1, m_Frames.CurrentImageIndex)
            UpdateControls()
        End If
    End Sub

    Private Sub sendBlock()

        If m_Serial._serial.IsOpen Then
            Dim Data() As Byte
            Data = m_Frames.imageCompressToPixels '_frames.getImageByte()
            Dim size = Data.Length
            m_Serial._serial.Write(Data, 0, size) 'Data.Length)
            Data = Nothing
        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim folderBrowserDialog1 As New FolderBrowserDialog
        folderBrowserDialog1.Description = "Select a folder in which to save your workspace..."
        folderBrowserDialog1.SelectedPath = "c:\temp\v2" 'Application.StartupPath

        Dim result As DialogResult = folderBrowserDialog1.ShowDialog()
        If (result = DialogResult.OK) Then
            m_Frames.FolderPath = folderBrowserDialog1.SelectedPath & "\"
            m_Frames.save(CTimeLine1.getSpeed(), 5, m_Serial._serial.PortName, m_Serial._serial.BaudRate)
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        m_Frames = Nothing
        m_Frames = New CFramesLayer("", "images", "png")
        Dim img As CImage

        img = New CImage("image001")
        img.add(New CLayer("layer 1", New Bitmap(CImageUC1.Cols, CImageUC1.Rows)))
        m_Frames.add(img)
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        AddCImage()
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        RemoveImage()
    End Sub

    Private Sub NextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NextToolStripMenuItem.Click
        NextCimage()
    End Sub

    Private Sub PreviousToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviousToolStripMenuItem.Click
        PreviousCimage()
    End Sub

    Private Sub FirstToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FirstToolStripMenuItem.Click
        FirstCImage()
    End Sub

    Private Sub LastToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LastToolStripMenuItem.Click
        LastCImage()
    End Sub

    Private Sub PlayStopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlayStopToolStripMenuItem.Click
        PlayStopAnimation()
    End Sub

    Private Sub AddToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem1.Click
        CLayerUI1.AddLayer()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        CLayerUI1.DeleteLayer(0)
    End Sub

    Private Sub DuplicateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateToolStripMenuItem.Click
        CLayerUI1.DuplicateLayer()
    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        CLayerUI1.ImportLayer()
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub PublishToWebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PublishToWebToolStripMenuItem.Click
        Dim name = PromptWindows("name", "name")
        m_Frames.saveWeb("http://127.0.0.1/edsa-ledmarquee", name, 100, 5, "com1", 100)
    End Sub

    Private Function PromptWindows(message As String, title As String, Optional defaultvalue As String = "no name")
        Dim myValue As Object
        ' Display message, title, and default value.
        myValue = InputBox(message, title, defaultvalue)
        ' If user has clicked Cancel, set myValue to defaultValue
        If myValue Is "" Then myValue = defaultvalue
        Return myValue
    End Function
End Class
