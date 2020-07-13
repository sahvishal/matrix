using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.InboundReport;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.OutboundReport.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.InboundReport.Impl
{
    [DefaultImplementation]
    public class CrosswalkInboundReportPollingAgent : ICrosswalkInboundReportPollingAgent
    {
        private readonly ICrosswalkInboundReportService _crosswalkInboundReportService;
        private readonly IPipeDelimitedReportHelper _pipeDelimitedReportHelper;
        private readonly IMediaRepository _mediaRepository;
        private readonly ISettings _settings;
        private readonly IZipHelper _zipHelper;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IXmlSerializer<ResultPdfPostedXml> _resultPdfPostedSerializer;
        private readonly ILogger _logger;

        private readonly string _customSettingFile;
        private readonly DateTime _cutOffDate;
        private readonly DayOfWeek _dayOfWeek;
        private readonly string _resultPostedToPlanPath;
        private readonly string _sftpHost;
        private readonly string _sftpUserName;
        private readonly string _sftpPassword;
        private readonly bool _sendReportToSftp;
        private readonly string _destinationSftpPath;

        private readonly DateTime _stopSendingPdftoHealthPlanDate;

        public CrosswalkInboundReportPollingAgent(ILogManager logManager, ICrosswalkInboundReportService crosswalkInboundReportService, IPipeDelimitedReportHelper pipeDelimitedReportHelper, IMediaRepository mediaRepository, ISettings settings,
            IZipHelper zipHelper, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, ICustomSettingManager customSettingManager, IXmlSerializer<ResultPdfPostedXml> resultPdfPostedSerializer)
        {
            _crosswalkInboundReportService = crosswalkInboundReportService;
            _pipeDelimitedReportHelper = pipeDelimitedReportHelper;
            _mediaRepository = mediaRepository;
            _settings = settings;
            _zipHelper = zipHelper;
            _corporateAccountRepository = corporateAccountRepository;
            _customSettingManager = customSettingManager;
            _resultPdfPostedSerializer = resultPdfPostedSerializer;
            _logger = logManager.GetLogger("Crosswalk_Inbound_Report");

            _customSettingFile = settings.FloridaBlueSettingResourcePath;
            _cutOffDate = settings.FloridaBlueReportCutOfDate;
            _dayOfWeek = settings.FloridaBlueReportsDayOfWeek;
            _resultPostedToPlanPath = settings.ResultPostedToPlanPath;
            _sftpHost = settings.FloridaBlueSftpHost;
            _sftpUserName = settings.FloridaBlueSftpUserName;
            _sftpPassword = settings.FloridaBlueSftpPassword;
            _sendReportToSftp = settings.SendReportToFloridaBlueSftp;
            _destinationSftpPath = settings.FloridaBlueSftpPath;

            _stopSendingPdftoHealthPlanDate = settings.StopSendingPdftoHealthPlanDate;

        }

        public void PollForCrosswalkInboundReport()
        {
            try
            {
                if (DateTime.Today.DayOfWeek != _dayOfWeek)
                {
                    _logger.Info(string.Format("Today is {0}. Job is set to run on {1}.", DateTime.Today.DayOfWeek, _dayOfWeek));
                    return;
                }

                var accountIds = _settings.FloridaBlueAccountId.Split(',');

                if (accountIds.IsNullOrEmpty())
                {
                    _logger.Info("No accounts found for Response Vendor Report.");
                    return;
                }

                _logger.Info("Starting Crosswalk Inbound Report generation.");

                var customSettingFilePath = string.Format(_customSettingFile, ReportType.CrosswalkInbound);
                var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                var exportToTime = DateTime.Now.AddHours(-1);
                var exportFromTime = customSettings.LastTransactionDate ?? _cutOffDate;

                foreach (var accountId in accountIds)
                {
                    _logger.Info("Generating Crosswalk Inbound Report for Account ID : " + accountId);

                    var filter = new CrosswalkInboundFilter
                    {
                        StartDate = exportFromTime,
                        EndDate = exportToTime,
                        AccountId = Convert.ToInt32(accountId),
                        CustomTags = _settings.FloridaBlueMedicareCustomTags
                    };

                    if (filter.AccountId == _settings.FloridaBlueCommercialId)
                        filter.CustomTags = _settings.FloridaBlueCommercialCustomTags;
                    else if (filter.AccountId == _settings.FloridaBlueMammoId)
                        filter.CustomTags = _settings.FloridaBlueMammoCustomTags;
                    else if (filter.AccountId == _settings.FloridaBlueGapsId)
                        filter.CustomTags = _settings.FloridaBlueGapsCustomTags;

                    GenerateCrosswalkInboundReport(filter);

                    customSettings.LastTransactionDate = exportToTime;
                    _customSettingManager.SerializeandSave(customSettingFilePath, customSettings);

                    _logger.Info("Completed Crosswalk Inbound Report generation.");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Some error occured while generating Crosswalk Inbound Report");
                _logger.Error("Exception: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }

        private void GenerateCrosswalkInboundReport(CrosswalkInboundFilter filter)
        {
            var account = _corporateAccountRepository.GetById(filter.AccountId);

            filter.Tag = account.Tag;

            if (account.IsHealthPlan)
            {
                filter.StopSendingPdftoHealthPlanDate = _settings.StopSendingPdftoHealthPlanDate;
            }

            var model = _crosswalkInboundReportService.GetCrosswalkInboundReportList(filter, _logger);

            if (model != null)
            {
                var folder = string.Format(_settings.FloridaBlueInboundReportPath, account.FolderName, DateTime.Now.ToString("yyyy-MM-dd"));
                if (!Directory.Exists(folder)) DirectoryOperationsHelper.CreateDirectory(folder);
                var fileName = _pipeDelimitedReportHelper.GetReportName(ReportType.CrosswalkInbound) + ".txt";
                var zipFileName = _pipeDelimitedReportHelper.GetReportName(ReportType.CrosswalkZip);

                if (model.Collection != null && model.Collection.Any())
                {
                    _logger.Info("generating File");
                    var tempMediaLocation = _mediaRepository.GetTempMediaFileLocation().PhysicalPath + zipFileName + "\\";
                    if (!Directory.Exists(tempMediaLocation))
                        DirectoryOperationsHelper.CreateDirectory(tempMediaLocation);

                    var resultPostedToPlanFileName = Path.Combine(_resultPostedToPlanPath, string.Format("ResultPostedto_{0}.xml", account.Tag));
                    var resultPosted = _resultPdfPostedSerializer.Deserialize(resultPostedToPlanFileName);
                    resultPosted = resultPosted == null || resultPosted.Customer.IsNullOrEmpty() ? new ResultPdfPostedXml { Customer = new List<CustomerInfo>() } : resultPosted;

                    foreach (var crosswalkViewModel in model.Collection)
                    {
                        var hafResultPdfLocation = _mediaRepository.GetPremiumVersionResultPdfLocation(crosswalkViewModel.EventId, crosswalkViewModel.CustomerId);
                        var hafResultPdfFileName = _mediaRepository.GetPdfFileNameForHealthPlanResultReport();
                        var pcpResultPdfFileName = _mediaRepository.GetPdfFileNameForPcpResultReport();

                        _logger.Info(" Event Id: " + crosswalkViewModel.EventId + " Customer Id: " + crosswalkViewModel.CustomerId);

                        if (DirectoryOperationsHelper.IsFileExist(tempMediaLocation + crosswalkViewModel.FileName))
                        {
                            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(tempMediaLocation + crosswalkViewModel.FileName);
                            var files = DirectoryOperationsHelper.GetFiles(tempMediaLocation, fileNameWithoutExtension + "*.pdf");
                            crosswalkViewModel.FileName = fileNameWithoutExtension + "_" + files.Count() + ".pdf";
                        }

                        if (File.Exists(hafResultPdfLocation.PhysicalPath + hafResultPdfFileName))
                        {
                            var destinationFileName = GetFileName(resultPosted.Customer, crosswalkViewModel.EventId, crosswalkViewModel.CustomerId, Path.GetFileNameWithoutExtension(crosswalkViewModel.FileName), (long)ResultFormatType.PDF);
                            crosswalkViewModel.FileName = destinationFileName + ".pdf";

                            _logger.Info("Copying File.. filePath from : " + hafResultPdfLocation.PhysicalPath + hafResultPdfFileName);
                            _logger.Info("Copying File.. filePath To : " + tempMediaLocation + crosswalkViewModel.FileName);

                            DirectoryOperationsHelper.Copy(hafResultPdfLocation.PhysicalPath + hafResultPdfFileName, tempMediaLocation + crosswalkViewModel.FileName);

                            resultPosted.Customer.Add(GetCustomerInfo(crosswalkViewModel));
                        }
                        else if (File.Exists(hafResultPdfLocation.PhysicalPath + pcpResultPdfFileName))
                        {
                            var destinationFileName = GetFileName(resultPosted.Customer, crosswalkViewModel.EventId, crosswalkViewModel.CustomerId, Path.GetFileNameWithoutExtension(crosswalkViewModel.FileName), (long)ResultFormatType.PDF);
                            crosswalkViewModel.FileName = destinationFileName + ".pdf";

                            _logger.Info("Copying File.. filePath from : " + hafResultPdfLocation.PhysicalPath + pcpResultPdfFileName);
                            _logger.Info("Copying File.. filePath To : " + tempMediaLocation + crosswalkViewModel.FileName);

                            DirectoryOperationsHelper.Copy(hafResultPdfLocation.PhysicalPath + pcpResultPdfFileName, tempMediaLocation + crosswalkViewModel.FileName);

                            resultPosted.Customer.Add(GetCustomerInfo(crosswalkViewModel));
                        }
                        else
                        {
                            _logger.Info("file not found");
                        }

                    }

                    _resultPdfPostedSerializer.SerializeandSave(resultPostedToPlanFileName, resultPosted);

                    _pipeDelimitedReportHelper.Write(model.Collection, folder, fileName);
                    DirectoryOperationsHelper.Copy(folder + "\\" + fileName, tempMediaLocation + fileName);

                    _logger.Info("generating Zip ");
                    _zipHelper.CreateZipFiles(tempMediaLocation, folder + "\\" + zipFileName + ".zip");

                    if (_sendReportToSftp)
                    {
                        try
                        {
                            _logger.Info("Sending zip to SFTP.");

                            var destinationPath = _destinationSftpPath + "\\" + account.FolderName + "\\Download\\Reports";
                            SendFilesToSftp(Path.Combine(folder, zipFileName + ".zip"), destinationPath, zipFileName + ".zip");

                            _logger.Info("Zip sent to SFTP.");
                        }
                        catch (Exception ex)
                        {
                            _logger.Info("Error sending zip to SFTP.");
                            _logger.Error("Message : " + ex.Message);
                            _logger.Error("Stack Trace : " + ex.StackTrace);
                        }
                    }

                    _logger.Info("Deleting temp folder: " + tempMediaLocation);
                    DirectoryOperationsHelper.DeleteDirectory(tempMediaLocation, true);

                    _logger.Info("Deleting text file: " + folder + "\\" + fileName);
                    DirectoryOperationsHelper.Delete(folder + "\\" + fileName);
                }
                else
                {
                    _logger.Info("No Data found for account Id: " + filter.AccountId);
                }
            }
            else
            {
                _logger.Info("No record found for " + account.Tag);
            }
        }

        private CustomerInfo GetCustomerInfo(CrosswalkInboundViewModel crosswalkViewModel)
        {
            return new CustomerInfo
            {
                CustomerId = crosswalkViewModel.CustomerId,
                EventId = crosswalkViewModel.EventId,
                DateSent = DateTime.Now,
                EventDate = crosswalkViewModel.ServiceStartDate,
                FileName = crosswalkViewModel.FileName,
                FileType = (long)ResultFormatType.PDF,
                MemberId = string.IsNullOrEmpty(crosswalkViewModel.ClientId) ? string.Empty : crosswalkViewModel.ClientId
            };
        }

        private string GetFileName(IEnumerable<CustomerInfo> resultPdfPostedCustomers, long eventId, long customerId, string fileName, long fileType)
        {
            try
            {
                _logger.Info("File Type : " + fileType + " File Name : " + fileName + " EventID : " + eventId + " CustomerID : " + customerId);
                if (resultPdfPostedCustomers == null)
                    _logger.Info("Result posted customer null");
                else
                {
                    if (string.IsNullOrEmpty(fileName)) fileName = "GWC_CW_NoMemberId_" + customerId + ".pdf";
                    var fileSentCount = resultPdfPostedCustomers.Count(x => x.CustomerId == customerId && x.EventId == eventId && x.FileType == fileType && x.FileName.Contains(fileName));

                    if (fileSentCount > 0)
                    {
                        fileName += string.Format("_{0}_{1}", fileSentCount, DateTime.Now.ToString("yyyyMMdd"));
                    }
                }
                return fileName;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return fileName;
            }

        }

        private void SendFilesToSftp(string sourceFilePath, string destinationPath, string fileName)
        {
            var processFtp = new ProcessFtp(_logger, _sftpHost, _sftpUserName, _sftpPassword);

            processFtp.UploadSingleFile(sourceFilePath, destinationPath, fileName);
        }
    }
}
