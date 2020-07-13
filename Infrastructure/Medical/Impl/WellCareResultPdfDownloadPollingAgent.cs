using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
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
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class WellCareResultPdfDownloadPollingAgent : IWellCareResultPdfDownloadPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly IEventRepository _eventRepository;
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
        private readonly string _sftpDestinationPath;

        private readonly DateTime _stopSendingPdftoHealthPlanDate;

        public WellCareResultPdfDownloadPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, ISettings settings, ILogManager logManager,
            IMediaRepository mediaRepository, ICustomSettingManager customSettingManager, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, IEventRepository eventRepository,
            IResultPdfDownloadPollingAgentHelper resultPdfDownloaderHelper, IPgpFileEncryptionHelper pgpFileEncryptionHelper)
        {
            _cutOfDate = settings.PcpDownloadCutOfDate;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _mediaRepository = mediaRepository;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _eventRepository = eventRepository;

            _resultPdfDownloaderHelper = resultPdfDownloaderHelper;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;

            _logger = logManager.GetLogger("WellCare ResultPdf");

            _accountIds = settings.WellCareAccountIds;
            _customSettingFile = settings.PcpResultPdfDownloadSettings;
            _destinationFolderPdfPath = settings.PcpResultPdfDownloadPath;

            _sftpHost = settings.WellCareSftpHost;
            _sftpUserName = settings.WellCareSftpUserName;
            _sftpPassword = settings.WellCareSftpPassword;
            _sendReportToSftp = settings.SendPdfToWellCareSftp;
            _sftpDestinationPath = settings.WellCareSftpPath;

            _stopSendingPdftoHealthPlanDate = settings.StopSendingPdftoHealthPlanDate;

        }

        public void PollForPdfDownload()
        {
            try
            {
                if (_accountIds == null || !_accountIds.Any()) return;


                foreach (var accountId in _accountIds)
                {
                    var corporateAccount = _corporateAccountRepository.GetById(accountId);

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
                            stopSendingPdftoHealthPlanDate = _stopSendingPdftoHealthPlanDate;
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

                        _logger.Info(string.Format("Found {0} customers for {1} Result Pdf Download. ", eventCustomerResults.Count(), corporateAccount.Tag));

                        var pcpResultReport = _mediaRepository.GetPdfFileNameForPcpResultReport();

                        var healthPlanResultReport = _mediaRepository.GetPdfFileNameForHealthPlanResultReport();
                        customerResults = customerResults.OrderBy(x => x.EventId).ToArray();

                        long eventId = 0;
                        var eventDirectoryPdf = string.Empty;
                        var list = new List<WellCareResultPdfLog>();
                        foreach (var ecr in customerResults)
                        {

                            var sourcePath = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + healthPlanResultReport;

                            if (!File.Exists(sourcePath))
                            {
                                sourcePath = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + pcpResultReport;
                            }

                            if (File.Exists(sourcePath))
                            {
                                var stftDestinationPath = string.Format(_sftpDestinationPath);

                                try
                                {
                                    var theEventData = _eventRepository.GetById(ecr.EventId);

                                    eventDirectoryPdf = destinationFolderPdf + "/" + theEventData.EventDate.Year + "/" + ecr.EventId;

                                    if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.PDF)
                                    {
                                        var pdfFileName = ecr.CustomerId + "_" + theEventData.EventDate.ToString("MMddyyyy");

                                        if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                            pdfFileName += "_" + corporateAccount.PennedBackText;

                                        var pdfResultFile = eventDirectoryPdf + "/" + pdfFileName + ".pdf";
                                        list.Add(new WellCareResultPdfLog { CustomerId = ecr.CustomerId, FileName = pdfFileName });

                                        _resultPdfDownloaderHelper.ExportResultInPdfFormat(pdfFileName, sourcePath, eventDirectoryPdf);

                                        if (File.Exists(pdfResultFile))
                                        {
                                            _pgpFileEncryptionHelper.EncryptFile(corporateAccount, pdfResultFile);
                                        }

                                        if (_sendReportToSftp)
                                        {
                                            _logger.Info("destinationPath: " + stftDestinationPath);
                                            ExportResultInSftp(pdfFileName + ".pdf", sourcePath, stftDestinationPath);

                                            _logger.Info(string.Format("File Moved to HealthNow Sftp location for customer Id {0} and eventId {1}", ecr.CustomerId, ecr.EventId));
                                        }
                                    }

                                    if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.TIF)
                                    {
                                        var fileName = ecr.CustomerId.ToString();

                                        if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                            fileName += "_" + corporateAccount.PennedBackText;

                                        var tipResultFile = eventDirectoryPdf + "/" + fileName + ".tif";
                                        _resultPdfDownloaderHelper.ExportResultInTiffFormat(ecr.CustomerId + ".tif", sourcePath, eventDirectoryPdf);

                                        if (File.Exists(tipResultFile))
                                        {
                                            _pgpFileEncryptionHelper.EncryptFile(corporateAccount, tipResultFile);
                                        }
                                    }

                                    if (eventId != ecr.EventId)
                                    {
                                        var filePathForNewfile = eventDirectoryPdf + "/" + ecr.EventId + ".csv";
                                        GenerateHeaderCustomerResultPdfCsv(eventDirectoryPdf, filePathForNewfile);

                                        if (eventId > 0)
                                        {
                                            var appendRecordsForfile = eventDirectoryPdf + "/" + eventId + ".csv";

                                            AppendCustomerFileData(appendRecordsForfile, list);
                                            if (_sendReportToSftp)
                                            {
                                                ExportResultInSftp(eventId + ".csv", appendRecordsForfile, _sftpDestinationPath);

                                                _logger.Info("File Pushed For event customer File Records");
                                            }
                                        }

                                        eventId = ecr.EventId;
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

                        if (eventId > 0)
                        {
                            var appendRecordsForfile = eventDirectoryPdf + "/" + eventId + ".csv";

                            AppendCustomerFileData(appendRecordsForfile, list);

                            if (_sendReportToSftp)
                            {
                                ExportResultInSftp(eventId + ".csv", appendRecordsForfile, _sftpDestinationPath);

                                _logger.Info("File Pushed For event customer File Records");
                            }
                        }

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

        private bool GenerateHeaderCustomerResultPdfCsv(string directoryPath, string fileName)
        {
            if (!Directory.Exists(directoryPath)) return false;

            CreateFileLogHeader(fileName);
            return true;
        }

        private void AppendCustomerFileData(string filePath, IEnumerable<WellCareResultPdfLog> customerLog)
        {
            var sb = new StringBuilder();
            var members = (typeof(WellCareResultPdfLog)).GetMembers();
            var sanitizer = new CSVSanitizer();

            foreach (var customer in customerLog)
            {
                var values = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);
                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                            continue;
                    }
                    else
                        continue;


                    bool isHidden = false;
                    FormatAttribute formatter = null;

                    var attributes = propInfo.GetCustomAttributes(false);
                    if (!attributes.IsNullOrEmpty())
                    {
                        foreach (var attribute in attributes)
                        {
                            if (attribute is HiddenAttribute)
                            {
                                isHidden = true;
                                break;
                            }
                            if (attribute is FormatAttribute)
                            {
                                formatter = (FormatAttribute)attribute;
                            }
                        }
                    }

                    if (isHidden) continue;
                    var obj = propInfo.GetValue(customer, null);
                    if (obj == null)
                        values.Add(string.Empty);
                    else if (formatter != null)
                        values.Add(formatter.ToString(obj));
                    else if (obj.GetType() == typeof(List<string>))
                        values.Add(sanitizer.EscapeString(string.Join(",", ((List<string>)obj).ToArray())));
                    else
                        values.Add(sanitizer.EscapeString(obj.ToString()));

                }
                sb.Append(string.Join(",", values.ToArray()) + Environment.NewLine);
            }

            File.AppendAllText(filePath, sb.ToString());
        }

        private void CreateFileLogHeader(string filePath)
        {
            if (File.Exists(filePath)) return;

            try
            {
                var members = (typeof(WellCareResultPdfLog)).GetMembers();

                var header = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);
                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                            continue;
                    }
                    else
                        continue;

                    string propertyName = memberInfo.Name;
                    bool isHidden = false;

                    var attributes = propInfo.GetCustomAttributes(false);
                    if (!attributes.IsNullOrEmpty())
                    {
                        foreach (var attribute in attributes)
                        {
                            if (attribute is HiddenAttribute)
                            {
                                isHidden = true;
                                break;
                            }
                            if (attribute is DisplayNameAttribute)
                            {
                                propertyName = (attribute as DisplayNameAttribute).DisplayName;
                            }
                        }
                    }

                    if (isHidden) continue;

                    header.Add(propertyName);
                }

                using (var sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(string.Join(",", header));
                    sw.Close();
                }
            }
            catch (Exception) { }
        }

        private void ExportResultInSftp(string fileName, string sourcePath, string eventSftpPdfDirectory)
        {
            _logger.Info("Destination Path: " + eventSftpPdfDirectory + "\\" + fileName);
            _logger.Info("Source Path: " + sourcePath);

            var processFtp = new ProcessFtp(_logger, _sftpHost, _sftpUserName, _sftpPassword);
            processFtp.UploadSingleFile(sourcePath, eventSftpPdfDirectory, fileName);
        }
    }

}