using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallSkippedReportListModel : ListModelBase<CallSkippedReportViewModel, CallSkippedReportFilter>
    {
        public override IEnumerable<CallSkippedReportViewModel> Collection { get; set; }
        public override CallSkippedReportFilter Filter { get; set; }

        //[IgnoreAudit]
        //public PagingModel PagingModel { get; set; }
    }
}
