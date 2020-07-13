using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class CallQueueCriteriaRepository : PersistenceRepository, ICallQueueCriteriaRepository
    {
        public IEnumerable<CallQueueCriteria> GetByCallQueueId(long callQueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cqc in linqMetaData.CallQueueCriteria
                                where cqc.CallQueueId == callQueueId
                                && cqc.IsActive
                                orderby cqc.Sequence
                                select cqc).ToArray();

                return Mapper.Map<IEnumerable<CallQueueCriteriaEntity>, IEnumerable<CallQueueCriteria>>(entities);
            }
        }

        public void Save(IEnumerable<CallQueueCriteria> callQueueCriterias, long callQueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                DeleteCallQueueCriteria(callQueueId);

                if (callQueueCriterias != null && callQueueCriterias.Any())
                {
                    var sequence = 1;
                    foreach (var callQueueCriteria in callQueueCriterias)
                    {
                        var existingEntity = (from cqc in linqMetaData.CallQueueCriteria
                                              where cqc.CallQueueId == callQueueId
                                              && cqc.CriteriaId == callQueueCriteria.CriteriaId
                                              && cqc.Zipcode == callQueueCriteria.Zipcode
                                              select cqc).SingleOrDefault();
                        if (existingEntity != null)
                            callQueueCriteria.Id = existingEntity.CallQueueCriteriaId;

                        callQueueCriteria.Sequence = sequence;
                        var entity = Mapper.Map<CallQueueCriteria, CallQueueCriteriaEntity>(callQueueCriteria);

                        if (!adapter.SaveEntity(entity, true))
                        {
                            throw new PersistenceFailureException();
                        }
                        sequence++;
                    }
                }
            }
        }

        private void DeleteCallQueueCriteria(long callQueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new CallQueueCriteriaEntity() { IsActive = false };
                var relationPredicateBucket = new RelationPredicateBucket(CallQueueCriteriaFields.CallQueueId == callQueueId);
                adapter.UpdateEntitiesDirectly(entity, relationPredicateBucket);
            }
        }

        public IEnumerable<CallQueueCriteria> GetByCallQueueIds(IEnumerable<long> callQueueIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cqc in linqMetaData.CallQueueCriteria
                                where callQueueIds.Contains(cqc.CallQueueId)
                                && cqc.IsActive
                                orderby cqc.Sequence
                                select cqc).ToArray();

                return Mapper.Map<IEnumerable<CallQueueCriteriaEntity>, IEnumerable<CallQueueCriteria>>(entities);
            }
        }

        public IEnumerable<CallQueueCriteria> GetAllByCallQueueId(long callQueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cqc in linqMetaData.CallQueueCriteria
                                where cqc.CallQueueId == callQueueId
                                orderby cqc.Sequence
                                select cqc).ToArray();

                return Mapper.Map<IEnumerable<CallQueueCriteriaEntity>, IEnumerable<CallQueueCriteria>>(entities);
            }
        }

        public CallQueueCriteria GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from cqc in linqMetaData.CallQueueCriteria where cqc.CallQueueCriteriaId == id select cqc).SingleOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map<CallQueueCriteriaEntity, CallQueueCriteria>(entity);
            }
        }

        public IEnumerable<HealthPlanCallQueueCriteria> GetAgentAssignedCallQueueCriteria(CallCentreAgentQueueFilter filter)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                //var confirmationCallQueue = (from cq in linqMetaData.CallQueue where cq.Category == HealthPlanCallQueueCategory.AppointmentConfirmation select cq).SingleOrDefault();

                var agentOrganization = (from acco in linqMetaData.AccountCallCenterOrganization
                                         where acco.OrganizationId == filter.AgentOrganizationId && acco.IsDeleted == false
                                         select acco.AccountId);

                var accountIds = (from a in linqMetaData.Account
                                  where a.IsHealthPlan && (a.RestrictHealthPlanData == false || agentOrganization.Contains(a.AccountId))
                                  select a.AccountId);

                var collection = (from hpcqc in linqMetaData.HealthPlanCallQueueCriteria
                                  join hpca in linqMetaData.HealthPlanCriteriaAssignment on hpcqc.Id equals hpca.HealthPlanCriteriaId into assignment
                                  from a in assignment.DefaultIfEmpty()
                                  join hpct in linqMetaData.HealthPlanCriteriaTeamAssignment on hpcqc.Id equals hpct.HealthPlanCriteriaId into healthPlanCriteriaTeamAssignment
                                  from hpcta in healthPlanCriteriaTeamAssignment.DefaultIfEmpty()
                                  join cca in linqMetaData.CallCenterAgentTeam on hpcta.TeamId equals cca.TeamId into callCenterAgentTeam
                                  from ccat in callCenterAgentTeam.DefaultIfEmpty()
                                  where hpcqc.IsDeleted == false
                                  && hpcqc.HealthPlanId.HasValue
                                  && accountIds.Contains(hpcqc.HealthPlanId.Value)
                                  && hpcqc.IsQueueGenerated &&
                                    (
                                      //(confirmationCallQueue != null && hpcqc.CallQueueId == confirmationCallQueue.CallQueueId)
                                      //||
                                        (a.AssignedToOrgRoleUserId != null && a.AssignedToOrgRoleUserId == filter.AgentOrganizationRoleUserId && a.StartDate < DateTime.Today.AddDays(1) && (a.EndDate == null || a.EndDate >= DateTime.Today))
                                        ||
                                        (ccat.AgentId != null && ccat.AgentId == filter.AgentOrganizationRoleUserId && hpcta.StartDate < DateTime.Today.AddDays(1) && (hpcta.EndDate == null || hpcta.EndDate >= DateTime.Today))
                                    )

                                  select hpcqc);

                if (filter.HealthPlanId > 0)
                {
                    collection = (from c in collection
                                  where c.HealthPlanId == filter.HealthPlanId
                                  select c);
                }
                if (filter.CallQueueId > 0)
                {
                    collection = (from c in collection
                                  where c.CallQueueId == filter.CallQueueId
                                  select c);
                }

                var entities = collection.Distinct().ToArray();
                return Mapper.Map<IEnumerable<HealthPlanCallQueueCriteriaEntity>, IEnumerable<HealthPlanCallQueueCriteria>>(entities);
            }
        }

        public IEnumerable<OrderedPair<long, string>> CallQueueIdNamePair(bool isHealthPlan = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from cq in linqMetaData.CallQueue
                        where cq.IsHealthPlan == isHealthPlan && cq.IsActive
                        select new OrderedPair<long, string>(cq.CallQueueId, cq.Name)).ToArray();
            }
        }

        public bool CheckForHealthplanRestriction(long agentOrganizationId, long healthplanId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var agentOrganization = (from acco in linqMetaData.AccountCallCenterOrganization
                                         where acco.OrganizationId == agentOrganizationId && acco.IsDeleted == false
                                         select acco.AccountId);

                var accountId = (from a in linqMetaData.Account
                                 where a.IsHealthPlan && a.AccountId == healthplanId && (a.RestrictHealthPlanData == false || agentOrganization.Contains(a.AccountId))
                                 select a.AccountId).SingleOrDefault();
                return accountId > 0;
            }
        }

        public bool CheckForCriteriaAssignmentChange(long criteriaId, long agentOrganizationRoleUserId, long agentOrganizationId, long healthplanId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var agentOrganization = (from acco in linqMetaData.AccountCallCenterOrganization
                                         where acco.OrganizationId == agentOrganizationId && acco.IsDeleted == false
                                         select acco.AccountId);

                var accountIds = (from a in linqMetaData.Account
                                  where a.IsHealthPlan && a.AccountId == healthplanId && (a.RestrictHealthPlanData == false || agentOrganization.Contains(a.AccountId))
                                  select a.AccountId);

                var assignedCriteriaId = (from hpcqc in linqMetaData.HealthPlanCallQueueCriteria
                                          join hpca in linqMetaData.HealthPlanCriteriaAssignment on hpcqc.Id equals hpca.HealthPlanCriteriaId into assignment
                                          from a in assignment.DefaultIfEmpty()
                                          join hpct in linqMetaData.HealthPlanCriteriaTeamAssignment on hpcqc.Id equals hpct.HealthPlanCriteriaId into healthPlanCriteriaTeamAssignment
                                          from hpcta in healthPlanCriteriaTeamAssignment.DefaultIfEmpty()
                                          join cca in linqMetaData.CallCenterAgentTeam on hpcta.TeamId equals cca.TeamId into callCenterAgentTeam
                                          from ccat in callCenterAgentTeam.DefaultIfEmpty()
                                          where hpcqc.IsDeleted == false
                                          && hpcqc.HealthPlanId.HasValue
                                          && hpcqc.Id == criteriaId
                                          && accountIds.Contains(hpcqc.HealthPlanId.Value)
                                          && hpcqc.IsQueueGenerated &&
                                            (
                                                (a.AssignedToOrgRoleUserId != null && a.AssignedToOrgRoleUserId == agentOrganizationRoleUserId && a.StartDate < DateTime.Today.AddDays(1) && (a.EndDate == null || a.EndDate >= DateTime.Today))
                                                ||
                                                (ccat.AgentId != null && ccat.AgentId == agentOrganizationRoleUserId && hpcta.StartDate < DateTime.Today.AddDays(1) && (hpcta.EndDate == null || hpcta.EndDate >= DateTime.Today))
                                            )

                                          select hpcqc.Id).SingleOrDefault();

                return assignedCriteriaId <= 0;
            }
        }
    }
}