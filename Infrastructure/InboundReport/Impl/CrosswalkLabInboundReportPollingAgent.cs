using System;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.InboundReport;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.OutboundReport.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.InboundReport.Impl
{
    [DefaultImplementation]
    public class CrosswalkLabInboundReportPollingAgent : ICrosswalkLabInboundReportPollingAgent
    {
        private readonly ICrosswalkInboundReportService _crosswalkInboundReportService;
        private readonly IPipeDelimitedReportHelper _pipeDelimitedReportHelper;
        private readonly IMediaRepository _mediaRepository;
        private readonly ISettings _settings;
        private readonly IZipHelper _zipHelper;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly ILogger _logger;

        private readonly string _customSettingFile;
        private readonly DateTime _cutOffDate;
        private readonly DayOfWeek _dayOfWeek;
        private readonly string _sftpHost;
        private readonly string _sftpUserName;
        private readonly string _sftpPassword;
        private readonly bool _sendReportToSftp;
        private readonly string _destinationSftpPath;

        public CrosswalkLabInboundReportPollingAgent(ILogManager logManager, ICrosswalkInboundReportService crosswalkInboundReportService, IPipeDelimitedReportHelper pipeDelimitedReportHelper, IMediaRepository mediaRepository, ISettings settings,
            IZipHelper zipHelper, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, ICustomSettingManager customSettingManager)
        {
            _crosswalkInboundReportService = crosswalkInboundReportService;
            _pipeDelimitedReportHelper = pipeDelimitedReportHelper;
            _mediaRepository = mediaRepository;
            _settings = settings;
            _zipHelper = zipHelper;
            _corporateAccountRepository = corporateAccountRepository;
            _customSettingManager = customSettingManager;
            _logger = logManager.GetLogger("Crosswalk_Lab_Inbound_Report");

            _customSettingFile = settings.FloridaBlueSettingResourcePath;
            _cutOffDate = settings.FloridaBlueReportCutOfDate;
            _dayOfWeek = settings.FloridaBlueReportsDayOfWeek;
            _sftpHost = settings.FloridaBlueSftpHost;
            _sftpUserName = settings.FloridaBlueSftpUserName;
            _sftpPassword = settings.FloridaBlueSftpPassword;
            _sendReportToSftp = settings.SendReportToFloridaBlueSftp;
            _destinationSftpPath = settings.FloridaBlueSftpPath;
        }

        public void PollForCrosswalkLabInboundReport()
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

                _logger.Info("Starting Crosswalk Lab Inbound Report generation.");

                var customSettingFilePath = string.Format(_customSettingFile, ReportType.CrosswalkLabInbound);
                var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                var exportToTime = DateTime.Now.AddHours(-1);
                var exportFromTime = customSettings.LastTransactionDate ?? _cutOffDate;

                foreach (var accountId in accountIds)
                {
                    _logger.Info("Generating Crosswalk Lab Inbound Report for Account ID : " + accountId);

                    var filter = new CrosswalkLabInboundFilter
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

                    GenerateCrosswalkLabInboundReport(filter);

                    customSettings.LastTransactionDate = exportToTime;
                    _customSettingManager.SerializeandSave(customSettingFilePath, customSettings);

                    _logger.Info("Completed Crosswalk Lab Inbound Report generation.");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Some error occured while generating Crosswalk Lab Inbound Report");
                _logger.Error("Exception: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }

        private void GenerateCrosswalkLabInboundReport(CrosswalkLabInboundFilter filter)
        {
            var account = _corporateAccountRepository.GetById(filter.AccountId);

            filter.Tag = account.Tag;

            var model = _crosswalkInboundReportService.GetCrosswalkLabInboundReportList(filter);

            if (model != null)
            {
                var folder = string.Format(_settings.FloridaBlueInboundReportPath, account.FolderName, DateTime.Now.ToString("yyyy-MM-dd"));
                if (!Directory.Exists(folder)) DirectoryOperationsHelper.CreateDirectory(folder);
                var fileName = _pipeDelimitedReportHelper.GetReportName(ReportType.CrosswalkLabInbound) + ".txt";
                var zipFileName = _pipeDelimitedReportHelper.GetReportName(ReportType.CrosswalkLabZip);

                if (model.Collection != null && model.Collection.Any())
                {
                    _logger.Info("generating File");
                    _pipeDelimitedReportHelper.Write(model.Collection, folder, fileName);

                    var tempMediaLocation = _mediaRepository.GetTempMediaFileLocation().PhysicalPath + zipFileName + "\\";

                    if (!Directory.Exists(tempMediaLocation)) DirectoryOperationsHelper.CreateDirectory(tempMediaLocation);

                    foreach (var crosswalkViewModel in model.Collection)
                    {
                        var resultMediaLocation = _mediaRepository.GetResultMediaFileLocation(crosswalkViewModel.CustomerId, crosswalkViewModel.EventId);

                        _logger.Info(" Event Id: " + crosswalkViewModel.EventId + " Customer Id: " + crosswalkViewModel.CustomerId);
                        _logger.Info("file Path: " + resultMediaLocation.PhysicalPath + crosswalkViewModel.TestPdf);

                        if (!string.IsNullOrEmpty(crosswalkViewModel.TestPdf) && File.Exists(resultMediaLocation.PhysicalPath + crosswalkViewModel.TestPdf))
                        {
                            _logger.Info("Copying File.. filePath from : " + resultMediaLocation.PhysicalPath + crosswalkViewModel.TestPdf);
                            _logger.Info("Copying File.. filePath To : " + tempMediaLocation + crosswalkViewModel.FileName);
                            File.Copy(resultMediaLocation.PhysicalPath + crosswalkViewModel.TestPdf, tempMediaLocation + crosswalkViewModel.FileName);
                        }
                        else
                        {
                            _logger.Info("file not found");
                            _logger.Info("filePath : " + resultMediaLocation.PhysicalPath + "\\" + crosswalkViewModel.TestPdf);
                        }
                    }

                    File.Copy(folder + "\\" + fileName, tempMediaLocation + fileName);

                    _logger.Info("generating Zip ");
                    _zipHelper.CreateZipFiles(tempMediaLocation, folder + "\\" + zipFileName + ".zip");

                    _logger.Info("Deleting text file: " + folder + "\\" + fileName);
                    File.Delete(folder + "\\" + fileName);

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
                }
                else
                {
                    _logger.Info("No record found for " + account.Tag);
                }
            }
            else
            {
                _logger.Info("No record found for " + account.Tag);
            }
        }

        private void SendFilesToSftp(string sourceFilePath, string destinationPath, string fileName)
        {
            var processFtp = new ProcessFtp(_logger, _sftpHost, _sftpUserName, _sftpPassword);

            processFtp.UploadSingleFile(sourceFilePath, destinationPath, fileName);
        }
    }
}
