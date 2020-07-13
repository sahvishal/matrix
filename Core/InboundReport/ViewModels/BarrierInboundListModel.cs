using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.InboundReport.ViewModels
{
    public class BarrierInboundListModel : ListModelBase<BarrierInboundViewModel, BarrierInboundFilter>
    {
        public override IEnumerable<BarrierInboundViewModel> Collection { get; set; }

        public override BarrierInboundFilter Filter { get; set; }
    }
}
