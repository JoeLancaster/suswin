Imports System.Runtime.InteropServices

Module KernelProc

    <Flags>
    Public Enum ThreadAccess As Integer
        TERMINATE = &H1
        SUSPEND_RESUME = &H2
        GET_CONTEXT = &H8
        SET_CONTEXT = &H10
        SET_INFORMATION = &H20
        QUERY_INFORMATION = &H40
        SET_THREAD_TOKEN = &H80
        IMPERSONATE = &H100
        DIRECT_IMPERSONATION = &H200
    End Enum
    <DllImport("kernel32.dll", EntryPoint:="OpenThread", SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Function OpenThread(dwDesiredAccess As ThreadAccess, bInheritHandle As Boolean, dwThreadId As UInteger) As IntPtr

    End Function
    <DllImport("kernel32.dll", EntryPoint:="SuspendThread", SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Function SuspendThread(hThread As IntPtr) As UInteger

    End Function
    <DllImport("kernel32.dll", EntryPoint:="ResumeThread", SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Function ResumeThread(hThread As IntPtr) As Integer

    End Function
    <DllImport("kernel32.dll", EntryPoint:="ResumeThread", SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Function CloseHandle(handle As IntPtr) As Boolean

    End Function
    <DllImport("kernel32.dll", EntryPoint:="GetModuleHandle", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Function GetModuleHandle(ByVal lpModuleName As String) As IntPtr
    End Function
End Module
