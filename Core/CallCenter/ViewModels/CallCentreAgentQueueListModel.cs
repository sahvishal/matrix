using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallCentreAgentQueueListModel
    {
        public IEnumerable<CallCentreAgentQueueListViewModel> Collection { get; set; }
        public CallCentreAgentQueueFilter Filter { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }

        public IEnumerable<HealthPlanDropDownView> HealthPlanList { get; set; }
        public IEnumerable<CallQueueCategoryViewModel> CallQueuesList { get; set; }
    }
}
