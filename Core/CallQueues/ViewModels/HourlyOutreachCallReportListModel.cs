using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class HourlyOutreachCallReportListModel : ListModelBase<HourlyOutreachCallReportModel, HourlyOutreachCallReportModelFilter>
    {
        public override IEnumerable<HourlyOutreachCallReportModel> Collection { get; set; }

        public override HourlyOutreachCallReportModelFilter Filter { get; set; }
    }
}