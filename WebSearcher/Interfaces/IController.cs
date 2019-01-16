using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSearcher.Interfaces
{
    public delegate void ControllerEvent();

    public interface IController
    {
        bool IsRunning { get; }

        event ControllerEvent OnRunning;
        event ControllerEvent OnStopped;

        void Run();
        void Cancel();
    }
}
