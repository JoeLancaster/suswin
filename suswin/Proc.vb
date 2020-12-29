Class Proc
    Private _running As Boolean
    Public ReadOnly pid As Integer
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
    Public Function Equals(p As Proc) As Boolean
        If p Is Nothing Then
            Return False
        End If
        Return p.pid = Me.pid
    End Function
    Public Overrides Function GetHashCode() As Integer
        Return pid.GetHashCode()
    End Function
    Sub Suspend()
        For Each pThread As ProcessThread In proc.Threads
            Dim hThread As IntPtr = KernelProc.OpenThread(ThreadAccess.SUSPEND_RESUME, False, CType(pThread.Id, UInteger))
            If hThread = IntPtr.Zero Then
                Continue For
            End If
            Console.WriteLine(pThread.Id)
            Console.WriteLine(KernelProc.SuspendThread(hThread))
            'Console.WriteLine(kProc.CloseHandle(hThread))
        Next
        running = False
    End Sub
    Sub PResume()
        For Each pThread As ProcessThread In proc.Threads
            Dim hThread As IntPtr = KernelProc.OpenThread(ThreadAccess.SUSPEND_RESUME, False, CType(pThread.Id, UInteger))
            If hThread = IntPtr.Zero Then
                Continue For
            End If
            Debug.WriteLine(KernelProc.ResumeThread(hThread))
        Next
        running = True
    End Sub

End Class
