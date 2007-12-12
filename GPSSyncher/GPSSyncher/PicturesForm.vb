Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text

Public Class PicturesForm

    Private Sub PicturesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        populatePictureList()

    End Sub

    Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click
        Me.Close()
    End Sub

    Private Sub addButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addButton.Click

        Dim picturePath As String = ""

        Dim fDialog As OpenFileDialog = New OpenFileDialog()
        fDialog.Title = "Select NMEA GPS File"
        fDialog.Filter = "JPG files (*.JPG)|*.jpg"
        If fDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            fileNameField.Text = fDialog.FileName()

            Dim fs As FileStream = File.OpenRead(fileNameField.Text)
            Dim img As Image = Image.FromStream(fs, False, False)
            Dim thumbImg As Image = img.GetThumbnailImage(previewBox.Width, previewBox.Height, _
                Nothing, Nothing)
            previewBox.Image = thumbImg

            ' find the date this picture was taken
            If Not (img.GetPropertyItem(306) Is Nothing) Then
                Dim dtData As String = Encoding.ASCII.GetString(img.GetPropertyItem(306).Value())
                Dim dateString As String = dtData.Split(" ")(0)
                Dim timeString As String = dtData.Split(" ")(1)
                Dim dateParts As String() = dateString.Split(":")
                Dim timeParts As String() = timeString.Split(":")

                Dim dt As DateTime = New DateTime(Convert.ToInt32(dateParts(0)), _
                    Convert.ToInt32(dateParts(1)), Convert.ToInt32(dateParts(2)), _
                    Convert.ToInt32(timeParts(0)), Convert.ToInt32(timeParts(1)), _
                    Convert.ToInt32(timeParts(2)))
                DateTimePicker1.Value = dt

            End If

            fs.Close()

            saveButton.Enabled = True
        End If

    End Sub

    Private Sub saveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveButton.Click

        Dim dateTimeString As String = DateTimePicker1.Value.Year & "-" & _
            DateTimePicker1.Value.Month & "-" & DateTimePicker1.Value.Day & " " & _
            DateTimePicker1.Value.Hour & ":" & DateTimePicker1.Value.Minute & ":" & _
            DateTimePicker1.Value.Second
        Dim currentTimeString As String = DateTime.Now.Year & "-" & _
            DateTime.Now.Month & "-" & DateTime.Now.Day & " " & _
            DateTime.Now.Hour & ":" & DateTime.Now.Minute & ":" & _
            DateTime.Now.Second

        Dim dbConn As MySqlConnection = New MySqlConnection("Data Source=localhost; " & _
            "Database=cs4440; User ID=admin;")
        dbConn.Open()

        Dim dbCmd As MySqlCommand = New MySqlCommand()
        dbCmd.Connection = dbConn
        dbCmd.CommandType = CommandType.Text
        dbCmd.CommandText = "SELECT x, y FROM gpscoordinates WHERE time = '" & dateTimeString & "'"
        Dim dbReader As MySqlDataReader = dbCmd.ExecuteReader()
        Dim x, y As String
        If dbReader.Read Then
            x = dbReader("x")
            y = dbReader("y")
        Else
            MessageBox.Show("No GPS data can be applied to this picture. The X,Y values for this " & _
                "picture will be set to (0, 0)", "GPS Syncher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            x = "0"
            y = "0"
        End If
        dbReader.Close()

        dbCmd = New MySqlCommand()
        dbCmd.Connection = dbConn
        dbCmd.CommandType = CommandType.Text
        dbCmd.CommandText = "INSERT INTO images (filename, x, y, taken_at, uploaded_at) VALUES " & _
            "('" & fileNameField.Text.Split("\")(fileNameField.Text.Split("\").Length - 1) & "', " & _
            "'" & x & "', " & _
            "'" & y & "', " & _
            "'" & dateTimeString & "', " & _
            "'" & currentTimeString & "')"
        dbCmd.ExecuteNonQuery()

        dbConn.Close()
        dbConn.Dispose()

        Dim thumbImg As Image = previewBox.Image
        thumbImg.Save("C:\pictures\" & fileNameField.Text.Split("\")(fileNameField.Text.Split("\").Length - 1))

        MessageBox.Show("Successfully added picture!", "GPS Syncher", MessageBoxButtons.OK, _
            MessageBoxIcon.Information)
        saveButton.Enabled = False
        fileNameField.Text = ""
        previewBox.Image = Nothing

        populatePictureList()

    End Sub

    Private Sub populatePictureList()

        picturesList.Items.Clear()

        Dim dbConn As MySqlConnection = New MySqlConnection("Data Source=localhost; " & _
            "Database=cs4440; User ID=admin;")
        dbConn.Open()

        Dim dbCmd As MySqlCommand = New MySqlCommand
        dbCmd.Connection = dbConn
        dbCmd.CommandType = CommandType.Text
        dbCmd.CommandText = "SELECT * FROM images ORDER BY id"
        Dim dbReader As MySqlDataReader = dbCmd.ExecuteReader()

        While dbReader.Read()
            picturesList.Items.Add(dbReader("filename"))
        End While

        dbReader.Close()
        dbConn.Close()
        dbConn.Dispose()

    End Sub

    Private Sub deleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleteButton.Click

        If (MessageBox.Show("Are you sure you want to delete this image?", "Confirm", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then

            Dim dbConn As MySqlConnection = New MySqlConnection("Data Source=localhost; " & _
                        "Database=cs4440; User ID=admin;")
            dbConn.Open()

            Dim dbCmd As MySqlCommand = New MySqlCommand
            dbCmd.Connection = dbConn
            dbCmd.CommandType = CommandType.Text
            dbCmd.CommandText = "DELETE FROM images WHERE filename = '" & picturesList.Items(picturesList.SelectedIndex) & "'"
            Dim dbReader As MySqlDataReader = dbCmd.ExecuteReader()

            While dbReader.Read()
                picturesList.Items.Add(dbReader("filename"))
            End While

            dbReader.Close()
            dbConn.Close()
            dbConn.Dispose()

            MsgBox("Successfully deleted image!")
            populatePictureList()
            previewBox.Image = Nothing

        End If

    End Sub

    Private Sub picturesList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picturesList.SelectedIndexChanged

        Dim fs As FileStream = New FileStream("C:\pictures\" & picturesList.Items(picturesList.SelectedIndex), FileMode.Open)
        Dim img As Image = Image.FromStream(fs)
        previewBox.Image = img
        fs.Close()

    End Sub
End Class