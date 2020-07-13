using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class TextReminderModelFilter : ModelFilterBase
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public long HealthPlanId { get; set; }

        public bool ShowSmsOptedCustomers { get; set; }
        public bool ShowSmsNotOptedCustomers { get; set; }
    }
}
