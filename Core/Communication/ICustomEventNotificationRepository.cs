using System.Collections.Generic;
using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Communication
{
    public interface ICustomEventNotificationRepository
    {
        IEnumerable<CustomEventNotification> GetByEventId(long eventId);
        IEnumerable<CustomEventNotification> GetNotificationByStatus(long serviceStatus);
        bool SaveNotification(CustomEventNotification notification);
    }
}
