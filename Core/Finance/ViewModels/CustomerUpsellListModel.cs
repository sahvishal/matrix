using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class CustomerUpsellListModel : ListModelBase<CustomerUpsellModel, CustomerUpsellListModelFilter> {
        public override IEnumerable<CustomerUpsellModel> Collection { get; set; }
        public override CustomerUpsellListModelFilter Filter { get; set; }
    }
}