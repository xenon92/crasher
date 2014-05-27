Imports System.IO

Public Class MainForm
    Public appdataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)



    Public count As System.Collections.ObjectModel.ReadOnlyCollection(Of String)

    Private Sub buttonCrashClick(sender As Object, e As EventArgs) Handles buttonCrash.Click

        If comboBoxServerIP.Text = "" Then
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Error
            NotifyIcon1.BalloonTipTitle = "Info Missing"
            NotifyIcon1.BalloonTipText = "Enter IP address!"
            NotifyIcon1.ShowBalloonTip(7000)
        ElseIf comboBoxServerPort.Text = "" Then

            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Error
            NotifyIcon1.BalloonTipTitle = "Info Missing"
            NotifyIcon1.BalloonTipText = "Enter Port!"
            NotifyIcon1.ShowBalloonTip(7000)
        Else

            Try


                Dim SetupPath As String = Application.StartupPath & "\crasherbase"


                Dim mypro As New Process
                mypro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                mypro.StartInfo.FileName = SetupPath
                mypro.StartInfo.Arguments = " " & comboBoxServerIP.Text & " " & comboBoxServerPort.Text
                mypro.Start()



                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
                NotifyIcon1.BalloonTipTitle = "HACKED!"
                NotifyIcon1.BalloonTipText = "Check the Server, should have crashed!"
                NotifyIcon1.ShowBalloonTip(7000)



            Catch ex As Exception
                'MsgBox(ex.Message)
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Error
                NotifyIcon1.BalloonTipTitle = "Something went Wrong"
                NotifyIcon1.BalloonTipText = "Coudn't execute the Hack! Try again"
                NotifyIcon1.ShowBalloonTip(7000)


            End Try





        End If







    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NotifyIcon1.BalloonTipTitle = "Welcome"
        NotifyIcon1.BalloonTipText = "Let's crash some Servers!"
        NotifyIcon1.ShowBalloonTip(7000)


        Dim folderExists As Boolean
        folderExists = My.Computer.FileSystem.DirectoryExists(appdataPath & "\Crasher")

        If folderExists = True Then


            reloadserverlist()
            If count.Count = 0 Then
            Else
                comboBoxServerName.SelectedIndex = 0
            End If


        Else
            My.Computer.FileSystem.CreateDirectory(appdataPath & "\Crasher")
        End If






    End Sub
    Private Sub reloadserverlist()

        comboBoxServerName.Items.Clear()
        Dim files() As String = System.IO.Directory.GetFiles(appdataPath & "\Crasher")
        Dim di As New IO.DirectoryInfo(appdataPath & "\Crasher")
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo


        For Each dra In diar1
            'Dim strsplit() As String = Split(dra.FullName.ToString, ".")
            comboBoxServerName.Items.Add(System.IO.Path.GetFileNameWithoutExtension(dra.FullName))

        Next

        count = My.Computer.FileSystem.GetFiles(appdataPath & "\Crasher")
    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBoxServerName.SelectedIndexChanged




        Dim fileExists1 As Boolean
        fileExists1 = My.Computer.FileSystem.FileExists(appdataPath & "\Crasher\" & comboBoxServerName.Text & ".Server")
        If fileExists1 = True Then

            Dim file4 As New FileStream(appdataPath & "\Crasher\" & comboBoxServerName.Text & ".Server", FileMode.Open, FileAccess.Read)

            Dim br As New BinaryReader(file4)


            comboBoxServerIP.Text = br.ReadString
            comboBoxServerPort.Text = br.ReadString


            br.Close()
            file4.Close()


        End If

    End Sub

    Private Sub buttonSaveClick(sender As Object, e As EventArgs) Handles buttonSave.Click



        If comboBoxServerName.Text = "" Or comboBoxServerName.Text = " " Then
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Error
            NotifyIcon1.BalloonTipTitle = "Server Name"
            NotifyIcon1.BalloonTipText = "Enter a Server name!"
            NotifyIcon1.ShowBalloonTip(7000)

        Else

            Dim file4 As New FileStream(appdataPath & "\Crasher\" & comboBoxServerName.Text & ".Server", FileMode.Create, FileAccess.Write)




            Dim bw1 As New BinaryWriter(file4)

            bw1.Write(comboBoxServerIP.Text)
            bw1.Write(comboBoxServerPort.Text)

            bw1.Close()
            file4.Close()





            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            NotifyIcon1.BalloonTipTitle = "Saved"
            NotifyIcon1.BalloonTipText = "Server Saved!"

            NotifyIcon1.ShowBalloonTip(7000)

            ' ComboBox1.Text = ""
            reloadserverlist()
            'Form1_Load(Nothing, Nothing)

        End If





    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Dim SetupPath As String = Application.StartupPath & "\Disclaimer.pdf"


        Dim mypro As New Process
        'mypro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        mypro.StartInfo.FileName = SetupPath
        'mypro.StartInfo.Arguments = " " & TextBox2.Text & " " & TextBox3.Text
        mypro.Start()
    End Sub

    Private Sub buttonDeleteClick(sender As Object, e As EventArgs) Handles buttonDelete.Click



        My.Computer.FileSystem.DeleteFile(appdataPath & "\Crasher\" & comboBoxServerName.Text & ".Server", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

        comboBoxServerName.Text = ""
        comboBoxServerIP.Text = ""
        comboBoxServerPort.Text = ""

        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.BalloonTipTitle = "Deleted"
        NotifyIcon1.BalloonTipText = "Server Deleted!"
        NotifyIcon1.ShowBalloonTip(7000)

        reloadserverlist()




        'Form1_Load(Me, New System.EventArgs)
        'Me.Show()
    End Sub
End Class
