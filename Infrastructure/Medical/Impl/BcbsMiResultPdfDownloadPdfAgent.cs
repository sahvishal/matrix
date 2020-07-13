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
    public class BcbsMiResultPdfDownloadPdfAgent : IBcbsMiResultPdfDownloadPdfAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ISettings _settings;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ICustomerRepository _customerRepository;

        private readonly IResultPdfDownloadPollingAgentHelper _resultPdfDownloadHelper;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly IZipHelper _zipHelper;
        private readonly IUniqueItemRepository<Event> _eventRepository;
        private readonly IXmlSerializer<ResultPdfPostedXml> _resultPdfPostedSerializer;

        private readonly ILogger _logger;

        private readonly string _customSettingFile;
        private readonly string _destinationFolderResultReportPath;

        private readonly string _destinationFolderResultPdfPath;

        private readonly long _accountId;
        private readonly DateTime _cutOfDate;
        private readonly string[] _bcbsMiRiskPatientTags;
        private readonly string[] _bcbsMiGapPatinetTags;

        private readonly DateTime _fromDateForGapPatient;

        private readonly string _resultPostedToPlanPath;
        private readonly IResultPdfFileHelper _resultPdfFileHelper;
        private readonly IXmlSerializer<ResultPdfNotPosted> _resultPdfNotPostedSerializer;
        private readonly IResultPdfEmailNotificationHelper _resultPdfEmailNotificationHelper;

        private readonly DateTime _stopSendingPdftoHealthPlanDate;

        public BcbsMiResultPdfDownloadPdfAgent(IEventCustomerResultRepository eventCustomerResultRepository, ISettings settings, ILogManager logManager, IMediaRepository mediaRepository, ICustomSettingManager customSettingManager,
            IUniqueItemRepository<CorporateAccount> corporateAccountRepository, ICustomerRepository customerRepository, IResultPdfDownloadPollingAgentHelper resultPdfDownloadHelper, IPgpFileEncryptionHelper pgpFileEncryptionHelper,
            IZipHelper zipHelper, IUniqueItemRepository<Event> eventRepository, IXmlSerializer<ResultPdfPostedXml> resultPdfPostedSerializer, IResultPdfFileHelper resultPdfFileHelper,
            IXmlSerializer<ResultPdfNotPosted> resultPdfNotPostedSerializer, IResultPdfEmailNotificationHelper resultPdfEmailNotificationHelper)
        {
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _settings = settings;
            _mediaRepository = mediaRepository;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _customerRepository = customerRepository;

            _resultPdfDownloadHelper = resultPdfDownloadHelper;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _zipHelper = zipHelper;
            _eventRepository = eventRepository;
            _resultPdfPostedSerializer = resultPdfPostedSerializer;
            _resultPdfFileHelper = resultPdfFileHelper;

            _logger = logManager.GetLogger("BcbsMiResultPdf");

            _customSettingFile = settings.PcpResultPdfDownloadSettings;
            _destinationFolderResultReportPath = settings.BcbsMiResultReportDownloadPath;

            _destinationFolderResultPdfPath = settings.BcbsMiResultPdfDownloadPath;

            _cutOfDate = settings.PcpDownloadCutOfDate;

            _accountId = settings.BcbsMiAccountId;
            _bcbsMiGapPatinetTags = settings.BcbsMiGapPatinetTags;
            _bcbsMiRiskPatientTags = settings.BcbsMiRiskPatientTags;

            _fromDateForGapPatient = settings.FromDateForGapPatient;
            _resultPostedToPlanPath = settings.ResultPostedToPlanPath;
            _resultPdfNotPostedSerializer = resultPdfNotPostedSerializer;
            _resultPdfEmailNotificationHelper = resultPdfEmailNotificationHelper;

            _stopSendingPdftoHealthPlanDate = settings.StopSendingPdftoHealthPlanDate;
        }

        public void PollForPdfDownload()
        {
            try
            {
                if (DateTime.Today.DayOfWeek != _settings.BcbsMiResultPdfDownloadIntervalDay)
                {
                    _logger.Info("Today is " + DateTime.Today.DayOfWeek + " while service is configured to run on " + _settings.BcbsMiResultPdfDownloadIntervalDay);
                    _logger.Info("Please set " + (int)DateTime.Today.DayOfWeek + " to run Service today");
                    return;
                }

                if (_accountId <= 0) return;
                var corporateAccount = _corporateAccountRepository.GetById(_accountId);

                try
                {
                    _logger.Info(string.Format("Generating for accountId {0} and account tag {1}. ", corporateAccount.Id, corporateAccount.FolderName));

                    var customSettingFilePath = string.Format(_customSettingFile, corporateAccount.FolderName);
                    var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                    var exportToTime = DateTime.Now.AddHours(-1);
                    var exportFromTime = customSettings.LastTransactionDate ?? _cutOfDate;

                    var destinationFolderPdfPath = string.Format(_destinationFolderResultReportPath, corporateAccount.FolderName);

                    CreateDistinationDirectory(destinationFolderPdfPath);
                    DeleteIffileExist(destinationFolderPdfPath);

                    _logger.Info("Generating for Gap Patient");
                    PatientWithGapTag(exportToTime, exportFromTime, corporateAccount, DateTime.Today.GetFirstDateOfYear(), DateTime.Today.GetLastDateOfYear());

                    customSettings.LastTransactionDate = exportToTime;
                    _customSettingManager.SerializeandSave(customSettingFilePath, customSettings);

                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("some error occurred for AccountId: {0} and account tag: {1} Exception Message: \n{2}, \n stack Trace: \n\t {3} ", corporateAccount.Id, corporateAccount.Tag, ex.Message, ex.StackTrace));
                }


            }
            catch (Exception exception)
            {

                _logger.Error(string.Format("some error occurred Exception Message: \n{0}, \n stack Trace: \n\t {1} ", exception.Message, exception.StackTrace));
            }
        }

        private void PatientWithGapTag(DateTime exportToTime, DateTime exportFromTime, CorporateAccount corporateAccount, DateTime? eventDateFromConsider, DateTime? eventDateToConsider)
        {
            try
            {
                var destinationFolderPdfPath = string.Format(_destinationFolderResultPdfPath, corporateAccount.FolderName);
                destinationFolderPdfPath = destinationFolderPdfPath + "\\Q-ResultPdf";

                PostResultPdfOnSftp(exportToTime, exportFromTime, corporateAccount, destinationFolderPdfPath, true, _bcbsMiGapPatinetTags); 

                if (DirectoryOperationsHelper.IsDirectoryExist(destinationFolderPdfPath) && DirectoryOperationsHelper.GetFiles(destinationFolderPdfPath).Any())
                {
                    var destinationSftp = string.Format(_destinationFolderResultReportPath, corporateAccount.FolderName);

                    if (!DirectoryOperationsHelper.IsDirectoryExist(destinationSftp))
                        DirectoryOperationsHelper.CreateDirectory(destinationSftp);

                    var destinationfile = destinationSftp + @"\Q_MOBILE_ResultPdf_" + DateTime.Today.ToString("yyyyMMdd") + ".zip";

                    _zipHelper.CreateZipFiles(destinationFolderPdfPath, destinationfile, true);
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("some error occurred for the \n Message {0} \n Stack Trace {1}", exception.Message, exception.StackTrace));
            }
        }
        private void PostResultPdfOnSftp(DateTime exportToTime, DateTime exportFromTime, CorporateAccount corporateAccount, string destinationFolderPdfPath, bool includeCustomerWithTag, string[] customTags)
        {
            var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultDelivered(exportToTime, exportFromTime, corporateAccount.Id, corporateAccount.Tag, _settings.PPEventCutOfDate, includeCustomerWithTag, customTags, stopSendingPdftoHealthPlanDate: _stopSendingPdftoHealthPlanDate);
           
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
                _logger.Info(string.Format("No event customer result list found for {0}.",
                    corporateAccount.Tag));
            }

            _logger.Info(string.Format("Found {0} customers for {1} Result. ", eventCustomerResults.Count(),
                corporateAccount.Tag));


            var pcpResultReport = _mediaRepository.GetPdfFileNameForPcpResultReport();

            var healthPlanResultReport = _mediaRepository.GetPdfFileNameForHealthPlanResultReport();

            var resultPostedToPlanFileName = Path.Combine(_resultPostedToPlanPath, string.Format("ResultPostedto_{0}.xml", corporateAccount.Tag));
            var resultPosted = _resultPdfPostedSerializer.Deserialize(resultPostedToPlanFileName);
            resultPosted = resultPosted == null || resultPosted.Customer.IsNullOrEmpty() ? new ResultPdfPostedXml { Customer = new List<CustomerInfo>() } : resultPosted;

            foreach (var ecr in customerResults)
            {
                var sourcePath = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + healthPlanResultReport;

                if (!DirectoryOperationsHelper.IsFileExist(sourcePath))
                {
                    sourcePath = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + pcpResultReport;
                }

                if (DirectoryOperationsHelper.IsFileExist(sourcePath))
                {
                    try
                    {
                        var customer = _customerRepository.GetCustomer(ecr.CustomerId);

                        var eventData = _eventRepository.GetById(ecr.EventId);

                        var destinationFilename = string.IsNullOrEmpty(customer.InsuranceId) ? "No MemberId_" + customer.CustomerId + "_" + eventData.EventDate.ToString("MM-dd-yyyy") : customer.InsuranceId + "_" + eventData.EventDate.ToString("MM-dd-yyyy");
                        destinationFilename = RemoveIllegalFileChar(destinationFilename);
                        if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                            destinationFilename += "_" + corporateAccount.PennedBackText;

                        //var destinationFolderPdfPathWithYear = Path.Combine(destinationFolderPdfPath, eventData.EventDate.Year.ToString());

                        if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.PDF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                        {
                            var pdfFileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, destinationFilename, (long)ResultFormatType.PDF);

                            var resultPdfFile = Path.Combine(destinationFolderPdfPath, pdfFileName + ".pdf");

                            _logger.Info("destination file : " + destinationFolderPdfPath + "\\" + pdfFileName + ".pdf");
                            _logger.Info("source file : " + sourcePath);

                            _resultPdfDownloadHelper.ExportResultInPdfFormat(pdfFileName + ".pdf", sourcePath, destinationFolderPdfPath);

                            if (DirectoryOperationsHelper.IsFileExist(resultPdfFile))
                            {
                                var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, resultPdfFile);
                                resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, Path.GetFileName(pgpFilePath), (long)ResultFormatType.PDF, customer, ecr.Id));
                            }
                            else
                            {
                                _logger.Info("File Not Found : " + resultPdfFile);
                                resultNotPosted.EventCustomer.Add(new EventCustomerInfo
                                {
                                    EventCustomerId = ecr.Id,
                                    EventId = ecr.EventId,
                                    CustomerId = ecr.CustomerId,
                                    Error = "file not Moved on HIP SFTP."
                                });
                            }
                        }

                        if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.TIF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                        {
                            var tifFileName = _resultPdfFileHelper.GetFileName(resultPosted.Customer, ecr, destinationFilename, (long)ResultFormatType.TIF);
                            var resultTifFile = destinationFolderPdfPath + "/" + tifFileName + ".tif";
                            _resultPdfDownloadHelper.ExportResultInTiffFormat(tifFileName + ".tif", sourcePath, destinationFolderPdfPath);

                            if (DirectoryOperationsHelper.IsFileExist(resultTifFile))
                            {
                                var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, resultTifFile);
                                resultPosted.Customer.Add(_resultPdfFileHelper.GetCustomerInfo(eventData, Path.GetFileName(pgpFilePath), (long)ResultFormatType.TIF, customer, ecr.Id));
                            }
                            else
                            {
                                _logger.Info(string.Format("File {0} not Exit for pgp Encryption ", resultTifFile));
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

                        _logger.Error(string.Format("some error occurred for the customerId {0}, Event Id {1},\n Message {2} \n Stack Trace {3}", ecr.CustomerId, ecr.EventId, exception.Message, exception.StackTrace));
                    }
                }
                else
                {
                    _logger.Info(string.Format("File not generated or removed for the customerId {0}, {1}", ecr.CustomerId,
                        ecr.EventId));

                    resultNotPosted.EventCustomer.Add(new EventCustomerInfo
                    {
                        EventCustomerId = ecr.Id,
                        EventId = ecr.EventId,
                        CustomerId = ecr.CustomerId,
                        Error = "File not generated or removed."
                    });
                }
            }

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

        private void DeleteIffileExist(string destinationPath)
        {
            var files = Directory.GetFiles(destinationPath, "*.zip");

            foreach (var file in files)
            {
                if (!string.IsNullOrEmpty(file) && file.Contains("ResultPdf_"))
                {
                    if (DirectoryOperationsHelper.IsFileExist(file))
                        DirectoryOperationsHelper.DeleteFileIfExist(file);
                }

            }
        }

        private void CreateDistinationDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
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

        private void MoveFileToArchive(string sourceFolder, string destinationFolder)
        {
            _logger.Info("Moving directory to archive folder.");
            var directories = DirectoryOperationsHelper.GetDirectories(sourceFolder);

            if (directories == null || !directories.Any())
            {
                _logger.Info("No directory found to move into archive.");
                return;
            }

            directories = directories.Where(x => !x.Contains(DateTime.Today.Year.ToString())).ToArray();

            if (directories.Any())
            {
                foreach (var dir in directories)
                {
                    var files = DirectoryOperationsHelper.GetFiles(dir, "*.pdf");
                    if (!files.Any())
                    {
                        _logger.Info("No files found in Directory: " + dir + "to move into archive.");
                        continue;
                    }

                    _logger.Info(string.Format("{0} files found in directory: {1}.", files.Count(), dir));

                    var folderName = Path.GetFileName(dir.TrimEnd(Path.DirectorySeparatorChar));

                    var destinationPath = Path.Combine(destinationFolder, folderName);
                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationPath);

                    foreach (var file in files)
                    {
                        if (DirectoryOperationsHelper.IsFileExist(file))
                        {
                            var fileName = Path.GetFileName(file);
                            var destinationFileName = Path.Combine(destinationPath, fileName);
                            try
                            {
                                DirectoryOperationsHelper.DeleteFileIfExist(destinationFileName);
                                DirectoryOperationsHelper.Move(file, destinationFileName);
                                _logger.Info(string.Format("{0} file moved into {1} from directory: {2}.", fileName, destinationPath, dir));
                            }
                            catch (Exception ex)
                            {
                                _logger.Error(string.Format("Exception occurred while moving file {0} to {1}. \nException Message: {2}\n\tStackTrace:{3}", file, destinationFileName, ex.Message, ex.StackTrace));
                            }
                        }
                    }

                    DirectoryOperationsHelper.DeleteDirectory(dir);
                }
            }
        }
    }
}