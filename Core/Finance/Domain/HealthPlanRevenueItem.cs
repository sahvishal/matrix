using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Finance.Domain
{
    public class HealthPlanRevenueItem : DomainObjectBase
    {
        public long HealthPlanRevenueId { get; set; }
        public long? PackageId { get; set; }
        public long? TestId { get; set; }
        public decimal Price { get; set; }
    }
}
