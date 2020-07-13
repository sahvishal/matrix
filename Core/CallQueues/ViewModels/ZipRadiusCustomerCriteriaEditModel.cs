namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class ZipRadiusCustomerCriteriaEditModel
    {
        public long CriteriaId { get; set; }
        public long CallQueueId { get; set; }
        public string ZipCode { get; set; }
        public int? Radius { get; set; }
        public int HealthPlanId { get; set; }
        public string CustomCorporateTag { get; set; }
    }
}