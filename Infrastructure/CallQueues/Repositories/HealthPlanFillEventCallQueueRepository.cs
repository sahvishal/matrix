using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class HealthPlanFillEventCallQueueRepository : PersistenceRepository, IHealthPlanFillEventCallQueueRepository
    {

        public HealthPlanFillEventCallQueue Save(HealthPlanFillEventCallQueue healthPlanFillEventCallQueue)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<HealthPlanFillEventCallQueue, HealthPlanFillEventCallQueueEntity>(healthPlanFillEventCallQueue);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<HealthPlanFillEventCallQueueEntity, HealthPlanFillEventCallQueue>(entity);
            }
        }

        public bool DeleteByCriteriaId(long criteriaId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(HealthPlanFillEventCallQueueFields.CriteriaId == criteriaId);
                if (adapter.DeleteEntitiesDirectly("HealthPlanFillEventCallQueueEntity", bucket) > 0)
                    return true;
                return false;
            }
        }

        public IEnumerable<HealthPlanFillEventCallQueue> GetByCriteriaId(long criteriaId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cq in linqMetaData.HealthPlanFillEventCallQueue where cq.CriteriaId == criteriaId select cq).ToArray();
                return Mapper.Map<IEnumerable<HealthPlanFillEventCallQueueEntity>, IEnumerable<HealthPlanFillEventCallQueue>>(entities);
            }
        }


        public IEnumerable<long> GetEventIdsByHealthPlanIds(long healthPlanId, long callqueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from fec in linqMetaData.HealthPlanFillEventCallQueue
                        join cqc in linqMetaData.HealthPlanCallQueueCriteria on fec.CriteriaId equals cqc.Id
                        join ea in linqMetaData.EventAccount on fec.EventId equals ea.EventId
                        where ea.AccountId == healthPlanId && cqc.CallQueueId == callqueueId
                        select fec.EventId).Distinct().ToArray();
            }
        }

        public void SaveEventZips(long eventId, long zipId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new EventZipEntity(eventId, zipId);

                if (!adapter.SaveEntity(entity))
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public void DeleteEventZipByEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(EventZipFields.EventId == eventIds.ToArray());
                adapter.DeleteEntitiesDirectly(typeof(EventZipEntity), bucket);
            }
        }

        public void DeleteEventZipByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(EventZipFields.EventId == eventId);
                adapter.DeleteEntitiesDirectly(typeof(EventZipEntity), bucket);
            }
        }

        public bool IsEventZipAlreadyGenerated(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ez in linqMetaData.EventZip
                                where ez.EventId == eventId
                                select ez.ZipId);

                return entities.Count() > 0;
            }
        }
    }
}