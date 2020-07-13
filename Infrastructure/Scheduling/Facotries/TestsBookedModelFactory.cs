using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core; 
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class TestsBookedModelFactory : ITestsBookedModelFactory
    {
        private readonly IHostRepository _hostRepository;

        public TestsBookedModelFactory(IHostRepository hostRepository)
        { 
            _hostRepository = hostRepository;
        }
        public TestsBookedListModel Create(IEnumerable<OrderedPair<long, long>> eventCustomerTestOrderedPairs, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Event> events,   IEnumerable<Customer> customers,
                                                    IEnumerable<Pod> pods, IEnumerable<Test> tests)
        {
            var model = new TestsBookedListModel();
            var appointmentsBookedModels = new List<TestsBookedModel>();
            var eventIds = eventCustomers.Select(ec => ec.EventId).Distinct().ToArray();
            var hosts = _hostRepository.GetEventHosts(eventIds);

            eventCustomerTestOrderedPairs.ToList().ForEach(ect =>
                                                {
                                                    var ec = eventCustomers.FirstOrDefault(o => o.Id == ect.FirstValue); 

                                                   
                                                    var theEvent = events.FirstOrDefault(o => o.Id == ec.EventId); 
                                                  
                                                    var customer = customers.FirstOrDefault(c => c.CustomerId == ec.CustomerId);

                                                    var testNames = tests.Where(x => x.Id == ect.SecondValue).First().Name;

                                                           
                                                    var podNames = (theEvent.PodIds != null && theEvent.PodIds.Count() > 0) ? string.Join(", ", pods.Where(p => theEvent.PodIds.Contains(p.Id)).Select(p => p.Name)) : string.Empty;

                                                    var host = hosts.First(h => h.Id == theEvent.HostId);
                                                    
                                                    var testModel = new TestsBookedModel
                                                                        { 
                                                                            CustomerId = ec.CustomerId,
                                                                            CustomerName = customer.NameAsString,
                                                                            EventName = host.OrganizationName,
                                                                            EventDate = theEvent.EventDate,
                                                                            EventId = ec.EventId,
                                                                            TestName = testNames,
                                                                            PodName = podNames 
                                                                        };


                                                    appointmentsBookedModels.Add(testModel);
                                                });
             

            model.Collection = appointmentsBookedModels;
            return model;
        }
    }
}
