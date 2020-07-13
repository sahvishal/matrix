using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class CustomTestPerformedListModelFactory : ICustomTestPerformedListModelFactory
    {
        public CustomTestPerformedReportListModel Create(IEnumerable<EventCustomersViewServiceReport> eventCustomerResults, IEnumerable<CustomerEventScreeningTests> customerEventScreeningTests,
            IEnumerable<Event> events, IEnumerable<Customer> customers, IEnumerable<Test> tests)
        {
            var listModel = new CustomTestPerformedReportListModel();
            var collection = new List<CustomTestPerformedViewModel>();
            
            foreach (var customerResult in eventCustomerResults)
            {
                var theEvent = events.First(e => e.Id == customerResult.EventId);
                var customer = customers.First(c => c.CustomerId == customerResult.CustomerId);

                var testids = customerEventScreeningTests.Where(ces => ces.EventCustomerResultId == customerResult.EventCustomerId).Select(x => x.TestId).ToArray();

                var test = tests.Where(t => testids.Contains(t.Id));

                var model = new CustomTestPerformedViewModel
                {
                    CustomerName = customer.NameAsString,
                    CustomerId = customer.CustomerId,
                    DateOfBirth = customer.DateOfBirth,
                    EventDate = theEvent.EventDate,
                    EventId = theEvent.Id,
                    HICN = customer.Hicn,
                    Market = customer.Market,
                    MemberId = customer.InsuranceId,
                    ServicesPerformed = string.Join(", ", test.Select(x => x.Name).ToArray())
                };

                collection.Add(model);
            }

            listModel.Collection = collection;

            return listModel;
        }

    }
}