using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface ISystemGeneratedCallQueueCriteriaService
    {
        SystemGeneratedCallQueueCriteria GetSystemGeneratedCallQueueCriteria(long callQueueId, long? organisationUserRoleId);
        IEnumerable<SystemGeneratedCallQueueCriteria> GetSystemGeneratedCallQueueCriteria(long callQueueId);
        IEnumerable<SystemGeneratedCallQueueCriteria> GetSystemGeneratedCallQueueCriteriaNotGenerated(long callQueueId);
        SystemGeneratedCallQueueCriteria UpdateEventQueueCriteria(FillEventQueueCriteriaEditModel model, long organizationRoleId);
        SystemGeneratedCallQueueCriteria Save(SystemGeneratedCallQueueCriteria systemGeneratedCallQueueCriteria);
        SystemGeneratedCallQueueCriteria UpdateConfirmationQueueCriteria(ConfirmationQueueCriteriaEditModel model, long organizationRoleId);
        SystemGeneratedCallQueueCriteria UpdateUpsellQueueCriteria(UpsellQueueCriteriaEditModel model, long organizationRoleId);
    }
}
