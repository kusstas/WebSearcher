using System;
using System.Net;
using System.Text.RegularExpressions;

using WebSearcher.Interfaces;

namespace WebSearcher.Ctrl
{
    public class Session : ISession
    {
        public IModel Model { get; set; }

        public SessionStatus Status { get { return m_status; } private set { m_status = value; OnStatusChanged(); } }

        public string Error { get; private set; }
       
        public Uri Url { get; set; }
        public string[] SearchedWords { get; set; }

        public int Result { get; private set; }

        public event SessionEvent OnSessionRun;
        public event SessionEvent OnSessionEnd;
        public event SessionAppearsEvent OnSesssionAppears;
        public event SessionLog OnLog;

        private SessionStatus m_status = SessionStatus.WaitingForStart;
        private WebClient m_webClient = new WebClient();
        
        public Session()
        {
            m_webClient.DownloadStringCompleted += OnWebClientCompeted;
        }

        public void Run()
        {
            if (SearchedWords != null && SearchedWords.Length == 0)
            {
                throw new Exception("List of searched words is empty");
            }

            Status = SessionStatus.InProgress;

            OnLog?.Invoke("Download: " + Url.ToString());

            m_webClient.DownloadStringAsync(Url);
        }

        public void Cancel()
        {
            Status = SessionStatus.Canceled;
            OnLog?.Invoke("Cancel download: " + Url.ToString());
            m_webClient.CancelAsync();
        }

        private void OnWebClientCompeted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            string result = "";
            try
            {
                result = e.Result;
            }
            catch
            {
                OnLog?.Invoke("Cannot download page: " + Url);
            }

            if (result.Length == 0)
            {
                Status = SessionStatus.Failed;
                return;
            }

            FindNewSessions(result);
            FindWords(result);

            Status = SessionStatus.Complete;
        }

        private void FindNewSessions(string text)
        {
            OnLog?.Invoke("Page downloaded: " + Url.ToString());

            Regex regex = new Regex("(\\/\\S*)?(((https|http|ftp)://)((\\w|-)+)(([.]|[/])((\\w|-)+))+)(\\/\\S*)?");

            foreach (Match match in regex.Matches(text))
            {
                try
                {
                    Uri url = new Uri(match.Value);

                    if (Model != null && !Model.AddToStory(url.ToString()))
                    {
                        continue;
                    }

                    Session session = new Session()
                    {
                        Url = url,
                        SearchedWords = SearchedWords,
                        Model = Model
                    };
                    OnSesssionAppears?.Invoke(session);
                }
                catch (Exception ex)
                {
                    OnLog?.Invoke(ex.Message + ": " + match.Value);
                }
            }
        }

        private void FindWords(string text)
        {
            Regex regex = new Regex(string.Join("|", SearchedWords), RegexOptions.IgnoreCase);
            Result = regex.Matches(text).Count;
            OnLog?.Invoke("Finded matches in: " + Url.ToString() + " - " + Result.ToString());

            Model?.WriteResult(Url.ToString(), Result);
        }

        private void OnStatusChanged()
        {
            switch (Status)
            {
                case SessionStatus.WaitingForStart:
                    break;
                case SessionStatus.InProgress:
                    OnSessionRun?.Invoke(this);
                    break;
                case SessionStatus.Complete:
                case SessionStatus.Canceled:
                case SessionStatus.Failed:
                    OnSessionEnd?.Invoke(this);
                    break;
            }
        }
    }
}
