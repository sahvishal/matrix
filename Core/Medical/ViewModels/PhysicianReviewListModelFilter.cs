using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianReviewListModelFilter : ModelFilterBase
    {
        public long EventId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int DateType { get; set; }

        public long PhysicianId { get; set; }

        public int PodId { get; set; }

        public bool IsRetailEvent { get; set; }
        public bool IsCorporateEvent { get; set; }
        public bool IsPublicEvent { get; set; }
        public bool IsPrivateEvent { get; set; }
    }
}
