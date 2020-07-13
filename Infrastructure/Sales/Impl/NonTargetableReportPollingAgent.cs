using System;
using System.Collections.Generic;
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
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Sales.Impl
{
    [DefaultImplementation]
    public class NonTargetableReportPollingAgent : INonTargetableReportPollingAgent
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly IBaseExportableReportHelper _baseExportableReportHelper;
        private readonly INonTargetableReportService _nonTargetableReportService;
        private readonly IStateRepository _stateRepository;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;

        private readonly string _sftpHost;
        private readonly string _sftpUserName;
        private readonly string _sftpPassword;
        private readonly bool _sendReportToSftp;
        private readonly string _sftpPathForNonTargetableReport;
        private readonly string _nonTargetableReportPath;
        private readonly DateTime _cutoffDate;
        private readonly long _accountId;
        private readonly long _runningDate;

        public NonTargetableReportPollingAgent(IEventRepository eventRepository, ILogManager logManager, ISettings settings, IBaseExportableReportHelper baseExportableReportHelper,
            INonTargetableReportService nonTargetableReportService, IStateRepository stateRepository,
            IUniqueItemRepository<CorporateAccount> corporateAccountRepository)
        {
            _logger = logManager.GetLogger("NonTargetableCustomerReport");
            _eventRepository = eventRepository;
            _settings = settings;
            _baseExportableReportHelper = baseExportableReportHelper;
            _nonTargetableReportService = nonTargetableReportService;
            _stateRepository = stateRepository;
            _corporateAccountRepository = corporateAccountRepository;

            _sftpHost = settings.WellmedSftpHost;
            _sftpUserName = settings.WellmedSftpUserName;
            _sftpPassword = settings.WellmedSftpPassword;
            _sendReportToSftp = settings.SendNonTargetableReportToSftp;
            _sftpPathForNonTargetableReport = settings.NonTargetableReportSftpPath;
            _nonTargetableReportPath = settings.NonTargetableReportPath;
            _cutoffDate = settings.NonTargetableCutoffDate;
            _accountId = settings.WellmedAccountId;
            _runningDate = settings.NonTargetableReportRunDate;
        }

        public void PollForNonTargetableCustomer()
        {
            try
            {
                var timeOfDay = DateTime.Now;
                _logger.Info("Time of day : " + timeOfDay.ToString("HH:mm:ss"));

                if (!_settings.IsDevEnvironment && _runningDate != DateTime.Today.Day)
                {
                    _logger.Info("Report is generated only in 1st week of the month");
                    return;
                }
                if (_accountId <= 0)
                {
                    _logger.Info("Account Id Not Provided");
                    return;
                }
                var account = _corporateAccountRepository.GetById(_accountId);
                if (account == null)
                {
                    _logger.Info("Account not exists");
                    return;
                }

                _logger.Info(string.Format("Generating Report for Non Target-able Report"));
                var lastMonthDate = (DateTime.Today).AddMonths(-1);

                var endDate = new DateTime(lastMonthDate.Year, lastMonthDate.Month, DateTime.DaysInMonth(lastMonthDate.Year, lastMonthDate.Month));
                var filter = new NonTargetableReportModelFilter
                {
                    AccountId = _accountId,
                    StartDate = new DateTime(DateTime.Today.Year, 1, 1),
                    EndDate = endDate
                };

                if (lastMonthDate.Year < DateTime.Today.Year)
                {
                    filter = new NonTargetableReportModelFilter
                    {
                        AccountId = _accountId,
                        StartDate = new DateTime(lastMonthDate.Year, 1, 1),
                        EndDate = endDate
                    };
                }

                var eventScheduleModelFilter = new EventScheduleListModelFilter
                {
                    AccountId = _accountId,
                    FromDate = filter.StartDate,
                    ToDate = filter.EndDate
                };
                var stateIds = _eventRepository.GetEventStateByAccountId(eventScheduleModelFilter);
                if (stateIds.IsNullOrEmpty())
                {
                    _logger.Info("No State found for Wellmed");
                }
                var states = _stateRepository.GetStates(stateIds);

                foreach (var state in states)
                {
                    try
                    {
                        _logger.Info("Generating Report for State: " + state.Name);

                        var dataGen = new ExportableDataGenerator<NonTargetableReportModel, NonTargetableReportModelFilter>(_nonTargetableReportService.GetCustomersForNonTargetableService, _logger);
                        filter.StateId = state.Id;
                        var model = dataGen.GetData(filter);

                        if (model != null && !model.Collection.IsNullOrEmpty())
                        {
                            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<NonTargetableReportModel>();

                            var path = string.Format(_nonTargetableReportPath, account.FolderName);
                            var reportfilePath = Path.Combine(path, state.Name);

                            DirectoryOperationsHelper.CreateDirectoryIfNotExist(reportfilePath);
                            reportfilePath = Path.Combine(reportfilePath, string.Format("WellMed_NonTargetable_{0}.csv", DateTime.Now.ToString("yyyyMM")));
                            _logger.Info("File path : " + reportfilePath);

                            DirectoryOperationsHelper.DeleteFileIfExist(reportfilePath);
                            _baseExportableReportHelper.GenerateCsv(reportfilePath, exporter, model.Collection);

                            if (_sendReportToSftp && DirectoryOperationsHelper.IsFileExist(reportfilePath))
                            {
                                _logger.Info("Starting to post non targetable report on sftp for StateId: " + state.Id + " State: " + state.Name);

                                var sftpResultExportDirectory = string.Format(_sftpPathForNonTargetableReport, state.Name);
                                var processFtp = new ProcessFtp(_logger, _sftpHost, _sftpUserName, _sftpPassword);
                                processFtp.UploadSingleFile(reportfilePath, sftpResultExportDirectory, "");

                                _logger.Info("Non targetable report posted on sftp for StateId: " + state.Id + " State: " + state.Name);
                            }
                            _logger.Info("Non targetable Report generation completed for StateId: " + state.Id + " State: " + state.Name);
                        }
                        else
                        {
                            _logger.Info("No customer found for StateId: " + state.Id + " State: " + state.Name);
                        }
                    }
                    catch (Exception exception)
                    {
                        _logger.Error("Error occurred during generation of report for StateId: " + state.Id);
                        _logger.Error("Message:  " + exception.Message);
                        _logger.Error("Stack Trace:  " + exception.StackTrace);
                    }
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
