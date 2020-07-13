using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class NonTargetableReportListModel : ListModelBase<NonTargetableReportModel, NonTargetableReportModelFilter>
    {
        public override IEnumerable<NonTargetableReportModel> Collection { get; set; }

        public override NonTargetableReportModelFilter Filter { get; set; }
    }
}
