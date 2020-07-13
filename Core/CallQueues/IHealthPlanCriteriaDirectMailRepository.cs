using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanCriteriaDirectMailRepository
    {
        IEnumerable<HealthPlanCriteriaDirectMail> GetByCriteriaId(long criteriaId);
        IEnumerable<HealthPlanCriteriaDirectMail> GetByCampaignId(long campaignId);
        bool Save(IEnumerable<long> activityIds, long criteriaId);
        IEnumerable<HealthPlanCriteriaDirectMail> GetByCriteriaIds(long[] criteriaIds);
    }
}