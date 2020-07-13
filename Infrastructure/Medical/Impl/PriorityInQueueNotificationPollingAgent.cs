using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Interfaces;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PriorityInQueueNotificationPollingAgent : IPriorityInQueueNotificationPollingAgent
    {
        private readonly ILogger _logger;
        private readonly INotifier _notifier;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly ISettings _settings;
        private readonly ICustomerEventPriorityInQueueDataRepository _customerEventPriorityInQueueDataRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IEventCustomerNotificationRepository _eventCustomerNotificationRepository;

        public PriorityInQueueNotificationPollingAgent(ILogManager logManager, INotifier notifier, IEmailNotificationModelsFactory emailNotificationModelsFactory, ISettings settings,
            ICustomerEventPriorityInQueueDataRepository customerEventPriorityInQueueDataRepository, IEventCustomerResultRepository eventCustomerResultRepository, IEventCustomerNotificationRepository eventCustomerNotificationRepository)
        {
            _logger = logManager.GetLogger<PriorityInQueueNotificationPollingAgent>();
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
            _settings = settings;

            _customerEventPriorityInQueueDataRepository = customerEventPriorityInQueueDataRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _eventCustomerNotificationRepository = eventCustomerNotificationRepository;
        }

        public void PollForPriorityInQueueNotification()
        {
            try
            {
                var eventCustomerResultIds = _customerEventPriorityInQueueDataRepository.GetEventCustomerResultIdsForPriorityInQueueNotification(_settings.DaysToCheckPriorityInQueue);
                if (eventCustomerResultIds == null || !eventCustomerResultIds.Any())
                {
                    _logger.Info("No records found for priority in queue");
                }

                foreach (var eventCustomerResultId in eventCustomerResultIds)
                {
                    try
                    {
                        var eventCustomerResult = _eventCustomerResultRepository.GetById(eventCustomerResultId);

                        _logger.Info(string.Format("Checking Priority In Queue mail for EventId {0}, CustomerId {1}", eventCustomerResult.EventId, eventCustomerResult.CustomerId));

                        var messageAlreadySent = _eventCustomerNotificationRepository.GetByEventCustomerId(eventCustomerResultId, NotificationTypeAlias.PriorityInQueueCustomer);
                        if (messageAlreadySent != null)
                        {
                            _logger.Info(string.Format("Priority In Queue mail has been already sent for EventId {0}, CustomerId {1}", eventCustomerResult.EventId, eventCustomerResult.CustomerId));
                            continue;
                        }

                        var priorityInQueueNotificationModel = _emailNotificationModelsFactory.GetPriorityInQueueNotificationModel(eventCustomerResult.EventId, eventCustomerResult.CustomerId, "", eventCustomerResultId);

                        var notifications = _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.PriorityInQueueCustomer, EmailTemplateAlias.PriorityInQueueCustomer, priorityInQueueNotificationModel, 0, 1, "Priority in queue Customer");
                        if (notifications != null && notifications.Any())
                        {
                            _logger.Info(string.Format("Priority In Queue mail has been queued for EventId {0}, CustomerId {1}", eventCustomerResult.EventId, eventCustomerResult.CustomerId));

                            var notification = notifications.First();
                            var eventCustomerNotification = new EventCustomerNotification { EventCustomerId = eventCustomerResultId, NotificationId = notification.Id, NotificationTypeId = notification.NotificationType.Id };
                            _eventCustomerNotificationRepository.Save(eventCustomerNotification);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Error for priority in queue for EventCustomerResultId {0}. \n Message : {1}, \n Stack Trace : {2}", eventCustomerResultId, ex.Message, ex.StackTrace));
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while polling data for priority in queue. \n Message : {0}, \n Stack Trace : {1}", ex.Message, ex.StackTrace));
            }
        }
    }
}
