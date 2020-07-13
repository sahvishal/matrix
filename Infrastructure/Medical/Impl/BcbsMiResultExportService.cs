using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Users.Domain;
using System;
using System.IO;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class BcbsMiResultExportService : IBcbsMiResultExportService
    {
        private readonly ILogger _logger;


        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly ICsvReader _csvReader;
        private readonly string _resultExportSettings;
        private readonly long _accountId;
        private readonly string _bcbsmiResultExportDownloadPath;
        private readonly PcpResultExportServiceHelper _pcpResultExportServiceHelper;
        private readonly string[] _bcbsMiGapPatinetTags;
        private readonly DayOfWeek _bcbsMiGapResultExportIntervalDay;
        private readonly string _accumulativeResultExportsPath;

        private readonly string _incrementalResultExportsPath;

        private readonly DateTime _stopSendingPdftoHealthPlanDate;

        public BcbsMiResultExportService(ILogManager logManager, ISettings settings, IUniqueItemRepository<CorporateAccount> corporateAccountRepository,
            ICustomSettingManager customSettingManager, IPgpFileEncryptionHelper pgpFileEncryptionHelper, ICsvReader csvReader)
        {
            _logger = logManager.GetLogger("BcbsMiResultExport");
            _corporateAccountRepository = corporateAccountRepository;
            _customSettingManager = customSettingManager;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _csvReader = csvReader;

            _resultExportSettings = settings.PcpResultReportDownloadSettings;

            _bcbsmiResultExportDownloadPath = settings.BcbsMiResultReportDownloadPath;
            _accountId = settings.BcbsMiAccountId;

            _bcbsMiGapPatinetTags = settings.BcbsMiGapPatinetTags;
            _bcbsMiGapResultExportIntervalDay = settings.BcbsMiGapResultExportIntervalDay;

            _pcpResultExportServiceHelper = new PcpResultExportServiceHelper(_logger, settings, csvReader);

            _accumulativeResultExportsPath = settings.CumulativeResultExportsPath;
            _incrementalResultExportsPath = settings.IncrementalResultExportsPath;

            _stopSendingPdftoHealthPlanDate = settings.StopSendingPdftoHealthPlanDate;
        }

        public void ResultExport()
        {
            try
            {
                if (DateTime.Today.DayOfWeek != _bcbsMiGapResultExportIntervalDay)
                {
                    _logger.Info("Today is " + DateTime.Today.DayOfWeek + " while service is configured to run on " + _bcbsMiGapResultExportIntervalDay);
                    _logger.Info("Please set " + (int)DateTime.Today.DayOfWeek + " to run Service today");
                    return;
                }

                if (_accountId <= 0) return;
                var account = _corporateAccountRepository.GetById(_accountId);
                var destinationPath = string.Format(_bcbsmiResultExportDownloadPath, account.FolderName);
                try
                {
                    var resultExportSettings = string.Format(_resultExportSettings, account.Tag);

                    var customSettings = _customSettingManager.Deserialize(resultExportSettings);

                    var fromDate = customSettings.LastTransactionDate.HasValue ? customSettings.LastTransactionDate.Value : DateTime.Today.GetFirstDateOfYear();

                    var toDate = DateTime.Now;

                    CreateDistinationDirectory(destinationPath);

                    if (fromDate.Year == toDate.Year)
                    {
                        ResultExportForGapPatient(fromDate, toDate, account, fromDate.GetFirstDateOfYear(), fromDate.GetLastDateOfYear());
                    }
                    else if (fromDate.Year < DateTime.Today.Year)
                    {
                        toDate = new DateTime(fromDate.Year, 12, 31);
                        ResultExportForGapPatient(fromDate, toDate, account, fromDate.GetFirstDateOfYear(), fromDate.GetLastDateOfYear());

                        fromDate = new DateTime(DateTime.Now.Year, 1, 1);
                        ResultExportForGapPatient(fromDate, DateTime.Today, account, fromDate.GetFirstDateOfYear(), fromDate.GetLastDateOfYear());
                    }

                    customSettings.LastTransactionDate = toDate;
                    _customSettingManager.SerializeandSave(resultExportSettings, customSettings);

                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Account Id {0} and account Tag {1}  Message: {2} \n Stack Trace: {3} ", account.Id, account.Tag, ex.Message, ex.StackTrace));
                }

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Message: {0} \n Stack Trace: {1} ", ex.Message, ex.StackTrace));
            }
        }

        private void CreateDistinationDirectory(string directoryPath)
        {
            if (!DirectoryOperationsHelper.IsDirectoryExist(directoryPath)) DirectoryOperationsHelper.CreateDirectory(directoryPath);
        }

        private void ResultExportForGapPatient(DateTime fromDate, DateTime toDate, CorporateAccount account, DateTime eventStartDate, DateTime eventEndDate)
        {
            try
            {
                var bcbsmiResultExportDownloadPath = string.Format(_bcbsmiResultExportDownloadPath, account.FolderName);

                var gapFileName = string.Format(@"Q_MOBILE_ResultExport_{0}_{1}.csv", fromDate.Date.ToString("yyyyMMdd"), toDate.Date.ToString("yyyyMMdd"));

                var finalFilename = Path.Combine(bcbsmiResultExportDownloadPath, gapFileName);

                CreateDistinationDirectory(_accumulativeResultExportsPath);
                CreateDistinationDirectory(_incrementalResultExportsPath);

                var cumulativeFilePath = Path.Combine(_accumulativeResultExportsPath, string.Format(@"ResultExport_{0}_{1}.csv", account.Tag, eventStartDate.Year));

                var incrementalFile = string.Format(@"ResultExport_{0}_{1}.csv", account.Tag, Guid.NewGuid());

                var incrementalFilePath = Path.Combine(_incrementalResultExportsPath, incrementalFile);

                DateTime? stopSendingPdftoHealthPlanDate = null;
                if (account != null && account.IsHealthPlan)
                {
                    stopSendingPdftoHealthPlanDate = _stopSendingPdftoHealthPlanDate;
                }

                _pcpResultExportServiceHelper.ResultExport(fromDate, toDate, account.Id, _incrementalResultExportsPath, account.Tag,
                    _bcbsMiGapPatinetTags, useBlankValue: true, resultExportFileName: incrementalFile, considerEventDate: true,
                    eventStartDate: eventStartDate, eventEndDate: eventEndDate, stopSendingPdftoHealthPlanDate: stopSendingPdftoHealthPlanDate);

                _pcpResultExportServiceHelper.CreateCumulativeFileAndPost(incrementalFilePath, cumulativeFilePath, finalFilename);

                if (DirectoryOperationsHelper.IsFileExist(finalFilename))
                {
                    _csvReader.RemoveEmptyColumnsFromCsv(finalFilename);

                    _pgpFileEncryptionHelper.EncryptFile(account, finalFilename);
                }

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Message: {0} \n Stack Trace: {1} ", ex.Message, ex.StackTrace));
            }
        }

    }
}