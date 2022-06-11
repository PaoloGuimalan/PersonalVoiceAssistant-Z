Imports System.Speech
Imports System.Speech.Recognition
Imports System.Data.SQLite
Imports System.Linq

Public Class Form8

    Dim com As Boolean = False

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

    Dim locationn7 As String = "C:\Z_Assistant\VoiceDB"
    Dim filename7 As String = "emo_count.db"
    Dim fullpath7 As String = System.IO.Path.Combine(locationn7, filename7)
    Public connectionString7 As String = String.Format("Data Source = {0}", fullpath7)


    Private Function duplicateDataBase(fullpath As String) As Boolean
        Return System.IO.File.Exists(fullpath)
    End Function

    Private WithEvents Voice As New Recognition.SpeechRecognitionEngine

    Dim SAPI


    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Voice.SetInputToDefaultAudioDevice()

        Dim selectssemo As String = "SELECT * FROM sad_cmd"
        Dim connemo As New SQLiteConnection(connectionString)
        Dim cmdemo As New SQLiteCommand(selectssemo, connemo)
        Dim echoemo As SQLiteDataReader
        connemo.Open()
        echoemo = cmdemo.ExecuteReader
        Dim SSemo As String
        While echoemo.Read()

            SSemo = echoemo("cmd")

            Dim Grammemo As New Recognition.SrgsGrammar.SrgsDocument

            Dim Ruleemo As New Recognition.SrgsGrammar.SrgsRule("Language")

            Dim Listemo As New Recognition.SrgsGrammar.SrgsOneOf(SSemo, "Exit", "Thanks")

            Ruleemo.Add(Listemo)

            Grammemo.Rules.Add(Ruleemo)
            Grammemo.Root = Ruleemo

            Voice.LoadGrammar(New Recognition.Grammar(Grammemo))


        End While

        connemo.Close()

        Voice.RecognizeAsync()

    End Sub

    Private Sub Voice_RecognizeCompleted(sender As Object, y As RecognizeCompletedEventArgs) Handles Voice.RecognizeCompleted

        If com = False Then
            Voice.RecognizeAsync()
        End If

    End Sub

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
            Dim cmdhh As String = "SELECT * FROM sad_cmd"
            Dim conn1 As New SQLiteConnection(connectionString)
            Dim cmd2 As New SQLiteCommand(cmdhh, conn1)
            Dim echo2 As SQLiteDataReader
            conn1.Open()
            echo2 = cmd2.ExecuteReader

            While echo2.Read()
                Select Case y.Result.Text
                    Case echo2("cmd")
                        If echo1("att") = "Friendly" Then
                            If echo2("label_emo") = "happy" Then
                                happy()
                            ElseIf echo2("label_emo") = "sad" Then
                                sad()
                            End If
                        ElseIf echo1("att") = "Normal" Then
                            If echo2("label_emo") = "happy" Then
                                happy()
                            ElseIf echo2("label_emo") = "sad" Then
                                sad()
                            End If
                        ElseIf echo1("att") = "Extreme" Then
                            If echo2("label_emo") = "happy" Then
                                happy()
                            ElseIf echo2("label_emo") = "sad" Then
                                sad()
                            End If
                        End If
                    Case "Exit"
                        Dim nn = New Random().Next(1, 5)
                        com = True
                        Form1.Show()
                        Me.Close()
                End Select

            End While
        End While

        conn.Close()

    End Sub


    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        ' Process.Start("spotify:track:37PJvlIfYWqEX6fgjHlnTf")
    End Sub

    Public Sub happy()
        Dim functionzzzemo As String = "happy"
        Dim cmdhh291234emo As String = "INSERT INTO count_times (emo_status, date_st) " &
                "VALUES " &
                "(" &
                "'" & functionzzzemo & "', " &
                "'" & Date.Today() & "' " &
                ")"

        Dim conn1291234emo As New SQLiteConnection(connectionString7)
        Dim cmd2291234emo As New SQLiteCommand(cmdhh291234emo, conn1291234emo)
        conn1291234emo.Open()
        cmd2291234emo.ExecuteNonQuery()
        conn1291234emo.Close()

        Dim attselhapp As String = "SELECT * FROM settings WHERE id = 1"
        Dim connhapp As New SQLiteConnection(connectionString7)
        Dim cmdhapp As New SQLiteCommand(attselhapp, connhapp)
        Dim echo1happ As SQLiteDataReader
        connhapp.Open()
        echo1happ = cmdhapp.ExecuteReader
        echo1happ.Read()

        connhapp.Close()
    End Sub

    Public Sub sad()
        Dim functionzzzemo As String = "sad"
        Dim cmdhh291234emo As String = "INSERT INTO count_times (emo_status, date_st) " &
                "VALUES " &
                "(" &
                "'" & functionzzzemo & "', " &
                "'" & Date.Today() & "' " &
                ")"

        Dim conn1291234emo As New SQLiteConnection(connectionString7)
        Dim cmd2291234emo As New SQLiteCommand(cmdhh291234emo, conn1291234emo)
        conn1291234emo.Open()
        cmd2291234emo.ExecuteNonQuery()
        conn1291234emo.Close()
    End Sub

End Class

