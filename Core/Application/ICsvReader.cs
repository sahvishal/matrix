using System.Collections.Generic;
using System.Data;

namespace Falcon.App.Core.Application
{
    public interface ICsvReader
    {
        string Delimiter { get; set; }
        DataTable Read(string filePath);
        void Write(string filePath, DataTable source);
        DataTable ReadWithTextQualifier(string filePath);
        IEnumerable<DataTable> ReadWithTextQualifierLargeData(string filePath);
        void RemoveEmptyColumnsFromCsv(string filePath);
        DataTable CsvToDataTable(string path, bool hasHeader, string seperator = ",");
        char GetFileDelimiter(string filePath);
        DataTable ConvertCsvToDataTable(string path, bool hasHeader, string seperator);
        void ConvertDataTableToCsv(DataTable dt, string filePath, string seperator);
    }
}