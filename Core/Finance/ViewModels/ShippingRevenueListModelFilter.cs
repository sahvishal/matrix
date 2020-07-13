using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class ShippingRevenueListModelFilter : ModelFilterBase
    {
        public long EventId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int PodId { get; set; }
    }
}
