using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class HealthPlanCriteriaDirectMail : DomainObjectBase
    {
        public long CriteriaId { get; set; }
        public long CampaignActivityId { get; set; }
    }
}
