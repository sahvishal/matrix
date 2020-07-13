﻿using System;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
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
    public class InterviewInboundReportPollingAgent : IInterviewInboundReportPollingAgent
    {
        private readonly IInterviewInboundReportService _interviewInboundReportService;
        private readonly IPipeDelimitedReportHelper _pipeDelimitedReportHelper;
        private readonly ISettings _settings;
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

        public InterviewInboundReportPollingAgent(ILogManager logManager, IInterviewInboundReportService interviewInboundReportService, IPipeDelimitedReportHelper pipeDelimitedReportHelper, ISettings settings,
            IUniqueItemRepository<CorporateAccount> corporateAccountRepository, ICustomSettingManager customSettingManager)
        {
            _interviewInboundReportService = interviewInboundReportService;
            _pipeDelimitedReportHelper = pipeDelimitedReportHelper;
            _settings = settings;
            _corporateAccountRepository = corporateAccountRepository;
            _customSettingManager = customSettingManager;
            _logger = logManager.GetLogger("Interview_Inbound_Report");

            _customSettingFile = settings.FloridaBlueSettingResourcePath;
            _cutOffDate = settings.FloridaBlueReportCutOfDate;
            _dayOfWeek = settings.FloridaBlueReportsDayOfWeek;
            _sftpHost = settings.FloridaBlueSftpHost;
            _sftpUserName = settings.FloridaBlueSftpUserName;
            _sftpPassword = settings.FloridaBlueSftpPassword;
            _sendReportToSftp = settings.SendReportToFloridaBlueSftp;
            _destinationSftpPath = settings.FloridaBlueSftpPath;
        }

        public void PollForInterviewInboundReport()
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

                _logger.Info("Starting Interview Inbound Report generation.");

                var customSettingFilePath = string.Format(_customSettingFile, ReportType.InterviewInbound);
                var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                var exportToTime = DateTime.Now.AddHours(-1);
                //var exportFromTime = customSettings.LastTransactionDate.HasValue ? new DateTime(customSettings.LastTransactionDate.Value.Year, 1, 1) : _cutOffDate;
                //var exportFromTime = new DateTime(DateTime.Now.Year, 1, 1);
                var exportFromTime = _cutOffDate;

                foreach (var accountId in accountIds)
                {
                    _logger.Info("Generating Interview Inbound Report for Account ID : " + accountId);

                    var filter = new InterviewInboundFilter
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

                    GenerateInterviewInboundReport(filter);

                    customSettings.LastTransactionDate = exportToTime;
                    _customSettingManager.SerializeandSave(customSettingFilePath, customSettings);
                }

                _logger.Info("Completed Interview Inbound Report generation.");
            }
            catch (Exception ex)
            {
                _logger.Error("Some error occured while generating Interview Inbound Report");
                _logger.Error("Exception: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }

        private void GenerateInterviewInboundReport(InterviewInboundFilter filter)
        {
            var dataGen = new ExportableDataGenerator<InterviewInboundViewModel, InterviewInboundFilter>(_interviewInboundReportService.GetInterviewInboundReportList, _logger);
            var model = dataGen.GetData(filter);

            var account = _corporateAccountRepository.GetById(filter.AccountId);

            if (model != null && !model.Collection.IsNullOrEmpty())
            {
                var folder = string.Format(_settings.FloridaBlueInboundReportPath, account.FolderName, DateTime.Now.ToString("yyyy-MM-dd"));
                if (!Directory.Exists(folder)) DirectoryOperationsHelper.CreateDirectory(folder);
                var fileName = _pipeDelimitedReportHelper.GetReportName(ReportType.InterviewInbound);

                if (model.Collection != null && model.Collection.Any())
                {
                    _pipeDelimitedReportHelper.Write(model.Collection, folder, fileName + ".txt");

                    if (_sendReportToSftp)
                    {
                        try
                        {
                            _logger.Info("Sending file to SFTP.");

                            var destinationPath = _destinationSftpPath + "\\" + account.FolderName + "\\Download\\Reports";
                            SendFilesToSftp(Path.Combine(folder, fileName), destinationPath, fileName);

                            _logger.Info("File sent to SFTP.");
                        }
                        catch (Exception ex)
                        {
                            _logger.Info("Error sending file to SFTP.");
                            _logger.Error("Message : " + ex.Message);
                            _logger.Error("Stack Trace : " + ex.StackTrace);
                        }
                    }
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
