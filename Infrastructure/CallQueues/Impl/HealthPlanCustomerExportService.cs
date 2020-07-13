using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;

//using DateTime = System.DateTime;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HealthPlanCustomerExportService : IHealthPlanCustomerExportService
    {
        private readonly ICustomerRepository _customerRepository;

        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICorporateCustomerCustomTagRepository _corporateCustomerCustomTagRepository;
        private readonly IHealthPlanExportCustomerViewModelFactory _exportCustomerViewModelFactory;
        private readonly ISettings _settings;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;

        private readonly int _pageSizeHealthPlanExport;

        private readonly long _martinsPointExclusiveAccountId;
        private readonly DayOfWeek _dayOfWeek;

        public HealthPlanCustomerExportService(ICorporateAccountRepository corporateAccountRepository, ICustomerRepository customerRepository, ICorporateCustomerCustomTagRepository corporateCustomerCustomTagRepository,
            IHealthPlanExportCustomerViewModelFactory exportCustomerViewModelFactory, ISettings settings, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, ISftpCridentialManager sftpCridentialManager)
        {

            _corporateAccountRepository = corporateAccountRepository;
            _customerRepository = customerRepository;
            _corporateCustomerCustomTagRepository = corporateCustomerCustomTagRepository;
            _exportCustomerViewModelFactory = exportCustomerViewModelFactory;
            _settings = settings;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;

            _pageSizeHealthPlanExport = settings.PageSizeHealthPlanExport;
            _martinsPointExclusiveAccountId = settings.MartinsPointExclusiveAccountId;
            _dayOfWeek = settings.HealthPlanCustomerExportIntervalDay;
        }

        public void HealthPlanIncorrectPhoneCustomerExport(DateTime cutOffDate, string destinationFileFormate, ILogger logger)
        {
            var healthPlans = _corporateAccountRepository.GetAllHealthPlan();
            if (healthPlans.IsNullOrEmpty())
            {
                logger.Info("No Healthplan exists");
                return;
            }

            if (!_settings.DoNotSendHomeVistIncorrectPhoneNumberAccountIds.IsNullOrEmpty())
            {
                healthPlans = healthPlans.Where(hp => !_settings.DoNotSendHomeVistIncorrectPhoneNumberAccountIds.Contains(hp.Id));
            }

            logger.Info("Starting Corporate Customer Export for Incorrect Phone Number");

            foreach (var corporateAccount in healthPlans)
            {
                if ((corporateAccount.Id == _settings.WellmedAccountId || corporateAccount.Id == _settings.WellmedTxAccountId))
                {
                    if (DateTime.Today.DayOfWeek != _settings.WellmedIncorrectPhoneNumberDayOfWeek)
                    {
                        logger.Info("Day of the week is " + ((long)DateTime.Today.DayOfWeek) + " Account Id: " + corporateAccount.Id);
                        continue;
                    }
                }
                //else if (corporateAccount.Id == _settings.HcpNvAccountId)
                //{
                //    if ((long)DateTime.Today.DayOfWeek != _settings.HcpNvIncorrectPhoneNumberDayOfWeek)
                //    {
                //        logger.Info("Today is Day of Week is " + DateTime.Today.DayOfWeek);
                //        logger.Info("Service will run on Day of Week " +
                //                     (DayOfWeek)_settings.HcpNvIncorrectPhoneNumberDayOfWeek);
                //        continue;
                //    }
                //}
                else if (DateTime.Today.DayOfWeek != _dayOfWeek)
                {
                    logger.Info("Day of the week is " + ((long)DateTime.Today.DayOfWeek) + " Account Id: " + corporateAccount.Id);
                    continue;
                }
                
                    
                var filter = new HealthPlanCustomerIncorrectPhoneExportFilter
                {
                    CorporateTag = corporateAccount.Tag,
                    StartDate = cutOffDate
                };

                if (corporateAccount.Id == _settings.HealthNowAccountId)
                {
                    filter.CustomTags = _settings.HealthNowCustomTags;
                }
                else if (corporateAccount.Id == _settings.ExcellusAccountId)
                {
                    filter.CustomTags = _settings.ExcellusCustomTags;
                }

                logger.Info(string.Format("Starting for Corporate Tag: {0} StartDate: {1}", filter.CorporateTag, filter.StartDate.ToShortDateString()));

                var list = IncorrectPhoneNumberExportReport(filter, logger);

                if (!list.Any()) continue;

                var destinationFolderPath = string.Format(destinationFileFormate, corporateAccount.FolderName, DateTime.Today.Year);

                var fileName = "IncorrectPhoneNumber.csv";

                if (_settings.OptumIncorrectPhoneNumberAccountIds.Contains(corporateAccount.Id))
                {
                    destinationFolderPath = string.Format(_settings.OptumIncorrectPhoneNumberDownloadPath, corporateAccount.FolderName);
                    fileName = "IncorrectPhoneNumber" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                }
                else if (corporateAccount.Id == _martinsPointExclusiveAccountId)
                {
                    fileName = "Exclusive_IncorrectPhoneNumber.csv";
                }
                else if (corporateAccount.Id == _settings.ExcellusAccountId)
                {
                    destinationFolderPath = Directory.GetParent(destinationFolderPath).FullName;
                    fileName = "IncorrectPhoneNumber_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                }
                else if (corporateAccount.Id == _settings.HealthNowAccountId)
                {
                    destinationFolderPath = string.Format(_settings.HealthPlanDownloadPath, corporateAccount.FolderName);
                    fileName = "IncorrectPhoneNumber_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                    DirectoryOperationsHelper.DeleteFiles(destinationFolderPath, "IncorrectPhoneNumber*.csv");
                }
                else if (corporateAccount.Id == _settings.MedMutualAccountId)
                {
                    destinationFolderPath = string.Format(_settings.HealthPlanDownloadPath, corporateAccount.FolderName);
                    fileName = "IncorrectPhoneNumbers_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                    DirectoryOperationsHelper.DeleteFiles(destinationFolderPath, "IncorrectPhoneNumbers*.csv");
                }
                else if (corporateAccount.Id == _settings.WellmedWellCareAccountId)
                {
                    var wellmedAccount = healthPlans.FirstOrDefault(x => x.Id == _settings.WellmedAccountId);
                    if (wellmedAccount != null)
                    {
                        destinationFolderPath = string.Format(destinationFileFormate, wellmedAccount.FolderName, DateTime.Today.Year);

                        fileName = "WCR_IncorrectPhoneNumbers_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                    }

                    DirectoryOperationsHelper.DeleteFiles(destinationFolderPath, "WCR_IncorrectPhoneNumbers*.csv");
                }
                else if (corporateAccount.Id == _settings.ConnecticareAccountId)
                {
                    destinationFolderPath = string.Format(_settings.HealthPlanDownloadPath, corporateAccount.FolderName);
                    fileName = "Comm Incorrect Phone Number " + DateTime.Today.ToString("yyyy-MM-dd") + ".csv";
                }
                else if (corporateAccount.Id == _settings.ConnecticareMaAccountId)
                {
                    destinationFolderPath = string.Format(_settings.HealthPlanDownloadPath, corporateAccount.FolderName);
                    fileName = "MCR Incorrect Phone Number " + DateTime.Today.ToString("yyyy-MM-dd") + ".csv";
                }
                else if (corporateAccount.Id == _settings.BcbsScAccountId || corporateAccount.Id == _settings.BcbsScAssessmentAccountId)
                {
                    destinationFolderPath = string.Format(_settings.HealthPlanExportRootPath, corporateAccount.FolderName);
                }
                else if (corporateAccount.Id == _settings.FloridaBlueFepAccountId)
                {
                    destinationFolderPath = Path.Combine(string.Format(_settings.HealthPlanDownloadPath, corporateAccount.FolderName), "Reports");
                    fileName = "IncorrectPhoneNumber_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                    DirectoryOperationsHelper.DeleteFiles(destinationFolderPath, "IncorrectPhoneNumber*.csv");
                }
                else if (corporateAccount.Id == _settings.PPAccountId)
                {
                    logger.Info("PP Account");
                    destinationFolderPath = string.Format(_settings.HealthPlanDownloadPath, corporateAccount.FolderName);
                    fileName = "IncorrectPhoneNumber_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                }
                else if (corporateAccount.Id == _settings.NammAccountId)
                {
                    logger.Info("Namm Account Id");
                    destinationFolderPath = string.Format(_settings.HealthPlanExportRootPath, corporateAccount.FolderName);
                    fileName = "IncorrectPhoneNumber_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                }
                //else if (corporateAccount.Id == _settings.HcpNvAccountId)
                //{
                   
                //    logger.Info("HCP NV");
                //    var folderName = _settings.HcpNvFolder;
                //    destinationFolderPath = Path.Combine(string.Format(_settings.OutTakeReportPath, folderName), "IncorrectPhone");
                //    fileName = string.Format("IncorrectPhoneNumber_{0}_{1}_{2}.csv", corporateAccount.AcesClientShortName, folderName, DateTime.Today.ToString("MMddyyyy"));
                //}
                else if (corporateAccount.Id == _settings.WellmedAccountId)
                {
                    logger.Info("Wellmed FL");
                    var folderName = _settings.WellmedFlFolder;
                    destinationFolderPath = Path.Combine(string.Format(_settings.OutTakeReportPath, folderName), "IncorrectPhone");
                    fileName = string.Format("IncorrectPhoneNumber_{0}_{1}_{2}.csv", corporateAccount.AcesClientShortName, folderName, DateTime.Today.ToString("MMddyyyy"));
                }
                else if (corporateAccount.Id == _settings.WellmedTxAccountId)
                {
                    logger.Info("Wellmed TX");
                    var folderName = _settings.WellmedTxFolder;
                    destinationFolderPath = Path.Combine(string.Format(_settings.OutTakeReportPath, folderName), "IncorrectPhone");
                    fileName = string.Format("IncorrectPhoneNumber_{0}_{1}_{2}.csv", corporateAccount.AcesClientShortName, folderName, DateTime.Today.ToString("MMddyyyy"));
                }

                if (_settings.OptumAccountIds.Contains(corporateAccount.Id))
                {
                    try
                    {
                        DirectoryOperationsHelper.DeleteDirectory(destinationFolderPath, true);
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Some error occurred while deleting directory at path: " + destinationFolderPath);
                        logger.Error("Message: " + ex.Message);
                        logger.Error("Stack Trace: " + ex.StackTrace);
                    }
                }

                if (!Directory.Exists(destinationFolderPath))
                    Directory.CreateDirectory(destinationFolderPath);

                var destinationFileName = Path.Combine(destinationFolderPath, fileName);

                if (File.Exists(destinationFileName))
                    File.Delete(destinationFileName);

                logger.Info(string.Format("Corporate Tag: {0} StartDate: {1} Create CSV at Path: {2} ", filter.CorporateTag, filter.StartDate.ToShortDateString(), destinationFileName));

                WriteCsv(destinationFileName, list, logger);

                //if (File.Exists(destinationFileName))
                //{
                //    if (corporateAccount.Id == _settings.FloridaBlueFepAccountId && _settings.SendReportToFloridaBlueSftp)
                //    {
                //        var destinationSftpPath = _settings.FloridaBlueSftpPath + "\\" + corporateAccount.FolderName + "\\Download\\Reports";
                //        PostFile(destinationFileName, destinationSftpPath, _settings.FloridaBlueSftpHost, _settings.FloridaBlueSftpUserName, _settings.FloridaBlueSftpPassword, fileName, logger);
                //    }
                //    else
                //    {
                //        SendIncorrectPhoneNumberClientSftp(corporateAccount, destinationFileName, logger);
                //    }

                //}
            }
        }


        public void AnthemHomeVisitRequestedCustomerExport(HealthPlanCustomerExportFilter filter, string destinationFolderPath, string fileName, ILogger logger)
        {
            logger.Info(string.Format("Starting for Corporate Tag: {0} StartDate: {1}", filter.CorporateTag, filter.StartDate.ToShortDateString()));

            var list = HomeVisitExportCustomerReport(filter, logger);

            if (!list.Any()) return;

            if (!Directory.Exists(destinationFolderPath))
                Directory.CreateDirectory(destinationFolderPath);

            var destinationFileName = Path.Combine(destinationFolderPath, fileName);

            if (File.Exists(destinationFileName))
                File.Delete(destinationFileName);

            logger.Info(string.Format("Corporate Tag: {0} StartDate: {1} Create CSV at Path: {2} ", filter.CorporateTag, filter.StartDate.ToShortDateString(), destinationFileName));

            WriteCsv(destinationFileName, list, logger);
        }


        public void AnthemIncorrectPhoneNumbreCustomerExport(HealthPlanCustomerExportFilter filter, string destinationFolderPath, string fileName, ILogger logger)
        {
            logger.Info(string.Format("Starting for Corporate Tag: {0} StartDate: {1}", filter.CorporateTag, filter.StartDate.ToShortDateString()));

            var filterforincorrectPhone = new HealthPlanCustomerIncorrectPhoneExportFilter
            {
                CorporateTag = filter.CorporateTag,
                CustomTags = filter.CustomTags,
                ExcludeCustomerWithCustomTag = filter.ExcludeCustomerWithCustomTag,
                StartDate = filter.StartDate
            };


            var list = IncorrectPhoneNumberExportReport(filterforincorrectPhone, logger);

            if (!list.Any()) return;

            if (!Directory.Exists(destinationFolderPath))
                Directory.CreateDirectory(destinationFolderPath);

            var destinationFileName = Path.Combine(destinationFolderPath, fileName);

            if (File.Exists(destinationFileName))
                File.Delete(destinationFileName);

            logger.Info(string.Format("Corporate Tag: {0} StartDate: {1} Create CSV at Path: {2} ", filter.CorporateTag, filter.StartDate.ToShortDateString(), destinationFileName));

            WriteCsv(destinationFileName, list, logger);
        }


        public void HealthPlanHomeVisitRequestedCustomerExport(DateTime cutOffDate, string destinationFileFormate, ILogger logger)
        {
            var healthPlans = _corporateAccountRepository.GetAllHealthPlan();
            if (healthPlans.IsNullOrEmpty())
            {
                logger.Info("No Healthplan exists");
                return;
            }

            if (!_settings.DoNotSendHomeVistIncorrectPhoneNumberAccountIds.IsNullOrEmpty())
            {
                healthPlans = healthPlans.Where(hp => !_settings.DoNotSendHomeVistIncorrectPhoneNumberAccountIds.Contains(hp.Id));
            }

            logger.Info("Starting Corporate Customer Export for Home Vist Requested");

            foreach (var corporateAccount in healthPlans)
            {
                var filter = new HealthPlanCustomerExportFilter
                {
                    CallStatus = CallStatus.Attended,
                    CorporateTag = corporateAccount.Tag,
                    StartDate = cutOffDate,
                    Tag = ProspectCustomerTag.HomeVisitRequested
                };

                if (corporateAccount.Id == _settings.HealthNowAccountId)
                {
                    filter.CustomTags = _settings.HealthNowCustomTags;
                }

                if (corporateAccount.Id == _settings.ExcellusAccountId)
                {
                    filter.CustomTags = _settings.ExcellusCustomTags;
                }

                logger.Info(string.Format("Starting for Corporate Tag: {0} StartDate: {1}", filter.CorporateTag, filter.StartDate.ToShortDateString()));

                var list = HomeVisitExportCustomerReport(filter, logger);

                if (!list.Any()) continue;

                var destinationFolderPath = string.Format(destinationFileFormate, corporateAccount.FolderName, DateTime.Today.Year);

                var fileName = "HomeVisitRequested.csv";

                if (_settings.OptumHomeVisitRequesedAccountIds.Contains(corporateAccount.Id))
                {
                    destinationFolderPath = string.Format(_settings.OptumHomeVisitRequesedDownloadPath, corporateAccount.FolderName);
                    fileName = "HomeVisitRequested" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                }
                else if (corporateAccount.Id == _martinsPointExclusiveAccountId)
                {
                    fileName = "Exclusive_HomeVisitRequested.csv";
                }
                else if (corporateAccount.Id == _settings.ExcellusAccountId)
                {
                    destinationFolderPath = Directory.GetParent(destinationFolderPath).FullName;
                    fileName = "HomeVisitRequest_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                }
                else if (corporateAccount.Id == _settings.HealthNowAccountId)
                {
                    destinationFolderPath = string.Format(_settings.HealthPlanDownloadPath, corporateAccount.FolderName);
                    fileName = "HomeVisitRequest_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                    DirectoryOperationsHelper.DeleteFiles(destinationFolderPath, "HomeVisitRequest*.csv");
                }
                else if (corporateAccount.Id == _settings.MedMutualAccountId)
                {
                    destinationFolderPath = string.Format(_settings.HealthPlanDownloadPath, corporateAccount.FolderName);
                    fileName = "HomeVisitRequest_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                    DirectoryOperationsHelper.DeleteFiles(destinationFolderPath, "HomeVisitRequest*.csv");
                }
                else if (corporateAccount.Id == _settings.WellmedWellCareAccountId)
                {
                    var wellmedAccount = healthPlans.FirstOrDefault(x => x.Id == _settings.WellmedAccountId);
                    if (wellmedAccount != null)
                    {
                        destinationFolderPath = string.Format(destinationFileFormate, wellmedAccount.FolderName, DateTime.Today.Year);

                        fileName = "WCR_HomeVisitRequest_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                    }

                    DirectoryOperationsHelper.DeleteFiles(destinationFolderPath, "WCR_HomeVisitRequest*.csv");
                }
                else if (corporateAccount.Id == _settings.ConnecticareAccountId)
                {
                    destinationFolderPath = string.Format(_settings.HealthPlanDownloadPath, corporateAccount.FolderName);
                    fileName = "Comm Home Visit Req " + DateTime.Today.ToString("yyyy-MM-dd") + ".csv";
                }
                else if (corporateAccount.Id == _settings.ConnecticareMaAccountId)
                {
                    destinationFolderPath = string.Format(_settings.HealthPlanDownloadPath, corporateAccount.FolderName);
                    fileName = "MCR Home Visit Req " + DateTime.Today.ToString("yyyy-MM-dd") + ".csv";
                }
                else if (corporateAccount.Id == _settings.BcbsScAssessmentAccountId)
                {
                    destinationFolderPath = string.Format(_settings.HealthPlanExportRootPath, corporateAccount.FolderName);
                }
                else if (corporateAccount.Id == _settings.PPAccountId)
                {
                    destinationFolderPath = string.Format(_settings.HealthPlanDownloadPath, corporateAccount.FolderName);
                    fileName = "HomeVisitRequest_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                }
                else if (corporateAccount.Id == _settings.NammAccountId)
                {
                    destinationFolderPath = string.Format(_settings.HealthPlanExportRootPath, corporateAccount.FolderName);
                    fileName = "HomeVisitRequest_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
                }
                //else if (corporateAccount.Id == _settings.BcbsScAccountId)
                //{
                //    var folder = _settings.BcbsScFolder;
                //    destinationFolderPath = Path.Combine(string.Format(_settings.OutTakeReportPath, folder), "HomeVisitRequest");
                //    fileName = string.Format("HomeVisitRequest_{0}_{1}_{2}.csv", corporateAccount.AcesClientShortName, folder, DateTime.Today.ToString("MMddyyyy"));
                //}

                if (_settings.OptumAccountIds.Contains(corporateAccount.Id))
                {
                    try
                    {
                        DirectoryOperationsHelper.DeleteDirectory(destinationFolderPath, true);
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Some error occurred while deleting directory at path: " + destinationFolderPath);
                        logger.Error("Message: " + ex.Message);
                        logger.Error("Stack Trace: " + ex.StackTrace);
                    }
                }

                if (!Directory.Exists(destinationFolderPath))
                    Directory.CreateDirectory(destinationFolderPath);

                var destinationFileName = Path.Combine(destinationFolderPath, fileName);

                if (File.Exists(destinationFileName))
                    File.Delete(destinationFileName);

                logger.Info(string.Format("Corporate Tag: {0} StartDate: {1} Create CSV at Path: {2} ", filter.CorporateTag, filter.StartDate.ToShortDateString(), destinationFileName));

                WriteCsv(destinationFileName, list, logger);

                //if (File.Exists(destinationFileName))
                //{
                //    SendHomevisitRequestToClientSftp(corporateAccount, destinationFileName, logger);
                //}
            }
        }


        private IEnumerable<HealthPlanExportCustomerViewModel> HomeVisitExportCustomerReport(HealthPlanCustomerExportFilter filter, ILogger logger)
        {
            var list = new List<HealthPlanExportCustomerViewModel>();
            var pageNumber = 1;

            while (true)
            {
                int totalRecords;
                var customers = _customerRepository.HealthPlanHomeVisitRequestedCustomerExport(filter, pageNumber, _pageSizeHealthPlanExport, out totalRecords);

                if (customers == null || !customers.Any()) break;

                var customerIds = customers.Select(x => x.CustomerId).ToArray();
                var corporateTags = _corporateCustomerCustomTagRepository.GetByCustomerIds(customerIds);

                var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(customerIds);

                var model = _exportCustomerViewModelFactory.Create(customers, corporateTags, primaryCarePhysicians);

                list.AddRange(model);

                logger.Info(string.Format("Page Number {0} Total Records {1}", pageNumber, totalRecords));

                pageNumber++;

                if (list.Count >= totalRecords)
                    break;
            }

            return list;
        }

        private IEnumerable<HealthPlanExportCustomerViewModel> IncorrectPhoneNumberExportReport(HealthPlanCustomerIncorrectPhoneExportFilter filter, ILogger logger)
        {
            var list = new List<HealthPlanExportCustomerViewModel>();
            var pageNumber = 1;


            while (true)
            {
                int totalRecords;
                var customers = _customerRepository.GetHealthPlanIncorrectPhoneCustomerExport(filter, pageNumber, _pageSizeHealthPlanExport, out totalRecords);

                if (customers == null || !customers.Any()) break;

                var customerIds = customers.Select(x => x.CustomerId).ToArray();
                var corporateTags = _corporateCustomerCustomTagRepository.GetByCustomerIds(customerIds);

                var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(customerIds);

                var model = _exportCustomerViewModelFactory.Create(customers, corporateTags, primaryCarePhysicians);

                list.AddRange(model);

                logger.Info(string.Format("Page Number {0} Total Records {1}", pageNumber, totalRecords));

                pageNumber++;

                if (list.Count >= totalRecords)
                    break;
            }

            return list;
        }

        private string WriteCsv(string csvFilePath, IEnumerable<HealthPlanExportCustomerViewModel> modelData, ILogger logger)
        {
            using (var streamWriter = new StreamWriter(csvFilePath, false))
            {
                var members = (typeof(HealthPlanExportCustomerViewModel)).GetMembers();

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

            logger.Info("file Path:" + csvFilePath);

            return "CSV File Export was succesful!";
        }

        //private void ExportFileOnClintSftp(string sourcePath, string destination, SftpCridential cridential, string fileName, ILogger logger)
        //{
        //    PostFile(sourcePath, destination, cridential.HostName, cridential.UserName, cridential.Password, fileName, logger);
        //}

        //private void PostFile(string sourcePath, string destination, string hostName, string userName, string password, string fileName, ILogger logger)
        //{
        //    var processFtp = new ProcessFtp(logger, hostName, userName, password);

        //    logger.Info("Destination Path:  " + destination);
        //    logger.Info("File Name Path:  " + fileName);
        //    logger.Info("Source Path: " + sourcePath);

        //    processFtp.UploadSingleFile(sourcePath, destination, fileName);
        //}

        //private void SendIncorrectPhoneNumberClientSftp(CorporateAccount corporateAccount, string destinationFileName, ILogger logger)
        //{
        //    var sftpSettings = _sftpCridentialManager.Deserialize(_settings.SftpResouceFilePath + corporateAccount.Tag + ".xml");
        //    if (sftpSettings != null && sftpSettings.SendFileToSftp)
        //    {
        //        if (_ntspAccountIds != null && _ntspAccountIds.Contains(corporateAccount.Id))
        //        {
        //            var destinationPathOnSftp = string.Format(_destinationSftpFolderPdfPath, corporateAccount.FolderName);
        //            destinationPathOnSftp = destinationPathOnSftp + "/" + "IncorrectPhoneNumber";

        //            ExportFileOnClintSftp(destinationFileName, destinationPathOnSftp, sftpSettings, "IncorrectPhoneNumber.csv", logger);
        //        }
        //        else if (corporateAccount.Id == _bcbsMnAccountId)
        //        {
        //            var fileName = string.Format("IncorrectPhoneNumber_{0}.csv", DateTime.Today.ToString("MMddyyyy"));
        //            ExportFileOnClintSftp(destinationFileName, _bcbsSftpFolderPath, sftpSettings, fileName, logger);
        //        }
        //        else if (_settings.HcpNvAccountId == corporateAccount.Id)
        //        {
        //            var destinationPathOnSftp = (!string.IsNullOrEmpty(_settings.HcpNvSftpResultReportDownloadPath) ? _settings.HcpNvSftpResultReportDownloadPath + "/" : string.Empty) + "IncorrectPhoneNumber";
        //            var fileName = string.Format("IncorrectPhoneNumber_{0}.csv", DateTime.Today.ToString("MMddyyyy"));

        //            ExportFileOnClintSftp(destinationFileName, destinationPathOnSftp, sftpSettings, fileName, logger);
        //        }
        //        else if (_settings.BcbsAlAccountId == corporateAccount.Id)
        //        {
        //            ExportFileOnClintSftp(destinationFileName, _settings.BcbsAlSftpDownloadPath + "Reports", sftpSettings, "IncorrectPhoneNumber.csv", logger);
        //        }
        //    }
        //}

        //private void SendHomevisitRequestToClientSftp(CorporateAccount corporateAccount, string destinationFileName, ILogger logger)
        //{
        //    var sftpSettings = _sftpCridentialManager.Deserialize(_settings.SftpResouceFilePath + corporateAccount.Tag + ".xml");

        //    if (sftpSettings != null && sftpSettings.SendFileToSftp)
        //    {
        //        if (_ntspAccountIds != null && _ntspAccountIds.Contains(corporateAccount.Id))
        //        {
        //            var destinationPathOnSftp = string.Format(_destinationSftpFolderPdfPath, corporateAccount.FolderName);
        //            destinationPathOnSftp = destinationPathOnSftp + "/" + "HomeVisitRequest";

        //            ExportFileOnClintSftp(destinationFileName, destinationPathOnSftp, sftpSettings, "HomeVisitRequest.csv", logger);
        //        }
        //        else if (corporateAccount.Id == _bcbsMnAccountId)
        //        {
        //            var fileName = string.Format("HomeVisitRequest_{0}.csv", DateTime.Today.ToString("MMddyyyy"));
        //            ExportFileOnClintSftp(destinationFileName, _bcbsSftpFolderPath, sftpSettings, fileName, logger);
        //        }
        //        else if (_settings.HcpNvAccountId == corporateAccount.Id)
        //        {
        //            var fileName = string.Format("HomeVisitRequest_{0}.csv", DateTime.Today.ToString("MMddyyyy"));
        //            var destinationPathOnSftp = (!string.IsNullOrEmpty(_settings.HcpNvSftpResultReportDownloadPath) ? _settings.HcpNvSftpResultReportDownloadPath + "/" : string.Empty) + "HomeVisitRequest";
        //            ExportFileOnClintSftp(destinationFileName, destinationPathOnSftp, sftpSettings, fileName, logger);
        //        }
        //        else if (_settings.BcbsAlAccountId == corporateAccount.Id)
        //        {
        //            ExportFileOnClintSftp(destinationFileName, _settings.BcbsAlSftpDownloadPath + "Reports", sftpSettings, "HomeVisitRequested.csv", logger);
        //        }
        //    }
        //}

        public void ExcellusMedicaidHomeVisitRequestedCustomerExport(HealthPlanCustomerExportFilter filter, string destinationFolderPath, string fileName, ILogger logger)
        {
            logger.Info(string.Format("Starting for Corporate Tag: {0} StartDate: {1}", filter.CorporateTag, filter.StartDate.ToShortDateString()));

            var list = HomeVisitExportCustomerReport(filter, logger);

            if (!list.Any()) return;

            if (!Directory.Exists(destinationFolderPath))
                Directory.CreateDirectory(destinationFolderPath);

            var destinationFileName = Path.Combine(destinationFolderPath, fileName);

            if (File.Exists(destinationFileName))
                File.Delete(destinationFileName);

            logger.Info(string.Format("Corporate Tag: {0} StartDate: {1} Create CSV at Path: {2} ", filter.CorporateTag, filter.StartDate.ToShortDateString(), destinationFileName));

            WriteCsv(destinationFileName, list, logger);
        }

        public void ExcellusMedicaidIncorrectPhoneCustomerExport(HealthPlanCustomerIncorrectPhoneExportFilter filter, string destinationFolderPath, string fileName, ILogger logger)
        {
            logger.Info(string.Format("Starting for Corporate Tag: {0} StartDate: {1}", filter.CorporateTag, filter.StartDate.ToShortDateString()));

            var list = IncorrectPhoneNumberExportReport(filter, logger);

            if (!list.Any()) return;

            if (!Directory.Exists(destinationFolderPath))
                Directory.CreateDirectory(destinationFolderPath);

            var destinationFileName = Path.Combine(destinationFolderPath, fileName);

            if (File.Exists(destinationFileName))
                File.Delete(destinationFileName);

            logger.Info(string.Format("Corporate Tag: {0} StartDate: {1} Create CSV at Path: {2} ", filter.CorporateTag, filter.StartDate.ToShortDateString(), destinationFileName));

            WriteCsv(destinationFileName, list, logger);
        }
    }
}