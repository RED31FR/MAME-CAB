Imports System.IO
Imports CMarqueeObjects

Public Class Service1
    Private Property m_Frames As CFrames
    Private Property m_Serial As New CSerial
    Private Property m_ManageFrame As New CRandomFrames
    Private Property MyTimer As New System.Timers.Timer()


    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        m_ManageFrame.Folder = "C:\temp\V2"
        m_Frames = New CFrames(m_ManageFrame.getFolder, "image", "png")
        m_Frames.open()
        MyTimer.Interval = m_Frames.getSpeed
        m_Serial._serial.PortName = m_Frames.getPortName
        m_Serial._serial.BaudRate = m_Frames.getSerialSpeed
        m_Serial.open()
        MyTimer.Start()
        AddHandler MyTimer.Elapsed, AddressOf OnTimedEvent
        'Dim strFile As String = "c:\temp\yourfile.txt"
        'Dim fileExists As Boolean = File.Exists(strFile)
        'Using sw As New StreamWriter(File.Open(strFile, FileMode.OpenOrCreate))
        'sw.WriteLine(m_Serial._serial.PortName)
        'sw.WriteLine(m_Serial._serial.BaudRate.ToString)
        'sw.WriteLine(MyTimer.Interval.ToString)
        'sw.WriteLine(m_Frames.count.ToString)
        'sw.WriteLine(m_Serial._serial.IsOpen.ToString)
        'sw.Close()
        'End Using
        Dim strFile As String = "c:\temp\yourfile.txt"
        Dim fileExists As Boolean = File.Exists(strFile)
        Using sw As New StreamWriter(File.Open(strFile, FileMode.OpenOrCreate))
            sw.WriteLine(m_Frames._folderPath)
            sw.Close()
        End Using
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        'm_Timer.Stop()
    End Sub

    Private Sub OnTimedEvent()
        If m_Frames.goNext() = -1 Then
            'm_Frames.goFirst()
            m_Frames.clear()
            m_Frames._folderPath = m_ManageFrame.getFolder
            m_Frames.open()
            m_Serial.close()
            MyTimer.Interval = m_Frames.getSpeed
            m_Serial._serial.PortName = m_Frames.getPortName
            m_Serial._serial.BaudRate = m_Frames.getSerialSpeed
            m_Serial.open()
            Dim strFile As String = "c:\temp\yourfile.txt"
            Dim fileExists As Boolean = File.Exists(strFile)
            Using sw As New StreamWriter(File.Open(strFile, FileMode.OpenOrCreate))
                sw.WriteLine(m_Frames._folderPath)
                sw.Close()
            End Using
        End If
        Dim Data() As Byte
        Data = m_Frames.imageCompressToPixels '_frames.getImageByte()
        If m_Serial._serial.IsOpen Then
            Dim size = Data.Length
            m_Serial._serial.Write(Data, 0, size) 'Data.Length)

        End If
        Data = Nothing
    End Sub
End Class
