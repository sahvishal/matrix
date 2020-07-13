using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Finance.Domain
{
    public class HealthPlanRevenue : DomainObjectBase
    {
        public long AccountId { get; set; }
        public long RevenueItemTypeId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
    }
}
