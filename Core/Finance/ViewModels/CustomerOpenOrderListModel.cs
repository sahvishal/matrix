using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class CustomerOpenOrderListModel : ListModelBase<CustomerOpenOrderViewModel, CustomerOpenOrderListModelFilter>
    {
        public override IEnumerable<CustomerOpenOrderViewModel> Collection
        {
            get;
            set;
        }

        public override CustomerOpenOrderListModelFilter Filter
        {
            get;
            set;
        }
    }
}
