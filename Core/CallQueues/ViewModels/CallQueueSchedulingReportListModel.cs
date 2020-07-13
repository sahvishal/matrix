using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueSchedulingReportListModel : ListModelBase<CallQueueSchedulingReportModel, CallQueueSchedulingReportFilter>
    {
        public override IEnumerable<CallQueueSchedulingReportModel> Collection { get; set; }

        public override CallQueueSchedulingReportFilter Filter { get; set; }
    }
}