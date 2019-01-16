using System.Collections.Generic;
using System;

using WebSearcher.Interfaces;

namespace WebSearcher.Ctrl
{
    public class Controller : IController
    {
        public IView View { get { return m_view; } set { m_view = value; UpdateViewProperties(); } }
        public IModel Model { get; set; }

        public bool IsRunning { get { return m_isRunning; } private set { m_isRunning = value; OnRunningChanged(); } }

        public event ControllerEvent OnRunning;
        public event ControllerEvent OnStopped;

        private IView m_view = null;
        private bool m_isRunning = false;
        private uint m_countThreads = 1;
        private string m_url = "";
        private string[] m_searchedWords;

        private Queue<ISession> m_sessionsInQueue = new Queue<ISession>();
        private List<ISession> m_sessionsInProgress = new List<ISession>();
        private bool m_needToCancel = false;

        public void Run()
        {
            if (View == null)
            {
                return;
            }

            m_countThreads = View.CountThreads;
            m_url = View.StartUrl;
            m_searchedWords = View.SearchedWords;
            m_needToCancel = false;

            try
            {
                Session startSession = new Session
                {
                    Url = new Uri(m_url),
                    SearchedWords = m_searchedWords,
                    Model = Model
                };

                Model?.AddToStory(startSession.Url.ToString());

                IsRunning = true;
                OnSessionAppears(startSession);
            }
            catch(Exception ex)
            {
                View.Error(ex.Message);
                IsRunning = false;
            }
        }

        public void Cancel()
        {
            m_needToCancel = true;

            m_sessionsInQueue.Clear();

            ISession[] needToCancel = m_sessionsInProgress.ToArray();

            foreach (ISession session in needToCancel)
            {
                session.Cancel();
            }
        }

        private void OnRunningChanged()
        {
            if (IsRunning)
            {
                OnRunning?.Invoke();
            }
            else
            {
                OnStopped?.Invoke();
            }
        }

        private void OnSessionEnd(ISession sender)
        {
            m_sessionsInProgress.Remove(sender);

            if (m_sessionsInProgress.Count == 0 && m_sessionsInQueue.Count == 0)
            {
                IsRunning = false;
                Model.SaveTo("Matches.csv");
                Model?.Reset();
            }

            ExecuteSessions();
        }

        private void OnSessionAppears(ISession session)
        {
            session.OnLog += View.Log;
            session.OnSesssionAppears += OnSessionAppears;

            m_sessionsInQueue.Enqueue(session);
            ExecuteSessions();
        }

        private void ExecuteSessions()
        {
            if (!IsRunning || m_needToCancel)
            {
                return;
            }

            while (m_sessionsInProgress.Count < m_countThreads && m_sessionsInQueue.Count >  0)
            {
                ISession session = m_sessionsInQueue.Dequeue();

                session.OnSessionEnd += OnSessionEnd;

                m_sessionsInProgress.Add(session);
                session.Run();
            }
        }

        private void UpdateViewProperties()
        {
            if (View != null)
            {
                View.MinCountThreads = 1;
                View.MaxCountThreads = 10;
            }
        }
    }
}
