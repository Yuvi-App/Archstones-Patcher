Imports System.IO

Public Class Form1
    Private Sub cbxRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxRegion.SelectedIndexChanged
        If cbxRegion.SelectedIndex = 0 Then
            cbxTitleID.Items.Clear()
            cbxTitleID.Items.Add("BLUS30443")
            cbxTitleID.SelectedIndex = 0
        ElseIf cbxRegion.SelectedIndex = 1 Then
            cbxTitleID.Items.Clear()
            cbxTitleID.Items.Add("BLES00932")
            cbxTitleID.SelectedIndex = 0
        ElseIf cbxRegion.SelectedIndex = 2 Then
            cbxTitleID.Items.Clear()
            cbxTitleID.Items.Add("BCJS30022")
            cbxTitleID.Items.Add("BCJS70013")
            cbxTitleID.Items.Add("BCAS20071")
            cbxTitleID.Items.Add("BCAS20115")
            cbxTitleID.Items.Add("BCKS10071")
            cbxTitleID.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnPatch_Click(sender As Object, e As EventArgs) Handles btnPatch.Click
        Dim region = cbxRegion.Text
        Dim titleid = cbxTitleID.Text
        Dim rpcs3_location As String
        Dim rpcs3_elf As String
        Dim des_location As String
        Dim server
        Dim writeserverhex
        Dim setelflocation = False

        MessageBox.Show("Please choose your RPCS3 Install Location")
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            rpcs3_location = FolderBrowserDialog1.SelectedPath
            Process.Start(rpcs3_location + "\rpcs3.exe")
            MessageBox.Show("Once RPCS3 Opens, Go to Utilites at the top, Click Decrypt PS3 Binaries." + vbNewLine + vbNewLine + "Select your EBOOT.BIN from Demon's Souls Install Folder (usrdir)" + vbNewLine + "This will add a new file called eboot.elf to your usrdir folder")
        End If


        Dim Folder As New IO.DirectoryInfo(rpcs3_location + "\dev_hdd0")
        For Each File As IO.FileInfo In Folder.GetFiles("*.elf", IO.SearchOption.AllDirectories)
            If Not File.Directory.FullName.Contains("TEST12345") Then
                If MessageBox.Show("Is this the right elf file?" + vbNewLine + File.FullName, "Verify Elf", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    rpcs3_elf = File.FullName
                    des_location = File.DirectoryName
                    setelflocation = True
                    Exit For
                End If
            End If

        Next

        If setelflocation = False Then
            MessageBox.Show("Unable to find your eboot.elf, Please select it")
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                setelflocation = True
                rpcs3_elf = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
                des_location = Path.GetDirectoryName(rpcs3_elf)
            End If
        End If

        If setelflocation = True Then
            'Set Server String to look for
            If titleid = "BLUS30443" Then
                server = "63002E00640065006D006F006E0073002D0073006F0075006C0073002E0063006F006D003A00310038003000300030"
                writeserverhex = "63002E007400680065006100720063006800730074006F006E00650073002E0063006F006D003A00310038003000300030"
            ElseIf titleid = "BLES00932" Then
                server = "640073002D00650075002D0063002E007300630065006A002D006F006E006C0069006E0065002E006A0070003A00310038003000300030"
                writeserverhex = "740077002E007400680065006100720063006800730074006F006E00650073002E0063006F006D003A0031003800300030003000000000"
            Else
                server = "63006D006E00610070002E007300630065006A002D006F006E006C0069006E0065002E006A0070003A00310038003000300030"
                writeserverhex = "740077002E007400680065006100720063006800730074006F006E00650073002E0063006F006D003A00310038003000300030"
            End If

            If MessageBox.Show("Do you wish to patch " + vbNewLine + vbNewLine + "Region: " + region + vbNewLine + "TitleID: " + titleid + vbNewLine + "Eboot Elf to Patch: " + rpcs3_elf, "Patch" + vbNewLine + vbNewLine + vbNewLine + "Original Eboot will be backed up", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                PatchGame(rpcs3_elf, des_location, server, writeserverhex)
            End If
        ElseIf setelflocation = False Then
            MessageBox.Show("No EBOOT.elf Selected, Please try again")
        End If
    End Sub

    Public Function PatchGame(elf, des_location, server, writeservehex)
        'Make Backup First
        Try
            My.Computer.FileSystem.CopyFile(elf, elf + ".bak", Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        Catch ex As Exception

        End Try

        Try
            My.Computer.FileSystem.CopyFile(des_location + "\EBOOT.BIN", des_location + "\EBOOT.BIN" + ".bak", Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        Catch ex As Exception

        End Try

        Dim matchBytes As Byte() = StringToByteArray(server)
        Dim Found = False
        Dim startposition

        Try
            Using fs = New FileStream(elf, FileMode.Open)
                Dim i As Integer = 0
                Dim readByte As Integer

                While (CSharpImpl.__Assign(readByte, fs.ReadByte())) <> -1
                    If matchBytes(i) = readByte Then
                        i += 1
                    Else
                        i = 0
                    End If

                    If i = matchBytes.Length Then
                        startposition = fs.Position - matchBytes.Length
                        MessageBox.Show("Found Old Server between " + Hex(startposition).ToString + " and " + Hex(fs.Position).ToString)
                        Found = True
                        Exit While
                    End If
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error Finding Location", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            If Found = True Then
                Dim writeBytes As Byte() = StringToByteArray(writeservehex)
                Using stream = New FileStream(elf, FileMode.Open, FileAccess.Write)
                    Dim bw As New BinaryWriter(stream)
                    stream.Position = startposition
                    bw.Write(writeBytes, 0, writeBytes.Length)
                    bw.Close()
                End Using
                My.Computer.FileSystem.CopyFile(elf, des_location + "\EBOOT.BIN", Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
                MessageBox.Show("Successfully Patched File & Installed File" + vbNewLine + "You will no longer need the IP/Host Switch, Start game and verify.")
            Else
                MessageBox.Show("Unable to find orginal server location to modify, Please try again")
            End If
        Catch ex As Exception
        End Try

    End Function

    Public Shared Function StringToByteArray(ByVal hex As String) As Byte()
        Dim NumberChars As Integer = hex.Length
        Dim bytes As Byte() = New Byte(NumberChars / 2 - 1) {}

        For i As Integer = 0 To NumberChars - 1 Step 2
            bytes(i / 2) = Convert.ToByte(hex.Substring(i, 2), 16)
        Next

        Return bytes
    End Function

    Private Class CSharpImpl
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class

End Class
