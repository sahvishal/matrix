using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class GoogleAnalyticsEnableReportingDataModel
    {
        public AddressViewModel Address { get; set; }

        public long CustomerId { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal Shipping { get; set; }

        public EventPackage EventPackage { get; set; }

        public IEnumerable<EventTest> EventTests { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
