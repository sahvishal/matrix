using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class HospitalPartnerCustomerListModel : ListModelBase<HospitalPartnerCustomerViewModel, HospitalPartnerCustomerListModelFilter>
    {
        public override IEnumerable<HospitalPartnerCustomerViewModel> Collection { get; set; }

        public override HospitalPartnerCustomerListModelFilter Filter { get; set; }

    }
}
