using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    [NoValidationRequired]
    public class CallCenterBonusFilter : ModelFilterBase
    {
        public long PayPeriodId { get; set; }

        public long CallCenterAgentId { get; set; }

        public DateTime? EffectiveDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string PayRange { get; set; }
    }
}