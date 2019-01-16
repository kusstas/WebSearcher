using System.Collections.Generic;

namespace WebSearcher.Ctrl
{
    public delegate void SessionEvent(ISession sender);
    public delegate void SessionAppearsEvent(ISession session);
    public delegate void SessionLog(string message);

    public enum SessionStatus
    {
        WaitingForStart,
        InProgress,
        Complete,
        Canceled,
        Failed
    }

    public interface ISession
    {
        event SessionEvent OnSessionRun;
        event SessionEvent OnSessionEnd;
        event SessionAppearsEvent OnSesssionAppears;
        event SessionLog OnLog;

        SessionStatus Status { get; }
        string Error { get; }
        int Result { get; }

        void Run();
        void Cancel();
    }
}
