using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class ShippingRevenueDetailListModel : ListModelBase<ShippingRevenueDetailViewModel, ShippingRevenueListModelFilter>
    {
        public override IEnumerable<ShippingRevenueDetailViewModel> Collection { get; set; }

        public override ShippingRevenueListModelFilter Filter { get; set; }
    }
}
