using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PcpResultMailedReportListModel : ListModelBase<PcpResultMailedReportModel, PcpResultMailedReportModelFilter>
    {
        public override IEnumerable<PcpResultMailedReportModel> Collection { get; set; }

        public override PcpResultMailedReportModelFilter Filter { get; set; }
    }
}
