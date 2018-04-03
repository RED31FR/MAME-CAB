Imports System.IO

Public Class CRandomFrames
    Private Property m_Folder As String
    Private Property m_SubFolders As New List(Of String)
    Public Property Folder As String
        Get
            Return m_Folder
        End Get
        Set(value As String)
            If Directory.Exists(value) Then
                m_Folder = value
                Dim Dirs() As String = Directory.GetDirectories(m_Folder)
                For Each Dir As String In Dirs
                    m_SubFolders.Add(Dir)
                Next
            End If
        End Set
    End Property

    Private Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    Public Function getFolder() As String
        Dim random As Integer = GetRandom(0, m_SubFolders.Count)
        Return m_SubFolders.Item(random) & "\"
    End Function

End Class
