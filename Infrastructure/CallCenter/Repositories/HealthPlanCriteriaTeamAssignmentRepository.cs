using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{
    [DefaultImplementation]
    public class HealthPlanCriteriaTeamAssignmentRepository : PersistenceRepository, IHealthPlanCriteriaTeamAssignmentRepository
    {
        public void Save(IEnumerable<HealthPlanCriteriaTeamAssignment> collection)
        {
            var distinctCriterias = collection.Select(x => x.HealthPlanCriteriaId).Distinct();
            foreach (var criteriaId in distinctCriterias)
            {
                DeleteAssignmentsForCriteria(criteriaId);
                DeleteAgentAssignmentForCriteria(criteriaId);
            }

            var entities = Mapper.Map<IEnumerable<HealthPlanCriteriaTeamAssignment>, IEnumerable<HealthPlanCriteriaTeamAssignmentEntity>>(collection);
            foreach (var entity in entities)
            {
                entity.IsActive = true;
                Save(entity);
            }
        }

        public IEnumerable<HealthPlanCriteriaTeamAssignment> GetTeamAssignments(long healthPlanCriteriaId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from hpcta in linqMetaData.HealthPlanCriteriaTeamAssignment
                                where hpcta.HealthPlanCriteriaId == healthPlanCriteriaId
                                select hpcta).ToArray();

                return Mapper.Map<IEnumerable<HealthPlanCriteriaTeamAssignmentEntity>, IEnumerable<HealthPlanCriteriaTeamAssignment>>(entities);

            }
        }

        private void Save(HealthPlanCriteriaTeamAssignmentEntity entity)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public void DeleteAssignmentsForCriteria(long criteriaId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(HealthPlanCriteriaTeamAssignmentEntity),
                                                      new RelationPredicateBucket(HealthPlanCriteriaTeamAssignmentFields.HealthPlanCriteriaId == criteriaId));
            }
        }

        public IEnumerable<HealthPlanCriteriaTeamAssignment> GetByCriteriaIds(IEnumerable<long> criteriaIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from hpcta in linqMetaData.HealthPlanCriteriaTeamAssignment
                                where criteriaIds.Contains(hpcta.HealthPlanCriteriaId)
                                select hpcta).ToArray();

                return Mapper.Map<IEnumerable<HealthPlanCriteriaTeamAssignmentEntity>, IEnumerable<HealthPlanCriteriaTeamAssignment>>(entities);

            }
        }

        public bool IsTeamOverlapped(HealthPlanCriteriaTeamEditModel model)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var crterias = (from hpcqc in linqMetaData.HealthPlanCallQueueCriteria
                                where hpcqc.Id != model.CriteriaId && hpcqc.CallQueueId == model.CallQueueId &&
                                      hpcqc.HealthPlanId == model.HealthPlanId
                                select hpcqc.Id);

                var endDate = model.EndDate;
                var startDate = model.StartDate;

                var count = (from hpcta in linqMetaData.HealthPlanCriteriaTeamAssignment
                             where crterias.Contains(hpcta.HealthPlanCriteriaId)
                              && (
                               (
                                    endDate != null &&
                                    (
                                        (hpcta.EndDate.HasValue && startDate >= hpcta.StartDate && startDate <= hpcta.EndDate.Value)
                                        ||
                                        (hpcta.EndDate.HasValue && (hpcta.StartDate >= endDate && endDate <= hpcta.EndDate.Value))
                                        ||
                                        (hpcta.EndDate.HasValue && (hpcta.StartDate >= startDate && hpcta.StartDate <= endDate))
                                        ||
                                        (hpcta.EndDate.HasValue && (hpcta.EndDate >= startDate && hpcta.EndDate <= endDate))

                                    )
                               )
                               ||
                               (
                                    endDate == null &&
                                    (
                                        (hpcta.EndDate.HasValue && startDate <= hpcta.EndDate.Value)
                                    )

                               )
                               ||
                               (
                                    !hpcta.EndDate.HasValue && (hpcta.StartDate >= startDate || hpcta.StartDate <= startDate)
                               )
                               )
                             select hpcta).Count();

                return count > 1;
            }
        }

        public void UpdateTeamAssignment(HealthPlanCriteriaTeamEditModel model)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new HealthPlanCriteriaTeamAssignmentEntity()
                {
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                };

                entity.Fields["EndDate"].IsChanged = true;

                var bucket = new RelationPredicateBucket(HealthPlanCriteriaTeamAssignmentFields.HealthPlanCriteriaId == model.CriteriaId);
                bucket.PredicateExpression.AddWithAnd(HealthPlanCriteriaTeamAssignmentFields.TeamId == model.Id);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        private void DeleteAgentAssignmentForCriteria(long criteriaId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(HealthPlanCriteriaAssignmentEntity), new RelationPredicateBucket(HealthPlanCriteriaAssignmentFields.HealthPlanCriteriaId == criteriaId));
            }
        }
    }
}
