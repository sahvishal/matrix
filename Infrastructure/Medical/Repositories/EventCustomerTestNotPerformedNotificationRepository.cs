using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    public class EventCustomerTestNotPerformedNotificationRepository : PersistenceRepository, IEventCustomerTestNotPerformedNotificationRepository
    {
        public EventCustomerTestNotPerformedNotification Save(EventCustomerTestNotPerformedNotification domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<EventCustomerTestNotPerformedNotification, EventCustomerTestNotPerformedNotificationEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                return Mapper.Map<EventCustomerTestNotPerformedNotificationEntity, EventCustomerTestNotPerformedNotification>(entity);
            }
        }

        public IEnumerable<EventCustomerTestNotPerformedNotification> GetbyEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ectnpn in linqMetaData.EventCustomerTestNotPerformedNotification
                                where ectnpn.EventCustomerId == eventCustomerId
                                select ectnpn).ToArray();
                return Mapper.Map<IEnumerable<EventCustomerTestNotPerformedNotificationEntity>, IEnumerable<EventCustomerTestNotPerformedNotification>>(entities);
            }
        }

        public void SaveAll(IEnumerable<EventCustomerTestNotPerformedNotification> domainList)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = Mapper.Map<IEnumerable<EventCustomerTestNotPerformedNotification>, IEnumerable<EventCustomerTestNotPerformedNotificationEntity>>(domainList);

                var collection = new EntityCollection<EventCustomerTestNotPerformedNotificationEntity>();
                collection.AddRange(entities);

                if (adapter.SaveEntityCollection(collection) == 0)
                    throw new PersistenceFailureException();
            }
        }
    }
}
