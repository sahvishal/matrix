using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Impl;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Communication.Impl
{
    [DefaultImplementation]
    public class PhysicianPartnerSendFaxPollingAgent : IPhysicianPartnerSendFaxPollingAgent
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly ICalendar _calendar;
        private readonly INotificationMediumRepository _notificationMediumRepository;
        private readonly IEFaxApi _eFaxApi;
        private readonly IEventCustomerNotificationRepository _eventCustomerNotificationRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IEventRepository _eventRepository;
        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly ILogger _logger;

        private int _runningThreadCount;
        private const string EfaxSucessStatus = "Success";
        private readonly string _emergencyFaxNumber;
        private readonly TimeSpan _timeIntervalToPingApi;
        private List<string> _listOfBadRecivers;
        private List<string> _keyLastRunning;
        private List<long> _listOfServicedNotifications;
        private bool _sendFaxToEmergencyFaxNumber;

        private TimeSpan _maximumWaitTime;


        public PhysicianPartnerSendFaxPollingAgent(INotificationRepository notificationRepository, ICalendar calendar, ILogManager logManager, INotificationMediumRepository notificationMediumRepository, IEFaxApi eFaxApi, IEventCustomerNotificationRepository eventCustomerNotificationRepository, IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository, IEmailNotificationModelsFactory emailNotificationModelsFactory, INotifier notifier, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, IEventRepository eventRepository, ISettings settings, INotificationTypeRepository notificationTypeRepository)
        {
            _notificationRepository = notificationRepository;
            _calendar = calendar;
            _notificationMediumRepository = notificationMediumRepository;
            _eFaxApi = eFaxApi;
            _eventCustomerNotificationRepository = eventCustomerNotificationRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _eventRepository = eventRepository;
            _notificationTypeRepository = notificationTypeRepository;

            _timeIntervalToPingApi = settings.TimeIntervalToPingApi;
            _emergencyFaxNumber = settings.EmergencyFaxNumber;
            _maximumWaitTime = settings.MaximumTimeToWaitApi;

            _logger = logManager.GetLogger<NotificationPollingAgent>();
        }

        public void PollForNotifications()
        {
            try
            {
                _sendFaxToEmergencyFaxNumber = false;
                ServiceFaxNotification();
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Exeception while sending Fax Message: {0} \n stack Trace : {1}", exception.Message, exception.StackTrace));
            }
        }

        private Dictionary<string, List<Notification>> CreateGroupByFaxNumber(IEnumerable<Notification> notifications)
        {
            if (!notifications.Any()) return null;

            var faxNumberList = notifications.Select(x => ((NotificationPhone)x).PhoneCell.ToString()).ToArray();
            var distictFaxNumber = faxNumberList.Distinct();

            var dictionary = new Dictionary<string, List<Notification>>();

            foreach (var number in distictFaxNumber)
            {
                dictionary.Add(number, notifications.Where(x => ((NotificationPhone)x).PhoneCell.ToString() == number).ToList());
            }

            return dictionary;
        }

        private void InitiateNewThread(Notification notification)
        {
            if (notification == null) return;
            _logger.Info(string.Format("Initiate Notification ID {0} New Thread Fax \n", notification.Id));

            (new Thread(ExecuteThread)).Start(notification);
        }

        private void AttemptToSendOnFax(IEnumerable<Notification> notifications)
        {
            _keyLastRunning = new List<string>();

            var groupedFax = CreateGroupByFaxNumber(notifications);

            var keys = groupedFax.Keys.Select(x => x);
            if (!groupedFax.Any()) return;
            _logger.Info("found Grouped Fax \n");

            while (true)
            {
                foreach (var key in keys)
                {
                    if (_keyLastRunning.Any(x => x == key))
                    {
                        _logger.Info(string.Format("some thead for key {0} is running", key));
                        continue;
                    }

                    _keyLastRunning.Add(key);

                    var list = groupedFax.First(x => x.Key == key).Value;
                    var notification = list.FirstOrDefault(x => !_listOfServicedNotifications.Contains(x.Id));

                    if (notification == null)
                    {
                        _logger.Info(string.Format("notifiation is Null"));
                        continue;
                    }
                    _logger.Info(string.Format("notificationId : {0} & Fax Number {1}", notification.Id, key));
                    InitiateNewThread(notification);
                }

                while (true)
                {
                    if (_runningThreadCount == 0)
                        break;
                    Thread.Sleep(_timeIntervalToPingApi);
                }

                _logger.Info("All Running thread in preivous Group has been completed.");

                keys = groupedFax.Keys.Where(x => !_listOfBadRecivers.Contains(x));

                if (!keys.Any()) break;

                _logger.Info(string.Format("Keys that not marked as bad Recivers {0} \n", string.Join(",", keys)));

                var listofNotificationNotMarkedAsBad = groupedFax.Where(x => keys.Contains(x.Key));

                var allServiced = listofNotificationNotMarkedAsBad.SelectMany(x => x.Value).Count(x => !_listOfServicedNotifications.Contains(x.Id));

                _logger.Info(string.Format("All serviced {0} \n", string.Join(",", _listOfServicedNotifications)));

                if (allServiced <= 0) break;
            }
        }

        private void AttemptToSendFaxOnBackupNumber(IEnumerable<Notification> notifications)
        {
            foreach (var notification in notifications)
            {
                ExecuteThread(notification);

                if (_listOfBadRecivers.Contains(_emergencyFaxNumber)) break;
            }
        }

        private void ServiceFaxNotification()
        {
            var notificationMediums = _notificationMediumRepository.GetAll().ToList();

            if (!notificationMediums.Any()) return;
            _sendFaxToEmergencyFaxNumber = false;

            var notificationType = _notificationTypeRepository.GetByAlias(NotificationTypeAlias.PhysicianPartnerCustomerResultFaxNotification);

            if (notificationType == null) return;

            var faxNotificationMedium = notificationMediums.First(x => x.Medium == NotificationMediumType.FaxNotification);

            var notifications = _notificationRepository.GetFaxNotificationByNotificationTypeId(faxNotificationMedium.Id, notificationType.Id);

            if (notifications == null || !notifications.Any()) return;

            _listOfServicedNotifications = new List<long>();
            _listOfBadRecivers = new List<string>();

            _logger.Info("attempteing to send on real fax number \n");

            AttemptToSendOnFax(notifications);

            _logger.Info("attempteing to send on real fax number-- completed\n");

            var isAnyBadReciver = _listOfBadRecivers.Any();

            _logger.Info(string.Format("defualter recivers for fax {0} \n", string.Join(",", _listOfBadRecivers)));

            if (isAnyBadReciver)
            {
                _sendFaxToEmergencyFaxNumber = true;

                var listOfPendingNotification = notifications.Where(x => !_listOfServicedNotifications.Contains(x.Id)).ToList();

                _logger.Info("attempteing to send on Emergency fax number \n");

                AttemptToSendFaxOnBackupNumber(listOfPendingNotification);

                _logger.Info("attempteing to send on Emergency fax number-completed \n");
            }

            isAnyBadReciver = _listOfBadRecivers.Contains(_emergencyFaxNumber);

            if (isAnyBadReciver)
            {
                var listOfPendingNotification = notifications.Where(x => !_listOfServicedNotifications.Contains(x.Id)).ToList();

                foreach (var notification in listOfPendingNotification)
                {
                    var lastMessage = notification.Notes ?? string.Empty;

                    notification.AttemptCount++;
                    notification.ServicedDate = _calendar.Now;
                    notification.ServiceStatus = NotificationServiceStatus.Failed;

                    _logger.Error(string.Format("All level of esclation has been met Notication Id {0} \n", notification.Id));
                    notification.Notes = string.Format("{0} marking as failed after attempt on emergency Number \n", lastMessage);

                    try
                    {
                        _notificationRepository.Save(notification);
                    }
                    catch (Exception exception)
                    {
                        _logger.Error("Could not update notification \n" + notification.Id, exception);
                    }
                }
            }
        }

        private void ExecuteThread(object sender)
        {
            var notification = (NotificationPhone)sender;
            _runningThreadCount++;

            var lastMessage = notification.Notes ?? string.Empty;

            try
            {
                var response = ServiceNotification(notification);

                switch (response.StatusCode)
                {
                    case EFaxStatusCode.Success:
                        var status = WaitForServiceToCompleteSending(notification);
                        _logger.Info(string.Format("waiting for service has done, api last status sent as {0}", status.Classification));

                        if (status.Classification.Contains(EfaxSucessStatus))
                        {
                            _listOfServicedNotifications.Add(notification.Id);
                            QueueNotificationToCustomerForResutlReady(notification);
                            notification.Notes = string.Format("{0} \nCalssfication-{1}\n", lastMessage, status.Classification);
                        }
                        else
                        {
                            _listOfBadRecivers.Add(_sendFaxToEmergencyFaxNumber ? _emergencyFaxNumber : notification.PhoneCell.ToString());
                            notification.Notes = string.Format("{0} \nCalssfication-{1}, Message- {2}, Outcome {3} \n", lastMessage, status.Classification, status.Message, status.Outcome);
                        }
                        notification.ServiceStatus = NotificationServiceStatus.Serviced;
                        break;

                    case EFaxStatusCode.Failur:
                        if (notification.AttemptCount >= notification.NotificationType.NumberOfAttempts)
                        {
                            notification.ServiceStatus = NotificationServiceStatus.Failed;
                        }
                        notification.Notes = string.Format("{0} \n Error Message for Failed Request Error Level-{1} \n Error-Message {2} \n", lastMessage, response.ErrorLevel, response.ErrorMessage);
                        _logger.Error(string.Format("EFax Error Level {0},\n EFax Error Discription {1} \n", response.ErrorLevel, response.ErrorMessage));
                        break;
                }
            }
            catch (Exception exception)
            {
                // TODO: log why we could not save it.
                if (notification.AttemptCount >= notification.NotificationType.NumberOfAttempts)
                {
                    notification.ServiceStatus = NotificationServiceStatus.Failed;
                }
                notification.Notes = string.Format("{0} \n exception Message-{1} \n Stack Trace {2} \n", lastMessage, exception.Message, exception.StackTrace);
                _logger.Error(string.Format("Failed to dispatch notification {0}  Message-{1} \n Stack Trace {2} \n", notification.Id, exception.Message, exception.StackTrace));
            }

            try
            {
                notification.AttemptCount++;
                notification.ServicedDate = _calendar.Now;
                _notificationRepository.Save(notification);
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Could not update notification {0}  Message-{1} \n Stack Trace {2} \n", notification.Id, exception.Message, exception.StackTrace));
            }
            finally
            {
                if (!_sendFaxToEmergencyFaxNumber)
                    _keyLastRunning.Remove(notification.PhoneCell.ToString());

                _runningThreadCount--;
            }
        }

        private EFaxOutboundResponsStatus WaitForServiceToCompleteSending(NotificationPhone notification)
        {
            var waitForServer = _timeIntervalToPingApi;

            EFaxOutboundResponsStatus status = null;
            _logger.Info(string.Format("Enter to get status from API for NotificationId {0}", notification.Id));

            while (waitForServer <= _maximumWaitTime)
            {
                Thread.Sleep(_timeIntervalToPingApi);
                _logger.Info(string.Format("waked Up for NotificationId {0} ", notification.Id));
                try
                {
                    status = _eFaxApi.GetOutboundStatusResponse(notification.Id);
                }
                catch (Exception exception)
                {
                    status = new EFaxOutboundResponsStatus { Classification = "Testing Time out for Notification", Message = "Testing Time out for Notification", Outcome = "Testing Time out for Notification" };
                    _logger.Error(string.Format("Message : {0} \n Stacktrace: {1} \n", exception.Message, exception.StackTrace));
                }
                if (status.Classification.Contains(EfaxSucessStatus))
                {
                    return status;
                }

                waitForServer += _timeIntervalToPingApi;
            }

            _logger.Info(string.Format("all attempt to get status positive fails for NotificationId {0} ", notification.Id));

            return status;
        }

        private void QueueNotificationToCustomerForResutlReady(NotificationPhone phoneNotification)
        {

            var eventCustomerNotification = _eventCustomerNotificationRepository.GetById(phoneNotification.Id);

            if (eventCustomerNotification == null)
            {
                _logger.Error(string.Format("No EventCustomer found for notification Id {0} \n", phoneNotification.Id));
                return;
            }

            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerNotification.EventCustomerId);
            var eventData = _eventRepository.GetById(eventCustomer.EventId);
            var customer = _customerRepository.GetCustomer(eventCustomer.CustomerId);

            if (eventData.NotifyResultReady)
            {
                var primaryCarePhysician = _primaryCarePhysicianRepository.Get(customer.CustomerId);

                if (primaryCarePhysician == null)
                {
                    _logger.Error("No primary Care Physician found \n");

                }
                var resultReadyNotification = _emailNotificationModelsFactory.GetPpCustomerResultNotificationModel(customer, primaryCarePhysician);

                _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.PhysicianPartnersCustomerResultReady, EmailTemplateAlias.PhysicianPartnersCustomerResultReady, resultReadyNotification, customer.Id, customer.CustomerId, "EFax System");
            }

        }

        private EFaxResponse ServiceNotification(NotificationPhone phone)
        {
            if (phone.PhoneCell == null || string.IsNullOrEmpty(phone.PhoneCell.ToString()))
            {
                _logger.Error(string.Format("Phone number can not be null or empty user id: {0} \n", phone.UserId));
                throw new Exception("Phone number can not be null or empty \n");
            }

            var eFaxParmaters = new EFaxParmaters
            {
                CustomerId = phone.RequestedBy.ToString(),
                IsHighPriority = false,
                Message = phone.Message,
                RecipientFax = _sendFaxToEmergencyFaxNumber ? _emergencyFaxNumber : phone.PhoneCell.ToString().Replace("-", ""),
                SendDuplicate = true,
                TransmissionId = phone.Id.ToString()
            };

            return _eFaxApi.SendCreateEFax(eFaxParmaters);
        }

    }
}



