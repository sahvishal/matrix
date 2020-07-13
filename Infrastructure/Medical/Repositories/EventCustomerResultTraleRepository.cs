using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class EventCustomerResultTraleRepository : PersistenceRepository, IEventCustomerResultTraleRepository
    {
        public void Save(EventCustomerResultTrale domainObject)
        {
            var entity = Mapper.Map<EventCustomerResultTrale, EventCustomerResultTraleEntity>(domainObject);

            if (domainObject == null) return;
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(entity))
                    throw new PersistenceFailureException();
            }
        }

        public EventCustomerResultTrale GetByEventCustomerResultId(long eventcusomerResultId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from ct in linqMetaData.EventCustomerResultTrale
                              where ct.EventCustomerResultId == eventcusomerResultId
                              select ct).SingleOrDefault();

                return entity == null ? null : Mapper.Map<EventCustomerResultTraleEntity, EventCustomerResultTrale>(entity);
            }
        }

        public List<EventCustomerResultTrale> GetByEventCustomerResultIds(IEnumerable<long> eventCustomerResultIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entites = (from ecrt in linqMetaData.EventCustomerResultTrale
                               where eventCustomerResultIds.Contains(ecrt.EventCustomerResultId)
                               select ecrt).ToList();

                return entites.IsNullOrEmpty() ? null : Mapper.Map<IEnumerable<EventCustomerResultTraleEntity>, IEnumerable<EventCustomerResultTrale>>(entites).ToList();
            }
        }
    }
}
