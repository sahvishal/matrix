using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class KynCustomerListModel : ListModelBase<KynCustomerModel, KynCustomerModelFilter>
    {
        public override IEnumerable<KynCustomerModel> Collection { get; set; }
        public override KynCustomerModelFilter Filter { get; set; }
    }
}
