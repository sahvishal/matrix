using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class GmsCallQueueCustomerListModel : ListModelBase<GmsCallQueueCustomerViewModel, OutboundCallQueueFilter>
    {
        public override IEnumerable<GmsCallQueueCustomerViewModel> Collection { get; set; }

        public override OutboundCallQueueFilter Filter { get; set; }
    }
}
