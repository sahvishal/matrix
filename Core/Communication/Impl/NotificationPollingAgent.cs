using System;
using System.Linq;
using System.Text.RegularExpressions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Interfaces;
using JetBrains.Annotations;

namespace Falcon.App.Core.Communication.Impl
{
    [DefaultImplementation]
    [UsedImplicitly]
    public class NotificationPollingAgent : INotificationPollingAgent
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly ICalendar _calendar;
        private readonly INotificationEmailSender _notificationEmailSender;
        private readonly ISettings _settings;
        private readonly ITwilioMessagingService _twilioMessagingService;
        private readonly INotificationMediumRepository _notificationMediumRepository;
        private readonly ILogger _logger;

        public NotificationPollingAgent(INotificationRepository notificationRepository, ICalendar calendar, INotificationEmailSender notificationEmailSender, ILogManager logManager, ISettings settings, ITwilioMessagingService twilioMessagingService, INotificationMediumRepository notificationMediumRepository)
        {
            _notificationRepository = notificationRepository;
            _calendar = calendar;
            _notificationEmailSender = notificationEmailSender;
            _settings = settings;
            _twilioMessagingService = twilioMessagingService;
            _notificationMediumRepository = notificationMediumRepository;
            _logger = logManager.GetLogger<NotificationPollingAgent>();
        }

        public void PollForNotifications()
        {
            try
            {
                ServiceEmailNotification();
            }
            catch (Exception ex)
            {
                _logger.Error("Exception:  " + ex.Message + " \n StackTrace: " + ex.StackTrace);
            }

        }

        private void ServiceEmailNotification()
        {
            var notificationMediums = _notificationMediumRepository.GetAll().ToList();
            if (!notificationMediums.Any()) return;

            var smsNotificationMedium = notificationMediums.FirstOrDefault(x => x.Medium == NotificationMediumType.SmsNotification);
            var emailNotificationMedium = notificationMediums.FirstOrDefault(x => x.Medium == NotificationMediumType.EmailNotification);
            var mediumIds = notificationMediums.Where(x => x.Medium == NotificationMediumType.SmsNotification || x.Medium == NotificationMediumType.EmailNotification).Select(x => x.Id).ToArray();

            var notifications = _notificationRepository.GetNotificationsToService(mediumIds);

            foreach (var notification in notifications)
            {
                if (!notification.NotificationType.IsServiceEnabled)
                {
                    _logger.Info("Notifications of type " + notification.NotificationType.NotificationTypeName + " is tunred off!");
                    continue;
                }

                notification.AttemptCount++;

                try
                {
                    dynamic dispatch = notification;

                    if (emailNotificationMedium != null && emailNotificationMedium.Id == notification.NotificationMedium.Id)
                    {
                        ServiceNotification(dispatch);

                    }
                    else if (smsNotificationMedium != null && smsNotificationMedium.Id == notification.NotificationMedium.Id)
                    {
                        ServiceNotification(dispatch);
                    }

                    notification.ServicedDate = _calendar.Now;
                    notification.ServiceStatus = NotificationServiceStatus.Serviced;

                }
                catch (Exception exception)
                {
                    // TODO: log why we could not save it.
                    if (notification.AttemptCount >= notification.NotificationType.NumberOfAttempts)
                    {
                        notification.ServiceStatus = NotificationServiceStatus.Failed;
                    }
                    _logger.Error("Failed to dispatch notification " + notification.Id, exception);
                }
                try
                {
                    _notificationRepository.Save(notification);
                }
                catch (Exception exception)
                {
                    _logger.Error("Could not update notification " + notification.Id, exception);
                }
            }
        }

        private void ServiceNotification(NotificationPhone phone)
        {
            if (phone.PhoneCell != null && !string.IsNullOrEmpty(phone.PhoneCell.ToString()))
            {
                var phoneNumber = Regex.Replace(phone.PhoneCell.InternationalPhoneNumber, @"\s+", "");
                _twilioMessagingService.SendMessaging(phoneNumber, phone.Message);
            }
            else
            {
                _logger.Error(string.Format("Phone number can not be null or empty user id: {0}", phone.UserId));
                throw new Exception("Phone number can not be null or empty");
            }

        }

        private void ServiceNotification(NotificationEmail notification)
        {
            EmailMessage message;
            try
            {
                message = new EmailMessage
                {
                    Body = notification.Body,
                    FromEmail = (notification.FromEmail ?? _settings.EmailNotificationIssuedFrom).ToString(),
                    FromName = notification.FromName,
                    Subject = notification.Subject,
                    ToEmail = notification.ToEmail.ToString()
                };
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Could not create message for notifcation {0} to {1}", notification.Id, notification.ToEmail), exception);
                throw;
            }

            try
            {
                _notificationEmailSender.SendEmail(message);
            }
            catch (Exception exception)
            {
                string errorMessage = string.Format("Could not send email for notification {0} to {1}", notification.Id, message.ToEmail);
                _logger.Error(errorMessage, exception);
                _logger.Error("Message: " + exception.Message);
                _logger.Error("StackTrace: " + exception.StackTrace);
                throw;
            }
        }

        private void ServiceNotification(Notification notification)
        {
            // TOOD: implement
        }
    }
}