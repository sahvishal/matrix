using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;

namespace Falcon.App.Core.CallCenter
{
    public interface ICallUploadRuleEngine
    {
        bool ApplyRuleEngine(CallUploadLog callUploadLog, IEnumerable<Call> calls, ProspectCustomer prospectCustomer, long organizationRoleUserId, long callqueueCustomerId, long callQueueId, out bool isRemovedFromCallQueue, ILogger logger);
    }
}