using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Medical.Impl;

namespace Falcon.App.Infrastructure.Communication.Impl
{
    [DefaultImplementation]
    public class QueueCustomerFaxResultNotificationService : IQueueCustomerFaxResultNotificationService
    {
        private readonly INotifier _notifier;
        private readonly ILogger _logger;
        private readonly IPrimaryCarePhysicianRepository _pcpRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IEventCustomerNotificationRepository _eventCustomerNotificationRepository;

        public QueueCustomerFaxResultNotificationService(
            INotifier notifier, ILogManager logManager, IPrimaryCarePhysicianRepository pcpRepository,
             IMediaRepository mediaRepository, IEventCustomerNotificationRepository eventCustomerNotificationRepository, IConfigurationSettingRepository configurationSettingRepository)
        {
            _notifier = notifier;
            _logger = logManager.GetLogger<ResultNotificationPollingAgent>();
            _pcpRepository = pcpRepository;
            _mediaRepository = mediaRepository;
            _eventCustomerNotificationRepository = eventCustomerNotificationRepository;
        }

        public void QueueFaxResultNotification(IEnumerable<EventCustomerResult> eventCustomerResult, string notificationTypeAlias)
        {
            var fileName = _mediaRepository.GetPdfFileNameForResultReport();

            var customerIds = eventCustomerResult.Select(x => x.CustomerId).ToArray();

            var pcpList = _pcpRepository.GetByCustomerIds(customerIds).Where(x => x.Fax != null && !string.IsNullOrEmpty(x.Fax.ToString()));

            foreach (var ecr in eventCustomerResult)
            {
                var messageAlreadySent = _eventCustomerNotificationRepository.GetByEventCustomerId(ecr.Id, notificationTypeAlias);
                if (messageAlreadySent != null)
                {
                    _logger.Info(string.Format("Fax already queued for EventId {0}, CustomerId {1} NotificationId {2} \n", ecr.EventId, ecr.CustomerId, messageAlreadySent.NotificationId));
                    continue;
                }

                var pdfUrl = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + fileName;

                if (File.Exists(pdfUrl))
                {
                    var pcp = pcpList.FirstOrDefault(x => x.CustomerId == ecr.CustomerId);

                    if (pcp == null)
                    {
                        _logger.Error(string.Format("PCP not found/or pcp Fax not found where customerId {0} \n", ecr.CustomerId));
                    }
                    else
                    {
                        try
                        {
                            PhoneNotificationModel model = null;
                            var notification = _notifier.NotifyViaFax(notificationTypeAlias, model, pcp.Fax, File.ReadAllBytes(pdfUrl), 1, "Faxing Notification");

                            if (notification != null)
                            {
                                var eventCustomerNotification = new EventCustomerNotification { EventCustomerId = ecr.Id, NotificationId = notification.Id, NotificationTypeId = notification.NotificationType.Id };
                                _eventCustomerNotificationRepository.Save(eventCustomerNotification);
                            }
                            _logger.Info(string.Format("Fax queued for EventId {0}, CustomerId {1}", ecr.EventId, ecr.CustomerId));
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(string.Format("Fax not queued for EventId {0}, CustomerId {1} \n StackTrace {2}", ecr.EventId, ecr.CustomerId, ex.StackTrace));
                        }

                    }
                }
                else
                {
                    _logger.Error(string.Format("Fax queue: File Not found for EventId {0}, CustomerId {1}", ecr.EventId, ecr.CustomerId));
                }
            }
        }
    }
}
