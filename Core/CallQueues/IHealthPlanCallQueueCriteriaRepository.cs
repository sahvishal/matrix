using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.CallCenter.Domain;
using System;

namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanCallQueueCriteriaRepository
    {
        HealthPlanCallQueueCriteria GetById(long criteriaId);
        IEnumerable<HealthPlanCallQueueCriteria> GetQueueCriteriasByQueueId(long callQueueId);
        IEnumerable<HealthPlanCallQueueCriteria> GetHealthPlanCallQueueCriteriaNotGenerated(long callQueueId);
        HealthPlanCallQueueCriteria GetQueueCriteria(long callQueueId, long? organizationUserRoleId, long healthPlanId, DateTime? assignmentDate = null);
        HealthPlanCallQueueCriteria Save(HealthPlanCallQueueCriteria healthPlanCallQueueCriteria);
        IEnumerable<HealthPlanCallQueueCriteria> GetHealthPlanCallQueueCriteria(HealthPlanCallQueueListModelFilter filter, int pageNumber, int pageSize, out int totalRecords);

        bool MarkForDelete(long criteriaId, bool markForDeletion);
        IEnumerable<HealthPlanCallQueueCriteria> GetQueueCriteriaMarkedDeleted();
        bool DeleteById(long criteriaId);

        HealthPlanCallQueueCriteria GetQueueCriteriaForQueue(long callQueueId, long healthPlanId);
        IEnumerable<HealthPlanCallQueueCriteria> GetCriteriaByHealthPlanCallQueue(long healthPlan, string callQueueCategory, bool considerDefault = false);

        bool MarkForDeleteByHealthPlanId(long healthPlanId);
        bool CheckHealthPlanAssignment(long healthPlan, string callQueueCategory, long criteriaId, long assignmentOrgRoleId, DateTime startDate, DateTime? endDate);

        void RegenerateHealthPlanCriteria(long healthPlanCriteriaId, long orgRoleId);
        
        IEnumerable<HealthPlanCallQueueCriteria> GetByCampaignId(long campaignId);
        IEnumerable<HealthPlanCallQueueCriteria> GetByCampaignIds(IEnumerable<long> campaignIds, long healthPlanId);
        IEnumerable<Campaign> GetCampaignsByHealthPlanId(long healthPlanId);
        IEnumerable<HealthPlanCallQueueCriteria> GetQueueCriteriasByCriteriaIds(IEnumerable<long> criteriaIds, long callQueueId);

        IEnumerable<string> GetAllHealthPlanCallQueueCriteriaNames();
        bool CheckAgentTeamHealthPlanAssignment(long healthPlanId, string callQueueCategory, long criteriaId, long teamId, DateTime startDate, DateTime? endDate);

        HealthPlanCallQueueCriteria GetQueueCriteriaForQueueByLanguage(string category, long healthPlanId, long? languageId);

        IEnumerable<HealthPlanCallQueueCriteria> GetCriteriaForMailRoundGms(long healthPlan);
    }
}