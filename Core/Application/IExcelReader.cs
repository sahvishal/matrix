using System.Data;

namespace Falcon.App.Core.Application
{
    public interface IExcelReader
    {
        DataSet ReadfromExcelintoDataset(string filePath, bool hasHeaders = true);
        void WriteToExcel(string filePath, DataSet source);
    }
}