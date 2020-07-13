using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class DailyVolumeListModel : ListModelBase<DailyVolumeModel, DailyVolumeListModelFilter>
    {
        public override IEnumerable<DailyVolumeModel> Collection { get; set; }
        public override DailyVolumeListModelFilter Filter { get; set; }
    }
}