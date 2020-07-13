using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class CustomerEventCriticalDataListModelFilter : ModelFilterBase
    {
        public string CustomerName { get; set; }
        public long CustomerId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long EventId { get; set; }
    }
}
