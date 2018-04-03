Imports System
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports CMarqueeObjects

Public Class CPalette
    Private Property m_Items As New List(Of Color)
    Public ReadOnly Property Items As List(Of Color)
        Get
            Return m_Items
        End Get
    End Property

    Public Sub AddColor(c As Color)
        If Me.find(c) = -1 Then
            m_Items.Add(c)
        End If
    End Sub

    Public Function find(c As Color) As Integer
        For Each item In m_Items
            If item.R = c.R And item.G = c.G And item.B = c.B Then
                Return m_Items.IndexOf(item)
            End If
        Next
        Return -1
    End Function

    Public Function To_Bytes() As Byte()
        Dim nbColors = m_Items.Count - 1
        Dim nbBytes As Integer
        If nbColors Mod 2 = 0 Then
            nbBytes = nbColors * 1.5
        Else
            nbBytes = nbColors * 1.5 + 0.5
        End If
        Dim resultat(nbBytes - 1) As Byte
        Dim index As Integer = 0

        'Dim indx As Integer = 0
        For i = 0 To nbColors - 1
            Dim r, g, b As Byte
            r = m_Items(i).R << 4
            g = m_Items(i).G << 4
            b = m_Items(i).B << 4
            If i Mod 2 = 0 Then
                'r = r >> 1
                g = g >> 4
                'b = b >> 1
                resultat(index) = r + g
                index += 1
                resultat(index) = b
            Else
                r = r >> 4
                'g = g >> 4
                b = b >> 4
                resultat(index) = resultat(index) + r
                index += 1
                resultat(index) = g + b
                index += 1
            End If

        Next

        Return resultat
    End Function

    Public Function ToBytes() As Byte()
        Dim resultat((m_Items.Count) * 3 - 1) As Byte
        Dim index As Integer = 0
        For Each item In m_Items
            resultat(index) = item.R
            resultat(index + 1) = item.G
            resultat(index + 2) = item.B
            index += 3
        Next
        Return resultat
    End Function

End Class

