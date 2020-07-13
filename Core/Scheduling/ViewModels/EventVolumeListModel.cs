using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventVolumeListModel : ListModelBase<EventVolumeModel, EventVolumeListModelFilter>
    {
        public override IEnumerable<EventVolumeModel> Collection { get; set; }
        public override EventVolumeListModelFilter Filter { get; set; }
    }
}