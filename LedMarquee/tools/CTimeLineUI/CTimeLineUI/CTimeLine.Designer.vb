<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CTimeLine
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TrackBarTimerInterval = New System.Windows.Forms.TrackBar()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TrackBarPosition = New System.Windows.Forms.TrackBar()
        Me.ButtonFirst = New System.Windows.Forms.Button()
        Me.ButtonPrevious = New System.Windows.Forms.Button()
        Me.ButtonPlay = New System.Windows.Forms.Button()
        Me.ButtonNext = New System.Windows.Forms.Button()
        Me.ButtonLast = New System.Windows.Forms.Button()
        Me.ButtonAdd = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonRemove = New System.Windows.Forms.Button()
        Me.LabelPositionMax = New System.Windows.Forms.Label()
        CType(Me.TrackBarTimerInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.TrackBarPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrackBarTimerInterval
        '
        Me.TrackBarTimerInterval.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TrackBarTimerInterval.Location = New System.Drawing.Point(0, 0)
        Me.TrackBarTimerInterval.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TrackBarTimerInterval.Maximum = 1500
        Me.TrackBarTimerInterval.Minimum = 5
        Me.TrackBarTimerInterval.Name = "TrackBarTimerInterval"
        Me.TrackBarTimerInterval.Size = New System.Drawing.Size(929, 61)
        Me.TrackBarTimerInterval.TabIndex = 0
        Me.TrackBarTimerInterval.Value = 130
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 43)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TrackBarTimerInterval)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TrackBarPosition)
        Me.SplitContainer1.Size = New System.Drawing.Size(929, 123)
        Me.SplitContainer1.SplitterDistance = 61
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 1
        '
        'TrackBarPosition
        '
        Me.TrackBarPosition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TrackBarPosition.LargeChange = 1
        Me.TrackBarPosition.Location = New System.Drawing.Point(0, 0)
        Me.TrackBarPosition.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TrackBarPosition.Name = "TrackBarPosition"
        Me.TrackBarPosition.Size = New System.Drawing.Size(929, 57)
        Me.TrackBarPosition.TabIndex = 1
        '
        'ButtonFirst
        '
        Me.ButtonFirst.Location = New System.Drawing.Point(5, 5)
        Me.ButtonFirst.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonFirst.Name = "ButtonFirst"
        Me.ButtonFirst.Size = New System.Drawing.Size(100, 28)
        Me.ButtonFirst.TabIndex = 2
        Me.ButtonFirst.Text = "<<"
        Me.ButtonFirst.UseVisualStyleBackColor = True
        '
        'ButtonPrevious
        '
        Me.ButtonPrevious.Location = New System.Drawing.Point(113, 5)
        Me.ButtonPrevious.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonPrevious.Name = "ButtonPrevious"
        Me.ButtonPrevious.Size = New System.Drawing.Size(100, 28)
        Me.ButtonPrevious.TabIndex = 2
        Me.ButtonPrevious.Text = "<"
        Me.ButtonPrevious.UseVisualStyleBackColor = True
        '
        'ButtonPlay
        '
        Me.ButtonPlay.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonPlay.Location = New System.Drawing.Point(221, 5)
        Me.ButtonPlay.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonPlay.Name = "ButtonPlay"
        Me.ButtonPlay.Size = New System.Drawing.Size(100, 28)
        Me.ButtonPlay.TabIndex = 2
        Me.ButtonPlay.Text = "|>"
        Me.ButtonPlay.UseVisualStyleBackColor = True
        '
        'ButtonNext
        '
        Me.ButtonNext.Location = New System.Drawing.Point(329, 5)
        Me.ButtonNext.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonNext.Name = "ButtonNext"
        Me.ButtonNext.Size = New System.Drawing.Size(100, 28)
        Me.ButtonNext.TabIndex = 2
        Me.ButtonNext.Text = ">"
        Me.ButtonNext.UseVisualStyleBackColor = True
        '
        'ButtonLast
        '
        Me.ButtonLast.Location = New System.Drawing.Point(437, 5)
        Me.ButtonLast.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonLast.Name = "ButtonLast"
        Me.ButtonLast.Size = New System.Drawing.Size(100, 28)
        Me.ButtonLast.TabIndex = 2
        Me.ButtonLast.Text = ">>"
        Me.ButtonLast.UseVisualStyleBackColor = True
        '
        'ButtonAdd
        '
        Me.ButtonAdd.Location = New System.Drawing.Point(545, 5)
        Me.ButtonAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.Size = New System.Drawing.Size(100, 28)
        Me.ButtonAdd.TabIndex = 2
        Me.ButtonAdd.Text = "+"
        Me.ButtonAdd.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'ButtonRemove
        '
        Me.ButtonRemove.Location = New System.Drawing.Point(653, 5)
        Me.ButtonRemove.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonRemove.Name = "ButtonRemove"
        Me.ButtonRemove.Size = New System.Drawing.Size(100, 28)
        Me.ButtonRemove.TabIndex = 3
        Me.ButtonRemove.Text = "-"
        Me.ButtonRemove.UseVisualStyleBackColor = True
        '
        'LabelPositionMax
        '
        Me.LabelPositionMax.AutoSize = True
        Me.LabelPositionMax.Location = New System.Drawing.Point(761, 11)
        Me.LabelPositionMax.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelPositionMax.Name = "LabelPositionMax"
        Me.LabelPositionMax.Size = New System.Drawing.Size(51, 17)
        Me.LabelPositionMax.TabIndex = 4
        Me.LabelPositionMax.Text = "Label1"
        '
        'CTimeLine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelPositionMax)
        Me.Controls.Add(Me.ButtonRemove)
        Me.Controls.Add(Me.ButtonAdd)
        Me.Controls.Add(Me.ButtonLast)
        Me.Controls.Add(Me.ButtonNext)
        Me.Controls.Add(Me.ButtonPlay)
        Me.Controls.Add(Me.ButtonPrevious)
        Me.Controls.Add(Me.ButtonFirst)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "CTimeLine"
        Me.Size = New System.Drawing.Size(929, 166)
        CType(Me.TrackBarTimerInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.TrackBarPosition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TrackBarTimerInterval As Windows.Forms.TrackBar
    Friend WithEvents SplitContainer1 As Windows.Forms.SplitContainer
    Friend WithEvents TrackBarPosition As Windows.Forms.TrackBar
    Friend WithEvents ButtonFirst As Windows.Forms.Button
    Friend WithEvents ButtonPrevious As Windows.Forms.Button
    Friend WithEvents ButtonPlay As Windows.Forms.Button
    Friend WithEvents ButtonNext As Windows.Forms.Button
    Friend WithEvents ButtonLast As Windows.Forms.Button
    Friend WithEvents ButtonAdd As Windows.Forms.Button
    Friend WithEvents Timer1 As Windows.Forms.Timer
    Friend WithEvents ButtonRemove As Windows.Forms.Button
    Friend WithEvents LabelPositionMax As Windows.Forms.Label
End Class
