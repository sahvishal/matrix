using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
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
    public class HealthPlanCallQueueCriteriaRepository : PersistenceRepository, IHealthPlanCallQueueCriteriaRepository
    {
        public HealthPlanCallQueueCriteria GetById(long criteriaId)
        {
            try
            {
                var expresion = new RelationPredicateBucket(HealthPlanCallQueueCriteriaFields.Id == criteriaId);
                expresion.PredicateExpression.AddWithAnd(HealthPlanCallQueueCriteriaFields.IsDeleted == false);
                return Get(expresion).Single();
            }
            catch (InvalidOperationException)
            {
                throw new ObjectNotFoundInPersistenceException<HealthPlanCallQueueCriteria>(criteriaId);
            }
        }

        public IEnumerable<HealthPlanCallQueueCriteria> GetQueueCriteriasByQueueId(long callQueueId)
        {
            var expresion = new RelationPredicateBucket(HealthPlanCallQueueCriteriaFields.CallQueueId == callQueueId);
            expresion.PredicateExpression.AddWithAnd(HealthPlanCallQueueCriteriaFields.IsDeleted == false);
            return Get(expresion);

        }

        public IEnumerable<HealthPlanCallQueueCriteria> GetHealthPlanCallQueueCriteriaNotGenerated(long callQueueId)
        {
            var expresion = new RelationPredicateBucket(HealthPlanCallQueueCriteriaFields.CallQueueId == callQueueId);
            expresion.PredicateExpression.AddWithAnd(HealthPlanCallQueueCriteriaFields.IsQueueGenerated == false);
            expresion.PredicateExpression.AddWithAnd(HealthPlanCallQueueCriteriaFields.IsDeleted == false);

            return Get(expresion);
        }

        private IEnumerable<HealthPlanCallQueueCriteria> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<HealthPlanCallQueueCriteriaEntity>();

                adapter.FetchEntityCollection(entities, expressionBucket);

                var healthPlanCallQueueCriteriaTags = Mapper.Map<IEnumerable<HealthPlanCallQueueCriteriaEntity>, IEnumerable<HealthPlanCallQueueCriteria>>(entities);

                return healthPlanCallQueueCriteriaTags.ToArray();
            }
        }

        public HealthPlanCallQueueCriteria GetQueueCriteria(long callQueueId, long? organisationUserRoleId, long healthPlanId, DateTime? assignmentDate = null)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from hpcqc in linqMetaData.HealthPlanCallQueueCriteria
                              join hpca in linqMetaData.HealthPlanCriteriaAssignment on hpcqc.Id equals hpca.HealthPlanCriteriaId
                              where hpcqc.CallQueueId == callQueueId && hpcqc.HealthPlanId.HasValue && hpcqc.HealthPlanId.Value == healthPlanId && hpca.AssignedToOrgRoleUserId == organisationUserRoleId && hpcqc.IsDeleted == false
                              && (assignmentDate == null || (hpca.StartDate.HasValue && hpca.StartDate.Value <= assignmentDate && (hpca.EndDate == null || hpca.EndDate.Value >= assignmentDate)))
                              select hpcqc).SingleOrDefault();

                if (entity == null)
                {
                    entity = (from hpcqc in linqMetaData.HealthPlanCallQueueCriteria where hpcqc.CallQueueId == callQueueId && hpcqc.HealthPlanId == healthPlanId && hpcqc.IsDefault && hpcqc.IsDeleted == false select hpcqc).SingleOrDefault();
                }

                return Mapper.Map<HealthPlanCallQueueCriteriaEntity, HealthPlanCallQueueCriteria>(entity);
            }
        }

        public HealthPlanCallQueueCriteria Save(HealthPlanCallQueueCriteria healthPlanCallQueueCriteria)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<HealthPlanCallQueueCriteria, HealthPlanCallQueueCriteriaEntity>(healthPlanCallQueueCriteria);
                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                return Mapper.Map<HealthPlanCallQueueCriteriaEntity, HealthPlanCallQueueCriteria>(entity);
            }
        }

        public bool MarkForDelete(long criteriaId, bool markForDeletion)
        {
            var criteria = new HealthPlanCallQueueCriteriaEntity(criteriaId) { IsDeleted = markForDeletion };
            IRelationPredicateBucket relationPredicateBucket = new RelationPredicateBucket(HealthPlanCallQueueCriteriaFields.Id == criteriaId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.UpdateEntitiesDirectly(criteria, relationPredicateBucket) > 0;
            }
        }

        public IEnumerable<HealthPlanCallQueueCriteria> GetQueueCriteriaMarkedDeleted()
        {
            var expresion = new RelationPredicateBucket(HealthPlanCallQueueCriteriaFields.IsDeleted == true);
            return Get(expresion);
        }

        public IEnumerable<HealthPlanCallQueueCriteria> GetHealthPlanCallQueueCriteria(HealthPlanCallQueueListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                filter = filter ?? new HealthPlanCallQueueListModelFilter();

                //long mailRoundCallQueueId = 0;
                //if (!filter.ShowMailRoundCriteria)
                //mailRoundCallQueueId = (from cc in linqMetaData.CallQueue where cc.Category == HealthPlanCallQueueCategory.MailRound select cc.CallQueueId).Single();
                //var query = (from hc in linqMetaData.HealthPlanCallQueueCriteria where !hc.IsDeleted && hc.CallQueueId != mailRoundCallQueueId select hc);

                var confirmationQueue = (from cq in linqMetaData.CallQueue where cq.Category == HealthPlanCallQueueCategory.AppointmentConfirmation select cq).SingleOrDefault();

                var query = (from hc in linqMetaData.HealthPlanCallQueueCriteria where !hc.IsDeleted select hc);

                if (!filter.ShowAssignmentMetaData)
                    query = (from hc in linqMetaData.HealthPlanCallQueueCriteria where !hc.IsDeleted && (confirmationQueue != null && hc.CallQueueId != confirmationQueue.CallQueueId) select hc);

                if (filter.HealthPlanId > 0)
                {
                    query = (from hc in query where hc.HealthPlanId.Value == filter.HealthPlanId select hc);
                }

                if (filter.CallQueueId > 0)
                {
                    query = (from hc in query where hc.CallQueueId == filter.CallQueueId select hc);
                }

                totalRecords = query.Count();

                IEnumerable<HealthPlanCallQueueCriteriaEntity> entities = null;

                if (filter.ShowAssignmentMetaData)
                {
                    var criteriaIdModifiedDatePairQuery = (from hpca in linqMetaData.HealthPlanCriteriaAssignment
                                                           group hpca.DateCreated by hpca.HealthPlanCriteriaId
                                                               into g
                                                               select new { CriteriaId = g.Key, DateModifiedAgent = g.Max() });

                    var teamCriteriaIdModifiedDatePairQuery = (from hpcta in linqMetaData.HealthPlanCriteriaTeamAssignment
                                                               group hpcta.DateCreated by hpcta.HealthPlanCriteriaId
                                                                   into g
                                                                   select new { CriteriaId = g.Key, DateModifiedTeam = g.Max() });

                    var combinedQuery = (from q in query
                                         join c in criteriaIdModifiedDatePairQuery on q.Id equals c.CriteriaId into agentAssignment
                                         from aa in agentAssignment.DefaultIfEmpty()
                                         join tc in teamCriteriaIdModifiedDatePairQuery on q.Id equals tc.CriteriaId into teamAssignment
                                         from ta in teamAssignment.DefaultIfEmpty()
                                         select new
                                         {
                                             CriteriaId = q.Id,
                                             DateModified = aa.DateModifiedAgent != null ? aa.DateModifiedAgent : ta.DateModifiedTeam
                                         });

                    /*query = (from q in query
                             join c in combinedQuery on q.Id equals c.CriteriaId into assignment
                             from a in assignment.DefaultIfEmpty()
                             orderby a.DateModified descending
                             select q);

                    entities = query.TakePage(pageNumber, pageSize).ToArray();*/

                    entities = query.OrderByDescending(p => p.DateModified).ThenByDescending(o => o.DateCreated).TakePage(pageNumber, pageSize).ToArray();
                }
                else
                    entities = query.OrderByDescending(p => p.DateModified).ThenByDescending(o => o.DateCreated).TakePage(pageNumber, pageSize).ToArray();

                return Mapper.Map<IEnumerable<HealthPlanCallQueueCriteriaEntity>, IEnumerable<HealthPlanCallQueueCriteria>>(entities);
            }
        }

        public bool DeleteById(long criteriaId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly("HealthPlanCriteriaDirectMailEntity", new RelationPredicateBucket(HealthPlanCriteriaDirectMailFields.CriteriaId == criteriaId));
                adapter.DeleteEntitiesDirectly("HealthPlanCallQueueCriteriaAssignmentEntity", new RelationPredicateBucket(HealthPlanCallQueueCriteriaAssignmentFields.CriteriaId == criteriaId));
                adapter.DeleteEntitiesDirectly("HealthPlanCriteriaTeamAssignmentEntity", new RelationPredicateBucket(HealthPlanCriteriaTeamAssignmentFields.HealthPlanCriteriaId == criteriaId));
                adapter.DeleteEntitiesDirectly("HealthPlanCriteriaAssignmentEntity", new RelationPredicateBucket(HealthPlanCriteriaAssignmentFields.HealthPlanCriteriaId == criteriaId));
                adapter.DeleteEntitiesDirectly("HealthPlanFillEventCallQueueEntity", new RelationPredicateBucket(HealthPlanFillEventCallQueueFields.CriteriaId == criteriaId));
                adapter.DeleteEntitiesDirectly("HealthPlanCallQueueCriteriaEntity", new RelationPredicateBucket(HealthPlanCallQueueCriteriaFields.Id == criteriaId));

                return true;
            }
        }

        public HealthPlanCallQueueCriteria GetQueueCriteriaForQueue(long callQueueId, long healthPlanId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from hpcqc in linqMetaData.HealthPlanCallQueueCriteria
                              where hpcqc.CallQueueId == callQueueId && hpcqc.HealthPlanId.HasValue && hpcqc.HealthPlanId.Value == healthPlanId && hpcqc.IsDeleted == false
                              select hpcqc).OrderByDescending(x => x.DateCreated).FirstOrDefault();

                return Mapper.Map<HealthPlanCallQueueCriteriaEntity, HealthPlanCallQueueCriteria>(entity);
            }
        }

        public IEnumerable<HealthPlanCallQueueCriteria> GetCriteriaByHealthPlanCallQueue(long healthPlan, string callQueueCategory, bool considerDefault = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueueId = (from cq in linqMetaData.CallQueue where cq.IsHealthPlan && cq.Category == callQueueCategory select cq.CallQueueId).SingleOrDefault();

                var entities = (from hpc in linqMetaData.HealthPlanCallQueueCriteria
                                where hpc.HealthPlanId.HasValue && hpc.HealthPlanId.Value == healthPlan &&
                                    hpc.CallQueueId == callQueueId && hpc.IsDeleted == false && hpc.IsDefault == considerDefault
                                select hpc);

                return Mapper.Map<IEnumerable<HealthPlanCallQueueCriteriaEntity>, IEnumerable<HealthPlanCallQueueCriteria>>(entities);
            }
        }

        public bool MarkForDeleteByHealthPlanId(long healthPlanId)
        {
            var criteria = new HealthPlanCallQueueCriteriaEntity() { IsDeleted = true };
            IRelationPredicateBucket relationPredicateBucket = new RelationPredicateBucket(HealthPlanCallQueueCriteriaFields.HealthPlanId == healthPlanId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.UpdateEntitiesDirectly(criteria, relationPredicateBucket) > 0;
            }
        }

        public bool CheckHealthPlanAssignment(long healthPlanId, string callQueueCategory, long criteriaId, long assignmentOrgRoleId, DateTime startDate, DateTime? endDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueueId = (from cq in linqMetaData.CallQueue where cq.IsHealthPlan && cq.Category == callQueueCategory select cq.CallQueueId).First();

                var criterias = (from cr in linqMetaData.HealthPlanCallQueueCriteria
                                 where cr.HealthPlanId.HasValue && cr.HealthPlanId == healthPlanId && cr.Id != criteriaId
                                 && cr.CallQueueId == callQueueId && cr.IsDeleted == false
                                 select cr);

                var isExist = (from criteria in criterias
                               join hpa in linqMetaData.HealthPlanCriteriaAssignment on criteria.Id equals hpa.HealthPlanCriteriaId
                               where hpa.AssignedToOrgRoleUserId == assignmentOrgRoleId
                               && (
                               (
                                    endDate != null &&
                                    (
                                        (hpa.EndDate.HasValue && startDate >= hpa.StartDate.Value && startDate <= hpa.EndDate.Value)
                                        ||
                                        (hpa.EndDate.HasValue && (endDate >= hpa.StartDate && endDate <= hpa.EndDate.Value))
                                        ||
                                        (hpa.EndDate.HasValue && (hpa.StartDate >= startDate && hpa.StartDate <= endDate))
                                    )
                               )
                               ||
                               (
                                    endDate == null &&
                                    (
                                        (hpa.EndDate.HasValue && startDate <= hpa.EndDate.Value)
                                    )

                               )
                               ||
                               (
                                    !hpa.EndDate.HasValue && endDate != null && (startDate >= hpa.StartDate || endDate >= hpa.StartDate)
                               )
                               ||
                               (
                                    endDate == null && !hpa.EndDate.HasValue && (startDate >= hpa.StartDate || hpa.StartDate >= startDate)
                               )
                               )
                               select hpa).Any();

                return isExist;
            }
        }

        public void RegenerateHealthPlanCriteria(long healthPlanCriteriaId, long orgRoleId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(new HealthPlanCallQueueCriteriaEntity { IsQueueGenerated = false, DateModified = DateTime.Now, ModifiedByOrgRoleUserId = orgRoleId },
                    new RelationPredicateBucket(HealthPlanCallQueueCriteriaFields.Id == healthPlanCriteriaId));
            }
        }

        public IEnumerable<HealthPlanCallQueueCriteria> GetByCampaignId(long campaignId)
        {
            var expresion = new RelationPredicateBucket(HealthPlanCallQueueCriteriaFields.CampaignId == campaignId);
            expresion.PredicateExpression.AddWithAnd(HealthPlanCallQueueCriteriaFields.IsDeleted == false);
            return Get(expresion);
        }

        public IEnumerable<HealthPlanCallQueueCriteria> GetByCampaignIds(IEnumerable<long> campaignIds, long healthPlanId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from q in linqMetaData.HealthPlanCallQueueCriteria
                                where q.CampaignId.HasValue && campaignIds.Contains(q.CampaignId.Value) && q.IsDeleted == false && q.HealthPlanId.HasValue && q.HealthPlanId == healthPlanId
                                select q);

                var healthPlanCallQueueCriteriaTags = Mapper.Map<IEnumerable<HealthPlanCallQueueCriteriaEntity>, IEnumerable<HealthPlanCallQueueCriteria>>(entities);

                return healthPlanCallQueueCriteriaTags.ToArray();
            }
        }

        public IEnumerable<HealthPlanCallQueueCriteria> GetQueueCriteriasByCriteriaIds(IEnumerable<long> criteriaIds, long callQueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from q in linqMetaData.HealthPlanCallQueueCriteria
                                where criteriaIds.Contains(q.Id) && q.IsDeleted == false && q.CallQueueId == callQueueId
                                select q).ToArray();

                return Mapper.Map<IEnumerable<HealthPlanCallQueueCriteriaEntity>, IEnumerable<HealthPlanCallQueueCriteria>>(entities);
            }
        }

        public IEnumerable<Campaign> GetCampaignsByHealthPlanId(long healthPlanId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from c in linqMetaData.Campaign
                                //join hpcqc in linqMetaData.HealthPlanCallQueueCriteria on c.Id equals hpcqc.CampaignId.Value
                                where /*hpcqc.CampaignId.HasValue && hpcqc.IsDeleted == false &&*/ c.AccountId == healthPlanId && c.IsPublished
                                select c).ToArray();

                return Mapper.Map<IEnumerable<CampaignEntity>, IEnumerable<Campaign>>(entities);
            }
        }

        public IEnumerable<string> GetAllHealthPlanCallQueueCriteriaNames()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from hpcqc in linqMetaData.HealthPlanCallQueueCriteria
                                where hpcqc.IsDeleted == false && hpcqc.CriteriaName != null
                                select hpcqc.CriteriaName).ToArray();
                return entities;
            }
        }

        public bool CheckAgentTeamHealthPlanAssignment(long healthPlanId, string callQueueCategory, long criteriaId, long teamId, DateTime startDate, DateTime? endDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueueId = (from cq in linqMetaData.CallQueue where cq.IsHealthPlan && cq.Category == callQueueCategory select cq.CallQueueId).First();

                var criteria = (from cr in linqMetaData.HealthPlanCallQueueCriteria
                                where cr.HealthPlanId.HasValue && cr.HealthPlanId == healthPlanId && cr.Id != criteriaId
                                && cr.CallQueueId == callQueueId && cr.IsDeleted == false
                                select cr);

                var isExist = (from hpc in criteria
                               join hpta in linqMetaData.HealthPlanCriteriaTeamAssignment on hpc.Id equals hpta.HealthPlanCriteriaId
                               where hpta.TeamId == teamId
                               && (
                               (
                                    endDate != null &&
                                    (
                                        (hpta.EndDate.HasValue && startDate >= hpta.StartDate && startDate <= hpta.EndDate.Value)
                                        ||
                                        (hpta.EndDate.HasValue && (endDate >= hpta.StartDate && endDate <= hpta.EndDate.Value))
                                        ||
                                        (hpta.EndDate.HasValue && (hpta.StartDate >= startDate && hpta.StartDate <= endDate))
                                    )
                               )
                               ||
                               (
                                    endDate == null &&
                                    (
                                        (hpta.EndDate.HasValue && startDate <= hpta.EndDate.Value)
                                    )

                               )
                               ||
                               (
                                    !hpta.EndDate.HasValue && endDate != null && (startDate >= hpta.StartDate || endDate >= hpta.StartDate)
                               )
                               ||
                               (
                                    endDate == null && !hpta.EndDate.HasValue && (startDate >= hpta.StartDate || hpta.StartDate >= startDate)
                               )
                               )
                               select hpta).Any();

                return isExist;
            }
        }

        public HealthPlanCallQueueCriteria GetQueueCriteriaForQueueByLanguage(string category, long healthPlanId, long? languageId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueue = (from cq in linqMetaData.CallQueue where cq.Category == category select cq).Single();

                var entity = (from hpcqc in linqMetaData.HealthPlanCallQueueCriteria
                              where hpcqc.CallQueueId == callQueue.CallQueueId && hpcqc.HealthPlanId.HasValue && hpcqc.HealthPlanId.Value == healthPlanId
                              && hpcqc.LanguageId.HasValue && hpcqc.LanguageId == languageId
                              && hpcqc.IsDeleted == false
                              select hpcqc).OrderByDescending(x => x.DateCreated).FirstOrDefault();

                return Mapper.Map<HealthPlanCallQueueCriteriaEntity, HealthPlanCallQueueCriteria>(entity);
            }
        }

        public IEnumerable<HealthPlanCallQueueCriteria> GetCriteriaForMailRoundGms(long healthPlan)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueueId = (from cq in linqMetaData.CallQueue where cq.IsHealthPlan && cq.Category == HealthPlanCallQueueCategory.MailRound select cq.CallQueueId).SingleOrDefault();

                var entities = (from hpc in linqMetaData.HealthPlanCallQueueCriteria
                                join c in linqMetaData.Campaign on hpc.CampaignId equals c.Id
                                where hpc.HealthPlanId.HasValue && hpc.HealthPlanId.Value == healthPlan &&
                                    hpc.CallQueueId == callQueueId && hpc.IsDeleted == false && hpc.IsDefault == false
                                orderby c.EndDate descending
                                select hpc);

                return Mapper.Map<IEnumerable<HealthPlanCallQueueCriteriaEntity>, IEnumerable<HealthPlanCallQueueCriteria>>(entities);
            }
        }
    }
}