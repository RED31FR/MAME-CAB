Imports System.Drawing
Imports System.Windows.Forms

Public Class CToolsPaletteUI
    Public Event _ForeColorChange()
    Public Event _BackgroundColorChange()
    Public Event ButtonCopyClick()
    Public Event ButtonPasteClick()
    Public Event ButtonClearClick()
    Public Event ButtonLeftClick()
    Public Event ButtonRightClick()
    Public Event ButtonUpClick()
    Public Event ButtonDownClick()
    Public Event ButtonSeletionClick()
    Public Event ButtonMoveClick()
    Public Event ButtonRotateLeftClick()
    Public Event ButtonRotateRightClick()
    Public Event ButtonFillClick()
    Public Event ButtonFlipXClick()
    Public Event ButtonFlipYClick()
    Public Event ButtonPickColorClick()
    Public Event ButtonReplaceColorClick(c As Color)
    Public Event ButtonDuplicateClick()

    Public Property _foreColor As Color
    Public Property _backgroundColor As Color

    Private Sub CToolsPalette_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _foreColor = ButtonForeColor1.BackColor
        _backgroundColor = ButtonBackgroundColor.BackColor
        ButtonForeColor1.BackColor = _foreColor
        Dim ToolTipCopy As ToolTip = New ToolTip()
        ToolTipCopy.SetToolTip(ButtonCopy, "Copy")
        Dim ToolTipPaste As ToolTip = New ToolTip()
        ToolTipPaste.SetToolTip(ButtonPaste, "Paste")
        Dim ToolTipClear As ToolTip = New ToolTip()
        ToolTipClear.SetToolTip(ButtonClear, "Clear")
        Dim ToolTipForeColor As ToolTip = New ToolTip()
        ToolTipClear.SetToolTip(ButtonForeColor1, "Fore Color")
        Dim ToolTipBackGroundColor As ToolTip = New ToolTip()
        ToolTipClear.SetToolTip(ButtonBackgroundColor, "Background Color")
        Dim ToolTipSelection As ToolTip = New ToolTip()
        ToolTipClear.SetToolTip(ButtonSelection, "Selection")
        RaiseEvent _ForeColorChange()
        RaiseEvent _BackgroundColorChange()
    End Sub

    Private Sub ButtonPaste_Click(sender As Object, e As EventArgs) Handles ButtonPaste.Click
        RaiseEvent ButtonPasteClick()
    End Sub

    Private Sub ButtonCopy_Click(sender As Object, e As EventArgs) Handles ButtonCopy.Click
        RaiseEvent ButtonCopyClick()
    End Sub

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        RaiseEvent ButtonClearClick()
    End Sub

    Private Sub ButtonLeft_Click(sender As Object, e As EventArgs) Handles ButtonLeft.Click
        RaiseEvent ButtonLeftClick()
    End Sub

    Private Sub ButtonRight_Click(sender As Object, e As EventArgs) Handles ButtonRight.Click
        RaiseEvent ButtonRightClick()
    End Sub

    Private Sub ButtonSelection_Click(sender As Object, e As EventArgs) Handles ButtonSelection.Click
        RaiseEvent ButtonSeletionClick()
    End Sub

    Private Sub ButtonUp_Click(sender As Object, e As EventArgs) Handles ButtonUp.Click
        RaiseEvent ButtonUpClick()
    End Sub

    Private Sub ButtonDown_Click(sender As Object, e As EventArgs) Handles ButtonDown.Click
        RaiseEvent ButtonDownClick()
    End Sub

    Private Sub ButtonForeColor3_MouseDown(sender As Object, e As MouseEventArgs) Handles ButtonForeColor3.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim colorDialog As New ColorDialog
            If colorDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                ButtonForeColor3.BackColor = colorDialog.Color
                _foreColor = colorDialog.Color
            End If
        Else
            _foreColor = ButtonForeColor3.BackColor
        End If
        unselectButton()
        selectButton(sender)
        RaiseEvent _ForeColorChange()
    End Sub

    Private Sub ButtonForeColor1_MouseDown(sender As Object, e As MouseEventArgs) Handles ButtonForeColor1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim colorDialog As New ColorDialog
            If colorDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                ButtonForeColor1.BackColor = colorDialog.Color
                _foreColor = colorDialog.Color
            End If
        Else
            _foreColor = ButtonForeColor1.BackColor
        End If
        unselectButton()
        selectButton(sender)
        RaiseEvent _ForeColorChange()
    End Sub

    Private Sub ButtonForeColor2_MouseDown(sender As Object, e As MouseEventArgs) Handles ButtonForeColor2.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim colorDialog As New ColorDialog
            If colorDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                ButtonForeColor2.BackColor = colorDialog.Color
                _foreColor = colorDialog.Color
            End If
        Else
            _foreColor = ButtonForeColor2.BackColor
        End If
        unselectButton()
        selectButton(sender)
        RaiseEvent _ForeColorChange()
    End Sub

    Private Sub ButtonBackgroundColor_MouseDown(sender As Object, e As MouseEventArgs) Handles ButtonBackgroundColor.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim colorDialog As New ColorDialog
            If colorDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                ButtonBackgroundColor.BackColor = colorDialog.Color
                _backgroundColor = colorDialog.Color
            End If
        Else
            _backgroundColor = ButtonBackgroundColor.BackColor
        End If
        RaiseEvent _BackgroundColorChange()
    End Sub

    Private Sub unselectButton()
        ButtonForeColor1.FlatAppearance.BorderSize = 0
        ButtonForeColor2.FlatAppearance.BorderSize = 0
        ButtonForeColor3.FlatAppearance.BorderSize = 0
    End Sub

    Private Sub selectButton(b As Button)
        b.FlatAppearance.BorderSize = 2
    End Sub

    Private Sub ButtonRotateLeft_Click(sender As Object, e As EventArgs) Handles ButtonRotateLeft.Click
        RaiseEvent ButtonRotateLeftClick()
    End Sub

    Private Sub ButtonRotateRight_Click(sender As Object, e As EventArgs) Handles ButtonRotateRight.Click
        RaiseEvent ButtonRotateRightClick()
    End Sub

    Private Sub ButtonFill_Click(sender As Object, e As EventArgs) Handles ButtonFill.Click
        RaiseEvent ButtonFillClick()
    End Sub

    Private Sub ButtonFlipX_Click(sender As Object, e As EventArgs) Handles ButtonFlipX.Click
        RaiseEvent ButtonFlipXClick()
    End Sub

    Private Sub ButtonFlipY_Click(sender As Object, e As EventArgs) Handles ButtonFlipY.Click
        RaiseEvent ButtonFlipYClick()
    End Sub

    Public Sub setColor(c As Color)
        _foreColor = c
        If ButtonForeColor1.FlatAppearance.BorderSize = 2 Then
            ButtonForeColor1.BackColor = c
            unselectButton()
            selectButton(ButtonForeColor1)
        ElseIf ButtonForeColor2.FlatAppearance.BorderSize = 2 Then
            ButtonForeColor2.BackColor = c
            unselectButton()
            selectButton(ButtonForeColor2)
        ElseIf ButtonForeColor3.FlatAppearance.BorderSize = 2 Then
            ButtonForeColor3.BackColor = c
            unselectButton()
            selectButton(ButtonForeColor3)
        End If
        RaiseEvent _ForeColorChange()
    End Sub

    Private Sub ButtonPickColor_Click(sender As Object, e As EventArgs) Handles ButtonPickColor.Click
        RaiseEvent ButtonPickColorClick()
    End Sub

    Private Sub ButtonReplaceColor_Click(sender As Object, e As EventArgs) Handles ButtonReplaceColor.Click
        If ButtonForeColor1.FlatAppearance.BorderSize = 2 Then
            RaiseEvent ButtonReplaceColorClick(ButtonForeColor1.BackColor)
        ElseIf ButtonForeColor2.FlatAppearance.BorderSize = 2 Then
            RaiseEvent ButtonReplaceColorClick(ButtonForeColor2.BackColor)
        ElseIf ButtonForeColor3.FlatAppearance.BorderSize = 2 Then
            RaiseEvent ButtonReplaceColorClick(ButtonForeColor3.BackColor)
        End If
    End Sub

    Private Sub ButtonDuplicate_Click(sender As Object, e As EventArgs) Handles ButtonDuplicate.Click
        RaiseEvent ButtonDuplicateClick()
    End Sub
End Class
