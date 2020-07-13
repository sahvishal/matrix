using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventScheduleListModel : ListModelBase<EventScheduleModel, EventScheduleListModelFilter>
    {
        public override IEnumerable<EventScheduleModel> Collection { get; set; }
        public override EventScheduleListModelFilter Filter { get; set; }
    }
}