using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class CustomTestPerformedReportListModel : ListModelBase<CustomTestPerformedViewModel, CustomTestPerformedReportFilter>
    {
        public override IEnumerable<CustomTestPerformedViewModel> Collection { get; set; }

        public override CustomTestPerformedReportFilter Filter { get; set; }
    }
}