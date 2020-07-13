using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Application.Helper;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class BcbsMemberResultMailedReportPollingAgent : IBcbsMemberResultMailedReportPollingAgent
    {
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IBcbsMiMemberResultMailedReportService _bcbsMiMemberResultMailedReportService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IBaseExportableReportHelper _baseExportableReportHelper;
        private readonly ILogger _logger;
        private readonly string _memberResultMailedSettingPath;
        private readonly DayOfWeek _memberResultMailedReportDayOfWeek;

        private readonly long _accountId;
        private readonly DateTime _cutOfDate;
        private readonly string _destinationFolderPdfPath;
        private readonly string[] _bcbsMiRiskPatientTags;
        private readonly string[] _bcbsMiGapPatinetTags;

        public BcbsMemberResultMailedReportPollingAgent(ILogManager logManager, ISettings settings, ICustomSettingManager customSettingManager,
            IBcbsMiMemberResultMailedReportService bcbsMiMemberResultMailedReportService, ICorporateAccountRepository corporateAccountRepository, IBaseExportableReportHelper baseExportableReportHelper)
        {
            _customSettingManager = customSettingManager;
            _bcbsMiMemberResultMailedReportService = bcbsMiMemberResultMailedReportService;
            _corporateAccountRepository = corporateAccountRepository;
            _baseExportableReportHelper = baseExportableReportHelper;
            _logger = logManager.GetLogger("MemberResultMailedReport");
            _memberResultMailedSettingPath = settings.BcbsMiMemberResultMailedReportSettingPath;
            _memberResultMailedReportDayOfWeek = settings.BcbsMiMemberResultMailedReportDayOfWeek;

            _accountId = settings.BcbsMiAccountId;
            _cutOfDate = settings.PcpDownloadCutOfDate;
            _destinationFolderPdfPath = settings.BcbsMiResultReportDownloadPath;
            _bcbsMiGapPatinetTags = settings.BcbsMiGapPatinetTags;
            _bcbsMiRiskPatientTags = settings.BcbsMiRiskPatientTags;
        }

        public void PollforMemberResultMailedReport()
        {
            try
            {
                if (_accountId < 1)
                {
                    _logger.Info("No account Ids provided");
                    return;
                }

                if (_memberResultMailedReportDayOfWeek != DateTime.Today.DayOfWeek)
                {
                    _logger.Info("Report is schedule to run on " + _memberResultMailedReportDayOfWeek);
                    _logger.Info("Today is day of week " + DateTime.Today.DayOfWeek);
                    _logger.Info(string.Format("Set day of week to {0} to run today ", ((int)DateTime.Today.DayOfWeek)));
                    return;
                }

                var account = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(_accountId);

                var shippintOptionId = _corporateAccountRepository.GetAccountShippingOptionIds(account.Id);

                if (shippintOptionId.IsNullOrEmpty())
                {
                    _logger.Info("No shipping has been selected at Account");
                    return;
                }

                try
                {
                    var directoryPath = _destinationFolderPdfPath + "\\";
                    directoryPath = string.Format(directoryPath, account.FolderName);

                    CreateDistinationDirectory(directoryPath);

                    var serviceReportSettings = string.Format(_memberResultMailedSettingPath, account.Tag);
                    var customSettings = _customSettingManager.Deserialize(serviceReportSettings);

                    var fromDate = (customSettings.LastTransactionDate != null) ? new DateTime(customSettings.LastTransactionDate.Value.Year, 1, 1) : _cutOfDate;

                    var toDate = DateTime.Now;

                    if (fromDate.Year == toDate.Year)
                    {

                        DeleteIffileExist(directoryPath, toDate.Year);

                        //MemberReportForRiskCustomer(account, fromDate, toDate, directoryPath, shippintOptionId);
                        MemberReportForGapCustomer(account, fromDate, toDate, directoryPath, shippintOptionId);
                        //MemberReportForCustomerNoTags(account, fromDate, toDate, directoryPath, shippintOptionId);
                    }
                    else if (fromDate.Year < DateTime.Today.Year)
                    {

                        toDate = new DateTime(fromDate.Year, 12, 31);

                        while (true)
                        {
                            DeleteIffileExist(directoryPath, toDate.Year);

                            //MemberReportForRiskCustomer(account, fromDate, toDate, directoryPath, shippintOptionId);
                            MemberReportForGapCustomer(account, fromDate, toDate, directoryPath, shippintOptionId);
                            //MemberReportForCustomerNoTags(account, fromDate, toDate, directoryPath, shippintOptionId);

                            fromDate = new DateTime((fromDate.Year + 1), 1, 1);

                            toDate = DateTime.Now;

                            if (fromDate.Year < DateTime.Today.Year)
                                toDate = new DateTime(fromDate.Year, 12, 31);

                            if (fromDate.Year > DateTime.Today.Year)
                                break;
                        }
                    }

                    customSettings.LastTransactionDate = toDate;
                    _customSettingManager.SerializeandSave(serviceReportSettings, customSettings);
                }
                catch (Exception ex)
                {
                    _logger.Error("Some Error occurred  for Tag" + account.Tag);
                    _logger.Error("Message: " + ex.Message);
                    _logger.Error("Stack Trace: " + ex.StackTrace);
                }

            }
            catch (Exception ex)
            {
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }

        private void MemberReportForRiskCustomer(CorporateAccount account, DateTime fromDate, DateTime toDate, string directoryPath, IEnumerable<long> shippintOptionId)
        {
            var fileName = string.Format("R_MemberReport_{0}.csv", toDate.ToString("yyyyMMdd"));

            var filter = new MemberResultMailedReportFilter
            {
                DateFrom = fromDate,
                DateTo = toDate,
                HealthPlanId = account.Id,
                CustomTags = _bcbsMiRiskPatientTags,
                ExcludeCustomerWithCustomTag = false,
                ShippingOptions = shippintOptionId,
                Tag = account.Tag
            };

            _logger.Info("generating R_MemberReport for " + account.Tag);

            var dataGen = new ExportableDataGenerator<BcbsMiMemberResultMailedReportViewModel, MemberResultMailedReportFilter>(_bcbsMiMemberResultMailedReportService.GetBcbsMiMemberResultMailedReport, _logger);

            var model = dataGen.GetData(filter);

            if (model != null && !model.Collection.IsNullOrEmpty())
            {
                var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<BcbsMiMemberResultMailedReportViewModel>();

                _logger.Info("Record count" + model.Collection.Count());

                if (File.Exists(directoryPath + fileName))
                    File.Delete(directoryPath + fileName);

                _baseExportableReportHelper.GenerateCsv(directoryPath + fileName, exporter, model.Collection);

                _logger.Info("Destination file " + directoryPath + fileName);
            }
            else
            {
                _logger.Info("No Record Found for Tag" + account.Tag);
            }

            _logger.Info("Completed R-MemberReport for " + account.Tag);
        }

        private void MemberReportForGapCustomer(CorporateAccount account, DateTime dateFrom, DateTime dateTo, string directoryPath, IEnumerable<long> shippintOptionId)
        {
            var fileName = string.Format("Q_MOBILE_MemberReport_{0}.csv", dateTo.ToString("yyyyMMdd"));

            var filter = new MemberResultMailedReportFilter
            {
                DateFrom = dateFrom,
                DateTo = dateTo,
                HealthPlanId = account.Id,
                CustomTags = _bcbsMiGapPatinetTags,
                ExcludeCustomerWithCustomTag = false,
                ShippingOptions = shippintOptionId,
                Tag = account.Tag
            };

            _logger.Info("generating Q_MOBILE_MemberReport for " + account.Tag);

            var dataGen = new ExportableDataGenerator<BcbsMiMemberResultMailedReportViewModel, MemberResultMailedReportFilter>(_bcbsMiMemberResultMailedReportService.GetBcbsMiMemberResultMailedReport, _logger);

            var model = dataGen.GetData(filter);

            if (model != null && !model.Collection.IsNullOrEmpty())
            {
                var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<BcbsMiMemberResultMailedReportViewModel>();

                _logger.Info("Record count" + model.Collection.Count());

                if (File.Exists(directoryPath + fileName))
                    File.Delete(directoryPath + fileName);

                _baseExportableReportHelper.GenerateCsv(directoryPath + fileName, exporter, model.Collection);

                _logger.Info("Destination file " + directoryPath + fileName);
            }
            else
            {
                _logger.Info("No Record Found for Tag" + account.Tag);
            }

            _logger.Info("Completed Q_MOBILE_MemberReport for " + account.Tag);
        }


        private void MemberReportForCustomerNoTags(CorporateAccount account, DateTime dateFrom, DateTime dateTo, string directoryPath, IEnumerable<long> shippintOptionId)
        {
            var fileName = string.Format("MemberReport_{0}.csv", dateTo.ToString("yyyyMMdd"));

            var tagToExlude = new List<string>();
            if (!_bcbsMiGapPatinetTags.IsNullOrEmpty())
                tagToExlude.AddRange(_bcbsMiGapPatinetTags);

            if (!_bcbsMiRiskPatientTags.IsNullOrEmpty())
                tagToExlude.AddRange(_bcbsMiRiskPatientTags);

            var filter = new MemberResultMailedReportFilter
            {
                DateFrom = dateFrom,
                DateTo = dateTo,
                HealthPlanId = account.Id,
                CustomTags = tagToExlude.ToArray(),
                ExcludeCustomerWithCustomTag = true,
                ShippingOptions = shippintOptionId,
                Tag = account.Tag
            };

            _logger.Info("Generating MemberReport for " + account.Tag);

            var dataGen = new ExportableDataGenerator<BcbsMiMemberResultMailedReportViewModel, MemberResultMailedReportFilter>(_bcbsMiMemberResultMailedReportService.GetBcbsMiMemberResultMailedReport, _logger);

            var model = dataGen.GetData(filter);

            if (model != null && !model.Collection.IsNullOrEmpty())
            {
                var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<BcbsMiMemberResultMailedReportViewModel>();

                _logger.Info("Record count" + model.Collection.Count());

                if (File.Exists(directoryPath + fileName))
                    File.Delete(directoryPath + fileName);

                _baseExportableReportHelper.GenerateCsv(directoryPath + fileName, exporter, model.Collection);

                _logger.Info("Destination file " + directoryPath + fileName);
            }
            else
            {
                _logger.Info("No Record Found for Tag" + account.Tag);
            }

            _logger.Info("Completed MemberReport for " + account.Tag);
        }

        private void CreateDistinationDirectory(string directoryPath)
        {
            DirectoryOperationsHelper.CreateDirectoryIfNotExist(directoryPath);
            //if (!DirectoryOperationsHelper.CreateDirectoryIfNotExist(directoryPath)) Directory.CreateDirectory(directoryPath);
        }

        private void DeleteIffileExist(string destinationPath, int year)
        {
            var files = DirectoryOperationsHelper.GetFiles(destinationPath, "*.csv");

            foreach (var file in files)
            {
                if (!string.IsNullOrEmpty(file) && file.Contains("MemberReport_") && file.Contains("_" + year))
                {
                    if (DirectoryOperationsHelper.IsFileExist(file))
                        DirectoryOperationsHelper.Delete(file);
                }

            }
        }
    }
}