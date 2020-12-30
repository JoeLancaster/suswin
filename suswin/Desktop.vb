Imports System.Runtime.InteropServices

Public Module Desktop
    Enum ShowWindowCommands As Integer
        ''' <summary>
        ''' Hides the window and activates another window.
        ''' </summary>
        Hide = 0
        ''' <summary>
        ''' Activates and displays a window. If the window is minimized or
        ''' maximized, the system restores it to its original size and position.
        ''' An application should specify this flag when displaying the window
        ''' for the first time.
        ''' </summary>
        Normal = 1
        ''' <summary>
        ''' Activates the window and displays it as a minimized window.
        ''' </summary>
        ShowMinimized = 2
        ''' <summary>
        ''' Maximizes the specified window.
        ''' </summary>
        Maximize = 3
        ' is this the right value?
        ''' <summary>
        ''' Activates the window and displays it as a maximized window.
        ''' </summary>      
        ShowMaximized = 3
        ''' <summary>
        ''' Displays a window in its most recent size and position. This value
        ''' is similar to <see cref="Win32.ShowWindowCommands.Normal"/>, except
        ''' the window is not actived.
        ''' </summary>
        ShowNoActivate = 4
        ''' <summary>
        ''' Activates the window and displays it in its current size and position.
        ''' </summary>
        Show = 5
        ''' <summary>
        ''' Minimizes the specified window and activates the next top-level
        ''' window in the Z order.
        ''' </summary>
        Minimize = 6
        ''' <summary>
        ''' Displays the window as a minimized window. This value is similar to
        ''' <see cref="Win32.ShowWindowCommands.ShowMinimized"/>, except the
        ''' window is not activated.
        ''' </summary>
        ShowMinNoActive = 7
        ''' <summary>
        ''' Displays the window in its current size and position. This value is
        ''' similar to <see cref="Win32.ShowWindowCommands.Show"/>, except the
        ''' window is not activated.
        ''' </summary>
        ShowNA = 8
        ''' <summary>
        ''' Activates and displays the window. If the window is minimized or
        ''' maximized, the system restores it to its original size and position.
        ''' An application should specify this flag when restoring a minimized window.
        ''' </summary>
        Restore = 9
        ''' <summary>
        ''' Sets the show state based on the SW_* value specified in the
        ''' STARTUPINFO structure passed to the CreateProcess function by the
        ''' program that started the application.
        ''' </summary>
        ShowDefault = 10
        ''' <summary>
        '''  <b>Windows 2000/XP:</b> Minimizes a window, even if the thread
        ''' that owns the window is not responding. This flag should only be
        ''' used when minimizing windows from a different thread.
        ''' </summary>
        ForceMinimize = 11
    End Enum
    <DllImport("User32", SetLastError:=True)>
    Public Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
    End Function
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
    <DllImport("user32.dll", EntryPoint:="ShowWindow", SetLastError:=True, CharSet:=CharSet.Auto, ExactSpelling:=True)>
    Public Function ShowWindow(hWnd As IntPtr, cmd As Integer) As Boolean

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
