using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    [NoValidationRequired]
    public class PayPeriodBookedCustomerFilter : ModelFilterBase
    {
        public long PayPeriodId { get; set; }
        public long AgentId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int NumberOfWeek { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool ShowAttendedCustomersOnly { get; set; }
    }
}