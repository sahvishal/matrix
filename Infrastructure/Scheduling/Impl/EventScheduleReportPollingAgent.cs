using System;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class EventScheduleReportPollingAgent : IEventScheduleReportPollingAgent
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISettings _settings;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEventReportingService _eventReportingService;
        private readonly IBaseExportableReportHelper _baseExportableReportHelper;
        private readonly IStateRepository _stateRepository;
        private readonly ILogger _logger;

        private readonly string _sftpHost;
        private readonly string _sftpUserName;
        private readonly string _sftpPassword;
        private readonly bool _sendReportToSftp;
        private readonly string _eventScheduleReportSftpPath;
        public EventScheduleReportPollingAgent(IEventRepository eventRepository, ISettings settings, ICorporateAccountRepository corporateAccountRepository,
            ILogManager logManager, IEventReportingService eventReportingService, IBaseExportableReportHelper baseExportableReportHelper, IStateRepository stateRepository)
        {
            _eventRepository = eventRepository;
            _settings = settings;
            _corporateAccountRepository = corporateAccountRepository;
            _eventReportingService = eventReportingService;
            _baseExportableReportHelper = baseExportableReportHelper;
            _stateRepository = stateRepository;
            _logger = logManager.GetLogger("EventScheduleReportPollingAgent");

            _sftpHost = settings.WellmedSftpHost;
            _sftpUserName = settings.WellmedSftpUserName;
            _sftpPassword = settings.WellmedSftpPassword;
            _sendReportToSftp = settings.SendReportToWellmedSftp;
            _eventScheduleReportSftpPath = settings.EventScheduleReportSftpPath;
        }

        public void PollForEventScheduleReort()
        {

            try
            {
                _logger.Info("starting Event Schedule Report");

                var accounts = _corporateAccountRepository.GetByIds(_settings.EventScheduleAccountIds);

                foreach (var account in accounts)
                {
                    _logger.Info("Event Schedule Report for Account Tag" + account.Tag);

                    if ((account.Id == _settings.ConnecticareAccountId || account.Id == _settings.ConnecticareMaAccountId) && DateTime.Today.DayOfWeek != _settings.ConnecticareEventScheduleExportDay)
                    {
                        _logger.Info("today is " + DateTime.Today.DayOfWeek + " while service is configured to run on " + _settings.ConnecticareEventScheduleExportDay);
                        _logger.Info("Please set " + (int)DateTime.Today.DayOfWeek + " to run Service today");
                        continue;
                    }

                    var fromDate = new DateTime(DateTime.Today.Year, 1, 1);
                    var toDate = new DateTime(DateTime.Today.Year, 12, 31);

                    var filter = new EventScheduleListModelFilter
                    {
                        AccountId = account.Id,
                        FromDate = fromDate,
                        ToDate = toDate,
                    };
                    var stateIds = _eventRepository.GetEventStateByAccountId(filter);

                    if (stateIds.IsNullOrEmpty())
                    {
                        _logger.Info("No State found for Account Tag " + account.Tag);
                        continue;
                    }

                    var states = _stateRepository.GetStates(stateIds);
                    foreach (var state in states)
                    {
                        try
                        {
                            _logger.Info("fetching records for State Name " + state.Name);
                            filter.StateId = state.Id;

                            var dataGen = new ExportableDataGenerator<EventScheduleModel, EventScheduleListModelFilter>(_eventReportingService.GetEventScheduleReport, _logger);
                            var model = dataGen.GetData(filter);

                            if (model != null && !model.Collection.IsNullOrEmpty())
                            {
                                _logger.Info("Writing Event Schedule Report");
                                var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<EventScheduleModel>();

                                _logger.Info("Record count" + model.Collection.Count());
                                var eventScheduleReportPath = Path.Combine(_settings.EventScheduleReportPath, DateTime.Today.Year.ToString());

                                DirectoryOperationsHelper.CreateDirectoryIfNotExist(eventScheduleReportPath);
                                var reportName = "EventScheduleReport_" + account.Tag + "_" + state.Name + "_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";

                                var reportfilePath = Path.Combine(eventScheduleReportPath, reportName);

                                if (account.Id == _settings.ConnecticareAccountId || account.Id == _settings.ConnecticareMaAccountId)
                                {
                                    reportfilePath = Path.Combine(_settings.HealthPlanDownloadPath, account.FolderName);
                                    reportfilePath = Path.Combine(reportfilePath, reportName);
                                }

                                DirectoryOperationsHelper.DeleteFileIfExist(reportfilePath);

                                _baseExportableReportHelper.GenerateCsv(reportfilePath, exporter, model.Collection);

                                _logger.Info("Generated report of Event Schedule Report for Account " + account.Tag + " state " + state.Name);
                                _logger.Info("Path: " + reportfilePath + " state " + state.Name);

                                if (_sendReportToSftp)
                                {
                                    _logger.Info("Sending file to sftp.");
                                    var eventScheduleReportSftpPath = string.Format(_eventScheduleReportSftpPath, fromDate.Year);
                                    var processFtp = new ProcessFtp(_logger, _sftpHost, _sftpUserName, _sftpPassword);

                                    processFtp.UploadSingleFile(reportfilePath, eventScheduleReportSftpPath, "");

                                    _logger.Info("File sent on sftp.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("some Error occurred while generating report of Event Schedule Report for Account " + account.Tag + " state " + state.Name);
                            _logger.Error("ex: " + ex.Message);
                            _logger.Error("stack Trace: " + ex.StackTrace);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("some Error occurred while generating report of Event Schedule Report ");
                _logger.Error("ex: " + ex.Message);
                _logger.Error("stack Trace: " + ex.StackTrace);
            }
        }

    }
}
