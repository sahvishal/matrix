using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ITestPerformedListModelFactory
    {
        TestPerformedListModel Create(IEnumerable<VwGetTestPerformedReport> customerEventTestStates, IEnumerable<CustomerEventScreeningTests> customerEventScreeningTests, IEnumerable<EventCustomerResult> eventCustomerResults,
            IEnumerable<Event> events, IEnumerable<Customer> customers, IEnumerable<Test> tests, IEnumerable<OrderedPair<long, string>> idNamePairs, IEnumerable<Pod> pods, IEnumerable<OrderedPair<long, long>> preApprovedTests,
            IEnumerable<CorporateAccount> accounts, IEnumerable<OrderedPair<long, string>> physicianIdNamePairs, IEnumerable<PhysicianCustomerAssignment> customerPhysicians,
            IEnumerable<PhysicianEventAssignment> eventsPhysicians, IEnumerable<CustomerSkipReview> customerSkiped, IEnumerable<Host> eventHosts, IEnumerable<CorporateAccount> corporateAccounts,
            IEnumerable<AccountAdditionalFields> accountAdditionalFields, IEnumerable<EventCustomerRetest> retests, IEnumerable<EventCustomer> eventCustomers);
    }
}
