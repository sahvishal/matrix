using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class ActualCustomerShowedListModel : ListModelBase<ActualCustomerShowedViewModel, PayPeriodBookedCustomerFilter>
    {
        public override IEnumerable<ActualCustomerShowedViewModel> Collection { get; set; }
        public override PayPeriodBookedCustomerFilter Filter { get; set; }

        public string RegisteredBy { get; set; }
    }
}