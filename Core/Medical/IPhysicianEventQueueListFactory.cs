using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IPhysicianEventQueueListFactory
    {
        PhysicianEventQueueListModel Create(IEnumerable<PhysicianEventQueueListItem> eventQueueListItems,
                                            IEnumerable<OrderedPair<long, string>> physiciansIdNamePairs,
                                            IEnumerable<Event> events, IEnumerable<Pod> pods);
    }
}
