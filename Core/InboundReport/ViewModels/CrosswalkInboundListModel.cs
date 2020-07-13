using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.InboundReport.ViewModels
{
    public class CrosswalkInboundListModel : ListModelBase<CrosswalkInboundViewModel, CrosswalkInboundFilter>
    {
        public override IEnumerable<CrosswalkInboundViewModel> Collection { get; set; }

        public override CrosswalkInboundFilter Filter { get; set; }
    }
}
