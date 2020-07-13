using System.Collections.Generic;

namespace Falcon.App.Core.Application
{
    public interface IDicomExtractor
    {
        void ProcessFiles(string folderPath);
        string GetDirectoryContainingDicomFiles(string folderPath);
        IEnumerable<string> GetDirectoriesContainingDicomFiles(string folderPath);
    }
}