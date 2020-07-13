using System;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class NoShowCustomerCriteriaEditModel
    {
        public long CriteriaId { get; set; }
        public long CallQueueId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int HealthPlanId { get; set; }
        public string CustomCorporateTag { get; set; }
    }
}