using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianReviewSummaryListModelFilter : ModelFilterBase
    {
        public long EventId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int DateType { get; set; }

        public int PodId { get; set; }

        public bool IsRetailEvent { get; set; }
        public bool IsCorporateEvent { get; set; }
        public bool IsPublicEvent { get; set; }
        public bool IsPrivateEvent { get; set; }

        public bool IsBlank()
        {
            if (EventId > 0 || FromDate.HasValue || ToDate.HasValue || DateType > 0 || PodId > 0 || (IsRetailEvent && !IsCorporateEvent) ||(!IsRetailEvent && IsCorporateEvent) || (!IsPublicEvent && IsPrivateEvent) || (IsPublicEvent && !IsPrivateEvent))
                return false;
            return true;
        }
    }
}
