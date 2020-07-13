using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class EventNotesModelFilter : ModelFilterBase
    {
        public long HealthPlanId { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public long PodId { get; set; }
    }
}