Public Class CFrames

    Public Property _folderPath As String
    Public Property _fileNameRoot As String
    Public Property _extention As String
    Private Property _images As New ImageList
    Public Property _position As Integer = 0

    Private Property _sizeInit As Boolean = False

    Public Sub New(path As String, filename As String, extention As String)
        _folderPath = path
        _fileNameRoot = filename
        _extention = extention
    End Sub

    Public Sub open()
        Dim di As New IO.DirectoryInfo(_folderPath)
        Dim diar1 As IO.FileInfo() = di.GetFiles(_fileNameRoot & "*." & _extention)
        Dim dra As IO.FileInfo

        'list the names of all files in the specified directory
        For Each dra In diar1
            Me.addFrame(_folderPath & dra.ToString)
        Next
        di = Nothing
        diar1 = Nothing
        dra = Nothing
    End Sub

    Private Function getIniValue(section As String) As String
        Dim value As String = ""
        Dim tmp As String
        Dim found As Boolean = False
        If File.Exists(_folderPath & "config.ini") Then
            Dim sr As StreamReader = File.OpenText(_folderPath & "config.ini")
            Do While sr.Peek() >= 0 And Not found
                tmp = sr.ReadLine()
                If tmp = section Then
                    value = sr.ReadLine()
                    found = True
                End If
            Loop
            sr.Close()
        End If

        Return value
    End Function

    Public Function getPortName() As String
        Dim value As String = getIniValue("[PortName]")
        If value = "" Then
            value = "COM1"
        End If
        Return value
    End Function

    Public Function getBrightness() As String
        Dim value As String = getIniValue("[Brightness]")
        If value = "" Then
            value = "5"
        End If
        Return Convert.ToInt32(value)
    End Function

    Public Function getSerialSpeed() As Integer
        Dim value As String = getIniValue("[SerialSpeed]")
        If value = "" Then
            value = "9600"
        End If
        Return Convert.ToInt32(value)
    End Function

    Public Function getSpeed() As Integer
        Dim value As String = getIniValue("[speed]")
        If value = "" Then
            value = "50"
        End If
        Return Convert.ToInt32(value)
    End Function

    Public Sub save(speed As String, Brightness As Byte, portName As String, serialspeed As Integer)
        Dim picList As String() = Directory.GetFiles(_folderPath, _fileNameRoot & "*." & _extention)
        Dim sw As StreamWriter = New StreamWriter(_folderPath & "config.ini")
        Dim index As String = "00"

        sw.WriteLine("[speed]")
        sw.WriteLine(speed)
        sw.WriteLine("[Brightness]")
        sw.WriteLine(Brightness)
        sw.WriteLine("[PortName]")
        sw.WriteLine(portName)
        sw.WriteLine("[SerialSpeed]")
        sw.WriteLine(serialspeed)
        sw.Close()

        For Each f As String In picList
            File.Delete(f)
        Next

        For i = 0 To _images.Images.Count - 1
            If i < 10 Then
                index = "00" & i.ToString
            ElseIf i > 9 And i < 100 Then
                index = "0" & i.ToString
            End If
            _images.Images(i).Save((_folderPath & _fileNameRoot & index & "." & _extention))
        Next
    End Sub

    Public Sub setImageSize(w As Integer, h As Integer)
        _images.ImageSize = New Size(w, h)
        _sizeInit = True
    End Sub

    Public Function addFrame() As Boolean
        If (_sizeInit) Then
            Dim myBitmap As Image = New Bitmap(_images.ImageSize.Width, _images.ImageSize.Height)
            _images.Images.Add(myBitmap)
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function SafeImageFromFile(path As String) As Image
        Using fs As New FileStream(path, FileMode.Open, FileAccess.Read)
            Dim img = Image.FromStream(fs)
            Return img
        End Using
    End Function

    Public Function addFrame(file As String) As Boolean
        Dim myBitmap As Image

        myBitmap = SafeImageFromFile(file)
        If (Not _sizeInit) Then
            _images.ImageSize = New Size(myBitmap.Width, myBitmap.Height)
            _sizeInit = True
        End If
        If myBitmap.Width = _images.ImageSize.Width And myBitmap.Height = _images.ImageSize.Height Then
            _images.Images.Add(myBitmap)
            myBitmap = Nothing
            Return True
        Else
            myBitmap = Nothing
            Return False
        End If
    End Function

    Public Function count() As Integer
        Return _images.Images.Count
    End Function

    Public Function getImage(pos As Integer) As Image
        If (pos < Me.count) Then
            Return _images.Images(pos)
        Else
            Return Nothing
        End If
    End Function

    Public Sub setImage(pos As Integer, file As String)
        If pos < Me.count Then
            _images.Images(pos) = Nothing
            _images.Images(pos) = Bitmap.FromFile(file)
        End If
    End Sub

    Public Sub setImage(pos As Integer, ByVal image As Image)
        If pos < Me.count Then
            '_images.Images(pos) = Nothing
            _images.Images(pos) = image
        End If
    End Sub

    Public Sub setImage(ByVal image As Image)
        setImage(_position, image)
    End Sub

    Public Sub removeAt(pos As Integer)
        If pos < Me.count Then
            _images.Images.RemoveAt(pos)
            _position = pos - 1
            If _position < 0 Then
                _position = 0
            End If
        End If
    End Sub

    Public Sub remove()
        removeAt(_position)
    End Sub

    Public Sub clear()
        _images.Images.Clear()
        _position = 0
    End Sub

    Public Function goFirst() As Integer
        If Me.count > 0 Then
            _position = 0
            Return 0
        Else
            Return -1
        End If

    End Function

    Public Function goLast() As Integer
        If (Me.count > 0) Then
            _position = Me.count - 1
            Return _position
        Else
            Return -1
        End If
    End Function

    Public Function goNext() As Integer
        If _position < Me.count - 1 Then
            _position += 1
            Return _position
        Else
            Return -1
        End If
    End Function

    Public Function goPrevious() As Integer
        If _position > 0 Then
            _position -= 1
            Return _position
        Else
            Return -1
        End If
    End Function

    Public Function getImageScale(scale As Integer) As Image
        Dim image As Image
        Dim orignal As Image = Me.getImage
        image = New Bitmap(orignal.Width * scale + 1, orignal.Height * scale + 1)

        Dim myBitmap As New Bitmap(orignal)

        'Dim bit As Bitmap
        Dim g As Graphics
        Dim myPen As Pen = New Pen(Color.Gray, 1)
        Dim myBrush As Brush

        g = Graphics.FromImage(image)
        For i = 0 To orignal.Width - 1
            For j = 0 To orignal.Height - 1
                g.DrawRectangle(myPen, New Rectangle(i * scale, j * scale, scale, scale))
                myBrush = Nothing
                myBrush = New SolidBrush(myBitmap.GetPixel(i, j))
                g.FillRectangle(myBrush, New Rectangle(i * scale + 1, j * scale + 1, scale - 1, scale - 1))
            Next
        Next
        myPen = Nothing
        myBrush = Nothing
        g = Nothing
        orignal = Nothing
        myBitmap = Nothing
        Return image
    End Function

    Public Function getImage() As Image
        If Me.count > 0 Then
            Return _images.Images(_position)
        Else
            Return Nothing
        End If
    End Function

    Private Function getListOfPixelColor(ByRef pixels As List(Of CPixel), color As Color) As List(Of CPixel)
        Dim resultat As New List(Of CPixel)
        For Each pixel In pixels
            If pixel.Color = color Then
                resultat.Add(pixel)
            End If
        Next
        Return resultat
    End Function

    Public Function getPalette() As CPalette
        Dim palette As CPalette = New CPalette
        Dim myBitmap As Bitmap = New Bitmap(Me.getImage())
        Dim c As Color
        For j = 0 To myBitmap.Height - 1
            For i = 0 To myBitmap.Width - 1
                c = myBitmap.GetPixel(i, j)
                If (c.R = 255) Then
                    c = Color.FromArgb(254, c.G, c.B)
                End If
                If (c.G = 255) Then
                    c = Color.FromArgb(c.R, 254, c.B)
                End If
                If (c.B = 255) Then
                    c = Color.FromArgb(c.R, c.G, 254)
                End If
                palette.AddColor(c)
            Next
        Next
        Return palette
    End Function

    Public Function paletteToBytes() As Byte()
        Dim palette As CPalette = getPalette()
        Return palette.ToBytes()
    End Function

    Public Function pixelsToBytes() As Byte()
        Dim palette As CPalette = Me.getPalette()
        Dim color, previousColor As Color
        Dim nb As Byte = 0
        Dim myBitmap As Bitmap = New Bitmap(Me.getImage())
        Dim resultat As New List(Of Byte)
        color = myBitmap.GetPixel(0, 0)
        If (color.R = 255) Then
            color = Color.FromArgb(254, color.G, color.B)
        End If
        If (color.G = 255) Then
            color = Color.FromArgb(color.R, 254, color.B)
        End If
        If (color.B = 255) Then
            color = Color.FromArgb(color.R, color.G, 254)
        End If
        'previousColor = color
        For j = 0 To myBitmap.Height - 1
            For i = 0 To myBitmap.Width - 1
                previousColor = color
                If (j Mod 2 = 0) Then
                    color = myBitmap.GetPixel(i, j)
                Else
                    color = myBitmap.GetPixel(myBitmap.Width - i - 1, j)
                End If
                If (color.R = 255) Then
                    color = Color.FromArgb(254, color.G, color.B)
                End If
                If (color.G = 255) Then
                    color = Color.FromArgb(color.R, 254, color.B)
                End If
                If (color.B = 255) Then
                    color = Color.FromArgb(color.R, color.G, 254)
                End If
                If color.R = previousColor.R And color.G = previousColor.G And color.B = previousColor.B And nb < 254 Then
                    nb += 1
                Else
                    resultat.Add(nb)
                    resultat.Add(palette.find(previousColor))
                    nb = 1
                End If
            Next
        Next
        resultat.Add(nb)
        resultat.Add(palette.find(previousColor))
        Dim pixels(resultat.Count - 1) As Byte
        Dim pos As Integer = 0
        For Each item In resultat
            pixels(pos) = item
            pos += 1
        Next
        Return pixels
    End Function

    Public Function imageCompressToPixels() As Byte()
        Dim palette As Byte() = Me.paletteToBytes
        Dim pixels As Byte() = Me.pixelsToBytes

        Dim resultat As Byte()
        If pixels.Count < 254 Then
            ReDim resultat(palette.Count + pixels.Count + 2)
        Else
            Dim nb As Integer = pixels.Count / 254
            ReDim resultat(palette.Count + pixels.Count + nb + 1)
        End If

        Dim pos As Integer = 0
        resultat(pos) = palette.Count
        pos += 1
        For Each item In palette
            resultat(pos) = item
            pos += 1
        Next
        If pixels.Count < 254 Then
            resultat(pos) = pixels.Count
            pos += 1
            For Each item In pixels
                resultat(pos) = item
                pos += 1
            Next
        Else

        End If
        resultat(resultat.Count - 1) = 255
        Return resultat
    End Function

    Private Function convertPixelToByte(pixels As List(Of CPixel)) As Byte()
        Dim tmp As New List(Of CPixel)
        'tmp.AddRange(pixels)
        'tmp.Sort()
        Dim data(4) As Byte
        Dim c As Char
        c = "C"
        data(0) = Convert.ToByte(c)
        c = "L"
        data(1) = Convert.ToByte(c)
        c = "E"
        data(2) = Convert.ToByte(c)
        c = "A"
        data(3) = Convert.ToByte(c)
        c = "R"
        data(4) = Convert.ToByte(c)
        Dim pos = 5
        While pixels.Count > 0
            tmp = getListOfPixelColor(pixels, pixels(0).Color)
            If data Is Nothing Then
                Array.Resize(data, 8)
            Else
                Array.Resize(data, data.Length + 8)
            End If
            c = "D"
            data(pos) = Convert.ToByte(c)
            pos += 1
            c = "R"
            data(pos) = Convert.ToByte(c)
            pos += 1
            c = "A"
            data(pos) = Convert.ToByte(c)
            pos += 1
            c = "W"
            data(pos) = Convert.ToByte(c)
            pos += 1
            c = "P"
            data(pos) = Convert.ToByte(c)
            pos += 1
            data(pos) = pixels(0).Color.R
            pos += 1
            data(pos) = pixels(0).Color.G
            pos += 1
            data(pos) = pixels(0).Color.B
            pos += 1
            For Each pixel In tmp
                pixels.Remove(pixel)
                Array.Resize(data, data.Length + 2)
                data(pos) = pixel.X
                pos += 1
                data(pos) = pixel.Y
                pos += 1
            Next
            Array.Resize(data, data.Length + 2)
            data(pos) = 255
            pos += 1
            data(pos) = 255
            pos += 1
        End While
        Return data
    End Function

    Public Function getImageCommand() As Byte()
        Dim pixels As New List(Of CPixel)
        Dim datas As Byte()
        Dim original As Image = Me.getImage

        If original IsNot Nothing Then
            Dim taille As Integer
            taille = original.Width * original.Height - 1
            Dim data(taille) As Byte
            Dim myBitmap As New Bitmap(original)
            Dim color As Color
            For i = 0 To original.Width - 1
                For j = 0 To original.Height - 1

                    If j Mod 2 = 0 Then
                        color = myBitmap.GetPixel(i, j)

                    Else
                        color = myBitmap.GetPixel(original.Width - 1 - i, j)
                    End If
                    If Not (color.R = 0 And color.G = 0 And color.B = 0) Then
                        If color.R = 255 And color.G = 255 And color.B = 255 Then
                            pixels.Add(New CPixel(i, j, Color.FromArgb(254, 254, 254)))
                        Else
                            pixels.Add(New CPixel(i, j, color))
                        End If

                    End If
                Next
            Next
            color = Nothing
            original = Nothing
            myBitmap = Nothing
            'Return data
        Else
            original = Nothing
            Return Nothing
        End If
        datas = convertPixelToByte(pixels)
        Return datas
    End Function

    Public Function getImageByte() As Byte()
        Dim original As Image = Me.getImage

        If original IsNot Nothing Then
            Dim taille As Integer
            taille = original.Width * original.Height * 3 - 1
            Dim data(taille) As Byte
            Dim myBitmap As New Bitmap(original)
            Dim color As Color
            For i = 0 To original.Width - 1
                For j = 0 To original.Height - 1

                    If j Mod 2 = 0 Then
                        color = myBitmap.GetPixel(i, j)

                    Else
                        color = myBitmap.GetPixel(original.Width - 1 - i, j)
                    End If
                    data((i + j * original.Width) * 3) = color.R
                    data((i + j * original.Width) * 3 + 1) = color.B
                    data((i + j * original.Width) * 3 + 2) = color.G
                Next
            Next
            color = Nothing
            original = Nothing
            myBitmap = Nothing
            Return data
        Else
            original = Nothing
            Return Nothing
        End If
    End Function
End Class