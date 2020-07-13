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
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MonarchResultPdfToWellmedDownloadPollingAgent : IMonarchResultPdfToWellmedDownloadPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ISettings _settings;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ICustomerRepository _customerRepository;

        private readonly IResultPdfDownloadPollingAgentHelper _resultPdfDownloadHelper;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly ISftpCridentialManager _sftpCridentialManager;
        private readonly IZipHelper _zipHelper;
        private readonly IXmlSerializer<CustomerWithNoGmpiViewModel> _customerWithNoGmpi;
        private readonly IXmlSerializer<ResultPdfPostedXml> _resultPdfPostedSerializer;
        private readonly IResultPdfFileHelper _resultPdfFileHelper;
        private readonly IEventRepository _eventRepository;

        private readonly ILogger _logger;

        private readonly string _customSettingFile;
        private readonly string _destinationFolderPdfPath;

        private readonly IEnumerable<long> _accountIds;
        private readonly DateTime _cutOfDate;

        private readonly string _sftpCridentailPath;
        private readonly string _sftpPath;
        private readonly string _customerWithNoGmpiPath;
        private readonly bool _sendPdfToWellmed;
        private readonly string _resultPostedToPlanPath;

        private readonly DateTime _stopSendingPdftoHealthPlanDate;
        
        const int PageSize = 100;

        public MonarchResultPdfToWellmedDownloadPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, ISettings settings, ILogManager logManager,
            IMediaRepository mediaRepository, ICustomSettingManager customSettingManager, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, ICustomerRepository customerRepository,
            IResultPdfDownloadPollingAgentHelper resultPdfDownloadHelper, IPgpFileEncryptionHelper pgpFileEncryptionHelper, ISftpCridentialManager sftpCridentialManager, IZipHelper zipHelper,
            IXmlSerializer<CustomerWithNoGmpiViewModel> customerWithNoGmpi, IXmlSerializer<ResultPdfPostedXml> resultPdfPostedSerializer, IResultPdfFileHelper resultPdfFileHelper,
            IEventRepository eventRepository)
        {
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _settings = settings;
            _mediaRepository = mediaRepository;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _customerRepository = customerRepository;

            _resultPdfDownloadHelper = resultPdfDownloadHelper;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _sftpCridentialManager = sftpCridentialManager;
            _zipHelper = zipHelper;
            _customerWithNoGmpi = customerWithNoGmpi;
            _resultPdfPostedSerializer = resultPdfPostedSerializer;
            _resultPdfFileHelper = resultPdfFileHelper;
            _eventRepository = eventRepository;

            _logger = logManager.GetLogger("MonarchResultPdfToWellmed");

            _customSettingFile = settings.PcpResultPdfDownloadSettings;
            _destinationFolderPdfPath = settings.MonarchWellmedPdfPath;

            _cutOfDate = settings.PcpDownloadCutOfDate;

            _accountIds = settings.MonarchAccountIds;

            _sftpCridentailPath = settings.SftpResouceFilePath;
            _sftpPath = settings.MonarchWelledPdfSfptPath;
            _customerWithNoGmpiPath = settings.CustomerWithNoGmpiPath;
            _sendPdfToWellmed = settings.SendPdfToWellmed;
            _resultPostedToPlanPath = settings.ResultPostedToPlanPath;

            _stopSendingPdftoHealthPlanDate = settings.StopSendingPdftoHealthPlanDate;

        }

        public void PollForPdfDownload()
        {
            try
            {
                if (!_sendPdfToWellmed)
                {
                    _logger.Info("Service has been stopped. ");
                    return;
                }

                if (_accountIds.IsNullOrEmpty()) return;
                var corporateAccounts = _corporateAccountRepository.GetByIds(_accountIds);

                try
                {
                    foreach (var corporateAccount in corporateAccounts)
                    {
                        try
                        {
                            _logger.Info(string.Format("Generating for accountId {0} and account tag {1}. ", corporateAccount.Id, corporateAccount.Tag));

                            var customSettingFilePath = string.Format(_customSettingFile, corporateAccount.Tag + "_MonarchWellmedPdfPath");
                            var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                            var exportToTime = DateTime.Now.AddHours(-1);
                            var exportFromTime = customSettings.LastTransactionDate ?? _cutOfDate;
                            _logger.Info("Sending Fresh Files to SFTP");

                            DateTime? stopSendingPdftoHealthPlanDate = null;
                            if (corporateAccount.IsHealthPlan)
                            {
                                stopSendingPdftoHealthPlanDate = _stopSendingPdftoHealthPlanDate;
                            }

                            var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsToFax((int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false, exportToTime, exportFromTime,
                                corporateAccount.Id, corporateAccount.Tag, true, stopSendingPdftoHealthPlanDate : stopSendingPdftoHealthPlanDate);

                            var newCustomerListWithNoGmpi = new List<long>();
                            var customersGmpiNoUpdated = new List<long>();

                            PostResultPdfToSftp(eventCustomerResults, corporateAccount, newCustomerListWithNoGmpi);
                            _logger.Info("Sending Fresh Files to SFTP Completed");

                            _logger.Info("Sending Old File to SFTP");

                            PostCustomerWithNoGmpi(corporateAccount, customersGmpiNoUpdated);

                            _logger.Info("Sending Old File to SFTP Completed");

                            if (!customersGmpiNoUpdated.IsNullOrEmpty())
                                newCustomerListWithNoGmpi.AddRange(customersGmpiNoUpdated);

                            newCustomerListWithNoGmpi = newCustomerListWithNoGmpi.Distinct().ToList();

                            SaveCustomersWithNoGmpi(corporateAccount, newCustomerListWithNoGmpi);

                            customSettings.LastTransactionDate = exportToTime;
                            _customSettingManager.SerializeandSave(customSettingFilePath, customSettings);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(string.Format("some error occurred: \n Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
                        }

                    }
                    var resultPostedToPlanFileName = Path.Combine(_resultPostedToPlanPath, "resultPostedMonarchToWellmed.xml");
                    var resultPosted = _resultPdfPostedSerializer.Deserialize(resultPostedToPlanFileName);
                    resultPosted = resultPosted == null || resultPosted.Customer.IsNullOrEmpty() ? new ResultPdfPostedXml { Customer = new List<CustomerInfo>() } : resultPosted;

                    if (!resultPosted.Customer.IsNullOrEmpty())
                    {
                        _logger.Info("Result posted Log");

                        CorrectMissingRecords(resultPosted);
                        resultPosted = _resultPdfPostedSerializer.Deserialize(resultPostedToPlanFileName);

                        _resultPdfFileHelper.CreateCsvForFileShared(resultPosted.Customer, _destinationFolderPdfPath, "resultPostedMonarchToWellmed");

                        _logger.Info("Result posted Log Completed");
                    }

                    ZipResultPdfFiles();

                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("some error occurred: Exception Message: \n{0}, \n stack Trace: \n\t {1} ", ex.Message, ex.StackTrace));
                }
            }
            catch (Exception exception)
            {

                _logger.Error(string.Format("some error occurred Exception Message: \n{0}, \n stack Trace: \n\t {1} ", exception.Message, exception.StackTrace));
            }
        }

        private void SaveCustomersWithNoGmpi(CorporateAccount account, List<long> customerIds)
        {
            var filePath = Path.Combine(_customerWithNoGmpiPath, string.Format("CustomerWithNoGmpi_{0}.xml", account.Tag));
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            if (!customerIds.IsNullOrEmpty())
            {
                var customerWithNoGmpiXml = new CustomerWithNoGmpiViewModel
                {
                    CustomerIds = customerIds
                };
                _customerWithNoGmpi.SerializeandSave(filePath, customerWithNoGmpiXml);
            }

        }

        private void PostResultPdfToSftp(IEnumerable<EventCustomerResult> eventCustomerResults, CorporateAccount corporateAccount, List<long> newCustomerListWithNoGmpi)
        {
            var customerResults = eventCustomerResults as EventCustomerResult[] ?? eventCustomerResults.ToArray();

            if (eventCustomerResults == null || !customerResults.Any())
            {
                _logger.Info(string.Format("No event customer result list for {0} Result Pdf Download.", corporateAccount.Tag));
            }

            _logger.Info(string.Format("Found {0} customers for {1} Result Pdf Download. ", eventCustomerResults.Count(), corporateAccount.Tag));

            var resultPostedToPlanFileName = Path.Combine(_resultPostedToPlanPath, "resultPostedMonarchToWellmed.xml");
            var resultPosted = _resultPdfPostedSerializer.Deserialize(resultPostedToPlanFileName);
            resultPosted = resultPosted == null || resultPosted.Customer.IsNullOrEmpty() ? new ResultPdfPostedXml { Customer = new List<CustomerInfo>() } : resultPosted;

            var destinationFolderPdfPath = _destinationFolderPdfPath + "/pdf";
            var pcpResultReport = _mediaRepository.GetPdfFileNameForPcpResultReport();

            var healthPlanResultReport = _mediaRepository.GetPdfFileNameForHealthPlanResultReport();

            foreach (var ecr in customerResults)
            {
                var customer = _customerRepository.GetCustomer(ecr.CustomerId);
                var eventData = _eventRepository.GetById(ecr.EventId);

                if (!string.IsNullOrEmpty(customer.AdditionalField4))
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
                            var eventDirectoryPdf = destinationFolderPdfPath;
                            var destinationFilename = ResultFileName(customer);

                            if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.PDF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                            {
                                destinationFilename = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, destinationFilename, (long)ResultFormatType.PDF);

                                if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                    destinationFilename += "_" + corporateAccount.PennedBackText;

                                var resultPdfFile = eventDirectoryPdf + "/" + destinationFilename + ".pdf";

                                _resultPdfDownloadHelper.ExportResultInPdfFormat(destinationFilename + ".pdf", sourcePath, eventDirectoryPdf);

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
                                destinationFilename = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, destinationFilename, (long)ResultFormatType.TIF);

                                if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                    destinationFilename += "_" + corporateAccount.PennedBackText;

                                var resultTifFile = eventDirectoryPdf + "/" + destinationFilename + ".tif";

                                _resultPdfDownloadHelper.ExportResultInTiffFormat(destinationFilename + ".tif", sourcePath, eventDirectoryPdf);

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
                        catch (Exception exception)
                        {
                            _logger.Error(string.Format("some error occurred for the customerId {0}, {1},\n Message {2} \n Stack Trace {3}", ecr.CustomerId, ecr.EventId, exception.Message, exception.StackTrace));
                        }
                    }
                    else
                    {
                        _logger.Info(string.Format("File not generated or removed for the customerId {0}, {1}", ecr.CustomerId, ecr.EventId));
                    }
                }
                else
                {
                    if (newCustomerListWithNoGmpi != null)
                        newCustomerListWithNoGmpi.Add(customer.CustomerId);

                    _logger.Info(string.Format("Customer Id: {0}, Event id: {1} do not have GMPID ", ecr.CustomerId, ecr.EventId));
                }
            }

            _resultPdfPostedSerializer.SerializeandSave(resultPostedToPlanFileName, resultPosted);
        }

        private void ZipResultPdfFiles()
        {
            if (!Directory.Exists(_destinationFolderPdfPath + "/pdf/"))
            {
                Directory.CreateDirectory(_destinationFolderPdfPath + "/pdf/");
            }

            if (!Directory.GetFiles(_destinationFolderPdfPath + "/pdf/").Any())
            {
                _logger.Info("No file found for Posting");
                return;
            }

            var destinationfile = "HealthFair_Data_" + DateTime.Today.ToString("MMyydd") + ".zip";

            var directoryToDeleteFrom = new DirectoryInfo(_destinationFolderPdfPath);

            foreach (var file in directoryToDeleteFrom.GetFiles("HealthFair_Data_*.zip"))
            {
                _logger.Info("Deleting zip file : " + file.Name);
                file.Delete();
            }

            _logger.Info("Zip file started: " + _destinationFolderPdfPath + "\\" + destinationfile);
            var sourceFile = _destinationFolderPdfPath + "\\" + destinationfile;

            _zipHelper.CreateZipFiles(_destinationFolderPdfPath + "/pdf/", sourceFile, true);

            _logger.Info("Zip file Completed: " + _destinationFolderPdfPath + "\\" + destinationfile);

            ExportResultInSftp(destinationfile, sourceFile);

            if (!Directory.Exists(_destinationFolderPdfPath + "/ArchivePdf/"))
                Directory.CreateDirectory(_destinationFolderPdfPath + "/ArchivePdf/");

            var sourceDir = new DirectoryInfo(_destinationFolderPdfPath + "/pdf/");
            var destinationDir = new DirectoryInfo(_destinationFolderPdfPath + "/ArchivePdf/");

            DeepCopy(sourceDir, destinationDir);

        }


        public void DeepCopy(DirectoryInfo source, DirectoryInfo target)
        {
            // Recursively call the DeepCopy Method for each Directory
            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                var subDirectoryInfo = target.CreateSubdirectory(dir.Name);
                _logger.Info("Creating Subdirectory: " + subDirectoryInfo.FullName);
                DeepCopy(dir, subDirectoryInfo);
            }

            _logger.Info("Source directory: " + source.FullName);
            _logger.Info("target directory: " + target.FullName);

            var files = source.GetFiles();

            _logger.Info(files.Count() + " files in Source Directory to Copy");

            // Go ahead and copy each file in "source" to the "target" directory
            foreach (FileInfo file in files)
            {
                var destinationFilePath = Path.Combine(target.FullName, file.Name);

                _logger.Info("Source File Path: " + file.FullName + " Destination File Path: " + destinationFilePath);

                if (File.Exists(destinationFilePath))
                    File.Delete(destinationFilePath);

                file.MoveTo(destinationFilePath);
            }
        }

        private void PostCustomerWithNoGmpi(CorporateAccount account, List<long> customersGmpiNotUpdated)
        {
            var customers = _customerWithNoGmpi.Deserialize(_customerWithNoGmpiPath + "\\CustomerWithNoGmpi_" + account.Tag + ".xml");

            int pageNumber = 1;
            int totalRecords = 0;

            var customersWithGmpiIds = new List<long>();

            if (customers != null && !customers.CustomerIds.IsNullOrEmpty())
            {
                while (true)
                {
                    totalRecords = customers.CustomerIds.Count();
                    if (totalRecords < 1) break;

                    var pagedCusotmerIds = customers.CustomerIds.Skip((pageNumber - 1) * PageSize).Take(PageSize);

                    _logger.Info(string.Format("Total No of Customer: {0}, Page Number {1} ", totalRecords, pageNumber));

                    var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsByCustomerIds((int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false, account.Id, pagedCusotmerIds, _cutOfDate);
                    PostResultPdfToSftp(eventCustomerResults, account, null);

                    if (!eventCustomerResults.IsNullOrEmpty())
                    {
                        _logger.Info(string.Format("Total Customer found With GMPI: {0} ", eventCustomerResults.Count()));
                        customersWithGmpiIds.AddRange(eventCustomerResults.Select(x => x.CustomerId));
                    }
                    else
                    {
                        _logger.Info(string.Format("No Records found"));
                    }

                    pageNumber++;
                    if ((pageNumber * PageSize) > totalRecords)
                        break;
                }

                customersGmpiNotUpdated.AddRange(customers.CustomerIds.Where(c => !customersWithGmpiIds.Contains(c)));
            }
        }

        private void ExportResultInSftp(string fileName, string sourcePath)
        {
            _logger.Info("Destination Path:  " + _sftpPath + "\\" + fileName);
            _logger.Info("Source Path: " + sourcePath);

            var sftpCridential = _sftpCridentialManager.Deserialize(_sftpCridentailPath + "MonarchWellmedPdfPath.xml");

            if (sftpCridential != null)
            {
                var processFtp = new ProcessFtp(_logger, sftpCridential.HostName, sftpCridential.UserName, sftpCridential.Password);

                processFtp.UploadSingleFile(sourcePath, _sftpPath, fileName);
            }
        }

        private string ResultFileName(Customer customer)
        {
            return RemoveIllegalFileChar(customer.AdditionalField4) + "_36_" + customer.CustomerId;
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

        private void CorrectMissingRecords(ResultPdfPostedXml resultPdfPostedXml)
        {
            if (resultPdfPostedXml == null || resultPdfPostedXml.Customer.IsNullOrEmpty()) return;

            var isRecordMissing = resultPdfPostedXml.Customer.Any(x => !x.EventDate.HasValue || string.IsNullOrEmpty(x.MemberId));

            if (!isRecordMissing) return;

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

            var resultpdfPosted = new ResultPdfPostedXml { Customer = customersInfo.ToList() };
            var resultPostedToPlanFileName = Path.Combine(_resultPostedToPlanPath, "resultPostedMonarchToWellmed.xml");

            _resultPdfPostedSerializer.SerializeandSave(resultPostedToPlanFileName, resultpdfPosted);
        }
    }
}