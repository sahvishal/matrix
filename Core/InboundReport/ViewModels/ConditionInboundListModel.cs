using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.InboundReport.ViewModels
{
    public class ConditionInboundListModel : ListModelBase<ConditionInboundViewModel, ConditionInboundFilter>
    {
        public override IEnumerable<ConditionInboundViewModel> Collection { get; set; }

        public override ConditionInboundFilter Filter { get; set; }
    }
}
