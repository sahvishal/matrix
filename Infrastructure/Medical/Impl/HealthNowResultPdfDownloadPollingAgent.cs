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
    public class HealthNowResultPdfDownloadPollingAgent : IHealthNowResultPdfDownloadPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ISettings _settings;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly IResultPdfDownloadPollingAgentHelper _resultPdfDownloaderHelper;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IXmlSerializer<ResultPdfPostedXml> _resultPdfPostedSerializer;
        private readonly IResultPdfFileHelper _resultPdfFileHelper;
        private readonly IUniqueItemRepository<Event> _eventRepository;

        private readonly ILogger _logger;

        private readonly string _customSettingFile;
        private readonly string _destinationFolderPdfPath;

        private readonly long _accountId;
        private readonly DateTime _cutOfDate;

        private readonly string _sftpHost;
        private readonly string _sftpUserName;
        private readonly string _sftpPassword;
        private readonly bool _sendReportToSftp;
        private readonly string _sftpDestinationPath;
        private readonly string _resultPostedToPlanPath;

        public HealthNowResultPdfDownloadPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, ISettings settings, ILogManager logManager,
            IMediaRepository mediaRepository, ICustomSettingManager customSettingManager, IUniqueItemRepository<CorporateAccount> corporateAccountRepository,
            IResultPdfDownloadPollingAgentHelper resultPdfDownloaderHelper, IPgpFileEncryptionHelper pgpFileEncryptionHelper, ICustomerRepository customerRepository, IXmlSerializer<ResultPdfPostedXml> resultPdfPostedSerializer, IResultPdfFileHelper resultPdfFileHelper, IUniqueItemRepository<Event> eventRepository)
        {
            _cutOfDate = settings.PcpDownloadCutOfDate;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _settings = settings;
            _mediaRepository = mediaRepository;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;

            _resultPdfDownloaderHelper = resultPdfDownloaderHelper;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _customerRepository = customerRepository;
            _resultPdfPostedSerializer = resultPdfPostedSerializer;
            _resultPdfFileHelper = resultPdfFileHelper;
            _eventRepository = eventRepository;

            _logger = logManager.GetLogger("HealthNow ResultPdf");

            _accountId = settings.HealthNowAccountId;
            _customSettingFile = settings.PcpResultPdfDownloadSettings;
            _destinationFolderPdfPath = settings.PcpResultPdfDownloadPath;

            _sftpHost = settings.HealthNowSftpHost;
            _sftpUserName = settings.HealthNowSftpUserName;
            _sftpPassword = settings.HealthNowSftpPassword;
            _sendReportToSftp = settings.SendPdfToHealthNowSftp;
            _sftpDestinationPath = settings.HealthNowSftpPath;
            _resultPostedToPlanPath = settings.ResultPostedToPlanPath;
        }

        public void PollForPdfDownload()
        {
            try
            {
                if (_accountId < 1) return;

                var corporateAccount = _corporateAccountRepository.GetById(_accountId);

                try
                {
                    _logger.Info(string.Format("Generating for accountId {0} and account tag {1}. ", corporateAccount.Id, corporateAccount.Tag));

                    var destinationFolderPdf = string.Format(_destinationFolderPdfPath, corporateAccount.FolderName);
                    var customSettingFilePath = string.Format(_customSettingFile, corporateAccount.Tag);
                    var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                    var exportToTime = DateTime.Now.AddHours(-1);
                    var exportFromTime = customSettings.LastTransactionDate ?? _cutOfDate;
                 
                    DateTime? stopSendingPdftoHealthPlanDate = null;
                    if (corporateAccount.IsHealthPlan)
                    {
                        stopSendingPdftoHealthPlanDate = _settings.StopSendingPdftoHealthPlanDate;
                    }
                  
                    var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsToFax(
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
                                var eventDirectoryPdf = destinationFolderPdf + "/" + ecr.EventId;

                                var customerData = _customerRepository.GetCustomer(ecr.CustomerId);
                                var eventData = _eventRepository.GetById(ecr.EventId);

                                if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.PDF)
                                {
                                    var patientMemerId = string.IsNullOrEmpty(customerData.InsuranceId) ? "No_MemberId_" + ecr.CustomerId : customerData.InsuranceId;

                                    if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                        patientMemerId += "_" + corporateAccount.PennedBackText;

                                    patientMemerId = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, patientMemerId, (long)ResultFormatType.PDF);
                                    var pdfFileName = patientMemerId + ".pdf";
                                    //var pdfResultFile = eventDirectoryPdf + "/" + pdfFileName;

                                    //  _resultPdfDownloaderHelper.ExportResultInPdfFormat(ecr.CustomerId + ".pdf", sourcePath, eventDirectoryPdf);

                                    //if (File.Exists(pdfResultFile))
                                    //{
                                    //    _pgpFileEncryptionHelper.EncryptFile(corporateAccount, pdfResultFile);
                                    //}

                                    if (_sendReportToSftp)
                                    {
                                        ExportResultInSftp(pdfFileName, sourcePath, _sftpDestinationPath + "\\" + ecr.EventId);

                                        resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, pdfFileName, (long)ResultFormatType.PDF, customerData, ecr.Id));

                                        _logger.Info(string.Format("File Moved to HealthNow Sftp location for customer Id {0} and eventId {1}", ecr.CustomerId, ecr.EventId));
                                    }

                                }

                                if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.TIF)
                                {
                                    var fileName = ecr.CustomerId.ToString();
                                    if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                        fileName += "_" + corporateAccount.PennedBackText;

                                    fileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, fileName, (long)ResultFormatType.TIF);

                                    var tipResultFile = eventDirectoryPdf + "/" + fileName + ".tif";
                                    _resultPdfDownloaderHelper.ExportResultInTiffFormat(ecr.CustomerId + ".tif", sourcePath, eventDirectoryPdf);

                                    if (File.Exists(tipResultFile))
                                    {
                                        var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, tipResultFile);
                                        resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, Path.GetFileName(pgpFilePath), (long)ResultFormatType.TIF, customerData, ecr.Id));
                                    }
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
            _logger.Info("source Path: " + sourcePath);
            _logger.Info("destination Path: " + Path.Combine(eventSftpPdfDirectory, fileName));

            var processFtp = new ProcessFtp(_logger, _sftpHost, _sftpUserName, _sftpPassword);
            processFtp.UploadSingleFile(sourcePath, eventSftpPdfDirectory, fileName);
        }
    }
}