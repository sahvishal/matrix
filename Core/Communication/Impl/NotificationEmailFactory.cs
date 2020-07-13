using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Communication.Impl
{
    [DefaultImplementation]
    public class NotificationEmailFactory : INotificationEmailFactory
    {
        private readonly ICalendar _calendar;
        private readonly INotificationMediumRepository _notificationMediumRepository;
        //private readonly NotificationMedium _emailNotificationMedium;
        //private readonly NotificationMedium _smsNotificationMedium;
        //private readonly NotificationMedium _faxNotificationMedium;

        public NotificationEmailFactory(ICalendar calendar, INotificationMediumRepository notificationMediumRepository)
        {
            _calendar = calendar;
            _notificationMediumRepository = notificationMediumRepository;

            //var notificationMediumList = _notificationMediumRepository.GetAll();
            //_emailNotificationMedium = notificationMediumList.Single(s => s.Medium == NotificationMediumType.EmailNotification);
            //_smsNotificationMedium = notificationMediumList.Single(s => s.Medium == NotificationMediumType.SmsNotification);
            //_faxNotificationMedium = notificationMediumList.Single(s => s.Medium == NotificationMediumType.FaxNotification);
        }

        public NotificationEmail CreateNotificationEmail(NotificationType notificationType, NotificationSubscriber notificationSubscriber, Email fromEmail, string fromName, EmailMessage formatMessage, string source, string notes, int priority, long requestedBy, long userId)
        {
            var notificationMediumList = _notificationMediumRepository.GetAll();
            var emailNotificationMedium = notificationMediumList.Single(s => s.Medium == NotificationMediumType.EmailNotification);

            return new NotificationEmail
            {
                Body = formatMessage.Body,
                Subject = formatMessage.Subject,
                ToEmail = notificationSubscriber.Email,
                FromEmail = fromEmail,
                FromName = fromName,
                Source = source,
                Notes = notes,
                DateCreated = _calendar.Now,
                Priority = priority,
                ServiceStatus = NotificationServiceStatus.Unserviced,
                NotificationType = notificationType,
                NotificationMedium = emailNotificationMedium,
                RequestedBy = requestedBy,
                NotificationDate = _calendar.Now,
                UserId = userId
            };
        }


        public NotificationEmail CreateNotificationEmail(NotificationType notificationType, NotificationSubscriber notificationSubscriber, Email fromEmail, string fromName, EmailMessage formatMessage, string source, string notes, int priority, long requestedBy, long userId, DateTime notificatonDate) // Need to Use dateTimeCalendar
        {
            var notificationMediumList = _notificationMediumRepository.GetAll();
            var emailNotificationMedium = notificationMediumList.Single(s => s.Medium == NotificationMediumType.EmailNotification);

            return new NotificationEmail
            {
                Body = formatMessage.Body,
                Subject = formatMessage.Subject,
                ToEmail = notificationSubscriber.Email,
                FromEmail = fromEmail,
                FromName = fromName,
                Source = source,
                Notes = notes,
                DateCreated = _calendar.Now,
                Priority = priority,
                ServiceStatus = NotificationServiceStatus.Unserviced,
                NotificationType = notificationType,
                NotificationMedium = emailNotificationMedium,
                RequestedBy = requestedBy,
                NotificationDate = notificatonDate,
                UserId = userId
            };
        }

        public NotificationPhone CreateSmsNotification(NotificationType notificationType, NotificationSubscriber notificationSubscriber, EmailMessage formatMessage, string source, long userId, long requestedBy)
        {
            var notificationMediumList = _notificationMediumRepository.GetAll();
            var smsNotificationMedium = notificationMediumList.Single(s => s.Medium == NotificationMediumType.SmsNotification); 

            return new NotificationPhone
            {
                Message = formatMessage.Body,
                DateCreated = _calendar.Now,
                NotificationMedium = smsNotificationMedium,
                UserId = userId,
                Priority = 0,
                NotificationDate = _calendar.Now,
                NotificationType = notificationType,
                PhoneCell = notificationSubscriber.CellNumber,
                ServiceStatus = NotificationServiceStatus.Unserviced,
                RequestedBy = requestedBy,
                Source = source,
                Notes = source
            };
        }

        public NotificationPhone CreateFaxNotification(NotificationType notificationType, PhoneNumber faxPhoneNumber, byte[] message, string source, long requestedBy)
        {
            var notificationMediumList = _notificationMediumRepository.GetAll();
            var faxNotificationMedium = notificationMediumList.Single(s => s.Medium == NotificationMediumType.FaxNotification);

            return new NotificationPhone
            {
                Message = string.Join(",", message),
                DateCreated = _calendar.Now,
                NotificationMedium = faxNotificationMedium,
                UserId = 0,
                Priority = 0,
                NotificationDate = _calendar.Now,
                NotificationType = notificationType,
                PhoneCell = faxPhoneNumber,
                ServiceStatus = NotificationServiceStatus.Unserviced,
                RequestedBy = requestedBy,
                Source = source,
                Notes = source
            };
        }

    }
}