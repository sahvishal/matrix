using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PcpResultPdfDownloadPollingAgent : IPcpResultPdfDownloadPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IZipHelper _zipHelper;
        private readonly IEventRepository _eventRepository;
        private readonly IXmlSerializer<ResultPdfPostedXml> _resultPdfPostedSerializer;
        private readonly IResultPdfFileHelper _resultPdfFileHelper;
        private readonly ISftpCridentialManager _sftpCridentialManager;
        private readonly ISettings _settings;


        private readonly IMediaRepository _mediaRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ILogger _logger;

        private readonly string _customSettingFile;
        private readonly string _destinationFolderPdfSetting;

        private readonly IEnumerable<long> _accountIds;
        private readonly DateTime _cutOfDate;
        private readonly IResultPdfDownloadPollingAgentHelper _resultPdfDownloadHelper;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly IXmlSerializer<ResultPdfNotPosted> _resultPdfNotPostedSerializer;
        private readonly IResultPdfEmailNotificationHelper _resultPdfEmailNotificationHelper;

        private readonly long _martinsPointExclusiveAccountId;
        private readonly string _resultPostedToPlanPath;

        public PcpResultPdfDownloadPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, ISettings settings, ILogManager logManager, IMediaRepository mediaRepository, ICustomSettingManager customSettingManager,
            ICorporateAccountRepository corporateAccountRepository, IResultPdfDownloadPollingAgentHelper resultPdfDownloadHelper, IPgpFileEncryptionHelper pgpFileEncryptionHelper, ICustomerRepository customerRepository, IZipHelper zipHelper,
            IEventRepository eventRepository, IXmlSerializer<ResultPdfPostedXml> resultPdfPostedSerializer, IResultPdfFileHelper resultPdfFileHelper, ISftpCridentialManager sftpCridentialManager,
            IXmlSerializer<ResultPdfNotPosted> resultPdfNotPostedSerializer, IResultPdfEmailNotificationHelper resultPdfEmailNotificationHelper)
        {
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _settings = settings;
            _mediaRepository = mediaRepository;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _resultPdfDownloadHelper = resultPdfDownloadHelper;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _customerRepository = customerRepository;
            _zipHelper = zipHelper;
            _eventRepository = eventRepository;
            _resultPdfPostedSerializer = resultPdfPostedSerializer;
            _resultPdfFileHelper = resultPdfFileHelper;
            _sftpCridentialManager = sftpCridentialManager;
            _logger = logManager.GetLogger("PCPResultPdf");

            _customSettingFile = settings.PcpResultPdfDownloadSettings;
            _destinationFolderPdfSetting = settings.PcpResultPdfDownloadPath;
            _accountIds = settings.PcpResultPdfDownloadAccountIds;
            _cutOfDate = settings.PcpDownloadCutOfDate;
            _martinsPointExclusiveAccountId = settings.MartinsPointExclusiveAccountId;
            _resultPostedToPlanPath = settings.ResultPostedToPlanPath;
            _resultPdfNotPostedSerializer = resultPdfNotPostedSerializer;
            _resultPdfEmailNotificationHelper = resultPdfEmailNotificationHelper;
        }

        public void PollForPdfDownload()
        {
            try
            {
                if (_accountIds.IsNullOrEmpty()) return;
                var corporateAccounts = _corporateAccountRepository.GetByIds(_accountIds);

                foreach (var corporateAccount in corporateAccounts)
                {
                    try
                    {
                        _logger.Info(string.Format("Generating for accountId {0} and account tag {1}. ", corporateAccount.Id, corporateAccount.Tag));

                        var destinationFolderPdf = string.Format(_destinationFolderPdfSetting, corporateAccount.FolderName);
                        var customSettingFilePath = string.Format(_customSettingFile, corporateAccount.Tag);
                        var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                        var exportToTime = DateTime.Now.AddHours(-1);
                        var exportFromTime = customSettings.LastTransactionDate ?? _cutOfDate;

                        bool inclcludeCustomTag = false;
                        string[] CustomTags = null;
                        var considerEventDate = true;

                        DateTime? eventCutOfDate = _settings.PPEventCutOfDate;

                        if (corporateAccount.Id == _settings.HealthNowAccountId)
                        {
                            CustomTags = _settings.HealthNowCustomTags;
                            inclcludeCustomTag = true;
                        }
                        if (corporateAccount.Id == _settings.ExcellusAccountId)
                        {
                            CustomTags = _settings.ExcellusCustomTags;
                            inclcludeCustomTag = true;
                        }

                        if (corporateAccount.Id == _settings.PPAccountId)
                        {
                            considerEventDate = true;
                        }

                        DateTime? stopSendingPdftoHealthPlanDate = null;
                        if (corporateAccount.IsHealthPlan)
                        {
                            stopSendingPdftoHealthPlanDate = _settings.StopSendingPdftoHealthPlanDate;
                        }

                        var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsToFax((int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false, exportToTime, exportFromTime,
                            corporateAccount.Id, corporateAccount.Tag, true, CustomTags, inclcludeCustomTag, considerEventDate, eventCutOfDate
                            , stopSendingPdftoHealthPlanDate: stopSendingPdftoHealthPlanDate);

                        var customerResults = eventCustomerResults as EventCustomerResult[] ?? eventCustomerResults.ToArray();
                        customerResults = customerResults ?? new EventCustomerResult[] { };

                        var resultNotPostedFileName = string.Format("ResultNotPostedto_{0}.xml", corporateAccount.Tag);
                        var resultNotPostedToPlanFileName = Path.Combine(_settings.ResultNotPostedToPlanPath, resultNotPostedFileName);

                        var resultNotPosted = _resultPdfNotPostedSerializer.Deserialize(resultNotPostedToPlanFileName);
                        resultNotPosted = resultNotPosted == null || resultNotPosted.EventCustomer.IsNullOrEmpty() ? new ResultPdfNotPosted { EventCustomer = new List<EventCustomerInfo>() } : resultNotPosted;

                        if (resultNotPosted.EventCustomer.Count > 0)
                        {
                            var eventCustomerIds = resultNotPosted.EventCustomer.Select(x => x.EventCustomerId);

                            if (!customerResults.IsNullOrEmpty())
                            {
                                var freshCustomerEventCustomerIds = customerResults.Select(x => x.Id);
                                eventCustomerIds = (from q in eventCustomerIds where !freshCustomerEventCustomerIds.Contains(q) select q).ToList();
                            }


                            int totalRecords = eventCustomerIds.Count();
                            int pageNumber = 0;
                            int pagesize = 100;

                            while (true)
                            {
                                if (totalRecords < 1) break;

                                var totalItems = pageNumber * pagesize;
                                var customerIds = eventCustomerIds.Skip(totalItems).Take(pagesize);
                                var resultNotPostedEventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsByIdsAndResultState(customerIds, (int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false);

                                if (!resultNotPostedEventCustomerResults.IsNullOrEmpty())
                                {
                                    var resultReports = resultNotPostedEventCustomerResults.ToArray();

                                    if (customerResults.IsNullOrEmpty())
                                        customerResults = resultReports.ToArray();
                                    else
                                        customerResults = customerResults.Concat(resultReports).ToArray();
                                }
                                pageNumber++;

                                if (totalItems >= totalRecords)
                                    break;
                            }

                        }

                        resultNotPosted.EventCustomer = !resultNotPosted.EventCustomer.IsNullOrEmpty() ? new List<EventCustomerInfo>() : resultNotPosted.EventCustomer;

                        if (eventCustomerResults == null || !customerResults.Any())
                        {
                            _logger.Info(string.Format("No event customer result list for {0} Result Pdf Download.", corporateAccount.Tag));
                            continue;
                        }

                        _logger.Info(string.Format("Found {0} customers for {1} Result Pdf Download. ", eventCustomerResults.Count(), corporateAccount.Tag));

                        var pcpResultReport = _mediaRepository.GetPdfFileNameForPcpResultReport();

                        var healthPlanResultReport = _mediaRepository.GetPdfFileNameForHealthPlanResultReport();

                        var resultPostedToPlanFileName = Path.Combine(_resultPostedToPlanPath, string.Format("ResultPostedto_{0}.xml", corporateAccount.Tag));
                        var resultPosted = _resultPdfPostedSerializer.Deserialize(resultPostedToPlanFileName);

                        resultPosted = resultPosted == null || resultPosted.Customer.IsNullOrEmpty() ? new ResultPdfPostedXml { Customer = new List<CustomerInfo>() } : resultPosted;
                        var resultPostedCustomer = new List<CustomerInfo>();

                        var healthPlanDownloadPath = Path.Combine(string.Format(_settings.HealthPlanDownloadPath, corporateAccount.FolderName), string.Format("ResultPDFs_{0}", DateTime.Now.ToString("yyyyMMdd")));

                        foreach (var ecr in customerResults)
                        {
                            var sourceUrl = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + healthPlanResultReport;

                            if (!DirectoryOperationsHelper.IsFileExist(sourceUrl))
                            {
                                sourceUrl = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + pcpResultReport;
                            }

                            if (DirectoryOperationsHelper.IsFileExist(sourceUrl))
                            {
                                try
                                {
                                    string fileName = ecr.CustomerId.ToString();

                                    var eventDirectoryPdf = Path.Combine(destinationFolderPdf, ecr.EventId.ToString());
                                    var customer = _customerRepository.GetCustomer(ecr.CustomerId);
                                    var theEvent = _eventRepository.GetById(ecr.EventId);

                                    if (corporateAccount.Id == _martinsPointExclusiveAccountId)
                                    {
                                        fileName = "Exclusive_" + customer.InsuranceId;
                                    }
                                    else if (corporateAccount.Id == _settings.ExcellusAccountId)
                                    {
                                        fileName = customer.InsuranceId;
                                    }
                                    else if (corporateAccount.Id == _settings.HealthNowAccountId)
                                    {
                                        fileName = customer.InsuranceId;
                                        eventDirectoryPdf = healthPlanDownloadPath;
                                    }
                                    else if (corporateAccount.Id == _settings.AppleCareAccountId)
                                    {
                                        if (!string.IsNullOrEmpty(customer.InsuranceId))
                                            fileName = string.Format("{0}_{1}", customer.InsuranceId, theEvent.EventDate.ToString("yyyyMMdd"));
                                        else
                                            fileName = string.Format("NoMember_{0}_{1}", customer.CustomerId, theEvent.EventDate.ToString("yyyyMMdd"));

                                        fileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, fileName, (long)ResultFormatType.PDF);
                                    }
                                    else if (corporateAccount.Id == _settings.MedMutualAccountId)
                                    {
                                        if (!string.IsNullOrEmpty(customer.InsuranceId))
                                            fileName = string.Format("{0}_{1}", customer.InsuranceId, theEvent.EventDate.ToString("yyyyMMdd"));
                                        else
                                            fileName = string.Format("NoMember_{0}_{1}", customer.CustomerId, theEvent.EventDate.ToString("yyyyMMdd"));

                                        eventDirectoryPdf = healthPlanDownloadPath;

                                        fileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, fileName, (long)ResultFormatType.PDF);
                                    }
                                    else if (corporateAccount.Id == _settings.ConnecticareAccountId)
                                    {
                                        if (!string.IsNullOrEmpty(customer.InsuranceId))
                                            fileName = customer.InsuranceId + "_" + customer.Name.LastName + "_" + customer.Name.FirstName + " " + customer.Name.MiddleName
                                                       + theEvent.EventDate.ToString("yyyy-MM-dd") + "_HF_COMM";

                                        else
                                            fileName = customer.Name.LastName + "_" + customer.Name.FirstName + " " + customer.Name.MiddleName
                                                       + theEvent.EventDate.ToString("yyyy-MM-dd") + "_HF_COMM";

                                        eventDirectoryPdf = string.Format(_settings.HealthPlanDownloadPath, corporateAccount.FolderName);
                                    }
                                    else if (corporateAccount.Id == _settings.ConnecticareMaAccountId)
                                    {
                                        if (!string.IsNullOrEmpty(customer.InsuranceId))
                                            fileName = customer.InsuranceId + "_" + customer.Name.LastName + "_" + customer.Name.FirstName + " " + customer.Name.MiddleName
                                                       + theEvent.EventDate.ToString("yyyy-MM-dd") + "_HF_MCR";

                                        else
                                            fileName = customer.Name.LastName + "_" + customer.Name.FirstName + " " + customer.Name.MiddleName
                                                       + theEvent.EventDate.ToString("yyyy-MM-dd") + "_HF_MCR";

                                        eventDirectoryPdf = string.Format(_settings.HealthPlanDownloadPath, corporateAccount.FolderName);
                                    }
                                    else if (corporateAccount.Id == _settings.BcbsAlAccountId)
                                    {
                                        if (!string.IsNullOrEmpty(customer.InsuranceId))
                                        {
                                            fileName = customer.CustomerId + "_" + customer.Name.FirstName + " " + customer.Name.LastName + "_" + customer.InsuranceId;
                                        }
                                        else
                                        {
                                            fileName = customer.CustomerId + "_" + customer.Name.FirstName + " " + customer.Name.LastName;
                                        }

                                        eventDirectoryPdf = destinationFolderPdf + "\\" + ecr.EventId + "_" + DateTime.Today.ToString("MM-dd-yyyy");
                                    }
                                    else if (corporateAccount.Id == _settings.FloridaBlueFepAccountId)
                                    {
                                        if (!string.IsNullOrEmpty(customer.InsuranceId))
                                            fileName = string.Format("GWC_CW_{0}", customer.InsuranceId);

                                        else
                                            fileName = string.Format("GWC_CW_NoMemberId_{0}", customer.CustomerId);

                                        eventDirectoryPdf = Path.Combine(string.Format(_settings.HealthPlanDownloadPath, corporateAccount.FolderName), "PDFs");
                                    }
                                    else if (corporateAccount.Id == _settings.PPAccountId)
                                    {
                                        fileName = theEvent.Id + "_" + customer.CustomerId;
                                        eventDirectoryPdf = string.Format(_settings.HealthPlanDownloadPath, corporateAccount.FolderName);
                                    }
                                    else if (corporateAccount.Id == _settings.NammAccountId)
                                    {
                                        fileName = theEvent.Id + "_" + customer.CustomerId;
                                        eventDirectoryPdf = string.Format(_settings.HealthPlanExportRootPath, corporateAccount.FolderName);
                                    }

                                    if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                        fileName += "_" + corporateAccount.PennedBackText;

                                    if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.PDF)
                                    {
                                        var destinationFileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, fileName, (long)ResultFormatType.PDF);
                                        var pdfFileName = destinationFileName + ".pdf";
                                        var pdfResultFile = Path.Combine(eventDirectoryPdf, pdfFileName);
                                        _resultPdfDownloadHelper.ExportResultInPdfFormat(pdfFileName, sourceUrl, eventDirectoryPdf);

                                        var isFilePosted = true;

                                        if (DirectoryOperationsHelper.IsFileExist(pdfResultFile))
                                        {
                                            var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, pdfResultFile);

                                            if (_settings.SendReportToHcpNv && _settings.HcpNvAccountId == corporateAccount.Id)
                                            {
                                                isFilePosted = ExportResultOnHcpNvSftp(ecr.CustomerId + ".pdf", sourceUrl, ecr.EventId);
                                            }

                                            if (_settings.BcbsAlAccountId == corporateAccount.Id)
                                            {
                                                var sftpSettings = _sftpCridentialManager.Deserialize(_settings.SftpResouceFilePath + corporateAccount.Tag + ".xml");

                                                isFilePosted = ExportFileOnClientSftp(pdfResultFile, _settings.BcbsAlSftpDownloadPath + "Individual Member Results (PDFs)\\" + ecr.EventId + "_" + DateTime.Today.ToString("MM-dd-yyyy"), sftpSettings);
                                            }

                                            if (corporateAccount.Id == _settings.FloridaBlueFepAccountId)
                                            {
                                                var destinationSftpPath = _settings.FloridaBlueSftpPath + "\\" + corporateAccount.FolderName + "\\Download\\PDfs";
                                                isFilePosted = UploadSingleFile(pdfResultFile, destinationSftpPath, _settings.FloridaBlueSftpHost, _settings.FloridaBlueSftpUserName, _settings.FloridaBlueSftpPassword);
                                            }

                                            if (isFilePosted)
                                            {
                                                resultPostedCustomer.Add(_resultPdfFileHelper.GetCustomerInfo(theEvent, Path.GetFileName(pgpFilePath), (long)ResultFormatType.PDF, customer, ecr.Id));
                                            }
                                            else
                                            {
                                                resultNotPosted.EventCustomer.Add(new EventCustomerInfo
                                                {
                                                    EventCustomerId = ecr.Id,
                                                    EventId = ecr.EventId,
                                                    CustomerId = ecr.CustomerId,
                                                    Error = "File Not posted on Client SFTP."
                                                });
                                            }

                                            _logger.Info("destination: " + pdfResultFile);
                                            _logger.Info("Source: " + sourceUrl);
                                        }
                                        else
                                        {
                                            resultNotPosted.EventCustomer.Add(new EventCustomerInfo
                                            {
                                                EventCustomerId = ecr.Id,
                                                EventId = ecr.EventId,
                                                CustomerId = ecr.CustomerId,
                                                Error = "file not Moved on HIP SFTP."
                                            });
                                        }
                                    }

                                    if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.TIF)
                                    {
                                        var destinationFileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, fileName, (long)ResultFormatType.TIF);
                                        var tipResultFile = Path.Combine(eventDirectoryPdf, destinationFileName + ".tif");
                                        _resultPdfDownloadHelper.ExportResultInTiffFormat(destinationFileName + ".tif", sourceUrl, eventDirectoryPdf);

                                        var isFilePosted = true;
                                        var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, tipResultFile);

                                        if (DirectoryOperationsHelper.IsFileExist(tipResultFile))
                                        {
                                            if (_settings.SendReportToHcpNv && _settings.HcpNvAccountId == corporateAccount.Id)
                                            {
                                                isFilePosted = ExportResultOnHcpNvSftp(ecr.CustomerId + ".tif", sourceUrl, ecr.EventId, false);
                                            }

                                            if (_settings.BcbsAlAccountId == corporateAccount.Id)
                                            {
                                                var sftpSettings = _sftpCridentialManager.Deserialize(_settings.SftpResouceFilePath + corporateAccount.Tag + ".xml");
                                                isFilePosted = ExportFileOnClientSftp(tipResultFile, _settings.BcbsAlSftpDownloadPath + "Individual Member Results (PDFs)\\" + ecr.EventId + "_" + DateTime.Today.ToString("MM-dd-yyyy"), sftpSettings);
                                            }
                                            if (isFilePosted)
                                            {
                                                resultPostedCustomer.Add(_resultPdfFileHelper.GetCustomerInfo(theEvent, Path.GetFileName(pgpFilePath), (long)ResultFormatType.TIF, customer, ecr.Id));
                                            }
                                            else
                                            {
                                                resultNotPosted.EventCustomer.Add(new EventCustomerInfo
                                                {
                                                    EventCustomerId = ecr.Id,
                                                    EventId = ecr.EventId,
                                                    CustomerId = ecr.CustomerId,
                                                    Error = "File Not posted on Client SFTP."
                                                });
                                            }

                                            _logger.Info("destination: " + tipResultFile);
                                            _logger.Info("Source: " + sourceUrl);
                                        }
                                        else
                                        {
                                            resultNotPosted.EventCustomer.Add(new EventCustomerInfo
                                            {
                                                EventCustomerId = ecr.Id,
                                                EventId = ecr.EventId,
                                                CustomerId = ecr.CustomerId,
                                                Error = "file not Moved on HIP SFTP."
                                            });
                                        }
                                    }
                                }
                                catch (Exception exception)
                                {
                                    resultNotPosted.EventCustomer.Add(new EventCustomerInfo
                                    {
                                        EventCustomerId = ecr.Id,
                                        EventId = ecr.EventId,
                                        CustomerId = ecr.CustomerId,
                                        Error = "file not Moved on HIP SFTP."
                                    });

                                    _logger.Error(string.Format("some error occurred for the customerId {0}, {1},\n Message {2} \n Stack Trace {3}", ecr.CustomerId, ecr.EventId, exception.Message, exception.StackTrace));
                                }
                            }
                            else
                            {
                                _logger.Info(string.Format("File not generated or removed for the customerId {0}, {1}", ecr.CustomerId, ecr.EventId));

                                resultNotPosted.EventCustomer.Add(new EventCustomerInfo
                                {
                                    EventCustomerId = ecr.Id,
                                    EventId = ecr.EventId,
                                    CustomerId = ecr.CustomerId,
                                    Error = "File not generated or removed."
                                });
                            }
                        }

                        if (corporateAccount.Id == _settings.HealthNowAccountId || corporateAccount.Id == _settings.MedMutualAccountId)
                        {
                            if (DirectoryOperationsHelper.IsDirectoryExist(healthPlanDownloadPath) &&
                                DirectoryOperationsHelper.GetFiles(healthPlanDownloadPath).Any())
                            {
                                var isZipFileCreated = false;
                                try
                                {
                                    _zipHelper.CreateZipFiles(healthPlanDownloadPath);
                                    isZipFileCreated = true;
                                }
                                catch (Exception ex)
                                {
                                    _logger.Error(string.Format("some error occurred while creating zip file for AccountId: {0} and account tag: {1} Exception Message: \n{2}, \n stack Trace: \n\t {3} ",
                                            corporateAccount.Id, corporateAccount.Tag, ex.Message, ex.StackTrace));
                                }

                                if (isZipFileCreated)
                                {
                                    resultPosted.Customer.AddRange(resultPostedCustomer);
                                }
                                else
                                {
                                    resultNotPosted.EventCustomer.AddRange(
                                        resultPostedCustomer.Select(x => new EventCustomerInfo
                                        {
                                            EventCustomerId = x.EventCustomerId,
                                            CustomerId = x.CustomerId,
                                            EventId = x.EventId,
                                            Error = "Error occurred while creating zip file."
                                        }));
                                }
                            }

                            DirectoryOperationsHelper.DeleteDirectory(healthPlanDownloadPath, true);
                        }
                        else
                        {
                            resultPosted.Customer.AddRange(resultPostedCustomer);
                        }

                        customSettings.LastTransactionDate = exportToTime;
                        _customSettingManager.SerializeandSave(customSettingFilePath, customSettings);

                        CorrectandSaveResultPosted(resultPosted, corporateAccount);
                        _resultPdfNotPostedSerializer.SerializeandSave(resultNotPostedToPlanFileName, resultNotPosted);

                        if (resultNotPosted.EventCustomer.Count > 0)
                            _resultPdfEmailNotificationHelper.SendEmailNotificationForFileNotPosted(corporateAccount.Tag, resultNotPosted.EventCustomer.Count, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("some error occurred for AccountId: {0} and account tag: {1} Exception Message: \n{2}, \n stack Trace: \n\t {3} ", corporateAccount.Id, corporateAccount.Tag, ex.Message, ex.StackTrace));
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("some error occurred Exception Message: \n{0}, \n stack Trace: \n\t {1} ", exception.Message, exception.StackTrace));
            }
        }

        private void CorrectandSaveResultPosted(ResultPdfPostedXml resultPosted, CorporateAccount account)
        {
            if (resultPosted != null && !resultPosted.Customer.IsNullOrEmpty())
            {
                _logger.Info("Result posted Log for " + account.Tag);
                resultPosted = _resultPdfFileHelper.CorrectMissingRecords(resultPosted);

                if (account.Id == _settings.AppleCareAccountId || account.Id == _settings.MedMutualAccountId)
                {
                    var pdfLogfile = string.Format(_settings.PdfLogFilePath, account.FolderName);
                    if (account.Id == _settings.MedMutualAccountId) pdfLogfile = pdfLogfile.Replace(" ", "");
                    pdfLogfile = Path.Combine(pdfLogfile, "Download");

                    try
                    {
                        _resultPdfFileHelper.CreateCsvForFileShared(resultPosted.Customer, pdfLogfile, account.Tag + "_PdfLogFile");
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("some error occurred");
                        _logger.Error("exception: " + ex.Message);
                        _logger.Error("stack trace: " + ex.StackTrace);
                    }
                }

                _logger.Info("Result posted Log Completed for " + account.Tag);
            }

            var resultPostedToPlanFileName = Path.Combine(_resultPostedToPlanPath, string.Format("ResultPostedto_{0}.xml", account.Tag));
            _resultPdfPostedSerializer.SerializeandSave(resultPostedToPlanFileName, resultPosted);
        }

        private bool ExportResultOnHcpNvSftp(string fileName, string sourcePath, long eventId, bool isPdf = true)
        {
            //var destinationPathOnSftp = string.Format("{0}/{1}/{2}", _settings.HcpNvSftpResultReportDownloadPath, "Completed Pt. Documentation", eventId);
            var destinationPathOnSftp = (!string.IsNullOrEmpty(_settings.HcpNvSftpResultReportDownloadPath) ? _settings.HcpNvSftpResultReportDownloadPath + "/" : string.Empty) + "Completed Pt. Documentation" + "/" + eventId;

            destinationPathOnSftp = destinationPathOnSftp.Replace("/", "\\");

            _logger.Info("Destination Path:  " + destinationPathOnSftp);
            _logger.Info("File Name Path:  " + fileName);
            _logger.Info("Source Path: " + sourcePath);

            var processFtp = new ProcessFtp(_logger, _settings.HcpNvSftpHost, _settings.HcpNvSftpUserName, _settings.HcpNvSftpPassword);
            return processFtp.UploadSingleFile(sourcePath, destinationPathOnSftp, fileName);
        }

        private bool ExportFileOnClientSftp(string sourcePath, string destination, SftpCridential cridential)
        {
            return UploadSingleFile(sourcePath, destination, cridential.HostName, cridential.UserName, cridential.Password);
        }

        private bool UploadSingleFile(string sourcePath, string destination, string hostName, string userName, string password)
        {
            var processFtp = new ProcessFtp(_logger, hostName, userName, password);
            var fileName = Path.GetFileName(sourcePath);

            _logger.Info("Destination Path:  " + destination);
            _logger.Info("File Name Path:  " + fileName);
            _logger.Info("Source Path: " + sourcePath);

            return processFtp.UploadSingleFile(sourcePath, destination, fileName);
        }
    }
}
