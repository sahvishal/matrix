using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Communication.Repositories
{
    [DefaultImplementation(Interface = typeof(IEventNotificationRepository))]
    public class EventNotificationRepository : PersistenceRepository, IEventNotificationRepository
    {
        public EventNotification GetByEventId(long eventId, string notificationType)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from en in linqMetaData.EventNotification
                              join n in linqMetaData.Notification on en.NotificationId equals n.NotificationId
                              join nt in linqMetaData.NotificationType on n.NotificationTypeId equals nt.NotificationTypeId
                              where nt.NotificationTypeNameAlias == notificationType && en.EventId == eventId
                              select en).FirstOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map<EventNotificationEntity, EventNotification>(entity);
            }
        }

        public void Save(EventNotification eventNotification)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<EventNotification, EventNotificationEntity>(eventNotification);
                if (!adapter.SaveEntity(entity))
                    throw new PersistenceFailureException();
            }
        }

        public void SaveForCorporateAccount(EventNotification eventNotification)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var domain = GetByEventId(eventNotification.EventId, NotificationTypeAlias.EventResultReadyNotification);
                if (domain == null)
                {
                    Save(eventNotification);
                }
                else
                {
                    var bucket = new RelationPredicateBucket(EventNotificationFields.EventId == eventNotification.EventId);
                    bucket.PredicateExpression.AddWithAnd(EventNotificationFields.NotificationId == domain.NotificationId);
                    var entity = new EventNotificationEntity { IsForCorporateAccount = true };

                    if (adapter.UpdateEntitiesDirectly(entity, bucket) == 0)
                        throw new PersistenceFailureException("Could not Update Is for Corporate Account");
                }
            }
        }
    }
}
