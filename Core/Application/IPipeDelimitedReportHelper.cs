using System.Collections.Generic;
using System.Data;

namespace Falcon.App.Core.Application
{
    public interface IPipeDelimitedReportHelper
    {
        DataTable Read(string filePath, string seprator = "");

        void Write<T>(IEnumerable<T> modelData, string folderLocation, string filePath);

        string GetReportName(string fileType);

        DataTable ReadWithTextQualifier(string filePath);

        void WriteWithTextQualifier<T>(IEnumerable<T> modelData, string folderLocation, string filePath);
    }
}
