using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class ShippingRevenueDetailViewModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public Name CustomerName { get; set; }

        [DisplayName("Customer Address")]
        public AddressViewModel CustomerAddress { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Event Name")]
        public string EventName { get; set; }

        [DisplayName("Event Location")]
        public AddressViewModel EventAddress { get; set; }

        public string Vehicle { get; set; }

        [DisplayName("Shipping Option")]
        public IEnumerable<string> ShippingOptions { get; set; }

        [DisplayName("Shipping Cost")]
        [Format("0.00")]
        public decimal ShippingCost { get; set; }

        [DisplayName("Is Paid")]
        public string IsPaid { get; set; }
    }
}
