﻿Imports CMarqueeObjects

Public Class TestForm
    Private Property m_Frames As CFrames

    Private Sub CToolsPaletteUI1_ButtonSeletionClick() Handles CToolsPaletteUI1.ButtonSeletionClick
        CPixelsPanel1.startSelection()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonPasteClick() Handles CToolsPaletteUI1.ButtonPasteClick
        CPixelsPanel1.startPaste()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonClearClick() Handles CToolsPaletteUI1.ButtonClearClick
        CPixelsPanel1.clear()
    End Sub

    Private Sub CToolsPaletteUI1__BackgroundColorChange() Handles CToolsPaletteUI1._BackgroundColorChange
        CPixelsPanel1.BackColor = CToolsPaletteUI1._backgroundColor
    End Sub

    Private Sub CToolsPaletteUI1__ForeColorChange() Handles CToolsPaletteUI1._ForeColorChange
        CPixelsPanel1.ForeColor = CToolsPaletteUI1._foreColor
    End Sub

    Private Sub CToolsPaletteUI1_ButtonLeftClick() Handles CToolsPaletteUI1.ButtonLeftClick
        CPixelsPanel1.MoveLeft()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonDownClick() Handles CToolsPaletteUI1.ButtonDownClick
        CPixelsPanel1.MoveDown()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonRightClick() Handles CToolsPaletteUI1.ButtonRightClick
        CPixelsPanel1.MoveRight()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonUpClick() Handles CToolsPaletteUI1.ButtonUpClick
        CPixelsPanel1.MoveUp()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonRotateLeftClick() Handles CToolsPaletteUI1.ButtonRotateLeftClick
        CPixelsPanel1.RotateLeft()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonRotateRightClick() Handles CToolsPaletteUI1.ButtonRotateRightClick
        CPixelsPanel1.RotateRight()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'CPixelsPanel1.startFill()

    End Sub

    Private Sub CToolsPaletteUI1_ButtonFillClick() Handles CToolsPaletteUI1.ButtonFillClick

    End Sub

    Private Sub CToolsPaletteUI1_ButtonFlipXClick() Handles CToolsPaletteUI1.ButtonFlipXClick
        CPixelsPanel1.FlipX()
    End Sub

    Private Sub CToolsPaletteUI1_ButtonFlipYClick() Handles CToolsPaletteUI1.ButtonFlipYClick
        CPixelsPanel1.FlipY()
    End Sub

    Private Sub CFullImage1_SelectionChanged() Handles CFullImage1.SelectionChanged
        CPixelsPanel1.SmallImage = CFullImage1.getSmallImage
        If m_Frames IsNot Nothing Then
            m_Frames.addFrame()
            m_Frames.goNext()
            m_Frames.setImage((CPixelsPanel1.SmallImage))
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        m_Frames.clear()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If CFullImage1.StartPoint.X = CFullImage1.ImageWidth - CFullImage1.SmallWidth - 1 Then
            Timer1.Stop()
            m_Frames._folderPath = "c:\temp\test2\"
            m_Frames.save(300, 5, "COM1", 9600)
        Else
            CFullImage1.moveSelectionVertical(1)
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Timer1.Stop()
        m_Frames.save(300, 5, "COM1", 9600)
    End Sub

    Private Sub TestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m_Frames = New CFrames("c:\temp\test2\", "image", "png")
        m_Frames.setImageSize(28, 10)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ofd As New OpenFileDialog
        If ofd.ShowDialog = DialogResult.OK Then
            If ofd.FileName <> String.Empty Then
                Me.CFullImage1.Image = Bitmap.FromFile(ofd.FileName)
                Me.CFullImage1.Invalidate()
            End If
        End If
    End Sub
End Class