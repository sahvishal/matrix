using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class PcpTrackingReportListModel : ListModelBase<PcpTrackingReportViewModel,PcpTrackingReportFilter>
    {
        public override IEnumerable<PcpTrackingReportViewModel> Collection { get; set; }

        public override PcpTrackingReportFilter Filter { get; set; }
    }
}
