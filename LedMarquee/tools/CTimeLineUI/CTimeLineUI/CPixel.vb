Imports System.Drawing

Public Class CPixel
    Implements IEquatable(Of CPixel)
    Implements IComparable(Of CPixel)

    Public Property X() As Integer
        Get
            Return m_X
        End Get
        Set(value As Integer)
            m_X = value
        End Set
    End Property

    Public Property Y() As Integer
        Get
            Return m_Y
        End Get
        Set(value As Integer)
            m_Y = value
        End Set
    End Property

    Public Property Color() As Color
        Get
            Return m_Color
        End Get
        Set(value As Color)
            m_Color = value
        End Set
    End Property

    Private m_X As Integer
    Private m_Y As Integer
    Private m_Color As Color

    'Public Overrides Function ToString() As String
    'Return "ID: " & PartId & "   Name: " & PartName
    'End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then
            Return False
        End If
        Dim objAsCPixel As CPixel = TryCast(obj, CPixel)
        If objAsCPixel Is Nothing Then
            Return False
        Else
            Return Equals(objAsCPixel)
        End If
    End Function

    Public Function SortByNameAscending(color1 As Color, color2 As Color) As Integer
        Return (color1.R.ToString & color1.G.ToString & color1.B.ToString).CompareTo(color2.R.ToString & color2.G.ToString & color2.B.ToString)
    End Function

    ' Default comparer for Part.
    Public Function CompareTo(comparePart As CPixel) As Integer _
            Implements IComparable(Of CPixel).CompareTo
        ' A null value means that this object is greater.
        If comparePart Is Nothing Then
            Return 1
        Else

            Return (Me.Color.R.ToString & Me.Color.G.ToString & Me.Color.B.ToString).CompareTo(comparePart.Color.R.ToString & comparePart.Color.G.ToString & comparePart.Color.B.ToString)
            'Me.Color.R.CompareTo(comparePart.Color.R) + Me.Color.G.CompareTo(comparePart.Color.G) + Me.Color.B.CompareTo(comparePart.Color.B)
        End If
    End Function

    Public Overloads Function Equals(other As CPixel) As Boolean Implements IEquatable(Of CPixel).Equals
        If other Is Nothing Then
            Return False
        End If
        Return (Me.Color.Equals(other.Color))
    End Function


    Public Sub New(x As Integer, y As Integer, color As Color)
        Me.X = x
        Me.Y = y
        Me.Color = color
    End Sub

End Class
