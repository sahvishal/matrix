using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventListGmsListModel : ListModelBase<EventListGmsModel, EventListGmsModelFilter>
    {
        public override IEnumerable<EventListGmsModel> Collection { get; set; }

        public override EventListGmsModelFilter Filter { get; set; }
    }
}
