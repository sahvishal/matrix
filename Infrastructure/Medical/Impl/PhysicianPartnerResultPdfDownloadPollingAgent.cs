using System;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PhysicianPartnerResultPdfDownloadPollingAgent : IPhysicianPartnerResultPdfDownloadPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;

        private readonly string _customSettingFile;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly ILogger _logger;
        private readonly string _destinationFolderPdf;
        private readonly string _destinationFolderTiff;
        private readonly ISettings _settings;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IConvertPdfToTiff _convertPdfToTiff;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;

        public PhysicianPartnerResultPdfDownloadPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, ISettings settings, ILogManager logManager, IMediaRepository mediaRepository, ICustomSettingManager customSettingManager,
            IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, IConvertPdfToTiff convertPdfToTiff, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, IPgpFileEncryptionHelper pgpFileEncryptionHelper)
        {
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _customSettingFile = settings.PhysicianPartnerResultPdfDownloadSettings;
            _mediaRepository = mediaRepository;
            _customSettingManager = customSettingManager;
            _logger = logManager.GetLogger("ResultPdf");
            _destinationFolderPdf = settings.PhysicianPartnerResultPdfDownloadPath;
            _destinationFolderTiff = settings.PhysicianPartnerResultTiffDownloadPath;
            _settings = settings;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _convertPdfToTiff = convertPdfToTiff;
            _corporateAccountRepository = corporateAccountRepository;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
        }

        public void PollForPdfDownload()
        {
            try
            {
                var customSettings = _customSettingManager.Deserialize(_customSettingFile);
                var exportToTime = DateTime.Now.AddHours(-1);

                var corporateAccount = _corporateAccountRepository.GetById(_settings.PhysicianPartnerAccountId);

                DateTime? stopSendingPdftoHealthPlanDate = null;
                if (corporateAccount.IsHealthPlan)
                {
                    stopSendingPdftoHealthPlanDate = _settings.StopSendingPdftoHealthPlanDate;
                }

                var eventCustomerResults =
                    _eventCustomerResultRepository.GetEventCustomerResultsToFax(
                        (int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false, exportToTime,
                        customSettings.LastTransactionDate, _settings.PhysicianPartnerAccountId, "", stopSendingPdftoHealthPlanDate: stopSendingPdftoHealthPlanDate);

                var customerResults = eventCustomerResults as EventCustomerResult[] ?? eventCustomerResults.ToArray();

                if (eventCustomerResults == null || !customerResults.Any())
                {
                    _logger.Info("No event customer result list.");
                    return;
                }


                _logger.Info("Get the event customer result list.");

                var pcpResultReport = _mediaRepository.GetPdfFileNameForPcpResultReport();

                var healthPlanResultReport = _mediaRepository.GetPdfFileNameForHealthPlanResultReport();

                foreach (var ecr in customerResults)
                {
                    var sourceUrl = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + healthPlanResultReport;

                    if (!File.Exists(sourceUrl))
                    {
                        sourceUrl = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + pcpResultReport;
                    }

                    if (File.Exists(sourceUrl))
                    {
                        try
                        {
                            var pcp = _primaryCarePhysicianRepository.Get(ecr.CustomerId);

                            var pcpName = "None";
                            if (pcp != null)
                            {
                                pcpName = pcp.Name.FullName;
                            }

                            if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.PDF)
                            {
                                var pdfResultFile = ExportResultInPdfFormat(ecr.EventId, ecr.CustomerId, pcpName, sourceUrl);

                                if (File.Exists(pdfResultFile))
                                {
                                    _pgpFileEncryptionHelper.EncryptFile(corporateAccount, pdfResultFile);
                                }
                            }

                            if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.TIF)
                            {
                                var tiffResultFile = ExportResultInTiffFormat(ecr.EventId, ecr.CustomerId, pcpName, sourceUrl);

                                if (File.Exists(tiffResultFile))
                                {
                                    _pgpFileEncryptionHelper.EncryptFile(corporateAccount, tiffResultFile);
                                }
                            }

                        }
                        catch (Exception exception)
                        {
                            _logger.Error(string.Format("some error occured for the customerId {0}, {1},\n Messagen {2} \n Stack Trace {3}", ecr.CustomerId, ecr.EventId, exception.Message, exception.StackTrace));
                        }
                    }
                    else
                    {
                        _logger.Error(string.Format("File dose not generated or removed for the customerId {0}, {1}", ecr.CustomerId, ecr.EventId));
                    }
                }

                customSettings.LastTransactionDate = exportToTime;
                _customSettingManager.SerializeandSave(_customSettingFile, customSettings);
            }
            catch (Exception exception)
            {

                _logger.Error(string.Format("some error occured Exception Message: \n{0}, \n stack Trace: \n\t {1} ", exception.Message, exception.StackTrace));
            }

        }

        private string ExportResultInPdfFormat(long eventId, long customerId, string pcpName, string sourceUrl)
        {
            var eventDirectoryPdf = _destinationFolderPdf + "/" + eventId;
            eventDirectoryPdf = eventDirectoryPdf + "/" + pcpName;

            CreateDistinationDirectory(eventDirectoryPdf);

            var destinationPdfFile = string.Format("{0}/{1}.pdf", eventDirectoryPdf, customerId);
            if (File.Exists(destinationPdfFile)) File.Delete(destinationPdfFile);
            File.Copy(sourceUrl, destinationPdfFile);

            return destinationPdfFile;
        }

        private string ExportResultInTiffFormat(long eventId, long customerId, string pcpName, string sourceUrl)
        {
            var eventDirectoryTiff = _destinationFolderTiff + "/" + eventId;
            eventDirectoryTiff = eventDirectoryTiff + "/" + pcpName;

            CreateDistinationDirectory(eventDirectoryTiff);

            var destinationTiffFile = string.Format("{0}/{1}.tif", eventDirectoryTiff, customerId);

            if (File.Exists(destinationTiffFile)) File.Delete(destinationTiffFile);

            _convertPdfToTiff.SavePdfAsTiffImage(sourceUrl, destinationTiffFile);

            return destinationTiffFile;
        }

        private void CreateDistinationDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        }

    }
}
