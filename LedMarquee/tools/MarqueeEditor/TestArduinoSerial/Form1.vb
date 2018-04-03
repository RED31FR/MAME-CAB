Imports CMarqueeObjects

Public Class Form1
    Public Property m_Serial As New CSerial
    Public Property receivedData As String = ""
    Public Property timerIsStart As Boolean = False
    Public Property m_ManageFrame As New CRandomFrames
    Public Property m_Frames As CFramesLayer


    Private Sub CSerialUI1_closePort() Handles CSerialUI1.closePort
        m_Serial.close()
        'Timer1.Stop()
        'Timer1.Enabled = False
    End Sub

    Private Sub CSerialUI1_openPort() Handles CSerialUI1.openPort
        m_Serial.open()
        RichTextBox1.Text = ""
        'Timer1.Enabled = True
        'Timer1.Start()
    End Sub

    Private Sub CSerialUI1_speedChange() Handles CSerialUI1.speedChange
        m_Serial._serial.BaudRate = CSerialUI1.getSpeed()
    End Sub

    Private Sub CSerialUI1_serialPortChange() Handles CSerialUI1.serialPortChange
        m_Serial._serial.PortName = CSerialUI1.getPortName
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m_Serial._serial.BaudRate = 115200
        m_Serial._serial.PortName = "COM6"
        CSerialUI1.setPortName(m_Serial._serial.PortName)
        CSerialUI1.setSpeed(m_Serial._serial.BaudRate)
        Timer1.Enabled = False
        m_ManageFrame.Folder = "C:\temp\v2\"
        m_Frames = New CFramesLayer(m_ManageFrame.getFolder, "image", "png")
        m_Frames.open()
        Timer2.Interval = m_Frames.getSpeed
        CSerialUI1.setPortName(m_Frames.getPortName)
    End Sub

    Private Function ReceiveSerialData() As String
        Dim Incoming As String
        Dim buffer(1) As Byte
        Try
            Incoming = m_Serial._serial.ReadExisting()
            If Incoming Is Nothing Then
                Return "nothing" & vbCrLf
            Else
                Return Incoming
            End If
        Catch ex As TimeoutException
            Return "Error: Serial Port read timed out."
        End Try

    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        receivedData = ReceiveSerialData()
        If receivedData <> "" Then
            RichTextBox1.Text &= receivedData
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.Text = ""
        If timerIsStart Then
            timerIsStart = False
            Timer2.Stop()
        Else
            timerIsStart = True
            Timer2.Start()
        End If
        'RichTextBox1.Text = ""
        'If m_Frames.goNext() = -1 Then
        'm_Frames.goFirst()
        'End If
        'Dim Data As Byte() = m_Frames.imageCompressToPixels
        'm_Serial.sendData(Data, 0, Data.Length)
        'timerIsStart = True
        'Dim Data() As Byte
        'Data = m_Frames.imageCompressToPixels '_frames.getImageByte()
        'Dim size = Data.Length
        'm_Serial._serial.Write(Data, 0, size) 'Data.Length)
        'Data = Nothing
        'If m_Frames.CurrentImageIndex = m_Frames.Count - 1 Then
        'm_Frames.CurrentImageIndex = 0
        'Else
        'm_Frames.CurrentImageIndex = m_Frames.CurrentImageIndex + 1
        'End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'RichTextBox1.Text = ""
        'If m_Frames.goNext() = -1 Then
        'm_Frames.goFirst()
        'End If    


        Dim Data() As Byte
        Data = m_Frames.imageCompressToPixels '_frames.getImageByte()
        Dim size = Data.Length
        m_Serial._serial.Write(Data, 0, size) 'Data.Length)
        Data = Nothing
        If m_Frames.CurrentImageIndex = m_Frames.Count - 1 Then
            m_Frames = New CFramesLayer(m_ManageFrame.getFolder, "image", "png")
            m_Serial.close()

            Timer2.Stop()
            m_Frames.open()

            Timer2.Interval = m_Frames.getSpeed
            m_Frames.CurrentImageIndex = 0
            m_Serial.open()
            Timer2.Start()
        Else
            m_Frames.CurrentImageIndex = m_Frames.CurrentImageIndex + 1
        End If
        'Timer2.Stop()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim found As New CFoundMarqueeID
        found.getSerialPortOfMarqueeID(1)
    End Sub

End Class
