using System;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Communication.Interfaces
{
    public interface INotificationEmailFactory
    {
        NotificationEmail CreateNotificationEmail(NotificationType notificationType, NotificationSubscriber notificationSubscriber, Email fromEmail, string fromName, EmailMessage formatMessage, string source, string notes, int priority, long requestedBy, long userId);

        NotificationEmail CreateNotificationEmail(NotificationType notificationType,
                                                  NotificationSubscriber notificationSubscriber, Email fromEmail,
                                                  string fromName, EmailMessage formatMessage, string source,
                                                  string notes, int priority, long requestedBy, long userId,
                                                  DateTime notificatonDate);

        NotificationPhone CreateSmsNotification(NotificationType notificationType, NotificationSubscriber notificationSubscriber, EmailMessage formatMessage, string source, long userId, long requestedBy);

        NotificationPhone CreateFaxNotification(NotificationType notificationType, PhoneNumber faxPhoneNumber, byte[] message, string source, long requestedBy);

        // Need to Use dateTimeCalendar
    }
}