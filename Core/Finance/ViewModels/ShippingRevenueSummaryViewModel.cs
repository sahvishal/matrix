using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class ShippingRevenueSummaryViewModel : ViewModelBase
    {
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

        [DisplayName("Total Shipping Purchased")]
        public int ShippingCount { get; set; }

        [Format("0.00")]
        public decimal Revenue { get; set; }
    }
}
