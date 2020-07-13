using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class CustomerOrderModel : ViewModelBase
    {
        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Location")]
        public string Location { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        public long OrderId { get; set; }

        [DisplayName("Revenue")]
        public decimal DiscountedTotal { get; set; }

        [DisplayName("Payment")]
        public decimal TotalPayment { get; set; }

    }
}
