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
    public class NtspResultPdfDownloadPollingAgent : INtspResultPdfDownloadPollingAgent
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

        private readonly ILogger _logger;

        private readonly string _customSettingFile;
        private readonly string _destinationFolderPdfPath;

        private readonly IEnumerable<long> _accountIds;
        private readonly DateTime _cutOfDate;

        private readonly string _sftpHost;
        private readonly string _sftpUserName;
        private readonly string _sftpPassword;
        private readonly bool _sendReportToSftp;
        private readonly string _destinationSftpFolderPdfPath;

        private readonly IXmlSerializer<ResultPdfPostedXml> _resultPdfPostedSerializer;
        private readonly IResultPdfFileHelper _resultPdfFileHelper;

        private readonly DateTime _stopSendingPdftoHealthPlanDate;

        private readonly string _resultPostedToPlanPath;
        public NtspResultPdfDownloadPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, ISettings settings, ILogManager logManager,
            IMediaRepository mediaRepository, ICustomSettingManager customSettingManager, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, ICustomerRepository customerRepository,
            IUniqueItemRepository<Event> eventRepository, IResultPdfDownloadPollingAgentHelper resultPdfDownloaderHelper, IPgpFileEncryptionHelper pgpFileEncryptionHelper, IXmlSerializer<ResultPdfPostedXml> resultPdfPostedSerializer, IResultPdfFileHelper resultPdfFileHelper)
        {


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

            _logger = logManager.GetLogger("NTSP ResultPdf");

            _accountIds = settings.NtspAccountIds;
            _customSettingFile = settings.NtspResultPdfDownloadSettings;
            _destinationFolderPdfPath = settings.NtspResultPdfDownloadPath;

            _sftpHost = settings.NtspSftpHost;
            _sftpUserName = settings.NtspSftpUserName;
            _sftpPassword = settings.NtspSftpPassword;
            _sendReportToSftp = settings.SendReportToNtspSftp;
            _destinationSftpFolderPdfPath = settings.NtspSftpResultReportDownloadPath;

            _resultPdfPostedSerializer = resultPdfPostedSerializer;
            _resultPdfFileHelper = resultPdfFileHelper;
            _resultPostedToPlanPath = settings.ResultPostedToPlanPath;

            _stopSendingPdftoHealthPlanDate = settings.StopSendingPdftoHealthPlanDate;
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
                        _logger.Info(string.Format("Genderating for accountId {0} and account tag {1}. ", corporateAccount.Id, corporateAccount.Tag));

                        var destinationFolderPdfPath = string.Format(_destinationFolderPdfPath, corporateAccount.FolderName);
                        var sptpDestinationfolder = string.Format(_destinationSftpFolderPdfPath, corporateAccount.FolderName);

                        var customSettingFilePath = string.Format(_customSettingFile, corporateAccount.Tag);
                        var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                        var exportToTime = DateTime.Now.AddHours(-1);
                        var exportFromTime = customSettings.LastTransactionDate ?? _cutOfDate;

                        DateTime? stopSendingPdftoHealthPlanDate = null;
                        if (corporateAccount.IsHealthPlan)
                        {
                            stopSendingPdftoHealthPlanDate = _stopSendingPdftoHealthPlanDate;
                        }

                        var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsToFax((int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false, exportToTime, exportFromTime, corporateAccount.Id, corporateAccount.Tag, true, stopSendingPdftoHealthPlanDate: _stopSendingPdftoHealthPlanDate);

                        var resultPosted = GetResultPostedTo(corporateAccount.Tag);

                        var customerResults = eventCustomerResults as EventCustomerResult[] ?? eventCustomerResults.ToArray();

                        if (eventCustomerResults == null || !customerResults.Any())
                        {
                            _logger.Info(string.Format("No event customer result list for {0} Result Pdf Download.", corporateAccount.Tag));
                            continue;
                        }

                        _logger.Info(string.Format("Found {0} customers for {1} Result Pdf Download. ", eventCustomerResults.Count(), corporateAccount.Tag));

                        var pcpResultReport = _mediaRepository.GetPdfFileNameForPcpResultReport();

                        var healthPlanResultReport = _mediaRepository.GetPdfFileNameForHealthPlanResultReport();

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

                                    var lastName = string.IsNullOrEmpty(customer.Name.LastName) ? string.Empty : customer.Name.LastName.Trim();
                                    var firstName = string.IsNullOrEmpty(customer.Name.FirstName) ? string.Empty : customer.Name.FirstName.Trim();

                                    if (!string.IsNullOrEmpty(customer.InsuranceId))
                                    {
                                        destinationFileName = string.Format("{0}_{1}_{2}_{3}", customer.InsuranceId, lastName, firstName, eventData.EventDate.ToString("MMddyy"));
                                    }
                                    else
                                    {
                                        destinationFileName = string.Format("{0}_{1}_{2}_{3}_{4}", "No_MemberId", customer.CustomerId, lastName, firstName, eventData.EventDate.ToString("MMddyy"));
                                    }

                                    var destinationFolderPdfPathWithEventId = destinationFolderPdfPath + "/" + ecr.EventId + "/";
                                    var sptpDestinationfolderPathWithEventId = sptpDestinationfolder + "/pdf" + "/" + ecr.EventId;

                                    if (!string.IsNullOrEmpty(destinationFileName))
                                    {
                                        if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.PDF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                                        {
                                            destinationFileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, destinationFileName, (long)ResultFormatType.PDF);

                                            if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                                destinationFileName += "_" + corporateAccount.PennedBackText;

                                            var pdfResultFile = destinationFolderPdfPathWithEventId + destinationFileName + ".pdf";

                                            _resultPdfDownloaderHelper.ExportResultInPdfFormat(destinationFileName + ".pdf", sourcePath, destinationFolderPdfPathWithEventId);

                                            if (File.Exists(pdfResultFile))
                                            {
                                                var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, pdfResultFile);
                                            }

                                            resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, destinationFileName + ".pdf", (long)ResultFormatType.PDF, customer, ecr.Id));

                                            if (_sendReportToSftp)
                                            {
                                                sptpDestinationfolderPathWithEventId = sptpDestinationfolderPathWithEventId.Replace("\\", "/");

                                                ResultPdfonNtspSftp(destinationFileName + ".pdf", sourcePath, sptpDestinationfolderPathWithEventId);

                                                _logger.Info(string.Format("File Moved to Ntsp Sftp location for customer Id {0} and eventId {1}", ecr.CustomerId, ecr.EventId));
                                            }
                                        }

                                        if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.TIF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                                        {
                                            destinationFileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, destinationFileName, (long)ResultFormatType.TIF);

                                            if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                                destinationFileName += "_" + corporateAccount.PennedBackText;

                                            var tifResultFile = destinationFolderPdfPathWithEventId + destinationFileName + ".tif";
                                            _resultPdfDownloaderHelper.ExportResultInTiffFormat(destinationFileName + ".tif", sourcePath, destinationFolderPdfPathWithEventId);

                                            if (File.Exists(tifResultFile))
                                            {
                                                _pgpFileEncryptionHelper.EncryptFile(corporateAccount, tifResultFile);
                                            }

                                            resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, destinationFileName + ".tif", (long)ResultFormatType.PDF, customer, ecr.Id));
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

                        CorrectandSaveResultPosted(resultPosted, corporateAccount);

                        customSettings.LastTransactionDate = exportToTime;
                        _customSettingManager.SerializeandSave(customSettingFilePath, customSettings);

                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("some error occured for AccountId: {0} and account tag: {1} Exception Message: \n{2}, \n stack Trace: \n\t {3} ", corporateAccount.Id, corporateAccount.Tag, ex.Message, ex.StackTrace));
                    }
                }

            }
            catch (Exception exception)
            {

                _logger.Error(string.Format("some error occured Exception Message: \n{0}, \n stack Trace: \n\t {1} ", exception.Message, exception.StackTrace));
            }
        }

        private ResultPdfPostedXml CorrectMissingRecords(ResultPdfPostedXml resultPdfPostedXml)
        {
            if (resultPdfPostedXml == null || resultPdfPostedXml.Customer.IsNullOrEmpty()) return resultPdfPostedXml;

            var isRecordMissing = resultPdfPostedXml.Customer.Any(x => !x.EventDate.HasValue || string.IsNullOrEmpty(x.MemberId));

            if (!isRecordMissing) return resultPdfPostedXml;

            var customersInfo = resultPdfPostedXml.Customer;

            foreach (var customerInfo in customersInfo)
            {
                try
                {
                    if (string.IsNullOrEmpty(customerInfo.MemberId))
                    {
                        var customer = _customerRepository.GetCustomer(customerInfo.CustomerId);
                        customerInfo.MemberId = customer.InsuranceId;
                    }

                    if (!customerInfo.EventDate.HasValue)
                    {
                        var eventData = _eventRepository.GetById(customerInfo.EventId);
                        customerInfo.EventDate = eventData.EventDate;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Info("Error while getting memberId for customer Id " + customerInfo.CustomerId);
                    _logger.Error("Message " + ex.Message);
                    _logger.Error("StackTrace " + ex.StackTrace);
                }
            }

            return new ResultPdfPostedXml() { Customer = customersInfo };
        }

        private ResultPdfPostedXml GetResultPostedTo(string tag)
        {
            var resultPostedToPlanFileName = Path.Combine(_resultPostedToPlanPath, string.Format("ResultPostedto_{0}.xml", tag));
            var resultPosted = _resultPdfPostedSerializer.Deserialize(resultPostedToPlanFileName);
            if (resultPosted == null || resultPosted.Customer.IsNullOrEmpty())
                return new ResultPdfPostedXml { Customer = new List<CustomerInfo>() };

            return resultPosted;
        }

        private void CorrectandSaveResultPosted(ResultPdfPostedXml resultPosted, CorporateAccount account)
        {
            if (resultPosted != null && !resultPosted.Customer.IsNullOrEmpty())
            {
                _logger.Info("Result posted Log for " + account.Tag);
                resultPosted = CorrectMissingRecords(resultPosted);

                var pdfLogfile = string.Format(_settings.PdfLogFilePath, account.FolderName);
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

                _logger.Info("Result posted Log Completed for " + account.Tag);
            }

            var resultPostedToPlanFileName = Path.Combine(_resultPostedToPlanPath, string.Format("ResultPostedto_{0}.xml", account.Tag));
            _resultPdfPostedSerializer.SerializeandSave(resultPostedToPlanFileName, resultPosted);
        }

        private void ResultPdfonNtspSftp(string fileName, string sourcePath, string eventSftpPdfDirectory)
        {
            _logger.Info("destination Path: " + eventSftpPdfDirectory + "/" + fileName);
            _logger.Info("source Path: " + sourcePath);

            var processFtp = new ProcessFtp(_logger, _sftpHost, _sftpUserName, _sftpPassword);
            processFtp.UploadSingleFileUsingSftp(sourcePath, eventSftpPdfDirectory, fileName);
        }

    }
}
