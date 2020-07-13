using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueReportListModel : ListModelBase<CallQueueReportModel, CallQueueReportModelFilter>
    {
        public override IEnumerable<CallQueueReportModel> Collection { get; set; }
        public override CallQueueReportModelFilter Filter { get; set; }
    }
}
