using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{
    [DefaultImplementation]
    public class CallCenterTeamRepository : PersistenceRepository, ICallCenterTeamRepository
    {
        public CallCenterTeam Save(CallCenterTeam model)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CallCenterTeam, CallCenterTeamEntity>(model);
                if (entity == null)
                {
                    return null;
                }
                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                return Mapper.Map<CallCenterTeamEntity, CallCenterTeam>(entity);
            }
        }

        public CallCenterTeam GetById(long teamId)
        {
            using (var adpater = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adpater);
                return
                    Mapper.Map<CallCenterTeamEntity, CallCenterTeam>(
                    (from cct in linqMetaData.CallCenterTeam where cct.Id == teamId && cct.IsActive select cct)
                        .SingleOrDefault());
            }
        }

        public IEnumerable<long> GetTeamAgents(long teamId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return
                    (from ccat in linqMetaData.CallCenterAgentTeam where ccat.TeamId == teamId select ccat.AgentId)
                        .ToArray();
            }
        }

        public bool IsTeamNameUnique(string name)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var activeTeamNames = (from cct in linqMetaData.CallCenterTeam
                                       where cct.IsActive
                                       select cct.Name.ToLower()).ToArray();

                return activeTeamNames.FirstOrDefault(y => string.Equals(y, name.ToLower())) == null;
            }
        }

        public void SaveAgentTeamAssignment(long teamId, IEnumerable<long> agentIds)
        {
            agentIds = agentIds.Distinct();
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(CallCenterAgentTeamEntity),
                                               new RelationPredicateBucket(CallCenterAgentTeamFields.TeamId == teamId));

                var entities = new EntityCollection<CallCenterAgentTeamEntity>();
                foreach (var agentId in agentIds)
                {
                    entities.Add(new CallCenterAgentTeamEntity { TeamId = teamId, AgentId = agentId });
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetIdNamePairOfTeams()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from cct in linqMetaData.CallCenterTeam where cct.IsActive select new OrderedPair<long, string> { FirstValue = cct.Id, SecondValue = cct.Name }).ToList();
            }
        }

        public IEnumerable<CallCenterTeam> GetByFilter(int pageNumber, int pageSize, CallCenterTeamListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    totalRecords = linqMetaData.CallCenterTeam.Count();

                    var entities = linqMetaData.CallCenterTeam.Where(x => x.IsActive).OrderByDescending(p => p.DateCreated).TakePage(pageNumber, pageSize).Select(x => x).ToArray();
                    return AutoMapper.Mapper.Map<IEnumerable<CallCenterTeamEntity>, IEnumerable<CallCenterTeam>>(entities);
                }
                else
                {
                    var query = (from c in linqMetaData.CallCenterTeam where c.IsActive select c);

                    if (!string.IsNullOrEmpty(filter.Name))
                    {
                        query = (from c in query
                                 where c.Name.Contains(filter.Name.Trim())
                                 select c);
                    }
                    totalRecords = query.Count();
                    var entities = query.OrderByDescending(p => p.DateCreated).TakePage(pageNumber, pageSize).Select(x => x).ToArray();
                    return AutoMapper.Mapper.Map<IEnumerable<CallCenterTeamEntity>, IEnumerable<CallCenterTeam>>(entities);
                }
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetTeamIdAgentIdOrderedPairsByTeamIds(IEnumerable<long> teamIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ta in linqMetaData.CallCenterAgentTeam
                        where teamIds.Contains(ta.TeamId)
                        select new OrderedPair<long, long>(ta.TeamId, ta.AgentId)).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetIdNamePairOfTeams(IEnumerable<long> teamIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from cct in linqMetaData.CallCenterTeam where cct.IsActive && teamIds.Contains(cct.Id) select new OrderedPair<long, string> { FirstValue = cct.Id, SecondValue = cct.Name }).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetAgentTeamIdPairs(IEnumerable<long> teamIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from cct in linqMetaData.CallCenterTeam
                             join ccat in linqMetaData.CallCenterAgentTeam on cct.Id equals ccat.TeamId
                             join oru in linqMetaData.OrganizationRoleUser on ccat.AgentId equals oru.OrganizationRoleUserId
                             join u in linqMetaData.User on oru.UserId equals u.UserId
                             where teamIds.Contains(cct.Id)
                             select new OrderedPair<long, string>
                             {
                                 FirstValue = cct.Id,
                                 SecondValue = u.FirstName + " " + u.LastName
                             }).ToArray();

                return query;
            }
        }
    }
}
