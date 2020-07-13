using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Communication.Impl
{

    [DefaultImplementation]
    public class EventCustomerCustomNotificationRepository : PersistenceRepository, IEventCustomerCustomNotificationRepository
    {
        public IEnumerable<EventCustomerCustomNotification> GetByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var enetities = (from cen in linqMetaData.EventCustomerCustomNotification
                                 join ec in linqMetaData.EventCustomers on cen.EventCustomerId equals ec.EventCustomerId
                                 where ec.EventId == eventId
                                 select cen);

                return Mapper.Map<IEnumerable<EventCustomerCustomNotificationEntity>, IEnumerable<EventCustomerCustomNotification>>(enetities);
            }
        }

        public bool Save(EventCustomerCustomNotification domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<EventCustomerCustomNotification, EventCustomerCustomNotificationEntity>(domain);

                adapter.SaveEntity(entity, true);
            }
            return true;
        }
    }
}