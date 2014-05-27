Imports System.IO

Public Class Form1
    Public appdataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

    Public ip As String
    Public port As String
    Public count As System.Collections.ObjectModel.ReadOnlyCollection(Of String)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox2.Text = "" Then
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Error
            NotifyIcon1.BalloonTipTitle = "Info Missing"
            NotifyIcon1.BalloonTipText = "Enter IP address!"
            NotifyIcon1.ShowBalloonTip(7000)
        ElseIf TextBox3.Text = "" Then

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
                mypro.StartInfo.Arguments = " " & TextBox2.Text & " " & TextBox3.Text
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
                ComboBox1.SelectedIndex = 0
            End If


        Else
            My.Computer.FileSystem.CreateDirectory(appdataPath & "\Crasher")
        End If

       




    End Sub
    Private Sub reloadserverlist()

        ComboBox1.Items.Clear()
        Dim files() As String = System.IO.Directory.GetFiles(appdataPath & "\Crasher")
        Dim di As New IO.DirectoryInfo(appdataPath & "\Crasher")
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo


        For Each dra In diar1
            'Dim strsplit() As String = Split(dra.FullName.ToString, ".")
            ComboBox1.Items.Add(System.IO.Path.GetFileNameWithoutExtension(dra.FullName))

        Next

        count = My.Computer.FileSystem.GetFiles(appdataPath & "\Crasher")
    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged




        Dim fileExists1 As Boolean
        fileExists1 = My.Computer.FileSystem.FileExists(appdataPath & "\Crasher\" & ComboBox1.Text & ".Server")
        If fileExists1 = True Then

            Dim file4 As New FileStream(appdataPath & "\Crasher\" & ComboBox1.Text & ".Server", FileMode.Open, FileAccess.Read)

            Dim br As New BinaryReader(file4)

            ' Dim ip As String
            'Dim port As String




            TextBox2.Text = br.ReadString
            TextBox3.Text = br.ReadString


            br.Close()
            file4.Close()


        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        

        If ComboBox1.Text = "" Or ComboBox1.Text = " " Then
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Error
            NotifyIcon1.BalloonTipTitle = "Server Name"
            NotifyIcon1.BalloonTipText = "Enter a Server name!"
            NotifyIcon1.ShowBalloonTip(7000)

        Else

            Dim file4 As New FileStream(appdataPath & "\Crasher\" & ComboBox1.Text & ".Server", FileMode.Create, FileAccess.Write)




            Dim bw1 As New BinaryWriter(file4)

            bw1.Write(TextBox2.Text)
            bw1.Write(TextBox3.Text)

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click



        My.Computer.FileSystem.DeleteFile(appdataPath & "\Crasher\" & ComboBox1.Text & ".Server", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

        ComboBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""

        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.BalloonTipTitle = "Deleted"
        NotifyIcon1.BalloonTipText = "Server Deleted!"
        NotifyIcon1.ShowBalloonTip(7000)

        reloadserverlist()




        'Form1_Load(Me, New System.EventArgs)
        'Me.Show()
    End Sub
End Class
