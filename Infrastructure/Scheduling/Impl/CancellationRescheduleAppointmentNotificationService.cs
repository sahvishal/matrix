using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class CancellationRescheduleAppointmentNotificationService : ICancellationRescheduleAppointmentNotificationService
    {
        private readonly IEventRepository _eventRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly int _sendCancelRescheduleNotificationBeforeDays;
        public CancellationRescheduleAppointmentNotificationService(IEventRepository eventRepository, ICustomerRepository customerRepository, IEmailNotificationModelsFactory emailNotificationModelsFactory, INotifier notifier, ISettings settings)
        {
            _eventRepository = eventRepository;
            _customerRepository = customerRepository;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
            _sendCancelRescheduleNotificationBeforeDays = settings.SendCancelRescheduleNotificationBeforeDays;
        }

        public void SendCancellationRescheduleAppointmentMail(bool isCancelAppointment, long customerId, long eventId, long newEventId, string reason, long orgRoleId, string source, string subReason)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            var eventData = _eventRepository.GetById(eventId);

            if (eventData.EventDate.Date == DateTime.Today.AddDays(_sendCancelRescheduleNotificationBeforeDays))
            {
                DateTime? newEventDate = null;

                if (!isCancelAppointment)
                {
                    var newEventData = _eventRepository.GetById(newEventId);
                    newEventDate = newEventData.EventDate;
                }

                var model = _emailNotificationModelsFactory.GetCancelRescheduleAppointmentNotificationViewModel(customer.NameAsString, eventId, newEventId, newEventDate, isCancelAppointment, reason, subReason);

                _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CancelRescheduleAppointmentNotification, EmailTemplateAlias.CancelRescheduleAppointmentNotification, model, 0, orgRoleId, source);
            }
        }
    }
}
