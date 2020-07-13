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


namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class BcbsResultPdfDownloadPollingAgent : IBcbsResultPdfDownloadPollingAgent
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

        private readonly IEnumerable<long> _accountIds;
        private readonly DateTime _cutOfDate;

        private readonly string _resultPostedToPlanPath;

        public BcbsResultPdfDownloadPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, ISettings settings, ILogManager logManager,
            IMediaRepository mediaRepository, ICustomSettingManager customSettingManager, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, ICustomerRepository customerRepository,
            IUniqueItemRepository<Event> eventRepository, IResultPdfDownloadPollingAgentHelper resultPdfDownloaderHelper, IPgpFileEncryptionHelper pgpFileEncryptionHelper, IXmlSerializer<ResultPdfPostedXml> resultPdfPostedSerializer, IResultPdfFileHelper resultPdfFileHelper)
        {
            _cutOfDate = settings.PcpDownloadCutOfDate;

            _settings = settings;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _mediaRepository = mediaRepository;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _resultPdfDownloaderHelper = resultPdfDownloaderHelper;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _resultPdfPostedSerializer = resultPdfPostedSerializer;
            _resultPdfFileHelper = resultPdfFileHelper;

            _logger = logManager.GetLogger("BCBS ResultPdf");

            _accountIds = settings.BcbsAccountIds;
            _customSettingFile = settings.PcpResultPdfDownloadSettings;
            _destinationFolderPdfPath = settings.BcbsResultPdfDownloadPath;
            _resultPostedToPlanPath = settings.ResultPostedToPlanPath;
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
                        var customSettingFilePath = string.Format(_customSettingFile, corporateAccount.Tag);
                        var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                        var exportToTime = DateTime.Now.AddHours(-1);
                        var exportFromTime = customSettings.LastTransactionDate ?? _cutOfDate;

                        _logger.Info("From Time: " + exportFromTime.ToShortDateString());
                        _logger.Info("From Time: " + exportToTime.ToShortDateString());
                       
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
                                    if (customer.DateOfBirth.HasValue && !string.IsNullOrEmpty(customer.InsuranceId))
                                    {
                                        var lastName = string.IsNullOrEmpty(customer.Name.LastName) ? string.Empty : customer.Name.LastName.Trim();
                                        var firstName = string.IsNullOrEmpty(customer.Name.FirstName) ? string.Empty : customer.Name.FirstName.Trim();

                                        //destinationFileName = string.Format("0000000000000000000009492_{0}_{1}_{2}_{3}", lastName, firstName, customer.DateOfBirth.Value.ToString("yyyy-MM-dd"), eventData.EventDate.Year);
                                        destinationFileName = string.Format("{4}_{0}_{1}_{2}_{3}", lastName, firstName, customer.DateOfBirth.Value.ToString("yyyy-MM-dd"), eventData.EventDate.Year, customer.InsuranceId);
                                        //var destinationFolderPdfPathWithEventId = destinationFolderPdfPath + "/" + ecr.EventId + "/";

                                        if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                            destinationFileName += "_" + corporateAccount.PennedBackText;

                                        if (!string.IsNullOrEmpty(destinationFileName))
                                        {
                                            if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.PDF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                                            {
                                                //  var pdfResultFile = destinationFolderPdfPathWithEventId + destinationFileName + ".pdf";

                                                var fileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, destinationFileName, (long)ResultFormatType.PDF);
                                                _logger.Info("destination: " + destinationFolderPdfPath + "//" + fileName);
                                                _logger.Info("source: " + sourcePath);

                                                var pdfResultFile = destinationFolderPdfPath + "/" + fileName + ".pdf";
                                                _resultPdfDownloaderHelper.ExportResultInPdfFormat(fileName + ".pdf", sourcePath, destinationFolderPdfPath);

                                                if (File.Exists(pdfResultFile))
                                                {
                                                    var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, pdfResultFile);
                                                    resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, Path.GetFileName(pgpFilePath), (long)ResultFormatType.PDF, customer, ecr.Id));
                                                }
                                            }

                                            if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.TIF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                                            {
                                                //var tifResultFile = destinationFolderPdfPathWithEventId + destinationFileName + ".tif";

                                                var fileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, destinationFileName, (long)ResultFormatType.TIF);

                                                var tifResultFile = destinationFolderPdfPath + "/" + fileName + ".tif";
                                                _resultPdfDownloaderHelper.ExportResultInTiffFormat(fileName + ".tif", sourcePath, destinationFolderPdfPath);

                                                if (File.Exists(tifResultFile))
                                                {
                                                    var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, tifResultFile);
                                                    resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, Path.GetFileName(pgpFilePath), (long)ResultFormatType.TIF, customer, ecr.Id));
                                                }
                                            }
                                        }

                                    }
                                    else
                                    {
                                        _logger.Info("customer does not have DOB and MemberId for customer Id: " + customer.CustomerId + " Event Id: " + eventData.Id);
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

            }
            catch (Exception exception)
            {

                _logger.Error(string.Format("some error occured Exception Message: \n{0}, \n stack Trace: \n\t {1} ", exception.Message, exception.StackTrace));
            }
        }
    }
}
