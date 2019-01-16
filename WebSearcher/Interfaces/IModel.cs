using System.Collections.Generic;

namespace WebSearcher.Interfaces
{
    public interface IModel
    {
        bool AddToStory(string url);
        void WriteResult(string url, int result);
        void Reset();

        void SaveTo(string path);
    }
}
