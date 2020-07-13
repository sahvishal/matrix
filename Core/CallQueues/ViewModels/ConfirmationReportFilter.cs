using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    [NoValidationRequired]
    public class ConfirmationReportFilter : ModelFilterBase
    {
        public DateTime? EventDateFrom { get; set; }

        public DateTime? EventDateTo { get; set; }

        public long HealthPlanId { get; set; }

        public string Disposition { get; set; }
    }
}
