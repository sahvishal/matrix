using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class BcbsMiHomeVisitRequestExportPollingAgent : IBcbsMiHomeVisitRequestExportPollingAgent
    {
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateCustomerCustomTagRepository _corporateCustomerCustomTagRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IHealthPlanExportCustomerViewModelFactory _healthPlanExportCustomerViewModelFactory;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly ILogger _logger;
        private readonly DateTime _cutOffDate;
        private readonly DayOfWeek _dayOfWeek;
        private readonly string[] _bcbsMiRiskPatientTags;
        private readonly string[] _bcbsMiGapPatinetTags;
        private readonly long _bcbsMiAccountId;
        private readonly string _bcbsMiFolderPath;
        private readonly string _customSettingsPath;

        private const int PageSize = 100;

        public BcbsMiHomeVisitRequestExportPollingAgent(ILogManager logManager, ISettings settings, IUniqueItemRepository<CorporateAccount> corporateAccountRepository,
            ICustomerRepository customerRepository, ICorporateCustomerCustomTagRepository corporateCustomerCustomTagRepository,
            IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, IHealthPlanExportCustomerViewModelFactory healthPlanExportCustomerViewModelFactory, ICustomSettingManager customSettingManager)
        {
            _corporateAccountRepository = corporateAccountRepository;
            _customerRepository = customerRepository;
            _corporateCustomerCustomTagRepository = corporateCustomerCustomTagRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _healthPlanExportCustomerViewModelFactory = healthPlanExportCustomerViewModelFactory;
            _customSettingManager = customSettingManager;
            _logger = logManager.GetLogger("BCBS_MI_Home_Visit_Request_Export");
            _cutOffDate = settings.PcpDownloadCutOfDate;
            _dayOfWeek = settings.BcbsMiHomeVisitExportDay;
            _bcbsMiRiskPatientTags = settings.BcbsMiRiskPatientTags;
            _bcbsMiGapPatinetTags = settings.BcbsMiGapPatinetTags;
            _bcbsMiAccountId = settings.BcbsMiAccountId;
            _bcbsMiFolderPath = settings.BcbsMiResultReportDownloadPath;
            _customSettingsPath = settings.BcbsmiHomeVisitRequestedSettingPath;
        }

        public void PollForExport()
        {
            try
            {
                if (_bcbsMiAccountId <= 0)
                {
                    _logger.Info("Account Id not provided  ");
                    return;
                }

                if (DateTime.Today.DayOfWeek != _dayOfWeek)
                {
                    _logger.Info("Day of the week is " + DateTime.Today.DayOfWeek);
                    _logger.Info("The job runs every " + _dayOfWeek);
                    return;
                }

                var corporateAccount = _corporateAccountRepository.GetById(_bcbsMiAccountId);

                _logger.Info(" Starting BCBS MI Home Visit Requested Report generation.");
                var dateTime = DateTime.Now;
                var homeVisitRequestedSetting = _customSettingManager.Deserialize(string.Format(_customSettingsPath, corporateAccount.Tag));

                var directoryPath = string.Format(_bcbsMiFolderPath, corporateAccount.FolderName);

                var fromDate = (homeVisitRequestedSetting.LastTransactionDate != null) ? new DateTime(homeVisitRequestedSetting.LastTransactionDate.Value.Year, 1, 1) : _cutOffDate;
                var toDate = DateTime.Now;

                if (fromDate.Year == toDate.Year)
                {
                    DeleteIffileExist(directoryPath, toDate.Year);

                    //HomeVisitRequestReportForRiskPatient(corporateAccount, fromDate, toDate);
                    HomeVisitRequestReportForGapPatient(corporateAccount, fromDate, toDate);
                    //HomeVisitRequestReportForNormalPatient(corporateAccount, fromDate, toDate);

                }
                else if (fromDate.Year < DateTime.Today.Year)
                {
                    toDate = new DateTime(fromDate.Year, 12, 31);

                    while (true)
                    {
                        DeleteIffileExist(directoryPath, toDate.Year);

                        //HomeVisitRequestReportForRiskPatient(corporateAccount, fromDate, toDate);
                        HomeVisitRequestReportForGapPatient(corporateAccount, fromDate, toDate);
                        //HomeVisitRequestReportForNormalPatient(corporateAccount, fromDate, toDate);

                        fromDate = new DateTime((fromDate.Year + 1), 1, 1);

                        toDate = DateTime.Now;

                        if (fromDate.Year < DateTime.Today.Year)
                            toDate = new DateTime(fromDate.Year, 12, 31);

                        if (fromDate.Year > DateTime.Today.Year)
                            break;
                    }
                }


                homeVisitRequestedSetting.LastTransactionDate = dateTime;

                _customSettingManager.SerializeandSave(string.Format(_customSettingsPath, corporateAccount.Tag), homeVisitRequestedSetting);

                _logger.Info("BCBS MI Home Visit Requested Report completed.");
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while generating BCBS MI Home Visit Requested Report.\n Message : {0} \n Stack Trace : {1}", ex.Message, ex.StackTrace));
            }
        }

        private void HomeVisitRequestReportForRiskPatient(CorporateAccount account, DateTime fromDate, DateTime toDate)
        {
            var filter = new HealthPlanCustomerExportFilter
            {
                CallStatus = CallStatus.Attended,
                Tag = ProspectCustomerTag.HomeVisitRequested,
                CorporateTag = account.Tag,
                StartDate = fromDate,
                EndDate = toDate,
                CustomTags = _bcbsMiRiskPatientTags
            };

            _logger.Info(string.Format("Starting Risk Patient for Corporate Tag: {0} StartDate: {1}", filter.CorporateTag, filter.StartDate.ToShortDateString()));

            HomeVisitRequestReport("R_HomeVisitRequested", account, filter);

            _logger.Info(string.Format("Completed Risk Patient for Corporate Tag: {0} StartDate: {1}\n", filter.CorporateTag, filter.StartDate.ToShortDateString()));
        }

        private void HomeVisitRequestReportForGapPatient(CorporateAccount account, DateTime fromDate, DateTime toDate)
        {
            var filter = new HealthPlanCustomerExportFilter
            {
                CallStatus = CallStatus.Attended,
                Tag = ProspectCustomerTag.HomeVisitRequested,
                CorporateTag = account.Tag,
                StartDate = fromDate,
                EndDate = toDate,
                CustomTags = _bcbsMiGapPatinetTags
            };

            _logger.Info(string.Format("Starting Gap Patient for Corporate Tag: {0} StartDate: {1}", filter.CorporateTag, filter.StartDate.ToShortDateString()));

            HomeVisitRequestReport("Q_HomeVisitRequested", account, filter);

            _logger.Info(string.Format("Completed Gap Patient for Corporate Tag: {0} StartDate: {1}\n", filter.CorporateTag, filter.StartDate.ToShortDateString()));
        }

        private void HomeVisitRequestReportForNormalPatient(CorporateAccount account, DateTime fromDate, DateTime toDate)
        {
            var tagToExlude = new List<string>();
            if (!_bcbsMiGapPatinetTags.IsNullOrEmpty())
                tagToExlude.AddRange(_bcbsMiGapPatinetTags);

            if (!_bcbsMiRiskPatientTags.IsNullOrEmpty())
                tagToExlude.AddRange(_bcbsMiRiskPatientTags);

            var filter = new HealthPlanCustomerExportFilter
            {
                CallStatus = CallStatus.Attended,
                Tag = ProspectCustomerTag.HomeVisitRequested,
                CorporateTag = account.Tag,
                StartDate = fromDate,
                EndDate = toDate,
                CustomTags = tagToExlude.ToArray(),
                ExcludeCustomerWithCustomTag = true
            };

            _logger.Info(string.Format("Starting Normal Patient for Corporate Tag: {0} StartDate: {1}", filter.CorporateTag, filter.StartDate.ToShortDateString()));

            HomeVisitRequestReport("HomeVisitRequested", account, filter);

            _logger.Info(string.Format("Completed Normal Patient for Corporate Tag: {0} StartDate: {1}\n", filter.CorporateTag, filter.StartDate.ToShortDateString()));
        }

        private void HomeVisitRequestReport(string fileName, CorporateAccount account, HealthPlanCustomerExportFilter filter)
        {
            var list = new List<BcbsMiHomeVisitRequestViewModel>();
            var pageNumber = 1;

            while (true)
            {
                int totalRecords;
                var customers = _customerRepository.HealthPlanHomeVisitRequestedCustomerExport(filter, pageNumber, PageSize, out totalRecords);

                _logger.Info(string.Format("Corporate Tag: {0} StartDate: {1} Total Customer Found: {2} PageNumber {3} ", filter.CorporateTag, filter.StartDate.ToShortDateString(), totalRecords, pageNumber));

                if (customers == null || !customers.Any()) break;

                var customerIds = customers.Select(x => x.CustomerId).ToArray();
                var corporateTags = _corporateCustomerCustomTagRepository.GetByCustomerIds(customerIds);

                var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(customerIds);

                var model = _healthPlanExportCustomerViewModelFactory.CreateHomeVisitListForBcbsMi(customers, corporateTags, primaryCarePhysicians);

                list.AddRange(model);

                pageNumber++;

                if (list.Count >= totalRecords)
                    break;
            }

            if (!list.Any())
            {
                _logger.Info(string.Format("No Patients found for Corporate Tag: {0}", filter.CorporateTag));
                return;
            }

            GenerateReport(fileName, account, list);
        }

        private void GenerateReport(string fileName, CorporateAccount account, IEnumerable<BcbsMiHomeVisitRequestViewModel> list)
        {
            var destinationFolderPath = string.Format(_bcbsMiFolderPath, account.FolderName);
            if (!Directory.Exists(destinationFolderPath))
                Directory.CreateDirectory(destinationFolderPath);

            foreach (var fileInfo in new DirectoryInfo(destinationFolderPath).GetFiles(fileName + "*.csv"))
            {
                fileInfo.Delete();
            }

            var destinationFileName = destinationFolderPath + "\\" + fileName + "_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";

            _logger.Info(string.Format("Corporate Tag: {0} Create CSV at Path: {1} ", account.Tag, destinationFileName));

            WriteCsv(destinationFileName, list);
        }

        private void WriteCsv(string csvFilePath, IEnumerable<BcbsMiHomeVisitRequestViewModel> modelData)
        {
            using (var streamWriter = new StreamWriter(csvFilePath, false))
            {
                var members = (typeof(BcbsMiHomeVisitRequestViewModel)).GetMembers();

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
                            if (propInfo.PropertyType == typeof(IEnumerable<string>))
                            {
                                values.Add(string.Empty);
                                continue;
                            }
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
                        else if (memberInfo.Name == "Zip")
                        {
                            values.Add("=" + sanitizer.EscapeString(obj.ToString()));
                        }
                        else if (formatter != null)
                            values.Add(formatter.ToString(obj));
                        else
                            values.Add(sanitizer.EscapeString(obj.ToString()));
                    }
                    streamWriter.Write(string.Join(",", values.ToArray()) + Environment.NewLine);
                }
                streamWriter.Close();
            }
        }

        private void DeleteIffileExist(string destinationPath, int year)
        {
            var files = DirectoryOperationsHelper.GetFiles(destinationPath, "*.csv");

            foreach (var file in files)
            {
                if (!string.IsNullOrEmpty(file) && file.Contains("HomeVisitRequested_") && file.Contains("_" + year))
                {
                    if (DirectoryOperationsHelper.IsFileExist(file))
                        DirectoryOperationsHelper.Delete(file);
                }

            }
        }

    }
}
