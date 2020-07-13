using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Insurance.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class InsurancePaymentViewModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Name")]
        public string EventName { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Package/Test(s)")]
        public string CustomerOrder { get; set; }

        [DisplayName("Payment Instruments")]
        public IEnumerable<OrderedPair<string, decimal>> PaymentInstruments { get; set; }

        [DisplayName("Insurance Detail")]
        public InsuranceDetailViewModel InsuranceDetail { get; set; }

        public string Status { get; set; }

        [DisplayName("Order Total")]
        public decimal DiscountedTotal { get; set; }

        [Hidden]
        public long OrderId { get; set; }
    }
}
