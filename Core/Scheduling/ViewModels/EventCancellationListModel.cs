using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventCancellationListModel : ListModelBase<EventCancellationModel, EventCancellationModelFilter>
    {
        public override IEnumerable<EventCancellationModel> Collection { get; set; }
        public override EventCancellationModelFilter Filter { get; set; }
    }
}
