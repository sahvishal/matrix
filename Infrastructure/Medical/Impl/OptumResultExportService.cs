using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Medical.Interfaces;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class OptumResultExportService : IOptumResultExportService
    {
        private readonly ILogger _logger;


        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;

        private readonly string _resultExportSettings;
        private readonly IEnumerable<long> _accountIds;
        private readonly string _optumeResultExportDownloadPath;
        private readonly DateTime _cutOfDate;
        private readonly PcpResultExportServiceHelper _pcpResultExportServiceHelper;
        private readonly IEnumerable<long> _optumAccountIds;
        private readonly IEnumerable<long> _optumNVSettingAccountIds;

        private readonly string _accumulativeResultExportsPath;
        private readonly string _incrementalResultExportsPath;
        private readonly long _optumnvAccountId;

        private readonly DateTime _stopSendingPdftoHealthPlanDate;


        public OptumResultExportService(ILogManager logManager, ISettings settings, ICorporateAccountRepository corporateAccountRepository,
            ICustomSettingManager customSettingManager, IPgpFileEncryptionHelper pgpFileEncryptionHelper, ICsvReader csvReader)
        {
            _logger = logManager.GetLogger("Optum Result Export");
            _corporateAccountRepository = corporateAccountRepository;
            _customSettingManager = customSettingManager;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;

            _resultExportSettings = settings.PcpResultReportDownloadSettings;

            _optumeResultExportDownloadPath = settings.OptumResultReportDownloadPath;

            _accountIds = settings.OptumResultReportDownloadAccountIds;
            _cutOfDate = settings.PcpDownloadCutOfDate;
            _optumAccountIds = settings.OptumAccountIds;

            _optumNVSettingAccountIds = settings.OptumNVSettingAccountIds;

            _pcpResultExportServiceHelper = new PcpResultExportServiceHelper(_logger, settings, csvReader);

            _accumulativeResultExportsPath = settings.CumulativeResultExportsPath;
            _incrementalResultExportsPath = settings.IncrementalResultExportsPath;
            _optumnvAccountId = settings.OptumNvAccountId;

            _stopSendingPdftoHealthPlanDate = settings.StopSendingPdftoHealthPlanDate;


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
                        _logger.Info(string.Format("Generating for accountId {0} and account tag {1}. ", account.Id, account.Tag));

                        var resultExportSettings = string.Format(_resultExportSettings, account.Tag);
                        var optumResultExportDownloadPath = string.Format(_optumeResultExportDownloadPath, account.FolderName);

                        var customSettings = _customSettingManager.Deserialize(resultExportSettings);

                        var fromDate = customSettings.LastTransactionDate ?? DateTime.Today.GetFirstDateOfYear();

                        var toDate = DateTime.Now;

                        if (_optumAccountIds.Contains(account.Id))
                        {
                            try
                            {
                                DirectoryOperationsHelper.DeleteDirectory(optumResultExportDownloadPath, true);
                            }
                            catch (Exception ex)
                            {
                                _logger.Error("Some error occurred while deleting directory at path: " + optumResultExportDownloadPath);
                                _logger.Error("Message: " + ex.Message);
                                _logger.Error("Stack Trace: " + ex.StackTrace);
                            }
                        }

                        string[] showHiddenColumns = new string[1];

                        if (_optumNVSettingAccountIds.Contains(account.Id))
                        {
                            showHiddenColumns[0] = "Mrn";
                        }

                        _logger.Info(" Create Destination Path: " + optumResultExportDownloadPath);

                        DirectoryOperationsHelper.CreateDirectoryIfNotExist(optumResultExportDownloadPath);

                        var fileName = optumResultExportDownloadPath + string.Format(@"\ResultExport_{0}.csv", DateTime.Now.Date.ToString("yyyyMMdd"));

                        if (_optumAccountIds.Contains(account.Id))
                        {
                            GenerateCummulativeReport(fromDate, toDate, account, optumResultExportDownloadPath, showHiddenColumns, fileName);
                        }
                        else
                        {
                            DateTime? stopSendingPdftoHealthPlanDate = null;
                            if (account != null && account.IsHealthPlan)
                            {
                                stopSendingPdftoHealthPlanDate = _stopSendingPdftoHealthPlanDate;
                            }

                            _pcpResultExportServiceHelper.ResultExport(fromDate, toDate, account.Id, optumResultExportDownloadPath, account.Tag, resultExportFileName: fileName, showHiddenColumns: showHiddenColumns, stopSendingPdftoHealthPlanDate: stopSendingPdftoHealthPlanDate);
                        }

                        if (DirectoryOperationsHelper.IsFileExist(fileName))
                        {
                            _pgpFileEncryptionHelper.EncryptFile(account, fileName);
                        }
                        else if (_optumNVSettingAccountIds.Contains(account.Id))
                        {
                            _pcpResultExportServiceHelper.WriteCsvHeader(fileName, showHiddenColumns);
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

        public void GenerateCummulativeReport(DateTime fromDate, DateTime toDate, CorporateAccount account, string finalDestinationPath, string[] showHiddenColumns, string reportName)
        {
            DirectoryOperationsHelper.CreateDirectoryIfNotExist(_accumulativeResultExportsPath);
            DirectoryOperationsHelper.CreateDirectoryIfNotExist(_incrementalResultExportsPath);

            var cumulativeFilePath = Path.Combine(_accumulativeResultExportsPath, string.Format(@"ResultExport_{0}_{1}.csv", account.Tag, _cutOfDate.Year));
            var incrementalFile = string.Format(@"ResultExport_{0}_{1}.csv", account.Tag, Guid.NewGuid());
            var incrementalFilePath = Path.Combine(_incrementalResultExportsPath, incrementalFile);

            var finalFilename = Path.Combine(finalDestinationPath, reportName);
            _logger.Info("finalDestinationPath:  " + finalDestinationPath);
            DirectoryOperationsHelper.CreateDirectoryIfNotExist(finalDestinationPath);

            _pcpResultExportServiceHelper.ResultExport(fromDate, toDate, account.Id, _incrementalResultExportsPath, account.Tag, resultExportFileName: incrementalFile,
                considerEventDate: true, showHiddenColumns: showHiddenColumns, eventStartDate: _cutOfDate, eventEndDate: null, stopSendingPdftoHealthPlanDate: _stopSendingPdftoHealthPlanDate);

            _pcpResultExportServiceHelper.CreateCumulativeFileAndPost(incrementalFilePath, cumulativeFilePath, finalFilename);
        }
    }
}