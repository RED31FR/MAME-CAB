Imports System.Drawing
Imports System.Drawing.Imaging

Public Class CFullImage
    Private Property m_SmallWidth As Integer
    Private Property m_SmallHeight As Integer
    Private Property m_StartPoint As Point = New Point(0, 0)
    Private Property m_Image As Image
    Private Property m_ButtonPressed As Boolean = False

    Public Event SelectionChanged()

    Public ReadOnly Property ImageWidth As Integer
        Get
            Return m_Image.Width
        End Get
    End Property

    Public ReadOnly Property ImageHeight As Integer
        Get
            Return m_Image.Height
        End Get
    End Property

    Public Property StartPoint As Point
        Get
            Return m_StartPoint
        End Get
        Set(value As Point)
            m_StartPoint = normStartPoint(value)
        End Set
    End Property

    Public Property Image As Image
        Get
            Return m_Image
        End Get
        Set(value As Image)
            m_Image = value.Clone
        End Set
    End Property

    Public Property SmallWidth As Integer
        Get
            Return m_SmallWidth
        End Get
        Set(value As Integer)
            m_SmallWidth = value
        End Set
    End Property

    Public Property SmallHeight As Integer
        Get
            Return m_SmallHeight
        End Get
        Set(value As Integer)
            m_SmallHeight = value
        End Set
    End Property

    Private Sub CFullImage_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim bit As Bitmap
        Dim g As Graphics
        Dim myPen As Pen = New Pen(Color.White, 2)
        myPen.DashCap = Drawing2D.DashCap.Round

        ' Create a custom dash pattern.
        myPen.DashPattern = New Single() {2.0F, 2.0F, 2.0F, 2.0F}

        'Dim myBrush As Brush = New SolidBrush(Color.Blue)
        If m_Image Is Nothing Then
            bit = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Else
            bit = New Bitmap(m_Image)
        End If
        g = Graphics.FromImage(bit)
        g.DrawRectangle(myPen, New Rectangle(m_StartPoint.X, m_StartPoint.Y, m_SmallWidth, m_SmallHeight)) 'New Rectangle(_selectionStartPoint.X, _selectionStartPoint.Y, sizex, sizey))
        Me.PictureBox1.Image = bit
    End Sub

    Public Function getSmallImage() As Image
        Dim myBitmap As Bitmap = New Bitmap(Me.m_Image)
        Dim format As PixelFormat = myBitmap.PixelFormat
        Dim image As Image = myBitmap.Clone(New Rectangle(m_StartPoint.X, m_StartPoint.Y, m_SmallWidth, m_SmallHeight), format)
        Return image
    End Function

    Private Sub PictureBox1_MouseUp(sender As Object, e As Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        m_ButtonPressed = False
        m_StartPoint = normStartPoint(New Point(e.X, e.Y))
        RaiseEvent SelectionChanged()
        Me.Invalidate()
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        m_ButtonPressed = True
        m_StartPoint = normStartPoint(New Point(e.X, e.Y))
        RaiseEvent SelectionChanged()
        Me.Invalidate()
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If m_ButtonPressed Then
            m_StartPoint = normStartPoint(New Point(e.X, e.Y))
            'RaiseEvent SelectionChanged()
            Me.Invalidate()
        End If
    End Sub

    Public Sub moveSelectionHorizontal(value As Integer)
        m_StartPoint = normStartPoint(New Point(m_StartPoint.X + value, m_StartPoint.Y))
        RaiseEvent SelectionChanged()
        Me.Invalidate()
    End Sub

    Public Sub moveSelectionVertical(value As Integer)
        m_StartPoint = normStartPoint(New Point(m_StartPoint.X, m_StartPoint.Y + value))
        RaiseEvent SelectionChanged()
        Me.Invalidate()
    End Sub

    Public Sub moveSelection(vertor As Point)
        m_StartPoint = normStartPoint(New Point(m_StartPoint.X + vertor.X, m_StartPoint.Y + vertor.Y))
        RaiseEvent SelectionChanged()
        Me.Invalidate()
    End Sub

    Private Function normStartPoint(p As Point) As Point
        If p.X < 0 Then
            p = New Point(0, p.Y)
        End If
        If p.Y < 0 Then
            p = New Point(p.X, 0)
        End If
        If p.X + m_SmallWidth > m_Image.Width Then
            p = New Point(m_Image.Width - m_SmallWidth, p.Y)
        End If
        If p.Y + m_SmallHeight > m_Image.Height Then
            p = New Point(p.X, m_Image.Height - m_SmallHeight)
        End If
        Return p
    End Function
End Class
