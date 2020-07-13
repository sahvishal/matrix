using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Communication.Impl
{
    [DefaultImplementation]
    public class Notifier : INotifier
    {
        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly INotificationSubscriberRepository _notificationSubscriberRepository;
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly IEmailTemplateFormatter _emailTemplateFormatter;
        private readonly INotificationRepository _notificationRepository;
        private readonly INotificationEmailFactory _notificationEmailFactory;
        private readonly ISettings _settings;
        private readonly IUserRepository<User> _userRepository;
        private readonly ICalendar _calendar;
        private readonly ITwilioMessagingService _twilioMessagingService;

        public Notifier(INotificationTypeRepository notificationTypeRepository,
            INotificationSubscriberRepository notificationSubscriberRepository,
            IEmailTemplateRepository emailTemplateRepository,
            IEmailTemplateFormatter emailTemplateFormatter,
            INotificationRepository notificationRepository,
            INotificationEmailFactory notificationEmailFactory,
            ISettings settings,
            IUserRepository<User> userRepository, ICalendar calendar, ITwilioMessagingService twilioMessagingService)
        {
            _notificationTypeRepository = notificationTypeRepository;
            _notificationSubscriberRepository = notificationSubscriberRepository;
            _emailTemplateRepository = emailTemplateRepository;
            _emailTemplateFormatter = emailTemplateFormatter;

            _notificationRepository = notificationRepository;
            _notificationEmailFactory = notificationEmailFactory;
            _settings = settings;
            _userRepository = userRepository;
            _calendar = calendar;
            _twilioMessagingService = twilioMessagingService;
        }


        public IEnumerable<Notification> NotifySubscribersViaEmail<T>(string notificationTypeAlias, string emailTemplateAlias, T model, long userId, long requestedBy,
            string source, string notes = null, int priority = 0, DateTime? notificationDate = null, bool useAlternateEmail = false)
        {
            NotificationType notificationType = _notificationTypeRepository.GetByAlias(notificationTypeAlias);

            if (!notificationType.IsQueuingEnabled)
                return null;

            EmailTemplate emailTemplate = _emailTemplateRepository.GetByAlias(emailTemplateAlias);

            List<NotificationSubscriber> notificationSubscribers = _notificationSubscriberRepository.GetForNotificationType(notificationType.Id).ToList();

            notificationSubscribers.Add(GetUserToNotify(userId));

            if (useAlternateEmail)
            {
                var subscriber = GetAlternateEamilToNotify(userId);
                if (subscriber != null)
                    notificationSubscribers.Add(subscriber);
            }


            Email fromEmail = _settings.EmailNotificationIssuedFrom;
            string fromName = _settings.NameNotificationissuedFrom;

            var notifications = new List<Notification>();

            foreach (var notificationSubscriber in notificationSubscribers)
            {
                EmailMessage formatMessage = _emailTemplateFormatter.FormatMessage(emailTemplate, model, notificationSubscriber.Email.ToString(), fromEmail.ToString(), fromName, emailTemplate.Id);
                NotificationEmail notificationEmail;
                if (notificationDate != null)
                    notificationEmail = _notificationEmailFactory.CreateNotificationEmail(notificationType, notificationSubscriber, fromEmail,
                        fromName, formatMessage, source, notes, priority, requestedBy, userId, notificationDate.Value);
                else
                {
                    notificationEmail = _notificationEmailFactory.CreateNotificationEmail(notificationType, notificationSubscriber, fromEmail,
                    fromName, formatMessage, source, notes, priority, requestedBy, userId);
                }

                Notification notification = _notificationRepository.Save(notificationEmail);
                notifications.Add(notification);
            }

            return notifications;
        }

        public IEnumerable<Notification> NotifySubscribersViaEmail<T>(string notificationTypeAlias, string emailTemplateAlias, T model, string[] subscriberEmails, long userId, long requestedBy, string source, string notes = null, int priority = 0, DateTime? notificationDate = null)
        {
            NotificationType notificationType = _notificationTypeRepository.GetByAlias(notificationTypeAlias);

            if (!notificationType.IsQueuingEnabled)
                return null;

            EmailTemplate emailTemplate = _emailTemplateRepository.GetByAlias(emailTemplateAlias);

            List<NotificationSubscriber> notificationSubscribers = _notificationSubscriberRepository.GetForNotificationType(notificationType.Id).ToList();

            notificationSubscribers.AddRange(GetEmailNotificationSubscribers(subscriberEmails, userId));

            Email fromEmail = _settings.EmailNotificationIssuedFrom;
            string fromName = _settings.NameNotificationissuedFrom;

            var notifications = new List<Notification>();

            foreach (var notificationSubscriber in notificationSubscribers)
            {
                EmailMessage formatMessage = _emailTemplateFormatter.FormatMessage(emailTemplate, model, notificationSubscriber.Email.ToString(), fromEmail.ToString(), fromName, emailTemplate.Id);

                NotificationEmail notificationEmail;
                if (notificationDate != null)
                    notificationEmail = _notificationEmailFactory.CreateNotificationEmail(notificationType, notificationSubscriber, fromEmail,
                    fromName, formatMessage, source, notes, priority, requestedBy, userId, notificationDate.Value);
                else
                    notificationEmail = _notificationEmailFactory.CreateNotificationEmail(notificationType,
                                                                                          notificationSubscriber,
                                                                                          fromEmail,
                                                                                          fromName, formatMessage,
                                                                                          source, notes, priority,
                                                                                          requestedBy, userId);

                Notification notification = _notificationRepository.Save(notificationEmail);
                notifications.Add(notification);
            }
            return notifications;
        }

        public Notification NotifyViaSms<T>(string notificationTypeAlias, string smsTemplateAlias, T model, long userId, long requestedBy, string source, string notes = null, int priority = 0, DateTime? notificationDate = null)
        {
            var notificationType = _notificationTypeRepository.GetByAlias(notificationTypeAlias);

            if (!notificationType.IsQueuingEnabled)
                return null;

            var emailTemplate = _emailTemplateRepository.GetByAlias(smsTemplateAlias);

            var notificationSubscriber = GetUserToNotify(userId);

            var formatMessage = _emailTemplateFormatter.FormatMessage(emailTemplate, model, emailTemplate.Id);

            var notificationSms = _notificationEmailFactory.CreateSmsNotification(notificationType, notificationSubscriber, formatMessage, source, userId, requestedBy);

            if (notificationDate != null)
                notificationSms.NotificationDate = notificationDate.Value;

            var notification = _notificationRepository.Save(notificationSms);

            return notification;
        }

        public Notification NotifyViaFax<T>(string notificationTypeAlias, T model, PhoneNumber faxPhoneNumber, byte[] message, long requestedBy, string source, string notes = null, int priority = 0, DateTime? notificationDate = null)
        {
            var notificationType = _notificationTypeRepository.GetByAlias(notificationTypeAlias);

            if (!notificationType.IsQueuingEnabled)
                return null;

            var notificationFax = _notificationEmailFactory.CreateFaxNotification(notificationType, faxPhoneNumber, message, source, requestedBy);

            if (notificationDate.HasValue)
                notificationFax.NotificationDate = notificationDate.Value;

            var notification = _notificationRepository.Save(notificationFax);
            return notification;
        }

        private NotificationSubscriber GetUserToNotify(long userId)
        {

            if (userId == 0)
            {
                return new NotificationSubscriber(userId)
                {
                    Email = new Email("JUNK765098@mailinator.com"),
                    Name = ""
                };
            }

            var userToBeNotified = _userRepository.GetUser(userId);

            return new NotificationSubscriber(userId)
            {
                Email = string.IsNullOrWhiteSpace(userToBeNotified.Email.ToString()) ? new Email("JUNK765098@mailinator.com") : userToBeNotified.Email,
                Name = userToBeNotified.Name.FullName,
                Phone = userToBeNotified.HomePhoneNumber,
                CellNumber = userToBeNotified.MobilePhoneNumber
            };
        }

        private IEnumerable<NotificationSubscriber> GetEmailNotificationSubscribers(string[] emails, long userId)
        {
            var subscribers = new NotificationSubscriber[emails.Length];
            int index = 0;
            foreach (var email in emails)
            {
                subscribers[index++] = new NotificationSubscriber(userId)
                {
                    Email = new Email(email)
                };
            }

            return subscribers;
        }

        public Notification NotifyCannedEmail(string notificationTypeAlias, Email fromEmail, string toEmail, string subjectText, string bodyText, long userId, long requestedBy, string source, string notes = null, int priority = 0, DateTime? notificationDate = null)
        {
            NotificationType notificationType = _notificationTypeRepository.GetByAlias(notificationTypeAlias);

            if (!notificationType.IsQueuingEnabled)
                return null;

            if (fromEmail == null || string.IsNullOrEmpty(fromEmail.ToString()))
                fromEmail = _settings.EmailNotificationIssuedFrom;

            string fromName = _settings.NameNotificationissuedFrom;

            var formatMessage = new EmailMessage
                {
                    Body = bodyText,
                    Subject = subjectText,
                    ToEmail = toEmail,
                    FromEmail = fromEmail.ToString(),
                    FromName = fromName
                };
            var notificationSubscriber = new NotificationSubscriber(userId)
                {
                    Email = new Email(toEmail),

                };
            var notificationEmail = _notificationEmailFactory.CreateNotificationEmail(notificationType, notificationSubscriber, fromEmail,
                    fromName, formatMessage, source, notes, priority, requestedBy, userId);

            var notification = _notificationRepository.Save(notificationEmail);
            return notification;
        }

        public Notification NotifyViaSmsImmediate<T>(string notificationTypeAlias, string smsTemplateAlias, T model, long userId,
            long requestedBy, string source, string notes = null, int priority = 0, DateTime? notificationDate = null,
            bool sendBeforeSavingToDb = false)
        {

            var notificationType = _notificationTypeRepository.GetByAlias(notificationTypeAlias);

            if (!notificationType.IsQueuingEnabled)
                return null;

            var emailTemplate = _emailTemplateRepository.GetByAlias(smsTemplateAlias);

            var notificationSubscriber = GetUserToNotify(userId);

            var formatMessage = _emailTemplateFormatter.FormatMessage(emailTemplate, model, emailTemplate.Id);

            var notificationSms = _notificationEmailFactory.CreateSmsNotification(notificationType,
                notificationSubscriber, formatMessage, source, userId, requestedBy);
            if (sendBeforeSavingToDb)
            {
                try
                {
                    var phoneNumber = Regex.Replace(notificationSubscriber.CellNumber.InternationalPhoneNumber,
                        @"\s+", "");
                    _twilioMessagingService.SendMessaging(phoneNumber, formatMessage.Body);
                    notificationSms.ServiceStatus = NotificationServiceStatus.Serviced;
                    notificationSms.AttemptCount = 1;
                    notificationSms.ServicedDate = _calendar.Now;
                }
                catch { }
            }
            if (notificationDate != null)
                notificationSms.NotificationDate = notificationDate.Value;

            var notification = _notificationRepository.Save(notificationSms);

            return notification;

        }

        private NotificationSubscriber GetAlternateEamilToNotify(long userId)
        {
            if (userId == 0)
                return null;

            var userToBeNotified = _userRepository.GetUser(userId);

            if (string.IsNullOrWhiteSpace(userToBeNotified.AlternateEmail.ToString()))
                return null;

            return new NotificationSubscriber(userId)
            {
                Email = string.IsNullOrWhiteSpace(userToBeNotified.AlternateEmail.ToString()) ? null : userToBeNotified.AlternateEmail,
                Name = userToBeNotified.Name.FullName,
                Phone = userToBeNotified.HomePhoneNumber,
                CellNumber = userToBeNotified.MobilePhoneNumber
            };
        }
    }
}