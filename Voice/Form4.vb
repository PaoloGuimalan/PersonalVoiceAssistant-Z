Imports System.Speech
Imports System.Speech.Recognition
Imports System.Data.SQLite

Public Class Form4

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

    Private WithEvents Voice4 As New Recognition.SpeechRecognitionEngine

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Hide()

        Voice4.SetInputToDefaultAudioDevice()

        Dim selectss24 As String = "SELECT * FROM settingscmd"
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

            Voice4.LoadGrammar(New Recognition.Grammar(Gramm2))


        End While

        conn24.Close()

        Voice4.RecognizeAsync()

        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False

    End Sub

    Private Sub Voice4_RecognizeCompleted(sender As Object, xx As RecognizeCompletedEventArgs) Handles Voice4.RecognizeCompleted
        If com <> True Then
            Voice4.RecognizeAsync()
        End If
    End Sub

    Dim SAPI

    Private Sub Voice4_SpeechRecognized(sender As Object, xx As SpeechRecognizedEventArgs) Handles Voice4.SpeechRecognized
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Voice = SAPI.GetVoices.Item(1)

        Dim cmdhh2 As String = "SELECT * FROM settingscmd"
        Dim conn12 As New SQLiteConnection(connectionString)
        Dim cmd22 As New SQLiteCommand(cmdhh2, conn12)
        Dim echo22 As SQLiteDataReader
        conn12.Open()
        echo22 = cmd22.ExecuteReader

        While echo22.Read()
            Select Case xx.Result.Text
                Case echo22("cmd")
                    If echo22("cmd") = "Exit" Then
                        SAPI.Speak("Exiting Settings")
                        com = True
                        exit4()
                    End If
            End Select

        End While
        conn12.Close()

    End Sub

    Public Sub exit4()

        Dim functionzzz As String = "Exits Settings"
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Voice = SAPI.GetVoices.Item(1)

        If ComboBox1.Text = "" Then
            SAPI.Speak("You cannot set my attitude level as null! Please Set my attitude level properly.")
        Else

            Dim functionzzz As String = "Attitude Level Updated to " & ComboBox1.Text
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


            Dim settss As String = "UPDATE settings SET att = '" + ComboBox1.Text + "'WHERE id = 1"
            Dim conn2ss As New SQLiteConnection(connectionString)
            Dim cmd2ss As New SQLiteCommand(settss, conn2ss)
            conn2ss.Open()
            cmd2ss.ExecuteNonQuery()
            conn2ss.Close()
            SAPI.Speak("Attitude Level Successfully Updated to" + ComboBox1.Text)
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "" Then

        ElseIf ComboBox2.Text = "Commands" Then
            cmbbx = "commands"
            load_cmds()
        ElseIf ComboBox2.Text = "Control Panel" Then
            cmbbx = "controlpanel"
            load_cmds()
        ElseIf ComboBox2.Text = "Applications" Then
            cmbbx = "Applications"
            load_cmds()
        ElseIf ComboBox2.Text = "SettingsCmd" Then
            cmbbx = "settingscmd"
            load_cmds()
        ElseIf ComboBox2.Text = "WordCmd" Then
            cmbbx = "WordCmd"
            load_cmds()
        ElseIf ComboBox2.Text = "SystemBrowser" Then
            cmbbx = "browsercmds"
            load_cmds()
        End If

    End Sub

    Sub load_cmds()
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Voice = SAPI.GetVoices.Item(1)

        If ComboBox2.Text = "" Then
            SAPI.Speak("Please Select a Table of Commands.")
        Else
            Dim cmdhh2 As String = "SELECT * FROM " + cmbbx
            Dim conn12 As New SQLiteConnection(connectionString)
            Dim cmd22 As New SQLiteCommand(cmdhh2, conn12)
            conn12.Open()
            cmd22.ExecuteNonQuery()
            Dim dr As New SQLiteDataAdapter
            dr.SelectCommand = cmd22
            Dim parsetable As New DataTable
            dr.Fill(parsetable)
            conn12.Close()

            ListView1.Items.Clear()
            For Each row As DataRow In parsetable.Rows
                With ListView1.Items.Add(row.Item("cmd").ToString)
                    .SubItems.Add(row.Item("speachf").ToString)
                    .SubItems.Add(row.Item("speachn").ToString)
                    .SubItems.Add(row.Item("speache").ToString)
                    .SubItems.Add(row.Item("actions").ToString)
                    .SubItems.Add(row.Item("id").ToString)
                    .SubItems.Add(row.Item("app_label").ToString)
                End With
            Next
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False

            btnAdd.Enabled = False
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnSave.Enabled = False
            sel_user_id = ListView1.SelectedItems(0).SubItems(5).Text
            Dim cmdhh27 As String = "SELECT * FROM " & cmbbx & " WHERE id = " & sel_user_id
            Dim conn127 As New SQLiteConnection(connectionString)
            Dim cmd227 As New SQLiteCommand(cmdhh27, conn127)
            conn127.Open()
            cmd227.ExecuteNonQuery()
            Dim dr As New SQLiteDataAdapter
            dr.SelectCommand = cmd227
            Dim parsetable As New DataTable
            dr.Fill(parsetable)
            conn127.Close()
            For Each row As DataRow In parsetable.Rows
                TextBox1.Text = row.Item("cmd").ToString
                TextBox2.Text = row.Item("speachf").ToString
                TextBox3.Text = row.Item("speachn").ToString
                TextBox4.Text = row.Item("speache").ToString
                TextBox5.Text = row.Item("actions").ToString
                TextBox6.Text = row.Item("app_label").ToString
            Next
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        clearTextboxes()

        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = True
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        isNew = True
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = True
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        isNew = False
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Voice = SAPI.GetVoices.Item(1)

        If ListView1.SelectedItems.Count > 0 Then
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False

            Dim ans = MsgBox("Are you sure you want to delete this Command?",
            MsgBoxStyle.YesNoCancel, "Delete")

            If ans = MsgBoxResult.Yes Then

                Dim functionzzz As String = " A Command in " & cmbbx & " has been Deleted"
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

                Dim cmdhh28 As String = "DELETE FROM " & cmbbx & " WHERE id = " & sel_user_id
                Dim conn128 As New SQLiteConnection(connectionString)
                Dim cmd228 As New SQLiteCommand(cmdhh28, conn128)
                conn128.Open()
                cmd228.ExecuteNonQuery()
                conn128.Close()

                SAPI.Speak("A Command has been successfully Deleted!")

                load_cmds()
                clearTextboxes()
            End If
        Else
            SAPI.Speak("Please Select a Command to Delete!")
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Voice = SAPI.GetVoices.Item(1)

        If isNew = True Then
            'insert to database

            Dim functionzzz As String = "A new Command has been declared in " & cmbbx
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


            Dim cmdhh29 As String = "INSERT INTO " & cmbbx &
            " (cmd, speachf, speachn, speache, actions, app_label) " &
            "VALUES " &
            "(" &
            "'" & TextBox1.Text.Trim & "', " &
            "'" & TextBox2.Text.Trim & "', " &
            "'" & TextBox3.Text.Trim & "', " &
            "'" & TextBox4.Text.Trim & "', " &
            "'" & TextBox5.Text.Trim & "', " &
            "'" & TextBox6.Text.Trim & "'" &
            ")"

            Dim conn129 As New SQLiteConnection(connectionString)
            Dim cmd229 As New SQLiteCommand(cmdhh29, conn129)
            conn129.Open()
            cmd229.ExecuteNonQuery()
            conn129.Close()
            SAPI.Speak("New Command has been saved successfully.")
        End If

        If isNew = False Then
            'insert to database

            Dim functionzzz As String = "A Command has been Updated in " & cmbbx
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


            Dim cmdhh25 As String = "UPDATE " & cmbbx &
            " SET cmd ='" & TextBox1.Text.Trim & "', " &
            "speachf ='" & TextBox2.Text.Trim & "', " &
            "speachn ='" & TextBox3.Text.Trim & "', " &
            "speache ='" & TextBox4.Text.Trim & "', " &
            "actions ='" & TextBox5.Text.Trim & "', " &
            "app_label ='" & TextBox6.Text.Trim & "' " &
            "WHERE id = " & sel_user_id

            Dim conn125 As New SQLiteConnection(connectionString)
            Dim cmd225 As New SQLiteCommand(cmdhh25, conn125)
            conn125.Open()
            cmd225.ExecuteNonQuery()
            conn125.Close()
            SAPI.Speak("Existing Command has been updated successfully.")
        End If

        load_cmds()
        clearTextboxes()
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = False

    End Sub

    Public Sub clearTextboxes()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""

        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = False

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub
End Class