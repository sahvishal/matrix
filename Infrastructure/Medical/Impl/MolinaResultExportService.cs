using System;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Application.Helper;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MolinaResultExportService : PersistenceRepository, IMolinaResultExportService
    {
        private readonly ILogger _logger;

        // private readonly IWellmedResultExportFactory _pcpResultExportFactory;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;

        private readonly string _resultExportSettings;
        private readonly long _accountId;
        private readonly string _molinaResultExportDownloadPath;

        private readonly DateTime _cutOfDate;

        private readonly PcpResultExportServiceHelper _pcpResultExportServiceHelper;

        private readonly DateTime _stopSendingPdftoHealthPlanDate;

        public MolinaResultExportService(ILogManager logManager, ISettings settings, IUniqueItemRepository<CorporateAccount> corporateAccountRepository,
            ICustomSettingManager customSettingManager, IPgpFileEncryptionHelper pgpFileEncryptionHelper, ICsvReader csvReader)
        {
            _logger = logManager.GetLogger("MolinaResultExport");
            _corporateAccountRepository = corporateAccountRepository;
            _customSettingManager = customSettingManager;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;


            _resultExportSettings = settings.MolinaResultReportDownloadSettings;
            _molinaResultExportDownloadPath = settings.MolinaResultReportDownloadPath;

            _cutOfDate = settings.PcpDownloadCutOfDate;

            _accountId = settings.MolinaAccountId;

            _pcpResultExportServiceHelper = new PcpResultExportServiceHelper(_logger, settings, csvReader);

            _stopSendingPdftoHealthPlanDate = settings.StopSendingPdftoHealthPlanDate;

        }

        public void ResultExport()
        {
            try
            {
                if (_accountId <= 0) return;

                var account = _corporateAccountRepository.GetById(_accountId);

                if (account == null)
                {
                    _logger.Info("Account can't be null");
                    return;
                }

                var resultExportSettings = string.Format(_resultExportSettings, account.Tag);

                var customSettings = _customSettingManager.Deserialize(resultExportSettings);

                var fromDate = customSettings.LastTransactionDate ?? _cutOfDate;
                var toDate = DateTime.Now;

                if (!Directory.Exists(_molinaResultExportDownloadPath))
                {
                    Directory.CreateDirectory(_molinaResultExportDownloadPath);
                }

                var sourceFileName = _molinaResultExportDownloadPath + string.Format(@"\ResultExport_{0}.csv", DateTime.Now.Date.ToString("yyyyMMdd")); ;

                DateTime? stopSendingPdftoHealthPlanDate = null;
                if (account != null && account.IsHealthPlan)
                {
                    stopSendingPdftoHealthPlanDate = _stopSendingPdftoHealthPlanDate;
                }

                _pcpResultExportServiceHelper.ResultExport(fromDate, toDate, account.Id, _molinaResultExportDownloadPath, account.Tag, stopSendingPdftoHealthPlanDate: stopSendingPdftoHealthPlanDate);

                try
                {
                    if (DirectoryOperationsHelper.IsFileExist(sourceFileName))
                    {
                        _pgpFileEncryptionHelper.EncryptFile(account, sourceFileName);
                    }
                    else
                    {
                        _logger.Error("Message: " + sourceFileName + " File not found");
                    }

                }
                catch (Exception exception)
                {
                    _logger.Error("Message: " + exception.Message + " Stack Trace: " + exception.StackTrace);

                }

                customSettings.LastTransactionDate = toDate;
                _customSettingManager.SerializeandSave(resultExportSettings, customSettings);

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Message: {0} \n Stack Trace: {1} ", ex.Message, ex.StackTrace));
            }

        }
    }
}