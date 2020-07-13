using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class EventScheduleListModelFilter : ModelFilterBase
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public long AccountId { get; set; }

        public long StateId { get; set; }

        public bool IsEmpty()
        {
            return FromDate == null && ToDate == null && AccountId <= 0 && StateId <= 0;
        }
    }
}