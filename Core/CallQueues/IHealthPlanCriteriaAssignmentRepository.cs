using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanCriteriaAssignmentRepository
    {
        IEnumerable<HealthPlanCriteriaAssignment> GetByCriteriaId(long criteriaId);

        IEnumerable<HealthPlanCriteriaAssignment> GetByCriteriaIds(long[] criteriaIds);
        bool DeleteByCriteriaId(long criteriaId);
        void Save(long healthPlanId, long callQueueId, long criteriaId, IEnumerable<HealthPlanCriteriaAssignment> assignments);
        IEnumerable<HealthPlanCriteriaAssignment> GetByOrganizationUserId(long userId);
        void UpdateHealthPlanCriteriaAssignment(IEnumerable<CallQueueAssignmentEditModel> assignments);
    }
}