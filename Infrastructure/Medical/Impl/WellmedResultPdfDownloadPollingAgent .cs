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
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using DateTime = System.DateTime;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class WellmedResultPdfDownloadPollingAgent : IWellmedResultPdfDownloadPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;


        private readonly IMediaRepository _mediaRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUniqueItemRepository<Event> _eventRepository;
        private readonly IConvertPdfToTiff _convertPdfToTiff;
        private readonly IResultPdfDownloadPollingAgentHelper _resultPdfDownloadHelper;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly IHostRepository _hostRepository;
        private readonly IXmlSerializer<ResultPdfPostedXml> _resultPdfPostedSerializer;
        private readonly IXmlSerializer<CustomerResultsFailedOnSftp> _customerResultsFailedOnSftpSerializer;

        private readonly ILogger _logger;

        private readonly string _customSettingFile;
        private readonly string _destinationFolderPdfPath;
        private readonly string _destinationCatalystFolderPdfPath;
        private readonly string _destinationSftpFolderPdfPath;
        private readonly string _destinationSftpCatalystFolderPdfPath;
        private readonly string[] _wellmedCustomerGroupName;
        private readonly long _accountId;
        private readonly DateTime _cutOfDate;

        private readonly string _sftpHost;
        private readonly string _sftpUserName;
        private readonly string _sftpPassword;
        private readonly bool _sendReportToSftp;

        private readonly string _resultPostedToPlanPath;
        private readonly IResultPdfFileHelper _resultPdfFileHelper;
        private readonly ISettings _settings;

        public WellmedResultPdfDownloadPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, ISettings settings, ILogManager logManager, IMediaRepository mediaRepository, ICustomSettingManager customSettingManager,
            IUniqueItemRepository<CorporateAccount> corporateAccountRepository, ICustomerRepository customerRepository, IUniqueItemRepository<Event> eventRepository, IConvertPdfToTiff convertPdfToTiff,
            IResultPdfDownloadPollingAgentHelper resultPdfDownloadHelper, IPgpFileEncryptionHelper pgpFileEncryptionHelper, IHostRepository hostRepository, IXmlSerializer<ResultPdfPostedXml> resultPdfPostedSerializer,
            IResultPdfFileHelper resultPdfFileHelper, IXmlSerializer<CustomerResultsFailedOnSftp> customerResultsFailedOnSftpSerializer)
        {
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _mediaRepository = mediaRepository;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _convertPdfToTiff = convertPdfToTiff;
            _resultPdfDownloadHelper = resultPdfDownloadHelper;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _hostRepository = hostRepository;
            _resultPdfPostedSerializer = resultPdfPostedSerializer;
            _resultPdfFileHelper = resultPdfFileHelper;
            _customerResultsFailedOnSftpSerializer = customerResultsFailedOnSftpSerializer;
            _settings = settings;

            _logger = logManager.GetLogger("WellmedResultPdf");

            _customSettingFile = settings.WellmedResultPdfDownloadSettings;
            _destinationFolderPdfPath = settings.WellmedResultPdfDownloadPath;
            _destinationSftpFolderPdfPath = settings.WellmedSftpResultPdfDownloadPath;
            _cutOfDate = settings.PcpDownloadCutOfDate;

            _sftpHost = settings.WellmedSftpHost;
            _sftpUserName = settings.WellmedSftpUserName;
            _sftpPassword = settings.WellmedSftpPassword;
            _accountId = settings.WellmedAccountId;
            _sendReportToSftp = settings.SendReportToWellmedSftp;
            _resultPostedToPlanPath = settings.ResultPostedToPlanPath;

            _destinationSftpCatalystFolderPdfPath = settings.WellmedSftpResultPdfCatalystDownloadPath;
            _destinationCatalystFolderPdfPath = settings.WellmedResultPdfCatalystDownloadPath;
            _wellmedCustomerGroupName = settings.WellmedCustomerGroupName.Split(new char[] { ',' }).Select(t => t.ToLowerInvariant()).ToArray();
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

                    var customSettingFilePath = string.Format(_customSettingFile, corporateAccount.Tag);
                    var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                    var exportToTime = DateTime.Now.AddHours(-1);
                    var exportFromTime = customSettings.LastTransactionDate ?? _cutOfDate;
                    
                    DateTime? stopSendingPdftoHealthPlanDate = null;
                    if (corporateAccount.IsHealthPlan)
                    {
                        stopSendingPdftoHealthPlanDate = _settings.StopSendingPdftoHealthPlanDate;
                    }

                    var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsToFax((int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false, exportToTime, exportFromTime, corporateAccount.Id, corporateAccount.Tag, true, stopSendingPdftoHealthPlanDate: stopSendingPdftoHealthPlanDate);

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

                    var sftpFailedRecordsFileName = Path.Combine(_resultPostedToPlanPath, string.Format("CustomerResultsFailedOnSftp_{0}.xml", corporateAccount.Tag + "_ToWellmed"));
                    var sftpFailedCustomers = _customerResultsFailedOnSftpSerializer.Deserialize(sftpFailedRecordsFileName);
                    sftpFailedCustomers = sftpFailedCustomers == null || sftpFailedCustomers.EventCustomerIds.IsNullOrEmpty() ? new CustomerResultsFailedOnSftp { EventCustomerIds = new List<long>() } : sftpFailedCustomers;

                    var newSftpFailedCustomers = new CustomerResultsFailedOnSftp { EventCustomerIds = new List<long>() };

                    if (!sftpFailedCustomers.EventCustomerIds.IsNullOrEmpty())
                    {
                        var failedEventCustomerIds = sftpFailedCustomers.EventCustomerIds.Where(x => !customerResults.Select(ecr => ecr.Id).Contains(x));
                        if (!failedEventCustomerIds.IsNullOrEmpty())
                        {
                            int totalRecords = failedEventCustomerIds.Count();
                            int pageNumber = 0;
                            int pagesize = 100;

                            while (true)
                            {
                                if (totalRecords < 1) break;

                                var totalItems = pageNumber * pagesize;
                                var customerIds = failedEventCustomerIds.Skip(totalItems).Take(pagesize);
                                var failedEventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsByIdsAndResultState(customerIds, (int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false);
                                if (!failedEventCustomerResults.IsNullOrEmpty())
                                    customerResults.Concat(failedEventCustomerResults);
                                pageNumber++;

                                if (totalItems >= totalRecords)
                                    break;
                            }
                        }
                    }

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
                                var host = _hostRepository.GetHostForEvent(ecr.EventId);

                                if (!string.IsNullOrEmpty(customer.InsuranceId))
                                {
                                    var destinationFolderPdfPath = string.Empty;
                                    var destinationCatalystFolderPdfPath = string.Empty;
                                    //if (!string.IsNullOrEmpty(customer.GroupName) && _wellmedCustomerGroupName.Contains(customer.GroupName))
                                    //    destinationFolderPdfPath = _destinationCatalystFolderPdfPath + "\\" + host.Address.State + "\\" + eventData.EventDate.Year + "\\" + ecr.EventId;
                                    //else
                                    destinationFolderPdfPath = _destinationFolderPdfPath + "\\" + host.Address.State + "\\" + eventData.EventDate.Year + "\\" + ecr.EventId;

                                    var eventDirectoryPdf = GetDestinationFolderPath(destinationFolderPdfPath, customer, eventData.EventDate);

                                    var destinationFilename = "";

                                    if (!string.IsNullOrEmpty(customer.GroupName))
                                    {
                                        destinationFilename = RemoveIllegalFileChar(customer.GroupName) + "_" + RemoveIllegalFileChar(customer.InsuranceId);
                                    }
                                    else
                                    {
                                        destinationFilename = "NoGroup_" + RemoveIllegalFileChar(customer.InsuranceId);
                                    }

                                    if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                        destinationFilename += "_" + corporateAccount.PennedBackText;

                                    if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.PDF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                                    {
                                        var fileName = "UHC_" + _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, destinationFilename, (long)ResultFormatType.PDF);
                                        var resultPdfFile = eventDirectoryPdf + "/" + fileName + ".pdf";
                                        _resultPdfDownloadHelper.ExportResultInPdfFormat(fileName + ".pdf", sourcePath, eventDirectoryPdf);

                                        if (File.Exists(resultPdfFile))
                                        {
                                            var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, resultPdfFile);
                                        }
                                        else
                                        {
                                            _logger.Info("File Not Found : " + resultPdfFile);
                                        }

                                        if (!string.IsNullOrEmpty(customer.GroupName) && _wellmedCustomerGroupName.Contains(customer.GroupName.ToLower()))
                                        {
                                            destinationCatalystFolderPdfPath = _destinationCatalystFolderPdfPath + "\\" + host.Address.State + "\\" + eventData.EventDate.Year + "\\" + ecr.EventId;
                                            var resultCatalystPdfFile = destinationCatalystFolderPdfPath + "/" + fileName + ".pdf";

                                            _resultPdfDownloadHelper.ExportResultInPdfFormat(fileName + ".pdf", sourcePath, destinationCatalystFolderPdfPath);

                                            if (File.Exists(resultCatalystPdfFile))
                                            {
                                                var pgpCatalystFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, resultCatalystPdfFile);
                                            }
                                            else
                                            {
                                                _logger.Info("File Not Found : " + resultCatalystPdfFile);
                                            }
                                        }


                                        if (_sendReportToSftp)
                                        {
                                            var destinationSftpfolderPath = _destinationSftpFolderPdfPath + "\\" + host.Address.State + "\\" + eventData.EventDate.Year + "\\" + ecr.EventId;
                                            var resultPostedToSftp = false;

                                            if (ExportResultInSftp(fileName + ".pdf", sourcePath, destinationSftpfolderPath)) //GetDestinationFolderPath(destinationSftpfolderPath, customer, eventData.EventDate)
                                            {
                                                _logger.Info(string.Format("File Moved to Wellmed Sftp location for customer Id {0} and eventId {1}", ecr.CustomerId, ecr.EventId));
                                                resultPostedToSftp = true;
                                            }

                                            if (resultPostedToSftp && !string.IsNullOrEmpty(customer.GroupName) && _wellmedCustomerGroupName.Contains(customer.GroupName.ToLower()))
                                            {
                                                var destinationSftpCatalystfolderPath = _destinationSftpCatalystFolderPdfPath + "\\" + host.Address.State + "\\" + eventData.EventDate.Year + "\\" + ecr.EventId;
                                                if (ExportResultInSftp(fileName + ".pdf", sourcePath, destinationSftpCatalystfolderPath))
                                                {
                                                    _logger.Info(string.Format("File Moved to Wellmed Catalyst Sftp location for customer Id {0} and eventId {1}", ecr.CustomerId, ecr.EventId));
                                                }
                                                else
                                                    resultPostedToSftp = false;
                                            }

                                            if (resultPostedToSftp)
                                            {
                                                resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, fileName + ".pdf", (long)ResultFormatType.PDF, customer, ecr.Id));
                                            }
                                            else
                                            {
                                                newSftpFailedCustomers.EventCustomerIds.Add(ecr.Id);
                                            }
                                        }
                                    }

                                    if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.TIF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                                    {
                                        var fileName = "UHC_" + _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, destinationFilename, (long)ResultFormatType.TIF);
                                        var resultTifFile = eventDirectoryPdf + "/" + fileName + ".tif";

                                        _resultPdfDownloadHelper.ExportResultInTiffFormat(fileName + ".tif", sourcePath, eventDirectoryPdf);

                                        if (File.Exists(resultTifFile))
                                        {
                                            var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, resultTifFile);
                                            resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, Path.GetFileName(pgpFilePath), (long)ResultFormatType.TIF, customer, ecr.Id));
                                        }
                                        else
                                        {
                                            _logger.Info(string.Format("File {0} not Exit for pgp Encryption ", resultTifFile));
                                        }
                                    }
                                }
                                else
                                {
                                    _logger.Info(string.Format("member id is not found for customer {0} and eventId {1}", ecr.CustomerId, ecr.EventId));
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

                    _customerResultsFailedOnSftpSerializer.SerializeandSave(sftpFailedRecordsFileName, newSftpFailedCustomers);
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

        private string GetDestinationFolderPath(string destinationPathStart, Customer customer, DateTime eventDate)
        {
            var completeDestinationPath = destinationPathStart;
            //if (!string.IsNullOrEmpty(customer.Market))
            //{
            //    completeDestinationPath = completeDestinationPath + @"\" + RemoveIllegalFileChar(customer.Market);
            //}
            //else
            //{
            //    completeDestinationPath = completeDestinationPath + @"\" + "NoMarket";
            //}

            //completeDestinationPath = completeDestinationPath + @"\" + eventDate.ToString("MM-dd-yyyy");

            return completeDestinationPath;
        }

        private bool ExportResultInSftp(string fileName, string sourcePath, string eventSftpPdfDirectory)
        {
            _logger.Info("Destination Path:  " + eventSftpPdfDirectory + "\\" + fileName);
            _logger.Info("Source Path: " + sourcePath);

            var processFtp = new ProcessFtp(_logger, _sftpHost, _sftpUserName, _sftpPassword);
            return processFtp.UploadSingleFileOnSftp(sourcePath, eventSftpPdfDirectory, fileName);
        }

        private string RemoveIllegalFileChar(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return string.Empty;

            return fileName
                    .Replace('/', ' ')
                    .Replace('\\', ' ')
                    .Replace('*', ' ')
                    .Replace('.', ' ')
                    .Replace('"', ' ')
                    .Replace('[', ' ')
                    .Replace(']', ' ')
                    .Replace(':', ' ')
                    .Replace(';', ' ')
                    .Replace('|', ' ')
                    .Replace('=', ' ')
                    .Replace(',', ' ')
                    .Replace('?', ' ')
                    .Replace('<', ' ')
                    .Replace('>', ' ')
                    .Trim();
        }
    }
}
