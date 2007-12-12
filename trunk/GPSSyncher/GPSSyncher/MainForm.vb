Imports MySql.Data.MySqlClient

Public Class MainForm

    Private Sub ImportGPSCoordinatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportGPSCoordinatesToolStripMenuItem.Click
        Dim importForm As ImportGPSForm = New ImportGPSForm()
        importForm.MdiParent = Me
        importForm.Show()
    End Sub

    Private Sub GPSPointsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GPSPointsToolStripMenuItem.Click
        Dim pointsForm As GPSPointsForm = New GPSPointsForm()
        pointsForm.MdiParent = Me
        pointsForm.Show()
    End Sub

    Private Sub PictureDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureDataToolStripMenuItem.Click
        Dim pictureForm As PicturesForm = New PicturesForm()
        pictureForm.MdiParent = Me
        pictureForm.Show()
    End Sub
End Class
