using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class ConfirmationReportListModel : ListModelBase<ConfirmationReportViewModel, ConfirmationReportFilter>
    {
        public override IEnumerable<ConfirmationReportViewModel> Collection { get; set; }

        public override ConfirmationReportFilter Filter { get; set; }
    }
}
