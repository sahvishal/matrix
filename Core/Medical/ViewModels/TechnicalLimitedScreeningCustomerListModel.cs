using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class TechnicalLimitedScreeningCustomerListModel : ListModelBase<TechnicalLimitedScreeningCustomerViewModel, TechnicalLimitedScreeningCustomerListModelFilter>
    {
        public override IEnumerable<TechnicalLimitedScreeningCustomerViewModel> Collection { get; set; }
        public override TechnicalLimitedScreeningCustomerListModelFilter Filter
        {
            get;
            set;
        }
    }
}