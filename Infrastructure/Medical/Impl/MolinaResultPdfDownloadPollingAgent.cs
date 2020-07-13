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
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MolinaResultPdfDownloadPollingAgent : IMolinaResultPdfDownloadPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ICustomerRepository _customerRepository;

        private readonly IResultPdfDownloadPollingAgentHelper _resultPdfDownloadHelper;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly IEventRepository _eventRepository;

        private readonly ILogger _logger;

        private readonly string _customDownloadSettings;
        private readonly string _destinationFolderPdfPath;
        private readonly long _accountId;
        private readonly DateTime _cutOfDate;
        private readonly DateTime _stopSendingPdftoHealthPlanDate;
        

        public MolinaResultPdfDownloadPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, ISettings settings, ILogManager logManager, IMediaRepository mediaRepository,
            ICustomSettingManager customSettingManager, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, ICustomerRepository customerRepository,
            IResultPdfDownloadPollingAgentHelper resultPdfDownloadHelper, IPgpFileEncryptionHelper pgpFileEncryptionHelper, IEventRepository eventRepository)
        {
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _mediaRepository = mediaRepository;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _customerRepository = customerRepository;

            _resultPdfDownloadHelper = resultPdfDownloadHelper;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _eventRepository = eventRepository;

            _logger = logManager.GetLogger("MolinaResultPdf");

            _customDownloadSettings = settings.MolinaResultPdfDownloadSettings;
            _destinationFolderPdfPath = settings.MolinaResultPdfDownloadPath;

            _cutOfDate = settings.PcpDownloadCutOfDate;

            _accountId = settings.MolinaAccountId;

            _stopSendingPdftoHealthPlanDate = settings.StopSendingPdftoHealthPlanDate;
        }

        public void PollForPdfDownload()
        {
            try
            {
                if (_accountId <= 0) return;
                var corporateAccount = _corporateAccountRepository.GetById(_accountId);

                try
                {
                    _logger.Info(string.Format("Genderating for accountId {0} and account tag {1}. ", corporateAccount.Id, corporateAccount.Tag));

                    var customSettingFilePath = string.Format(_customDownloadSettings, corporateAccount.Tag);
                    var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                    var exportToTime = DateTime.Now.AddHours(-1);
                    var exportFromTime = customSettings.LastTransactionDate ?? _cutOfDate;
                   
                    DateTime? stopSendingPdftoHealthPlanDate = null;
                    if (corporateAccount.IsHealthPlan)
                    {
                        stopSendingPdftoHealthPlanDate = _stopSendingPdftoHealthPlanDate;
                    }
                  
                    var eventCustomerResults =
                        _eventCustomerResultRepository.GetEventCustomerResultsToFax(
                            (int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false, exportToTime, exportFromTime,
                            corporateAccount.Id, corporateAccount.Tag, true, stopSendingPdftoHealthPlanDate: stopSendingPdftoHealthPlanDate);

                    var customerResults = eventCustomerResults as EventCustomerResult[] ?? eventCustomerResults.ToArray();

                    if (eventCustomerResults == null || !customerResults.Any())
                    {
                        _logger.Info(string.Format("No event customer result list for {0} Result Pdf Download.", corporateAccount.Tag));
                        return;
                    }

                    var distinctEventIds = eventCustomerResults.Select(x => x.EventId).Distinct();

                    var events = ((IUniqueItemRepository<Event>)_eventRepository).GetByIds(distinctEventIds);

                    _logger.Info(string.Format("Found {0} customers for {1} Result Pdf Download. ", eventCustomerResults.Count(), corporateAccount.Tag));

                    var pcpResultReport = _mediaRepository.GetPdfFileNameForPcpResultReport();

                    var healthPlanResultReport = _mediaRepository.GetPdfFileNameForHealthPlanResultReport();

                    foreach (var ecr in customerResults)
                    {
                        var sourcePath = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + healthPlanResultReport;

                        if (!File.Exists(sourcePath))
                        {
                            sourcePath = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + pcpResultReport;
                        }

                        if (File.Exists(sourcePath))
                        {
                            try
                            {
                                var customer = _customerRepository.GetCustomer(ecr.CustomerId);
                                var eventData = events.Single(x => x.Id == ecr.EventId);

                                if (!string.IsNullOrEmpty(customer.InsuranceId))
                                {
                                    var eventDirectoryPdf = _destinationFolderPdfPath + @"\";
                                    var dateOfRegeneration = ecr.RegenerationDate ?? ecr.DataRecorderMetaData.DateModified;
                                    var fileName = customer.InsuranceId + "_" + eventData.EventDate.ToString("yyyyMMdd") + "_" + (dateOfRegeneration.Value.ToString("yyyyMMdd"));

                                    if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                        fileName += "_" + corporateAccount.PennedBackText;

                                    if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.PDF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                                    {
                                        var pdfFileName = fileName + ".pdf";

                                        _resultPdfDownloadHelper.ExportResultInPdfFormat(pdfFileName, sourcePath, eventDirectoryPdf);
                                        try
                                        {
                                            _pgpFileEncryptionHelper.EncryptFile(corporateAccount, eventDirectoryPdf + @"\" + pdfFileName);
                                        }
                                        catch (Exception exception)
                                        {
                                            _logger.Error("Message : " + exception.Message + " Stack Trace : " + exception.StackTrace);
                                        }

                                    }

                                    if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.TIF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                                    {
                                        var tifFileName = fileName + ".tif";

                                        _resultPdfDownloadHelper.ExportResultInTiffFormat(tifFileName, sourcePath, eventDirectoryPdf);

                                        try
                                        {
                                            _pgpFileEncryptionHelper.EncryptFile(corporateAccount, eventDirectoryPdf + @"\" + tifFileName);
                                        }
                                        catch (Exception exception)
                                        {
                                            _logger.Error("Message : " + exception.Message + " Stack Trace : " + exception.StackTrace);
                                        }

                                    }
                                }
                                else
                                {
                                    _logger.Info(string.Format("member id is not found for customer {0} and eventId {1}", ecr.CustomerId, ecr.EventId));
                                }

                            }
                            catch (Exception exception)
                            {
                                _logger.Error(string.Format("some error occured for the customerId {0}, {1},\n Messagen {2} \n Stack Trace {3}", ecr.CustomerId, ecr.EventId, exception.Message, exception.StackTrace));
                            }
                        }
                        else
                        {
                            _logger.Info(string.Format("File not generated or removed for the customerId {0}, {1}", ecr.CustomerId, ecr.EventId));
                        }
                    }

                    customSettings.LastTransactionDate = exportToTime;
                    _customSettingManager.SerializeandSave(customSettingFilePath, customSettings);

                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("some error occured for AccountId: {0} and account tag: {1} Exception Message: \n{2}, \n stack Trace: \n\t {3} ", corporateAccount.Id, corporateAccount.Tag, ex.Message, ex.StackTrace));
                }


            }
            catch (Exception exception)
            {

                _logger.Error(string.Format("some error occured Exception Message: \n{0}, \n stack Trace: \n\t {1} ", exception.Message, exception.StackTrace));
            }
        }
    }
}