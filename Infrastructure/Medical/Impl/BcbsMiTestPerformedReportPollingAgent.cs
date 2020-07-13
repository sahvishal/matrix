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

namespace Falcon.App.Infrastructure.Medical.Impl
{

    [DefaultImplementation]
    public class BcbsMiTestPerformedReportPollingAgent : IBcbsMiTestPerformedReportPollingAgent
    {
        private readonly ICustomSettingManager _customSettingManager;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICustomTestPerformedReportService _customTestPerformedReportService;
        private readonly IBaseExportableReportHelper _baseExportableReportHelper;
        private readonly ILogger _logger;
        private readonly long _accountId;
        private readonly DateTime _cutOfDate;
        private readonly string _destinationFolderPdfPath;

        private readonly string _bcbsMiServiceReportSettingPath;

        private readonly string[] _bcbsMiRiskPatientTags;
        private readonly string[] _bcbsMiGapPatinetTags;

        private readonly DayOfWeek _bcbsMiReportingServiceDayOfWeek;

        public BcbsMiTestPerformedReportPollingAgent(ILogManager logManager, ISettings settings, ICustomSettingManager customSettingManager, ICorporateAccountRepository corporateAccountRepository,
            ICustomTestPerformedReportService customTestPerformedReportService, IBaseExportableReportHelper baseExportableReportHelper)
        {
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _customTestPerformedReportService = customTestPerformedReportService;
            _baseExportableReportHelper = baseExportableReportHelper;
            _logger = logManager.GetLogger("CustomerTestPerformedReport");
            _accountId = settings.BcbsMiAccountId;
            _cutOfDate = settings.PcpDownloadCutOfDate;

            _bcbsMiGapPatinetTags = settings.BcbsMiGapPatinetTags;
            _bcbsMiRiskPatientTags = settings.BcbsMiRiskPatientTags;

            _destinationFolderPdfPath = settings.BcbsMiResultReportDownloadPath;
            _bcbsMiServiceReportSettingPath = settings.ServiceReportSettingPath;
            _bcbsMiReportingServiceDayOfWeek = settings.BcbsMiReportingServiceDayOfWeek;
        }

