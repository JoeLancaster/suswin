Class Proc
    Private _running As Boolean
    Public ReadOnly pid As Integer
    Private hThreads As List(Of IntPtr)

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
        hThreads = New List(Of IntPtr)
        For Each pThread As ProcessThread In proc.Threads
            Dim hThread As IntPtr = KernelProc.OpenThread(KernelProc.ThreadAccess.SUSPEND_RESUME, False, CType(pThread.Id, UInteger))
            If hThread = IntPtr.Zero Then
                Continue For
            End If
            hThreads.Add(hThread)
            KernelProc.SuspendThread(hThread)
        Next
        Running = False
    End Sub
    Sub PResume()
        For Each hThread In hThreads
            If hThread = IntPtr.Zero Then
                Continue For
            End If
            KernelProc.ResumeThread(hThread)
            KernelProc.CloseHandle(hThread)
        Next
        Running = True
    End Sub

End Class
