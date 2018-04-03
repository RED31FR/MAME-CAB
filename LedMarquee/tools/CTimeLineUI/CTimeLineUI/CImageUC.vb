Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms

Public Class CImageUC
    Private Property m_transparent As Color = Color.Black
    Private Property m_Selection As Image
    Private Property m_ButtonIsDown As Boolean = False
    Private Property m_SelectionInProgress As Boolean = False
    Private Property m_FillProgress As Boolean = False
    Private Property m_PasteInProgress As Boolean = False
    Private Property m_MoveInProgress As Boolean = False
    Private Property m_PickColorInProgress As Boolean = False
    Private Property m_ReplaceInProgress As Boolean = False
    Private Property m_SelectionStartPoint As Point
    Private Property m_SelectionEndPoint As Point

    Private Property m_ForeColor As Color = Color.Red
    Private Property m_BackGroundColor As Color = m_transparent

    Private Property m_MousePosition As New Point(0, 0)

    Public Event PixelsChanged()
    Public Event ColorPicked(c As Color)


    Private Property m_Image As CImage
    Private Property m_Cols As Integer = 28
    Private Property m_Rows As Integer = 10
    Private Property m_Scale As Integer = 10
    Private Property m_Modified As Boolean = True

    Public Overrides Property ForeColor As Color
        Get
            Return m_ForeColor
        End Get
        Set(value As Color)
            m_ForeColor = value
        End Set
    End Property

    Public Overrides Property BackColor As Color
        Get
            Return m_BackGroundColor
        End Get
        Set(value As Color)
            m_BackGroundColor = value
        End Set
    End Property

    Public Property Modified As Boolean
        Get
            Return m_Modified
        End Get
        Set(value As Boolean)
            m_Modified = value
            Me.Invalidate()
        End Set
    End Property

    Public Property Image As CImage
        Get
            Return m_Image
        End Get
        Set(value As CImage)
            m_Image = value
            RaiseEvent PixelsChanged()
            'PictureBox1.Image = m_Image.Image
        End Set
    End Property


    Public Property Cols As Integer
        Set(value As Integer)
            m_Cols = value
            Sizing()
        End Set
        Get
            Return m_Cols
        End Get
    End Property

    Public Property Rows As Integer
        Set(value As Integer)
            m_Rows = value
            Sizing()
        End Set
        Get
            Return m_Rows
        End Get
    End Property

    Public Property ScaleFactor As Integer
        Get
            Return m_Scale
        End Get
        Set(value As Integer)
            m_Scale = value
            Sizing()
        End Set
    End Property

    Private Sub addPixel(x As Integer, y As Integer, color As Color)
        If x < Me.Width And y < Me.Height And m_Image.getState(m_Image.SelectedLayer) Then
            x = Math.Truncate(x / Me.ScaleFactor)
            y = Math.Truncate(y / Me.ScaleFactor)
            m_Image.SetPixel(m_Image.SelectedLayer, x, y, color)
        End If
        m_Modified = True
        Me.Invalidate()
    End Sub

    Private Sub drawPixel(x As Integer, y As Integer, color As Color)
        If PictureBox1.Image IsNot Nothing Then
            Dim g As Graphics = Graphics.FromImage(PictureBox1.Image)
            Dim myBrush As Brush = New SolidBrush(color)
            g.FillRectangle(myBrush, New Rectangle(x * Me.ScaleFactor, y * Me.ScaleFactor, Me.ScaleFactor, Me.ScaleFactor))
            g = Nothing
            myBrush = Nothing
            m_Modified = True
        End If
    End Sub

    Private Sub drawSelectionRect()
        Dim myPen As Pen = New Pen(Color.White, 2)
        Dim sizex, sizey As Integer
        myPen.DashCap = Drawing2D.DashCap.Round

        ' Create a custom dash pattern.
        myPen.DashPattern = New Single() {2.0F, 2.0F, 2.0F, 2.0F}

        Using g As Graphics = Graphics.FromImage(PictureBox1.Image)
            sizex = (m_SelectionEndPoint.X - m_SelectionStartPoint.X + 1)
            sizey = (m_SelectionEndPoint.Y - m_SelectionStartPoint.Y + 1)
            g.DrawRectangle(myPen, normalizeRect(m_SelectionStartPoint, m_SelectionEndPoint))
        End Using
        myPen = Nothing
        PictureBox1.Invalidate()
    End Sub

    Private Sub drawSelection(p As Point)
        If m_Selection IsNot Nothing Then
            Dim dst As Image = PictureBox1.Image
            Dim ori As Bitmap = New Bitmap(m_Selection)
            Dim brush As Brush
            Using g As Graphics = Graphics.FromImage(PictureBox1.Image)
                For i = 0 To m_Selection.Width - 1
                    For j = 0 To m_Selection.Height - 1
                        brush = New SolidBrush(ori.GetPixel(i, j))
                        g.FillRectangle(brush, New Rectangle(i * m_Scale + p.X, j * m_Scale + p.Y, m_Scale, m_Scale))
                    Next
                Next
                'g.DrawImage(m_Selection, p)
            End Using
            'PictureBox1.Image = image
            dst = Nothing
            ori = Nothing
            brush = Nothing
        End If

    End Sub

    Private Sub drawPixels()
        If m_Modified Then

            Dim myBitmap As Bitmap
            Dim color As Color
            'Me.PictureBox1.Image = New Bitmap(m_Cols * m_Scale + 1, m_Cols * m_Scale + 1)
            If m_Image.Image IsNot Nothing Then
                myBitmap = New Bitmap(m_Image.Image)
                For i = 0 To Me.Cols - 1
                    For j = 0 To Me.Rows - 1
                        color = myBitmap.GetPixel(i, j)
                        drawPixel(i, j, color)
                    Next
                Next
                myBitmap.MakeTransparent(Color.Transparent)
            End If
            m_Modified = False
            myBitmap = Nothing
        End If
    End Sub

    Private Sub drawGrid()
        If PictureBox1.Image Is Nothing Then
            Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                Dim myPen As Pen = New Pen(Color.Gray, 1)
                For i = 0 To Me.Cols - 1
                    For j = 0 To Me.Rows - 1
                        g.DrawRectangle(myPen, New Rectangle(i * Me.ScaleFactor, j * Me.ScaleFactor, Me.ScaleFactor, Me.ScaleFactor))
                    Next
                Next
            End Using
            bmp.MakeTransparent(Color.Transparent)
            PictureBox1.Image = bmp
            bmp = Nothing
        Else
            'Dim bmp As New Bitmap(PictureBox1.Image)
            Using g As Graphics = Graphics.FromImage(PictureBox1.Image)
                Dim myPen As Pen = New Pen(Color.Gray, 1)
                For i = 0 To Me.Cols - 1
                    For j = 0 To Me.Rows - 1
                        g.DrawRectangle(myPen, New Rectangle(i * Me.ScaleFactor, j * Me.ScaleFactor, Me.ScaleFactor, Me.ScaleFactor))
                    Next
                Next
            End Using
            'PictureBox1.Image = bmp
            'bmp = Nothing
        End If
        PictureBox1.Invalidate()

    End Sub

    Private Sub Sizing()
        Me.Width = m_Cols * m_Scale + 1
        Me.Height = m_Rows * m_Scale + 1
        Me.PictureBox1.Width = m_Cols * m_Scale + 1
        Me.PictureBox1.Height = m_Rows * m_Scale + 1
    End Sub

    Private Sub CImageUC_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        If PictureBox1.Image IsNot Nothing Then
            Using g As Graphics = Graphics.FromImage(PictureBox1.Image)
                g.Clear(Color.Transparent)
            End Using
        Else
            Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            PictureBox1.Image = bmp.Clone
            bmp = Nothing
        End If
        drawPixels()
        drawGrid()
        If (m_Selection IsNot Nothing Or m_SelectionInProgress) And Not m_MoveInProgress Then
            drawSelectionRect()
        End If
        If m_PasteInProgress Or m_MoveInProgress Then
            drawSelection(m_MousePosition)
        End If
    End Sub

    Private Function isInRectangle(p As Point, r As Rectangle) As Boolean
        Return r.Contains(p)
    End Function

    Private Function isInRectangle(p As Point, startRect As Point, endRect As Point) As Boolean
        Return isInRectangle(p, normalizeRect(startRect, endRect))
    End Function

    Private Function normalizeRect(ByVal p1 As Point, ByVal p2 As Point) As Rectangle
        Dim r As New Rectangle
        If p1.X < 0 Then
            p1.X = 0
        End If
        If p2.X < 0 Then
            p2.X = 0
        End If
        If p1.Y < 0 Then
            p1.Y = 0
        End If
        If p2.Y < 0 Then
            p2.Y = 0
        End If
        If p1.X < p2.X Then
            r.X = p1.X
            r.Width = p2.X - p1.X
        Else
            r.X = p2.X - Me.ScaleFactor
            r.Width = p1.X - p2.X + Me.ScaleFactor
        End If
        If p1.Y < p2.Y Then
            r.Y = p1.Y
            r.Height = p2.Y - p1.Y
        Else
            r.Y = p2.Y - Me.ScaleFactor
            r.Height = p1.Y - p2.Y + Me.ScaleFactor
        End If
        If r.Height + r.Y > m_Image.Image.Height * m_Scale Then
            r.Height = m_Image.Image.Height - r.Y
        End If
        If r.Width + r.X > m_Image.Image.Width * m_Scale Then
            r.Width = m_Image.Image.Width - r.X
        End If
        Return r
    End Function

    Public Sub MoveLeft()
        Dim image, image2 As Image
        image = m_Image.Item(m_Image.SelectedLayer)

        image2 = New Bitmap(image.Width, image.Height)
        Dim g, g2 As Graphics
        g = Graphics.FromImage(image)
        g2 = Graphics.FromImage(image2)

        Dim mat As New Drawing2D.Matrix
        mat.Translate(-1, 0)
        g2.Transform = mat
        g2.DrawImage(image, 0, 0)
        'Me.clear()
        m_Image.setImage(m_Image.SelectedLayer, image2)
        RaiseEvent PixelsChanged()
        Me.Modified = True
        Me.Invalidate()
    End Sub

    Public Sub MoveRight()
        Dim image, image2 As Image
        image = m_Image.Item(m_Image.SelectedLayer)

        image2 = New Bitmap(image.Width, image.Height)
        Dim g, g2 As Graphics
        g = Graphics.FromImage(image)
        g2 = Graphics.FromImage(image2)

        Dim mat As New Drawing2D.Matrix
        mat.Translate(1, 0)
        g2.Transform = mat
        g2.DrawImage(image, 0, 0)
        'Me.clear()
        m_Image.setImage(m_Image.SelectedLayer, image2)
        RaiseEvent PixelsChanged()
        Me.Modified = True
        Me.Invalidate()
    End Sub

    Public Sub MoveUp()
        Dim image, image2 As Image
        image = m_Image.Item(m_Image.SelectedLayer)

        image2 = New Bitmap(image.Width, image.Height)
        Dim g, g2 As Graphics
        g = Graphics.FromImage(image)
        g2 = Graphics.FromImage(image2)

        Dim mat As New Drawing2D.Matrix
        mat.Translate(0, -1)
        g2.Transform = mat
        g2.DrawImage(image, 0, 0)
        'Me.clear()
        m_Image.setImage(m_Image.SelectedLayer, image2)
        RaiseEvent PixelsChanged()
        Me.Modified = True
        Me.Invalidate()
    End Sub

    Public Sub MoveDown()
        Dim image, image2 As Image
        image = m_Image.Item(m_Image.SelectedLayer)

        image2 = New Bitmap(image.Width, image.Height)
        Dim g, g2 As Graphics
        g = Graphics.FromImage(image)
        g2 = Graphics.FromImage(image2)

        Dim mat As New Drawing2D.Matrix
        mat.Translate(0, 1)
        g2.Transform = mat
        g2.DrawImage(image, 0, 0)
        'Me.clear()
        m_Image.setImage(m_Image.SelectedLayer, image2)
        RaiseEvent PixelsChanged()
        Me.Modified = True
        Me.Invalidate()
    End Sub

    Public Sub RotateLeft()
        If m_Selection IsNot Nothing Then
            m_Selection.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Paste(m_Selection, m_SelectionStartPoint)
        Else
            m_Image.Item(m_Image.SelectedLayer).RotateFlip(RotateFlipType.Rotate90FlipNone)
        End If
        RaiseEvent PixelsChanged()
        Me.Modified = True
        Me.Invalidate()
    End Sub

    Public Sub RotateRight()
        If m_Selection IsNot Nothing Then
            m_Selection.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Paste(m_Selection, m_SelectionStartPoint)
        Else
            m_Image.Item(m_Image.SelectedLayer).RotateFlip(RotateFlipType.Rotate270FlipNone)
        End If
        RaiseEvent PixelsChanged()
        Me.Modified = True
        Me.Invalidate()
    End Sub

    Public Sub FlipX()
        If m_Selection IsNot Nothing Then
            m_Selection.RotateFlip(RotateFlipType.Rotate180FlipX)
            Paste(m_Selection, m_SelectionStartPoint)
        Else
            m_Image.Item(m_Image.SelectedLayer).RotateFlip(RotateFlipType.Rotate180FlipX)
        End If
        RaiseEvent PixelsChanged()
        Me.Modified = True
        Me.Invalidate()
    End Sub

    Public Sub FlipY()
        If m_Selection IsNot Nothing Then
            m_Selection.RotateFlip(RotateFlipType.Rotate180FlipY)
            Paste(m_Selection, m_SelectionStartPoint)
        Else
            m_Image.Item(m_Image.SelectedLayer).RotateFlip(RotateFlipType.Rotate180FlipY)
        End If
        RaiseEvent PixelsChanged()
        Me.Modified = True
        Me.Invalidate()
    End Sub

    Public Sub Paste()
        Paste(m_Selection, New Point(0, 0))
        Me.Modified = True
        Me.Invalidate()
        RaiseEvent PixelsChanged()
    End Sub

    Public Sub Paste(img As Image, p As Point)
        Dim image As Image = m_Image.Item(m_Image.SelectedLayer)
        If image IsNot Nothing Then
            Using g As Graphics = Graphics.FromImage(image)
                g.DrawImage(img, p)
            End Using
            m_Image.setImage(m_Image.SelectedLayer, image)
            image = Nothing
            RaiseEvent PixelsChanged()
            Me.Modified = True
            Me.Invalidate()
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        Me.m_ButtonIsDown = True
        If Not m_SelectionInProgress And Not m_PasteInProgress And Not m_MoveInProgress And Not m_FillProgress And Not _
            m_PickColorInProgress And Not m_ReplaceInProgress Then
            If Me.isInRectangle(New Point((e.X - (e.X Mod Me.ScaleFactor)), ((e.Y - (e.Y Mod Me.ScaleFactor)))), m_SelectionStartPoint, m_SelectionEndPoint) Then
                'Me.startMove()
            Else
                m_Selection = Nothing
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    addPixel(e.X, e.Y, Color.Transparent)
                Else
                    'drawPixel(Math.Truncate(e.X / Me.ScaleFactor), Math.Truncate(e.Y / Me.ScaleFactor), m_ForeColor)
                    addPixel(e.X, e.Y, m_ForeColor)
                End If
            End If
        Else
            If m_SelectionInProgress Then
                m_SelectionStartPoint = New Point((e.X - (e.X Mod Me.ScaleFactor)), ((e.Y - (e.Y Mod Me.ScaleFactor))))
                m_SelectionEndPoint = New Point((e.X - (e.X Mod Me.ScaleFactor)) + Me.ScaleFactor, ((e.Y - (e.Y Mod Me.ScaleFactor))) + Me.ScaleFactor)
            ElseIf m_PasteInProgress Then

            ElseIf m_MoveInProgress Then

                'Me.m_Selection = Nothing
            ElseIf m_FillProgress Then
                m_FillProgress = False

            ElseIf m_PickColorInProgress Then

            End If

        End If
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If Not m_SelectionInProgress And Not m_PasteInProgress And Not m_MoveInProgress And Not m_FillProgress And Not _
            m_PickColorInProgress And Not m_ReplaceInProgress Then
            If m_ButtonIsDown Then
                m_Selection = Nothing
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    addPixel(e.X, e.Y, Color.Transparent)
                Else
                    addPixel(e.X, e.Y, m_ForeColor)
                End If
                'RaiseEvent PixelsChanged()
                Me.Invalidate()
            End If
        Else
            If m_SelectionInProgress Then
                If m_ButtonIsDown Then
                    m_SelectionEndPoint = New Point((e.X - (e.X Mod Me.ScaleFactor)) + Me.ScaleFactor, ((e.Y - (e.Y Mod Me.ScaleFactor))) + Me.ScaleFactor)
                    Me.Modified = True
                    Me.Invalidate(normalizeRect(m_SelectionStartPoint, m_SelectionEndPoint))
                End If
            ElseIf m_PasteInProgress Then
                Me.Modified = True
                Me.Invalidate()
            ElseIf m_MoveInProgress Then
                'Paste(m_Selection, New Point((e.X - (e.X Mod Me.ScaleFactor)), ((e.Y - (e.Y Mod Me.ScaleFactor)))))
                'drawSelection(New Point((e.X - (e.X Mod Me.ScaleFactor)), ((e.Y - (e.Y Mod Me.ScaleFactor)))))

            End If
            'RaiseEvent PixelsChanged()
            m_MousePosition = New Point((e.X - (e.X Mod Me.ScaleFactor)), ((e.Y - (e.Y Mod Me.ScaleFactor))))
            'Me.Invalidate()
        End If

    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        m_ButtonIsDown = False
        If Not m_SelectionInProgress And Not m_PasteInProgress And Not m_MoveInProgress And Not m_FillProgress And Not _
            m_PickColorInProgress And Not m_ReplaceInProgress Then
            RaiseEvent PixelsChanged()
        Else
            If m_SelectionInProgress Then
                m_SelectionEndPoint = New Point((e.X - (e.X Mod Me.ScaleFactor)) + Me.ScaleFactor, ((e.Y - (e.Y Mod Me.ScaleFactor))) + Me.ScaleFactor)
                m_SelectionInProgress = False
                'createPixelsSelected()
            ElseIf m_PasteInProgress Then
                m_PasteInProgress = False
                pasteSelectionAt(New Point((e.X - (e.X Mod Me.ScaleFactor)), ((e.Y - (e.Y Mod Me.ScaleFactor)))))
                RaiseEvent PixelsChanged()
                Me.Modified = True
                Me.Invalidate()
            ElseIf m_MoveInProgress Then
                'Me.delete(m_SelectionStartPoint, m_SelectionEndPoint)
                'Me.pasteSelectionAt(New Point((e.X - (e.X Mod Me.ScaleFactor)), ((e.Y - (e.Y Mod Me.ScaleFactor)))))
                m_MoveInProgress = False
                RaiseEvent PixelsChanged()
                Me.Invalidate()
            ElseIf m_PickColorInProgress Then
                m_PickColorInProgress = False
                Dim myBitmap As New Bitmap(m_Image.Item(m_Image.SelectedLayer))
                RaiseEvent ColorPicked(myBitmap.GetPixel(Math.Truncate(e.X / Me.ScaleFactor), Math.Truncate(e.Y / Me.ScaleFactor)))
            End If
            If m_ReplaceInProgress Then
                Dim myBitmap As Bitmap = New Bitmap(m_Image.Image)
                Dim c As Color = myBitmap.GetPixel(Math.Truncate(e.X / Me.ScaleFactor), Math.Truncate(e.Y / Me.ScaleFactor))
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    replaceColor(c, m_BackGroundColor)
                Else
                    replaceColor(c, m_ForeColor)
                End If

                m_ReplaceInProgress = False
                Modified = True
                Me.Invalidate()
                RaiseEvent PixelsChanged()
            End If
        End If
    End Sub

    Private Sub replaceColor(c1 As Color, c2 As Color)
        Dim myBitmap As Bitmap = New Bitmap(m_Image.Item(m_Image.SelectedLayer))
        For i = 0 To myBitmap.Width - 1
            For j = 0 To myBitmap.Height - 1
                If c1 = myBitmap.GetPixel(i, j) Then
                    myBitmap.SetPixel(i, j, c2)
                End If
            Next
        Next
        myBitmap.MakeTransparent(m_transparent)
        m_Image.setImage(m_Image.SelectedLayer, myBitmap)
    End Sub

    Private Sub pasteSelectionAt(p As Point)
        Dim image As Image = m_Image.Item(m_Image.SelectedLayer)

        Using g As Graphics = Graphics.FromImage(image)
            g.DrawImage(m_Selection, New Point(p.X / m_Scale, p.Y / m_Scale))
        End Using
        m_Image.setImage(m_Image.SelectedLayer, image)
        image = Nothing
        m_Selection = Nothing
    End Sub

    Private Sub pasteSelectionAt()
        pasteSelectionAt(m_SelectionStartPoint)
    End Sub

    Public Sub startPickColor()
        If m_Image IsNot Nothing Then
            m_PickColorInProgress = True
        End If
    End Sub

    Public Sub startSelection()
        m_Selection = Nothing
        m_SelectionInProgress = True
        m_SelectionStartPoint = New Point(0, 0)
        m_SelectionEndPoint = New Point(0, 0)
    End Sub

    Public Sub startPaste()
        If m_Selection IsNot Nothing Then
            If m_Selection.Width = Me.m_Image.Image.Width And m_Selection.Height = Me.m_Image.Image.Height Then
                pasteSelectionAt(New Point(0, 0))
                RaiseEvent PixelsChanged()
            Else
                m_PasteInProgress = True
            End If

        End If
    End Sub

    Public Sub clearSelectedLayer()
        Dim bmp As New Bitmap(m_Image.Item(m_Image.SelectedLayer).Width, m_Image.Item(m_Image.SelectedLayer).Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(m_transparent)
        End Using
        bmp.MakeTransparent(m_transparent)
        m_Image.setImage(m_Image.SelectedLayer, bmp)
        bmp = Nothing
        m_Selection = Nothing
        RaiseEvent PixelsChanged()
        Me.Modified = True
        Me.Invalidate()
    End Sub

    Public Sub startReplaceColor(c As Color)
        m_ReplaceInProgress = True
    End Sub

    Private Sub createPixelsSelected()
        Dim myBitmap As Bitmap = New Bitmap(Me.m_Image.Item(m_Image.SelectedLayer))
        Dim p1 As Point = New Point(m_SelectionStartPoint.X / m_Scale, m_SelectionStartPoint.Y / m_Scale)
        Dim p2 As Point = New Point(m_SelectionEndPoint.X / m_Scale, m_SelectionEndPoint.Y / m_Scale)
        Dim cloneRect As Rectangle = normalizeRect(p1, p2)
        'Rectangle(_selectionStartPoint, New Size(_selectionEndPoint.X - _selectionStartPoint.X, _selectionEndPoint.Y - _selectionStartPoint.Y))
        Dim format As PixelFormat = myBitmap.PixelFormat

        m_Selection = myBitmap.Clone(cloneRect, format)
        myBitmap = Nothing
        cloneRect = Nothing
        format = Nothing
    End Sub

    Public Function copy()
        If m_SelectionStartPoint.X <> 0 And m_SelectionStartPoint.Y <> 0 And m_SelectionEndPoint.X <> 0 And m_SelectionEndPoint.Y Then
            createPixelsSelected()
        Else
            m_Selection = Me.m_Image.Item(m_Image.SelectedLayer).Clone
        End If
        Return m_Selection.Clone
    End Function
End Class
