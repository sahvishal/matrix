using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class CustomerOpenOrderListModelFilter : ModelFilterBase
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool IsRetailEvent { get; set; }
        public bool IsCorporateEvent { get; set; }
        public bool IsPublicEvent { get; set; }
        public bool IsPrivateEvent { get; set; }
        public long EventId { get; set; }
    }
}
