Imports System.IO

Public Class MainForm

    'Get path of the "AppData" system folder to store the ServerIP and ServerPorts
    'Using this folder enables the software to be run from anywhere
    'in the system. The data of the saved servers will be accessible to the software.
    Public appdataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

    Public count As System.Collections.ObjectModel.ReadOnlyCollection(Of String)

    Private Sub buttonCrashClick(sender As Object, e As EventArgs) Handles buttonCrash.Click


        'Check if the ServerIP or ServerPort are empty.
        'If either of them are empty, end module with notifying the user
        If textBoxServerIP.Text = "" Then
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Error
            NotifyIcon1.BalloonTipTitle = "Info Missing"
            NotifyIcon1.BalloonTipText = "Enter IP address!"
            NotifyIcon1.ShowBalloonTip(7000)
        ElseIf textBoxServerPort.Text = "" Then

            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Error
            NotifyIcon1.BalloonTipTitle = "Info Missing"
            NotifyIcon1.BalloonTipText = "Enter Port!"
            NotifyIcon1.ShowBalloonTip(7000)
        Else

            'If both ServerIP and ServerPort text fields have data,
            'continue the module and run the CLI code for the given
            'ServerIP and ServerPort
            Try

                Dim crasherBaseFilePath As String = Application.StartupPath & "\crasherbase"

                'CLI tool is run here
                'The CLI tool is named as "crasherbase" so that it doesn't reveal
                'information about the original malicious code.
                'The malicious code is not endorsed by me. Neither will I distribute
                'nor include it in my source code.
                Dim crashProcess As New Process
                crashProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                crashProcess.StartInfo.FileName = crasherBaseFilePath
                crashProcess.StartInfo.Arguments = " " & textBoxServerIP.Text & " " & textBoxServerPort.Text
                crashProcess.Start()


                'Notify the user of successful execution of the code
                'through system tray icon
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
                NotifyIcon1.BalloonTipTitle = "HACKED!"
                NotifyIcon1.BalloonTipText = "Check the Server, should have crashed!"
                NotifyIcon1.ShowBalloonTip(7000)


            Catch ex As Exception

                'An exception will occur if the "crasherbase" file is missing.
                'This will cause system tray to notify the user that something went wrong
                'without revealing info about the original hacking code.
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Error
                NotifyIcon1.BalloonTipTitle = "Something went Wrong"
                NotifyIcon1.BalloonTipText = "Coudn't execute the Hack! Try again"
                NotifyIcon1.ShowBalloonTip(7000)

            End Try

        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'System tray icon and balloon tip welcomes the user on launch of the software
        NotifyIcon1.BalloonTipTitle = "Welcome"
        NotifyIcon1.BalloonTipText = "Let's crash some Servers!"
        NotifyIcon1.ShowBalloonTip(7000)

        'Check if the "Crasher" folder exists in the "AppData" system folder
        'If not, create it.
        Dim folderExists As Boolean
        folderExists = My.Computer.FileSystem.DirectoryExists(appdataPath & "\Crasher")

        If folderExists = True Then

            'If folder exists, retrieve saved servers list including their
            'name, IP and port.
            reloadServerList()

            'If no saved servers exist
            If count.Count = 0 Then
            Else
                comboBoxServerName.SelectedIndex = 0
            End If

        Else

            My.Computer.FileSystem.CreateDirectory(appdataPath & "\Crasher")

        End If

    End Sub
    Private Sub reloadServerList()

        'This module will retrieve the saved server in the "/Appdata/Crasher" folder
        'Saved server are in the following format.
        '
        'Each server's info will be stored in a different file.
        '
        'ServerName.Server
        '
        'ServerName = The custom name of the server that user has specified
        '
        'The file contains: ServerIP and ServerPort

        comboBoxServerName.Items.Clear()
        Dim files() As String = System.IO.Directory.GetFiles(appdataPath & "\Crasher")
        Dim directoryInfo As New IO.DirectoryInfo(appdataPath & "\Crasher")
        Dim allFilesInfo As IO.FileInfo() = directoryInfo.GetFiles()
        Dim eachFile As IO.FileInfo


        For Each eachFile In allFilesInfo

            'Servers are added to the combo box
            comboBoxServerName.Items.Add(System.IO.Path.GetFileNameWithoutExtension(eachFile.FullName))

        Next

        'Total numbers to server retrieved is stored in count
        count = My.Computer.FileSystem.GetFiles(appdataPath & "\Crasher")

    End Sub



    Private Sub comboBoxServerNameSelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBoxServerName.SelectedIndexChanged

        'This module populates the ServerIP and ServerPort text fields when 
        'a new server is selected from the server name combo box.
        Dim serverFileExists As Boolean
        serverFileExists = My.Computer.FileSystem.FileExists(appdataPath & "\Crasher\" & comboBoxServerName.Text & ".Server")
        If serverFileExists = True Then

            Dim serverDataFile As New FileStream(appdataPath & "\Crasher\" & comboBoxServerName.Text & ".Server", FileMode.Open, FileAccess.Read)

            Dim binaryReader As New BinaryReader(serverDataFile)


            textBoxServerIP.Text = binaryReader.ReadString
            textBoxServerPort.Text = binaryReader.ReadString


            binaryReader.Close()
            serverDataFile.Close()


        End If

    End Sub

    Private Sub buttonSaveClick(sender As Object, e As EventArgs) Handles buttonSave.Click


        'This function saves the data as:
        'serverName from combo box is the file name.
        'The file is written with data from text boxes containing the 
        'ServerIP and ServerPort.

        If comboBoxServerName.Text = "" Or comboBoxServerName.Text = " " Then
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Error
            NotifyIcon1.BalloonTipTitle = "Server Name"
            NotifyIcon1.BalloonTipText = "Enter a Server name!"
            NotifyIcon1.ShowBalloonTip(7000)

        Else

            Dim serverDataFile As New FileStream(appdataPath & "\Crasher\" & comboBoxServerName.Text & ".Server", FileMode.Create, FileAccess.Write)

            Dim binaryWriter As New BinaryWriter(serverDataFile)

            binaryWriter.Write(textBoxServerIP.Text)
            binaryWriter.Write(textBoxServerPort.Text)

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

    Private Sub linkLabelDisclaimerLinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabelDisclaimer.LinkClicked

        'Open the Disclaimer.pdf file packed with the GUI
        Dim disclaimerFilePath As String = Application.StartupPath & "\Disclaimer.pdf"

        Dim openDisclaimerProcess As New Process
        openDisclaimerProcess.StartInfo.FileName = disclaimerFilePath
        openDisclaimerProcess.Start()

    End Sub

    Private Sub buttonDeleteClick(sender As Object, e As EventArgs) Handles buttonDelete.Click

        'Deletes the "ServerName.Server" file and hence deleting all traces
        'of the server in that file.
        My.Computer.FileSystem.DeleteFile(appdataPath & "\Crasher\" & comboBoxServerName.Text & ".Server", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

        'Clears the combo box and text fields to be concurrent with deleted server.
        comboBoxServerName.Text = ""
        textBoxServerIP.Text = ""
        textBoxServerPort.Text = ""

        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.BalloonTipTitle = "Deleted"
        NotifyIcon1.BalloonTipText = "Server Deleted!"
        NotifyIcon1.ShowBalloonTip(7000)

        'As the combo box was cleared, it is re-populated with the remaining servers
        'from the "AppData/Crasher" folder.
        reloadServerList()

    End Sub
End Class
