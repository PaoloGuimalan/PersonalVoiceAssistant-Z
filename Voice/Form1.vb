Imports System.Speech
Imports System.Speech.Recognition
Imports System.Data.SQLite
Imports System.Linq



Public Class Form1

    Dim com As Boolean = False
    Dim com2 As Boolean
    Dim spch As String

    Dim locationn As String = "C:\Z_Assistant\VoiceDB"
    Dim filename As String = "myDataBase.db"
    Dim fullpath As String = System.IO.Path.Combine(locationn, filename)
    Public connectionString As String = String.Format("Data Source = {0}", fullpath)

    Dim locationn2 As String = "C:\Z_Assistant\VoiceDB"
    Dim filename2 As String = "app_history.db"
    Dim fullpath2 As String = System.IO.Path.Combine(locationn2, filename2)
    Public connectionString2 As String = String.Format("Data Source = {0}", fullpath2)

    Dim locationn3 As String = "C:\Z_Assistant\VoiceDB"
    Dim filename3 As String = "recogn.db"
    Dim fullpath3 As String = System.IO.Path.Combine(locationn3, filename3)
    Public connectionString3 As String = String.Format("Data Source = {0}", fullpath3)

    Dim locationn5 As String = "C:\Z_Assistant\VoiceDB"
    Dim filename5 As String = "remm.db"
    Dim fullpath5 As String = System.IO.Path.Combine(locationn5, filename5)
    Public connectionString5 As String = String.Format("Data Source = {0}", fullpath5)

    Dim locationn6 As String = "C:\Z_Assistant\VoiceDB"
    Dim filename6 As String = "speeches.db"
    Dim fullpath6 As String = System.IO.Path.Combine(locationn6, filename6)
    Public connectionString6 As String = String.Format("Data Source = {0}", fullpath6)

    Dim locationn7 As String = "C:\Z_Assistant\VoiceDB"
    Dim filename7 As String = "status.db"
    Dim fullpath7 As String = System.IO.Path.Combine(locationn7, filename7)
    Public connectionString7 As String = String.Format("Data Source = {0}", fullpath7)



    Public Sub createDataBase()
        If Not duplicateDataBase(fullpath) Then
            Dim createTable As String = "CREATE TABLE 'commands' (
	                                            'id'	INTEGER,
	                                            'cmd'	TEXT,
	                                            'speach'	TEXT,
	                                            PRIMARY KEY('id' AUTOINCREMENT)
                                            );"
            Using SqlConn As New SQLiteConnection(connectionString)
                Dim cmd As New SQLiteCommand(createTable, SqlConn)
                SqlConn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End If
    End Sub


    Private Function duplicateDataBase(fullpath As String) As Boolean
        Return System.IO.File.Exists(fullpath)
    End Function

    Private WithEvents Voice As New Recognition.SpeechRecognitionEngine

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        createDataBase()

        PlayBackgroundSoundFile()

        saveactstartup()

    End Sub



    Private Sub Voice_RecognizeCompleted(sender As Object, y As RecognizeCompletedEventArgs) Handles Voice.RecognizeCompleted

        If com = False Then
            Voice.RecognizeAsync()
        End If

    End Sub

    Dim SAPI

    Private Sub Voice_SpeechRecognized(sender As Object, y As SpeechRecognizedEventArgs) Handles Voice.SpeechRecognized
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Voice = SAPI.GetVoices.Item(1)

        Dim attsel As String = "SELECT * FROM settings WHERE id = 1"
        Dim conn As New SQLiteConnection(connectionString)
        Dim cmd As New SQLiteCommand(attsel, conn)
        Dim echo1 As SQLiteDataReader
        conn.Open()
        echo1 = cmd.ExecuteReader

        While echo1.Read()
            Dim cmdhh As String = "SELECT * FROM commands"
            Dim conn1 As New SQLiteConnection(connectionString)
            Dim cmd2 As New SQLiteCommand(cmdhh, conn1)
            Dim echo2 As SQLiteDataReader
            conn1.Open()
            echo2 = cmd2.ExecuteReader

            While echo2.Read()
                Select Case y.Result.Text
                    Case echo2("cmd")
                        If echo1("att") = "Friendly" Then

                            If echo2("cmd") = "Shutdown" Then
                                SAPI.Speak(echo2("speachf"))
                                com = False
                                shutdown()
                            ElseIf echo2("cmd") = "Hey Z" Then
                                com = True
                                heyz()
                            ElseIf echo2("cmd") = "Restart" Then
                                SAPI.Speak(echo2("speachf"))
                                com = True
                                restartsystem()
                            ElseIf echo2("cmd") = "Total Shutdown" Then
                                com = True
                                ShutConfirm()
                            End If
                        ElseIf echo1("att") = "Normal" Then

                            If echo2("cmd") = "Shutdown" Then
                                SAPI.Speak(echo2("speachn"))
                                com = False
                                shutdown()
                            ElseIf echo2("cmd") = "Hey Z" Then
                                com = True
                                heyz()
                            ElseIf echo2("cmd") = "Restart" Then
                                SAPI.Speak(echo2("speachn"))
                                com = True
                                restartsystem()
                            ElseIf echo2("cmd") = "Total Shutdown" Then
                                com = True
                                ShutConfirm()
                            End If
                        ElseIf echo1("att") = "Extreme" Then

                            If echo2("cmd") = "Shutdown" Then
                                SAPI.Speak(echo2("speache"))
                                com = False
                                shutdown()
                            ElseIf echo2("cmd") = "Hey Z" Then
                                com = True
                                heyz()
                            ElseIf echo2("cmd") = "Restart" Then
                                SAPI.Speak(echo2("speache"))
                                com = True
                                restartsystem()
                            ElseIf echo2("cmd") = "Total Shutdown" Then
                                com = True
                                ShutConfirm()
                            End If
                        End If
                End Select

            End While
        End While

        conn.Close()

    End Sub



    Public Sub ShutConfirm()

        Dim attsel2emo As String = "SELECT * FROM settings WHERE id = 1"
        Dim conn2emo As New SQLiteConnection(connectionString)
        Dim cmd2emo As New SQLiteCommand(attsel2emo, conn2emo)
        Dim echo12emo As SQLiteDataReader
        conn2emo.Open()
        echo12emo = cmd2emo.ExecuteReader
        echo12emo.Read()

        Dim mnm = New Random().Next(16, 18)

        If echo12emo("att") = "Friendly" Then
            spch = "friendly"
        ElseIf echo12emo("att") = "Normal" Then
            spch = "normal"
        ElseIf echo12emo("att") = "Extreme" Then
            spch = "extreme"
        End If

        Dim attsel2emof As String = "SELECT * FROM " & spch & " WHERE id = " & mnm
        Dim conn2emof As New SQLiteConnection(connectionString6)
        Dim cmd2emof As New SQLiteCommand(attsel2emof, conn2emof)
        Dim echo12emof As SQLiteDataReader
        conn2emof.Open()
        echo12emof = cmd2emof.ExecuteReader
        echo12emof.Read()
        SAPI.Speak(echo12emof("resp"))
        conn2emof.Close()

        conn2emo.Close()

        Dim result As DialogResult = MessageBox.Show("System Shutdown?", "Confirmation Request", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Systemshut()
        ElseIf result = DialogResult.No Then
            Dim attsel2emo23 As String = "SELECT * FROM settings WHERE id = 1"
            Dim conn2emo23 As New SQLiteConnection(connectionString)
            Dim cmd2emo23 As New SQLiteCommand(attsel2emo23, conn2emo23)
            Dim echo12emo23 As SQLiteDataReader
            conn2emo23.Open()
            echo12emo23 = cmd2emo23.ExecuteReader
            echo12emo23.Read()

            Dim mnm2 = New Random().Next(19, 21)

            If echo12emo23("att") = "Friendly" Then
                spch = "friendly"
            ElseIf echo12emo23("att") = "Normal" Then
                spch = "normal"
            ElseIf echo12emo23("att") = "Extreme" Then
                spch = "extreme"
            End If

            Dim attsel2emof2323 As String = "SELECT * FROM " & spch & " WHERE id = " & mnm2
            Dim conn2emof2323 As New SQLiteConnection(connectionString6)
            Dim cmd2emof2323 As New SQLiteCommand(attsel2emof2323, conn2emof2323)
            Dim echo12emof2323 As SQLiteDataReader
            conn2emof2323.Open()
            echo12emof2323 = cmd2emof2323.ExecuteReader
            echo12emof2323.Read()
            SAPI.Speak(echo12emof2323("resp"))
            conn2emof2323.Close()

            conn2emo23.Close()

            AddHandler Me.FormClosing, AddressOf Form1_Load
        End If

    End Sub

    Public Sub Systemshut()

        Dim attsel2emo As String = "SELECT * FROM settings WHERE id = 1"
        Dim conn2emo As New SQLiteConnection(connectionString)
        Dim cmd2emo As New SQLiteCommand(attsel2emo, conn2emo)
        Dim echo12emo As SQLiteDataReader
        conn2emo.Open()
        echo12emo = cmd2emo.ExecuteReader
        echo12emo.Read()

        Dim mnm = New Random().Next(11, 15)

        If echo12emo("att") = "Friendly" Then
            spch = "friendly"
        ElseIf echo12emo("att") = "Normal" Then
            spch = "normal"
        ElseIf echo12emo("att") = "Extreme" Then
            spch = "extreme"
        End If

        Dim attsel2emof As String = "SELECT * FROM " & spch & " WHERE id = " & mnm
        Dim conn2emof As New SQLiteConnection(connectionString6)
        Dim cmd2emof As New SQLiteCommand(attsel2emof, conn2emof)
        Dim echo12emof As SQLiteDataReader
        conn2emof.Open()
        echo12emof = cmd2emof.ExecuteReader
        echo12emof.Read()
        SAPI.Speak(echo12emof("resp"))
        conn2emof.Close()

        conn2emo.Close()

        Dim functionzzz As String = "Computer Shutdown"
        Dim cmdhh291234 As String = "INSERT INTO startup (status, date_start) " &
                "VALUES " &
                "(" &
                "'" & functionzzz & "', " &
                "'" & Date.Today() & "' " &
                ")"

        Dim conn1291234 As New SQLiteConnection(connectionString3)
        Dim cmd2291234 As New SQLiteCommand(cmdhh291234, conn1291234)
        conn1291234.Open()
        cmd2291234.ExecuteNonQuery()
        conn1291234.Close()

        PlayBackgroundSoundFile2()
        Process.Start("shutdown", "-s -t 02")
        Environment.Exit(1)

    End Sub

    Public Sub saveactstartup()

        Dim functionzzzsaza As String = "Online"
        Dim cmdhh29123saza As String = "UPDATE online_status SET status = '" & functionzzzsaza & "', color = 'green' WHERE id = 1"

        Dim conn129123saza As New SQLiteConnection(connectionString7)
        Dim cmd229123saza As New SQLiteCommand(cmdhh29123saza, conn129123saza)
        conn129123saza.Open()
        cmd229123saza.ExecuteNonQuery()
        conn129123saza.Close()

        Dim functionzzz As String = "Run Successful"
        Dim cmdhh291234 As String = "INSERT INTO startup (status, date_start) " &
                "VALUES " &
                "(" &
                "'" & functionzzz & "', " &
                "'" & Date.Today() & "' " &
                ")"

        Dim conn1291234 As New SQLiteConnection(connectionString3)
        Dim cmd2291234 As New SQLiteCommand(cmdhh291234, conn1291234)
        conn1291234.Open()
        cmd2291234.ExecuteNonQuery()
        conn1291234.Close()

    End Sub

    Public Sub heyz()
        Form2.Show()
        Me.Hide()
    End Sub

    Public Sub shutdown()

        Form2.Close()
        Form3.Close()
        Form4.Close()
        Form5.Close()
        Form6.Close()
        Form7.Close()
        Form8.Close()

        Dim functionzzz As String = "System Shutdown"
        Dim cmdhh29123 As String = "INSERT INTO activity_memory (function, time_opened, date_opened) " &
                "VALUES " &
                "(" &
                "'" & functionzzz & "', " &
                "'" & TimeOfDay.ToString("h:mm tt") & "', " &
                "'" & Date.Today() & "'" &
                ")"

        Dim conn129123 As New SQLiteConnection(connectionString2)
        Dim cmd229123 As New SQLiteCommand(cmdhh29123, conn129123)
        conn129123.Open()
        cmd229123.ExecuteNonQuery()
        conn129123.Close()

        Dim functionzzzsa As String = "Offline"
        Dim cmdhh29123sa As String = "UPDATE online_status SET status = '" & functionzzzsa & "', color = 'red' WHERE id = 1"

        Dim conn129123sa As New SQLiteConnection(connectionString7)
        Dim cmd229123sa As New SQLiteCommand(cmdhh29123sa, conn129123sa)
        conn129123sa.Open()
        cmd229123sa.ExecuteNonQuery()
        conn129123sa.Close()

        PlayBackgroundSoundFile2()
        Environment.Exit(1)
    End Sub

    Public Sub restartsystem()

        Dim functionzzzsa As String = "Offline"
        Dim cmdhh29123sa As String = "UPDATE online_status SET status = '" & functionzzzsa & "', color = 'red' WHERE id = 1"

        Dim conn129123sa As New SQLiteConnection(connectionString7)
        Dim cmd229123sa As New SQLiteCommand(cmdhh29123sa, conn129123sa)
        conn129123sa.Open()
        cmd229123sa.ExecuteNonQuery()
        conn129123sa.Close()

        Dim functionzzz As String = "System Restart"
        Dim cmdhh29123 As String = "INSERT INTO activity_memory (function, time_opened, date_opened) " &
                "VALUES " &
                "(" &
                "'" & functionzzz & "', " &
                "'" & TimeOfDay.ToString("h:mm tt") & "', " &
                "'" & Date.Today() & "'" &
                ")"

        Dim conn129123 As New SQLiteConnection(connectionString2)
        Dim cmd229123 As New SQLiteCommand(cmdhh29123, conn129123)
        conn129123.Open()
        cmd229123.ExecuteNonQuery()
        conn129123.Close()

        Process.Start("C:\Z_Assistant\Voice.exe")
        Environment.Exit(1)
    End Sub

    Public Sub settings()
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub Key1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub attbox_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Sub PlayBackgroundSoundFile()
        My.Computer.Audio.Play("C:\Z_Assistant\sounds\space_signals.wav", AudioPlayMode.WaitToComplete
                               )
    End Sub

    Sub PlayBackgroundSoundFile2()
        My.Computer.Audio.Play("C:\Z_Assistant\sounds\space_message.wav", AudioPlayMode.WaitToComplete
                               )
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BunifuGradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles BunifuGradientPanel1.Paint

    End Sub

    Private Sub GunaCircleProgressBar1_Click(sender As Object, e As EventArgs) Handles GunaCircleProgressBar1.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GunaCircleProgressBar1.Increment(1)
    End Sub

    Private Sub GunaCircleProgressBar2_Click(sender As Object, e As EventArgs) Handles GunaCircleProgressBar2.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Voice = SAPI.GetVoices.Item(1)
        Try
            If Asc(e.KeyChar) = Keys.Z Then
                Voice.SetInputToDefaultAudioDevice()

                Dim selectss As String = "SELECT * FROM commands"
                Dim conn As New SQLiteConnection(connectionString)
                Dim cmd As New SQLiteCommand(selectss, conn)
                Dim echo As SQLiteDataReader
                conn.Open()
                echo = cmd.ExecuteReader
                Dim SS As String
                While echo.Read()

                    SS = echo("cmd")

                    Dim Gramm As New Recognition.SrgsGrammar.SrgsDocument

                    Dim Rule As New Recognition.SrgsGrammar.SrgsRule("Language")

                    Dim List As New Recognition.SrgsGrammar.SrgsOneOf(SS)

                    Rule.Add(List)

                    Gramm.Rules.Add(Rule)
                    Gramm.Root = Rule

                    Voice.LoadGrammar(New Recognition.Grammar(Gramm))


                End While

                conn.Close()

                Voice.RecognizeAsync()

            End If
        Catch ex As Exception

            com = True

            Dim attsel2emo12 As String = "SELECT * FROM settings WHERE id = 1"
            Dim conn2emo12 As New SQLiteConnection(connectionString)
            Dim cmd2emo12 As New SQLiteCommand(attsel2emo12, conn2emo12)
            Dim echo12emo12 As SQLiteDataReader
            conn2emo12.Open()
            echo12emo12 = cmd2emo12.ExecuteReader
            echo12emo12.Read()

            Dim mnm12 = New Random().Next(22, 26)

            If echo12emo12("att") = "Friendly" Then
                spch = "friendly"
            ElseIf echo12emo12("att") = "Normal" Then
                spch = "normal"
            ElseIf echo12emo12("att") = "Extreme" Then
                spch = "extreme"
            End If

            Dim attsel2emof12 As String = "SELECT * FROM " & spch & " WHERE id = " & mnm12
            Dim conn2emof12 As New SQLiteConnection(connectionString6)
            Dim cmd2emof12 As New SQLiteCommand(attsel2emof12, conn2emof12)
            Dim echo12emof12 As SQLiteDataReader
            conn2emof12.Open()
            echo12emof12 = cmd2emof12.ExecuteReader
            echo12emof12.Read()
            SAPI.Speak(echo12emof12("resp"))
            conn2emof12.Close()

            conn2emo12.Close()

            com = False

        End Try
    End Sub
End Class
