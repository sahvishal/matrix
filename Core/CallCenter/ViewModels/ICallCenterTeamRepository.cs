using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public interface ICallCenterTeamRepository
    {
        CallCenterTeam Save(CallCenterTeam model);
        bool IsTeamNameUnique(string name);
        void SaveAgentTeamAssignment(long teamId, IEnumerable<long> agentIds);
        CallCenterTeam GetById(long teamId);
        IEnumerable<long> GetTeamAgents(long teamId);
        IEnumerable<OrderedPair<long, string>> GetIdNamePairOfTeams();
        IEnumerable<CallCenterTeam> GetByFilter(int pageNumber, int pageSize, CallCenterTeamListModelFilter filter, out int totalRecords);
        IEnumerable<OrderedPair<long, long>> GetTeamIdAgentIdOrderedPairsByTeamIds(IEnumerable<long> teamIds);
        IEnumerable<OrderedPair<long, string>> GetIdNamePairOfTeams(IEnumerable<long> teamIds);
        IEnumerable<OrderedPair<long, string>> GetAgentTeamIdPairs(IEnumerable<long> teamIds);
    }
}
