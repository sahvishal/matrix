using System;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class EventListGmsPollingAgent : IEventListGmsPollingAgent
    {
        private readonly ISettings _settings;
        private readonly IBaseExportableReportHelper _baseExportableReportHelper;
        private readonly IEventReportingService _eventReportingService;
        private readonly ILogger _logger;

        public EventListGmsPollingAgent(ISettings settings, ILogManager logManager, IBaseExportableReportHelper baseExportableReportHelper, IEventReportingService eventReportingService)
        {
            _settings = settings;
            _baseExportableReportHelper = baseExportableReportHelper;
            _eventReportingService = eventReportingService;
            _logger = logManager.GetLogger("EventListGmsReport");
        }

        public void PollForEventList()
        {
            var timeOfDay = DateTime.Now;
            _logger.Info("Time of day : " + timeOfDay.ToString("HH:mm:ss"));

            var startTime = new TimeSpan(_settings.GmsEventStartTime, 0, 0);
            var endTime = new TimeSpan(_settings.GmsEventEndTime, 0, 0);

            if (timeOfDay.TimeOfDay < startTime || timeOfDay.TimeOfDay > endTime)
            {
                _logger.Info(string.Format("Report is generated only between {0} and {1}.", startTime.ToString(), endTime.ToString()));
                return;
            }

            _logger.Info(string.Format("Generating Event List for GMS."));
            try
            {
                var filter = new EventListGmsModelFilter
                {
                    FromDate = DateTime.Today,
                    HealthPlanIds = _settings.GmsAccountIds
                };

                var dataGen = new ExportableDataGenerator<EventListGmsModel, EventListGmsModelFilter>(_eventReportingService.GetEventListForGmsReport, _logger);
                var model = dataGen.GetData(filter);

                if (model != null && !model.Collection.IsNullOrEmpty())
                {
                    var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<EventListGmsModel>();

                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(_settings.EventListGmsReportPath);

                    var reportfilePath = Path.Combine(_settings.EventListGmsReportPath, string.Format("EventList_{0}.csv", DateTime.Now.ToString("yyyyMMdd_HH")));
                    _logger.Info("File path : " + reportfilePath);

                    DirectoryOperationsHelper.DeleteFileIfExist(reportfilePath);

                    _baseExportableReportHelper.GenerateCsv(reportfilePath, exporter, model.Collection);

                    if (_settings.SendReportToGmsSftp)
                    {
                        _logger.Info("Sending Event List to GMS sftp.");
                        var sftpFolderReportDirectory = _settings.GmsSftpPath;
                        var processFtp = new ProcessFtp(_logger, _settings.GmsSftpHost, _settings.GmsSftpUserName, _settings.GmsSftpPassword);

                        processFtp.UploadSingleFile(reportfilePath, sftpFolderReportDirectory, "");
                        _logger.Info("Sent Event List to GMS sftp.");
                    }
                    else
                    {
                        _logger.Info("Setting to send Event list to sftp is OFF.");
                    }

                    _logger.Info(string.Format("Event List generation for GMS completed."));
                }
                else
                {
                    _logger.Info("No future events found.");
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