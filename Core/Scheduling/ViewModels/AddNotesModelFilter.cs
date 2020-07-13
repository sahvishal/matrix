using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class AddNotesModelFilter : ModelFilterBase
    {
        public long HealthPlanId { get; set; }

        public DateTime? EventDateFrom { get; set; }
        public DateTime? EventDateTo { get; set; }

        public long PodId { get; set; }

        public long Id { get; set; }
    }
}
