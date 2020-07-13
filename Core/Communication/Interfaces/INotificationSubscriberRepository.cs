using System.Collections.Generic;
using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Communication.Interfaces
{
    public interface INotificationSubscriberRepository
    {
        IEnumerable<NotificationSubscriber> GetForNotificationType(long notificationTypeId);
    }
}