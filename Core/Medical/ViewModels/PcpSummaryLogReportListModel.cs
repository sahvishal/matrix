using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PcpSummaryLogReportListModel : ListModelBase<PcpSummaryLogReportModel, PcpSummaryLogReportModelFilter>
    {
        public override IEnumerable<PcpSummaryLogReportModel> Collection { get; set; }

        public override PcpSummaryLogReportModelFilter Filter { get; set; }

    }
}
