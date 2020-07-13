using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class PayPeriodListModel : ListModelBase<PayPeriodViewModel, PayPeriodFilter>
    {
        public override IEnumerable<PayPeriodViewModel> Collection
        {
            get;
            set;
        }

        public override PayPeriodFilter Filter
        {
            get;
            set;
        }
    }
}