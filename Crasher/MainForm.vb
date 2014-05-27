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


                Dim crasherBaseFilePath As String = Application.StartupPath & "\crasherbase"


                Dim crashProcess As New Process
                crashProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                crashProcess.StartInfo.FileName = crasherBaseFilePath
                crashProcess.StartInfo.Arguments = " " & comboBoxServerIP.Text & " " & comboBoxServerPort.Text
                crashProcess.Start()



                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
                NotifyIcon1.BalloonTipTitle = "HACKED!"
                NotifyIcon1.BalloonTipText = "Check the Server, should have crashed!"
                NotifyIcon1.ShowBalloonTip(7000)



            Catch ex As Exception

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

            reloadServerList()
            If count.Count = 0 Then
            Else
                comboBoxServerName.SelectedIndex = 0
            End If

        Else

            My.Computer.FileSystem.CreateDirectory(appdataPath & "\Crasher")

        End If

    End Sub
    Private Sub reloadServerList()

        comboBoxServerName.Items.Clear()
        Dim files() As String = System.IO.Directory.GetFiles(appdataPath & "\Crasher")
        Dim directoryInfo As New IO.DirectoryInfo(appdataPath & "\Crasher")
        Dim allFilesInfo As IO.FileInfo() = directoryInfo.GetFiles()
        Dim eachFile As IO.FileInfo


        For Each eachFile In allFilesInfo

            comboBoxServerName.Items.Add(System.IO.Path.GetFileNameWithoutExtension(eachFile.FullName))

        Next

        count = My.Computer.FileSystem.GetFiles(appdataPath & "\Crasher")

    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBoxServerName.SelectedIndexChanged

        Dim serverFileExists As Boolean
        serverFileExists = My.Computer.FileSystem.FileExists(appdataPath & "\Crasher\" & comboBoxServerName.Text & ".Server")
        If serverFileExists = True Then

            Dim serverDataFile As New FileStream(appdataPath & "\Crasher\" & comboBoxServerName.Text & ".Server", FileMode.Open, FileAccess.Read)

            Dim binaryReader As New BinaryReader(serverDataFile)


            comboBoxServerIP.Text = binaryReader.ReadString
            comboBoxServerPort.Text = binaryReader.ReadString


            binaryReader.Close()
            serverDataFile.Close()


        End If

    End Sub

    Private Sub buttonSaveClick(sender As Object, e As EventArgs) Handles buttonSave.Click



        If comboBoxServerName.Text = "" Or comboBoxServerName.Text = " " Then
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Error
            NotifyIcon1.BalloonTipTitle = "Server Name"
            NotifyIcon1.BalloonTipText = "Enter a Server name!"
            NotifyIcon1.ShowBalloonTip(7000)

        Else

            Dim serverDataFile As New FileStream(appdataPath & "\Crasher\" & comboBoxServerName.Text & ".Server", FileMode.Create, FileAccess.Write)

            Dim binaryWriter As New BinaryWriter(serverDataFile)

            binaryWriter.Write(comboBoxServerIP.Text)
            binaryWriter.Write(comboBoxServerPort.Text)

            binaryWriter.Close()
            serverDataFile.Close()

            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            NotifyIcon1.BalloonTipTitle = "Saved"
            NotifyIcon1.BalloonTipText = "Server Saved!"

            NotifyIcon1.ShowBalloonTip(7000)

            reloadServerList()

        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Dim disclaimerFilePath As String = Application.StartupPath & "\Disclaimer.pdf"

        Dim openDisclaimerProcess As New Process
        openDisclaimerProcess.StartInfo.FileName = disclaimerFilePath
        openDisclaimerProcess.Start()

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

        reloadServerList()

    End Sub
End Class
