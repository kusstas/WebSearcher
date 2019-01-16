using System.IO;
using System.Collections.Generic;
using System.Threading;

using WebSearcher.Interfaces;

namespace WebSearcher
{
    public class Model : IModel
    {
        private HashSet<string> m_story = new HashSet<string>();
        private Dictionary<string, int> m_result = new Dictionary<string, int>();

        private Mutex m_mutex = new Mutex();

        public bool AddToStory(string url)
        {
            m_mutex.WaitOne();
            bool result = m_story.Add(url);
            m_mutex.ReleaseMutex();
            return result;
        }

        public void WriteResult(string url, int result)
        {
            m_mutex.WaitOne();
            m_result.Add(url, result);
            m_mutex.ReleaseMutex();
        }

        public void SaveTo(string path)
        {
            
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (var item in m_result)
                {
                    if (item.Value > 0)
                    {
                        sw.WriteLine($"{item.Key},{item.Value}");
                    }
                }
            }
        }

        public void Reset()
        {
            m_story.Clear();
            m_result.Clear();
        }
    }
}
