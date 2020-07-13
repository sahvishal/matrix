using System;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class DailyVolumeReportPollingAgent : IDailyVolumeReportPollingAgent
    {
        private readonly IEventReportingService _eventReportingService;
        private readonly ISettings _settings;
        private readonly IBaseExportableReportHelper _baseExportableReportHelper;
        private readonly ILogger _logger;

        public DailyVolumeReportPollingAgent(IEventReportingService eventReportingService, ILogManager logManager, ISettings settings, IBaseExportableReportHelper baseExportableReportHelper)
        {
            _eventReportingService = eventReportingService;
            _settings = settings;
            _baseExportableReportHelper = baseExportableReportHelper;
            _logger = logManager.GetLogger("DailyVolumeReportPollingAgent");
        }

        public void PollForDailyVolumeReport()
        {
            try
            {
                _logger.Info("Setting filter to pull data for Daily Volume Report");
                var filter = new DailyVolumeListModelFilter
                {
                    FromDate = new DateTime(DateTime.Today.Year, 1, 1),
                    ToDate = new DateTime(DateTime.Today.Year, 12, 31)
                };

                _logger.Info("fetching Daily Volume Report");
                var dataGen = new ExportableDataGenerator<DailyVolumeModel, DailyVolumeListModelFilter>(_eventReportingService.GetDailyVolumeReport, _logger);
                var model = dataGen.GetData(filter);

                if (model != null && !model.Collection.IsNullOrEmpty())
                {
                    _logger.Info("Writing Daily volume Report");
                    var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<DailyVolumeModel>();

                    _logger.Info("Record count" + model.Collection.Count());
                    var dailyVolumeReportPath = Path.Combine(_settings.DailyVolumeReportPath, DateTime.Today.Year.ToString());

                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(dailyVolumeReportPath);
                    var reportName = "HF_DailyVolume_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                    var reportfilePath = Path.Combine(dailyVolumeReportPath, reportName);

                    DirectoryOperationsHelper.DeleteFileIfExist(reportfilePath);

                    _baseExportableReportHelper.GenerateCsv(reportfilePath, exporter, model.Collection);

                    _logger.Info("Daily Volume Report File Posted " + reportfilePath);
                }
            }
            catch (Exception exception)
            {
                _logger.Error("Some error occurred ");
                _logger.Error("Message:  " + exception.Message);
                _logger.Error("Stack Trace:  " + exception.StackTrace);
            }
        }
    }
}
