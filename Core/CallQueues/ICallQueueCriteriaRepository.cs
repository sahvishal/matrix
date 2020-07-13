using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallQueueCriteriaRepository
    {
        IEnumerable<CallQueueCriteria> GetByCallQueueId(long callQueueId);
        void Save(IEnumerable<CallQueueCriteria> callQueueCriterias, long callQueueId);
        IEnumerable<CallQueueCriteria> GetByCallQueueIds(IEnumerable<long> callQueueIds);
        IEnumerable<CallQueueCriteria> GetAllByCallQueueId(long callQueueId);
        CallQueueCriteria GetById(long id);
        IEnumerable<HealthPlanCallQueueCriteria> GetAgentAssignedCallQueueCriteria(CallCentreAgentQueueFilter filter);
        IEnumerable<OrderedPair<long, string>> CallQueueIdNamePair(bool isHealthPlan);
        bool CheckForHealthplanRestriction(long agentOrganizationId, long healthplanId);
        bool CheckForCriteriaAssignmentChange(long criteriaId, long agentOrganizationRoleUserId, long agentOrganizationId, long healthplanId);
    }
}
