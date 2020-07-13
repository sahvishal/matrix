using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class PreAssessmentReportListModel : ListModelBase<PreAssessmentReportViewModel, PreAssessmentReportFilter>
    {
        public override IEnumerable<PreAssessmentReportViewModel> Collection { get; set; }

        public override PreAssessmentReportFilter Filter { get; set; }
    }
}
