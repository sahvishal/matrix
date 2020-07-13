using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Communication.Repositories
{
    [DefaultImplementation(Interface = typeof(IEventCustomerNotificationRepository))]
    public class EventCustomerNotificationRepository : PersistenceRepository, IEventCustomerNotificationRepository
    {
        public EventCustomerNotification GetByEventCustomerId(long eventCustomerId, string notificationType)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ecn in linqMetaData.EventCustomerNotification
                              join nt in linqMetaData.NotificationType on ecn.NotificationTypeId equals nt.NotificationTypeId
                              where nt.NotificationTypeNameAlias == notificationType && ecn.EventCustomerId == eventCustomerId
                              select ecn).FirstOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map<EventCustomerNotificationEntity, EventCustomerNotification>(entity);
            }
        }

        public void Save(EventCustomerNotification eventCustomerNotification)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<EventCustomerNotification, EventCustomerNotificationEntity>(eventCustomerNotification);
                if (!adapter.SaveEntity(entity))
                    throw new PersistenceFailureException();
            }
        }

        public IEnumerable<EventCustomerNotification> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds, string notificationType)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ecn in linqMetaData.EventCustomerNotification
                                join nt in linqMetaData.NotificationType on ecn.NotificationTypeId equals nt.NotificationTypeId
                                where nt.NotificationTypeNameAlias == notificationType && eventCustomerIds.Contains(ecn.EventCustomerId)
                                select ecn).ToArray();

                return Mapper.Map<IEnumerable<EventCustomerNotificationEntity>, IEnumerable<EventCustomerNotification>>(entities);
            }
        }

        public EventCustomerNotification GetById(long notificationId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ecn in linqMetaData.EventCustomerNotification
                              where ecn.NotificationId == notificationId
                              select ecn).FirstOrDefault();

                return entity == null
                    ? null
                    : Mapper.Map<EventCustomerNotificationEntity, EventCustomerNotification>(entity);
            }
        }

        public IEnumerable<EventCustomerNotification> GetAllByEventCustomerId(long eventCustomerId, string notificationType)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ecn in linqMetaData.EventCustomerNotification
                                join nt in linqMetaData.NotificationType on ecn.NotificationTypeId equals nt.NotificationTypeId
                                where nt.NotificationTypeNameAlias == notificationType && ecn.EventCustomerId == eventCustomerId
                                select ecn).ToArray();

                return Mapper.Map<IEnumerable<EventCustomerNotificationEntity>, IEnumerable<EventCustomerNotification>>(entities);
            }
        }

        public IEnumerable<EventCustomerNotification> GetByEventId(long eventId, string notificationType)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ecn in linqMetaData.EventCustomerNotification
                                join ec in linqMetaData.EventCustomers on ecn.EventCustomerId equals ec.EventCustomerId
                                join nt in linqMetaData.NotificationType on ecn.NotificationTypeId equals nt.NotificationTypeId
                                where ec.EventId == eventId
                                && nt.NotificationTypeNameAlias == notificationType
                                select ecn);

                return Mapper.Map<IEnumerable<EventCustomerNotificationEntity>, IEnumerable<EventCustomerNotification>>(entities);
            }
        }
    }
}
