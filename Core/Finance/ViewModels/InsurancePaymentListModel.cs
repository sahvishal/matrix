using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class InsurancePaymentListModel : ListModelBase<InsurancePaymentViewModel, InsurancePaymentListModelFilter>
    {
        public override IEnumerable<InsurancePaymentViewModel> Collection { get; set; }
        public override InsurancePaymentListModelFilter Filter { get; set; }
    }
}
