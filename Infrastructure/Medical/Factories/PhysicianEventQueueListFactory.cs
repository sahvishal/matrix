using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;


namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PhysicianEventQueueListFactory : IPhysicianEventQueueListFactory
    {
        public PhysicianEventQueueListModel Create(IEnumerable<PhysicianEventQueueListItem> eventQueueListItems, IEnumerable<OrderedPair<long, string>> physiciansIdNamePairs, IEnumerable<Event> events, IEnumerable<Pod> pods)
        {
            var model = new PhysicianEventQueueListModel();
            var collection = new List<PhysicianEventQueueViewModel>();

            foreach (var item in eventQueueListItems)
            {
                var physicianName = physiciansIdNamePairs.Where(p => p.FirstValue == item.PhysicianId).First().SecondValue;
                var eventData = events.Where(e => e.Id == item.EventId).First();
                var eventPods = pods.Where(p => eventData.PodIds.Contains(p.Id));
                var podName = !eventPods.IsNullOrEmpty() ? string.Join(", ", eventPods.Select(pod => pod.Name)) : string.Empty;

                collection.Add(new PhysicianEventQueueViewModel()
                                   {
                                       PhysicianName = physicianName,
                                       EventId = eventData.Id,
                                       EventDate = eventData.EventDate,
                                       EventName = eventData.Name,
                                       Vehicle = podName,
                                       CustomersInQueue = item.CustomersInQueue,
                                       PhysicianId = item.PhysicianId
                                   });
            }

            model.Collection = collection;
            return model;
        }
    }
}
