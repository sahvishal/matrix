using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class GmsExcludedCustomerListModel : ListModelBase<GmsExcludedCustomerViewModel, OutboundCallQueueFilter>
    {
        public override IEnumerable<GmsExcludedCustomerViewModel> Collection { get; set; }

        public override OutboundCallQueueFilter Filter { get; set; }
    }
}