        public void PollforCustomTestPerformedReport()
        {
            try
            {
                if (_accountId < 1)
                {
                    _logger.Info("No account Ids provided");
                    return;
                }

                if (_bcbsMiReportingServiceDayOfWeek != DateTime.Today.DayOfWeek)
                {
                    _logger.Info("Report is schedule to run on " + _bcbsMiReportingServiceDayOfWeek);
                    _logger.Info("Today is day of week " + DateTime.Today.DayOfWeek);
                    _logger.Info(string.Format("Set day of week to {0} to run today ", ((int)DateTime.Today.DayOfWeek)));
                    return;
                }

                var account = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(_accountId);

                try
                {
                    var directoryPath = _destinationFolderPdfPath + "\\";
                    directoryPath = string.Format(directoryPath, account.FolderName);

                    CreateDistinationDirectory(directoryPath);

                    var serviceReportSettings = string.Format(_bcbsMiServiceReportSettingPath, account.Tag);
                    var customSettings = _customSettingManager.Deserialize(serviceReportSettings);

                    var fromDate = (customSettings.LastTransactionDate != null) ? new DateTime(customSettings.LastTransactionDate.Value.Year, 1, 1) : _cutOfDate;
                    var toDate = DateTime.Now;

                    if (fromDate.Year == toDate.Year)
                    {
                        DeleteIffileExist(directoryPath, toDate.Year);

                        //ServiceReportForRiskCustomer(account, fromDate, toDate, directoryPath);
                        ServiceReportForGapCustomer(account, fromDate, toDate, directoryPath);
                        //ServiceReportForCustomerNoTags(account, fromDate, toDate, directoryPath);
                    }
                    else if (fromDate.Year < DateTime.Today.Year)
                    {
                        toDate = new DateTime(fromDate.Year, 12, 31);

                        while (true)
                        {
                            DeleteIffileExist(directoryPath, toDate.Year);

                            //ServiceReportForRiskCustomer(account, fromDate, toDate, directoryPath);
                            ServiceReportForGapCustomer(account, fromDate, toDate, directoryPath);
                            //ServiceReportForCustomerNoTags(account, fromDate, toDate, directoryPath);

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

        private void ServiceReportForRiskCustomer(CorporateAccount account, DateTime dateFrom, DateTime dateTo, string directoryPath)
        {
            var fileName = string.Format("R_ServicesReport_{0}.csv", dateTo.ToString("yyyyMMdd"));

            var filter = new CustomTestPerformedReportFilter
            {
                DateFrom = dateFrom,
                DateTo = dateTo,
                HealthPlanId = account.Id,
                CustomTags = _bcbsMiRiskPatientTags,
                ExcludeCustomerWithCustomTag = false,
                Tag = account.Tag
            };

            _logger.Info("generating R-ServicesReport for " + account.Tag);

            var dataGen = new ExportableDataGenerator<CustomTestPerformedViewModel, CustomTestPerformedReportFilter>(_customTestPerformedReportService.CustomTestPerformedReport, _logger);

            var model = dataGen.GetData(filter);

            if (model != null && !model.Collection.IsNullOrEmpty())
            {
                var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CustomTestPerformedViewModel>();

                _logger.Info("Record count" + model.Collection.Count());

                if (File.Exists(directoryPath + fileName))
                    File.Delete(directoryPath + fileName);

                _baseExportableReportHelper.GenerateCsv(directoryPath + fileName, exporter, model.Collection);

                _logger.Info("CSV Generated at " + directoryPath + fileName);
            }
            else
            {
                _logger.Info("No Record Found for Tag" + account.Tag);
            }

            _logger.Info("Completed R-ServicesReport for " + account.Tag);

        }

        private void ServiceReportForGapCustomer(CorporateAccount account, DateTime dateFrom, DateTime dateTo, string directoryPath)
        {
            var fileName = string.Format("Q_MOBILE_ServicesReport_{0}.csv", dateTo.ToString("yyyyMMdd"));

            var filter = new CustomTestPerformedReportFilter
            {
                DateFrom = dateFrom,
                DateTo = dateTo,
                HealthPlanId = account.Id,
                CustomTags = _bcbsMiGapPatinetTags,
                ExcludeCustomerWithCustomTag = false,
                Tag = account.Tag
            };

            _logger.Info("Generating Q_MOBILE_ServicesReport for " + account.Tag);

            var dataGen = new ExportableDataGenerator<CustomTestPerformedViewModel, CustomTestPerformedReportFilter>(_customTestPerformedReportService.CustomTestPerformedReport, _logger);

            var model = dataGen.GetData(filter);

            if (model != null && !model.Collection.IsNullOrEmpty())
            {
                var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CustomTestPerformedViewModel>();

                _logger.Info("Record count" + model.Collection.Count());

                if (File.Exists(directoryPath + fileName))
                    File.Delete(directoryPath + fileName);

                _baseExportableReportHelper.GenerateCsv(directoryPath + fileName, exporter, model.Collection);

                _logger.Info("CSV Generated at " + directoryPath + fileName);
            }
            else
            {
                _logger.Info("No Record Found for Tag" + account.Tag);
            }

            _logger.Info("Completed Q_MOBILE_ServicesReport for " + account.Tag);
        }

        private void ServiceReportForCustomerNoTags(CorporateAccount account, DateTime dateFrom, DateTime dateTo, string directoryPath)
        {
            var fileName = string.Format("ServicesReport_{0}.csv", dateTo.ToString("yyyyMMdd"));

            var tagToExlude = new List<string>();
            if (!_bcbsMiGapPatinetTags.IsNullOrEmpty())
                tagToExlude.AddRange(_bcbsMiGapPatinetTags);

            if (!_bcbsMiRiskPatientTags.IsNullOrEmpty())
                tagToExlude.AddRange(_bcbsMiRiskPatientTags);

            var filter = new CustomTestPerformedReportFilter
            {
                DateFrom = dateFrom,
                DateTo = dateTo,
                HealthPlanId = account.Id,
                CustomTags = tagToExlude.ToArray(),
                ExcludeCustomerWithCustomTag = true,
                Tag = account.Tag
            };

            _logger.Info("Generating ServicesReport for " + account.Tag);

            var dataGen = new ExportableDataGenerator<CustomTestPerformedViewModel, CustomTestPerformedReportFilter>(_customTestPerformedReportService.CustomTestPerformedReport, _logger);

            var model = dataGen.GetData(filter);

            if (model != null && !model.Collection.IsNullOrEmpty())
            {
                var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CustomTestPerformedViewModel>();

                _logger.Info("Record count" + model.Collection.Count());

                if (File.Exists(directoryPath + fileName))
                    File.Delete(directoryPath + fileName);

                _baseExportableReportHelper.GenerateCsv(directoryPath + fileName, exporter, model.Collection);

                _logger.Info("CSV Generated at " + directoryPath + fileName);
            }
            else
            {
                _logger.Info("No Record Found for Tag" + account.Tag);
            }
            _logger.Info("Completed ServicesReport for " + account.Tag);
        }

        private void CreateDistinationDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        }

        private void DeleteIffileExist(string destinationPath, int year)
        {
            var files = Directory.GetFiles(destinationPath, "*.csv");

            foreach (var file in files)
            {
                if (!string.IsNullOrEmpty(file) && file.Contains("ServicesReport_") && file.Contains("_" + year))
                {
                    if (File.Exists(file))
                        File.Delete(file);
                }

            }
        }
    }
}