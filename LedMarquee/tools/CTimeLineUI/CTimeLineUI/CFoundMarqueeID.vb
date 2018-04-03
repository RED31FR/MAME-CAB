Imports System.Timers

Public Class CFoundMarqueeID
    Private Property m_Serial As New CSerial
    Private Property MyTimerTimeOut As New System.Timers.Timer()
    Private Property MyTimerRead As New System.Timers.Timer()
    Private Property SPToTest As Integer = 0
    Private Property serialPorts As New List(Of String)

    Public Sub getSerialPortOfMarqueeID(id As Integer)

        For Each sp As String In My.Computer.Ports.SerialPortNames
            serialPorts.Add(sp)
        Next

        MyTimerTimeOut.Interval = 2000
        MyTimerRead.Interval = 25
        m_Serial._serial.BaudRate = 115200
        AddHandler MyTimerTimeOut.Elapsed, AddressOf OnTimeOutEvent
        AddHandler MyTimerRead.Elapsed, AddressOf OnReadEvent
        m_Serial._serial.PortName = serialPorts.ElementAt(SPToTest)
        m_Serial.open()
        MyTimerTimeOut.Start()
        MyTimerRead.Start()

    End Sub

    Private Sub OnReadEvent(sender As Object, e As ElapsedEventArgs)
        Dim value As String
        If m_Serial._serial.IsOpen Then
            value = ReceiveSerialData()
            If value = "1" Then
                MsgBox("trouve")
            End If
        End If
    End Sub

    Private Sub OnTimeOutEvent(sender As Object, e As ElapsedEventArgs)
        If SPToTest < serialPorts.Count Then
            SPToTest += 1
            m_Serial.close()
            m_Serial._serial.PortName = serialPorts.ElementAt(SPToTest)
            m_Serial.open()
        Else
            MyTimerRead.Stop()
            MyTimerTimeOut.Stop()
            MsgBox("pas trouve")
        End If
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
End Class
