using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.CallCenter
{
    public interface IAgentConversionReportFactory
    {
        AgentConversionReportListModel Create(long[] agentOrgRoleUserIds, IEnumerable<OutboundCall> outboundCalls, IEnumerable<OrderedPair<long, string>> orgRoleUsers);
    }
}
