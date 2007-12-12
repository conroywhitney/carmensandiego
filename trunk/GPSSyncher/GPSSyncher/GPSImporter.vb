Imports MySql.Data.MySqlClient
Imports System.IO

Public Class GPSImporter

    Public Sub ParseGPSCoordinates(ByVal filename As String)

        ' Open a file stream to the filename specified
        Dim fs As FileStream = New FileStream(filename, FileMode.Open)
        Dim reader As StreamReader = New StreamReader(fs)

        ' Create a connection to the MySQL database
        Dim dbConn As MySqlConnection = New MySqlConnection("Data Source=localhost; " & _
            "Database=cs4440; User ID=admin;")
        dbConn.Open()
        Dim dbCmd As MySqlCommand

        ' Read through each line in the file one by one, and parse the $GPRMC lines
        Dim line As String = reader.ReadLine()
        Dim lineParts As String()
        Dim timeString, xString, yString, dateString, fullTimestamp As String
        Dim x, y As Double
        Do While line <> ""
            lineParts = line.Split(",")
            If lineParts(0) = "$GPRMC" Then
                timeString = lineParts(1)
                xString = lineParts(5)
                yString = lineParts(3)
                dateString = lineParts(9)

                '   adjust the hour from UTC to EST (EST = UTC - 5 hours)
                Dim time As DateTime = New DateTime(Convert.ToInt32("20" & dateString.Substring(4, 2)), _
                    Convert.ToInt32(dateString.Substring(2, 2)), _
                    Convert.ToInt32(dateString.Substring(0, 2)), _
                    Convert.ToInt32(timeString.Substring(0, 2)), _
                    Convert.ToInt32(timeString.Substring(2, 2)), _
                    Convert.ToInt32(timeString.Substring(4, 2)))
                Dim fiveHours As TimeSpan = New TimeSpan(5, 0, 0)
                time = time.Subtract(fiveHours)

                fullTimestamp = time.Year & "-" & time.Month & "-" & time.Day & " " & _
                    time.Hour & ":" & time.Minute & ":" & time.Second
                x = Double.Parse(xString.Substring(0, 3)) + (Double.Parse(xString.Substring(3)) / 60)
                y = Double.Parse(yString.Substring(0, 2)) + (Double.Parse(yString.Substring(2)) / 60)
                x = (-1) * x

                dbCmd = New MySqlCommand()
                dbCmd.CommandType = CommandType.Text
                dbCmd.Connection = dbConn
                dbCmd.CommandText = "INSERT INTO gpscoordinates VALUES ('" & _
                    fullTimestamp & "', " & x & ", " & y & ")"
                dbCmd.ExecuteNonQuery()
            End If
            line = reader.ReadLine()
        Loop

        ' Dispose the database objects
        dbConn.Close()
        dbConn.Dispose()

    End Sub

End Class
