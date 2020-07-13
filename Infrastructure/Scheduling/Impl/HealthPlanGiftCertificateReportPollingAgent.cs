using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class HealthPlanGiftCertificateReportPollingAgent : IHealthPlanGiftCertificateReportPollingAgent
    {
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly ILogger _logger;

        private readonly string _customSettingFile;
        private readonly IEnumerable<long> _accountIds;
        private readonly DateTime _cutOffDate;
        private readonly IEnumerable<DayOfWeek> _daysOfWeek;
        private readonly string _giftCertificateReportDownloadPath;
        private readonly string _giftCertificateReportInternalLocation;

        public HealthPlanGiftCertificateReportPollingAgent(ILogManager logManager, ISettings settings,
            ICorporateAccountRepository corporateAccountRepository, IEventCustomerReportingService eventCustomerReportingService,
            ICustomSettingManager customSettingManager)
        {
            _logger = logManager.GetLogger("HealthPlanGiftCertificateReport");
            _corporateAccountRepository = corporateAccountRepository;
            _eventCustomerReportingService = eventCustomerReportingService;
            _customSettingManager = customSettingManager;

            _customSettingFile = settings.GiftCertificateSettingResourcePath;
            _accountIds = settings.GiftCertificateReportDownloadAccountIds;
            _cutOffDate = settings.GiftCertificateReportCutOffDate;
            _daysOfWeek = settings.GiftCertificateReportDaysOfWeek;
            _giftCertificateReportDownloadPath = settings.GiftCertificateReportDownloadPath;
            _giftCertificateReportInternalLocation = settings.GiftCertificateReportInternalLocation;
        }

        public void PollForReportGeneration()
        {

            if (!_daysOfWeek.Contains(DateTime.Today.DayOfWeek))
            {
                _logger.Info(string.Format("Today is {0}. Job is set to run on {1} .", DateTime.Today.DayOfWeek, string.Join(", ", _daysOfWeek)));
                return;
            }

            if (_accountIds.IsNullOrEmpty())
            {
                _logger.Info("No accounts found for Gift Certificate Report.");
                return;
            }
            var corporateAccounts = _corporateAccountRepository.GetByIds(_accountIds);

            var toDate = DateTime.Today;
            var fromDate = new DateTime(toDate.Year, 1, 1);

            foreach (var corporateAccount in corporateAccounts)
            {
                try
                {
                    var customSettingFilePath = string.Format(_customSettingFile, corporateAccount.Tag);
                    var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                    var exportFromTime = customSettings.LastTransactionDate ?? _cutOffDate;

                    var filter = new HealthPlanGiftCertificateReportFilter
                    {
                        Tag = corporateAccount.Tag,
                        FromDate = exportFromTime.Date,
                        ToDate = toDate
                    };

                    fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : fromDate;

                    _logger.Info(string.Format("Generating for account with ID : {0} and tag : {1} from {2} to {3}", corporateAccount.Id, corporateAccount.Tag, fromDate.ToShortDateString(), toDate.ToShortDateString()));

                    var pageNumber = 1;
                    const int pageSize = 100;

                    var list = new List<HealthPlanGiftCertificateReportViewModel>();

                    while (true)
                    {
                        int totalRecords;
                        var model = _eventCustomerReportingService.GetForHealthPlanGiftCertificateReport(pageNumber, pageSize, filter, out totalRecords);
                        if (model == null || model.Collection == null || !model.Collection.Any()) break;

                        list.AddRange(model.Collection);
                        _logger.Info(String.Format("PageNumber:{0} Totalrecords: {1}  Current Length: {2}\n\n", pageNumber, totalRecords, list.Count));

                        pageNumber++;

                        if (list.Count >= totalRecords)
                            break;
                    }

                    if (!list.Any())
                    {
                        _logger.Info(string.Format("No records found for account with ID : {0} and tag : {1}", corporateAccount.Id, corporateAccount.Tag, fromDate.ToShortDateString(), toDate.ToShortDateString()));
                        continue;
                    }

                    var internalLocation = string.Format(_giftCertificateReportInternalLocation, corporateAccount.FolderName);

                    if (!DirectoryOperationsHelper.IsDirectoryExist(internalLocation)) DirectoryOperationsHelper.CreateDirectory(internalLocation);

                    var fileName = @"\" + string.Format("CCI_offline_HealthFair_{0}.csv", DateTime.Today.ToString("yyyy_MM_dd"));//CCI_offline_HealthFair_YYYY_MM_DD

                    var internalFilePath = internalLocation + fileName;

                    WriteCsv(list, internalFilePath);

                    if (DirectoryOperationsHelper.IsFileExist(internalFilePath))
                    {
                        var folder = Path.Combine(string.Format(_giftCertificateReportDownloadPath, corporateAccount.FolderName), DateTime.Today.Year.ToString());

                        if (!DirectoryOperationsHelper.IsDirectoryExist(folder)) DirectoryOperationsHelper.CreateDirectory(folder);

                        var filePath = folder + fileName;

                        DirectoryOperationsHelper.Copy(internalFilePath, filePath);
                    }

                    _logger.Info(string.Format("Completed Gift Certificate Report for account with ID : {0} and tag : {1} from {2} to {3}", corporateAccount.Id, corporateAccount.Tag, fromDate.ToShortDateString(), toDate.ToShortDateString()));

                    customSettings.LastTransactionDate = toDate;
                    _customSettingManager.SerializeandSave(customSettingFilePath, customSettings);
                }
                catch (Exception ex)
                {
                    _logger.Info(string.Format("Error occured for account with ID : {0} and tag : {1} \nMessage : {2} \nStack Trace : {3}", corporateAccount.Id, corporateAccount.Tag, ex.Message, ex.StackTrace));
                }
            }
        }

        private void WriteCsv(IEnumerable<HealthPlanGiftCertificateReportViewModel> modelData, string fileName)
        {
            _logger.Info("Writing CSV file " + fileName);
            if (File.Exists(fileName))
                File.Delete(fileName);

            var fileWriter = new StreamWriter(fileName);

            try
            {
                var members = (typeof(HealthPlanGiftCertificateReportViewModel)).GetMembers();

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

                    var propertyName = memberInfo.Name;
                    var isHidden = false;

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

                fileWriter.WriteLine(string.Join(",", header.ToArray()));

                var sanitizer = new CSVSanitizer();


                foreach (var model in modelData)
                {
                    var values = new List<string>();
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


                        bool isHidden = false;
                        FormatAttribute formatter = null;

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
                                if (attribute is FormatAttribute)
                                {
                                    formatter = (FormatAttribute)attribute;
                                }
                            }
                        }

                        if (isHidden) continue;
                        var obj = propInfo.GetValue(model, null);
                        if (obj == null)
                            values.Add(string.Empty);
                        else if (formatter != null)
                            values.Add(formatter.ToString(obj));
                        else
                            values.Add(sanitizer.EscapeString(obj.ToString()));

                    }

                    fileWriter.WriteLine(string.Join(",", values.ToArray()));
                }

                _logger.Info("CSV File Export was succesful!");
            }
            catch (Exception ex)
            {
                _logger.Error((string.Format("File Write: \n Error {0} \n Trace: {1} \n\n\n", ex.Message, ex.StackTrace)));
            }
            finally
            {
                fileWriter.Close();
                fileWriter.Dispose();
            }

        }
    }
}
