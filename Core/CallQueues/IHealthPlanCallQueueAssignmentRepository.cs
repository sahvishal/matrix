using System.Collections.Generic;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanCallQueueAssignmentRepository
    {
        bool DeleteByCriteriaId(long criteriaId);
        HealthPlanCallQueueCriteriaAssignment Save(HealthPlanCallQueueCriteriaAssignment assignment);
        void SaveCollection(IEnumerable<HealthPlanCallQueueCriteriaAssignment> systemGeneratedCallQueueCriteria);
        bool IsCustomerLockedForCriteria(long criteriaId);
    }
}