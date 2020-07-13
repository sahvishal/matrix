using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.InboundReport.ViewModels
{
    public class InterviewInboundListModel : ListModelBase<InterviewInboundViewModel, InterviewInboundFilter>
    {
        public override IEnumerable<InterviewInboundViewModel> Collection { get; set; }

        public override InterviewInboundFilter Filter { get; set; }
    }
}
