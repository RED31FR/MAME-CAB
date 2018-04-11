Public Class WebManager
    Private Sub CAuthentificationUI1_OnConnect() Handles CAuthentificationUI1.OnConnect
        CMarqueeWebUI1.Visible = True
    End Sub

    Private Sub CAuthentificationUI1_OnDisconnect() Handles CAuthentificationUI1.OnDisconnect
        CMarqueeWebUI1.Visible = False
    End Sub
End Class
