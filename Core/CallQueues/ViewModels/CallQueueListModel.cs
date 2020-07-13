using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueListModel : ListModelBase<CallQueueViewModel, CallQueueListModelFilter>
    {
        public override IEnumerable<CallQueueViewModel> Collection { get; set; }

        public override CallQueueListModelFilter Filter { get; set; }
    }
}
