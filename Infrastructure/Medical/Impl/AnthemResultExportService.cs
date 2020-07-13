using System;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Application.Helper;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class AnthemResultExportService : IAnthemResultExportService
    {
        private readonly ILogger _logger;


        private readonly ISettings _settings;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly ICorporateTagRepository _corporateTagRepository;
        private readonly string _resultExportSettings;

        private readonly PcpResultExportServiceHelper _pcpResultExportServiceHelper;

        private readonly string _accumulativeResultExportsPath;
        private readonly string _incrementalResultExportsPath;

        private readonly string[] _customTags;
        private readonly long _anthemAccountId;

        public AnthemResultExportService(ILogManager logManager, ISettings settings, IUniqueItemRepository<CorporateAccount> corporateAccountRepository,
            ICustomSettingManager customSettingManager, IPgpFileEncryptionHelper pgpFileEncryptionHelper, ICorporateTagRepository corporateTagRepository, ICsvReader csvReader)
        {
            _logger = logManager.GetLogger("AnthemResultExportService");
            _settings = settings;
            _corporateAccountRepository = corporateAccountRepository;
            _customSettingManager = customSettingManager;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _corporateTagRepository = corporateTagRepository;
            _resultExportSettings = settings.PcpResultReportDownloadSettings;

            _customTags = settings.AnthemCustomTags;

            _pcpResultExportServiceHelper = new PcpResultExportServiceHelper(_logger, settings, csvReader);

            _accumulativeResultExportsPath = settings.CumulativeResultExportsPath;
            _incrementalResultExportsPath = settings.IncrementalResultExportsPath;
            _anthemAccountId = _settings.AnthemAccountId;
        }

        public void ResultExport()
        {
            try
            {
                string[] showAdditionalFields = null;
                if (!string.IsNullOrEmpty(_settings.AnthemAdditionalFieldValues))
                {
                    showAdditionalFields = _settings.AnthemAdditionalFieldValues.Split(new char[','], StringSplitOptions.RemoveEmptyEntries);
                }

                foreach (var customTag in _customTags)
                {
                    try
                    {
                        _logger.Info("Running report for CustomTag: " + customTag);
                        var corporateTag = _corporateTagRepository.GetByTag(customTag);

                        if (corporateTag == null)
                        {
                            _logger.Info("No Corporate Tag Found: " + customTag);
                            continue;
                        }
                        var account = (_corporateAccountRepository).GetById(corporateTag.CorporateId);

                        _logger.Info(string.Format("Generating AppointmentBooked for accountId {0} and account tag {1}. ", account.Id, account.Tag));

                        var folderStateCode = string.Empty;
                        if (account.Id == _anthemAccountId)
                        {
                            folderStateCode = "CA";
                        }
                        else
                        {
                            foreach (var stateCode in _settings.AnthemCustomTagStates)
                            {
                                if (customTag.Contains(stateCode))
                                {
                                    folderStateCode = stateCode.Substring(stateCode.Length - 2);

                                    break;
                                }
                            }
                        }

                        if (folderStateCode == string.Empty)
                            continue;

                        var destinationPath = string.Format(_settings.AnthemDownloadPath, folderStateCode);
                        destinationPath = Path.Combine(destinationPath, "results");

                        var resultExportSettings = string.Format(_resultExportSettings, account.Tag);

                        var customSettings = _customSettingManager.Deserialize(resultExportSettings);

                        var fromDate = customSettings.LastTransactionDate ?? DateTime.Today.GetFirstDateOfYear();

                        var toDate = DateTime.Now;

                        CreateDistinationDirectory(destinationPath);

                        CreateDistinationDirectory(_accumulativeResultExportsPath);
                        CreateDistinationDirectory(_incrementalResultExportsPath);

                        var customTags = new[] { customTag };

                        var finalFilename = string.Format("HLTHFAIR_ResultsExport_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));
                        var incrementalFile = string.Format(@"ResultExport_{0}_{1}.csv", account.Tag, Guid.NewGuid());

                        var cumulativeFilePath = Path.Combine(_accumulativeResultExportsPath, string.Format(@"ResultExport_{0}_{1}.csv", account.Tag, DateTime.Today.Year));
                        var incrementalFilePath = Path.Combine(_incrementalResultExportsPath, incrementalFile);

                        var finalFilePath = Path.Combine(destinationPath, finalFilename);

                        DateTime? stopSendingPdftoHealthPlanDate = null;
                        if (account != null && account.IsHealthPlan)
                        {
                            stopSendingPdftoHealthPlanDate = _settings.StopSendingPdftoHealthPlanDate;
                        }

                        _pcpResultExportServiceHelper.ResultExport(fromDate, toDate, account.Id, _incrementalResultExportsPath, account.Tag, customTags, resultExportFileName: incrementalFile, considerEventDate: true, eventStartDate: fromDate.GetFirstDateOfYear(), eventEndDate: fromDate.GetLastDateOfYear(), showHiddenAdditionalFields: showAdditionalFields, stopSendingPdftoHealthPlanDate: stopSendingPdftoHealthPlanDate);

                        _pcpResultExportServiceHelper.CreateCumulativeFileAndPost(incrementalFilePath, cumulativeFilePath, finalFilePath);

                        if (DirectoryOperationsHelper.IsFileExist(finalFilePath))
                        {
                            _pgpFileEncryptionHelper.EncryptFile(account, finalFilePath);
                        }

                        customSettings.LastTransactionDate = toDate;
                        _customSettingManager.SerializeandSave(resultExportSettings, customSettings);

                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Custom Tag {0}  Message: {1} \n Stack Trace: {2} ", customTag, ex.Message, ex.StackTrace));
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Message: {0} \n Stack Trace: {1} ", ex.Message, ex.StackTrace));
            }
        }

        private void CreateDistinationDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        }

    }
}