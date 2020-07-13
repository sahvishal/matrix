using System.Collections.Generic;
using Falcon.App.Core.Application.Impl;

namespace Falcon.App.Core.Application
{
    public interface IBaseExportableReportHelper
    {
        string WriteCsv<T>(string fileName, CSVExporter<T> exporter, IEnumerable<T> modelData, long userId, string filterCriteria = "");

        bool GenerateCsv<T>(string csvFilePath, CSVExporter<T> exporter, IEnumerable<T> modelData, string filterCriteria = "", bool skipHeader = false);
    }
}