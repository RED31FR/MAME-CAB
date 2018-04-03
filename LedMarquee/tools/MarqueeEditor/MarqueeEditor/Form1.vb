Imports CMarqueeObjects
Imports CMarqueeObjects.CTimeLine

Public Class Form1
    Public Property _frames As CFrames
    Public Property _serial As New CSerial
    Public Property _pressePapier As Image

    Private Property _nbcols As Integer = 28
    Private Property _nbrows As Integer = 10


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CPixelPanel1._scale = 30
        _serial._serial.BaudRate = CSerialUI1.getSpeed
        _serial._serial.PortName = CSerialUI1.getPortName
    End Sub

    Private Sub sendBlock(start As Integer, nb As Integer)
        Dim Data() As Byte
        Data = _frames.imageCompressToPixels '_frames.getImageByte()
        If _serial._serial.IsOpen Then
            Dim size = Data.Length
            _serial._serial.Write(Data, 0, size) 'Data.Length)
        End If
        Data = Nothing
    End Sub

    Private Sub CTimeLine1_buttonAddClick() Handles CTimeLine1.buttonAddClick
        _frames.addFrame()
        _frames.goLast()
        CPixelsPanel1.SmallImage = _frames.getImage()
        'CPixelPanel1.setImage(_frames.getImage())
        CTimeLine1.changeTrackBarPositionMinMaxPos(0, _frames.count - 1, _frames._position)
        'CPixelPanel1.unSelect()
    End Sub

    Private Sub CTimeLine1_buttonFirstClick() Handles CTimeLine1.buttonFirstClick
        _frames.goFirst()
        CPixelsPanel1.SmallImage = _frames.getImage()
        'CPixelPanel1.setImage(_frames.getImage())
        CTimeLine1.changeTrackBarPositionMinMaxPos(0, _frames.count - 1, _frames._position)
        'CPixelPanel1.unSelect()
    End Sub

    Private Sub CTimeLine1_buttonLastClick() Handles CTimeLine1.buttonLastClick
        _frames.goLast()
        CPixelsPanel1.SmallImage = _frames.getImage()
        'CPixelPanel1.setImage(_frames.getImage())
        CTimeLine1.changeTrackBarPositionMinMaxPos(0, _frames.count - 1, _frames._position)
        'CPixelPanel1.unSelect()
    End Sub

    Private Sub CTimeLine1_buttonNextClick() Handles CTimeLine1.buttonNextClick
        _frames.goNext()
        CPixelsPanel1.SmallImage = _frames.getImage()
        'CPixelPanel1.setImage(_frames.getImage())
        CTimeLine1.changeTrackBarPositionMinMaxPos(0, _frames.count - 1, _frames._position)
        'CPixelPanel1.unSelect()
    End Sub

    Private Sub CTimeLine1_buttonPlayClick() Handles CTimeLine1.buttonPlayClick
        CPixelsPanel1.SmallImage = _frames.getImage()
        CTimeLine1.changeTimerState()
        CTimeLine1.changeTrackBarPositionMinMaxPos(0, _frames.count - 1, _frames._position)
        'CPixelPanel1.unSelect()
    End Sub

    Private Sub CTimeLine1_buttonPreviousClick() Handles CTimeLine1.buttonPreviousClick
        _frames.goPrevious()
        CPixelsPanel1.SmallImage = _frames.getImage()
        'CPixelPanel1.setImage(_frames.getImage())
        CTimeLine1.changeTrackBarPositionMinMaxPos(0, _frames.count - 1, _frames._position)
        'CPixelPanel1.unSelect()
    End Sub

    Private Sub CPixelPanel1_PixelChanged()
        If _frames IsNot Nothing Then
            '__frames.setImage(CPixelPanel1.getImageSmall)
            __frames.setImage(CPixelsPanel1.SmallImage)
            'sendBlock(0, 150)
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim folderBrowserDialog1 As New FolderBrowserDialog
        folderBrowserDialog1.Description = "Select a folder in which to save your workspace..."
        folderBrowserDialog1.SelectedPath = "c:\temp\goods" 'Application.StartupPath

        Dim result As DialogResult = folderBrowserDialog1.ShowDialog()
        If (result = DialogResult.OK) Then
            _frames = New CFrames(folderBrowserDialog1.SelectedPath & "\", "image", "png")
            _frames.open()
            CTimeLine1.setSpeed(_frames.getSpeed())
            CSerialUI1.setPortName(_frames.getPortName)
            CSerialUI1.setSpeed(_frames.getSerialSpeed)
            CPixelsPanel1.SmallImage = _frames.getImage()
            'CPixelPanel1.setImage(_frames.getImage())
            CTimeLine1.Enabled = True
            CTimeLine1.changeTrackBarPositionMinMaxPos(0, _frames.count - 1, _frames._position)
            CPixelsPanel1.Enabled = True
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        _frames.save(CTimeLine1.getSpeed(), TrackBarBrigthness.Value, _serial._serial.PortName, _serial._serial.BaudRate)
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim folderBrowserDialog1 As New FolderBrowserDialog
        folderBrowserDialog1.Description = "Select a folder in which to save your workspace..."
        folderBrowserDialog1.SelectedPath = "c:\temp\goods" 'Application.StartupPath

        Dim result As DialogResult = folderBrowserDialog1.ShowDialog()
        If (result = DialogResult.OK) Then
            _frames._folderPath = folderBrowserDialog1.SelectedPath & "\"
            _frames.save(CTimeLine1.getSpeed(), TrackBarBrigthness.Value, _serial._serial.PortName, _serial._serial.BaudRate)
        End If
    End Sub

    Private Sub CTimeLine1_buttonRemoveClick() Handles CTimeLine1.buttonRemoveClick
        _frames.remove()
        CPixelsPanel1.SmallImage = _frames.getImage()
        'CPixelPanel1.setImage(_frames.getImage())
        If _frames.count = 0 Then
            CTimeLine1.Enabled = False
        Else
            CTimeLine1.changeTrackBarPositionMinMaxPos(0, _frames.count - 1, _frames._position)
        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        _frames = New CFrames("c:\temp\pacman\", "image", "png")
        CTimeLine1.changeTrackBarPositionMinMaxPos(0, _frames.count, _frames._position)
        _frames.setImageSize(_nbCols, _nbrows)
        '_frames.setImageSize(5, 1)
        _frames.addFrame()
        CPixelsPanel1.SmallImage = _frames.getImage(0)
        'CPixelPanel1.setImage(_frames.getImage(0))
        CTimeLine1.Enabled = True
        'CPixelPanel1.Enabled = True
        CPixelsPanel1.Enabled = True
    End Sub

    Private Sub CTimeLine1_timerTick() Handles CTimeLine1.timerTick
        If _frames.goNext() = -1 Then
            _frames.goFirst()
        End If
        CPixelsPanel1.SmallImage = _frames.getImage()
        'CPixelPanel1.setImage(_frames.getImage())
        CTimeLine1.changeTrackBarPositionMinMaxPos(0, _frames.count - 1, _frames._position)
        sendBlock(0, 270)
    End Sub

    Private Sub CTimeLine1_trackTimerIntevalValueChange() Handles CTimeLine1.trackTimerIntevalValueChange
        'CTimeLine1.changeTrackBarPositionMinMaxPos(0, _frames.count - 1, _frames._position)
    End Sub

    Private Sub CTimeLine1_trackTPositionValueChange() Handles CTimeLine1.trackTPositionValueChange
        _frames._position = CTimeLine1.getTrackBarPosition
        CPixelsPanel1.SmallImage = _frames.getImage()
        'CPixelPanel1.setImage(_frames.getImage())
    End Sub

    Private Sub CToolsPaletteUI2__ForeColorChange() Handles CToolsPaletteUI2._ForeColorChange
        'CPixelPanel1._foreColor = CToolsPaletteUI2._foreColor
        CPixelsPanel1.ForeColor = CToolsPaletteUI2._foreColor
    End Sub

    Private Sub CToolsPaletteUI2__BackgroundColorChange() Handles CToolsPaletteUI2._BackgroundColorChange
        CPixelsPanel1.BackColor = CToolsPaletteUI2._backgroundColor
    End Sub

    Private Sub SerialPortToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SerialPortToolStripMenuItem.Click
        If DialogSerialPort.ShowDialog() = DialogResult.OK Then

        End If
    End Sub

    Private Sub OpenSerialPortToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSerialPortToolStripMenuItem.Click
        If (_serial._serial.IsOpen) Then
            _serial.close()
        End If
        '_serial._serial.PortName = "COM5"
        '_serial._serial.BaudRate = 115200
        '_serial._serial.BaudRate = 500000
        '_serial.open()
    End Sub

    Private Sub Form1_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        _serial.close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        sendBlock(0, 270)
    End Sub

    Private Sub CToolsPaletteUI2_ButtonCopyClick() Handles CToolsPaletteUI2.ButtonCopyClick
        CPixelsPanel1.copy() 'CPixelPanel1.getImageSmall
    End Sub

    Private Sub CToolsPaletteUI2_ButtonPasteClick() Handles CToolsPaletteUI2.ButtonPasteClick
        'CPixelPanel1.setImage(_pressePapier)
        'CPixelPanel1.pasteImageAt(New Point(0, 0), _pressePapier)
        CPixelsPanel1.startPaste()
    End Sub

    Private Sub CToolsPaletteUI2_ButtonClearClick() Handles CToolsPaletteUI2.ButtonClearClick
        CPixelsPanel1.clear()
    End Sub

    Private Sub CSerialUI1_openPort() Handles CSerialUI1.openPort
        _serial.open()
    End Sub

    Private Sub CSerialUI1_closePort() Handles CSerialUI1.closePort
        _serial.close()
    End Sub

    Private Sub CSerialUI1_speedChange() Handles CSerialUI1.speedChange
        _serial._serial.BaudRate = CSerialUI1.getSpeed
    End Sub

    Private Sub CSerialUI1_serialPortChange() Handles CSerialUI1.serialPortChange
        _serial._serial.PortName = CSerialUI1.getPortName
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Data As Byte() = _frames.imageCompressToPixels '_frames.pixelsToBytes '_frames.getImageCommand()
        'MsgBox(Data.Count.ToString)
        _serial.sendData(Data, 0, Data.Length - 1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Data As Byte() = _frames.getImageByte
        MsgBox(Data.Count.ToString)
        _serial.sendData(Data, 0, Data.Length)
    End Sub

    Private Sub CToolsPaletteUI2_ButtonLeftClick() Handles CToolsPaletteUI2.ButtonLeftClick
        CPixelsPanel1.MoveLeft()
    End Sub

    Private Sub CToolsPaletteUI2_ButtonRightClick() Handles CToolsPaletteUI2.ButtonRightClick
        CPixelsPanel1.MoveRight()
    End Sub

    Private Sub CToolsPaletteUI2_ButtonUpClick() Handles CToolsPaletteUI2.ButtonUpClick
        CPixelsPanel1.MoveUp()
    End Sub

    Private Sub CToolsPaletteUI2_ButtonDownClick() Handles CToolsPaletteUI2.ButtonDownClick
        CPixelsPanel1.MoveDown()
    End Sub

    Private Sub CToolsPaletteUI2_ButtonSeletionClick() Handles CToolsPaletteUI2.ButtonSeletionClick
        'CPixelPanel1._selectionInProgress = True
        'CPixelPanel1._pixelsSelected = Nothing
        CPixelsPanel1.startSelection()
    End Sub

    Private Sub CToolsPaletteUI2_ButtonFillClick() Handles CToolsPaletteUI2.ButtonFillClick

    End Sub

    Private Sub CToolsPaletteUI2_ButtonFlipXClick() Handles CToolsPaletteUI2.ButtonFlipXClick
        CPixelsPanel1.FlipX()
    End Sub

    Private Sub CToolsPaletteUI2_ButtonFlipYClick() Handles CToolsPaletteUI2.ButtonFlipYClick
        CPixelsPanel1.FlipY()
    End Sub

    Private Sub CToolsPaletteUI2_ButtonRotateLeftClick() Handles CToolsPaletteUI2.ButtonRotateLeftClick
        CPixelsPanel1.RotateLeft()
    End Sub

    Private Sub CToolsPaletteUI2_ButtonRotateRightClick() Handles CToolsPaletteUI2.ButtonRotateRightClick
        CPixelsPanel1.RotateRight()
    End Sub

    Private Sub CPixelsPanel1_PixelsChanged() Handles CPixelsPanel1.PixelsChanged
        If _frames IsNot Nothing Then
            '__frames.setImage(CPixelPanel1.getImageSmall)
            __frames.setImage(CPixelsPanel1.SmallImage)
            'sendBlock(0, 150)
        End If
    End Sub

    Private Sub CPixelsPanel1_ColorPicked(c As Color) Handles CPixelsPanel1.ColorPicked
        CToolsPaletteUI2.setColor(c)
    End Sub

    Private Sub CToolsPaletteUI2_ButtonPickColorClick() Handles CToolsPaletteUI2.ButtonPickColorClick
        CPixelsPanel1.startPickColor()
    End Sub

    Private Sub CToolsPaletteUI2_ButtonMoveClick() Handles CToolsPaletteUI2.ButtonMoveClick
        _pressePapier = CPixelsPanel1.copy()
    End Sub

    Private Sub ReloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReloadToolStripMenuItem.Click
        If _frames IsNot Nothing Then
            _frames.clear()
            _frames.open()
            CPixelsPanel1.SmallImage = _frames.getImage()
            CSerialUI1.setPortName(_frames.getPortName)
            CSerialUI1.setSpeed(_frames.getSerialSpeed)
            CTimeLine1.setSpeed(_frames.getSpeed)
        End If
    End Sub

    Private Sub CToolsPaletteUI2_ButtonReplaceColorClick(c As Color) Handles CToolsPaletteUI2.ButtonReplaceColorClick
        CPixelsPanel1.startReplaceColor(c)
    End Sub

    Private Sub CPixelsPanel1_Load(sender As Object, e As EventArgs) Handles CPixelsPanel1.Load

    End Sub

    Private Sub CToolsPaletteUI2_ButtonDuplicateClick() Handles CToolsPaletteUI2.ButtonDuplicateClick
        _pressePapier = _frames.getImage()
        _frames.addFrame()
        _frames.goLast()
        CPixelsPanel1.Paste(_pressePapier, New Point(0, 0))
        CPixelsPanel1.SmallImage = _frames.getImage()
        CTimeLine1.changeTrackBarPositionMinMaxPos(0, _frames.count - 1, _frames._position)
    End Sub
End Class
