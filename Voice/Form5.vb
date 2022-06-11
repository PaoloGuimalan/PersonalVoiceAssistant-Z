Imports System.Speech
Imports System.Speech.Recognition
Imports System.Data.SQLite

Public Class Form5

    Dim locationn As String = "C:\Z_Assistant\VoiceDB"
    Dim filename As String = "myDataBase.db"
    Dim fullpath As String = System.IO.Path.Combine(locationn, filename)
    Public connectionString As String = String.Format("Data Source = {0}", fullpath)

    Dim locationn2 As String = "C:\Z_Assistant\VoiceDB"
    Dim filename2 As String = "app_history.db"
    Dim fullpath2 As String = System.IO.Path.Combine(locationn2, filename2)
    Public connectionString2 As String = String.Format("Data Source = {0}", fullpath2)

    Dim SAPI
    Dim com As Boolean = False

    Private WithEvents Voice5 As New Recognition.SpeechRecognitionEngine

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Voice5.SetInputToDefaultAudioDevice()

        Dim selectss5 As String = "SELECT * FROM Applications"
        Dim conn5 As New SQLiteConnection(connectionString)
        Dim cmd5 As New SQLiteCommand(selectss5, conn5)
        Dim echo5 As SQLiteDataReader
        conn5.Open()
        echo5 = cmd5.ExecuteReader
        Dim SS5 As String
        While echo5.Read()

            SS5 = echo5("cmd")

            Dim Gramm5 As New Recognition.SrgsGrammar.SrgsDocument

            Dim Rule5 As New Recognition.SrgsGrammar.SrgsRule("Language")

            Dim List5 As New Recognition.SrgsGrammar.SrgsOneOf(SS5)

            Rule5.Add(List5)

            Gramm5.Rules.Add(Rule5)
            Gramm5.Root = Rule5

            Voice5.LoadGrammar(New Recognition.Grammar(Gramm5))


        End While

        conn5.Close()


        Voice5.RecognizeAsync()

        Dim attf5 As String = "SELECT * FROM settings WHERE id = 1"
        Dim connf5 As New SQLiteConnection(connectionString)
        Dim cmdf5 As New SQLiteCommand(attf5, connf5)
        Dim echof5 As SQLiteDataReader
        connf5.Open()
        echof5 = cmdf5.ExecuteReader
        echof5.Read()

        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Voice = SAPI.GetVoices.Item(1)

        If echof5("att") = "Friendly" Then
            SAPI.Speak("What word do you want me to search boss?")
        ElseIf echof5("att") = "Normal" Then
            SAPI.Speak("What word should I look up?")
        ElseIf echof5("att") = "Extreme" Then
            SAPI.Speak("You dumb shit, What word?")
        End If
        connf5.Close()
    End Sub

    Private Sub Voice5_RecognizeCompleted(sender As Object, xyd As RecognizeCompletedEventArgs) Handles Voice5.RecognizeCompleted
        If com <> True Then
            Voice5.RecognizeAsync()
        End If
    End Sub

    Private Sub Voice5_SpeechRecognized(sender As Object, xyd As SpeechRecognizedEventArgs) Handles Voice5.SpeechRecognized
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Voice = SAPI.GetVoices.Item(1)

        Dim attf55 As String = "SELECT * FROM settings WHERE id = 1"
        Dim connf55 As New SQLiteConnection(connectionString)
        Dim cmdf55 As New SQLiteCommand(attf55, connf55)
        Dim echof55 As SQLiteDataReader
        connf55.Open()
        echof55 = cmdf55.ExecuteReader

        While echof55.Read()

            Dim cmdhh25 As String = "SELECT * FROM WordCmd"
            Dim conn125 As New SQLiteConnection(connectionString)
            Dim cmd225 As New SQLiteCommand(cmdhh25, conn125)
            Dim echo225 As SQLiteDataReader
            conn125.Open()
            echo225 = cmd225.ExecuteReader

            While echo225.Read()
                Select Case xyd.Result.Text
                    Case echo225("cmd")
                        If echof55("att") = "Friendly" Then
                            If echo225("cmd") = "Exit" Then
                                SAPI.Speak(echo225("speachf"))
                                com = True
                                exit5()
                            ElseIf echo225("cmd") = "Thanks" Then
                                SAPI.Speak(echo225("speachf"))
                                com = True
                                exit5()
                            End If
                        ElseIf echof55("att") = "Normal" Then
                            If echo225("cmd") = "Exit" Then
                                SAPI.Speak(echo225("speachn"))
                                com = True
                                exit5()
                            ElseIf echo225("cmd") = "Thanks" Then
                                SAPI.Speak(echo225("speachn"))
                                com = True
                                exit5()
                            End If
                        ElseIf echof55("att") = "Extreme" Then
                            If echo225("cmd") = "Exit" Then
                                SAPI.Speak(echo225("speache"))
                                com = True
                                exit5()
                            ElseIf echo225("cmd") = "Thanks" Then
                                SAPI.Speak(echo225("speache"))
                                com = True
                                exit5()
                            End If
                        End If
                End Select

            End While
            conn125.Close()
        End While
        connf55.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        TextBox2.Text = ""

        Dim attf325 As String = "SELECT * FROM entries WHERE field1 = '" & TextBox1.Text & "'"
        Dim connf325 As New SQLiteConnection(connectionString)
        Dim cmdf325 As New SQLiteCommand(attf325, connf325)
        Dim echof325 As SQLiteDataReader
        connf325.Open()

        Try
            echof325 = cmdf325.ExecuteReader
            While echof325.Read()
                If echof325("field3") = "" Then
                    SAPI.Speak("No word as such in my memory")
                Else

                    Dim a As String = echof325("field3")
                    TextBox2.Text += a & vbCrLf & vbCrLf
                    SAPI.Speak(echof325("field1") & " means " & echof325("field3"))

                End If

            End While
        Catch ex As Exception
            SAPI.Speak("No word as such in my memory")
        End Try

        connf325.Close()
    End Sub

    Public Sub exit5()

        Dim functionzzz As String = "Exits System Dictionary"
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
End Class