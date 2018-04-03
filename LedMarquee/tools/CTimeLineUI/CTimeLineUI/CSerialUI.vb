Imports System.Drawing

Public Class CSerialUI
    Public Event serialPortChange()
    Public Event speedChange()
    Public Event openPort()
    Public Event closePort()

    Public Sub setPortName(portName As String)
        Dim pos As Integer
        pos = ComboBoxSerialPorts.FindString(portName)
        If pos <> -1 Then
            ComboBoxSerialPorts.SelectedIndex = pos
        End If
    End Sub

    Public Function getPortName() As String
        Return ComboBoxSerialPorts.Text
    End Function

    Public Sub setSpeed(baud As String)
        Dim pos As Integer
        pos = ComboBoxBaud.FindString(baud)
        If pos <> -1 Then
            ComboBoxBaud.SelectedIndex = pos
        End If
    End Sub

    Public Function getSpeed() As Integer
        Return Convert.ToInt32(ComboBoxBaud.Text)
    End Function

    Private Sub CSerialManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ComboBoxSerialPorts.Items.Count = 0 Then
            For Each sp As String In My.Computer.Ports.SerialPortNames
                ComboBoxSerialPorts.Items.Add(sp)
            Next
            If ComboBoxSerialPorts.SelectedIndex = -1 Then
                ComboBoxSerialPorts.SelectedIndex = 0
            End If
        Else
            If ComboBoxSerialPorts.Items.Count <> My.Computer.Ports.SerialPortNames.Count Then
                Dim tmp As String
                tmp = ComboBoxSerialPorts.Text
                ComboBoxSerialPorts.Items.Clear()
                For Each sp As String In My.Computer.Ports.SerialPortNames
                    ComboBoxSerialPorts.Items.Add(sp)
                Next
                ComboBoxSerialPorts.SelectedItem = ComboBoxSerialPorts.FindString(tmp)
            End If
        End If
        RaiseEvent serialPortChange()
    End Sub

    Private Sub ComboBoxSerialPorts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxSerialPorts.SelectedIndexChanged
        Me.ButtonOpen.BackColor = SystemColors.Control
        Me.ButtonClose.BackColor = Color.Red
        RaiseEvent closePort()
        RaiseEvent serialPortChange()
    End Sub

    Private Sub ComboBoxBaud_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxBaud.SelectedIndexChanged
        Me.ButtonOpen.BackColor = SystemColors.Control
        Me.ButtonClose.BackColor = Color.Red
        RaiseEvent closePort()
        RaiseEvent speedChange()
    End Sub

    Private Sub ButtonOpen_Click(sender As Object, e As EventArgs) Handles ButtonOpen.Click
        Me.ButtonClose.BackColor = SystemColors.Control
        Me.ButtonOpen.BackColor = Color.Green
        RaiseEvent openPort()
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.ButtonOpen.BackColor = SystemColors.Control
        Me.ButtonClose.BackColor = Color.Red
        RaiseEvent closePort()
    End Sub
End Class
