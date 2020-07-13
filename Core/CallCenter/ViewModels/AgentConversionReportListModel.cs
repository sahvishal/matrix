using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class AgentConversionReportListModel : ListModelBase<AgentConversionReportViewModel, AgentConversionReportFilter>
    {
        public override IEnumerable<AgentConversionReportViewModel> Collection { get; set; }
        public override AgentConversionReportFilter Filter { get; set; }
    }
}
