using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class EventListGmsModelFilter : ModelFilterBase
    {
        public DateTime FromDate { get; set; }

        public IEnumerable<long> HealthPlanIds { get; set; }
    }
}
