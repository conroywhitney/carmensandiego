Imports MySql.Data.MySqlClient

Public Class GPSPointsForm

    Private Sub GPSPointsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dbConn As MySqlConnection = New MySqlConnection("Data Source=localhost; " & _
            "Database=cs4440; User ID=admin;")
        dbConn.Open()
        Dim dbAdapter As MySqlDataAdapter = New MySqlDataAdapter("SELECT * FROM gpscoordinates " & _
            "ORDER BY time", dbConn)
        Dim dt As DataTable = New DataTable
        dbAdapter.Fill(dt)

        dataTable.DataSource = dt

        dbConn.Close()

    End Sub

End Class