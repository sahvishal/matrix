using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using System;
using System.IO;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class DiabeticRetinopathyParserlogPollingAgent : IDiabeticRetinopathyParserlogPollingAgent
    {
        private readonly string _diabeticRetinopathyParserlogExportDownloadPath;
        private readonly int _numberOfDays;
        private readonly ILogger _logger;
        private readonly DayOfWeek _dayOfWeek;
        
        private readonly IBaseExportableReportHelper _baseExportableReportHelper;
        private readonly IDiabeticRetinopathyParserlogService _diabeticRetinopathyParserlogService;
        public DiabeticRetinopathyParserlogPollingAgent(ILogManager logManager, ISettings settings, 
            IBaseExportableReportHelper baseExportableReportHelper, IDiabeticRetinopathyParserlogService diabeticRetinopathyParserlogService)
        {
            _logger = logManager.GetLogger("Diabetic Retinopathy Parser Log Report");

            _numberOfDays = settings.DiabeticRetinopathyParserReportNumberOfDays;
            _dayOfWeek = settings.DiabeticRetinopathylogIntervalDay;
            _diabeticRetinopathyParserlogExportDownloadPath = settings.DiabeticRetinopathylogExportDownloadPath;
            
            _baseExportableReportHelper = baseExportableReportHelper;
            _diabeticRetinopathyParserlogService = diabeticRetinopathyParserlogService;
        }
        public void PollForDiabeticRetinopathyParserlog()
        {
            
            try
            {
                if (DateTime.Today.DayOfWeek != _dayOfWeek)
                {
                    _logger.Info(string.Format("todays day : {0}, export set to run on {1}", DateTime.Today.DayOfWeek, _dayOfWeek));
                    return;
                }

                var fromDate = DateTime.Today.AddDays(-1 * _numberOfDays);
                var toDate = DateTime.Today;

                _logger.Info("Diabetic Retinopathy Parser Log Report Started");
                var filter = new DiabeticRetinopathyParserlogListModelFilter
                {
                    DateFrom = fromDate,
                    DateTo = toDate
                };

                _logger.Info(string.Format("Generating report for filter diabetic retinopathy parser log : DateFrom: {0}, DateTo {1} ", filter.DateFrom, filter.DateTo));


                var dataGen = new ExportableDataGenerator<DiabeticRetinopathyParserlogViewModel, DiabeticRetinopathyParserlogListModelFilter>(_diabeticRetinopathyParserlogService.GetDiabeticRetinopathyParserlog, _logger);
                var model = dataGen.GetData(filter);

                if (model != null)
                {
                    var fileName = GetCsvFileName(filter);

                    var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<DiabeticRetinopathyParserlogViewModel>();

                    if (model.Collection != null && model.Collection.Any())
                    {
                        _baseExportableReportHelper.GenerateCsv(fileName, exporter, model.Collection);
                    }
                }
                _logger.Info(string.Format("Report Generation Completed. "));

            }
            catch (Exception ex)
            {
                _logger.Error("Some Error Exception Occured while Generating Report");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("StackTrace: " + ex.StackTrace);

                _logger.Error(string.Format("Report Generation Completed  "));
            }

        }
        private string GetCsvFileName(DiabeticRetinopathyParserlogListModelFilter filter)
        {
            var diabeticRetinopathyParserlogExportPath = string.Format(_diabeticRetinopathyParserlogExportDownloadPath, filter.DateFrom.Value.Year);

            if (!Directory.Exists(diabeticRetinopathyParserlogExportPath))
                Directory.CreateDirectory(diabeticRetinopathyParserlogExportPath);

            var csvFileName = string.Format("DiabeticRetinopathyParserlog_{0}_{1}.csv", filter.DateFrom.Value.ToString("MMddyyyy"), filter.DateTo.Value.ToString("MMddyyyy"));

            var fileName = diabeticRetinopathyParserlogExportPath + "\\" + csvFileName;

            if (File.Exists(fileName))
                File.Delete(fileName);

            return fileName;
        }
    }
}
