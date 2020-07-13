using System.Collections.Generic;
using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Communication
{
    public interface IEventCustomerNotificationRepository
    {
        EventCustomerNotification GetByEventCustomerId(long eventCustomerId, string notificationType);
        void Save(EventCustomerNotification eventCustomerNotification);
        IEnumerable<EventCustomerNotification> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds, string notificationType);
        EventCustomerNotification GetById(long notificationId);
        IEnumerable<EventCustomerNotification> GetAllByEventCustomerId(long eventCustomerId, string notificationType);

        IEnumerable<EventCustomerNotification> GetByEventId(long eventId, string notificationType);
    }
}
