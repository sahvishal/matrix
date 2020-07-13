using System;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventSummaryViewModel
    {
        public long EventId { get; set; }

        [DisplayName("Location")]
        public AddressViewModel HostAddress { get; set; }

        [DisplayName("Date")]
        public DateTime EventDate { get; set; }
        public int TotalCustomers { get; set; }
        public int ScreenedCustomers { get; set; }
        public int NoShowCustomers { get; set; }
        public int CancelledCustomers { get; set; }

        public ListModelBase<HospitalPartnerCustomerViewModel, HospitalPartnerCustomerListModelFilter> Customers { get; set; }
    }
}
