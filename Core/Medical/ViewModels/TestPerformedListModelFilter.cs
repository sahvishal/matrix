using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class TestPerformedListModelFilter : ModelFilterBase
    {
        public DateTime? EventDateFrom { get; set; }
        public DateTime? EventDateTo { get; set; }
        public long TechnicianId { get; set; }
        public long HealthPlanId { get; set; }
        public long EventId { get; set; }
        public string Pod { get; set; }
        public bool IsRetailEvent { get; set; }
        public bool IsCorporateEvent { get; set; }
        public bool IsHealthPlanEvent { get; set; }
        public long TestId { get; set; }
        public string Tag { get; set; }
        public int IsPdfGenerated { get; set; }
    }
}
