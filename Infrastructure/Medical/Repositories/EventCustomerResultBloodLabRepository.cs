using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class EventCustomerResultBloodLabRepository : PersistenceRepository, IEventCustomerResultBloodLabRepository
    {
        public EventCustomerResultBloodLab GetByEventCustomerResultId(long eventCustomerResultId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ecrbl in linqMetaData.EventCustomerResultBloodLab
                              where ecrbl.EventCustomerResultId == eventCustomerResultId
                              && ecrbl.IsActive
                              select ecrbl).SingleOrDefault();

                if (entity == null)
                    return null;
                return Mapper.Map<EventCustomerResultBloodLabEntity, EventCustomerResultBloodLab>(entity);
            }
        }

        public EventCustomerResultBloodLab GetByEventIdAndCustomerId(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ecrbl in linqMetaData.EventCustomerResultBloodLab
                              join ecr in linqMetaData.EventCustomerResult on ecrbl.EventCustomerResultId equals ecr.EventCustomerResultId
                              where ecr.EventId == eventId && ecr.CustomerId == customerId
                              && ecrbl.IsActive
                              select ecrbl).SingleOrDefault();

                if (entity == null)
                    return null;
                return Mapper.Map<EventCustomerResultBloodLabEntity, EventCustomerResultBloodLab>(entity);
            }
        }

        public EventCustomerResultBloodLab Save(EventCustomerResultBloodLab domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from ecrbl in linqMetaData.EventCustomerResultBloodLab where ecrbl.EventCustomerResultId == domain.EventCustomerResultId select ecrbl).SingleOrDefault();
                if (entity == null || !entity.IsActive)
                {
                    var isNew = (entity == null);
                    entity = Mapper.Map<EventCustomerResultBloodLab, EventCustomerResultBloodLabEntity>(domain);
                    entity.IsNew = isNew;

                    adapter.SaveEntity(entity, true, false);

                    return Mapper.Map<EventCustomerResultBloodLabEntity, EventCustomerResultBloodLab>(entity);
                }

                return domain;
            }
        }
    }
}
