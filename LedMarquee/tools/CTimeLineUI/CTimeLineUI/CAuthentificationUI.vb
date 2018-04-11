Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq

Public Class CAuthentificationUI
    Private Property m_Username As String
    Private Property m_Password As String
    Private Property m_UserIsConnect As Boolean = False
    Private Property m_ServerPath As String
    Private Property m_TableUsername As String
    Private Property m_UserNameFieldName As String
    Private Property m_PasswordFieldName As String

    Public Event OnConnect()
    Public Event OnDisconnect()

    Public ReadOnly Property IsConnect As Boolean
        Get
            Return m_UserIsConnect
        End Get
    End Property

    Public Property ServerPath As String
        Get
            Return m_ServerPath
        End Get
        Set(value As String)
            m_ServerPath = value
        End Set
    End Property

    Public Property TableUSerName As String
        Get
            Return m_TableUsername
        End Get
        Set(value As String)
            m_TableUsername = value
        End Set
    End Property

    Public Property UserNameFieldName As String
        Get
            Return m_UserNameFieldName
        End Get
        Set(value As String)
            m_UserNameFieldName = value
        End Set
    End Property

    Public Property PasswordFieldName As String
        Get
            Return m_PasswordFieldName
        End Get
        Set(value As String)
            m_PasswordFieldName = value
        End Set
    End Property



    Private Sub Connect()
        Dim php As New CWebTools
        Dim htmlcode As String = php.PHP(m_ServerPath & "/connect.php", "post", "table=" & m_TableUsername & "&userNameField=" & m_UserNameFieldName & "&passwordNameField=" & m_PasswordFieldName & "&userNameValue=" & m_Username & "&passwordValue=" & m_Password)
        Dim jsonObj As JObject = JObject.Parse(htmlcode)
        m_UserIsConnect = jsonObj.GetValue("connect") = "True"
        If m_UserIsConnect Then
            RaiseEvent OnConnect()
        Else
            MsgBox("Username or Password Incorrect")
            RaiseEvent OnDisconnect()
        End If
        SetState()
    End Sub

    Private Sub ButtonConnect_Click(sender As Object, e As EventArgs) Handles ButtonConnect.Click
        Connect()
    End Sub

    Private Sub UserName_TextChanged(sender As Object, e As EventArgs) Handles UserName.TextChanged
        m_Username = UserName.Text
    End Sub

    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles Password.TextChanged
        m_Password = Password.Text
    End Sub

    Private Sub UserName_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles UserName.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Connect()
        End If
    End Sub

    Private Sub Password_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Password.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Connect()
        End If
    End Sub

    Private Sub SetState(state As Boolean)
        If state Then
            UserName.Visible = True
            Password.Visible = True
            ButtonConnect.Visible = True
            ButtonDisconnect.Visible = False
        Else
            UserName.Visible = False
            Password.Visible = False
            ButtonConnect.Visible = False
            ButtonDisconnect.Visible = True
        End If
    End Sub

    Private Sub SetState()
        SetState(Not m_UserIsConnect)
    End Sub

    Private Sub CAuthentificationUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetState()
    End Sub

    Private Sub ButtonDisconnect_Click(sender As Object, e As EventArgs) Handles ButtonDisconnect.Click
        m_Username = ""
        m_Password = ""
        UserName.Text = ""
        Password.Text = ""
        m_UserIsConnect = False
        SetState()
        RaiseEvent OnDisconnect()
    End Sub
End Class
