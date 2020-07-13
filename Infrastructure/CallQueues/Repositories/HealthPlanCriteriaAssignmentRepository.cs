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
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.Linq;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class HealthPlanCriteriaAssignmentRepository : PersistenceRepository, IHealthPlanCriteriaAssignmentRepository
    {
        private IEnumerable<HealthPlanCriteriaAssignment> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<HealthPlanCriteriaAssignmentEntity>();

                adapter.FetchEntityCollection(entities, expressionBucket);

                var healthPlanCriteriaAssignment = Mapper.Map<IEnumerable<HealthPlanCriteriaAssignmentEntity>, IEnumerable<HealthPlanCriteriaAssignment>>(entities);

                return healthPlanCriteriaAssignment.ToArray();
            }
        }

        public IEnumerable<HealthPlanCriteriaAssignment> GetByCriteriaId(long criteriaId)
        {
            var relationPredicateBucket = new RelationPredicateBucket(HealthPlanCriteriaAssignmentFields.HealthPlanCriteriaId == criteriaId);

            return Get(relationPredicateBucket);
        }

        public IEnumerable<HealthPlanCriteriaAssignment> GetByCriteriaIds(long[] criteriaIds)
        {

            var relationPredicateBucket = new RelationPredicateBucket(HealthPlanCriteriaAssignmentFields.HealthPlanCriteriaId == criteriaIds);

            return Get(relationPredicateBucket);
        }

        public bool DeleteByCriteriaId(long criteriaId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(HealthPlanCriteriaAssignmentEntity), new RelationPredicateBucket(HealthPlanCriteriaAssignmentFields.HealthPlanCriteriaId == criteriaId));
                return true;
            }
        }

        public void DeleteAssignmentFromOtherCriteria(long healthPlanId, long callQueueId, IEnumerable<long> assignedtoIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var criteriaAssignments = (from hpcqa in linqMetaData.HealthPlanCriteriaAssignment
                                           join cqc in linqMetaData.HealthPlanCallQueueCriteria on hpcqa.HealthPlanCriteriaId equals cqc.Id
                                           where cqc.HealthPlanId.HasValue && cqc.HealthPlanId.Value == healthPlanId && cqc.CallQueueId == callQueueId && assignedtoIds.Contains(hpcqa.AssignedToOrgRoleUserId)
                                           select hpcqa);

                foreach (var criteriaAssignment in criteriaAssignments)
                {
                    var relationPredicateBucket = new RelationPredicateBucket(HealthPlanCriteriaAssignmentFields.HealthPlanCriteriaId == criteriaAssignment.HealthPlanCriteriaId);

                    relationPredicateBucket.PredicateExpression.AddWithAnd(HealthPlanCriteriaAssignmentFields.AssignedToOrgRoleUserId == criteriaAssignment.AssignedToOrgRoleUserId);

                    adapter.DeleteEntitiesDirectly(typeof(HealthPlanCriteriaAssignmentEntity), relationPredicateBucket);
                }
            }
        }

        public void Save(long healthPlanId, long callQueueId, long criteriaId, IEnumerable<HealthPlanCriteriaAssignment> assignments)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var criteriaIds = assignments.Select(x => x.HealthPlanCriteriaId);
                foreach (var id in criteriaIds)
                {
                    DeleteByCriteriaId(id);
                    DeleteTeamAssignmentsForCriteria(id);

                }
                //DeleteByCriteriaId(criteriaId);
                //DeleteAssignmentFromOtherCriteria(healthPlanId, callQueueId, assignments.Select(s => s.AssignedToOrgRoleUserId).ToArray());

                var entities = Mapper.Map<IEnumerable<HealthPlanCriteriaAssignment>, IEnumerable<HealthPlanCriteriaAssignmentEntity>>(assignments);
                foreach (var entity in entities)
                {
                    Save(entity);
                }
            }
        }

        private void Save(HealthPlanCriteriaAssignmentEntity entity)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public IEnumerable<HealthPlanCriteriaAssignment> GetByOrganizationUserId(long userId)
        {
            var relationPredicateBucket = new RelationPredicateBucket(HealthPlanCriteriaAssignmentFields.AssignedToOrgRoleUserId == userId);

            return Get(relationPredicateBucket);
        }

        public void UpdateHealthPlanCriteriaAssignment(IEnumerable<CallQueueAssignmentEditModel> assignments)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                foreach (var assignment in assignments)
                {
                    var entity = new HealthPlanCriteriaAssignmentEntity(assignment.HealthPlanCriteriaId, assignment.AssignedOrgRoleUserId)
                    {
                        StartDate = assignment.StartDate,
                        EndDate = assignment.EndDate
                    };

                    var bucket = new RelationPredicateBucket(HealthPlanCriteriaAssignmentFields.AssignedToOrgRoleUserId == assignment.AssignedOrgRoleUserId);
                    bucket.PredicateExpression.AddWithAnd(HealthPlanCriteriaAssignmentFields.HealthPlanCriteriaId == assignment.HealthPlanCriteriaId);
                    adapter.UpdateEntitiesDirectly(entity, bucket);
                }
            }
        }

        private void DeleteTeamAssignmentsForCriteria(long criteriaId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(HealthPlanCriteriaTeamAssignmentEntity), new RelationPredicateBucket(HealthPlanCriteriaTeamAssignmentFields.HealthPlanCriteriaId == criteriaId));
            }
        }
    }
}
