using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;


namespace Falcon.App.Core.Finance.ViewModels
{
    public class DeferredRevenueViewModel : ViewModelBase
    {
        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Name")]
        public string EventName { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; } 

        [DisplayName("Event Address")]
        public AddressViewModel EventAddress { get; set; }

        [DisplayName("Vehicle")]
        public string Pod { get; set; }

        [DisplayName("Total Liability")]
        [Hidden]
        public decimal TotalLiability { get; set; } // Amount Recieved from Customers

        [Hidden]
        public decimal TotalRevenue { get; set; }

        [Hidden]
        public decimal TotalAmountDue { get; set; } 

        public IEnumerable<DeferredRevenueCustomerViewModel> Customers { get; set; }
        
    }
}
