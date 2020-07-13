namespace Falcon.App.Core.Insurance.Domain
{
    public class EventCustomerEligibility
    {
        public long EventCustomerId { get; set; }
        public long EligibilityId { get; set; }
        public long? ChargeCardId { get; set; }
    }
}
