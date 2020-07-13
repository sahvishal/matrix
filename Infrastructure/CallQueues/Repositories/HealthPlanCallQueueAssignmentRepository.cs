using System.Collections;
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
using System.Collections.Generic;
using System.Transactions;
using Falcon.App.Core;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class HealthPlanCallQueueAssignmentRepository : PersistenceRepository, IHealthPlanCallQueueAssignmentRepository
    {
        public bool DeleteByCriteriaId(long criteriaId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(HealthPlanCallQueueCriteriaAssignmentFields.CriteriaId == criteriaId);
                if (adapter.DeleteEntitiesDirectly("HealthPlanCallQueueCriteriaAssignmentEntity", bucket) > 0)
                    return true;
                return false;
            }
        }

        public HealthPlanCallQueueCriteriaAssignment Save(HealthPlanCallQueueCriteriaAssignment systemGeneratedCallQueueCriteria)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<HealthPlanCallQueueCriteriaAssignment, HealthPlanCallQueueCriteriaAssignmentEntity>(systemGeneratedCallQueueCriteria);
                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                return Mapper.Map<HealthPlanCallQueueCriteriaAssignmentEntity, HealthPlanCallQueueCriteriaAssignment>(entity);
            }
        }

        public void SaveCollection(IEnumerable<HealthPlanCallQueueCriteriaAssignment> systemGeneratedCallQueueCriteria)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = Mapper.Map<IEnumerable<HealthPlanCallQueueCriteriaAssignment>, IEnumerable<HealthPlanCallQueueCriteriaAssignmentEntity>>(systemGeneratedCallQueueCriteria);

                var collection = new EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity>();
                collection.AddRange(entities);

                adapter.SaveEntityCollection(collection);
            }
        }

        public bool IsCustomerLockedForCriteria(long criteriaId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var lockedCallQueueCustomerIds = (from cqcl in linqMetaData.CallQueueCustomerLock select cqcl.CallQueueCustomerId);

                var count = (from hpcqca in linqMetaData.HealthPlanCallQueueCriteriaAssignment
                             where
                                 hpcqca.CriteriaId == criteriaId &&
                                 lockedCallQueueCustomerIds.Contains(hpcqca.CallQueueCustomerId)
                             select hpcqca.CallQueueCustomerId).Count();

                return count > 0;
            }

        }
    }
}