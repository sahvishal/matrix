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
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class FloridaBlueResultPdfDownloadPollingAgent : IFloridaBlueResultPdfDownloadPollingAgent
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
        private readonly IZipHelper _zipHelper;
        private readonly IXmlSerializer<ResultPdfPostedXml> _resultPdfPostedSerializer;
        private readonly IResultPdfFileHelper _resultPdfFileHelper;

        private readonly ILogger _logger;

        private readonly string _customSettingFile;
        private readonly string _destinationFolderPdfPath;

        private readonly DateTime _cutOfDate;
        private readonly DayOfWeek _dayOfWeek;

        private const string FileNamePrefix = "GWC_CW";

        public FloridaBlueResultPdfDownloadPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, ISettings settings, ILogManager logManager,
            IMediaRepository mediaRepository, ICustomSettingManager customSettingManager, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, ICustomerRepository customerRepository,
            IUniqueItemRepository<Event> eventRepository, IResultPdfDownloadPollingAgentHelper resultPdfDownloaderHelper, IPgpFileEncryptionHelper pgpFileEncryptionHelper, IZipHelper zipHelper,
            IXmlSerializer<ResultPdfPostedXml> resultPdfPostedSerializer, IResultPdfFileHelper resultPdfFileHelper)
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
            _zipHelper = zipHelper;
            _resultPdfPostedSerializer = resultPdfPostedSerializer;
            _resultPdfFileHelper = resultPdfFileHelper;

            _logger = logManager.GetLogger("Florida Blue ResultPdf");

            _customSettingFile = settings.PcpResultPdfDownloadSettings;
            _destinationFolderPdfPath = settings.PcpResultPdfDownloadPath;
            _dayOfWeek = _settings.FloridaBlueReportsDayOfWeek;
        }

        public void PollForPdfDownload()
        {
            try
            {
                if (DateTime.Today.DayOfWeek != _dayOfWeek)
                {
                    _logger.Info(string.Format("Today is {0}. Job is set to run on {1}.", DateTime.Today.DayOfWeek, _dayOfWeek));
                    return;
                }

                var accountIds = new List<long>();
                if (string.IsNullOrEmpty(_settings.FloridaBlueAccountId))
                {
                    _logger.Info("No account Ids found.");
                    return;
                }

                var partnerIdsArray = _settings.FloridaBlueAccountId.Split(',').Where(hospitalIdstr => !string.IsNullOrEmpty(hospitalIdstr)).Select(x => x.Trim());

                foreach (var hospitalIdstr in partnerIdsArray)
                {
                    long pcpAccountId;
                    long.TryParse(hospitalIdstr, out pcpAccountId);
                    if (pcpAccountId > 0)
                    {
                        accountIds.Add(pcpAccountId);
                    }
                }

                var corporateAccounts = _corporateAccountRepository.GetByIds(accountIds);

                foreach (var corporateAccount in corporateAccounts)
                {
                    try
                    {
                        _logger.Info(string.Format("Generating for accountId {0} and account tag {1}. ", corporateAccount.Id, corporateAccount.Tag));

                        var destinationFolderPdfPath = string.Format(_destinationFolderPdfPath, corporateAccount.FolderName);
                        var customSettingFilePath = string.Format(_customSettingFile, corporateAccount.Tag);
                        var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                        var exportToTime = DateTime.Now.AddHours(-1);
                        var exportFromTime = customSettings.LastTransactionDate ?? _cutOfDate;

                        var folderName = string.Format("HLF_GWC_CW_{0}", exportToTime.ToString("yyyyMMddHHmmssfff"));
                        var destinationFolderPdfPathWithCustomFolder = destinationFolderPdfPath + "/" + folderName + "/";
                        
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
                            continue;
                        }

                        DirectoryOperationsHelper.CreateDirectoryIfNotExist(_settings.ResultPostedToPlanPath);

                        var resultPostedToPlanFileName = Path.Combine(_settings.ResultPostedToPlanPath, string.Format("resultPostedto_{0}.xml", corporateAccount.Tag));
                        var resultPosted = _resultPdfPostedSerializer.Deserialize(resultPostedToPlanFileName);
                        resultPosted = resultPosted ?? new ResultPdfPostedXml { Customer = new List<CustomerInfo>() };

                        //TODO: Foreach loop for one time use......TO BE REMOVED
                        foreach (var customerInfo in resultPosted.Customer.Where(x => x.FileType == 0))
                        {
                            customerInfo.FileType = (long)ResultFormatType.PDF;
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
                                    if (!string.IsNullOrEmpty(customer.InsuranceId))
                                    {
                                        destinationFileName = string.Format("{0}_{1}", FileNamePrefix, customer.InsuranceId);
                                    }
                                    else
                                    {
                                        destinationFileName = string.Format("{0}_NoMemberId_{1}", FileNamePrefix, customer.CustomerId);
                                    }

                                    if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                        destinationFileName += "_" + corporateAccount.PennedBackText;

                                    _logger.Info("Moving pdf file for customer Id: " + customer.CustomerId + " Event Id: " + eventData.Id);

                                    if (!string.IsNullOrEmpty(destinationFileName))
                                    {
                                        if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.PDF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                                        {
                                            var pdfResultFile = destinationFolderPdfPathWithCustomFolder + destinationFileName + ".pdf";
                                            _resultPdfDownloaderHelper.ExportResultInPdfFormat(destinationFileName + ".pdf", sourcePath, destinationFolderPdfPathWithCustomFolder);

                                            if (File.Exists(pdfResultFile))
                                            {
                                                var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, pdfResultFile);

                                                resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, Path.GetFileName(pgpFilePath), (long)ResultFormatType.PDF, customer, ecr.Id));
                                            }
                                        }

                                        if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.TIF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                                        {
                                            var tifResultFile = destinationFolderPdfPathWithCustomFolder + destinationFileName + ".tif";
                                            _resultPdfDownloaderHelper.ExportResultInTiffFormat(destinationFileName + ".tif", sourcePath, destinationFolderPdfPathWithCustomFolder);

                                            if (File.Exists(tifResultFile))
                                            {
                                                var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, tifResultFile);
                                                resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, Path.GetFileName(pgpFilePath), (long)ResultFormatType.TIF, customer, ecr.Id));
                                            }
                                        }
                                    }
                                    //else
                                    //{
                                    //    _logger.Info("customer info does not contain member Id for customer Id: " + customer.CustomerId + " Event Id: " + eventData.Id);
                                    //}
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
                        resultPosted = CorrectMissingRecords(resultPosted);
                        _resultPdfPostedSerializer.SerializeandSave(resultPostedToPlanFileName, resultPosted);

                        //zip folder
                        _logger.Info("Creating Zip file");

                        var sourceDir = Directory.GetParent(destinationFolderPdfPathWithCustomFolder).FullName;

                        var outputPath = sourceDir + ".zip";

                        _zipHelper.CreateZipFiles(sourceDir, outputPath, true);

                        string directoryName = Path.GetDirectoryName(outputPath) + "\\" + Path.GetFileNameWithoutExtension(outputPath);


                        _logger.Info("Deleting directory " + directoryName);
                        if (Directory.Exists(directoryName))
                        {
                            try
                            {
                                foreach (var file in Directory.GetFiles(directoryName))
                                {
                                    File.Delete(file);
                                }

                                Directory.Delete(directoryName, true);
                            }
                            catch (Exception exception)
                            {
                                _logger.Error(string.Format("Error while deleting directory {0}. Exception Message: \n{1}, \n stack Trace: \n\t {2}", directoryName, exception.Message, exception.StackTrace));
                            }
                        }

                        customSettings.LastTransactionDate = exportToTime;
                        _customSettingManager.SerializeandSave(customSettingFilePath, customSettings);

                        _logger.Info("Completed");

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
                    if (!string.IsNullOrEmpty(customerInfo.MemberId))
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

            return new ResultPdfPostedXml { Customer = customersInfo.ToList() };
        }
    }
}
