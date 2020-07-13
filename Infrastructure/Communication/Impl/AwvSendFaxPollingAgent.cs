using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Communication.Impl
{
    public class AwvSendFaxPollingAgent
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly INotificationMediumRepository _notificationMediumRepository;
        private readonly IEventCustomerNotificationRepository _eventCustomerNotificationRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ISettings _settings;
        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly IEFaxHelperService _eFaxHealperService;
        private readonly ILogger _logger;



        public AwvSendFaxPollingAgent(INotificationRepository notificationRepository,
            ILogManager logManager, INotificationMediumRepository notificationMediumRepository, //IEFaxApi eFaxApi,
            IEventCustomerNotificationRepository eventCustomerNotificationRepository,
            IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository,
            IEmailNotificationModelsFactory emailNotificationModelsFactory, INotifier notifier,
            IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, IEventRepository eventRepository,
            ISettings settings, INotificationTypeRepository notificationTypeRepository, IEFaxHelperService eFaxHealperService)
        {
            _notificationRepository = notificationRepository;
            _notificationMediumRepository = notificationMediumRepository;
            _eventCustomerNotificationRepository = eventCustomerNotificationRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _eventRepository = eventRepository;
            _settings = settings;
            _notificationTypeRepository = notificationTypeRepository;
            _eFaxHealperService = eFaxHealperService;
            _logger = logManager.GetLogger<AwvSendFaxPollingAgent>();
        }

        public AwvSendFaxPollingAgent()
        {

        }

        private void ServiceFaxNotification()
        {
            var notificationMediums = _notificationMediumRepository.GetAll().ToList();

            if (!notificationMediums.Any()) return;

            var notificationType = _notificationTypeRepository.GetByAlias(NotificationTypeAlias.AwvCustomerResultFaxNotification);

            if (notificationType == null) return;

            var faxNotificationMedium = notificationMediums.First(x => x.Medium == NotificationMediumType.FaxNotification);

            var notifications = _notificationRepository.GetFaxNotificationByNotificationTypeId(faxNotificationMedium.Id, notificationType.Id);

            if (notifications == null || !notifications.Any()) return;



        }



    }

    class EFaxNotificationService
    {
        private readonly IEFaxHelperService _eFaxHealperService;
        private readonly INotificationRepository _notificationRepository;
        private int _runningThreadCount;
        private List<string> _listOfBadRecivers;
        private List<long> _listOfServicedNotifications;

        private List<string> _completedFaxNumber;
        private List<string> _keyLastRunning;

        private readonly ILogger _logger;
        private readonly TimeSpan _timeIntervalToPingApi;
        private const string EfaxSucessStatus = "Success";
        private readonly string _emergencyFaxNumber;
        private bool _isPpCustomer;


        public EFaxNotificationService(ILogManager logManager, IEFaxHelperService eFaxHealperService, INotificationRepository notificationRepository, ISettings settings)
        {
            _eFaxHealperService = eFaxHealperService;
            _notificationRepository = notificationRepository;
            _emergencyFaxNumber = settings.EmergencyFaxNumber;
            _timeIntervalToPingApi = settings.TimeIntervalToPingApi;
            _logger = logManager.GetLogger<EFaxNotificationService>();
        }

        public void StartSendingNotificaton(IEnumerable<Notification> notifications, string notificationTypeAlias)
        {
            _listOfServicedNotifications = new List<long>();
            _listOfBadRecivers = new List<string>();

            _isPpCustomer = notificationTypeAlias == NotificationTypeAlias.PhysicianPartnerCustomerResultFaxNotification;

            if (_isPpCustomer)
                _listOfBadRecivers.Add(_emergencyFaxNumber);

            AttemptToSendOnFax(notifications);

            var listOfPendingNotification = notifications.Where(x => !_listOfServicedNotifications.Contains(x.Id)).ToList();

            if (listOfPendingNotification.Any())
            {
                MarkNotificationFailed(listOfPendingNotification);
            }
        }

        private void MarkNotificationFailed(IEnumerable<Notification> listOfPendingNotification)
        {
            foreach (var notification in listOfPendingNotification)
            {
                var lastMessage = notification.Notes ?? string.Empty;

                notification.AttemptCount++;
                notification.ServicedDate = System.DateTime.Now;
                notification.ServiceStatus = NotificationServiceStatus.Failed;

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

        private void InitiateNewThread(Notification notification)
        {
            if (notification == null) return;

            (new Thread(ExecuteThread)).Start(notification);
        }

        private string SendNoitificatoinonFaxNumber(NotificationPhone phoneNotification)
        {
            var faxNumber = phoneNotification.PhoneCell.ToString();
            if (_listOfBadRecivers.Contains(faxNumber))
                faxNumber = _emergencyFaxNumber;

            return faxNumber;
        }

        private void ExecuteThread(object sender)
        {
            var notification = (NotificationPhone)sender;
            _runningThreadCount++;

            var lastMessage = notification.Notes ?? string.Empty;
            var serviceNumber = SendNoitificatoinonFaxNumber(notification);

            try
            {
                var response = _eFaxHealperService.ServiceNotification(notification, serviceNumber);

                switch (response.StatusCode)
                {
                    case EFaxStatusCode.Success:
                        var status = _eFaxHealperService.WaitForServiceToCompleteSending(notification);

                        if (status.Classification.Contains(EfaxSucessStatus))
                        {
                            _listOfServicedNotifications.Add(notification.Id);
                            if (_isPpCustomer)
                            {
                                QueueNotificationToCustomerForResutlReady(notification);
                            }

                            notification.Notes = string.Format("{0} \nCalssfication-{1}\n", lastMessage, status.Classification);
                        }
                        else
                        {
                            _listOfBadRecivers.Add(serviceNumber);
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

            }

            try
            {
                notification.AttemptCount++;
                notification.ServicedDate = System.DateTime.Now;
                _notificationRepository.Save(notification);
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Could not update notification {0}  Message-{1} \n Stack Trace {2} \n", notification.Id, exception.Message, exception.StackTrace));
            }
            finally
            {
                _keyLastRunning.Remove(serviceNumber);
                _runningThreadCount--;
            }
        }


        private void AttemptToSendOnFax(IEnumerable<Notification> notifications)
        {
            _keyLastRunning = new List<string>();
            _completedFaxNumber = new List<string>();

            var groupedFax = _eFaxHealperService.CreateGroupByFaxNumber(notifications);

            var keys = groupedFax.Keys.Select(x => x);

            if (!groupedFax.Any()) return;

            _logger.Info("found Grouped Fax \n");

            while (true)
            {
                while (_runningThreadCount >= 5)
                {
                    if (_runningThreadCount < 5)
                        break;
                    Thread.Sleep(_timeIntervalToPingApi);
                }

                if (_listOfBadRecivers.Any() && !_keyLastRunning.Contains(_emergencyFaxNumber) && !_listOfBadRecivers.Contains(_emergencyFaxNumber))
                {
                    var notificationNotServiced = notifications.Where(x => !_listOfServicedNotifications.Contains(x.Id) && _listOfBadRecivers.Contains(((NotificationPhone)x).PhoneCell.ToString()));

                    groupedFax.Remove(_emergencyFaxNumber);

                    groupedFax.Add(_emergencyFaxNumber, notificationNotServiced.ToList());
                }

                var key = keys.FirstOrDefault(f => !_listOfBadRecivers.Contains(f) && !_keyLastRunning.Contains(f) && !_completedFaxNumber.Contains(f));

                if (!string.IsNullOrEmpty(key))
                {
                    if (string.IsNullOrEmpty(key) && !_keyLastRunning.Any()) break;

                    var list = groupedFax.First(x => x.Key == key).Value;

                    var notification = list.FirstOrDefault(x => !_listOfServicedNotifications.Contains(x.Id));

                    if (notification == null)
                    {
                        _logger.Info(string.Format("notifiation is Null for Key {0}", key));
                        _completedFaxNumber.Add(key);
                    }
                    else
                    {
                        _logger.Info(string.Format("notificationId : {0} & Fax Number {1}", notification.Id, key));

                        InitiateNewThread(notification);

                        _keyLastRunning.Add(key);
                    }
                }

                var pendinglist = groupedFax.Where(x => !_listOfBadRecivers.Contains(x.Key)).SelectMany(x => x.Value).ToList();
                pendinglist = pendinglist.Where(x => !_listOfServicedNotifications.Contains(x.Id)).ToList();

                if (!pendinglist.Any()) break;

                keys = groupedFax.Keys.Where(x => !_listOfBadRecivers.Contains(x) && !_completedFaxNumber.Contains(x)).ToList();

                if (!keys.Any()) break;

            }
        }

        private void QueueNotificationToCustomerForResutlReady(NotificationPhone phoneNotification)
        {

            //var eventCustomerNotification = _eventCustomerNotificationRepository.GetById(phoneNotification.Id);

            //if (eventCustomerNotification == null)
            //{
            //    _logger.Error(string.Format("No EventCustomer found for notification Id {0} \n", phoneNotification.Id));
            //    return;
            //}

            //var eventCustomer = _eventCustomerRepository.GetById(eventCustomerNotification.EventCustomerId);
            //var eventData = _eventRepository.GetById(eventCustomer.EventId);
            //var customer = _customerRepository.GetCustomer(eventCustomer.CustomerId);

            //if (eventData.NotifyResultReady)
            //{
            //    var primaryCarePhysician = _primaryCarePhysicianRepository.Get(customer.CustomerId);

            //    if (primaryCarePhysician == null)
            //    {
            //        _logger.Error("No primary Care Physician found \n");

            //    }
            //    var resultReadyNotification = _emailNotificationModelsFactory.GetPpCustomerResultNotificationModel(customer, primaryCarePhysician);

            //    _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.PhysicianPartnersCustomerResultReady, EmailTemplateAlias.PhysicianPartnersCustomerResultReady, resultReadyNotification, customer.Id, customer.CustomerId, "EFax System");
            //}

        }
    }

}
