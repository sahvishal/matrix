using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using DateTime = System.DateTime;
using Falcon.App.Core.Application.Helper;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class BcbsMiIncorrectPhoneExportPollingAgent : IBcbsMiIncorrectPhoneExportPollingAgent
    {
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateCustomerCustomTagRepository _corporateCustomerCustomTagRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IHealthPlanExportCustomerViewModelFactory _healthPlanExportCustomerViewModelFactory;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IXmlSerializer<DateAddedXml> _dateAddedSettingManager;
        private readonly ILogger _logger;
        private readonly DateTime _cutOffDate;
        private readonly DayOfWeek _dayOfWeek;
        private readonly string[] _bcbsMiRiskPatientTags;
        private readonly string[] _bcbsMiGapPatinetTags;
        private readonly long _bcbsMiAccountId;
        private readonly string _bcbsMiFolderPath;
        private readonly string _incorrectPhoneNumber;
        private readonly string _BcbsmiDateAddedIncorrectPhoneNumberSettingPath;

        private const int PageSize = 100;

        public BcbsMiIncorrectPhoneExportPollingAgent(ILogManager logManager, ISettings settings, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, ICustomerRepository customerRepository,
            ICorporateCustomerCustomTagRepository corporateCustomerCustomTagRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, IHealthPlanExportCustomerViewModelFactory healthPlanExportCustomerViewModelFactory,
            ICustomSettingManager customSettingManager, IXmlSerializer<DateAddedXml> dateAddedSettingManager)
        {
            _corporateAccountRepository = corporateAccountRepository;
            _customerRepository = customerRepository;
            _corporateCustomerCustomTagRepository = corporateCustomerCustomTagRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _healthPlanExportCustomerViewModelFactory = healthPlanExportCustomerViewModelFactory;
            _customSettingManager = customSettingManager;
            _logger = logManager.GetLogger("BCBS_MI_Incorrect_Phone_Export");
            _cutOffDate = settings.PcpDownloadCutOfDate;
            _dayOfWeek = settings.BcbsMiIncorrectPhoneExportDay;
            _bcbsMiRiskPatientTags = settings.BcbsMiRiskPatientTags;
            _bcbsMiGapPatinetTags = settings.BcbsMiGapPatinetTags;
            _bcbsMiAccountId = settings.BcbsMiAccountId;
            _bcbsMiFolderPath = settings.BcbsMiResultReportDownloadPath;
            _incorrectPhoneNumber = settings.BcbsmiIncorrectPhoneNumberSettingPath;
            _BcbsmiDateAddedIncorrectPhoneNumberSettingPath = settings.BcbsmiDateAddedIncorrectPhoneNumberSettingPath;
            _dateAddedSettingManager = dateAddedSettingManager;
        }

        public void PollForExport()
        {
            try
            {
                if (DateTime.Today.DayOfWeek != _dayOfWeek)
                {
                    _logger.Info("Day of the week is " + DateTime.Today.DayOfWeek);
                    _logger.Info("The job runs every " + _dayOfWeek);
                    return;
                }

                var corporateAccount = _corporateAccountRepository.GetById(_bcbsMiAccountId);
                var serviceReportSettings = string.Format(_incorrectPhoneNumber, corporateAccount.Tag);
                var customSettings = _customSettingManager.Deserialize(serviceReportSettings);

                var directoryPath = string.Format(_bcbsMiFolderPath, corporateAccount.FolderName);

                var fromDate = (customSettings.LastTransactionDate != null) ? new DateTime(customSettings.LastTransactionDate.Value.Year, 1, 1) : _cutOffDate;
                var toDate = DateTime.Now;

                if (fromDate.Year == toDate.Year)
                {
                    DeleteIffileExist(directoryPath, toDate.Year);

                    //IncorrectPhoneNumberReportForRiskPatient(corporateAccount, fromDate, toDate);
                    IncorrectPhoneNumberReportForGapPatient(corporateAccount, fromDate, toDate);
                    //IncorrectPhoneNumberReportForNormalPatient(corporateAccount, fromDate, toDate);
                }
                else if (fromDate.Year < DateTime.Today.Year)
                {
                    toDate = new DateTime(fromDate.Year, 12, 31);

                    while (true)
                    {
                        DeleteIffileExist(directoryPath, toDate.Year);

                        //IncorrectPhoneNumberReportForRiskPatient(corporateAccount, fromDate, toDate);
                        IncorrectPhoneNumberReportForGapPatient(corporateAccount, fromDate, toDate);
                        //IncorrectPhoneNumberReportForNormalPatient(corporateAccount, fromDate, toDate);

                        fromDate = new DateTime((fromDate.Year + 1), 1, 1);

                        toDate = DateTime.Now;

                        if (fromDate.Year < DateTime.Today.Year)
                            toDate = new DateTime(fromDate.Year, 12, 31);

                        if (fromDate.Year > DateTime.Today.Year)
                            break;
                    }
                }


                _logger.Info(" Starting BCBS MI Incorrect Phone Number Report generation.");

                customSettings.LastTransactionDate = toDate;
                _customSettingManager.SerializeandSave(serviceReportSettings, customSettings);
                _logger.Info("BCBS MI Incorrect Phone Number Report completed.");

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while generating BCBS MI Incorrect Phone Number Report.\n Message : {0} \n Stack Trace : {1}", ex.Message, ex.StackTrace));
            }
        }

        private void IncorrectPhoneNumberReportForRiskPatient(CorporateAccount account, DateTime fromDate, DateTime toDate)
        {
            var filter = new HealthPlanCustomerIncorrectPhoneExportFilter
            {
                CorporateTag = account.Tag,
                StartDate = fromDate,
                EndDate = toDate,
                CustomTags = _bcbsMiRiskPatientTags
            };

            var dateAddedXmlFile = string.Format(_BcbsmiDateAddedIncorrectPhoneNumberSettingPath, account.Tag, "R_IncorrectPhoneNumber_" + Convert.ToString(toDate.Year));
            var dateAddedSettings = _dateAddedSettingManager.Deserialize(dateAddedXmlFile);
            dateAddedSettings = (dateAddedSettings == null || dateAddedSettings.AddedDate.IsNullOrEmpty()) ? new DateAddedXml { AddedDate = new List<DateAddedSettings>() } : dateAddedSettings;


            _logger.Info(string.Format("Starting Risk Patient for Corporate Tag: {0} StartDate: {1}", filter.CorporateTag, filter.StartDate.ToShortDateString()));

            IncorrectPhoneNumberReport("R_IncorrectPhoneNumber", account, filter, dateAddedSettings.AddedDate);

            _logger.Info(string.Format("Completed Risk Patient for Corporate Tag: {0} StartDate: {1}\n", filter.CorporateTag, filter.StartDate.ToShortDateString()));
        }

        private void IncorrectPhoneNumberReportForGapPatient(CorporateAccount account, DateTime fromDate, DateTime toDate)
        {
            var filter = new HealthPlanCustomerIncorrectPhoneExportFilter
            {
                CorporateTag = account.Tag,
                StartDate = fromDate,
                EndDate = toDate,
                CustomTags = _bcbsMiGapPatinetTags
            };

            var dateAddedXmlFile = string.Format(_BcbsmiDateAddedIncorrectPhoneNumberSettingPath, account.Tag, "Q_IncorrectPhoneNumber_" + Convert.ToString(toDate.Year));
            var dateAddedSettings = _dateAddedSettingManager.Deserialize(dateAddedXmlFile);
            dateAddedSettings = (dateAddedSettings == null || dateAddedSettings.AddedDate.IsNullOrEmpty()) ? new DateAddedXml { AddedDate = new List<DateAddedSettings>() } : dateAddedSettings;

            _logger.Info(string.Format("Starting Gap Patient for Corporate Tag: {0} StartDate: {1}", filter.CorporateTag, filter.StartDate.ToShortDateString()));

            IncorrectPhoneNumberReport("Q_MOBILE_IncorrectPhoneNumber", account, filter, dateAddedSettings.AddedDate);

            _logger.Info(string.Format("Completed Gap Patient for Corporate Tag: {0} StartDate: {1}\n", filter.CorporateTag, filter.StartDate.ToShortDateString()));

        }

        private void IncorrectPhoneNumberReportForNormalPatient(CorporateAccount account, DateTime fromDate, DateTime toDate)
        {
            var tagToExlude = new List<string>();
            if (!_bcbsMiGapPatinetTags.IsNullOrEmpty())
                tagToExlude.AddRange(_bcbsMiGapPatinetTags);

            if (!_bcbsMiRiskPatientTags.IsNullOrEmpty())
                tagToExlude.AddRange(_bcbsMiRiskPatientTags);

            var filter = new HealthPlanCustomerIncorrectPhoneExportFilter
            {
                CorporateTag = account.Tag,
                StartDate = fromDate,
                EndDate = toDate,
                CustomTags = tagToExlude.ToArray(),
                ExcludeCustomerWithCustomTag = true
            };

            var dateAddedXmlFile = string.Format(_BcbsmiDateAddedIncorrectPhoneNumberSettingPath, account.Tag, "IncorrectPhoneNumber_" + Convert.ToString(toDate.Year));
            var dateAddedSettings = _dateAddedSettingManager.Deserialize(dateAddedXmlFile);
            dateAddedSettings = (dateAddedSettings == null || dateAddedSettings.AddedDate.IsNullOrEmpty()) ? new DateAddedXml { AddedDate = new List<DateAddedSettings>() } : dateAddedSettings;

            _logger.Info(string.Format("Starting Normal Patient for Corporate Tag: {0} StartDate: {1}", filter.CorporateTag, filter.StartDate.ToShortDateString()));

            IncorrectPhoneNumberReport("IncorrectPhoneNumber", account, filter, dateAddedSettings.AddedDate);

            _logger.Info(string.Format("Completed Normal Patient for Corporate Tag: {0} StartDate: {1}\n", filter.CorporateTag, filter.StartDate.ToShortDateString()));
        }

        private void IncorrectPhoneNumberReport(string fileName, CorporateAccount account, HealthPlanCustomerIncorrectPhoneExportFilter filter, List<DateAddedSettings> dateAddedSettings)
        {
            var list = new List<BcbsMiIncorrectPhoneViewModel>();
            var pageNumber = 1;

            while (true)
            {
                int totalRecords;
                var customers = _customerRepository.GetHealthPlanIncorrectPhoneCustomerExport(filter, pageNumber, PageSize, out totalRecords);

                _logger.Info(string.Format("Corporate Tag: {0} StartDate: {1} Total Customer Found: {2} PageNumber {3} ", filter.CorporateTag, filter.StartDate.ToShortDateString(), totalRecords, pageNumber));

                if (customers == null || !customers.Any()) break;

                var customerIds = customers.Select(x => x.CustomerId).ToArray();
                var corporateTags = _corporateCustomerCustomTagRepository.GetByCustomerIds(customerIds);

                var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(customerIds);

                var model = _healthPlanExportCustomerViewModelFactory.CreateIncorrectPhoneListForBcbsMi(customers, corporateTags, primaryCarePhysicians, dateAddedSettings);

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

            GenerateReport(fileName, account, list, filter.EndDate.Value);

        }

        private void GenerateReport(string fileName, CorporateAccount account, IEnumerable<BcbsMiIncorrectPhoneViewModel> list, DateTime toDate)
        {
            var destinationFolderPath = string.Format(_bcbsMiFolderPath, account.FolderName);

            DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationFolderPath);

            var destinationFileName = destinationFolderPath + "\\" + fileName + "_" + toDate.ToString("yyyyMMdd") + ".csv";

            _logger.Info(string.Format("Corporate Tag: {0} Create CSV at Path: {1} ", account.Tag, destinationFileName));


            WriteCsv(destinationFileName, list);

            WriteXmlFile(list, account.Tag, fileName, toDate);

        }

        private void WriteCsv(string csvFilePath, IEnumerable<BcbsMiIncorrectPhoneViewModel> modelData)
        {

            using (var streamWriter = new StreamWriter(csvFilePath, false))
            {
                var members = (typeof(BcbsMiIncorrectPhoneViewModel)).GetMembers();

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

        private void WriteXmlFile(IEnumerable<BcbsMiIncorrectPhoneViewModel> list, string tag, string fileName, DateTime toDate)
        {
            var dateAddedSetting = (from d in list
                                    select new DateAddedSettings
                                    {
                                        CustomerId = d.CustomerId,
                                        AddedDate = d.DateAddedtoReport
                                    }).ToList();

            DateAddedXml dateAddedXml = new DateAddedXml();
            dateAddedXml.AddedDate = dateAddedSetting;

            var dateAddedXmlFile = string.Format(_BcbsmiDateAddedIncorrectPhoneNumberSettingPath, tag, fileName + "_" + Convert.ToString(toDate.Year));
            _dateAddedSettingManager.SerializeandSave(dateAddedXmlFile, dateAddedXml);

        }

        private void DeleteIffileExist(string destinationPath, int year)
        {
            var files = DirectoryOperationsHelper.GetFiles(destinationPath, "*.csv");

            foreach (var file in files)
            {
                if (!string.IsNullOrEmpty(file) && file.Contains("IncorrectPhoneNumber_") && file.Contains("_" + year))
                {
                    if (DirectoryOperationsHelper.IsFileExist(file))
                        DirectoryOperationsHelper.Delete(file);
                }

            }
        }
    }
}
