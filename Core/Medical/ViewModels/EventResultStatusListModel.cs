using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class EventResultStatusListModel : ListModelBase<EventResultStatusViewModel, EventResultStatusViewModelFilter>
    {
        public override IEnumerable<EventResultStatusViewModel> Collection { get; set; }

        public override EventResultStatusViewModelFilter Filter { get; set; }

    }
}
