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
    public class PriorityInQueueRepository : PersistenceRepository, IPriorityInQueueRepository
    {
        public PriorityInQueue GetByEventCustomerResultId(long eventCustomerResultId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.PriorityInQueue.SingleOrDefault(piq => piq.EventCustomerResultId == eventCustomerResultId && piq.IsActive);
                if (entity == null)
                    return null;

                return Mapper.Map<PriorityInQueueEntity, PriorityInQueue>(entity);

            }
        }

        public PriorityInQueue Save(PriorityInQueue domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<PriorityInQueue, PriorityInQueueEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException();
                return AutoMapper.Mapper.Map<PriorityInQueueEntity, PriorityInQueue>(entity);
            }
        }

        public long GetMaxPriorityInQueue()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var maxNumberInQueue = (from piq in linqMetaData.PriorityInQueue 
                                        select piq.InQueuePriority).Max();
                var max = maxNumberInQueue + 1;
                return max;
            }
        }

        public IEnumerable<PriorityInQueue> GetByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from piq in linqMetaData.PriorityInQueue
                                join ecr in linqMetaData.EventCustomerResult on piq.EventCustomerResultId equals ecr.EventCustomerResultId
                                where piq.IsActive && ecr.EventId == eventId && piq.IsActive
                                select piq);

                return Mapper.Map<IEnumerable<PriorityInQueueEntity>, IEnumerable<PriorityInQueue>>(entities);

            }
        }

        public IEnumerable<PriorityInQueue> GetByEventIds(IEnumerable<long> eventIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var piqs = (from piq in linqMetaData.PriorityInQueue
                            join ecr in linqMetaData.EventCustomerResult on piq.EventCustomerResultId equals ecr.EventCustomerResultId
                            where eventIds.Contains(ecr.EventId) && piq.IsActive
                            select piq).ToArray();



                if (piqs.IsEmpty())
                    return null;

                return Mapper.Map<IEnumerable<PriorityInQueueEntity>, IEnumerable<PriorityInQueue>>(piqs);
            }
        }

        public PriorityInQueue GetByEventIdCustomerId(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from piq in linqMetaData.PriorityInQueue
                                join ecr in linqMetaData.EventCustomerResult on piq.EventCustomerResultId equals
                                    ecr.EventCustomerResultId
                              where piq.IsActive && ecr.EventId == eventId && ecr.CustomerId == customerId
                                select piq).FirstOrDefault();
              
                if (entity == null)
                    return null;

                return Mapper.Map<PriorityInQueueEntity, PriorityInQueue>(entity);

            }
        }

    }
}
