using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    [DefaultImplementation]
    public class EventPodRepository : PersistenceRepository, IEventPodRepository
    {
        public EventPod Save(EventPod domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from ep in linqMetaData.EventPod where ep.EventId == domain.EventId && ep.PodId == domain.PodId select ep).SingleOrDefault();
                if (entity != null)
                {
                    domain.DateCreated = entity.DateCreated;
                    domain.Id = entity.EventPodId;
                }

                entity = Mapper.Map<EventPod, EventPodEntity>(domain);
                adapter.SaveEntity(entity, true, false);
                return Mapper.Map<EventPodEntity, EventPod>(entity);
            }
        }

        public void Deactivate(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(new EventPodEntity { IsActive = false }, new RelationPredicateBucket(EventPodFields.EventId == eventId));
            }
        }

        public void DeactivateEventPod(long eventId, IEnumerable<long> podIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(EventPodFields.EventId == eventId);
                bucket.PredicateExpression.AddWithAnd(EventPodFields.PodId == podIds.ToArray());

                adapter.UpdateEntitiesDirectly(new EventPodEntity { IsActive = false }, bucket);
            }
        }

        public IEnumerable<EventPod> GetByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ep in linqMetaData.EventPod
                                where ep.EventId == eventId && ep.IsActive
                                select ep).ToArray();

                return Mapper.Map<IEnumerable<EventPodEntity>, IEnumerable<EventPod>>(entities);
            }
        }

        public EventPod GetByEventIdPodId(long eventId, long podId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from ep in linqMetaData.EventPod
                              where ep.EventId == eventId && ep.IsActive && ep.PodId == podId
                              select ep).SingleOrDefault();
                if (entity == null)
                    return null;

                return Mapper.Map<EventPodEntity, EventPod>(entity);
            }
        }

        public bool IsKynIntegrationEnabled(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var query = (from ep in linqMetaData.EventPod where ep.EventId == eventId && ep.IsActive && ep.EnableKynIntegration select ep);

                return query.Count() > 0;
            }
        }

        public bool IsBloodworkFormAttached(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var enabled = linqMetaData.EventPod.Any(x => x.EventId == eventId && x.IsActive && x.IsBloodworkFormAttached);

                return enabled;
            }
        }

        public IEnumerable<EventPod> GetByEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ep in linqMetaData.EventPod
                                where eventIds.Contains(ep.EventId) && ep.IsActive
                                select ep).ToArray();

                return Mapper.Map<IEnumerable<EventPodEntity>, IEnumerable<EventPod>>(entities);
            }
        }

        
    }
}
