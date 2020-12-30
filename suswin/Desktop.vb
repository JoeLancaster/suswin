Imports System.Runtime.InteropServices

Public Module Desktop

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True, EntryPoint:="RegisterHotKey")>
    Public Function _RegisterHotkey(hWnd As IntPtr, id As Integer, mods As UInteger, vk As Integer) As Boolean

    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True, EntryPoint:="UnRegisterHotKey")>
    Public Function _UnRegisterHotkey(hWnd As IntPtr, id As Integer) As Integer

    End Function

    <DllImport("USER32.DLL", EntryPoint:="GetWindowTextW", SetLastError:=True,
    CharSet:=CharSet.Unicode, ExactSpelling:=True,
    CallingConvention:=CallingConvention.StdCall)>
    Public Function GetActiveWindowText(ByVal hWnd As System.IntPtr,
                                            ByVal lpString As System.Text.StringBuilder,
                                            ByVal cch As Integer) As Integer
    End Function


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
End Module
