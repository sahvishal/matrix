using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class CorporateAccountCustomerListModel : ListModelBase<CorporateAccountCustomerViewModel, CorporateAccountCustomerListModelFilter>
    {
        public override IEnumerable<CorporateAccountCustomerViewModel> Collection { get; set; }
        public override CorporateAccountCustomerListModelFilter Filter { get; set; }

        public long EventId { get; set; }

        [DisplayName("Location")]
        public AddressViewModel HostAddress { get; set; }

        [DisplayName("Date")]
        public DateTime EventDate { get; set; }
        public int TotalCustomers { get; set; }
        public int ScreenedCustomers { get; set; }
        public int NoShowCustomers { get; set; }
        public int CancelledCustomers { get; set; }
    }
}
