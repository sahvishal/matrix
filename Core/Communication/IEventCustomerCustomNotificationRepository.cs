using System.Collections.Generic;
using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Communication
{
    public interface IEventCustomerCustomNotificationRepository
    {
        IEnumerable<EventCustomerCustomNotification> GetByEventId(long eventId);
        bool Save(EventCustomerCustomNotification domain);
    }
}