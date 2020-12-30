Imports Microsoft.VisualBasic

Public Class Keyboard
    Private id As Integer
    Public Sub RegisterHotKey(mods As KeyMod, vk As Integer) 'Use vk as the id
        _RegisterHotkey(_form.Handle, id, mods, vk)
        id += 1
    End Sub
    Public Sub UnRegisterHotKey(vk As Integer)
        _UnRegisterHotkey(_form.Handle, vk)
    End Sub

    Private _form As MsgForm
    Public Event KeyPressed As EventHandler(Of KeyPressedEventArgs)

    Public Sub New()
        id = 0
        _form = New MsgForm()
        AddHandler _form.KeyPressed, Sub(sender As Object, args As KeyPressedEventArgs)
                                         RaiseEvent KeyPressed(Me, args)
                                     End Sub
    End Sub
    <Flags>
    Enum KeyMod As UInteger
        None = 0
        Meta = &H1
        Control = &H2
        Shift = &H4
        Super = &H8
    End Enum

    Const WM_HOTKEY = &H312
    Public Class MsgForm
        Inherits Form
        Public Event KeyPressed As EventHandler(Of KeyPressedEventArgs)
        Protected Overrides Sub WndProc(ByRef m As Message)
            If m.Msg = WM_HOTKEY Then
                RaiseEvent KeyPressed(Me, New KeyPressedEventArgs(m.LParam))
            End If
            MyBase.WndProc(m)
        End Sub
    End Class

    Public Class KeyPressedEventArgs
        Inherits EventArgs
        Public ReadOnly Modifier As KeyMod
        Public ReadOnly Key As Keys
        Public ReadOnly LParam As IntPtr

        Friend Sub New(lparam As IntPtr)
            Key = DirectCast((CInt(lparam) >> 16) And &HFFFF, Keys)
            Modifier = DirectCast(CUInt(CInt(lparam) And &HFFFF), KeyMod)
            Me.LParam = lparam
        End Sub
    End Class
End Class
