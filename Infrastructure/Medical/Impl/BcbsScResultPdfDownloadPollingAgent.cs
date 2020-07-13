using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class BcbsScResultPdfDownloadPollingAgent : IBcbsScResultPdfDownloadPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;


        private readonly IMediaRepository _mediaRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUniqueItemRepository<Event> _eventRepository;
        private readonly IResultPdfDownloadPollingAgentHelper _resultPdfDownloaderHelper;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;

        private readonly ILogger _logger;
        private readonly ISettings _settings;

        private readonly string _customSettingFile;
        private readonly string _destinationFolderPdfPath;

        private readonly IEnumerable<long> _accountIds;
        private readonly DateTime _cutOfDate;

        public BcbsScResultPdfDownloadPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, ISettings settings, ILogManager logManager,
            IMediaRepository mediaRepository, ICustomSettingManager customSettingManager, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, ICustomerRepository customerRepository,
            IUniqueItemRepository<Event> eventRepository, IResultPdfDownloadPollingAgentHelper resultPdfDownloaderHelper, IPgpFileEncryptionHelper pgpFileEncryptionHelper)
        {
            _cutOfDate = settings.PcpDownloadCutOfDate;

            _eventCustomerResultRepository = eventCustomerResultRepository;
            _mediaRepository = mediaRepository;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _resultPdfDownloaderHelper = resultPdfDownloaderHelper;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;

            _logger = logManager.GetLogger("BCBS SC ResultPdf");
            _settings = settings;

            _accountIds = settings.BcbsScResultPdfAccountIds;
            _customSettingFile = settings.PcpResultPdfDownloadSettings;
            _destinationFolderPdfPath = settings.BcbsScResultPdfDownloadPath;
        }

        public void PollForPdfDownload()
        {
            try
            {
                if (_accountIds.IsNullOrEmpty())
                {
                    _logger.Info("Provide account Id");
                    return;
                }
                var corporateAccounts = _corporateAccountRepository.GetByIds(_accountIds);
                if (corporateAccounts.IsNullOrEmpty())
                {
                    _logger.Info("Corporate Account not found");
                    return;
                }

                foreach (var corporateAccount in corporateAccounts)
                {
                    try
                    {
                        _logger.Info(string.Format("Genderating for accountId {0} and account tag {1}. ", corporateAccount.Id, corporateAccount.Tag));

                        var destinationFolderPdfPath = string.Format(_destinationFolderPdfPath, corporateAccount.FolderName);
                        if (corporateAccount.Id == _settings.BcbsScAccountId)
                        {
                            destinationFolderPdfPath = Path.Combine(destinationFolderPdfPath, "PDF");
                        }
                        else if (corporateAccount.Id == _settings.BcbsScAssessmentAccountId)
                        {
                            destinationFolderPdfPath = Path.Combine(destinationFolderPdfPath, "PDFs");
                        }
                        var customSettingFilePath = string.Format(_customSettingFile, corporateAccount.Tag);
                        var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                        var exportToTime = DateTime.Now.AddHours(-1);
                        var exportFromTime = customSettings.LastTransactionDate ?? _cutOfDate;
                       
                        DateTime? stopSendingPdftoHealthPlanDate = null;
                        if (corporateAccount.IsHealthPlan)
                        {
                            stopSendingPdftoHealthPlanDate = _settings.StopSendingPdftoHealthPlanDate;
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
                                    var eventData = _eventRepository.GetById(ecr.EventId);

                                    var destinationFileName = string.Empty;

                                    if (!string.IsNullOrEmpty(customer.InsuranceId))
                                    {

                                        destinationFileName = string.Format("{0}_{1}", customer.InsuranceId, eventData.EventDate.Date.ToString("MMddyyyy"));
                                        var destinationFolderPdfPathWithEventYear = destinationFolderPdfPath + "\\";// + eventData.EventDate.Date.Year + "/"

                                        if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                                            destinationFileName += "_" + corporateAccount.PennedBackText;

                                        if (!string.IsNullOrEmpty(destinationFileName))
                                        {
                                            if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.PDF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                                            {
                                                var pdfResultFile = destinationFolderPdfPathWithEventYear + destinationFileName + ".pdf";

                                                _logger.Info("destination: " + pdfResultFile);
                                                _logger.Info("source: " + sourcePath);

                                                _resultPdfDownloaderHelper.ExportResultInPdfFormat(destinationFileName + ".pdf", sourcePath, destinationFolderPdfPathWithEventYear, destinationFileName + "_" + customer.Name.FirstName + ".pdf");

                                                if (File.Exists(pdfResultFile))
                                                {
                                                    _pgpFileEncryptionHelper.EncryptFile(corporateAccount, pdfResultFile);
                                                }
                                            }

                                            if (corporateAccount.ResultFormatTypeId == (long)ResultFormatType.TIF || corporateAccount.ResultFormatTypeId == (long)ResultFormatType.Both)
                                            {
                                                var tifResultFile = destinationFolderPdfPathWithEventYear + destinationFileName + ".tif";

                                                _resultPdfDownloaderHelper.ExportResultInTiffFormat(destinationFileName + ".tif", sourcePath, destinationFolderPdfPath);

                                                if (File.Exists(tifResultFile))
                                                {
                                                    _pgpFileEncryptionHelper.EncryptFile(corporateAccount, tifResultFile);
                                                }
                                            }
                                        }

                                    }
                                    else
                                    {
                                        _logger.Info("customer does not MemberId for customer Id: " + customer.CustomerId + " Event Id: " + eventData.Id);
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
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("some error occured Exception Message: \n{0}, \n stack Trace: \n\t {1} ", exception.Message, exception.StackTrace));
            }
        }
    }
}