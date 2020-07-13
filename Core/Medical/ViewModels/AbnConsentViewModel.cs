using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class AbnConsentViewModel
    {
        public string CustomerName { get; set; }
        public long CustomerId { get; set; }
        public IEnumerable<OrderedPair<string, decimal>> Tests { get; set; }
        public OrderedPair<string, decimal> Product { get; set; } 
    }
}
