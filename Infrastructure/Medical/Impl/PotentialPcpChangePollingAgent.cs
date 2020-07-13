using System;
using System.Collections.Generic;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PotentialPcpChangePollingAgent : IPotentialPcpChangePollingAgent
    {
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly IBaseExportableReportHelper _baseExportableReportHelper;
        private readonly IPotentialPcpChangeReportService _potentialPcpChangeReportService;
        private readonly IEventRepository _eventRepository;
        private readonly IStateRepository _stateRepository;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ICustomSettingManager _customSettingManager;

        private readonly string _sftpHost;
        private readonly string _sftpUserName;
        private readonly string _sftpPassword;
        private readonly bool _sendReportToSftp;
        private readonly string _sftpPathForPcpChangeReport;
        private readonly long _accountId;
        private readonly long _runningDate;
        private readonly string _pcpChangeReportPath;
        private readonly string _pcpCustomSetting;
        private readonly DateTime _cutoffDate;

        public PotentialPcpChangePollingAgent(ISettings settings, ILogManager logManager, IBaseExportableReportHelper baseExportableReportHelper, IEventRepository eventRepository,
                                              IPotentialPcpChangeReportService potentialPcpChangeReportService, IStateRepository stateRepository,
                                              IUniqueItemRepository<CorporateAccount> corporateAccountRepository, ICustomSettingManager customSettingManager)
        {
            _settings = settings;
            _logger = logManager.GetLogger("PotentialPcpChangePollingAgent");
            _baseExportableReportHelper = baseExportableReportHelper;
            _potentialPcpChangeReportService = potentialPcpChangeReportService;
            _eventRepository = eventRepository;
            _stateRepository = stateRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _customSettingManager = customSettingManager;

            _pcpChangeReportPath = _settings.PcpChangeReportPath;
            _runningDate = _settings.PcpChangeReportRunDate;
            _sftpPathForPcpChangeReport = settings.PcpChangeReportSftpPath;
            _sendReportToSftp = settings.SendPcpChangeReportToSftp;

            _sftpHost = settings.WellmedSftpHost;
            _sftpUserName = settings.WellmedSftpUserName;
            _sftpPassword = settings.WellmedSftpPassword;
            _accountId = settings.WellmedAccountId;

            _pcpCustomSetting = settings.PcpChangeReportSettings;
            _cutoffDate = settings.PcpChangeReportCutoffDate;
        }

        public void PollForPotentialPcpChange()
        {
            try
            {
                var timeOfDay = DateTime.Now;
                _logger.Info("Time of day : " + timeOfDay.ToString("HH:mm:ss"));

                if (!_settings.IsDevEnvironment && _runningDate != DateTime.Today.Day)
                {
                    _logger.Info("Report is generated only in 1st week of the month , currently selected run Date is " + _settings.PcpChangeReportRunDate);
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

                var customSetting = _customSettingManager.Deserialize(_pcpCustomSetting);
                List<DateTime> toDates = null;
                if (customSetting.LastTransactionDate != null)
                {
                    toDates = GetToDates(customSetting.LastTransactionDate.Value.AddMonths(1));             //to pick correct records
                    _logger.Info("Generating Potential Pcp change Report for Month " + customSetting.LastTransactionDate.Value.AddMonths(1));
                }
                else
                {
                    _logger.Info("Generating report for first time as LastTransactionDate is missing from custom setting XML");
                    toDates = GetToDates(_cutoffDate);
                }

                foreach (var todate in toDates)
                {
                    var filter = new PotentialPcpChangeReportModelFilter
                    {
                        AccountId = _accountId,
                        StartDate = new DateTime(todate.Year, todate.Month, 1),
                        EndDate = todate
                    };
                    _logger.Info(string.Format("Generating report for date: {0} to {1}", filter.StartDate, filter.EndDate));
                    var eventScheduleModelFilter = new EventScheduleListModelFilter
                    {
                        AccountId = _accountId,
                        FromDate = filter.StartDate,
                        ToDate = filter.EndDate
                    };
                    GenerateReport(eventScheduleModelFilter, filter, account);

                    _logger.Info(string.Format("Completed Generating Report for Potential Pcp Change"));
                }
            }
            catch (Exception exception)
            {
                _logger.Error("Some error occurred ");
                _logger.Error("Message:  " + exception.Message);
                _logger.Error("Stack Trace:  " + exception.StackTrace);
            }
        }

        private void GenerateReport(EventScheduleListModelFilter eventScheduleModelFilter, PotentialPcpChangeReportModelFilter filter, CorporateAccount account)
        {
            var stateIds = (IReadOnlyCollection<long>)_eventRepository.GetEventStateByAccountId(eventScheduleModelFilter);
            if (stateIds.IsNullOrEmpty())
            {
                _logger.Info("No State found for Wellmed");             //Do not return from here as we are updating last transaction date at last
            }

            var states = _stateRepository.GetStates(stateIds);
            foreach (var state in states)
            {
                try
                {
                    _logger.Info("Generating Report for State: " + state.Name);

                    var dataGen = new ExportableDataGenerator<PotentialPcpChangeReportViewModel, PotentialPcpChangeReportModelFilter>(_potentialPcpChangeReportService.GetPotentialPcpChangeData, _logger);
                    filter.StateId = state.Id;
                    var model = dataGen.GetData(filter);

                    if (model != null && !model.Collection.IsNullOrEmpty())
                    {
                        var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<PotentialPcpChangeReportViewModel>();

                        var path = string.Format(_pcpChangeReportPath, account.FolderName);
                        var reportfilePath = Path.Combine(path, state.Name);

                        DirectoryOperationsHelper.CreateDirectoryIfNotExist(reportfilePath);
                        reportfilePath = Path.Combine(reportfilePath, string.Format("WellMed_PCP_Change_Report_{0}.csv", filter.StartDate.ToString("yyyyMM")));
                        _logger.Info("File path : " + reportfilePath);

                        DirectoryOperationsHelper.DeleteFileIfExist(reportfilePath);
                        _baseExportableReportHelper.GenerateCsv(reportfilePath, exporter, model.Collection);

                        if (_sendReportToSftp && DirectoryOperationsHelper.IsFileExist(reportfilePath))
                        {
                            _logger.Info("Starting to post Potential Pcp Change report on sftp for StateId: " + state.Id + " State: " + state.Name);

                            var sftpResultExportDirectory = string.Format(_sftpPathForPcpChangeReport, state.Name);
                            var processFtp = new ProcessFtp(_logger, _sftpHost, _sftpUserName, _sftpPassword);
                            processFtp.UploadSingleFile(reportfilePath, sftpResultExportDirectory, "");

                            _logger.Info("Potential Pcp Change report posted on sftp for StateId: " + state.Id + " State: " + state.Name);
                        }
                        _logger.Info("Potential Pcp Change Report generation completed for StateId: " + state.Id + " State: " + state.Name);
                    }
                    else
                    {
                        _logger.Info("No data found for StateId: " + state.Id + " State: " + state.Name);
                    }
                }
                catch (Exception exception)
                {
                    _logger.Error("Error occurred during generation of report for StateId: " + state.Id);
                    _logger.Error("Message:  " + exception.Message);
                    _logger.Error("Stack Trace:  " + exception.StackTrace);
                }
            }

            //update custom setting XML
            var customSetting = _customSettingManager.Deserialize(_pcpCustomSetting);
            customSetting.LastTransactionDate = filter.EndDate;
            _customSettingManager.SerializeandSave(_pcpCustomSetting, customSetting);
        }

        private List<DateTime> GetToDates(DateTime cutoffDate)
        {
            var toDates = new List<DateTime>();

            var today = DateTime.Today;
            var tempDate = cutoffDate;
            tempDate = new DateTime(tempDate.Year, tempDate.Month, DateTime.DaysInMonth(tempDate.Year, tempDate.Month));

            while (tempDate < today)
            {
                toDates.Add(tempDate);

                tempDate = tempDate.AddMonths(1);
                tempDate = new DateTime(tempDate.Year, tempDate.Month, DateTime.DaysInMonth(tempDate.Year, tempDate.Month));
            }
            return toDates;
        }

    }
}
