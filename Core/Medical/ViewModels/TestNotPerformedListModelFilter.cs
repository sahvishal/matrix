using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class TestNotPerformedListModelFilter : ModelFilterBase
    {
        public DateTime? EventDateFrom { get; set; }
        public DateTime? EventDateTo { get; set; }

        public long TechnicianId { get; set; }
        public long HealthPlanId { get; set; }
        public long EventId { get; set; }
        public string Pod { get; set; }
        public long TestId { get; set; }
    }
}