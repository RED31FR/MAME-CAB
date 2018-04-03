Imports System.IO.Ports

Public Class CSerial
    Public Event portChangeState()

    Public Property _serial As SerialPort
    Public Property _speed As Integer

    Public Sub New()
        _serial = New SerialPort()
        _serial.PortName = "COM1"
        _serial.BaudRate = 57600
        _serial.Parity = IO.Ports.Parity.None
        _serial.StopBits = IO.Ports.StopBits.One
        _serial.DataBits = 8
        _serial.DtrEnable = True
        _serial.RtsEnable = True
        _serial.Encoding = System.Text.Encoding.ASCII
        _serial.Handshake = IO.Ports.Handshake.None
    End Sub

    Public Sub open()
        If Not _serial.IsOpen Then
            _serial.Open()
            RaiseEvent portChangeState()
        End If
    End Sub

    Public Sub close()
        If _serial.IsOpen Then
            _serial.Close()
            RaiseEvent portChangeState()
        End If
    End Sub

    Public Sub sendData(buffer As Byte(), offset As Integer, count As Integer)
        If _serial.IsOpen Then
            _serial.Write(buffer, offset, count)
        End If
    End Sub
End Class
