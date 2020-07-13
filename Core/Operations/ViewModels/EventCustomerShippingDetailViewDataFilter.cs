using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class EventCustomerShippingDetailViewDataFilter : ModelFilterBase
    {
        public long ShippmentStatus { get; set; }
        public IEnumerable<long> ShippingOptions { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public long EventId { get; set; }
        public long PodId { get; set; }
        public bool IsResultReady { get; set; }
        public bool? IsExclusivelyRequested { get; set; }
        public int HasEmail { get; set; }
    }
}
