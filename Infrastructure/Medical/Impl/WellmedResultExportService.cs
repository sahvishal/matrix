using System;
using System.Collections.Generic;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Core.Application.Helper;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class WellmedResultExportService : PersistenceRepository, IWellmedResultExportService
    {
        private readonly ILogger _logger;

        // private readonly IWellmedResultExportFactory _pcpResultExportFactory;
        private readonly ISettings _settings;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;

        private readonly string _resultExportSettings;
        private readonly long _accountId;
        private readonly string _wellmedResultExportDownloadPath;
        private readonly string _destinationSftpFolderResultExportPath;
        private readonly DateTime _cutOfDate;

        private readonly string _sftpHost;
        private readonly string _sftpUserName;
        private readonly string _sftpPassword;
        private readonly bool _sendReportToSftp;
        private readonly PcpResultExportServiceHelper _pcpResultExportServiceHelper;

        private readonly IEnumerable<long> _accountIds;

        public WellmedResultExportService(ILogManager logManager, ISettings settings, IUniqueItemRepository<CorporateAccount> corporateAccountRepository,
            ICustomSettingManager customSettingManager, IPgpFileEncryptionHelper pgpFileEncryptionHelper, ICsvReader csvReader)
        {
            _logger = logManager.GetLogger("WellmedResultExport");
            _settings = settings;
            _corporateAccountRepository = corporateAccountRepository;
            _customSettingManager = customSettingManager;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;

            _resultExportSettings = settings.WellmedResultReportDownloadSettings;
            _wellmedResultExportDownloadPath = settings.WellmedResultReportDownloadPath;
            _destinationSftpFolderResultExportPath = settings.WellmedSftpResultReportDownloadPath;

            _cutOfDate = settings.PcpDownloadCutOfDate;
            //_pcpResultExportFactory = new WellmedResultExportFactory(_logger);

            _sftpHost = settings.WellmedSftpHost;
            _sftpUserName = settings.WellmedSftpUserName;
            _sftpPassword = settings.WellmedSftpPassword;
            _accountId = settings.WellmedAccountId;
            _sendReportToSftp = settings.SendReportToWellmedSftp;

            _pcpResultExportServiceHelper = new PcpResultExportServiceHelper(_logger, settings, csvReader);

            _accountIds = settings.WellmedReportAccountIds;
        }

        public void ResultExport()
        {
            try
            {
                if (_accountIds.IsNullOrEmpty()) return;

                var accounts = _corporateAccountRepository.GetByIds(_accountIds);

                if (accounts.IsNullOrEmpty())
                {
                    _logger.Info("Account can't be null");
                    return;
                }

                foreach (var account in accounts)
                {
                    try
                    {
                        var resultExportSettings = string.Format(_resultExportSettings, account.Tag);

                        var customSettings = _customSettingManager.Deserialize(resultExportSettings);

                        var fromDate = customSettings.LastTransactionDate ?? _cutOfDate;
                        var toDate = DateTime.Now;

                        var destinationPath = _wellmedResultExportDownloadPath;
                        string[] customTags = null;

                        if (account.Id == _settings.WellmedWellCareAccountId)
                        {
                            destinationPath = destinationPath + "\\" + account.FolderName;
                        }

                        if (account.Id == _settings.WellmedWellCareAccountId)
                        {
                            customTags = _settings.WellCareToWellMedCustomTags;
                        }

                        if (!Directory.Exists(destinationPath))
                        {
                            Directory.CreateDirectory(destinationPath);
                        }

                        var fileName = string.Format(@"ResultExport_{0}.csv", DateTime.Now.Date.ToString("yyyyMMdd"));

                        if (account.Id != _accountId)
                        {
                            fileName = string.Format(@"WCR_ResultExport_{0}.csv", DateTime.Now.Date.ToString("yyyyMMdd")); ;
                        }

                        var sourceFileName = Path.Combine(destinationPath, fileName);

                        DateTime? stopSendingPdftoHealthPlanDate = null;
                        if (account != null && account.IsHealthPlan)
                        {
                            stopSendingPdftoHealthPlanDate = _settings.StopSendingPdftoHealthPlanDate;
                        }

                        _pcpResultExportServiceHelper.ResultExport(fromDate, toDate, account.Id, destinationPath, account.Tag, customTags: customTags, resultExportFileName: fileName, stopSendingPdftoHealthPlanDate: stopSendingPdftoHealthPlanDate);

                        if (DirectoryOperationsHelper.IsFileExist(sourceFileName))
                        {
                            sourceFileName = _pgpFileEncryptionHelper.EncryptFile(account, sourceFileName);
                        }

                        if (_sendReportToSftp && File.Exists(sourceFileName))
                        {
                            var sftpResultExportDirectory = _destinationSftpFolderResultExportPath;

                            if (account.Id != _accountId)
                            {
                                sftpResultExportDirectory = sftpResultExportDirectory + "\\" + account.FolderName;
                            }

                            var processFtp = new ProcessFtp(_logger, _sftpHost, _sftpUserName, _sftpPassword);
                            processFtp.UploadSingleFile(sourceFileName, sftpResultExportDirectory, "");
                        }

                        customSettings.LastTransactionDate = toDate;
                        _customSettingManager.SerializeandSave(resultExportSettings, customSettings);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("some error occured for Account Id:  " + account.Id + " tag: " + account.Tag);
                        _logger.Info("Message:" + ex.Message);
                        _logger.Info("Stack Trace:" + ex.StackTrace);
                    }

                }

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Message: {0} \n Stack Trace: {1} ", ex.Message, ex.StackTrace));
            }

        }
    }
}