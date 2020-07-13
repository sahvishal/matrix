using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ICustomTestPerformedListModelFactory
    {
        CustomTestPerformedReportListModel Create(IEnumerable<EventCustomersViewServiceReport> eventCustomerResults, IEnumerable<CustomerEventScreeningTests> customerEventScreeningTests,
            IEnumerable<Event> events, IEnumerable<Customer> customers, IEnumerable<Test> tests);
    }
}