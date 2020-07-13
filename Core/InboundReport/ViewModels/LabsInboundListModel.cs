using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.InboundReport.ViewModels
{
    public class LabsInboundListModel : ListModelBase<LabsInboundViewModel, LabsInboundFilter>
    {
        public override IEnumerable<LabsInboundViewModel> Collection { get; set; }

        public override LabsInboundFilter Filter { get; set; }
    }
}
