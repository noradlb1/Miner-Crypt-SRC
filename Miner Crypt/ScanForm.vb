Imports System.Net
Imports System.Web.Script.Serialization

Public Class ScanForm
    Dim fileLoc As String = Environ("appdata") & "\" & IO.Path.GetFileName(MinerCrypt.SaveLoc)

    Public Sub reFUDme_ScanText(token As String, file As String)
        Try
            Dim wc As New WebClient()
            AddHandler wc.UploadFileCompleted, AddressOf getTextResults
            wc.UploadFileAsync(New Uri("http://www.refud.me/api.php?auth_token=" & token & "&type=text"), "POST", file)
            While wc.IsBusy
                Application.DoEvents()
            End While

            If resulttext.Text.Contains("0/35") Then
                MessageBox.Show("1 Crypt spent!")

                Seal.SpendPoints(1)

                MinerCrypt.RemainNoLabel.Text = Seal.Points

                System.IO.File.Move(fileLoc, MinerCrypt.SaveLoc)

                MessageBox.Show("File Built!")

            Else
                MessageBox.Show("File not FUD, crypt not spent.")

                System.IO.File.Move(fileLoc, MinerCrypt.SaveLoc)

                MessageBox.Show("File Built!")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub getTextResults(sender As Object, e As UploadFileCompletedEventArgs)
        Dim response As String = System.Text.Encoding.UTF8.GetString(e.Result)
        Dim dict As Dictionary(Of String, String) = New JavaScriptSerializer().Deserialize(Of Dictionary(Of String, String))(response)
        Dim result As String = dict("result")
        Dim url As String = dict("url")
        dict.Remove("result")
        dict.Remove("url")
        For Each antiVirus As KeyValuePair(Of String, String) In dict
            Dim name As String = antiVirus.Key
            Dim detection As String = antiVirus.Value
            Dim antiV As ListViewItem = ListView1.Items.Add(name)
            antiV.SubItems.Add(detection)
        Next
        resulttext.Text = result & "/35"
        urltext.Text = url
    End Sub

    Private Sub ScanForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.BringToFront()

        MessageBox.Show("Scanning, please wait!")

        If (System.IO.File.Exists(fileLoc)) Then
            reFUDme_ScanText("123456", fileLoc)
        End If

    End Sub

    Private Sub FlatClose1_Click(sender As Object, e As EventArgs) Handles FlatClose1.Click
        Me.Close()
    End Sub
End Class