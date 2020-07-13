using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class CallQueueRepository : PersistenceRepository, ICallQueueRepository
    {
        public CallQueue GetById(long id)
        {
            try
            {
                var relationPredicateBucket = new RelationPredicateBucket(CallQueueFields.CallQueueId == id);
                //relationPredicateBucket.PredicateExpression.AddWithAnd(CallQueueFields.IsManual == isManual);
                return Get(relationPredicateBucket).Single();
            }
            catch (InvalidOperationException)
            {
                throw new ObjectNotFoundInPersistenceException<CallQueue>(id);
            }
        }

        public IEnumerable<CallQueue> GetByIds(IEnumerable<long> ids, bool isManual = true, bool isHealthPlan = false)
        {
            var relationPredicateBucket = new RelationPredicateBucket(CallQueueFields.CallQueueId == ids.ToArray());
            relationPredicateBucket.PredicateExpression.AddWithAnd(CallQueueFields.IsManual == isManual);
            relationPredicateBucket.PredicateExpression.AddWithAnd(CallQueueFields.IsHealthPlan == isHealthPlan);

            return Get(relationPredicateBucket);
        }

        public IEnumerable<CallQueue> GetAll(bool isManual = true, bool isHealthPlan = false)
        {
            var relationPredicateBucket = new RelationPredicateBucket(CallQueueFields.IsActive == true);
            relationPredicateBucket.PredicateExpression.AddWithAnd(CallQueueFields.IsManual == isManual);
            relationPredicateBucket.PredicateExpression.AddWithAnd(CallQueueFields.IsHealthPlan == isHealthPlan);
            return Get(relationPredicateBucket);
        }

        private IEnumerable<CallQueue> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<CallQueueEntity>();

                adapter.FetchEntityCollection(entities, expressionBucket);

                var callQueues = Mapper.Map<IEnumerable<CallQueueEntity>, IEnumerable<CallQueue>>(entities);

                return callQueues.OrderBy(t => t.Name).ToArray();
            }
        }

        public CallQueue Save(CallQueue callQueue)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CallQueue, CallQueueEntity>(callQueue);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<CallQueueEntity, CallQueue>(entity);
            }
        }

        public IEnumerable<CallQueue> GetCallQueueList(CallQueueListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    totalRecords = linqMetaData.CallQueue.Count(cq => cq.IsManual && cq.IsHealthPlan == false);
                    var entities = linqMetaData.CallQueue.Where(cq => cq.IsManual && cq.IsHealthPlan == false).OrderByDescending(p => p.IsActive).ThenBy(p => p.Name).TakePage(pageNumber, pageSize).ToArray();

                    return Mapper.Map<IEnumerable<CallQueueEntity>, IEnumerable<CallQueue>>(entities);
                }
                else
                {
                    var query = from cq in linqMetaData.CallQueue where cq.IsManual && cq.IsHealthPlan == false select cq;

                    if (!string.IsNullOrEmpty(filter.Name))
                        query = from cq in query where cq.Name.Contains(filter.Name) select cq;

                    if (filter.CriteriaId > 0)
                    {
                        var callQueueIds = (from cqc in linqMetaData.CallQueueCriteria where cqc.CriteriaId == filter.CriteriaId select cqc.CallQueueId);
                        query = from cq in query where callQueueIds.Contains(cq.CallQueueId) select cq;
                    }

                    totalRecords = query.Count();
                    var entities = query.OrderByDescending(p => p.IsActive).ThenBy(p => p.Name).TakePage(pageNumber, pageSize).ToArray();

                    return Mapper.Map<IEnumerable<CallQueueEntity>, IEnumerable<CallQueue>>(entities);
                }
            }
        }

        public IEnumerable<CallQueue> GetByAssignedToOrgRoleUserId(long assignedToOrgRoleUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cq in linqMetaData.CallQueue
                                join cqa in linqMetaData.CallQueueAssignment on cq.CallQueueId equals cqa.CallQueueId
                                where cqa.AssignedOrgRoleUserId == assignedToOrgRoleUserId
                                && cq.IsActive
                                && cq.IsManual
                                orderby cq.Name
                                select cq);
                return Mapper.Map<IEnumerable<CallQueueEntity>, IEnumerable<CallQueue>>(entities);

            }
        }

        public void SetCallQueueIsActiveState(long callQueueId, bool isActive)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(new CallQueueEntity { IsActive = isActive }, new RelationPredicateBucket(CallQueueFields.CallQueueId == callQueueId));
            }
        }

        public CallQueue GetCallQueueByCategory(string category)
        {
            var relationPredicateBucket = new RelationPredicateBucket(CallQueueFields.Category == category);
            return Get(relationPredicateBucket).SingleOrDefault();
        }

        public void SetCallQueueIsGenerated(long callQueueId, bool isQueueGenerated)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(new CallQueueEntity { IsQueueGenerated = isQueueGenerated }, new RelationPredicateBucket(CallQueueFields.CallQueueId == callQueueId));
            }
        }

    }
}