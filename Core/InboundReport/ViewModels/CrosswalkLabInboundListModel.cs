using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.InboundReport.ViewModels
{
    public class CrosswalkLabInboundListModel : ListModelBase<CrosswalkLabInboundViewModel, CrosswalkLabInboundFilter>
    {
        public override IEnumerable<CrosswalkLabInboundViewModel> Collection { get; set; }

        public override CrosswalkLabInboundFilter Filter { get; set; }
    }
}
