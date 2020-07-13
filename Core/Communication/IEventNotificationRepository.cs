using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Communication
{
    public interface IEventNotificationRepository
    {
        EventNotification GetByEventId(long eventId, string notificationType);
        void Save(EventNotification eventNotification);
        void SaveForCorporateAccount(EventNotification eventNotification);
    }
}
