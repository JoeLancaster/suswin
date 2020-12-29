Imports System
Imports System.Runtime.InteropServices
Imports System.Diagnostics

Module kProc

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
End Module

Class Proc
    Private _running As Boolean
    ReadOnly pid As Integer
    Public Property Running() As Boolean
        Get
            Return _running
        End Get
        Private Set(value As Boolean)
            _running = value
        End Set
    End Property

    Public proc As Process
    Public Sub New(pid As Integer)
        Me.pid = pid
        proc = Process.GetProcessById(pid)
    End Sub
    Sub Suspend()
        For Each pThread As ProcessThread In proc.Threads
            Dim hThread As IntPtr = kProc.OpenThread(ThreadAccess.SUSPEND_RESUME, False, CType(pThread.Id, UInteger))
            If hThread = IntPtr.Zero Then
                Continue For
            End If
            Console.WriteLine(pThread.Id)
            Console.WriteLine(kProc.SuspendThread(hThread))
            'Console.WriteLine(kProc.CloseHandle(hThread))
        Next
        running = False
    End Sub
    Sub PResume()
        For Each pThread As ProcessThread In proc.Threads
            Dim hThread As IntPtr = kProc.OpenThread(ThreadAccess.SUSPEND_RESUME, False, CType(pThread.Id, UInteger))
            If hThread = IntPtr.Zero Then
                Continue For
            End If
            Console.WriteLine(kProc.ResumeThread(hThread))
        Next
        running = True
    End Sub

End Class

Module Program
    <DllImport("USER32.DLL", EntryPoint:="GetForegroundWindow", SetLastError:=True,
    CharSet:=CharSet.Unicode, ExactSpelling:=True,
    CallingConvention:=CallingConvention.StdCall)>
    Public Function GetActiveWindowHandle() As IntPtr

    End Function
    <DllImport("USER32.DLL", EntryPoint:="GetWindowTextW", SetLastError:=True,
    CharSet:=CharSet.Unicode, ExactSpelling:=True,
    CallingConvention:=CallingConvention.StdCall)>
    Public Function GetActiveWindowText(ByVal hWnd As System.IntPtr,
                                            ByVal lpString As System.Text.StringBuilder,
                                            ByVal cch As Integer) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Function GetWindowThreadProcessId(ByVal hWnd As IntPtr,
    ByRef lpdwProcessId As Integer) As Integer
    End Function


    Sub Main(args As String())
        Dim x As Proc = New Proc(12960)
        Console.WriteLine(x.proc.ProcessName)
        x.PResume()
        'Dim pid As Integer = 0
        'Dim hWnd As IntPtr = GetActiveWindowHandle()
        'GetWindowThreadProcessId(hWnd, pid)
        'Dim p As Process = Process.GetProcessById(pid)
        'Console.ReadKey()
        'Console.WriteLine(p.ToString())
    End Sub
End Module
