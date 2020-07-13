using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using System.Collections.Generic;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IHealthPlanCallQueueCriteriaEditModelFactory
    {
        HealthPlanCallQueueCriteriaEditModel DomainToModel(HealthPlanCallQueueCriteria domain);
        HealthPlanCallQueueCriteria GetHealthPlanCallQueueCriteriaForFillEvent(HealthPlanCallQueueCriteriaEditModel model, long orgRoleId);
        HealthPlanCallQueueCriteria GetHealthPlanCallQueueCriteriaForCallRound(HealthPlanCallQueueCriteriaEditModel model, long orgRoleId);
        HealthPlanCallQueueCriteria GetHealthPlanCallQueueCriteriaForZipRadius(HealthPlanCallQueueCriteriaEditModel model, long orgRoleId);
        HealthPlanCallQueueCriteria GetHealthPlanCallQueueCriteriaForNoShow(HealthPlanCallQueueCriteriaEditModel model, long orgRoleId);
        IEnumerable<HealthPlanCriteriaAssignment> GetHealthPlanCriteriaAssignment(IEnumerable<CallQueueAssignmentEditModel> assignments, long healthplanCriteriaId, long orgRoleUserId);
        IEnumerable<HealthPlanCriteriaAssignment> GetHealthPlanCriteriaAssignmentForMailRound(IEnumerable<CallQueueAssignmentEditModel> assignments, IEnumerable<HealthPlanCallQueueCriteria> healthPlanCallQueueCriterias, long orgRoleUserId);

        IEnumerable<HealthPlanCriteriaTeamAssignment> GetHealthPlanCriteriaTeamAssignmentForMailRound(IEnumerable<HealthPlanCriteriaTeamAssignmentEditModel> teamAssignment, IEnumerable<HealthPlanCallQueueCriteria> healthPlanCallQueueCriterias,
            long orgRoleUserId);
        IEnumerable<HealthPlanCriteriaTeamAssignment> GetHealthPlanCriteriaTeamAssignment(IEnumerable<HealthPlanCriteriaTeamAssignmentEditModel> teamAssignment, HealthPlanCallQueueCriteria criteria, long orgRoleUserId);

        HealthPlanCallQueueCriteria GetHealthPlanCallQueueCriteriaForConfirmation(HealthPlanCallQueueCriteriaEditModel model, long orgRoleId);

        HealthPlanCallQueueCriteria GetHealthPlanCallQueueCriteriaForMailRound(HealthPlanCallQueueCriteriaEditModel model, long campaignId, long orgRoleId);
    }
}