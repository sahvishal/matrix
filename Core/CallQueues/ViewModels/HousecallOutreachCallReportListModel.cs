using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class HousecallOutreachCallReportListModel : ListModelBase<HousecallOutreachReportModel, OutreachCallReportModelFilter>
    {
        public override IEnumerable<HousecallOutreachReportModel> Collection { get; set; }

        public override OutreachCallReportModelFilter Filter { get; set; }
    }
}
