
using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;
namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueExcludedCustomerReportListModel : ListModelBase<CallQueueExcludedCustomerReportModel, CallQueueExcludedCustomerReportModelFilter>
    {
        public override IEnumerable<CallQueueExcludedCustomerReportModel> Collection { get; set; }

        public override CallQueueExcludedCustomerReportModelFilter Filter { get; set; }
    }
}
