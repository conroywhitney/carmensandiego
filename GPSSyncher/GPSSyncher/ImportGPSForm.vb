Imports System.Windows.Forms
Imports System.Threading

Public Class ImportGPSForm

    Private _finished As Boolean = False

    Private Sub ImportGPSForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        statusLabel.Text = "Ready"
    End Sub

    Private Sub browseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseButton.Click

        Dim fDialog As OpenFileDialog = New OpenFileDialog()
        fDialog.Title = "Select NMEA GPS File"
        fDialog.Filter = "{NMEA GPS Files (*.txt)|*.txt|All Files (*.*)|*.*}"
        If fDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            fileNameField.Text = fDialog.FileName()
        End If

    End Sub

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click
        Me.Close()
    End Sub

    Private Sub okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okButton.Click
        If fileNameField.Text = "" Then
            MessageBox.Show("Please select a file to import!", "GPS Syncher", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            okButton.Enabled = False
            cancelButton.Enabled = False
            browseButton.Enabled = False
            _finished = False
            busySymbol.Visible = True
            statusLabel.Text = "Importing GPS coordinates. Please wait..."

            Dim t As Thread = New Thread(AddressOf runGPSParse)
            t.Start(fileNameField.Text)

            While (_finished = False)
                Application.DoEvents()
            End While

            okButton.Enabled = True
            cancelButton.Enabled = True
            browseButton.Enabled = True
            busySymbol.Visible = False
            statusLabel.Text = "Ready"

            MsgBox("Finished Importing GPS coordinates!")
        End If
    End Sub

    Private Sub runGPSParse(ByVal filename As Object)

        Dim importer As GPSImporter = New GPSImporter()
        importer.ParseGPSCoordinates(CStr(filename))
        _finished = True

    End Sub

End Class