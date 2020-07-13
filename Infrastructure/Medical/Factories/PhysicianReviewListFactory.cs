using System;
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
    public class PhysicianReviewListFactory : IPhysicianReviewListFactory
    {
        public PhysicianReviewListModel Create(IEnumerable<PhysicianEvaluation> evaluations, IEnumerable<OrderedPair<long, string>> physiciansIdNamePair, IEnumerable<EventCustomer> eventCustomers,
            IEnumerable<Customer> customers, IEnumerable<Order> orders, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests, IEnumerable<OrderedPair<long, long>> criticalEventIdCustomerIdPair,
            IEnumerable<Event> events, IEnumerable<OrderedPair<long, long>> pdfGeneratedEventIdCustomerIdPair, IEnumerable<Pod> pods, IEnumerable<long> halfStudyEventCustomerIds, IEnumerable<long> evaluationPendingEventCustomerIds)
        {
            var model = new PhysicianReviewListModel();
            var physicianReviews = new List<PhysicianReviewViewModel>();

            evaluations.ToList().ForEach(ev =>
                                             {
                                                 var physicianName = physiciansIdNamePair.Where(p => p.FirstValue == ev.PhysicianId).First().SecondValue;

                                                 var eventCustomer = eventCustomers.Where(ec => ec.Id == ev.EventCustomerId).First();

                                                 var customer = customers.Where(c => c.CustomerId == eventCustomer.CustomerId).First();

                                                 var eventData = events.Where(e => e.Id == eventCustomer.EventId).First();

                                                 var eventPods = pods.Where(p => eventData.PodIds.Contains(p.Id));

                                                 var podName = !eventPods.IsNullOrEmpty() ? string.Join(", ", eventPods.Select(pod => pod.Name)) : string.Empty;

                                                 var order = orders.Where(o => o.EventId == eventCustomer.EventId && o.CustomerId == eventCustomer.CustomerId).FirstOrDefault();

                                                 var package = order == null ? null : packages.Where(p => p.FirstValue == order.Id).FirstOrDefault();

                                                 var test = order == null ? null : tests.Where(p => p.FirstValue == order.Id).ToList();

                                                 var productPurchased = string.Empty;

                                                 if (package != null && !test.IsNullOrEmpty())
                                                     productPurchased = package.SecondValue + " + " + string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                                                 else if (!test.IsNullOrEmpty())
                                                     productPurchased = string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                                                 else if (package != null)
                                                     productPurchased = package.SecondValue;

                                                 var critical = criticalEventIdCustomerIdPair.Where(c => c.FirstValue == eventCustomer.EventId && c.SecondValue == eventCustomer.CustomerId).FirstOrDefault();

                                                 var pdfGenerated = pdfGeneratedEventIdCustomerIdPair.Where(pg => pg.FirstValue == eventCustomer.EventId && pg.SecondValue == eventCustomer.CustomerId).FirstOrDefault();

                                                 var reviewDuration = TimeSpan.FromSeconds(ev.EvaluationEndTime.Value.Subtract(ev.EvaluationStartTime).TotalSeconds);

                                                 var study = "Full";

                                                 var halfStudyEventCustomerId = halfStudyEventCustomerIds.Where(hsec => hsec == ev.EventCustomerId).Select(hsec => hsec).FirstOrDefault();
                                                 if (halfStudyEventCustomerId > 0)
                                                     study = "Half";
                                                 else
                                                 {
                                                     var evaluationPendingEventCustomerId = evaluationPendingEventCustomerIds.Where(epec => epec ==ev.EventCustomerId).Select(epec=>epec).FirstOrDefault();
                                                     if (evaluationPendingEventCustomerId > 0)
                                                         study = "Half";
                                                 }

                                                 physicianReviews.Add(new PhysicianReviewViewModel
                                                                          {
                                                                              PhysicianName = physicianName,
                                                                              CustomerId = customer.CustomerId,
                                                                              CustomerName = customer.Name.FullName,
                                                                              EventDate = eventData.EventDate,
                                                                              EventId = eventData.Id,
                                                                              Package = productPurchased,
                                                                              ReviewDate = ev.EvaluationStartTime,
                                                                              ReviewDuration = string.Format("{0:D2}min {1:D2}sec", reviewDuration.Minutes, reviewDuration.Seconds),
                                                                              IsCritical = critical != null ? true : false,
                                                                              IsPdfGenerated = pdfGenerated != null ? true : false,
                                                                              Vehicle = podName,
                                                                              Study = study
                                                                          });
                                             });

            model.Collection = physicianReviews;

            return model;
        }
    }
}
