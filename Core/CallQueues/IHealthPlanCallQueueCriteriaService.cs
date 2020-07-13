using System.Collections.Generic;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanCallQueueCriteriaService
    {
        HealthPlanCallQueueCriteria GetSystemGeneratedCallQueueCriteria(long callQueueId, long healthPlanId, long? organizationUserRoleId, long campaignId, long? criterialId = null);

        IEnumerable<HealthPlanCallQueueCriteria> GetHealthPlanCallQueueCriteriaNotGenerated(long callQueueId);

        HealthPlanCallQueueCriteria Save(HealthPlanCallQueueCriteria criteria);

        ListModelBase<HealthPlanCallQueueViewModel, HealthPlanCallQueueListModelFilter> GetHealthPlanCallQueueList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        HealthPlanCallQueueCriteriaEditModel SaveHealthPlanCallQueueCriteria(HealthPlanCallQueueCriteriaEditModel editModel, long orgRoleId, bool isCriteriaSameAsPervious);
        HealthPlanCallQueueCriteriaEditModel GetCriteriaEditModel(long criteriaId = 0);
        IEnumerable<CallQueueAssignmentEditModel> GetCallQueueAssignment(long criteriaId);
        IEnumerable<HealthPlanCriteriaTeamEditModel> GetTeamAssignementEditModel(long criteriaId);
        void UpdateTeamAssignment(HealthPlanCriteriaTeamListEditModel model);
    }
}