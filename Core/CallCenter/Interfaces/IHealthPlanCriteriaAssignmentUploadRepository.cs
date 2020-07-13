using Falcon.App.Core.CallCenter.Domain;

namespace Falcon.App.Core.CallCenter.Interfaces
{
    public interface IHealthPlanCriteriaAssignmentUploadRepository
    {
        HealthPlanCriteriaAssignmentUpload Save(HealthPlanCriteriaAssignmentUpload domain);
    }
}
