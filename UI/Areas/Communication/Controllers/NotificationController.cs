using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Communication.Controllers
{
    [RoleBasedAuthorize]
    public class NotificationController : Controller
    {
        private INotificationTypeRepository _notificationTypeRepository;
        private ISessionContext _sessionContext;
        private readonly ICustomerRepository _customerRepository;
        private readonly INotifier _notifier;
        private readonly IEventRepository _eventRepository;
        private readonly IPhoneNotificationModelsFactory _phoneNotificationModelsFactory;
        private readonly IEventCustomerNotificationRepository _eventCustomerNotificationRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEventService _eventService;
        private ILogger _logger;

        private int _defaultPageSize;

        public NotificationController(INotificationTypeRepository notificationTypeRepository, ILogManager logManager, ISessionContext sessionContext, ISettings settings, ICustomerRepository customerRepository, INotifier notifier,
            IEventRepository eventRepository, IPhoneNotificationModelsFactory phoneNotificationModelsFactory, IEventCustomerNotificationRepository eventCustomerNotificationRepository, IEventCustomerRepository eventCustomerRepository,
            IEmailTemplateRepository emailTemplateRepository, ICorporateAccountRepository corporateAccountRepository, IEventService eventService)
        {
            _notificationTypeRepository = notificationTypeRepository;
            _sessionContext = sessionContext;
            _customerRepository = customerRepository;
            _notifier = notifier;
            _eventRepository = eventRepository;
            _phoneNotificationModelsFactory = phoneNotificationModelsFactory;
            _eventCustomerNotificationRepository = eventCustomerNotificationRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _emailTemplateRepository = emailTemplateRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _eventService = eventService;
            _logger = logManager.GetLogger<Global>();
            _defaultPageSize = settings.DefaultPageSizeForReports;
        }

        public ActionResult Index(NotificationTypeListFilter filter = null, int pageNumber = 1)
        {
            if (filter == null) filter = new NotificationTypeListFilter();

            int totalRecords;

            var model = new NotificationTypeListModel
                {
                    Collection =
                        _notificationTypeRepository.GetbyFilter(filter, pageNumber, _defaultPageSize, out totalRecords),
                    Filter = filter
                };

            model.PagingModel = new PagingModel(pageNumber, _defaultPageSize, totalRecords, pn => Url.Action("Index", new { filter.Name, filter.IsQueuingEnabled, filter.IsServiceEnabled, pageNumber = pn }));

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateNotificationData(long id, bool serviceRunningStatus, bool queuingStatus, int numberOfAttempts)
        {
            try
            {
                _notificationTypeRepository.UpdateNotificationData(id, serviceRunningStatus, queuingStatus, numberOfAttempts, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                return Json(new { IsSuccess = true, Message = "Updated Notification Data.", Id = id });
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("While Updating Notification Type. Message: {0}. \n Stack Trace {1}", ex.Message, ex.StackTrace));
                return Json(new { IsSuccess = false, Message = "Some error occured, while processing your request. Message: " + ex.Message, Id = id });
            }
        }

        //[HttpPost]
        public JsonResult SendConfirmationSms(long eventId, long customerId)
        {

            var currentSession = _sessionContext.UserSession;
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            var customer = _customerRepository.GetCustomer(customerId);
            var message = string.Empty;

            if (customer.IsSubscribed == null || customer.IsSubscribed.Value == false)
            {
                _logger.Info("customer has not Subscribed for SMS customerId " + customer.CustomerId);

                message = "customer has not Subscribed for SMS";
                _logger.Info(message);

                return Json(new { message }, JsonRequestBehavior.AllowGet);
            }

            if (eventCustomer.EnableTexting)
            {
                var account = _corporateAccountRepository.GetbyEventId(eventId);
                if (account != null && !account.EnableSms)
                {
                    message = "SMS has been disabled for Corporate Account Tag: " + account.Tag;
                    _logger.Info(message);

                    return Json(new { message }, JsonRequestBehavior.AllowGet);
                }
                
                var messageAlreadySentList = _eventCustomerNotificationRepository.GetAllByEventCustomerId(eventCustomer.Id, NotificationTypeAlias.AppointmentConfirmation);
                var messageCount = (messageAlreadySentList != null && messageAlreadySentList.Any()) ? messageAlreadySentList.Count() : 0;

                if (account != null && messageCount >= account.MaximumSms)
                {
                    _logger.Info("Maximum SMS has Been Sent ");
                    _logger.Info(string.Format("Allowed SMS {0}, SMS Already Sent {0} " + account.MaximumSms, messageCount));
                    message = "Maximum SMS limit has been reached.";
                    return Json(new { message }, JsonRequestBehavior.AllowGet);
                }

                if (account == null && messageCount > 0)
                {
                    message = "Appointment confirmation SMS has already been sent.";
                    _logger.Info(message);
                    return Json(new { message }, JsonRequestBehavior.AllowGet);
                }

                var eventData = _eventRepository.GetById(eventId);
                var smsNotificaionModel = _phoneNotificationModelsFactory.GetScreeningReminderSmsNotificationModel(customer, eventData);

                var smsTemplateAlias = EmailTemplateAlias.AppointmentConfirmation;
                if (account != null && account.ConfirmationSmsTemplateId.HasValue && account.ConfirmationSmsTemplateId.Value > 0)
                {
                    var smsTemplate = _emailTemplateRepository.GetById(account.ConfirmationSmsTemplateId.Value);
                    smsTemplateAlias = smsTemplate.Alias;
                }
                var notification = _notifier.NotifyViaSms(NotificationTypeAlias.AppointmentConfirmation, smsTemplateAlias, smsNotificaionModel, customer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

                if (notification != null)
                {
                    var eventCustomerNotification = new EventCustomerNotification { EventCustomerId = eventCustomer.Id, NotificationId = notification.Id, NotificationTypeId = notification.NotificationType.Id };
                    _eventCustomerNotificationRepository.Save(eventCustomerNotification);
                }
                else
                {
                    message = "Queuing is disabled for Appointment Confirmation SMS.";
                    _logger.Info(message);
                    return Json(new { message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                message = "Customer has not opted for SMS";
                _logger.Info(message);
                return Json(new { message }, JsonRequestBehavior.AllowGet);
            }

            message = "Message Sent Successfully";
            return Json(new { message }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public JsonResult SendReminderSms(long eventId, long customerId)
        {
            var currentSession = _sessionContext.UserSession;
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            var customer = _customerRepository.GetCustomer(customerId);
            var message = string.Empty;

            if (customer.IsSubscribed == null || customer.IsSubscribed.Value == false)
            {
                _logger.Info("customer has not Subscribed for SMS customerId " + customer.CustomerId);

                message = "customer has not Subscribed for SMS";
                _logger.Info(message);

                return Json(new { message }, JsonRequestBehavior.AllowGet);
            }

            if (eventCustomer.EnableTexting)
            {
                var account = _corporateAccountRepository.GetbyEventId(eventId);
                if (account != null && !account.EnableSms)
                {
                    message = "SMS has been disabled for Corporate Account Tag: " + account.Tag;
                    _logger.Info(message);

                    return Json(new { message }, JsonRequestBehavior.AllowGet);
                }
                
                var messageAlreadySentList = _eventCustomerNotificationRepository.GetAllByEventCustomerId(eventCustomer.Id, NotificationTypeAlias.AppointmentReminder);
                var messageCount = (messageAlreadySentList != null && messageAlreadySentList.Any()) ? messageAlreadySentList.Count() : 0;

                if (account != null && messageCount >= account.MaximumSms)
                {
                    _logger.Info("Maximum SMS has been sent ");
                    _logger.Info(string.Format("Allowed SMS {0}, SMS Already Sent {0} " + account.MaximumSms, messageCount));
                    message = "Maximum SMS limit has been reached.";
                    return Json(new { message }, JsonRequestBehavior.AllowGet);
                }

                if (account == null && messageCount > 0)
                {
                    message = "Appointment reminder SMS has already been sent.";
                    _logger.Info(message);
                    return Json(new { message }, JsonRequestBehavior.AllowGet);
                }

                var eventData = _eventRepository.GetById(eventId);
                var smsNotificaionModel = _phoneNotificationModelsFactory.GetScreeningReminderSmsNotificationModel(customer, eventData);

                var smsTemplateAlias = EmailTemplateAlias.AppointmentReminder;
                if (account != null && account.ReminderSmsTemplateId.HasValue && account.ReminderSmsTemplateId.Value > 0)
                {
                    var smsTemplate = _emailTemplateRepository.GetById(account.ReminderSmsTemplateId.Value);
                    smsTemplateAlias = smsTemplate.Alias;
                }
                var notification = _notifier.NotifyViaSms(NotificationTypeAlias.AppointmentReminder, smsTemplateAlias, smsNotificaionModel, customer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

                if (notification != null)
                {
                    var eventCustomerNotification = new EventCustomerNotification { EventCustomerId = eventCustomer.Id, NotificationId = notification.Id, NotificationTypeId = notification.NotificationType.Id };
                    _eventCustomerNotificationRepository.Save(eventCustomerNotification);
                }
                else
                {
                    message = "Queuing is disabled for Appointment Reminder SMS.";
                    _logger.Info(message);
                    return Json(new { message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                message = "Customer has not opted for SMS";
                _logger.Info(message);
                return Json(new { message }, JsonRequestBehavior.AllowGet);
            }

            message = "Message Sent Successfully";
            return Json(new { message }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SendCustomEventSms(CustomEventNotificationEditModel model)
        {
            var message = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(model.Message))
                {
                    message = "Please enter a message.";
                    _logger.Info(message);
                    return Json(new { message, Success = 0 }, JsonRequestBehavior.AllowGet);
                }
                var account = _corporateAccountRepository.GetbyEventId(model.EventId);
                if (!account.EnableSms)
                {
                    message = "SMS has been disabled for Corporate Account Tag: " + account.Tag;
                    _logger.Info(message);
                    return Json(new { message, Success = 0 }, JsonRequestBehavior.AllowGet);
                }

                //var eventCustomerNotifications = _eventCustomerNotificationRepository.GetByEventId(model.EventId, NotificationTypeAlias.CustomEventSmsNotification);
                //var customers = 

                _eventService.SaveCustomEventNotification(model, account, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while saving Custom Message for Event : {0}. \nMessage : {1} \nStack Trace : {2}", model.EventId, ex.Message, ex.StackTrace));
                message = "Some error occurred while sending message.";
                return Json(new { message, Success = 0 }, JsonRequestBehavior.AllowGet);
            }

            message = "Message Sent Successfully";
            return Json(new { message, Success = 1 }, JsonRequestBehavior.AllowGet);
        }
    }
}
