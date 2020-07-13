using System;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;


namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IPhysicianPartnerQueueFaxPollingAgent))]
    public class PhysicianPartnerQueueFaxPollingAgent : IPhysicianPartnerQueueFaxPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly INotifier _notifier;
        private readonly ILogger _logger;
        private readonly IPrimaryCarePhysicianRepository _pcpRepository;
        private readonly int _faxInterval;
        private readonly IMediaRepository _mediaRepository;
        private readonly IEventCustomerNotificationRepository _eventCustomerNotificationRepository;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly ISettings _settings;

        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;


        public PhysicianPartnerQueueFaxPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, INotifier notifier, ILogManager logManager, IPrimaryCarePhysicianRepository pcpRepository,
             IMediaRepository mediaRepository, IEventCustomerNotificationRepository eventCustomerNotificationRepository, IConfigurationSettingRepository configurationSettingRepository, ISettings settings, IUniqueItemRepository<CorporateAccount> corporateAccountRepository)
        {
            _eventCustomerResultRepository = eventCustomerResultRepository;

            _notifier = notifier;
            _faxInterval = settings.FaxServiceInvokeInterval;
            _logger = logManager.GetLogger<ResultNotificationPollingAgent>();
            _pcpRepository = pcpRepository;
            _mediaRepository = mediaRepository;
            _eventCustomerNotificationRepository = eventCustomerNotificationRepository;
            _configurationSettingRepository = configurationSettingRepository;
            _settings = settings;
            _corporateAccountRepository = corporateAccountRepository;
        }

        public void PollforFaxResultNotification()
        {
            try
            {
                var value = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnablePhysicianPartnerCustomerResultFaxNotification);

                if (value.ToLower() != bool.TrueString.ToLower()) return;

                var account = _corporateAccountRepository.GetById(_settings.PhysicianPartnerAccountId);

                DateTime? stopSendingPdftoHealthPlanDate = null;
                if (account != null && account.IsHealthPlan)
                {
                    stopSendingPdftoHealthPlanDate = _settings.StopSendingPdftoHealthPlanDate;
                }

                var eventCustomerResults =
                    _eventCustomerResultRepository.GetEventCustomerResultsToFax(
                    (int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false, DateTime.Now, DateTime.Now.AddHours(-_faxInterval), _settings.PhysicianPartnerAccountId, "", stopSendingPdftoHealthPlanDate: stopSendingPdftoHealthPlanDate);

                var customerResults = eventCustomerResults as EventCustomerResult[] ?? eventCustomerResults.ToArray();

                if (eventCustomerResults == null || !customerResults.Any())
                {
                    _logger.Info("No event customer result list found for Fax queue.");
                    return;
                }
                _logger.Info("Get the event customer result list for Fax queue.");

                var fileName = _mediaRepository.GetPdfFileNameForPcpResultReport();

                var customerIds = customerResults.Select(x => x.CustomerId).ToArray();

                var pcpList = _pcpRepository.GetByCustomerIds(customerIds).Where(x => x.Fax != null && !string.IsNullOrEmpty(x.Fax.ToString()));

                foreach (var ecr in customerResults)
                {
                    var messageAlreadySent = _eventCustomerNotificationRepository.GetByEventCustomerId(ecr.Id, NotificationTypeAlias.PhysicianPartnerCustomerResultFaxNotification);
                    if (messageAlreadySent != null)
                    {
                        _logger.Info(string.Format("Fax already queued for EventId {0}, CustomerId {1}", ecr.EventId, ecr.CustomerId));
                        continue;
                    }
                    var path = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath;
                    var pdfUrl = path + fileName;
                    if (path.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                        throw new InvalidDirectoryPathException();

                    if (File.Exists(pdfUrl))
                    {
                        var pcp = pcpList.FirstOrDefault(x => x.CustomerId == ecr.CustomerId);

                        if (pcp == null)
                        {
                            _logger.Error(string.Format("PCP not found/or pcp Fax not found where customerId {0}", ecr.CustomerId));
                        }
                        else
                        {
                            try
                            {
                                PhoneNotificationModel model = null;
                                var notification = _notifier.NotifyViaFax(NotificationTypeAlias.PhysicianPartnerCustomerResultFaxNotification, model, pcp.Fax, DirectoryOperationsHelper.ReadAllBytes(pdfUrl), 1, "Faxing Notification");

                                if (notification != null)
                                {
                                    var eventCustomerNotification = new EventCustomerNotification { EventCustomerId = ecr.Id, NotificationId = notification.Id, NotificationTypeId = notification.NotificationType.Id };
                                    _eventCustomerNotificationRepository.Save(eventCustomerNotification);
                                }
                                _logger.Info(string.Format("Fax queued for EventId {0}, CustomerId {1}", ecr.EventId, ecr.CustomerId));
                            }
                            catch (Exception ex)
                            {
                                _logger.Error(string.Format("Fax not queued for EventId {0}, CustomerId {1}", ecr.EventId, ecr.CustomerId));
                                _logger.Error("\n");
                                _logger.Error(ex.Message + "Stack Trace:" + ex.StackTrace);
                            }

                        }
                    }
                    else
                    {
                        _logger.Error(string.Format("Fax queue: File Not found for EventId {0}, CustomerId {1}", ecr.EventId, ecr.CustomerId));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message + "Fax queue: Stack Trace:" + ex.StackTrace);
            }
        }
    }
}
