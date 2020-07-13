using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class BcbsMiPcpResultMailedReportListModel : ListModelBase<BcbsMiPcpResultMailedReportModel, PcpResultMailedReportModelFilter>
    {
        public override IEnumerable<BcbsMiPcpResultMailedReportModel> Collection { get; set; }

        public override PcpResultMailedReportModelFilter Filter { get; set; }
    }
}
