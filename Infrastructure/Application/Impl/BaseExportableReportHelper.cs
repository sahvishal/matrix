using System;
using System.Collections.Generic;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class BaseExportableReportHelper : IBaseExportableReportHelper
    {
        private readonly IBaseReportService _baseReportService;
        protected readonly MediaLocation ExportableMediaLocation;
        protected readonly ILogger Logger;
        public BaseExportableReportHelper(IMediaRepository mediaRepository, IBaseReportService baseReportService, ILogManager logManager)
        {
            _baseReportService = baseReportService;
            ExportableMediaLocation = mediaRepository.GetExportToCsvMediaFileLocation();
            Logger = logManager.GetLogger("Exportable Report Polling Agent");
        }

        public string WriteCsv<T>(string fileName, CSVExporter<T> exporter, IEnumerable<T> modelData, long userId, string filterCriteria = "")
        {
            var csvFilePath = ExportableMediaLocation.PhysicalPath + fileName;

            var isGenerated = GenerateCsv(csvFilePath, exporter, modelData, filterCriteria);

            if (!isGenerated) return string.Empty;

            return _baseReportService.DownloadZipFile(ExportableMediaLocation, fileName, userId, Logger);
        }

        public bool GenerateCsv<T>(string csvFilePath, CSVExporter<T> exporter, IEnumerable<T> modelData, string filterCriteria = "", bool skipHeader = false)
        {
            var csvStringBuilder = new StringBuilder();
            var sanitizer = new CSVSanitizer();

            if (!string.IsNullOrEmpty(filterCriteria))
                csvStringBuilder.Append(sanitizer.EscapeString(filterCriteria) + Environment.NewLine + Environment.NewLine);

            if (!skipHeader)
                csvStringBuilder.Append(exporter.Header + Environment.NewLine);

            foreach (string line in exporter.ExportObjects(modelData))
            {
                csvStringBuilder.Append(line + Environment.NewLine);
            }

            var request = new GenericReportRequest { Model = csvStringBuilder.ToString(), CsvFilePath = csvFilePath };
            var isGenerated = _baseReportService.GetResponse(request, skipHeader);
            return isGenerated;
        }

        protected string GetExportableFileName(string fileName)
        {
            return string.Format("{0}_{1}.csv", fileName, DateTime.Now.ToString("MMddyyyyHHmmss"));
        }
    }
}