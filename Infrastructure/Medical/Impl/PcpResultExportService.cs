using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Core.Application.Helper;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PcpResultExportService : PersistenceRepository, IPcpResultExportService
    {
        private readonly ILogger _logger;


        private readonly ISettings _settings;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly ISftpCridentialManager _sftpCridentialManager;

        private readonly string _resultExportSettings;
        private readonly IEnumerable<long> _accountIds;
        private readonly string _physicianPartnerResultExportDownloadPath;
        private readonly DateTime _cutOfDate;
        private readonly PcpResultExportServiceHelper _pcpResultExportServiceHelper;

        //private readonly string _sftpHost;
        //private readonly string _sftpUserName;
        //private readonly string _sftpPassword;
        //private readonly bool _sendReportToSftp;
        private readonly string _destinationSftpFolderPdfPath;
        private readonly IEnumerable<long> _ntspAccountIds;

        private readonly long _bcbsMnAccountId;
        //private readonly string _bcbsMnSftpHost;
        //private readonly string _bcbsMnSftpUserName;
        //private readonly string _bcbsMnSftpPassword;
        //private readonly bool _sendReportToBcbsMn;
        private readonly string _bcbsSftpFolderPath;

        public PcpResultExportService(ILogManager logManager, ISettings settings, ICorporateAccountRepository corporateAccountRepository, ICustomSettingManager customSettingManager,
            IPgpFileEncryptionHelper pgpFileEncryptionHelper, ISftpCridentialManager sftpCridentialManager, ICsvReader csvReader)
        {
            _logger = logManager.GetLogger("PcpResultExport");
            _settings = settings;
            _corporateAccountRepository = corporateAccountRepository;
            _customSettingManager = customSettingManager;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _sftpCridentialManager = sftpCridentialManager;

            _resultExportSettings = settings.PcpResultReportDownloadSettings;
            _physicianPartnerResultExportDownloadPath = settings.PcpResultReportDownloadPath;
            _accountIds = settings.PcpResultReportDownloadAccountIds;
            _cutOfDate = settings.PcpDownloadCutOfDate;

            _pcpResultExportServiceHelper = new PcpResultExportServiceHelper(_logger, settings, csvReader);

            _ntspAccountIds = settings.NtspAccountIds;
            //_sftpHost = settings.NtspSftpHost;
            //_sftpUserName = settings.NtspSftpUserName;
            //_sftpPassword = settings.NtspSftpPassword;
            //_sendReportToSftp = settings.SendReportToNtspSftp;
            _destinationSftpFolderPdfPath = settings.NtspSftpResultReportDownloadPath;

            _bcbsMnAccountId = settings.BcbsMnAccountId;
            //_bcbsMnSftpHost = settings.BcbsMnSftpHost;
            //_bcbsMnSftpUserName = settings.BcbsMnSftpUserName;
            //_bcbsMnSftpPassword = settings.BcbsMnSftpPassword;
            //_sendReportToBcbsMn = settings.SendReportToBcbsMn;
            _bcbsSftpFolderPath = settings.BcbsMnSftpResultReportDownloadPath;
        }

        public void ResultExport()
        {
            try
            {
                if (_accountIds.IsNullOrEmpty()) return;
                var corporateAccounts = _corporateAccountRepository.GetByIds(_accountIds);

                foreach (var account in corporateAccounts)
                {
                    try
                    {
                        if (account.Id == _settings.ExcellusAccountId && _settings.ExcellusExportResultReportDayOfWeek != DateTime.Now.DayOfWeek)
                        {
                            _logger.Info(string.Format("The job runs for Account ID : {0} and Tag : {1} on every {2}.", account.Id, account.Tag, _settings.ExcellusExportResultReportDayOfWeek));
                            continue;
                        }
                        if (account.Id == _settings.MedMutualAccountId && _settings.MedMutualExportDay != DateTime.Now.Day)
                        {
                            _logger.Info(string.Format("The job runs for Account ID : {0} and Tag : {1} on {2} of every month.", account.Id, account.Tag, _settings.MedMutualExportDay));
                            continue;
                        }
                        if (account.Id == _settings.FloridaBlueFepAccountId && _settings.FloridaBlueFepExportDayOfWeek != DateTime.Now.DayOfWeek)
                        {
                            _logger.Info(string.Format("The job runs for Account ID : {0} and Tag : {1} on every {2}.", account.Id, account.Tag, _settings.FloridaBlueFepExportDayOfWeek));
                            continue;
                        }

                        string[] customTags = null;

                        if (account.Id == _settings.ExcellusAccountId)
                        {
                            customTags = _settings.ExcellusCustomTags;
                        }
                        else if (account.Id == _settings.HealthNowAccountId)
                        {
                            customTags = _settings.HealthNowCustomTags;
                        }

                        var resultExportSettings = string.Format(_resultExportSettings, account.Tag);
                        var physicianPartnerResultExportDownloadPath = string.Format(_physicianPartnerResultExportDownloadPath, account.FolderName);

                        if (account.Id == _settings.MedMutualAccountId || account.Id == _settings.HealthNowAccountId)
                        {
                            physicianPartnerResultExportDownloadPath = string.Format(_settings.HealthPlanDownloadPath, account.FolderName);
                        }
                        else if (account.Id == _settings.BcbsScAccountId || account.Id == _settings.BcbsScAssessmentAccountId || account.Id == _settings.NammAccountId)
                        {
                            physicianPartnerResultExportDownloadPath = string.Format(_settings.HealthPlanExportRootPath, account.FolderName);
                        }
                        else if (account.Id == _settings.FloridaBlueFepAccountId)
                        {
                            physicianPartnerResultExportDownloadPath = Path.Combine(string.Format(_settings.HealthPlanDownloadPath, account.FolderName), "Reports");
                        }

                        var customSettings = _customSettingManager.Deserialize(resultExportSettings);
                        var sftpSettings = _sftpCridentialManager.Deserialize(_settings.SftpResouceFilePath + account.Tag + ".xml");

                        var fromDate = customSettings.LastTransactionDate ?? _cutOfDate;
                        var toDate = DateTime.Now;

                        _logger.Info(string.Format("Generating Result Report for Account ID : {0} and Tag : {1}", account.Id, account.Tag));

                        DateTime? stopSendingPdftoHealthPlanDate = null;
                        if (account != null && account.IsHealthPlan)
                        {
                            stopSendingPdftoHealthPlanDate = _settings.StopSendingPdftoHealthPlanDate;
                        }

                        _pcpResultExportServiceHelper.ResultExport(fromDate, toDate, account.Id, physicianPartnerResultExportDownloadPath, account.Tag, customTags, stopSendingPdftoHealthPlanDate: stopSendingPdftoHealthPlanDate);

                        var resultExportFileName = string.Format(@"ResultExport_{0}.csv", DateTime.Now.Date.ToString("yyyyMMdd"));
                        var fileName = physicianPartnerResultExportDownloadPath + "\\" + resultExportFileName;

                        if (DirectoryOperationsHelper.IsFileExist(fileName))
                        {
                            _pgpFileEncryptionHelper.EncryptFile(account, fileName);

                            if (account.Id == _settings.FloridaBlueFepAccountId && _settings.SendReportToFloridaBlueSftp)
                            {
                                var destinationSftpPath = _settings.FloridaBlueSftpPath + "\\" + account.FolderName + "\\Download\\Reports";
                                PostFile(fileName, destinationSftpPath, _settings.FloridaBlueSftpHost, _settings.FloridaBlueSftpUserName, _settings.FloridaBlueSftpPassword);
                            }
                            else
                            {
                                PostFileOnClientSftp(sftpSettings, account, fileName, fromDate);
                            }
                        }

                        customSettings.LastTransactionDate = toDate;
                        _customSettingManager.SerializeandSave(resultExportSettings, customSettings);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Account Id {0} and account Tag {1}  Message: {2} \n Stack Trace: {3} ", account.Id, account.Tag, ex.Message, ex.StackTrace));
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Message: {0} \n Stack Trace: {1} ", ex.Message, ex.StackTrace));
            }
        }

        private void PostFileOnClientSftp(SftpCridential sftpSettings, CorporateAccount account, string fileName, DateTime fromDate)
        {
            if (sftpSettings != null)
            {
                _logger.Info(string.Format("Sending Result Export File on {0} sftp", account.Tag));

                if (_ntspAccountIds != null && _ntspAccountIds.Contains(account.Id))
                {
                    var destinationPathOnSftp = string.Format(_destinationSftpFolderPdfPath, account.FolderName);

                    destinationPathOnSftp = destinationPathOnSftp + "/" + "results";

                    ExportFileOnClintSftp(fileName, destinationPathOnSftp, sftpSettings);
                }
                else if (_bcbsMnAccountId == account.Id)
                {
                    ExportFileOnClintSftp(fileName, _bcbsSftpFolderPath, sftpSettings);
                }
                else if (_settings.HcpNvAccountId == account.Id)
                {
                    var destinationPathOnSftp = (!string.IsNullOrEmpty(_settings.HcpNvSftpResultReportDownloadPath) ? _settings.HcpNvSftpResultReportDownloadPath + "/" : string.Empty) + "results";

                    ExportFileOnClintSftp(fileName, destinationPathOnSftp, sftpSettings);
                }
                else if (_settings.BcbsAlAccountId == account.Id)
                {
                    ExportFileOnClintSftp(fileName, _settings.BcbsAlSftpDownloadPath + "Reports", sftpSettings);
                }

                _logger.Info(string.Format("Sent Result Export File on {0} sftp", account.Tag));
            }
        }

        private void ExportFileOnClintSftp(string sourcePath, string destination, SftpCridential cridential)
        {
            PostFile(sourcePath, destination, cridential.HostName, cridential.UserName, cridential.Password);
        }

        private void PostFile(string sourcePath, string destination, string hostName, string userName, string password)
        {
            var processFtp = new ProcessFtp(_logger, hostName, userName, password);
            var fileName = Path.GetFileName(sourcePath);

            _logger.Info("Destination Path:  " + destination);
            _logger.Info("File Name Path:  " + fileName);
            _logger.Info("Source Path: " + sourcePath);

            processFtp.UploadSingleFile(sourcePath, destination, fileName);
        }
    }
}