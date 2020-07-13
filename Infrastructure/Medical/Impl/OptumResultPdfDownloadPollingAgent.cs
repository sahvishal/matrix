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
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class OptumResultPdfDownloadPollingAgent : IOptumResultPdfDownloadPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ISettings _settings;

        private readonly IMediaRepository _mediaRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ILogger _logger;
        private readonly IXmlSerializer<CustomerWithNoGmpiViewModel> _customerWithNoMrn;

        private readonly string _customSettingFile;
        private readonly string _destinationFolderPdfSetting;
        private readonly string _customerWithNoMrnPath;

        private readonly IEnumerable<long> _accountIds;
        private readonly IEnumerable<long> _monarchAccountIds;

        private readonly DateTime _cutOfDate;

        private readonly IResultPdfDownloadPollingAgentHelper _resultPdfDownloadHelper;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IResultPdfFileHelper _resultPdfFileHelper;
        private readonly IXmlSerializer<ResultPdfPostedXml> _resultPdfPostedSerializer;
        private readonly IEventRepository _eventRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IEnumerable<long> _optumAccountIds;

        private readonly string _resultPostedToPlanPath;
        const int PageSize = 100;

        private readonly DateTime _stopSendingPdftoHealthPlanDate;

        public OptumResultPdfDownloadPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, ISettings settings, ILogManager logManager,
            IMediaRepository mediaRepository, ICustomSettingManager customSettingManager, ICorporateAccountRepository corporateAccountRepository,
            IResultPdfDownloadPollingAgentHelper resultPdfDownloadHelper, IPgpFileEncryptionHelper pgpFileEncryptionHelper,
            ICustomerRepository customerRepository, IResultPdfFileHelper resultPdfFileHelper, IXmlSerializer<ResultPdfPostedXml> resultPdfPostedSerializer, IEventRepository eventRepository,
            IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, IXmlSerializer<CustomerWithNoGmpiViewModel> customerWithNoMrn)
        {
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _settings = settings;
            _mediaRepository = mediaRepository;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;

            _resultPdfDownloadHelper = resultPdfDownloadHelper;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _customerRepository = customerRepository;
            _resultPdfFileHelper = resultPdfFileHelper;
            _resultPdfPostedSerializer = resultPdfPostedSerializer;
            _eventRepository = eventRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _customerWithNoMrn = customerWithNoMrn;

            _logger = logManager.GetLogger("Optum Result Pdf");

            _customSettingFile = settings.PcpResultPdfDownloadSettings;
            _destinationFolderPdfSetting = settings.OptumResultPdfDownloadPath;
            _customerWithNoMrnPath = settings.CustomerWithNoMrnPath;
            _accountIds = settings.OptumResultPdfDownloadAccountIds;
            _cutOfDate = settings.PcpDownloadCutOfDate;

            _monarchAccountIds = settings.MonarchAccountIds;
            _customSettingFile = settings.PcpResultPdfDownloadSettings;
            _resultPostedToPlanPath = settings.ResultPostedToPlanPath;

            _optumAccountIds = settings.OptumAccountIds;

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
                        _logger.Info(string.Format("Generating for accountId {0} and account tag {1}. ", corporateAccount.Id, corporateAccount.Tag));

                        var destinationFolderPdf = string.Format(_destinationFolderPdfSetting, corporateAccount.FolderName);
                        var customSettingFilePath = string.Format(_customSettingFile, corporateAccount.Tag);
                        var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                        var exportToTime = DateTime.Now.AddHours(-1);
                        var exportFromTime = customSettings.LastTransactionDate ?? _cutOfDate;

                        DateTime? stopSendingPdftoHealthPlanDate = null;
                        if (corporateAccount.IsHealthPlan)
                        {
                            stopSendingPdftoHealthPlanDate = _stopSendingPdftoHealthPlanDate;
                        }
                        _logger.Info("exportToTime: " + exportToTime.ToString("MM/dd/yyyy"));
                        _logger.Info("exportFromTime: " + exportFromTime.ToString("MM/dd/yyyy"));

                        var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsToFax((int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false, exportToTime, exportFromTime, corporateAccount.Id, corporateAccount.Tag, true, stopSendingPdftoHealthPlanDate: stopSendingPdftoHealthPlanDate);

                        var customerResults = eventCustomerResults as EventCustomerResult[] ?? eventCustomerResults.ToArray();

                        if (eventCustomerResults == null || !customerResults.Any())
                        {
                            _logger.Info(string.Format("No event customer result list for {0} Result Pdf Download.", corporateAccount.Tag));
                            continue;
                        }

                        if (_optumAccountIds.Contains(corporateAccount.Id))
                        {
                            try
                            {
                                DirectoryOperationsHelper.DeleteDirectory(destinationFolderPdf, true);
                            }
                            catch (Exception ex)
                            {
                                _logger.Error("Some error occurred while deleting directory at path: " + destinationFolderPdf);
                                _logger.Error("Message: " + ex.Message);
                                _logger.Error("Stack Trace: " + ex.StackTrace);
                            }
                        }

                        _logger.Info(string.Format("Found {0} customers for {1} Result Pdf Download. ", eventCustomerResults.Count(), corporateAccount.Tag));

                        var pcpResultReport = _mediaRepository.GetPdfFileNameForPcpResultReport();

                        var healthPlanResultReport = _mediaRepository.GetPdfFileNameForHealthPlanResultReport();

                        var resultPostedToPlanFileName = Path.Combine(_resultPostedToPlanPath, string.Format("ResultPostedto_{0}.xml", corporateAccount.Tag));
                        var resultPosted = _resultPdfPostedSerializer.Deserialize(resultPostedToPlanFileName);
                        resultPosted = resultPosted == null || resultPosted.Customer.IsNullOrEmpty() ? new ResultPdfPostedXml { Customer = new List<CustomerInfo>() } : resultPosted;

                        _logger.Info(string.Format("Result Pdf file Transfer started for {0} ", corporateAccount.Tag));

                        var customersWithNoMrn = new List<long>();
                        var newCustomersWithNoMrn = new List<long>();

                        foreach (var ecr in customerResults)
                        {
                            var sourceUrl = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + healthPlanResultReport;

                            if (!File.Exists(sourceUrl))
                            {
                                sourceUrl = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + pcpResultReport;
                            }

                            if (File.Exists(sourceUrl))
                            {
                                try
                                {
                                    SetReusltPdfNameing(ecr, corporateAccount, destinationFolderPdf, sourceUrl, resultPosted, newCustomersWithNoMrn);
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

                        if (corporateAccount.Id == _settings.OptumNvAccountId || corporateAccount.Id == _settings.OptumNvMedicareAccountId)
                        {
                            _logger.Info("Sending Old Files to SFTP");

                            PostCustomerWithNoMrn(corporateAccount, destinationFolderPdf, resultPosted, customersWithNoMrn);

                            _logger.Info("Sending Old Files to SFTP Completed");

                            if (!customersWithNoMrn.IsNullOrEmpty())
                                newCustomersWithNoMrn.AddRange(customersWithNoMrn);

                            newCustomersWithNoMrn = newCustomersWithNoMrn.Distinct().ToList();

                            SaveCustomersWithNoMrn(corporateAccount, newCustomersWithNoMrn);
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
                                DirectoryOperationsHelper.CreateDirectoryIfNotExist(pdfLogfile);
                                if (DirectoryOperationsHelper.IsDirectoryExist(pdfLogfile))
                                {
                                    var filesTobedeleted = DirectoryOperationsHelper.GetFiles(pdfLogfile, "*" + corporateAccount.Tag + "_PdfLogFile*");
                                    foreach (var logFile in filesTobedeleted)
                                    {
                                        DirectoryOperationsHelper.DeleteFileIfExist(logFile);
                                    }
                                }

                                var resultPostedCustomers = resultPosted.Customer.Where(x => x.EventDate.HasValue && x.EventDate.Value.Year >= _cutOfDate.Year);
                                _resultPdfFileHelper.CreateCsvForFileShared(resultPostedCustomers, pdfLogfile, corporateAccount.Tag + "_PdfLogFile");
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

                        _logger.Info(string.Format("Result Pdf file Transfer completed for {0} ", corporateAccount.Tag));
                        _logger.Info("");
                        _logger.Info("");
                        _logger.Info("================================================================================");

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

        private void SetReusltPdfNameing(EventCustomerResult ecr, CorporateAccount corporateAccount, string destinationFolderPdfPath, string sourcePath, ResultPdfPostedXml resultPosted, List<long> newCustomersWithNoMrn)
        {
            var eventDirectoryPdf = destinationFolderPdfPath + "\\" + ecr.EventId;
            var destinationFilename = ecr.CustomerId.ToString();
            var customer = _customerRepository.GetCustomer(ecr.CustomerId);
            var eventData = _eventRepository.GetById(ecr.EventId);

            if (_optumAccountIds.Contains(corporateAccount.Id))
            {
                eventDirectoryPdf = destinationFolderPdfPath;
            }

            if (corporateAccount.Id == _settings.OptumNvAccountId || corporateAccount.Id == _settings.OptumNvMedicareAccountId)
            {
                if (!string.IsNullOrEmpty(customer.Mrn))
                {
                    destinationFilename = customer.Mrn + "_" + eventData.EventDate.ToString("yyyyMMdd");
                    var customerPcp = _primaryCarePhysicianRepository.Get(ecr.CustomerId);
                    destinationFilename += (customerPcp != null ? "_" + customerPcp.Name.LastName : "");
                }
                else
                {
                    newCustomersWithNoMrn.Add(ecr.CustomerId);
                    _logger.Info("MRN not available for Customer ID : " + ecr.CustomerId);
                    return;
                }
            }

            if (_monarchAccountIds.Contains(corporateAccount.Id))
            {
                destinationFilename = ResultFileName(customer);
            }

            if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                destinationFilename += "_" + corporateAccount.PennedBackText;

            if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.PDF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
            {
                var fileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, destinationFilename, (long)ResultFormatType.PDF);

                var resultPdfFile = eventDirectoryPdf + "/" + fileName + ".pdf";
                _resultPdfDownloadHelper.ExportResultInPdfFormat(fileName + ".pdf", sourcePath, eventDirectoryPdf);

                _logger.Info("source Url: " + sourcePath);
                _logger.Info("destination Url: " + eventDirectoryPdf + "/" + fileName + ".pdf");

                if (File.Exists(resultPdfFile))
                {
                    var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, resultPdfFile);

                    resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, Path.GetFileName(pgpFilePath), (long)ResultFormatType.PDF, customer, ecr.Id));
                }
                else
                {
                    _logger.Info("File Not Found : " + resultPdfFile);
                }
            }

            if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.TIF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
            {
                var fileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, destinationFilename, (long)ResultFormatType.TIF);

                var resultTifFile = eventDirectoryPdf + "/" + fileName + ".tif";
                _resultPdfDownloadHelper.ExportResultInTiffFormat(fileName + ".tif", sourcePath, eventDirectoryPdf);

                _logger.Info("source Url: " + sourcePath);
                _logger.Info("destination Url: " + eventDirectoryPdf + "/" + fileName + ".tif");

                if (File.Exists(resultTifFile))
                {
                    var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, resultTifFile);
                    resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, Path.GetFileName(pgpFilePath), (long)ResultFormatType.TIF, customer, ecr.Id));
                }
                else
                {
                    _logger.Info(string.Format("File {0} not Exist for pgp Encryption ", resultTifFile));
                }
            }
        }

        private void PostCustomerWithNoMrn(CorporateAccount corporateAccount, string destinationFolderPdf, ResultPdfPostedXml resultPosted, List<long> customersMrnNotUpdated)
        {
            var customers = _customerWithNoMrn.Deserialize(_customerWithNoMrnPath + "\\CustomerWithNoMrn_" + corporateAccount.Tag + ".xml");

            int pageNumber = 1;
            int totalRecords = 0;

            var customersWithMrn = new List<long>();

            var pcpResultReport = _mediaRepository.GetPdfFileNameForPcpResultReport();

            var healthPlanResultReport = _mediaRepository.GetPdfFileNameForHealthPlanResultReport();

            if (customers != null && !customers.CustomerIds.IsNullOrEmpty())
            {
                while (true)
                {
                    totalRecords = customers.CustomerIds.Count();
                    if (totalRecords < 1) break;

                    var pagedCusotmerIds = customers.CustomerIds.Skip((pageNumber - 1) * PageSize).Take(PageSize);

                    _logger.Info(string.Format("Total No of Customer: {0}, Page Number {1} ", totalRecords, pageNumber));

                    var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsByCustomerIds((int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false, corporateAccount.Id, pagedCusotmerIds, _cutOfDate);
                    foreach (var ecr in eventCustomerResults)
                    {
                        var sourceUrl = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + healthPlanResultReport;

                        if (!File.Exists(sourceUrl))
                        {
                            sourceUrl = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + pcpResultReport;
                        }

                        if (File.Exists(sourceUrl))
                        {
                            try
                            {
                                SetReusltPdfNameing(ecr, corporateAccount, destinationFolderPdf, sourceUrl, resultPosted, customersMrnNotUpdated);
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

                    if (!eventCustomerResults.IsNullOrEmpty())
                    {
                        _logger.Info(string.Format("Total Customer found With MRN: {0} ", eventCustomerResults.Count()));
                        customersWithMrn.AddRange(eventCustomerResults.Select(x => x.CustomerId));
                    }
                    else
                    {
                        _logger.Info(string.Format("No Records found"));
                    }

                    pageNumber++;
                    if ((pageNumber * PageSize) > totalRecords)
                        break;
                }

                customersMrnNotUpdated.AddRange(customers.CustomerIds.Where(c => !customersWithMrn.Contains(c)));
            }
        }

        private void SaveCustomersWithNoMrn(CorporateAccount account, List<long> customerIds)
        {
            var filePath = Path.Combine(_customerWithNoMrnPath, string.Format("CustomerWithNoMrn_{0}.xml", account.Tag));
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            if (!customerIds.IsNullOrEmpty())
            {
                var customerWithNoMrnXml = new CustomerWithNoGmpiViewModel
                {
                    CustomerIds = customerIds
                };
                _customerWithNoMrn.SerializeandSave(filePath, customerWithNoMrnXml);
            }

        }

        private string ResultFileName(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.Mrn))
            {
                return "NoGMPI_36_" + customer.CustomerId;
            }

            return RemoveIllegalFileChar(customer.Mrn) + "_36_" + customer.CustomerId;

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