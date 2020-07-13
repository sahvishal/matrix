using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class EventArchiveStatsListModel : ListModelBase<EventArchiveStatsViewModel, EventArchiveStatsFilter>
    {
        public override IEnumerable<EventArchiveStatsViewModel> Collection { get; set; }

        public override EventArchiveStatsFilter Filter { get; set; }
    }
}
