using System.Collections.Generic;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class CustomerOrderViewModel
    {
        public IEnumerable<OrderViewData> OrderDetails { get; set; }
        public IEnumerable<PaymentViewData> Paymentdetails { get; set; }
        public string CustomerName { get; set; }
        public long CustomerId { get; set; }
        public decimal AmountOwed { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal PaymentTotal { get; set; }
    }
}
