Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class CLayer
    Private Property m_Image As Bitmap
    Private Property m_Name As String
    Private Property m_State As Boolean

    Public Property Name As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = value
        End Set
    End Property

    Public Property State As Boolean
        Get
            Return m_State
        End Get
        Set(value As Boolean)
            m_State = value
        End Set
    End Property

    Public Sub New(n As String)
        Image = New Bitmap(28, 10)
        Name = n
        State = True
    End Sub

    Public Sub New(n As String, img As Image, Optional s As Boolean = True)
        Image = New Bitmap(img)
        Name = n
        State = s
    End Sub

    Public Property Image As Image
        Get
            Return m_Image
        End Get
        Set(value As Image)
            m_Image = value.Clone
        End Set
    End Property

    Public Sub clear(color As Color)
        Using g As Graphics = Graphics.FromImage(m_Image)
            g.Clear(color)
        End Using
    End Sub
End Class


Public Class CImage
    Private Property m_Name As String
    Private Property m_Layers As New List(Of CLayer)
    Private Property m_SelectedLayer As Integer = 0

    Public Property Name As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = value
        End Set
    End Property

    Public ReadOnly Property CurrentLayer As CLayer
        Get
            Return m_Layers.Item(m_SelectedLayer)
        End Get
    End Property

    Public Property SelectedLayer As Integer
        Get
            Return m_SelectedLayer
        End Get
        Set(value As Integer)
            If value < m_Layers.Count Then
                m_SelectedLayer = value
            End If
        End Set
    End Property

    Public Sub New(n As String)
        m_Name = n
    End Sub

    Private Function CombineImages(ByVal img1 As Image, ByVal img2 As Image) As Image
        Dim newimage As New Bitmap(img1.Width, img1.Height)
        Dim g As Graphics = Graphics.FromImage(newimage)
        g.DrawImage(img1, 0, 0)
        g.DrawImage(img2, 0, 0)
        g.Dispose()
        newimage.MakeTransparent(Color.Transparent)
        Return newimage
    End Function

    Public ReadOnly Property Layers As List(Of CLayer)
        Get
            Return m_Layers
        End Get
    End Property

    Public ReadOnly Property Image As Bitmap
        Get
            Dim myBitmap As Bitmap = Nothing
            For Each layer In m_Layers
                If layer.State Then
                    If myBitmap Is Nothing Then
                        myBitmap = layer.Image
                    Else
                        myBitmap = CombineImages(myBitmap, layer.Image)
                    End If
                End If
            Next
            If myBitmap IsNot Nothing Then
                myBitmap.MakeTransparent(Color.Transparent)
            End If

            Return myBitmap
        End Get
    End Property

    Public ReadOnly Property Count As Integer
        Get
            Return m_Layers.Count
        End Get
    End Property

    Public Sub moveLayerTo(index As Integer, newPos As Integer)
        If index < m_Layers.Count And newPos < m_Layers.Count Then
            Dim layer As CLayer
            layer = m_Layers.Item(index)
            m_Layers.Remove(layer)
            m_Layers.Insert(newPos, layer)
        End If

    End Sub

    Public Sub clear()
        m_Layers.Clear()
    End Sub

    Public Sub add(l As CLayer)
        m_Layers.Add(l)
    End Sub

    Public Sub add(n As String, i As Image)
        m_Layers.Add(New CLayer(n, i))
    End Sub

    Public Function getState(ind As Integer) As Boolean
        If ind < m_Layers.Count And ind >= 0 Then
            Return m_Layers.Item(ind).State
        Else
            Return False
        End If
    End Function

    Public Sub setState(ind As Integer, state As Boolean)
        If ind < m_Layers.Count Then
            m_Layers.Item(ind).State = state ' Not m_Layers.Item(ind).State
        End If
    End Sub

    Public Sub setImage(index As Integer, img As Image)
        If index < m_Layers.Count Then
            m_Layers.Item(index).Image = img
        End If
    End Sub

    Public Function Item(i As Integer) As Image
        If i < m_Layers.Count Then
            Return m_Layers(i).Image
        Else
            Return Nothing
        End If
    End Function

    Public Sub removeAt(i As Integer)
        m_Layers.RemoveAt(i)
    End Sub

    Public Sub SetPixel(index As Integer, x As Integer, y As Integer, c As Color)
        If index < m_Layers.Count And x < m_Layers.Item(index).Image.Width And y < m_Layers.Item(index).Image.Height Then
            Dim myBitmap As New Bitmap(m_Layers.Item(index).Image)
            myBitmap.SetPixel(x, y, c)
            m_Layers.Item(index).Image = myBitmap.Clone
            myBitmap = Nothing
        End If
    End Sub

    Public Sub save(folder As String, index As Integer)
        If Not Directory.Exists(folder & Me.Name) Then
            Directory.CreateDirectory(folder & Me.Name)
        End If
        For Each layer In Me.m_Layers
            Dim indexLayer As Integer = m_Layers.IndexOf(layer)
            Dim indexStr As String
            If indexLayer < 10 Then
                indexStr = "00" & indexLayer.ToString
            ElseIf indexLayer < 100 Then
                indexStr = "0" & indexLayer.ToString
            Else
                indexStr = indexLayer.ToString
            End If
            If layer.State Then
                layer.Image.Save(folder & Me.Name & "\" & indexStr & "_c_" & layer.Name & ".png")
            Else
                layer.Image.Save(folder & Me.Name & "\" & indexStr & "_u_" & layer.Name & ".png")
            End If
        Next
        Me.Image.Save(folder & "output\" & Me.Name & ".png")
    End Sub

    Public Sub saveWeb(serverPath As String, cmarqueeID As Integer, index As Integer)
        Dim web As New CWebTools
        Dim htmlcode As String = web.PHP(serverPath & "/addcimagevb.php", "POST", "marqueeid=" & cmarqueeID & "&imagename=" & Me.Name)
        'MsgBox(htmlcode)        

        Dim jsonObj As JObject = JObject.Parse(htmlcode)

        'MsgBox(jsonObj.GetValue("id").ToString & " " & jsonObj.GetValue("name").ToString)



        For Each layer In Me.m_Layers
            Dim indexLayer As Integer = m_Layers.IndexOf(layer)
            Dim indexStr As String
            If indexLayer < 10 Then
                indexStr = "00" & indexLayer.ToString
            ElseIf indexLayer < 100 Then
                indexStr = "0" & indexLayer.ToString
            Else
                indexStr = indexLayer.ToString
            End If
            If layer.State Then
                layer.Image.Save(Path.GetTempPath & "\" & indexStr & "_c_" & layer.Name & ".png")
                web.UploadFile(Path.GetTempPath & "\" & indexStr & "_c_" & layer.Name & ".png", serverPath & "/addlayervb.php?cimageid=" & jsonObj.GetValue("id").ToString & "&layername=" & Me.Name)
                File.Delete(Path.GetTempPath & "\" & indexStr & "_c_" & layer.Name & ".png")
                'layer.Image.Save(folder & Me.Name & "\" & indexStr & "_c_" & layer.Name & ".png")
            Else
                'layer.Image.Save(folder & Me.Name & "\" & indexStr & "_u_" & layer.Name & ".png")
            End If
        Next
        'Me.Image.Save(folder & "output\" & Me.Name & ".png")
    End Sub

End Class

Public Class CFramesLayer
    Private Property m_CurrentImageIndex As Integer = -1
    Private Property m_Images As New List(Of CImage)
    Private Property m_folderPath As String
    Private Property m_fileNameRoot As String
    Private Property m_extention As String

    Public Property FolderPath As String
        Get
            Return m_folderPath
        End Get
        Set(value As String)
            m_folderPath = value
        End Set
    End Property

    Public Sub New()
        m_folderPath = ""
        m_fileNameRoot = "images"
        m_extention = "png"
    End Sub

    Public Sub New(path As String, filename As String, extention As String)
        m_folderPath = path
        m_fileNameRoot = filename
        m_extention = extention
    End Sub

    Public ReadOnly Property CurrentImage As CImage
        Get
            If m_CurrentImageIndex >= 0 Then
                Return m_Images.Item(m_CurrentImageIndex)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Property CurrentImageIndex As Integer
        Get
            Return m_CurrentImageIndex
        End Get
        Set(value As Integer)
            If value < m_Images.Count Then
                m_CurrentImageIndex = value
            End If
            If m_CurrentImageIndex < 0 Then
                m_CurrentImageIndex = 0
            End If
        End Set
    End Property

    Public ReadOnly Property Count As Integer
        Get
            Return m_Images.Count
        End Get
    End Property


    Public Sub clear()
        m_Images.Clear()
    End Sub

    Public Sub add(img As CImage)
        m_Images.Add(img)
        m_CurrentImageIndex = m_Images.Count - 1
    End Sub

    Public Sub addLayer(idx As Integer, n As String, img As Image)
        If idx < m_Images.Count Then
            m_Images(idx).add(New CLayer(n, img))
        End If
    End Sub

    Public Sub removeAt(Index As Integer)
        If Index < m_Images.Count Then
            m_Images.RemoveAt(Index)
            m_CurrentImageIndex -= 1
            If m_CurrentImageIndex < 0 Then
                m_CurrentImageIndex = 0
            End If
        End If
    End Sub

    Public Sub remoteLayerAt(IdxImage As Integer, idxLayer As Integer)

    End Sub

    Public Function item(index As Integer) As CImage
        If index < m_Images.Count Then
            Return m_Images.Item(index)
        Else
            Return Nothing
        End If
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

    Private Function getIniValue(section As String) As String
        Dim value As String = ""
        Dim tmp As String
        Dim found As Boolean = False
        If File.Exists(m_folderPath & "output\config.ini") Then
            Dim sr As StreamReader = File.OpenText(m_folderPath & "output\config.ini")
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

    Public Sub save(speed As String, Brightness As Byte, portName As String, serialspeed As Integer)
        If m_folderPath <> "" Then
            'delete all folders
            System.IO.Directory.Delete(m_folderPath, True)
            'Directory.Delete(m_folderPath, True)
            Directory.CreateDirectory(m_folderPath)
            If Not Directory.Exists(m_folderPath & "output") Then
                Directory.CreateDirectory(m_folderPath & "output")
            End If
            For Each image In m_Images
                image.save(m_folderPath, m_Images.IndexOf(image))
            Next
            Dim sw As StreamWriter = New StreamWriter(m_folderPath & "output\config.ini")
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
        End If
    End Sub

    Public Sub saveWeb(serverPath As String, name As String, speed As String, Brightness As Byte, portName As String, serialspeed As Integer)
        If serverPath <> "" Then
            'delete all folders            
            Dim web As New CWebTools
            Dim htmlcode As String = web.PHP(serverPath & "/addmarqueevb.php", "POST", "marqueename=" & name)
            'MsgBox(htmlcode)        

            Dim jsonObj As JObject = JObject.Parse(htmlcode)

            'MsgBox(jsonObj.GetValue("id").ToString & " " & jsonObj.GetValue("name").ToString)

            For Each image In m_Images
                image.saveWeb(serverPath, jsonObj.GetValue("id"), m_Images.IndexOf(image))
            Next
            'Dim sw As StreamWriter = New StreamWriter(m_folderPath & "output\config.ini")
            'Dim index As String = "00"

            'sw.WriteLine("[speed]")
            'sw.WriteLine(speed)
            'sw.WriteLine("[Brightness]")
            'sw.WriteLine(Brightness)
            'sw.WriteLine("[PortName]")
            'sw.WriteLine(portName)
            'sw.WriteLine("[SerialSpeed]")
            'sw.WriteLine(serialspeed)
            'sw.Close()
        End If
    End Sub

    Public Sub open()
        For Each Dir As String In Directory.GetDirectories(m_folderPath)
            If Dir <> m_folderPath & "output" Then
                Dim img As CImage

                img = New CImage(Path.GetFileName(Dir))
                For Each file As String In Directory.GetFiles(Dir)
                    Dim layer As CLayer
                    Dim filename As String = Path.GetFileName(file)
                    Dim filenameWithOutExt As String = Path.GetFileNameWithoutExtension(file)
                    If filename <> "config.ini" Then
                        Dim mybitmap As Bitmap
                        Using fs As New FileStream(file, FileMode.Open, FileAccess.Read)
                            mybitmap = Image.FromStream(fs)
                        End Using
                        layer = New CLayer(Mid(filenameWithOutExt, 7), mybitmap.Clone)
                        mybitmap = Nothing
                        If filename(4) = "u" Then
                            layer.State = False
                        ElseIf filename(4) = "c" Then
                            layer.State = True
                        End If
                        img.add(layer)
                    End If
                Next
                Me.add(img)
            End If
        Next
        Me.m_CurrentImageIndex = 0
    End Sub

    Public Function getPalette() As CPalette
        Dim palette As CPalette = New CPalette
        Dim myBitmap As Bitmap = New Bitmap(Me.m_Images.Item(Me.CurrentImageIndex).Image)
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
        Dim myBitmap As Bitmap = New Bitmap(Me.m_Images.Item(Me.CurrentImageIndex).Image)
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
        For Each itm In resultat
            pixels(pos) = itm
            pos += 1
        Next
        Return pixels
    End Function

    Public Function imageCompressToPixels() As Byte()
        Dim palette As Byte() = Me.paletteToBytes
        Dim pixels As Byte() = Me.pixelsToBytes

        '************************************************************************************************************
        '   Image Compress Format
        '************************************************************************************************************
        '   Value 255 is not allowed (when this value is encountered, it was changed by 254) Value 255 = end of block
        '************************************************************************************************************
        '   Byte 0 to 3                                         =>  Palette Size
        '************************************************************************************************************
        '   Byte 4 to (4 + Palette Size)                        => Palette Colors
        '   one color is 3 bytes (R, G, B)
        '************************************************************************************************************
        '   byte Palette Size + 4 to Palette Size + 7           =>  Pixels count * 2
        '   one byte for number of pixels, one byte for colr index in palette
        '************************************************************************************************************
        '   last byte                                           =>  End of file byte 255
        '************************************************************************************************************
        Dim resultat As Byte()
        If pixels.Count < 254 Then
            ReDim resultat(palette.Count + pixels.Count + 7)
        Else
            Dim nb As Integer = pixels.Count / 254
            ReDim resultat(palette.Count + pixels.Count + 7)
        End If

        Dim pos As Integer = 4
        Dim paletteSize As Integer = palette.Count
        If paletteSize > 762 Then
            resultat(0) = 254
            resultat(1) = 254
            resultat(2) = 254
            resultat(3) = paletteSize - 762
        ElseIf paletteSize > 508 Then
            resultat(0) = 0
            resultat(1) = 254
            resultat(2) = 254
            resultat(3) = paletteSize - 508
        ElseIf paletteSize > 254 Then
            resultat(0) = 0
            resultat(1) = 0
            resultat(2) = 254
            resultat(3) = paletteSize - 254
        Else
            resultat(0) = 0
            resultat(1) = 0
            resultat(2) = 0
            resultat(3) = paletteSize
        End If

        'resultat(pos) = palette.Count
        'pos = 4
        For Each itm In palette
            resultat(pos) = itm
            pos += 1
        Next
        If pixels.Count < 254 Then
            resultat(pos) = pixels.Count
            pos += 1
            resultat(pos) = 0
            pos += 1
            resultat(pos) = 0
            pos += 1

        ElseIf pixels.Count < 508 Then
            resultat(pos) = pixels.Count - 254
            pos += 1
            resultat(pos) = 254
            pos += 1
            resultat(pos) = 0
            pos += 1
        Else
            resultat(pos) = pixels.Count - 508
            pos += 1
            resultat(pos) = 254
            pos += 1
            resultat(pos) = 254
            pos += 1
        End If
        For Each itm In pixels
            resultat(pos) = itm
            pos += 1
        Next
        resultat(resultat.Count - 1) = 255
        Return resultat
    End Function

End Class
