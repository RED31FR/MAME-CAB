Imports System.Drawing
Imports System.Windows.Forms

Public Class CLayerUI
    Private Property m_Image As CImage
    Private Property heldDownPoint As Point
    Private Property heldDownItem As ListViewItem
    Private Property ContextMenuItem As ListViewItem
    Private Property previousListViewItem As ListViewItem
    Private Property previousListViewItemColor As Color
    Private Property layerIndex As Integer = 1
    Private Property m_SelectedLayer As Integer = 0

    Public Event ItemStateChange(index As Integer, state As Boolean)
    Public Event LayersChanged()

    Public Property Image As CImage
        Get
            Return m_Image
        End Get
        Set(value As CImage)
            Dim i As Integer = 0
            m_Image = value
            ListView1.Items.Clear()
            imageListSmall.Images.Clear()
            If m_Image IsNot Nothing Then
                layerIndex = m_Image.Layers.Count + 1
                For Each item In m_Image.Layers
                    imageListSmall.Images.Add(item.Image)
                    addItem(item.Name, i, item.State)
                    i += 1
                Next
            End If
        End Set
    End Property

    Public Sub clear()
        ListView1.Items.Clear()
        imageListSmall.Images.Clear()
    End Sub
    Private Sub CLayerUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Create a new ListView control.

        'listView1.Bounds = New Rectangle(New Point(0, 0), New Size(300, 200))
        listView1.Dock = DockStyle.Fill

        ' Set the view to show details.
        ListView1.View = View.Details
        ' Allow the user to edit item text.
        ListView1.LabelEdit = True
        ' Allow the user to rearrange columns.
        listView1.AllowColumnReorder = True
        ' Display check boxes.
        listView1.CheckBoxes = True
        ' Select the item and subitems when selection is made.
        listView1.FullRowSelect = True
        ' Display grid lines.
        listView1.GridLines = True
        ' Sort the items in the list in ascending order.
        'listView1.Sorting = SortOrder.Ascending

        ' Create columns for the items and subitems.
        ' Width of -2 indicates auto-size.
        ListView1.Columns.Add("Layer", 150, HorizontalAlignment.Left)
        ListView1.Columns.Add("Column 2", 60, HorizontalAlignment.Left)
        ListView1.Columns.Add("Column 3", 60, HorizontalAlignment.Left)
        ListView1.Columns.Add("Column 4", 60, HorizontalAlignment.Center)

        ' Create two ImageList objects.
        'Dim imageListSmall As New ImageList()
        'Dim imageListLarge As New ImageList()



        'Assign the ImageList objects to the ListView.
        ListView1.SmallImageList = imageListSmall

        ' Add the ListView to the control collection.
        Me.Controls.Add(listView1)

    End Sub

    Private Sub addItem(n As String, imgIndx As Integer, Optional s As Boolean = True)
        ' Create three items and three sets of subitems for each item.
        Dim item1 As New ListViewItem(n, imgIndx)
        ' Place a check mark next to the item.
        item1.Checked = s
        item1.SubItems.Add("1")
        item1.SubItems.Add("2")
        item1.SubItems.Add("3")
        If imgIndx = m_Image.SelectedLayer Then
            item1.BackColor = Color.LightBlue
        End If
        ListView1.Items.Add(item1)
    End Sub

    Private Sub ListView1_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles ListView1.ItemChecked
        RaiseEvent ItemStateChange(e.Item.Index, e.Item.Checked)
        'MsgBox(e.Item.Index)
    End Sub

    Private Sub ListView1_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles ListView1.ItemSelectionChanged
        m_Image.SelectedLayer = e.Item.Index

    End Sub

    Public Sub modeItemAt(pos As Integer, newPos As Integer)
        If pos <> newPos Then
            If pos < ListView1.Items.Count And newPos < ListView1.Items.Count Then
                Dim item As ListViewItem
                item = ListView1.Items(pos)
                ListView1.Items.Remove(item)
                ListView1.Items.Insert(newPos, item)
                m_Image.moveLayerTo(pos, newPos)
                m_Image.SelectedLayer = newPos
            End If
        End If
    End Sub

    Private Sub ListView1_MouseDown(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDown
        If e.Button = MouseButtons.Left Then
            heldDownItem = ListView1.GetItemAt(e.X, e.Y)
            If (heldDownItem IsNot Nothing) Then
                'heldDownPoint = New Point(e.X - heldDownItem.Position.X, e.Y - heldDownItem.Position.Y)
            End If
        Else
            ContextMenuItem = ListView1.GetItemAt(e.X, e.Y)
        End If

    End Sub

    Private Sub ListView1_MouseMove(sender As Object, e As MouseEventArgs) Handles ListView1.MouseMove
        If (heldDownItem IsNot Nothing) Then
            'heldDownItem.Position = New Point(e.Location.X - heldDownPoint.X, e.Location.Y - heldDownPoint.Y)
            Dim tmp As ListViewItem = ListView1.GetItemAt(e.X, e.Y)
            If tmp IsNot Nothing And previousListViewItem IsNot Nothing Then
                If tmp.Index <> previousListViewItem.Index Then
                    previousListViewItem.BackColor = previousListViewItemColor
                    previousListViewItem = tmp
                    previousListViewItemColor = tmp.BackColor
                    tmp.BackColor = Color.LightBlue
                End If
            ElseIf tmp IsNot Nothing Then
                previousListViewItem = tmp
            ElseIf previousListViewItem IsNot Nothing Then
                previousListViewItem.BackColor = previousListViewItemColor
                previousListViewItem = Nothing
            End If
            Cursor = Cursors.NoMove2D
        End If

    End Sub

    Private Sub ListView1_MouseUp(sender As Object, e As MouseEventArgs) Handles ListView1.MouseUp
        If heldDownItem IsNot Nothing Then
            Dim tmp As ListViewItem = ListView1.GetItemAt(e.X, e.Y)
            If tmp IsNot Nothing Then
                modeItemAt(heldDownItem.Index, tmp.Index)
                Me.Invalidate()
            End If
        End If
        heldDownItem = Nothing
        If previousListViewItem IsNot Nothing Then
            previousListViewItem.BackColor = previousListViewItemColor
            previousListViewItem = Nothing
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub AddLayer()
        Dim myValue As String = "Layer " & (layerIndex).ToString 'InputBox("Enter Value", "Enter Value", "Layer " & (m_Image.Count + 1).ToString)
        layerIndex += 1
        m_Image.add(New CLayer(myValue))
        imageListSmall.Images.Add(New Bitmap(1, 1))
        addItem(myValue, m_Image.Count - 1)
        m_Image.SelectedLayer = m_Image.Layers.Count - 1
        RaiseEvent LayersChanged()
        Dim i As Integer = 0
        ListView1.Items.Clear()
        imageListSmall.Images.Clear()
        If m_Image IsNot Nothing Then
            layerIndex = m_Image.Layers.Count + 1
            For Each item In m_Image.Layers
                imageListSmall.Images.Add(item.Image)
                addItem(item.Name, i, item.State)
                i += 1
            Next
        End If
    End Sub

    Public Sub DuplicateLayer()
        If m_Image.Layers.Count > 0 Then
            m_Image.add(New CLayer("Layer " & (layerIndex).ToString, m_Image.Item(m_Image.SelectedLayer)))
            'm_Image.add(New CLayer(m_Image.Layers(ContextMenuItem.Index).Name & " duplicate", m_Image.Item(ContextMenuItem.Index)))
            imageListSmall.Images.Add(m_Image.Item(m_Image.SelectedLayer))
            'addItem(m_Image.Layers(ContextMenuItem.Index).Name & " duplicate", m_Image.Count - 1)
            addItem("Layer " & (layerIndex).ToString, m_Image.Count - 1)
            layerIndex += 1
            RaiseEvent LayersChanged()
        End If
    End Sub

    Public Sub ImportLayer()
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "png files (*.png)|*.png|jpeg files (*.jpeg)|*.png|jpg files (*.jpg)|*.png|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                Dim myBitmap As Bitmap = New Bitmap(openFileDialog1.FileName)
                m_Image.add(New CLayer("Layer " & (layerIndex).ToString, myBitmap))
                imageListSmall.Images.Add(myBitmap)
                addItem("Layer " & (layerIndex).ToString, m_Image.Count - 1)
                layerIndex += 1
                RaiseEvent LayersChanged()
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally

            End Try
        End If
    End Sub

    Public Sub DeleteLayer(index As Integer)
        If m_Image.Layers.Count > 0 Then
            m_Image.removeAt(m_Image.SelectedLayer)
            imageListSmall.Images.RemoveAt(m_Image.SelectedLayer)
            ListView1.Items.RemoveAt(m_Image.SelectedLayer)
            ContextMenuItem = Nothing
            m_Image.SelectedLayer = m_Image.SelectedLayer - 1
            If m_Image.SelectedLayer < 0 Then
                m_Image.SelectedLayer = 0
            End If
            Me.Image = m_Image
            RaiseEvent LayersChanged()
        End If
    End Sub

    Private Sub AddLayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddLayerToolStripMenuItem.Click
        AddLayer()
    End Sub

    Private Sub DeleteLayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteLayerToolStripMenuItem.Click
        If ContextMenuItem IsNot Nothing Then
            If ContextMenuItem.Index < imageListSmall.Images.Count Then
                DeleteLayer(ContextMenuItem.Index)
            End If
        End If
    End Sub

    Public Sub createLayer()
        'm_Image.add(New CLayer(m_Image.Layers(m_Image.SelectedLayer).Name & " duplicate", m_Image.Item(m_Image.SelectedLayer)))
        m_Image.add(New CLayer("Layer " & (layerIndex).ToString, m_Image.Item(m_Image.SelectedLayer)))
        imageListSmall.Images.Add(m_Image.Item(m_Image.SelectedLayer))
        'addItem(m_Image.Layers(m_Image.SelectedLayer).Name & " duplicate", m_Image.Count - 1)
        addItem("Layer " & (layerIndex).ToString, m_Image.Count - 1)
        layerIndex += 1
        RaiseEvent LayersChanged()
    End Sub

    Private Sub DuplicateLayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateLayerToolStripMenuItem.Click
        If ContextMenuItem IsNot Nothing Then
            DuplicateLayer()
        End If
    End Sub

    Public Sub updateImageList(index As Integer, img As Image)
        imageListSmall.Images(index) = img
    End Sub

    Private Sub ListView1_AfterLabelEdit(sender As Object, e As LabelEditEventArgs) Handles ListView1.AfterLabelEdit
        m_Image.Layers(m_Image.SelectedLayer).Name = e.Label
        'RaiseEvent LayersChanged()
    End Sub

    Private Sub ImportLayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportLayerToolStripMenuItem.Click
        ImportLayer()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        For Each listviewItem As ListViewItem In ListView1.Items
            Dim index As Integer = ListView1.Items.IndexOf(listviewItem)
            ListView1.Items(index).BackColor = Color.Transparent
        Next
        Invalidate()
    End Sub

    Private Sub MergeLayersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MergeLayersToolStripMenuItem.Click
        Dim layer As CLayer
        layer = New CLayer("merge", m_Image.Image)
        m_Image.clear()
        m_Image.add(layer)
        Me.Image = m_Image
        layerIndex = 1
        'm_Image.CurrentLayer = m_Image.Layers(0)
        RaiseEvent LayersChanged()
    End Sub
End Class
