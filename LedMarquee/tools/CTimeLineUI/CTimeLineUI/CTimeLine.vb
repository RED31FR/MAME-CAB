Public Class CTimeLine

    Public Event buttonFirstClick()
    Public Event buttonPreviousClick()
    Public Event buttonPlayClick()
    Public Event buttonNextClick()
    Public Event buttonLastClick()
    Public Event buttonAddClick()
    Public Event buttonRemoveClick()
    Public Event trackTimerIntevalValueChange()
    Public Event trackTPositionValueChange()
    Public Event timerTick()

    Private Property _timerIsStarted As Boolean = False

    Private Sub ButtonFirst_Click(sender As Object, e As EventArgs) Handles ButtonFirst.Click
        RaiseEvent buttonFirstClick()
        setLabelPosMax()
    End Sub

    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        RaiseEvent buttonPreviousClick()
        setLabelPosMax()
    End Sub

    Private Sub ButtonPlay_Click(sender As Object, e As EventArgs) Handles ButtonPlay.Click
        RaiseEvent buttonPlayClick()
        setLabelPosMax()
    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        RaiseEvent buttonNextClick()
        setLabelPosMax()
    End Sub

    Private Sub ButtonLast_Click(sender As Object, e As EventArgs) Handles ButtonLast.Click
        RaiseEvent buttonLastClick()
        setLabelPosMax()
    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        setLabelPosMax()
        RaiseEvent buttonAddClick()
    End Sub

    Private Sub TrackBarTimerInterval_ValueChanged(sender As Object, e As EventArgs) Handles TrackBarTimerInterval.ValueChanged
        Timer1.Interval = TrackBarTimerInterval.Value
        RaiseEvent trackTimerIntevalValueChange()
    End Sub

    Private Sub TrackBarPosition_ValueChanged(sender As Object, e As EventArgs) Handles TrackBarPosition.ValueChanged
        RaiseEvent trackTPositionValueChange()
        setLabelPosMax()
    End Sub

    Private Sub ButtonRemove_Click(sender As Object, e As EventArgs) Handles ButtonRemove.Click
        RaiseEvent buttonRemoveClick()
        setLabelPosMax()
    End Sub

    Private Sub CTimeLine_EnabledChanged(sender As Object, e As EventArgs) Handles MyBase.EnabledChanged
        'If Me.Enabled = True Then
        'ButtonAdd.Enabled = True
        'Else
        'ButtonAdd.Enabled = False
        'End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        RaiseEvent timerTick()
    End Sub

    Public Sub changeTimerState()
        If _timerIsStarted Then
            Timer1.Stop()
        Else
            Timer1.Start()
        End If
        _timerIsStarted = Not _timerIsStarted
    End Sub

    Public Sub changeTrackBarPositionMinMaxPos(min As Integer, max As Integer, position As Integer)
        TrackBarPosition.Minimum = min
        TrackBarPosition.Maximum = max
        TrackBarPosition.Value = position
        setLabelPosMax()
    End Sub

    Public Function getTrackBarPosition()
        Return TrackBarPosition.Value
    End Function

    Public Function getSpeed() As Integer
        Return TrackBarTimerInterval.Value
    End Function

    Public Sub setSpeed(speed As Integer)
        If (speed < TrackBarTimerInterval.Maximum) Then
            TrackBarTimerInterval.Value = speed
        End If
    End Sub

    Public Sub setLabelPosMax()
        LabelPositionMax.Text = (TrackBarPosition.Value + 1).ToString & " / " & (TrackBarPosition.Maximum + 1).ToString
    End Sub

    Private Sub CTimeLine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setLabelPosMax()
    End Sub
End Class
