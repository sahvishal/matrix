using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Finance.ViewModels
{
    [NoValidationRequired]
    public class PayRangeCustomerBookedViewModel
    {
        public long PayPeriodId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<OrderedPair<long, long>> CustomerBookedByAgents { get; set; }
        public long TotalCustomerBookedByAgent { get; set; }
    }
}
