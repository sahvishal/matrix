using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class DeferredRevenueListModel : ListModelBase<DeferredRevenueViewModel, DeferredRevenueListModelFilter>
    {
        public override IEnumerable<DeferredRevenueViewModel> Collection
        {
            get; set;
        }

        public override DeferredRevenueListModelFilter Filter
        {
            get; set;
        }
    }
}
