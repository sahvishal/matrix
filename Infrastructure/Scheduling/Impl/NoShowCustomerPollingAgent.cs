using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class NoShowCustomerPollingAgent : INoShowCustomerPollingAgent
    {
        private readonly ISmsHelper _smsHelper;
        private readonly IEventRepository _eventRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly ILogger _logger;
        private readonly int _minutesAfterAppointmentTime;
        private readonly int _noShowCustomerScheduleInterval;
        public NoShowCustomerPollingAgent(ILogManager logManager, ISettings settings, IEventCustomerRepository eventCustomerRepository, IAppointmentRepository appointmentRepository, IEmailNotificationModelsFactory emailNotificationModelsFactory,
            INotifier notifier, IEventRepository eventRepository, ISmsHelper smsHelper)
        {
            _eventRepository = eventRepository;
            _smsHelper = smsHelper;
            _eventCustomerRepository = eventCustomerRepository;
            _appointmentRepository = appointmentRepository;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
            _logger = logManager.GetLogger<NoShowCustomerPollingAgent>();
            _minutesAfterAppointmentTime = settings.MinutesAfterAppointmentTime;
            _noShowCustomerScheduleInterval = settings.NoShowCustomerScheduleInterval;
        }

        public void PollForCustomerDoesNotAppearOnEvent()
        {
            try
            {
                var todayDate = DateTime.Now.Date;
                var eventList = _eventRepository.GetEventsToSendSms(todayDate, todayDate);
                if (eventList.IsNullOrEmpty())
                {
                    _logger.Info("No Show Customer Notification:No event found for Date " + todayDate.ToShortDateString());
                    return;
                }

                foreach (var eventData in eventList)
                {
                    var clientTime = _smsHelper.ConvertLocalTimeToCompleteClientTime(DateTime.Now, eventData.TimeZone);

                    _logger.Info(string.Format("No Show Customer Notification:Time at timezone {0} is {1} on Event Id: {2}", eventData.TimeZone, clientTime, eventData.Id));

                    var eventCustomers = _eventCustomerRepository.GetEventCustomersDoesNotAppearOnEvent(eventData.Id, clientTime, _minutesAfterAppointmentTime, _noShowCustomerScheduleInterval);

                    if (eventCustomers.IsNullOrEmpty())
                    {
                        _logger.Info("No Show Customer Notification:No Customer Appointment found for time " + clientTime);
                        continue;
                    }

                    var appointmentIds = eventCustomers.Where(x => x.AppointmentId.HasValue).Select(x => x.AppointmentId.Value).ToArray();
                    var appointments = _appointmentRepository.GetByIds(appointmentIds);

                    foreach (var eventCustomer in eventCustomers)
                    {
                        var appointment = appointments.First(a => a.Id == eventCustomer.AppointmentId.Value);
                        var noShowCustomerNotificationModel = _emailNotificationModelsFactory.GetNoShowCustomerNotificationViewModel(eventCustomer, appointment);

                        _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.NoShowCustomer, EmailTemplateAlias.NoShowCustomer, noShowCustomerNotificationModel, 0, 1, "System: Customer not appeared at event - No Show Customer");

                        _logger.Info("No Show Customer Notification:Mail Send for Event Id " + eventCustomer.EventId + " Customer Id:  " + eventCustomer.CustomerId + " For Appointment Start Time is: " + appointment.StartTime);
                    }
                }

            }
            catch (Exception exception)
            {
                _logger.Error("No Show Customer Notification:Some Error Occurred Message: " + exception.Message + "\n Stack Trace: " + exception.StackTrace);
            }
        }
    }
}