Imports System.Speech
Imports System.Speech.Recognition
Imports System.Data.SQLite


Public Class Form2

    Dim com As Boolean = False
    Dim Time As String
    Dim spch As String
    Dim strdateeee As String
    Dim Month As String
    Dim Monthlet As String

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

    Private WithEvents Voice2 As New Recognition.SpeechRecognitionEngine



    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub attbox_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Voice2.SetInputToDefaultAudioDevice()

        Dim selectss2 As String = "SELECT * FROM controlpanel"
        Dim conn2 As New SQLiteConnection(connectionString)
        Dim cmd2 As New SQLiteCommand(selectss2, conn2)
        Dim echo2 As SQLiteDataReader
        conn2.Open()
        echo2 = cmd2.ExecuteReader
        Dim SS2 As String
        While echo2.Read()

            SS2 = echo2("cmd")

            Dim Gramm2 As New Recognition.SrgsGrammar.SrgsDocument

            Dim Rule2 As New Recognition.SrgsGrammar.SrgsRule("Language")

            Dim List2 As New Recognition.SrgsGrammar.SrgsOneOf(SS2)

            Rule2.Add(List2)

            Gramm2.Rules.Add(Rule2)
            Gramm2.Root = Rule2

            Voice2.LoadGrammar(New Recognition.Grammar(Gramm2))


        End While

        conn2.Close()

        saveact()

        Voice2.RecognizeAsync()



    End Sub

    Private Sub Voice2_RecognizeCompleted(sender As Object, e As RecognizeCompletedEventArgs) Handles Voice2.RecognizeCompleted
        If com <> True Then
            Voice2.RecognizeAsync()
        End If
    End Sub


    Dim SAPI


    Private Sub Voice2_SpeechRecognized(sender As Object, e As SpeechRecognizedEventArgs) Handles Voice2.SpeechRecognized
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Voice = SAPI.GetVoices.Item(1)


        Dim attsel2 As String = "SELECT * FROM settings WHERE id = 1"
        Dim conn2 As New SQLiteConnection(connectionString)
        Dim cmd2 As New SQLiteCommand(attsel2, conn2)
        Dim echo12 As SQLiteDataReader
        conn2.Open()
        echo12 = cmd2.ExecuteReader

        While echo12.Read()
            Dim cmdhh2 As String = "SELECT * FROM controlpanel"
            Dim conn12 As New SQLiteConnection(connectionString)
            Dim cmd22 As New SQLiteCommand(cmdhh2, conn12)
            Dim echo22 As SQLiteDataReader
            conn12.Open()
            echo22 = cmd22.ExecuteReader

            While echo22.Read()
                Select Case e.Result.Text
                    Case echo22("cmd")
                        If echo12("att") = "Friendly" Then
                            If echo22("cmd") = "Time" Then
                                timeee()
                                SAPI.Speak(echo22("speachf") + Time)
                                com = False
                            ElseIf echo22("cmd") = "Date" Then
                                dateee()
                                SAPI.Speak(echo22("speachf") + strdateeee)
                                com = False
                            ElseIf echo22("cmd") = "Open Software" Then
                                SAPI.Speak(echo22("speachf"))
                                com = True
                                openapps()
                            ElseIf echo22("cmd") = "Exit" Then
                                SAPI.Speak(echo22("speachf"))
                                com = True
                                exittt()
                            ElseIf echo22("cmd") = "Settings" Then
                                SAPI.Speak(echo22("speachf"))
                                com = True
                                opensettings()
                            ElseIf echo22("cmd") = "Open Words" Then
                                SAPI.Speak(echo22("speachf"))
                                com = True
                                opendictionary()
                            ElseIf echo22("cmd") = "Open System Browser" Then
                                SAPI.Speak(echo22("speachf"))
                                com = True
                                opensay()
                            ElseIf echo22("cmd") = "I have something to say" Then
                                com = True
                                openplay()
                            Else
                                SAPI.Speak(echo22("speachf"))
                                com = False
                            End If
                        ElseIf echo12("att") = "Normal" Then
                            If echo22("cmd") = "Time" Then
                                timeee()
                                SAPI.Speak(echo22("speachn") + Time)
                                com = False
                            ElseIf echo22("cmd") = "Date" Then
                                dateee()
                                SAPI.Speak(echo22("speachn") + strdateeee)
                                com = False
                            ElseIf echo22("cmd") = "Open Software" Then
                                SAPI.Speak(echo22("speachn"))
                                com = True
                                openapps()
                            ElseIf echo22("cmd") = "Exit" Then
                                SAPI.Speak(echo22("speachn"))
                                com = True
                                exittt()
                            ElseIf echo22("cmd") = "Settings" Then
                                SAPI.Speak(echo22("speachn"))
                                com = True
                                opensettings()
                            ElseIf echo22("cmd") = "Open Words" Then
                                SAPI.Speak(echo22("speachn"))
                                com = True
                                opendictionary()
                            ElseIf echo22("cmd") = "Open System Browser" Then
                                SAPI.Speak(echo22("speachn"))
                                com = True
                                opensay()
                            ElseIf echo22("cmd") = "I have something to say" Then
                                com = True
                                openplay()
                            Else
                                SAPI.Speak(echo22("speachn"))
                                com = False
                            End If
                        ElseIf echo12("att") = "Extreme" Then
                            If echo22("cmd") = "Time" Then
                                timeee()
                                SAPI.Speak(Time + echo22("speache"))
                                com = False
                            ElseIf echo22("cmd") = "Date" Then
                                dateee()
                                SAPI.Speak(echo22("speache") + strdateeee)
                                com = False
                            ElseIf echo22("cmd") = "Open Software" Then
                                SAPI.Speak(echo22("speache"))
                                com = True
                                openapps()
                            ElseIf echo22("cmd") = "Settings" Then
                                SAPI.Speak(echo22("speache"))
                                com = True
                                opensettings()
                            ElseIf echo22("cmd") = "Exit" Then
                                SAPI.Speak(echo22("speache"))
                                com = True
                                exittt()
                            ElseIf echo22("cmd") = "Open Words" Then
                                SAPI.Speak(echo22("speache"))
                                com = True
                                opendictionary()
                            ElseIf echo22("cmd") = "Open System Browser" Then
                                SAPI.Speak(echo22("speache"))
                                com = True
                                opensay()
                            ElseIf echo22("cmd") = "I have something to say" Then
                                com = True
                                openplay()
                            Else
                                SAPI.Speak(echo22("speache"))
                                com = False
                            End If
                        End If
                End Select

            End While
        End While

        conn2.Close()
    End Sub


    Public Sub openplay()

        Dim functionzzz As String = "Emotional Support"
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

        Dim attsel2emo As String = "SELECT * FROM settings WHERE id = 1"
        Dim conn2emo As New SQLiteConnection(connectionString)
        Dim cmd2emo As New SQLiteCommand(attsel2emo, conn2emo)
        Dim echo12emo As SQLiteDataReader
        conn2emo.Open()
        echo12emo = cmd2emo.ExecuteReader
        echo12emo.Read()

        Dim mnm = New Random().Next(6, 10)

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

        Form8.Show()
        Me.Close()
    End Sub

    Public Sub exittt()

        Dim functionzzz As String = "Exits Control Panel"
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

    Public Sub timeee()


        Dim functionzzz As String = "Asked Time"
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


        Time = TimeOfDay.ToString("h mm tt")
    End Sub

    Public Sub dateee()


        Dim functionzzz As String = "Asked Date"
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

        Month = Date.Today.ToString("MM")

        If Month = "01" Then
            Monthlet = "January"
        ElseIf Month = "02" Then
            Monthlet = "February"
        ElseIf Month = "03" Then
            Monthlet = "March"
        ElseIf Month = "04" Then
            Monthlet = "April"
        ElseIf Month = "05" Then
            Monthlet = "May"
        ElseIf Month = "06" Then
            Monthlet = "June"
        ElseIf Month = "07" Then
            Monthlet = "July"
        ElseIf Month = "08" Then
            Monthlet = "August"
        ElseIf Month = "09" Then
            Monthlet = "September"
        ElseIf Month = "10" Then
            Monthlet = "October"
        ElseIf Month = "11" Then
            Monthlet = "November"
        ElseIf Month = "12" Then
            Monthlet = "December"
        End If

        strdateeee = Monthlet & Date.Today.ToString("dd yyyy")
    End Sub

    Public Sub openapps()

        Dim functionzzz As String = "Opened App Selection"
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

        Dim attf3op As String = "SELECT * FROM settings WHERE id = 1"
        Dim connf3op As New SQLiteConnection(connectionString)
        Dim cmdf3op As New SQLiteCommand(attf3op, connf3op)
        Dim echof3op As SQLiteDataReader
        connf3op.Open()
        echof3op = cmdf3op.ExecuteReader
        echof3op.Read()

        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Voice = SAPI.GetVoices.Item(1)

        If echof3op("att") = "Friendly" Then
            SAPI.Speak("What should I open boss?")
        ElseIf echof3op("att") = "Normal" Then
            SAPI.Speak("What do you want me to open?")
        ElseIf echof3op("att") = "Extreme" Then
            SAPI.Speak("You Lazy Shit, what app?")
        End If

        connf3op.Close()

        Form3.Show()
        Me.Close()
    End Sub

    Public Sub opensettings()

        Dim functionzzz As String = "Opened Settings"
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

        Form4.Show()
        Me.Close()
    End Sub

    Public Sub opendictionary()

        Dim functionzzz As String = "Opened System Dictionary"
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

        Form5.Show()
        Me.Close()
    End Sub

    Public Sub opensay()

        Dim functionzzz As String = "Opened System Browser"
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

        Form6.Show()
        Me.Close()
    End Sub

    Public Sub saveact()

        Dim attsel123 As String = "Select Count(times_openedZ) As memorynum From startup"
        Dim conn123 As New SQLiteConnection(connectionString3)
        Dim cmd123 As New SQLiteCommand(attsel123, conn123)
        Dim echo1123 As SQLiteDataReader
        conn123.Open()
        echo1123 = cmd123.ExecuteReader

        echo1123.Read()

        Dim memorynum As Integer = echo1123("memorynum")


        If memorynum <= 1 Then
            SAPI = CreateObject("SAPI.spvoice")
            SAPI.Voice = SAPI.GetVoices.Item(1)

            Dim attsel123123 As String = "Select * From memory_speeches Where id = 1"
            Dim conn123123 As New SQLiteConnection(connectionString3)
            Dim cmd123123 As New SQLiteCommand(attsel123123, conn123123)
            Dim echo1123123 As SQLiteDataReader
            conn123123.Open()
            echo1123123 = cmd123123.ExecuteReader
            echo1123123.Read()
            SAPI.Speak(echo1123123("speeches"))
            conn123123.Close()

            Dim functionzzz As String = "Z on Wake Up"
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
        Else

            SAPI = CreateObject("SAPI.spvoice")
            SAPI.Voice = SAPI.GetVoices.Item(1)

            Dim attsel As String = "SELECT * FROM settings WHERE id = 1"
            Dim conn As New SQLiteConnection(connectionString)
            Dim cmd As New SQLiteCommand(attsel, conn)
            Dim echo1 As SQLiteDataReader
            conn.Open()
            echo1 = cmd.ExecuteReader

            While echo1.Read()

                If echo1("att") = "Friendly" Then
                    Dim num = New Random().Next(1, 5)

                    Dim cmdhh As String = "SELECT * FROM friendly Where id = " & num
                    Dim conn1 As New SQLiteConnection(connectionString6)
                    Dim cmd2 As New SQLiteCommand(cmdhh, conn1)
                    Dim echo2 As SQLiteDataReader
                    conn1.Open()
                    echo2 = cmd2.ExecuteReader
                    echo2.Read()
                    SAPI.Speak(echo2("resp"))

                ElseIf echo1("att") = "Normal" Then
                    Dim num = New Random().Next(1, 5)

                    Dim cmdhh As String = "SELECT * FROM normal Where id = " & num
                    Dim conn1 As New SQLiteConnection(connectionString6)
                    Dim cmd2 As New SQLiteCommand(cmdhh, conn1)
                    Dim echo2 As SQLiteDataReader
                    conn1.Open()
                    echo2 = cmd2.ExecuteReader
                    echo2.Read()
                    SAPI.Speak(echo2("resp"))


                ElseIf echo1("att") = "Extreme" Then
                    Dim num = New Random().Next(1, 5)

                    Dim cmdhh As String = "SELECT * FROM extreme Where id = " & num
                    Dim conn1 As New SQLiteConnection(connectionString6)
                    Dim cmd2 As New SQLiteCommand(cmdhh, conn1)
                    Dim echo2 As SQLiteDataReader
                    conn1.Open()
                    echo2 = cmd2.ExecuteReader
                    echo2.Read()
                    SAPI.Speak(echo2("resp"))

                End If
            End While

            conn.Close()


            Dim functionzzz As String = "Z on Call"
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
        End If

        conn123.Close()


    End Sub

    Private Sub GunaCircleProgressBar2_Click(sender As Object, e As EventArgs) Handles GunaCircleProgressBar2.Click

    End Sub
End Class