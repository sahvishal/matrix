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

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class GiftCertificateOptumPollingAgent : IGiftCertificateOptumPollingAgent
    {
        private readonly ISettings _settings;
        private readonly IGiftCerificateOptumReportService _giftCerificateOptumReportService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        private readonly ILogger _logger;

        private readonly IBaseExportableReportHelper _baseExportableReportHelper;
        private readonly DayOfWeek _runReportForAppleCareDaysOfWeek;
        private readonly long _applecareAccountId;

        public GiftCertificateOptumPollingAgent(ILogManager logManager, ISettings settings, IGiftCerificateOptumReportService giftCerificateOptumReportService, IEventRepository eventRepository,
            ICorporateAccountRepository corporateAccountRepository, IBaseExportableReportHelper baseExportableReportHelper)
        {
            _settings = settings;
            _giftCerificateOptumReportService = giftCerificateOptumReportService;
            _corporateAccountRepository = corporateAccountRepository;
            _baseExportableReportHelper = baseExportableReportHelper;
            _logger = logManager.GetLogger("GiftCertificateOptumReport");

            _runReportForAppleCareDaysOfWeek = settings.AppleCareGiftCertificateDayOfWeek;
            _applecareAccountId = settings.AppleCareAccountId;
        }

        public void PollGiftCertificateOptumReport()
        {
            try
            {
                var corporateAccounts = _corporateAccountRepository.GetByIds(_settings.GiftCerificateOptumAccountIds);

                if (corporateAccounts.IsNullOrEmpty())
                {
                    _logger.Info("No Account Found to run Report");
                    return;
                }

                var fromDate = DateTime.Today.GetFirstDateOfYear();
                DateTime toDate = DateTime.Today;

                _logger.Info("starting for PollGiftCerificateOptumReport ");

                foreach (var account in corporateAccounts)
                {
                    if (account.Id == _applecareAccountId && _runReportForAppleCareDaysOfWeek != DateTime.Today.DayOfWeek)
                    {
                        _logger.Info(string.Format("Today is {0}. Job is set to run on {1} for Account Tag {2}.", DateTime.Today.DayOfWeek, _runReportForAppleCareDaysOfWeek, account.Tag));
                        continue;
                    }

                    if (account.Id != _applecareAccountId && (long)DateTime.Today.DayOfWeek != _settings.GiftCerificateOptumDayServiceRun)
                    {
                        _logger.Info("Today is Day of Week is " + DateTime.Today.DayOfWeek);
                        _logger.Info("Service will run on Day of Week " + (DayOfWeek)_settings.GiftCerificateOptumDayServiceRun);
                        return;
                    }

                    _logger.Info("starting for Account : " + account.Tag);

                    var destinationFoler = string.Format(_settings.GiftCerificateOptumDownloadPath, account.FolderName);

                    if (account.Id == _applecareAccountId)
                    {
                        destinationFoler = string.Format(_settings.GiftCertificateReportDownloadPath, account.FolderName);
                    }
                    if (account.Id != _applecareAccountId)
                    {
                        try
                        {
                            DirectoryOperationsHelper.DeleteDirectory(destinationFoler, true);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Some error occurred while deleting directory at path: " + destinationFoler);
                            _logger.Error("Message: " + ex.Message);
                            _logger.Error("Stack Trace: " + ex.StackTrace);
                        }
                    }

                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationFoler);

                    var lastReportRunDate = toDate.AddDays(-7);

                    if (toDate.Year == lastReportRunDate.Year)
                    {
                        var fileName = "GiftCardReport_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                        var filter = new GiftCertificateReportFilter
                        {
                            HealthPlanId = account.Id,
                            EventFrom = fromDate,
                            EventTo = toDate,
                            Tag = account.Tag
                        };

                        var isReportGenerated = GenerateReport(destinationFoler, fileName, filter);
                        if (account.Id != _applecareAccountId)
                        {
                            if (!isReportGenerated)
                            {
                                filter = new GiftCertificateReportFilter
                                {
                                    HealthPlanId = account.Id,
                                    EventFrom = new DateTime((fromDate.Year - 1), 1, 1),
                                    EventTo = new DateTime((fromDate.Year - 1), 12, 31),
                                    Tag = account.Tag
                                };
                                isReportGenerated = GenerateReport(destinationFoler, fileName, filter);
                                if (!isReportGenerated)
                                {
                                    WriteHeader(Path.Combine(destinationFoler, fileName));
                                }
                            }
                        }
                    }
                    else if (lastReportRunDate.Year < toDate.Year)
                    {
                        fromDate = new DateTime(lastReportRunDate.Year, 1, 1);
                        var toforPreviousYearDate = fromDate.GetLastDateOfYear();

                        var filter = new GiftCertificateReportFilter
                         {
                             HealthPlanId = account.Id,
                             EventFrom = fromDate,
                             EventTo = toforPreviousYearDate,
                             Tag = account.Tag
                         };

                        var fileName = "GiftCardReport_" + toforPreviousYearDate.ToString("yyyyMMdd") + ".csv";

                        GenerateReport(destinationFoler, fileName, filter);

                        filter = new GiftCertificateReportFilter
                       {
                           HealthPlanId = account.Id,
                           EventFrom = toDate.GetFirstDateOfYear(),
                           EventTo = toDate,
                           Tag = account.Tag
                       };

                        fileName = "GiftCardReport_" + toDate.ToString("yyyyMMdd") + ".csv";
                        GenerateReport(destinationFoler, fileName, filter);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }

        private bool GenerateReport(string destinationFolder, string fileName, GiftCertificateReportFilter filter)
        {
            var completePath = Path.Combine(destinationFolder, fileName);

            var dataGen = new ExportableDataGenerator<GiftCertificateReportOptumViewModel, GiftCertificateReportFilter>(_giftCerificateOptumReportService.GetGiftCertificateOptumReport, _logger);

            var model = dataGen.GetData(filter);

            if (model != null && !model.Collection.IsNullOrEmpty())
            {
                _logger.Info("Writing Gift Certificate Report");
                var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<GiftCertificateReportOptumViewModel>();

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


        private void WriteHeader(string fileName)
        {
            var members = (typeof(GiftCertificateReportOptumViewModel)).GetMembers();
            var fs = new FileStream(fileName, FileMode.OpenOrCreate);
            var streamWriter = new StreamWriter(fs);

            try
            {
                var header = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);
                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                            continue;
                    }
                    else
                        continue;

                    string propertyName = memberInfo.Name;
                    bool isHidden = false;

                    var attributes = propInfo.GetCustomAttributes(false);
                    if (!attributes.IsNullOrEmpty())
                    {
                        foreach (var attribute in attributes)
                        {
                            if (attribute is HiddenAttribute)
                            {
                                isHidden = true;
                                break;
                            }
                            if (attribute is DisplayNameAttribute)
                            {
                                propertyName = (attribute as DisplayNameAttribute).DisplayName;
                            }
                        }
                    }

                    if (isHidden) continue;

                    header.Add(propertyName);
                }

                streamWriter.Write(string.Join(",", header.ToArray()) + Environment.NewLine);
            }
            catch (Exception exception)
            {
                Console.WriteLine("some Exception: " + exception);
                throw;
            }
            finally
            {
                streamWriter.Close();
                streamWriter.Dispose();
                fs.Close();
                fs.Dispose();
            }

        }
    }
}