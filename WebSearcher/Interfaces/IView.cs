using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSearcher.Interfaces
{
    public interface IView
    {
        string StartUrl { get; }
        string[] SearchedWords { get; }

        uint CountThreads { get; }

        uint MinCountThreads { get; set; }
        uint MaxCountThreads { get; set; }

        void Error(string message);
        void Log(string message);
        void ClearLog();
    }
}
