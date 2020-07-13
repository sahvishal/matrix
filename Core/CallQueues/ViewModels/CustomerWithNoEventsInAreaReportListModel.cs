using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CustomerWithNoEventsInAreaReportListModel : ListModelBase<CustomerWithNoEventsInAreaReportModel, CustomerWithNoEventsInAreaReportModelFilter>
    {
        public override IEnumerable<CustomerWithNoEventsInAreaReportModel> Collection { get; set; }

        public override CustomerWithNoEventsInAreaReportModelFilter Filter { get; set; }
    }
}
