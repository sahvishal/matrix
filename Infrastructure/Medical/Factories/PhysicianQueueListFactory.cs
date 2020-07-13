using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PhysicianQueueListFactory : IPhysicianQueueListFactory
    {
        public PhysicianQueueListModel Create(IEnumerable<PhysicianQueueListItem> queue, IEnumerable<OrderedPair<long, string>> physiciansIdNamePair, IEnumerable<EventCustomer> eventCustomers, bool overReadRecords,
                                              IEnumerable<Customer> customers, IEnumerable<Order> orders, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests, IEnumerable<Event> events, IEnumerable<Pod> pods, IEnumerable<PriorityInQueue> priorityInQueues)
        {
            var model = new PhysicianQueueListModel();
            var physicianQueue = new List<PhysicianQueueViewModel>();

            foreach (var item in queue)
            {
                var physicianName = physiciansIdNamePair.Where(p => p.FirstValue == item.PhysicianId).First().SecondValue;
                var eventCustomer = eventCustomers.Where(ec => ec.Id == item.EventCustomerId).First();
                var customer = customers.Where(c => c.CustomerId == eventCustomer.CustomerId).First();
                var eventData = events.Where(e => e.Id == eventCustomer.EventId).First();

                var eventPods = pods.Where(p => eventData.PodIds.Contains(p.Id));
                var podName = !eventPods.IsNullOrEmpty() ? string.Join(", ", eventPods.Select(pod => pod.Name)) : string.Empty;

                var order = orders.Where(o => o.EventId == eventCustomer.EventId && o.CustomerId == eventCustomer.CustomerId).FirstOrDefault();

                var package = order == null ? null : packages.Where(p => p.FirstValue == order.Id).FirstOrDefault();

                var test = order == null ? null : tests.Where(p => p.FirstValue == order.Id).ToList();

                var productPurchased = string.Empty;

                if (package != null && !test.IsNullOrEmpty())
                    productPurchased =
                        package.SecondValue + " + " + string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                else if (!test.IsNullOrEmpty())
                    productPurchased = string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                else if (package != null)
                    productPurchased = package.SecondValue;


                var priorityInqueue = priorityInQueues != null ? priorityInQueues.FirstOrDefault(piq => piq.EventCustomerResultId == item.EventCustomerId) : null;
                var inQueuePriority = priorityInqueue != null ? priorityInqueue.InQueuePriority : (long?)null;

                physicianQueue.Add(new PhysicianQueueViewModel
                                       {
                                           PhysicianName = physicianName,
                                           CustomerId = customer.CustomerId,
                                           CustomerName = customer.Name.FullName,
                                           EventDate = eventData.EventDate,
                                           EventId = eventData.Id,
                                           Package = productPurchased,
                                           PreAuditDate = item.LastUpdatedOn,
                                           IsCritical = item.CriticalMarkedByTechnician,
                                           Vehicle = podName,
                                           SentBackforCorrection = overReadRecords ? item.SentBackbyOverread : item.SentBackbyPrimaryEval,
                                           EventCustomerId = item.EventCustomerId,
                                           InQueuePriority = inQueuePriority
                                       });
            }

            model.Collection = physicianQueue;

            return model;
        }
    }
}