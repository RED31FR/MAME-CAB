Public Class DialogSerialPort
    Public Event serialPortNameChanged()
    Public Event serialSpeedChanged()

    Private Sub DialogSerialPort_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CSerialUI1_serialPortChange() Handles CSerialUI1.serialPortChange
        RaiseEvent serialPortNameChanged()
    End Sub

    Private Sub CSerialUI1_speedChange() Handles CSerialUI1.speedChange
        RaiseEvent serialSpeedChanged()
    End Sub
End Class