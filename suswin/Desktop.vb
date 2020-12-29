Imports System.Runtime.InteropServices

Public Module Desktop
    Public Delegate Function HookProc(ByVal code As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    Enum HookType As Integer
        WH_JOURNALRECORD = 0
        WH_JOURNALPLAYBACK = 1
        WH_KEYBOARD = 2
        WH_GETMESSAGE = 3
        WH_CALLWNDPROC = 4
        WH_CBT = 5
        WH_SYSMSGFILTER = 6
        WH_MOUSE = 7
        WH_HARDWARE = 8
        WH_DEBUG = 9
        WH_SHELL = 10
        WH_FOREGROUNDIDLE = 11
        WH_CALLWNDPROCRET = 12
        WH_KEYBOARD_LL = 13
        WH_MOUSE_LL = 14
    End Enum

    Delegate Sub WinEventDelegate(
        ByVal hWinEventHook As IntPtr,
        ByVal eventType As UInteger,
        ByVal hwnd As IntPtr,
        ByVal idObject As Integer,
        ByVal idChild As Integer,
        ByVal dwEventThread As UInteger,
        ByVal dwmsEventTime As UInteger
    )

    <DllImport("user32.dll", EntryPoint:="GetForegroundWindow", SetLastError:=True,
CharSet:=CharSet.Unicode, ExactSpelling:=True,
CallingConvention:=CallingConvention.StdCall)>
    Public Function GetActiveWindowHandle() As IntPtr

    End Function
    <DllImport("user32.dll", EntryPoint:="GetWindowTextW", SetLastError:=True,
    CharSet:=CharSet.Unicode, ExactSpelling:=True,
    CallingConvention:=CallingConvention.StdCall)>
    Public Function GetWindowText(ByVal hWnd As System.IntPtr,
                                            ByVal lpString As System.Text.StringBuilder,
                                            ByVal cch As Integer) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Function GetWindowThreadProcessId(ByVal hWnd As IntPtr,
    ByRef lpdwProcessId As Integer) As Integer
    End Function
    <DllImport("user32.dll", EntryPoint:="SetWinEventHook")>
    Public Function SetWinEventHook(
        ByVal eventMin As UInteger,
        ByVal eventMax As UInteger,
        ByVal hmodWinEventProc As IntPtr,
        ByVal lpfnWinEventProc As WinEventDelegate,
        ByVal idProcess As UInteger,
        ByVal idThread As UInteger,
        ByVal dwFlags As UInteger
    ) As IntPtr
    End Function
    <DllImport("user32.dll", SetLastError:=True)>
    Public Function SetWindowsHookEx(ByVal hookType As HookType, ByVal lpfn As HookProc, ByVal hMod As IntPtr, ByVal dwThreadId As UInteger) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Public Function CallNextHookEx(ByVal hhk As IntPtr, ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    End Function
End Module
