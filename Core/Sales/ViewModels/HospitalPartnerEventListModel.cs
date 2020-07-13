using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class HospitalPartnerEventListModel : ListModelBase<HospitalPartnerEventViewModel,HospitalPartnerEventListModelFilter>
    {
        public override IEnumerable<HospitalPartnerEventViewModel> Collection { get; set; }
        public override HospitalPartnerEventListModelFilter Filter { get; set; }
    }
}
