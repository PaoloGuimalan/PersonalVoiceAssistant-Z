Imports System.Speech
Imports System.Speech.Recognition
Imports System.Data.SQLite
Imports Microsoft.Win32

Public Class Form6

    Private sel_user_id As String
    Dim isNew As Boolean
    Dim com As Boolean = False
    Dim cmbbx As String
    Dim locationn As String = "C:\Z_Assistant\VoiceDB"
    Dim filename As String = "myDataBase.db"
    Dim fullpath As String = System.IO.Path.Combine(locationn, filename)
    Public connectionString As String = String.Format("Data Source = {0}", fullpath)

    Dim locationn2 As String = "C:\Z_Assistant\VoiceDB"
    Dim filename2 As String = "app_history.db"
    Dim fullpath2 As String = System.IO.Path.Combine(locationn2, filename2)
    Public connectionString2 As String = String.Format("Data Source = {0}", fullpath2)

    Private WithEvents Voice6 As New Recognition.SpeechRecognitionEngine
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Hide()
        WebBrowserUpdater.FixBrowserVersion()

        Voice6.SetInputToDefaultAudioDevice()

        Dim selectss24 As String = "SELECT * FROM browsercmds"
        Dim conn24 As New SQLiteConnection(connectionString)
        Dim cmd24 As New SQLiteCommand(selectss24, conn24)
        Dim echo24 As SQLiteDataReader
        conn24.Open()
        echo24 = cmd24.ExecuteReader

        Dim SS24 As String
        While echo24.Read()

            SS24 = echo24("cmd")

            Dim Gramm2 As New Recognition.SrgsGrammar.SrgsDocument

            Dim Rule2 As New Recognition.SrgsGrammar.SrgsRule("Language")

            Dim List2 As New Recognition.SrgsGrammar.SrgsOneOf(SS24)

            Rule2.Add(List2)

            Gramm2.Rules.Add(Rule2)
            Gramm2.Root = Rule2

            Voice6.LoadGrammar(New Recognition.Grammar(Gramm2))


        End While


        conn24.Close()

        Voice6.RecognizeAsync()
    End Sub

    Private Sub Voice6_RecognizeCompleted(sender As Object, xx As RecognizeCompletedEventArgs) Handles Voice6.RecognizeCompleted
        If com <> True Then
            Voice6.RecognizeAsync()
        End If
    End Sub

    Dim SAPI

    Private Sub Voice6_SpeechRecognized(sender As Object, xx As SpeechRecognizedEventArgs) Handles Voice6.SpeechRecognized
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Voice = SAPI.GetVoices.Item(1)

        Dim attsel2 As String = "SELECT * FROM settings WHERE id = 1"
        Dim conn2 As New SQLiteConnection(connectionString)
        Dim cmd2 As New SQLiteCommand(attsel2, conn2)
        Dim echo12 As SQLiteDataReader
        conn2.Open()
        echo12 = cmd2.ExecuteReader

        While echo12.Read()

            Dim cmdhh2 As String = "SELECT * FROM browsercmds"
            Dim conn12 As New SQLiteConnection(connectionString)
            Dim cmd22 As New SQLiteCommand(cmdhh2, conn12)
            Dim echo22 As SQLiteDataReader
            conn12.Open()
            echo22 = cmd22.ExecuteReader

            While echo22.Read()
                Select Case xx.Result.Text
                    Case echo22("cmd")
                        If echo12("att") = "Friendly" Then
                            If echo22("cmd") = "search" Then
                                SAPI.Speak(echo22("speachf"))
                                If TextBox1.Text.Contains(" ") Then
                                    WebBrowser1.Navigate("www.google.com/search?q=" + TextBox1.Text)
                                ElseIf TextBox1.Text.Contains("www.") And TextBox1.Text.Contains(".com") Xor TextBox1.Text.Contains(" ") Then
                                    WebBrowser1.Navigate(TextBox1.Text)
                                ElseIf TextBox1.Text.Contains("www.") Or TextBox1.Text.Contains(".com") Xor TextBox1.Text.Contains(" ") Then
                                    WebBrowser1.Navigate(TextBox1.Text)
                                Else
                                    WebBrowser1.Navigate("www.google.com/search?q=" + TextBox1.Text)
                                End If
                                com = False
                            ElseIf echo22("cmd") = "exit" Then
                                SAPI.Speak(echo22("speachf"))
                                com = True
                                exit6()
                            End If
                        ElseIf echo12("att") = "Normal" Then
                            If echo22("cmd") = "search" Then
                                SAPI.Speak(echo22("speachn"))
                                If TextBox1.Text.Contains(" ") Then
                                    WebBrowser1.Navigate("www.google.com/search?q=" + TextBox1.Text)
                                ElseIf TextBox1.Text.Contains("www.") And TextBox1.Text.Contains(".com") Xor TextBox1.Text.Contains(" ") Then
                                    WebBrowser1.Navigate(TextBox1.Text)
                                ElseIf TextBox1.Text.Contains("www.") Or TextBox1.Text.Contains(".com") Xor TextBox1.Text.Contains(" ") Then
                                    WebBrowser1.Navigate(TextBox1.Text)
                                Else
                                    WebBrowser1.Navigate("www.google.com/search?q=" + TextBox1.Text)
                                End If
                                com = False
                            ElseIf echo22("cmd") = "exit" Then
                                SAPI.Speak(echo22("speachn"))
                                com = True
                                exit6()
                            End If
                        ElseIf echo12("att") = "Extreme" Then
                            If echo22("cmd") = "search" Then
                                SAPI.Speak(echo22("speache"))
                                If TextBox1.Text.Contains(" ") Then
                                    WebBrowser1.Navigate("www.google.com/search?q=" + TextBox1.Text)
                                ElseIf TextBox1.Text.Contains("www.") And TextBox1.Text.Contains(".com") Xor TextBox1.Text.Contains(" ") Then
                                    WebBrowser1.Navigate(TextBox1.Text)
                                ElseIf TextBox1.Text.Contains("www.") Or TextBox1.Text.Contains(".com") Xor TextBox1.Text.Contains(" ") Then
                                    WebBrowser1.Navigate(TextBox1.Text)
                                Else
                                    WebBrowser1.Navigate("www.google.com/search?q=" + TextBox1.Text)
                                End If
                                com = False
                            ElseIf echo22("cmd") = "exit" Then
                                SAPI.Speak(echo22("speache"))
                                com = True
                                exit6()
                            End If
                        End If
                End Select

            End While
            conn12.Close()
        End While


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub

    Public Sub exit6()

        Dim functionzzz As String = "Exits System Browser"
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


''' <summary>
''' Creates registry entry to allow standard WebBrowser control to operate at maximum compatibility instead of IE7
''' NOTE: the entry is specific to an application so must be done for any program that uses WebBrowser
''' </summary>
''' <remarks></remarks>
Public Class WebBrowserUpdater

    Public Shared Sub FixBrowserVersion()
        Try
            Dim BrowserVer As Integer, RegVal As Integer

            ' get the installed IE version
            Using Wb As New WebBrowser()
                BrowserVer = Wb.Version.Major
            End Using

            ' set the appropriate IE version
            If BrowserVer >= 11 Then
                RegVal = 11001
            ElseIf BrowserVer = 10 Then
                RegVal = 11001
            ElseIf BrowserVer = 9 Then
                RegVal = 11001
            ElseIf BrowserVer = 8 Then
                RegVal = 11001
            Else
                RegVal = 11001
            End If

            ' set the actual key
            Using Key As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", RegistryKeyPermissionCheck.ReadWriteSubTree)
                If Key.GetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe") Is Nothing Then
                    Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, RegistryValueKind.DWord)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class