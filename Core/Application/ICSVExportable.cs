using System.Collections.Generic;

namespace Falcon.App.Core.Application
{
    public interface ICSVExportable<T>
    {
        string Header { get; set; }

        string ExportToCSV(List<T> itemsToExport);
        string GetSingleLine(T item);
    }
}