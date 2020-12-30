Imports System
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.Windows.Forms

Module Program
    Private Sub Minimize(hWnd As IntPtr)
        Const SC_MINIMIZE = &HF020
        Const WM_SYSCOMMAND = &H112
        SendMessage(hWnd, WM_SYSCOMMAND, SC_MINIMIZE, 0)
    End Sub

    Dim processBinds As New Dictionary(Of IntPtr, Proc)
    Sub HandleKey(sender As Object, e As Keyboard.KeyPressedEventArgs)
        Dim p As Proc
        If processBinds.TryGetValue(e.LParam, p) Then
            p.PResume()
            processBinds.Remove(e.LParam)
        Else
            Dim pid As Integer = 0
            Dim hWnd As IntPtr = GetActiveWindowHandle()
            Minimize(hWnd)
            GetWindowThreadProcessId(hWnd, pid)
            p = New Proc(pid)
            processBinds.Add(e.LParam, p)
            p.Suspend()
        End If
    End Sub

    Sub Main(args As String())
        Dim keyb As Keyboard = New Keyboard()
        AddHandler keyb.KeyPressed, AddressOf HandleKey
        For k = &H70 To &H7B 'Ctrl-F1 to Ctrl-F12
            keyb.RegisterHotKey(Keyboard.KeyMod.Control, k)
        Next
        Application.Run()
    End Sub
End Module
