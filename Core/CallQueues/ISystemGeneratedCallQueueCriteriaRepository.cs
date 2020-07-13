using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface ISystemGeneratedCallQueueCriteriaRepository
    {
        SystemGeneratedCallQueueCriteria GetById(long criteriaId);
        SystemGeneratedCallQueueCriteria GetQueueCriteria(long callQueueId, long? organisationUserRoleId);
        IEnumerable<SystemGeneratedCallQueueCriteria> GetQueueCriteriasByQueueId(long callQueueId);
        IEnumerable<SystemGeneratedCallQueueCriteria> GetSystemGeneratedCallQueueCriteriaNotGenerated(long callQueueId);
        SystemGeneratedCallQueueCriteria Save(SystemGeneratedCallQueueCriteria systemGeneratedCallQueueCriteria);
    }
}