Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms

Public Class CPixelPanel
    Private Property _buttonIsDown As Boolean = False
    Private Property _selectionStartPoint As Point
    Private Property _selectionEndPoint As Point
    Private Property _image As Image

    Public Property _pixelsSelected As Image
    Public Property _selectionInProgress As Boolean = False
    Public Property _foreColor As Color = Color.Red
    Public Property _backGroundColor As Color = Color.Black
    Public Property _scale As Integer

    Public Event PixelChanged()
    Public Event selectionDone()

    Public Sub setImage(img As Image)
        Dim image As Image = Nothing
        Dim orignal As Image = img
        If img IsNot Nothing Then

            image = New Bitmap(orignal.Width * _scale() + 1, orignal.Height * _scale() + 1)
            Me.Width = orignal.Width * _scale() + 1
            Me.Height = orignal.Height * _scale() + 1
            Dim myBitmap As New Bitmap(orignal)

            'Dim bit As Bitmap
            Dim g As Graphics
            Dim myPen As Pen = New Pen(Color.Gray, 1)
            Dim myBrush As Brush

            g = Graphics.FromImage(image)
            g.Clear(Color.Black)
            For i = 0 To orignal.Width - 1
                For j = 0 To orignal.Height - 1
                    g.DrawRectangle(myPen, New Rectangle(i * _scale(), j * _scale(), _scale, _scale))
                    myBrush = Nothing
                    myBrush = New SolidBrush(myBitmap.GetPixel(i, j))
                    g.FillRectangle(myBrush, New Rectangle(i * _scale() + 1, j * _scale() + 1, _scale() - 1, _scale() - 1))
                Next
            Next
            myPen = Nothing
            myBrush = Nothing
            g = Nothing
            orignal = Nothing
            myBitmap = Nothing
        End If
        PictureBoxPixels.Image = image
        _image = image.Clone
        RaiseEvent PixelChanged()
    End Sub

    Public Sub unSelect()
        _pixelsSelected = Nothing
        _selectionEndPoint = Nothing
        _selectionStartPoint = Nothing
    End Sub

    Private Sub drawPixel(x As Integer, y As Integer, color As Color)
        Dim bit As Bitmap
        If x < Me.Width And y < Me.Height Then
            If _image Is Nothing Then
                bit = New Bitmap(PictureBoxPixels.Width, PictureBoxPixels.Height)
            Else
                bit = New Bitmap(_image, PictureBoxPixels.Width, PictureBoxPixels.Height)
            End If
            Dim g As Graphics = Graphics.FromImage(bit)
            Dim myBrush As Brush = New SolidBrush(color)
            x = Math.Truncate(x / _scale)
            y = Math.Truncate(y / _scale)
            g.FillRectangle(myBrush, New Rectangle(x * _scale + 1, y * _scale + 1, _scale - 1, _scale - 1))
            _image = bit.Clone
            Me.PictureBoxPixels.Image = bit
        End If
    End Sub

    Public Function getImage() As Image
        'If _pixelsSelected Is Nothing Then
        Return _image
        'Else
        'Return _pixelsSelected
        'End If
    End Function

    Public Function getImageSmall() As Image
        Dim image As Image
        Dim original As Image
        Dim w, h As Integer

        If _pixelsSelected Is Nothing Then
            'original = PictureBoxPixels.Image
            original = _image
        Else
            original = _pixelsSelected
        End If

        w = original.Width / _scale()
        h = original.Height / _scale()
        image = New Bitmap(w, h)

        Dim myBitmap As New Bitmap(original)
        Dim g As Graphics
        Dim myBrush As Brush

        g = Graphics.FromImage(image)
        For i = 1 To original.Width - 2 Step _scale
            For j = 1 To original.Height - 2 Step _scale
                myBrush = Nothing
                myBrush = New SolidBrush(myBitmap.GetPixel(i, j))
                g.FillRectangle(myBrush, New Rectangle(i / _scale, j / _scale, 1, 1))
            Next
        Next
        myBrush = Nothing
        g = Nothing
        original = Nothing
        myBitmap = Nothing
        Return image
    End Function

    Private Function normalizeRect(ByVal p1 As Point, ByVal p2 As Point) As Rectangle
        Dim r As New Rectangle
        If p1.X < p2.X Then
            r.X = p1.X
            r.Width = p2.X - p1.X
        Else
            r.X = p2.X
            r.Width = p1.X - p2.X + _scale
        End If
        If p1.Y < p2.Y Then
            r.Y = p1.Y
            r.Height = p2.Y - p1.Y
        Else
            r.Y = p2.Y
            r.Height = p1.Y - p2.Y + _scale
        End If
        If r.Width = 0 Then
            r.Width = _scale
        End If
        If r.Height = 0 Then
            r.Height = _scale
        End If
        Return r
    End Function


    Private Sub createPixelsSelected()
        Dim myBitmap As Bitmap = New Bitmap(Me.getImage)
        Dim cloneRect As Rectangle = normalizeRect(_selectionStartPoint, _selectionEndPoint)
        'Rectangle(_selectionStartPoint, New Size(_selectionEndPoint.X - _selectionStartPoint.X, _selectionEndPoint.Y - _selectionStartPoint.Y))
        Dim format As PixelFormat = myBitmap.PixelFormat

        _pixelsSelected = myBitmap.Clone(cloneRect, format)
    End Sub

    Private Sub PictureBoxPixels_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBoxPixels.MouseUp
        _buttonIsDown = False
        If _selectionInProgress Then
            '_selectionEndPoint = New Point((e.X - (e.X Mod _scale)) / _scale, ((e.Y - (e.Y Mod _scale)) / _scale))
            _selectionEndPoint = New Point((e.X - (e.X Mod _scale)) + _scale, ((e.Y - (e.Y Mod _scale))) + _scale)
            _selectionInProgress = False
            createPixelsSelected()
            RaiseEvent selectionDone()
            'draw()
        End If

        '_buttonIsDown = False
        RaiseEvent PixelChanged()
    End Sub

    Private Sub PictureBoxPixels_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBoxPixels.MouseDown
        _buttonIsDown = True
        If _selectionInProgress Then
            '_selectionStartPoint = New Point((e.X - (e.X Mod _scale)) / _scale, ((e.Y - (e.Y Mod _scale)) / _scale))
            _selectionStartPoint = New Point((e.X - (e.X Mod _scale)), ((e.Y - (e.Y Mod _scale))))
        Else

            If e.Button = Windows.Forms.MouseButtons.Right Then
                drawPixel(e.X, e.Y, _backGroundColor)
            Else
                drawPixel(e.X, e.Y, _foreColor)
            End If
        End If
        RaiseEvent PixelChanged()
    End Sub

    Private Sub PictureBoxPixels_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBoxPixels.MouseMove
        If _buttonIsDown And Not _selectionInProgress Then
            'drawSelectionSquare()

            If e.Button = Windows.Forms.MouseButtons.Right Then
                drawPixel(e.X, e.Y, _backGroundColor)
            Else
                drawPixel(e.X, e.Y, _foreColor)
            End If
        Else
            If _buttonIsDown Then 'And _selectionInProgress Then
                '_selectionEndPoint = New Point((e.X - (e.X Mod _scale)) / _scale, ((e.Y - (e.Y Mod _scale)) / _scale))
                _selectionEndPoint = New Point((e.X - (e.X Mod _scale)) + _scale, ((e.Y - (e.Y Mod _scale))) + _scale)
                'draw()
                drawSelectionSquare()
            ElseIf _pixelsSelected IsNot Nothing Then
                'draw()
                drawSelectionSquare()
            End If
            'DrawSelection(e)
        End If
        'drawSelectionSquare()
    End Sub

    Private Sub drawSelectionSquare()
        If _pixelsSelected IsNot Nothing Or _selectionInProgress Then
            Dim bit As Bitmap
            Dim g As Graphics
            Dim sizex, sizey As Integer
            Dim myPen As Pen = New Pen(Color.White, 2)
            myPen.DashCap = Drawing2D.DashCap.Round

            ' Create a custom dash pattern.
            myPen.DashPattern = New Single() {2.0F, 2.0F, 2.0F, 2.0F}

            'Dim myBrush As Brush = New SolidBrush(Color.Blue)
            If _image Is Nothing Then
                bit = New Bitmap(PictureBoxPixels.Width, PictureBoxPixels.Height)
            Else
                bit = New Bitmap(_image, PictureBoxPixels.Width, PictureBoxPixels.Height)
            End If
            g = Graphics.FromImage(bit)
            sizex = (_selectionEndPoint.X - _selectionStartPoint.X + 1)
            sizey = (_selectionEndPoint.Y - _selectionStartPoint.Y + 1)
            g.DrawRectangle(myPen, normalizeRect(_selectionStartPoint, _selectionEndPoint)) 'New Rectangle(_selectionStartPoint.X, _selectionStartPoint.Y, sizex, sizey))
            Me.PictureBoxPixels.Image = bit
        End If
    End Sub

    Private Sub DrawSelection(e As MouseEventArgs)
        Dim x, y As Integer
        'Dim XX, YY As Integer
        x = (e.X - (e.X Mod _scale))
        y = (e.Y - (e.Y Mod _scale))
        Dim g As Graphics = Graphics.FromImage(Me.getImage)
        g.DrawImage(_pixelsSelected, New Point(x, y))
    End Sub

    Public Sub clear()
        Dim image As Image = Nothing
        Dim orignal As Image = Me.getImageSmall
        If orignal IsNot Nothing Then
            image = New Bitmap(orignal.Width * _scale() + 1, orignal.Height * _scale() + 1)
            Me.Width = orignal.Width * _scale() + 1
            Me.Height = orignal.Height * _scale() + 1
            Dim myBitmap As New Bitmap(orignal)

            'Dim bit As Bitmap
            Dim g As Graphics
            Dim myPen As Pen = New Pen(Color.Gray, 1)
            Dim myBrush As Brush

            g = Graphics.FromImage(image)
            g.Clear(Color.Black)
            For i = 0 To orignal.Width - 1
                For j = 0 To orignal.Height - 1
                    g.DrawRectangle(myPen, New Rectangle(i * _scale(), j * _scale(), _scale, _scale))
                Next
            Next
            myPen = Nothing
            myBrush = Nothing
            g = Nothing
            orignal = Nothing
            myBitmap = Nothing
        End If
        PictureBoxPixels.Image = image
        RaiseEvent PixelChanged()
    End Sub

    Public Sub MoveLeft()
        Dim image, image2 As Image
        image = Me.getImageSmall

        image2 = New Bitmap(image.Width, image.Height)
        Dim g, g2 As Graphics
        g = Graphics.FromImage(image)
        g2 = Graphics.FromImage(image2)

        Dim mat As New Drawing2D.Matrix
        mat.Translate(-1, 0)
        g2.Transform = mat
        g2.DrawImage(image, 0, 0)
        Me.clear()
        Me.setImage(image2)
        RaiseEvent PixelChanged()
    End Sub

    Public Sub MoveRight()
        Dim image, image2 As Image
        image = Me.getImageSmall

        image2 = New Bitmap(image.Width, image.Height)
        Dim g, g2 As Graphics
        g = Graphics.FromImage(image)
        g2 = Graphics.FromImage(image2)

        Dim mat As New Drawing2D.Matrix
        mat.Translate(1, 0)
        g2.Transform = mat
        g2.DrawImage(image, 0, 0)
        Me.clear()
        Me.setImage(image2)
        RaiseEvent PixelChanged()
    End Sub

    Public Sub MoveDown()
        Dim image, image2 As Image
        image = Me.getImageSmall

        image2 = New Bitmap(image.Width, image.Height)
        Dim g, g2 As Graphics
        g = Graphics.FromImage(image)
        g2 = Graphics.FromImage(image2)

        Dim mat As New Drawing2D.Matrix
        mat.Translate(0, 1)
        g2.Transform = mat
        g2.DrawImage(image, 0, 0)
        Me.clear()
        Me.setImage(image2)
        RaiseEvent PixelChanged()
    End Sub

    Public Sub MoveUp()
        Dim image, image2 As Image
        image = Me.getImageSmall

        image2 = New Bitmap(image.Width, image.Height)
        Dim g, g2 As Graphics
        g = Graphics.FromImage(image)
        g2 = Graphics.FromImage(image2)

        Dim mat As New Drawing2D.Matrix
        mat.Translate(0, -1)
        g2.Transform = mat
        g2.DrawImage(image, 0, 0)
        Me.clear()
        Me.setImage(image2)
        RaiseEvent PixelChanged()
    End Sub

    Private Sub PictureBoxPixels_Paint(sender As Object, e As PaintEventArgs) Handles PictureBoxPixels.Paint
        'drawSelectionSquare()
    End Sub

    Public Sub pasteImageAt(p As Point, img As Image)
        'Dim g As Graphics = Graphics.FromImage(Me.PictureBoxPixels.Image)
        'g.DrawImage(img, p)

        Dim bit As Bitmap

        If _image Is Nothing Then
            bit = New Bitmap(PictureBoxPixels.Width, PictureBoxPixels.Height)
        Else
            bit = New Bitmap(_image, PictureBoxPixels.Width, PictureBoxPixels.Height)
        End If
        Dim g As Graphics = Graphics.FromImage(bit)
        g.DrawImage(img, p)

        _image = bit.Clone
        Me.PictureBoxPixels.Image = bit

    End Sub
End Class
