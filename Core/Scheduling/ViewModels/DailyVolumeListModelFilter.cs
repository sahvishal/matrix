using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class DailyVolumeListModelFilter : ModelFilterBase
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        [DisplayName("Pod")]
        public string Pod { get; set; }
        public long HealthPlanId { get; set; }
        public bool IsHealthPlanEvent { get; set; }
        public bool IsRetailEvent { get; set; }
        public bool IsCorporateEvent { get; set; }
        public bool IsEmpty()
        {
            return FromDate == null && ToDate == null && string.IsNullOrWhiteSpace(Pod);
        }
    }
}