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
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class BiWeeklyMicroAlbuminFobtPollingAgent : IBiWeeklyMicroAlbuminFobtPollingAgent
    {
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly IBaseExportableReportHelper _baseExportableReportHelper;
        private readonly IBiWeeklyMicroAlbuminFobtReportService _biWeeklyMicroAlbuminFobtReportService;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;

        private readonly string _sftpHost;
        private readonly string _sftpUserName;
        private readonly string _sftpPassword;
        private readonly bool _sendReportToSftp;
        private readonly string _sftpPathForBiWeeklyMicroAlbuminFobtReport;
        private readonly long _accountId;
        private readonly DateTime _cutoffDate;
        private readonly IEnumerable<long> _runningDates;
        private readonly string _biWeeklyReportPath;

        public BiWeeklyMicroAlbuminFobtPollingAgent(ISettings settings, ILogManager logManager, IBaseExportableReportHelper baseExportableReportHelper,
                                                    IBiWeeklyMicroAlbuminFobtReportService biWeeklyMicroAlbuminFobtReportService,
                                                    IUniqueItemRepository<CorporateAccount> corporateAccountRepository)
        {
            _settings = settings;
            _baseExportableReportHelper = baseExportableReportHelper;
            _biWeeklyMicroAlbuminFobtReportService = biWeeklyMicroAlbuminFobtReportService;
            _corporateAccountRepository = corporateAccountRepository;
            _logger = logManager.GetLogger("BiWeeklyMicroAlbuminFobtReport");

            _sftpHost = settings.WellmedSftpHost;
            _sftpUserName = settings.WellmedSftpUserName;
            _sftpPassword = settings.WellmedSftpPassword;
            _accountId = settings.WellmedAccountId;
            _cutoffDate = settings.BiWeeklyMicroAlbuminFobtCutoffDate;
            _sendReportToSftp = settings.SendBiWeeklyMicroAlbuminFobtReportToSftp;
            _sftpPathForBiWeeklyMicroAlbuminFobtReport = settings.BiWeeklyMicroAlbuminFobtSftpPath;
            _runningDates = settings.BiWeeklyMicroAlbuminFobtReportRunDates;
            _biWeeklyReportPath = settings.BiWeeklyMicroAlbuminFobtReportPath;
        }

        public void PollForBiWeeklyMicroAlbuminFobt()
        {
            try
            {
                var timeOfDay = DateTime.Now;
                _logger.Info("Time of day : " + timeOfDay.ToString("HH:mm:ss"));

                if (!_settings.IsDevEnvironment && _runningDates.All(x => x != DateTime.Today.Day))
                {
                    _logger.Info("Report is generated only on 1st and 15th of the month");
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

                _logger.Info(string.Format("Generating Report for BiWeekly MicroAlbumin and IFobt"));

                var lastMonthDate = (DateTime.Today).AddMonths(-1);
                var endDate = new DateTime(lastMonthDate.Year, lastMonthDate.Month, DateTime.DaysInMonth(lastMonthDate.Year, lastMonthDate.Month));
                var filter = new BiWeeklyMicroAlbuminFobtReportModelFilter
                {
                    StartDate = new DateTime(DateTime.Today.Year, 1, 1),
                    EndDate = DateTime.Today,
                    AccountId = _accountId,
                    CutOffDate = _cutoffDate
                };
                
                _logger.Info(string.Format("Generating Report for BiWeekly MicroAlbumin and IFobt"));
                if (lastMonthDate.Year < DateTime.Today.Year)
                {
                    filter = new BiWeeklyMicroAlbuminFobtReportModelFilter
                    {
                        AccountId = _accountId,
                        StartDate = new DateTime(lastMonthDate.Year, 1, 1),
                        EndDate = endDate
                    };
                }

                _logger.Info("Start Date: "+ filter.StartDate.ToShortDateString());
                _logger.Info("End Date: " + filter.EndDate.ToShortDateString());

                var dataGen = new ExportableDataGenerator<BiWeeklyMicroAlbuminFobtReportViewModel, BiWeeklyMicroAlbuminFobtReportModelFilter>(_biWeeklyMicroAlbuminFobtReportService.GetEventCustomerResultForReport, _logger);
                var model = dataGen.GetData(filter);

                if (model != null && !model.Collection.IsNullOrEmpty())
                {
                    var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<BiWeeklyMicroAlbuminFobtReportViewModel>();

                    var path = string.Format(_biWeeklyReportPath, account.FolderName);
                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(path);

                    var reportfilePath = Path.Combine(path, string.Format("WellMed_Kit_Disbursement_{0}.csv", DateTime.Now.ToString("yyyyMMdd")));
                    _logger.Info("File path : " + reportfilePath);
                    DirectoryOperationsHelper.DeleteFileIfExist(reportfilePath);
                    _baseExportableReportHelper.GenerateCsv(reportfilePath, exporter, model.Collection);

                    if (_sendReportToSftp && DirectoryOperationsHelper.IsFileExist(reportfilePath))
                    {
                        var sftpResultExportDirectory = _sftpPathForBiWeeklyMicroAlbuminFobtReport;

                        var processFtp = new ProcessFtp(_logger, _sftpHost, _sftpUserName, _sftpPassword);
                        processFtp.UploadSingleFile(reportfilePath, sftpResultExportDirectory, "");
                    }
                    _logger.Info("BiWeeklyMicroAlbuminFobt Report generation completed");
                }
                else
                {
                    _logger.Info("No customer found for Report");
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
