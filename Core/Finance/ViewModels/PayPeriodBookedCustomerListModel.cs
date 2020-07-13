using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class PayPeriodBookedCustomerListModel : ListModelBase<PayPeriodBookedCustomerViewModel, PayPeriodBookedCustomerFilter>
    {
        public override IEnumerable<PayPeriodBookedCustomerViewModel> Collection { get; set; }
        public override PayPeriodBookedCustomerFilter Filter { get; set; }

        public string RegisteredBy { get; set; }
    }
}