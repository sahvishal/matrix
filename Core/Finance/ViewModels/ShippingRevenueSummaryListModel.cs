using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class ShippingRevenueSummaryListModel : ListModelBase<ShippingRevenueSummaryViewModel, ShippingRevenueListModelFilter>
    {
        public override IEnumerable<ShippingRevenueSummaryViewModel> Collection { get; set; }

        public override ShippingRevenueListModelFilter Filter { get; set; }
    }
}
