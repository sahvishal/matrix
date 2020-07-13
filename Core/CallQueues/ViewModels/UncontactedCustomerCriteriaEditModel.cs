namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class UncontactedCustomerCriteriaEditModel
    {
        public long CriteriaId { get; set; }
        public long CallQueueId { get; set; }

        public int HealthPlanId { get; set; }
        public string CustomCorporateTag { get; set; }
    }
}