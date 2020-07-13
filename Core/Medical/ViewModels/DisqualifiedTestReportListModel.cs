using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class DisqualifiedTestReportListModel : ListModelBase<DisqualifiedTestReportViewModel, DisqualifiedTestReportFilter>
    {
        public override IEnumerable<DisqualifiedTestReportViewModel> Collection { get; set; }

        public override DisqualifiedTestReportFilter Filter { get; set; }
    }
}
