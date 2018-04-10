Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Windows.Forms

Public Class CMarqueeWebUI
    Private Property m_MarqueeId As Integer
    Private Property m_CImageId As Integer
    Private Property m_LayerId As Integer
    Private Property m_WebServerPath As String

    Public Event LayerChanged()
    Public Event CImageChanged()
    Public Event MarqueeChanged()

    Public Property ServerWebPath As String
        Get
            Return m_WebServerPath
        End Get
        Set(value As String)
            m_WebServerPath = value
        End Set
    End Property

    Public Property MarqueeId As Integer
        Set(value As Integer)
            m_MarqueeId = value
        End Set
        Get
            Return m_MarqueeId
        End Get
    End Property

    Public Property CImageId As Integer
        Get
            Return m_CImageId
        End Get
        Set(value As Integer)
            m_CImageId = value
        End Set
    End Property

    Public Property LayerId As Integer
        Get
            Return m_LayerId
        End Get
        Set(value As Integer)
            m_LayerId = value
        End Set
    End Property



    Private Sub TreeViewMarquees_AfterSelect(sender As Object, e As Windows.Forms.TreeViewEventArgs) Handles TreeViewMarquees.AfterSelect
        Dim id As TreeNode
        id = TreeViewMarquees.SelectedNode
        If id IsNot Nothing Then
            If id.Parent IsNot Nothing Then
                id = id.Parent
            End If
            id = id.Nodes.Find("id", True)(0)
            'MsgBox(id.Text)
            Dim web As New CWebTools
            Dim htmlcode As String = web.PHP(m_WebServerPath & "/marqueevb.php?id=" & id.Text, "POST", "")
            fillTreeViewCImage(htmlcode)
            RaiseEvent MarqueeChanged()
        End If
    End Sub

    Private Sub TreeViewCImages_AfterSelect(sender As Object, e As Windows.Forms.TreeViewEventArgs) Handles TreeViewCImages.AfterSelect
        Dim id As TreeNode
        id = TreeViewCImages.SelectedNode
        If id IsNot Nothing Then
            If id.Parent IsNot Nothing Then
                id = id.Parent
            End If
            id = id.Nodes.Find("id", True)(0)
            Dim web As New CWebTools
            Dim htmlcode As String = web.PHP(m_WebServerPath & "/cimagevb.php?id=" & id.Text, "POST", "")
            fillTreeViewLayer(htmlcode)
            RaiseEvent CImageChanged()
        End If
    End Sub

    Private Sub TreeViewLayer_AfterSelect(sender As Object, e As Windows.Forms.TreeViewEventArgs) Handles TreeViewLayer.AfterSelect
        Dim id As TreeNode
        id = TreeViewLayer.SelectedNode
        If id IsNot Nothing Then
            If id.Parent IsNot Nothing Then
                id = id.Parent
            End If
            id = id.Nodes.Find("id", True)(0)
            Dim Client As New WebClient
            Client.DownloadFile(m_WebServerPath & "/apercu.php?id=" & id.Text, Path.GetTempPath & "\" & id.Text & ".png")
            Client.Dispose()
            Using fs As New FileStream(Path.GetTempPath & "\" & id.Text & ".png", FileMode.Open, FileAccess.Read)
                Dim img = Image.FromStream(fs)
                PictureBoxWeb.Image = img
            End Using
        End If
        RaiseEvent LayerChanged()
    End Sub

    Private Sub CMarqueeWebUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If m_WebServerPath <> "" Then
            fillTreeViewMarquee()
        End If
    End Sub

    Private Function fillTreeViewMarquee() As String
        Dim value As String = ""
        Dim tmp As String
        Dim found As Boolean = False
        Dim Client As New WebClient
        TreeViewMarquees.Nodes.Clear()
        TreeViewCImages.Nodes.Clear()
        TreeViewLayer.Nodes.Clear()
        Dim node As TreeNode = Nothing
        Client.DownloadFile(m_WebServerPath & "/content.php", Path.GetTempPath & "\content.ini")
        If File.Exists(Path.GetTempPath & "\content.ini") Then
            Dim sr As StreamReader = File.OpenText(Path.GetTempPath & "\content.ini")
            Do While sr.Peek() >= 0 And Not found
                tmp = sr.ReadLine()
                If tmp(0) = "[" And tmp(tmp.Length - 1) = "]" Then
                    If node IsNot Nothing Then
                        TreeViewMarquees.Nodes.Add(node)
                    End If
                    node = New TreeNode(tmp)
                Else
                    node.Nodes.Add(tmp.Substring(0, tmp.IndexOf("=")), tmp.Substring(tmp.IndexOf("=") + 1))
                End If
            Loop
            If node IsNot Nothing Then
                TreeViewMarquees.Nodes.Add(node)
            End If
            sr.Close()
        End If
        Client.Dispose()
        Return value
    End Function

    Private Function fillTreeViewCImage(section As String) As String
        Dim value As String = ""
        Dim tmp As String
        Dim found As Boolean = False
        TreeViewCImages.Nodes.Clear()
        TreeViewLayer.Nodes.Clear()
        Dim node As TreeNode = Nothing
        Dim sr As StringReader = New StringReader(section)
        Do While sr.Peek() >= 0 And Not found
            tmp = sr.ReadLine()
            If tmp(0) = "[" And tmp(tmp.Length - 1) = "]" Then
                If node IsNot Nothing Then
                    TreeViewCImages.Nodes.Add(node)
                End If
                node = New TreeNode(tmp)
            Else
                node.Nodes.Add(tmp.Substring(0, tmp.IndexOf("=")), tmp.Substring(tmp.IndexOf("=") + 1))
            End If
        Loop
        If node IsNot Nothing Then
            TreeViewCImages.Nodes.Add(node)
        End If
        sr.Close()
        Return value
    End Function

    Private Function fillTreeViewLayer(section As String) As String
        Dim value As String = ""
        Dim tmp As String
        Dim found As Boolean = False
        TreeViewLayer.Nodes.Clear()
        Dim node As TreeNode = Nothing
        Dim sr As StringReader = New StringReader(section)
        Do While sr.Peek() >= 0 And Not found
            tmp = sr.ReadLine()
            If tmp(0) = "[" And tmp(tmp.Length - 1) = "]" Then
                If node IsNot Nothing Then
                    TreeViewLayer.Nodes.Add(node)
                End If
                node = New TreeNode(tmp)
            Else
                node.Nodes.Add(tmp.Substring(0, tmp.IndexOf("=")), tmp.Substring(tmp.IndexOf("=") + 1))
            End If
        Loop
        If node IsNot Nothing Then
            TreeViewLayer.Nodes.Add(node)
        End If
        sr.Close()
        Return value
    End Function

    Private Function PromptWindows(message As String, title As String, Optional defaultvalue As String = "no name")
        Dim myValue As Object
        ' Display message, title, and default value.
        myValue = InputBox(message, title, defaultValue)
        ' If user has clicked Cancel, set myValue to defaultValue
        If myValue Is "" Then myValue = defaultvalue
        Return myValue
    End Function

    Private Sub AddCImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddCImageToolStripMenuItem.Click
        Dim myValue As String = PromptWindows("Enter Marquee name", "Marquee name")
        Dim web As New CWebTools
        Dim htmlcode As String = web.PHP(m_WebServerPath & "/addmarqueevb.php", "POST", "marqueename=" & myValue)
        'MsgBox(htmlcode)
        fillTreeViewMarquee()
    End Sub

    Private Sub AddCImageToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AddCImageToolStripMenuItem1.Click
        Dim id As TreeNode
        id = TreeViewMarquees.SelectedNode
        If id IsNot Nothing Then

            'CPixelsPanel1.Visible = False

            If id.Parent IsNot Nothing Then
                id = id.Parent
            End If
            id = id.Nodes.Find("id", True)(0)
            Dim myValue As String = PromptWindows("Enter CImage name", "CImage name")
            Dim web As New CWebTools
            Dim htmlcode As String = web.PHP(m_WebServerPath & "/addcimagevb.php", "POST", "marqueeid=" & id.Text & "&imagename=" & myValue)
            fillTreeViewCImage(htmlcode)
        End If
    End Sub

    Private Sub AddLayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddLayerToolStripMenuItem.Click
        Dim id As TreeNode
        id = TreeViewCImages.SelectedNode
        If id IsNot Nothing Then
            If id.Parent IsNot Nothing Then
                id = id.Parent
            End If
            id = id.Nodes.Find("id", True)(0)
            Dim myValue As String = PromptWindows("Enter Layer name", "Layer name")
            My.Computer.Network.UploadFile(Path.GetTempPath & "\image001.png", m_WebServerPath & "/addlayervb.php?cimageid=" & id.Text & "&layername=" & myValue)
            Dim web As New CWebTools
            Dim htmlcode As String = web.PHP(m_WebServerPath & "/cimagevb.php?id=" & id.Text, "POST", "")
            fillTreeViewLayer(htmlcode)
            RaiseEvent CImageChanged()
        End If
    End Sub
End Class
