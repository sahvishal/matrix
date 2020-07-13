using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users;
using System.Linq;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Domain;
using Twilio;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class GiftCertificateWellmedPollingAgent : IGiftCertificateWellmedPollingAgent
    {
        private readonly ISettings _settings;
        private readonly IGiftCerificateWellmedReportService _giftCerificateWellmedReportService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        private readonly ILogger _logger;

        private readonly IBaseExportableReportHelper _baseExportableReportHelper;


        public GiftCertificateWellmedPollingAgent(ILogManager logManager, ISettings settings, IGiftCerificateWellmedReportService giftCerificateWellmedReportService, IEventRepository eventRepository,
            ICorporateAccountRepository corporateAccountRepository, IBaseExportableReportHelper baseExportableReportHelper)
        {
            _settings = settings;
            _giftCerificateWellmedReportService = giftCerificateWellmedReportService;
            _corporateAccountRepository = corporateAccountRepository;
            _baseExportableReportHelper = baseExportableReportHelper;
            _logger = logManager.GetLogger("GiftCertificateWellmedReport");
        }

        public void PollGiftCertificateWellmedReport()
        {
            try
            {
                var wellmedFlAccountId = _settings.WellmedAccountId;
                var wellmedTxAccountId = _settings.WellmedTxAccountId;

                var giftCertificateWellmedAccountIds = new List<long> { wellmedFlAccountId, wellmedTxAccountId };

                var corporateAccounts = _corporateAccountRepository.GetByIds(giftCertificateWellmedAccountIds);

                if (corporateAccounts.IsNullOrEmpty())
                {
                    _logger.Info("No Account Found to run Report");
                    return;
                }

                var fromDate = DateTime.Today.GetFirstDateOfYear();
                DateTime toDate = DateTime.Today;

                _logger.Info("starting for Poll Gift Cerificate Wellmed Report ");

                foreach (var account in corporateAccounts)
                {

                    if ((long)DateTime.Today.DayOfWeek != _settings.WellmedGiftCertificateDayOfWeek)
                    {
                        _logger.Info("Today is Day of Week is " + DateTime.Today.DayOfWeek);
                        _logger.Info("Service will run on Day of Week " +
                                     (DayOfWeek)_settings.WellmedGiftCertificateDayOfWeek);
                        return;
                    }

                    _logger.Info("starting for Account : " + account.Tag);

                    var folderName = account.Id == wellmedFlAccountId ? _settings.WellmedFlFolder : _settings.WellmedTxFolder;

                    var destinationFoler = Path.Combine(string.Format(_settings.OutTakeReportPath, folderName), "GiftCard");
                    
                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationFoler);

                    var lastReportRunDate = toDate.AddDays(-7);

                    if (toDate.Year == lastReportRunDate.Year)
                    {
                        GenerateReport(destinationFoler, fromDate, toDate, account, folderName);
                    }
                    else if (lastReportRunDate.Year < toDate.Year)
                    {
                        fromDate = new DateTime(lastReportRunDate.Year, 1, 1);
                        var toforPreviousYearDate = fromDate.GetLastDateOfYear();

                        GenerateReport(destinationFoler, fromDate, toforPreviousYearDate, account,folderName);
                        GenerateReport(destinationFoler, toDate.GetFirstDateOfYear(), toDate, account, folderName);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }

        private bool GenerateReport(string destinationFolder, DateTime startDate, DateTime endDate, CorporateAccount account, string folderName)
        {
            var filter = new GiftCertificateReportFilter
            {
                HealthPlanId = account.Id,
                EventFrom = startDate,
                EventTo = endDate,
                Tag = account.Tag
            };
            var acesClientShortName = !string.IsNullOrWhiteSpace(account.AcesClientShortName) ? account.AcesClientShortName : "NoClientSortName_" + account.Tag;

            var fileName = string.Format("GiftCard_{0}_{1}_{2}.csv", acesClientShortName, folderName, endDate.ToString("MMddyyyy"));

            GenerateReport(destinationFolder, fileName, filter);

            GenerateReport(destinationFolder, fileName, filter);

            return true;
        }

        private bool GenerateReport(string destinationFolder, string fileName, GiftCertificateReportFilter filter)
        {
            var completePath = Path.Combine(destinationFolder, fileName);

            var dataGen = new ExportableDataGenerator<GiftCertificateReportWellmedViewModel, GiftCertificateReportFilter>(_giftCerificateWellmedReportService.GetGiftCertificateWellmedReport, _logger);

            var model = dataGen.GetData(filter);

            if (model != null && !model.Collection.IsNullOrEmpty())
            {
                _logger.Info("Writing Gift Certificate Report");
                var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<GiftCertificateReportWellmedViewModel>();

                _logger.Info("Record count" + model.Collection.Count());

                DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationFolder);

                DirectoryOperationsHelper.DeleteFileIfExist(completePath);

                _baseExportableReportHelper.GenerateCsv(completePath, exporter, model.Collection);

                _logger.Info("completed Gift Certificate Report for account tag " + filter.Tag);

                _logger.Info("Destination Path: " + completePath);

                return true;
            }

            return false;
        }
    }
}