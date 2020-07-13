using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventNotesListModel : ListModelBase<EventNotesViewModel, EventNotesModelFilter>
    {
        public override IEnumerable<EventNotesViewModel> Collection { get; set; }
        public override EventNotesModelFilter Filter { get; set; }
    }
}
