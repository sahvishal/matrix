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
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class AnthemCaResultPdfDownloadPollingAgent : IAnthemCaResultPdfDownloadPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ISettings _settings;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly IResultPdfDownloadPollingAgentHelper _resultPdfDownloaderHelper;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IXmlSerializer<ResultPdfPostedXml> _resultPdfPostedSerializer;

        private readonly ILogger _logger;

        private readonly string _customSettingFile;
        private readonly string _destinationFolderPdfPath;

        private readonly long _accountId;
        private readonly DateTime _cutOfDate;

        private readonly string _resultPostedToPlanPath;
        private readonly IResultPdfFileHelper _resultPdfFileHelper;
        private readonly IXmlSerializer<ResultPdfNotPosted> _resultPdfNotPostedSerializer;
        private readonly IResultPdfEmailNotificationHelper _resultPdfEmailNotificationHelper;

        public AnthemCaResultPdfDownloadPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, ISettings settings, ILogManager logManager, IMediaRepository mediaRepository, ICustomSettingManager customSettingManager,
            IUniqueItemRepository<CorporateAccount> corporateAccountRepository, IResultPdfDownloadPollingAgentHelper resultPdfDownloaderHelper, IPgpFileEncryptionHelper pgpFileEncryptionHelper, ICustomerRepository customerRepository,
            IEventRepository eventRepository, IResultPdfFileHelper resultPdfFileHelper, IXmlSerializer<ResultPdfPostedXml> resultPdfPostedSerializer,
            IXmlSerializer<ResultPdfNotPosted> resultPdfNotPostedSerializer, IResultPdfEmailNotificationHelper resultPdfEmailNotificationHelper)
        {
            _cutOfDate = settings.AnthemDownloadCutOfDate;
            _settings = settings;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _mediaRepository = mediaRepository;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;

            _resultPdfDownloaderHelper = resultPdfDownloaderHelper;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _resultPostedToPlanPath = settings.ResultPostedToPlanPath;
            _resultPdfFileHelper = resultPdfFileHelper;
            _resultPdfPostedSerializer = resultPdfPostedSerializer;

            _logger = logManager.GetLogger("Anthem CA ResultPdf");

            _accountId = settings.AnthemAccountId;
            _customSettingFile = settings.PcpResultPdfDownloadSettings;
            _destinationFolderPdfPath = settings.PcpResultPdfDownloadPath;
            _resultPdfNotPostedSerializer = resultPdfNotPostedSerializer;
            _resultPdfEmailNotificationHelper = resultPdfEmailNotificationHelper;
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

                    var destinationFolderPdf = _settings.AnthemDownloadPath;
                    var customSettingFilePath = string.Format(_customSettingFile, corporateAccount.Tag);
                    var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                    var exportToTime = DateTime.Now.AddHours(-1);
                    var exportFromTime = customSettings.LastTransactionDate ?? _cutOfDate;
                    
                    DateTime? stopSendingPdftoHealthPlanDate = null;
                    if (corporateAccount.IsHealthPlan)
                    {
                        stopSendingPdftoHealthPlanDate = _settings.StopSendingPdftoHealthPlanDate;
                    }
                  
                    var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsToFax((int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false, exportToTime, exportFromTime,
                            corporateAccount.Id, corporateAccount.Tag, true, stopSendingPdftoHealthPlanDate: stopSendingPdftoHealthPlanDate);

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
                        return;
                    }

                    _logger.Info(string.Format("Found {0} customers for {1} Result Pdf Download. ", eventCustomerResults.Count(), corporateAccount.Tag));

                    var pcpResultReport = _mediaRepository.GetPdfFileNameForPcpResultReport();

                    var healthPlanResultReport = _mediaRepository.GetPdfFileNameForHealthPlanResultReport();

                    var resultPostedToPlanFileName = Path.Combine(_resultPostedToPlanPath, string.Format("ResultPostedto_{0}.xml", corporateAccount.Tag));
                    var resultPosted = _resultPdfPostedSerializer.Deserialize(resultPostedToPlanFileName);
                    resultPosted = resultPosted == null || resultPosted.Customer.IsNullOrEmpty() ? new ResultPdfPostedXml { Customer = new List<CustomerInfo>() } : resultPosted;

                    var eventsCollection = ((IUniqueItemRepository<Event>)_eventRepository).GetByIds(customerResults.Select(x => x.EventId).Distinct().ToArray());

                    foreach (var ecr in customerResults)
                    {

                        var customerData = _customerRepository.GetCustomer(ecr.CustomerId);
                        if (string.IsNullOrEmpty(customerData.InsuranceId))
                        {
                            _logger.Info("Customer Id: " + customerData.CustomerId + " does not contain Member Id");
                        }

                        var eventData = eventsCollection.Single(x => x.Id == ecr.EventId);

                        var sourcePath = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + healthPlanResultReport;

                        if (!DirectoryOperationsHelper.IsFileExist(sourcePath))
                        {
                            sourcePath = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + pcpResultReport;
                        }

                        if (DirectoryOperationsHelper.IsFileExist(sourcePath))
                        {
                            try
                            {
                                var eventDirectoryPdf = destinationFolderPdf;

                                if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.PDF)
                                {
                                    var patientMemerId = string.IsNullOrEmpty(customerData.InsuranceId) ? "No_MemberId_" + ecr.CustomerId + "_" : customerData.InsuranceId + "_";

                                    var pdfFileName = RemoveIllegalFileChar("HLTHFAIR_" + patientMemerId + ecr.EventId);

                                    if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                        pdfFileName += "_" + corporateAccount.PennedBackText;

                                    pdfFileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, pdfFileName, (long)ResultFormatType.PDF);
                                    //var pdfResultFile = eventDirectoryPdf + "/" + pdfFileName + ".pdf";

                                    var pdfResultFile = Path.Combine(eventDirectoryPdf, pdfFileName + ".pdf");

                                    _resultPdfDownloaderHelper.ExportResultInPdfFormat(pdfFileName + ".pdf", sourcePath, eventDirectoryPdf);

                                    if (DirectoryOperationsHelper.IsFileExist(pdfResultFile))
                                    {
                                        var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, pdfResultFile);
                                        resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, Path.GetFileName(pgpFilePath), (long)ResultFormatType.PDF, customerData, ecr.Id));

                                        _logger.Info("Source: " + sourcePath);
                                        _logger.Info("destination: " + pdfResultFile);
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
                                    var patientMemerId = string.IsNullOrEmpty(customerData.InsuranceId) ? "No_MemberId_" + ecr.CustomerId + "_" : customerData.InsuranceId + "_";

                                    var fileName = RemoveIllegalFileChar("HLTHFAIR_" + patientMemerId + ecr.EventId);
                                   
                                    if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                        fileName += "_" + corporateAccount.PennedBackText;

                                    fileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, fileName, (long)ResultFormatType.TIF);
                                    // var tipResultFile = eventDirectoryPdf + "/" + fileName + ".tif";
                                    var tipResultFile = Path.Combine(eventDirectoryPdf, fileName + ".tif");
                                    _resultPdfDownloaderHelper.ExportResultInTiffFormat(ecr.CustomerId + ".tif", sourcePath, eventDirectoryPdf);

                                    if (DirectoryOperationsHelper.IsFileExist(tipResultFile))
                                    {
                                        var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, tipResultFile);
                                        resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, Path.GetFileName(pgpFilePath), (long)ResultFormatType.TIF, customerData, ecr.Id));

                                        _logger.Info("Source: " + sourcePath);
                                        _logger.Info("destination: " + tipResultFile);
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

                    _resultPdfNotPostedSerializer.SerializeandSave(resultNotPostedToPlanFileName, resultNotPosted);

                    if (resultNotPosted.EventCustomer.Count > 0)
                        _resultPdfEmailNotificationHelper.SendEmailNotificationForFileNotPosted(corporateAccount.Tag, resultNotPosted.EventCustomer.Count, _logger);

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