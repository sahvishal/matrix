using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;

namespace Falcon.App.Core.CallCenter.Interfaces
{
    public interface ICallCenterAgentTeamLogRepository
    {
        void SaveAll(IEnumerable<CallCenterAgentTeamLog> collection);
        CallCenterAgentTeamLog Save(CallCenterAgentTeamLog domain);
        IEnumerable<CallCenterAgentTeamLog> GetAgentTeamLogForTeam(long teamId, IEnumerable<long> agentIds);
    }
}
