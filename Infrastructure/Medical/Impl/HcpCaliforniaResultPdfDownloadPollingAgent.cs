using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class HcpCaliforniaResultPdfDownloadPollingAgent : IHcpCaliforniaResultPdfDownloadPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ISettings _settings;

        private readonly IMediaRepository _mediaRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUniqueItemRepository<Event> _eventRepository;
        private readonly IResultPdfDownloadPollingAgentHelper _resultPdfDownloaderHelper;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly IXmlSerializer<ResultPdfPostedXml> _resultPdfPostedSerializer;
        private readonly IResultPdfFileHelper _resultPdfFileHelper;

        private readonly ILogger _logger;

        private readonly string _customSettingFile;
        private readonly string _destinationFolderPdfPath;

        private readonly long _accountId;
        private readonly DateTime _cutOfDate;

        private readonly string _sftpHost;
        private readonly string _sftpUserName;
        private readonly string _sftpPassword;
        private readonly bool _sendReportToSftp;
        private readonly string _resultPostedToPlanPath;

        public HcpCaliforniaResultPdfDownloadPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, ISettings settings, ILogManager logManager, IMediaRepository mediaRepository, ICustomSettingManager customSettingManager,
            IUniqueItemRepository<CorporateAccount> corporateAccountRepository, ICustomerRepository customerRepository, IUniqueItemRepository<Event> eventRepository, IResultPdfDownloadPollingAgentHelper resultPdfDownloaderHelper,
            IPgpFileEncryptionHelper pgpFileEncryptionHelper, IXmlSerializer<ResultPdfPostedXml> resultPdfPostedSerializer, IResultPdfFileHelper resultPdfFileHelper)
        {

            _accountId = settings.HcpCaliforniaAccountId;
            _cutOfDate = settings.PcpDownloadCutOfDate;

            _eventCustomerResultRepository = eventCustomerResultRepository;
            _settings = settings;
            _mediaRepository = mediaRepository;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _resultPdfDownloaderHelper = resultPdfDownloaderHelper;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _resultPdfPostedSerializer = resultPdfPostedSerializer;
            _resultPdfFileHelper = resultPdfFileHelper;

            _logger = logManager.GetLogger("HCP CA ResultPdf");

            _customSettingFile = settings.HcpCaliforniaResultPdfDownloadSettings;
            _destinationFolderPdfPath = settings.HcpCaliforniaResultPdfDownloadPath;

            _sftpHost = settings.HcpCaliforniaSftpHost;
            _sftpUserName = settings.HcpCaliforniaSftpUserName;
            _sftpPassword = settings.HcpCaliforniaSftpPassword;
            _sendReportToSftp = settings.SendReportToHcpCaliforniaSftp;
            _resultPostedToPlanPath = settings.ResultPostedToPlanPath;
        }

        public void PollForPdfDownload()
        {
            try
            {
                if (_accountId <= 0) return;
                var corporateAccount = _corporateAccountRepository.GetById(_accountId);

                try
                {
                    _logger.Info(string.Format("Genderating for accountId {0} and account tag {1}. ", corporateAccount.Id, corporateAccount.Tag));

                    var destinationFolderPdfPath = string.Format(_destinationFolderPdfPath, corporateAccount.FolderName);
                    var customSettingFilePath = string.Format(_customSettingFile, corporateAccount.Tag);
                    var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                    var exportToTime = DateTime.Now.AddHours(-1);
                    var exportFromTime = customSettings.LastTransactionDate ?? _cutOfDate;
                 
                    DateTime? stopSendingPdftoHealthPlanDate = null;
                    if (corporateAccount.IsHealthPlan)
                    {
                        stopSendingPdftoHealthPlanDate = _settings.StopSendingPdftoHealthPlanDate;
                    }
                   
                    var eventCustomerResults =
                        _eventCustomerResultRepository.GetEventCustomerResultsToFax(
                            (int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false, exportToTime, exportFromTime,
                            corporateAccount.Id, corporateAccount.Tag, true, stopSendingPdftoHealthPlanDate: stopSendingPdftoHealthPlanDate);

                    var customerResults = eventCustomerResults as EventCustomerResult[] ?? eventCustomerResults.ToArray();

                    if (eventCustomerResults == null || !customerResults.Any())
                    {
                        _logger.Info(string.Format("No event customer result list for {0} Result Pdf Download.", corporateAccount.Tag));
                        return;
                    }

                    _logger.Info(string.Format("Found {0} customers for {1} Result Pdf Download. ", eventCustomerResults.Count(), corporateAccount.Tag));

                    var pcpResultReport = _mediaRepository.GetPdfFileNameForPcpResultReport();

                    var healthPlanResultReport = _mediaRepository.GetPdfFileNameForHealthPlanResultReport();

                    var resultPostedToPlanFileName = Path.Combine(_resultPostedToPlanPath, string.Format("ResultPostedto_{0}.xml", corporateAccount.Tag));
                    var resultPosted = _resultPdfPostedSerializer.Deserialize(resultPostedToPlanFileName);
                    resultPosted = resultPosted == null || resultPosted.Customer.IsNullOrEmpty() ? new ResultPdfPostedXml { Customer = new List<CustomerInfo>() } : resultPosted;

                    foreach (var ecr in customerResults)
                    {
                        var sourcePath = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + healthPlanResultReport;

                        if (!File.Exists(sourcePath))
                        {
                            sourcePath = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + pcpResultReport;
                        }

                        if (File.Exists(sourcePath))
                        {
                            try
                            {
                                var customer = _customerRepository.GetCustomer(ecr.CustomerId);
                                var eventData = _eventRepository.GetById(ecr.EventId);

                                var destinationFileName = string.Empty;
                                //if (!string.IsNullOrEmpty(customer.Mrn))
                                //{
                                //    destinationFileName = customer.Mrn + "_" + eventData.EventDate.ToString("yyyyMMdd") + "_258_Outside Diagnostics_HF";
                                //}
                                //else if (!string.IsNullOrEmpty(customer.Lpi))
                                //{
                                //    destinationFileName = "XID" + customer.Lpi + "_" + eventData.EventDate.ToString("yyyyMMdd") + "_258_Outside Diagnostics_HF";
                                //}

                                if (!string.IsNullOrEmpty(customer.Lpi))
                                {
                                    destinationFileName = "XID" + customer.Lpi + "_" + eventData.EventDate.ToString("yyyyMMdd") + "_258_Outside Diagnostics_HF";
                                }
                                else if (!string.IsNullOrEmpty(customer.Mrn))
                                {
                                    destinationFileName = customer.Mrn + "_" + eventData.EventDate.ToString("yyyyMMdd") + "_258_Outside Diagnostics_HF";
                                }
                                else
                                {
                                    destinationFileName = customer.CustomerId + "_" + eventData.EventDate.ToString("yyyyMMdd") + "_258_Outside Diagnostics_HF";
                                }

                                if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                    destinationFileName += "_" + corporateAccount.PennedBackText;

                                if (!string.IsNullOrEmpty(destinationFileName))
                                {
                                    if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.PDF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                                    {
                                        var fileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, destinationFileName, (long)ResultFormatType.PDF);
                                        var pdfResultFile = destinationFolderPdfPath + "/pdf/" + fileName + ".pdf";
                                        _resultPdfDownloaderHelper.ExportResultInPdfFormat(fileName + ".pdf", sourcePath, destinationFolderPdfPath + "/pdf");

                                        if (File.Exists(pdfResultFile))
                                        {
                                            var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, pdfResultFile);
                                            resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, Path.GetFileName(pgpFilePath), (long)ResultFormatType.PDF, customer, ecr.Id));
                                        }
                                    }

                                    if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.TIF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                                    {
                                        var fileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, destinationFileName, (long)ResultFormatType.TIF);
                                        var tifResultFile = destinationFolderPdfPath + "/tif/" + fileName + ".tif";
                                        _resultPdfDownloaderHelper.ExportResultInTiffFormat(fileName + ".tif", sourcePath, destinationFolderPdfPath + "/tif");

                                        if (File.Exists(tifResultFile))
                                        {
                                            var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, tifResultFile);
                                            resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, Path.GetFileName(pgpFilePath), (long)ResultFormatType.TIF, customer, ecr.Id));
                                        }

                                        if (_sendReportToSftp)
                                        {
                                            ExportResultInSftp(fileName + ".tif", tifResultFile, "");

                                            _logger.Info(string.Format("File Moved to HCP CA Sftp location for customer Id {0} and eventId {1}", ecr.CustomerId, ecr.EventId));
                                        }
                                    }
                                }
                                else
                                {
                                    _logger.Info("customer info does nither contain LPI nor MRN info customer Id: " + customer.CustomerId + " Event Id: " + eventData.Id);
                                }
                            }
                            catch (Exception exception)
                            {
                                _logger.Error(string.Format("some error occured for the customerId {0}, {1},\n Messagen {2} \n Stack Trace {3}", ecr.CustomerId, ecr.EventId, exception.Message, exception.StackTrace));
                            }
                        }
                        else
                        {
                            _logger.Info(string.Format("File not generated or removed for the customerId {0}, {1}", ecr.CustomerId, ecr.EventId));
                        }
                    }

                    customSettings.LastTransactionDate = exportToTime;
                    _customSettingManager.SerializeandSave(customSettingFilePath, customSettings);

                    if (resultPosted != null && !resultPosted.Customer.IsNullOrEmpty())
                    {
                        _logger.Info("Result posted Log for " + corporateAccount.Tag);
                        resultPosted = _resultPdfFileHelper.CorrectMissingRecords(resultPosted);

                        var pdfLogfile = string.Format(_settings.PdfLogFilePath, corporateAccount.FolderName);
                        pdfLogfile = Path.Combine(pdfLogfile, "Download");

                        try
                        {
                            _resultPdfFileHelper.CreateCsvForFileShared(resultPosted.Customer, pdfLogfile, corporateAccount.Tag + "_PdfLogFile");
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("some error occurred");
                            _logger.Error("exception: " + ex.Message);
                            _logger.Error("stack trace: " + ex.StackTrace);
                        }

                        _logger.Info("Result posted Log Completed for " + corporateAccount.Tag);
                    }

                    _resultPdfPostedSerializer.SerializeandSave(resultPostedToPlanFileName, resultPosted);

                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("some error occured for AccountId: {0} and account tag: {1} Exception Message: \n{2}, \n stack Trace: \n\t {3} ", corporateAccount.Id, corporateAccount.Tag, ex.Message, ex.StackTrace));
                }


            }
            catch (Exception exception)
            {

                _logger.Error(string.Format("some error occured Exception Message: \n{0}, \n stack Trace: \n\t {1} ", exception.Message, exception.StackTrace));
            }
        }

        private void ExportResultInSftp(string fileName, string sourcePath, string eventSftpPdfDirectory)
        {
            var processFtp = new ProcessFtp(_logger, _sftpHost, _sftpUserName, _sftpPassword);
            processFtp.UploadSingleFile(sourcePath, eventSftpPdfDirectory, fileName);
        }
    }
}