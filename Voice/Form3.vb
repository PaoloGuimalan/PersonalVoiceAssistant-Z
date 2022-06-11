Imports System.Speech
Imports System.Speech.Recognition
Imports System.Data.SQLite

Public Class Form3

    Dim locationn As String = "C:\Z_Assistant\VoiceDB"
    Dim filename As String = "myDataBase.db"
    Dim fullpath As String = System.IO.Path.Combine(locationn, filename)
    Public connectionString As String = String.Format("Data Source = {0}", fullpath)

    Dim locationn2 As String = "C:\Z_Assistant\VoiceDB"
    Dim filename2 As String = "app_history.db"
    Dim fullpath2 As String = System.IO.Path.Combine(locationn2, filename2)
    Public connectionString2 As String = String.Format("Data Source = {0}", fullpath2)

    Dim locationn4 As String = "C:\Z_Assistant\VoiceDB"
    Dim filename4 As String = "atp_hist.db"
    Dim fullpath4 As String = System.IO.Path.Combine(locationn4, filename4)
    Public connectionString4 As String = String.Format("Data Source = {0}", fullpath4)

    Dim locationn5 As String = "C:\Z_Assistant\VoiceDB"
    Dim filename5 As String = "remm.db"
    Dim fullpath5 As String = System.IO.Path.Combine(locationn5, filename5)
    Public connectionString5 As String = String.Format("Data Source = {0}", fullpath5)


    Dim doInsert As Boolean = False

    Private WithEvents Voice3 As New Recognition.SpeechRecognitionEngine
    Private Sub attbox_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Voice3.SetInputToDefaultAudioDevice()

        Dim selectss3 As String = "SELECT * FROM Applications"
        Dim conn3 As New SQLiteConnection(connectionString)
        Dim cmd3 As New SQLiteCommand(selectss3, conn3)
        Dim echo3 As SQLiteDataReader
        conn3.Open()
        echo3 = cmd3.ExecuteReader
        Dim SS3 As String
        While echo3.Read()

            SS3 = echo3("cmd")

            Dim Gramm3 As New Recognition.SrgsGrammar.SrgsDocument

            Dim Rule3 As New Recognition.SrgsGrammar.SrgsRule("Language")

            Dim List3 As New Recognition.SrgsGrammar.SrgsOneOf(SS3)

            Rule3.Add(List3)

            Gramm3.Rules.Add(Rule3)
            Gramm3.Root = Rule3

            Voice3.LoadGrammar(New Recognition.Grammar(Gramm3))


        End While

        conn3.Close()

        Voice3.RecognizeAsync()

    End Sub

    Private Sub Voice3_RecognizeCompleted(sender As Object, x As RecognizeCompletedEventArgs) Handles Voice3.RecognizeCompleted
        If com <> True Then
            Voice3.RecognizeAsync()
        End If


    End Sub


    Dim SAPI
    Dim com As Boolean = False

    Private Sub Voice3_SpeechRecognized(sender As Object, x As SpeechRecognizedEventArgs) Handles Voice3.SpeechRecognized
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Voice = SAPI.GetVoices.Item(1)

        Dim attf32 As String = "SELECT * FROM settings WHERE id = 1"
        Dim connf32 As New SQLiteConnection(connectionString)
        Dim cmdf32 As New SQLiteCommand(attf32, connf32)
        Dim echof32 As SQLiteDataReader
        connf32.Open()
        echof32 = cmdf32.ExecuteReader

        While echof32.Read()
            Dim cmdhhf As String = "SELECT * FROM Applications"
            Dim conn1f As New SQLiteConnection(connectionString)
            Dim cmd2f As New SQLiteCommand(cmdhhf, conn1f)
            Dim echo2f As SQLiteDataReader
            conn1f.Open()
            echo2f = cmd2f.ExecuteReader

            While echo2f.Read()
                Select Case x.Result.Text
                    Case echo2f("cmd")
                        If echof32("att") = "Friendly" Then
                            SAPI.Speak(echo2f("speachf"))
                            Try
                                If echo2f("cmd") = "Thanks" Then
                                    com = True
                                    ThanksnExit()
                                ElseIf echo2f("cmd") = "Exit" Then
                                    com = True
                                    ThanksnExit()
                                ElseIf echo2f("cmd") = "Open Activity Reminders" Then
                                    com = True
                                    gofor()
                                Else
                                    Process.Start(echo2f("actions"))
                                    TextBox1.Text = echo2f("cmd")
                                    TextBox2.Text = echo2f("app_label")
                                    TextBox3.Text = echo2f("actions")
                                    doInsert = True
                                    savehistory()
                                    com = False
                                End If
                            Catch ex As Exception
                                SAPI.Speak("The App is not Processing!")
                                doInsert = False
                                com = False
                            End Try

                        ElseIf echof32("att") = "Normal" Then
                            SAPI.Speak(echo2f("speachn"))
                            Try
                                If echo2f("cmd") = "Thanks" Then
                                    com = True
                                    ThanksnExit()
                                ElseIf echo2f("cmd") = "Exit" Then
                                    com = True
                                    ThanksnExit()
                                ElseIf echo2f("cmd") = "Open Activity Reminders" Then
                                    com = True
                                    gofor()
                                Else
                                    Process.Start(echo2f("actions"))
                                    TextBox1.Text = echo2f("cmd")
                                    TextBox2.Text = echo2f("app_label")
                                    TextBox3.Text = echo2f("actions")
                                    doInsert = True
                                    savehistory()
                                    com = False
                                End If
                            Catch ex As Exception
                                SAPI.Speak("The App is not Processing!")
                                doInsert = False
                                com = False
                            End Try


                        ElseIf echof32("att") = "Extreme" Then
                            SAPI.Speak(echo2f("speache"))
                            Try
                                If echo2f("cmd") = "Thanks" Then
                                    com = True
                                    ThanksnExit()
                                ElseIf echo2f("cmd") = "Exit" Then
                                    com = True
                                    ThanksnExit()
                                ElseIf echo2f("cmd") = "Open Activity Reminders" Then
                                    com = True
                                    gofor()
                                Else
                                    Process.Start(echo2f("actions"))
                                    TextBox1.Text = echo2f("cmd")
                                    TextBox2.Text = echo2f("app_label")
                                    TextBox3.Text = echo2f("actions")
                                    doInsert = True
                                    savehistory()
                                    com = False
                                End If
                            Catch ex As Exception
                                SAPI.Speak("The App is not Processing!")
                                doInsert = False
                                com = False
                            End Try
                        End If


                End Select
            End While
            conn1f.Close()
        End While

        connf32.Close()


    End Sub

    Public Sub gofor()

        Dim functionzzz As String = "Opened Reminders"
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

        Me.Close()
        Form7.Show()
    End Sub

    Public Sub ThanksnExit()

        Dim functionzzz As String = "Exits App Selection"
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

        Form1.Show()
        Me.Close()
    End Sub

    Public Sub savehistory()
        If doInsert = True Then
            Dim cmdhh29123 As String = "INSERT INTO apps_history (cmd, app_label, app_path, time_opened, date_opened) " &
            "VALUES " &
            "(" &
            "'" & TextBox1.Text.Trim & "', " &
            "'" & TextBox2.Text.Trim & "', " &
            "'" & TextBox3.Text.Trim & "', " &
            "'" & TimeOfDay.ToString("h:mm tt") & "', " &
            "'" & Date.Today() & "'" &
            ")"

            Dim conn129123 As New SQLiteConnection(connectionString4)
            Dim cmd229123 As New SQLiteCommand(cmdhh29123, conn129123)
            conn129123.Open()
            cmd229123.ExecuteNonQuery()
            conn129123.Close()
        End If
    End Sub

    Private Sub GunaCircleProgressBar2_Click(sender As Object, e As EventArgs) Handles GunaCircleProgressBar2.Click

    End Sub

    Private Sub BunifuGradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles BunifuGradientPanel1.Paint

    End Sub
End Class