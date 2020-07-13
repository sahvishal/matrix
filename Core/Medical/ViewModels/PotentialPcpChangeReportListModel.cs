using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PotentialPcpChangeReportListModel : ListModelBase<PotentialPcpChangeReportViewModel, PotentialPcpChangeReportModelFilter>
    {
        public override IEnumerable<PotentialPcpChangeReportViewModel> Collection { get; set; }

        public override PotentialPcpChangeReportModelFilter Filter { get; set; }
    }
}
