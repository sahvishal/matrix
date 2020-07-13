using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class OutreachCallReportListModel : ListModelBase<OutreachCallReportModel, OutreachCallReportModelFilter>
    {
        public override IEnumerable<OutreachCallReportModel> Collection { get; set; }

        public override OutreachCallReportModelFilter Filter { get; set; }
    }
}
