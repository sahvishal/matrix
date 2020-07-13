using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface ISystemGeneratedCallQueueAssignmentRepository
    {
        bool DeleteByCriteriaId(long criteriaId);
        SystemGeneratedCallQueueAssignment Save(SystemGeneratedCallQueueAssignment assignment);
    }
}
