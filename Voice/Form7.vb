Imports System.Speech
Imports System.Speech.Recognition
Imports System.Data.SQLite


Public Class Form7

    Dim com As Boolean = False
    Dim Time As String
    Dim strdateeee As String

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

    Dim locationn4 As String = "C:\Z_Assistant\VoiceDB"
    Dim filename4 As String = "atp_hist.db"
    Dim fullpath4 As String = System.IO.Path.Combine(locationn4, filename4)
    Public connectionString4 As String = String.Format("Data Source = {0}", fullpath4)

    Private WithEvents Voice7 As New Recognition.SpeechRecognitionEngine

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Voice7.SetInputToDefaultAudioDevice()
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Voice = SAPI.GetVoices.Item(1)


        Dim Gramm7 As New Recognition.SrgsGrammar.SrgsDocument

        Dim Rule7 As New Recognition.SrgsGrammar.SrgsRule("Language")

        Dim List7 As New Recognition.SrgsGrammar.SrgsOneOf("Open", "Open All", "No Thanks", "Exit")

        Rule7.Add(List7)

        Gramm7.Rules.Add(Rule7)
        Gramm7.Root = Rule7

        Voice7.LoadGrammar(New Recognition.Grammar(Gramm7))

        Voice7.RecognizeAsync()

        Dim selectss As String = "Select cmd, Max(app_name) As app_name From app_counts"
        Dim conn As New SQLiteConnection(connectionString4)
        Dim cmd As New SQLiteCommand(selectss, conn)
        Dim echo As SQLiteDataReader
        conn.Open()
        echo = cmd.ExecuteReader

        While echo.Read()

            Label10.Text = echo("cmd")
        Label11.Text = echo("app_name")



        Dim selectss234 As String = "Select app_label, Max(app_labelno) As app_labelno From app_countlabel"
        Dim conn234 As New SQLiteConnection(connectionString4)
        Dim cmd234 As New SQLiteCommand(selectss234, conn234)
        Dim echo234 As SQLiteDataReader
        conn234.Open()
        echo234 = cmd234.ExecuteReader
        echo234.Read()

        Label8.Text = echo234("app_label")
        Label9.Text = echo234("app_labelno")

            SAPI.Speak("You have opened " & Label10.Text & " the most I recorded an initial of " & echo("app_name") & " entries. I also noticed that most of your Opened apps are labeled as " & echo234("app_label"))
            SAPI.Speak("Say Open if you want to open your most opened apps to continue your activities, Open All to open all of your most opened apps labeled as " & echo234("app_label") & " or you can do it manually.")

            conn234.Close()

        End While

        conn.Close()



    End Sub

    Private Sub Voice7_RecognizeCompleted(sender As Object, e As RecognizeCompletedEventArgs) Handles Voice7.RecognizeCompleted
        If com <> True Then
            Voice7.RecognizeAsync()
        End If
    End Sub


    Dim SAPI


    Private Sub Voice7_SpeechRecognized(sender As Object, e As SpeechRecognizedEventArgs) Handles Voice7.SpeechRecognized
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Voice = SAPI.GetVoices.Item(1)


        Select Case e.Result.Text
            Case "Open"
                com = False
            Case "Open All"
                com = False
            Case "No Thanks"
                com = False
            Case "Exit"
                com = False
                exitz()
        End Select


    End Sub

    Public Sub exitz()

        Dim functionzzz234 As String = "Exits Activity Reminders"
        Dim cmdhh29123234 As String = "INSERT INTO activity_memory (function, time_opened, date_opened) " &
                "VALUES " &
                "(" &
                "'" & functionzzz234 & "', " &
                "'" & TimeOfDay.ToString("h:mm tt") & "', " &
                "'" & Date.Today() & "'" &
                ")"

        Dim conn129123234 As New SQLiteConnection(connectionString2)
        Dim cmd229123234 As New SQLiteCommand(cmdhh29123234, conn129123234)
        conn129123234.Open()
        cmd229123234.ExecuteNonQuery()
        conn129123234.Close()

        Form1.Show()
        Me.Close()
    End Sub

End Class