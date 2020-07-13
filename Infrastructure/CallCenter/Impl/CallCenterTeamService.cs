using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class CallCenterTeamService : ICallCenterTeamService
    {
        private readonly ICallCenterTeamRepository _callCenterTeamRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ICallCenterTeamListModelFactory _callCenterTeamListModelFactory;

        public CallCenterTeamService(ICallCenterTeamRepository callCenterTeamRepository, IOrganizationRoleUserRepository organizationRoleUserRepository,
            ICallCenterTeamListModelFactory callCenterTeamListModelFactory)
        {
            _callCenterTeamRepository = callCenterTeamRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _callCenterTeamListModelFactory = callCenterTeamListModelFactory;
        }

        public CallCenterTeamEditModel GetCallCenterTeamEditModel(long teamId)
        {
            var team = _callCenterTeamRepository.GetById(teamId);
            if (team == null)
            {
                return null;
            }
            var currentAgentIds = _callCenterTeamRepository.GetTeamAgents(teamId);
            var agentMasterList = _organizationRoleUserRepository.GetIdNamePairofUsersByRole(Roles.CallCenterRep);
            var agentPairs = agentMasterList.Where(x => currentAgentIds.Contains(x.FirstValue)).Select(x => x).ToArray();

            var masterListExceptAssignedAgents = agentMasterList.Select(x => x.FirstValue).Except(currentAgentIds);
            if (masterListExceptAssignedAgents.Any())
            {
                agentMasterList = agentMasterList.Where(x => masterListExceptAssignedAgents.Contains(x.FirstValue)).Select(x => x).ToArray();
            }
            else
            {
                agentMasterList = new List<OrderedPair<long, string>>();
            }

            return new CallCenterTeamEditModel
            {
                Id = team.Id,
                Assignments = agentPairs.Sort(OrderByDirection.Ascending, x => x.SecondValue),
                Description = team.Description,
                Name = team.Name,
                TypeId = team.TypeId,
                AgentsMasterList = agentMasterList.Sort(OrderByDirection.Ascending, x => x.SecondValue)
            };
        }

        public ListModelBase<CallCenterTeamViewModel, CallCenterTeamListModelFilter> GetCallCenterTeams(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var callCenterTeams = _callCenterTeamRepository.GetByFilter(pageNumber, pageSize, filter as CallCenterTeamListModelFilter, out totalRecords);

            if (callCenterTeams.IsNullOrEmpty()) return null;

            var teamIds = callCenterTeams.Select(c => c.Id).ToArray();

            var orgRoleUserIds = new List<long>();

            orgRoleUserIds.AddRange(callCenterTeams.Select(c => c.DataRecorderMetaData.DataRecorderCreator.Id).ToArray());

            var modifiedByOrgRoleUserIds = callCenterTeams.Where(c => c.DataRecorderMetaData.DataRecorderModifier != null && c.DataRecorderMetaData.DataRecorderModifier.Id > 0)
                .Select(c => c.DataRecorderMetaData.DataRecorderModifier.Id).ToArray();

            if (!modifiedByOrgRoleUserIds.IsNullOrEmpty())
                orgRoleUserIds.AddRange(modifiedByOrgRoleUserIds);

            var teamIdAgentIdPairs = _callCenterTeamRepository.GetTeamIdAgentIdOrderedPairsByTeamIds(teamIds);

            orgRoleUserIds.AddRange(teamIdAgentIdPairs.Select(x => x.SecondValue).ToArray());

            orgRoleUserIds = orgRoleUserIds.Distinct().ToList();

            var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray());

            return _callCenterTeamListModelFactory.Create(callCenterTeams, teamIdAgentIdPairs, idNamePairs);
        }
    }
}
