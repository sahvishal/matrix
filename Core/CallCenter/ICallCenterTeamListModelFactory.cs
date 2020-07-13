using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.CallCenter
{
    public interface ICallCenterTeamListModelFactory
    {
        CallCenterTeamListModel Create(IEnumerable<CallCenterTeam> teams, IEnumerable<OrderedPair<long, long>> teamIdAgentIdPairs, IEnumerable<OrderedPair<long, string>> idNamePairs);
    }
}
