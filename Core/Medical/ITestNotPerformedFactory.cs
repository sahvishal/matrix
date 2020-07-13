using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ITestNotPerformedFactory
    {
        TestNotPerformedListModel Create(IEnumerable<TestNotPerformed> testNotPerformedLists, IEnumerable<CustomerEventScreeningTests> customerEventScreeningTests, IEnumerable<EventCustomerResult> eventCustomerResults,
            IEnumerable<Event> events, IEnumerable<Customer> customers, IEnumerable<Test> tests, IEnumerable<OrderedPair<long, long>> customersPreApprovedTestIds, IEnumerable<CorporateAccount> accounts,
            IEnumerable<Pod> pods, IEnumerable<CustomerEventTestState> customerEventTestStates, IEnumerable<OrderedPair<long, string>> idNamePairs, IEnumerable<OrderedPair<long, long>> staffOrgRoleUserEventsPair,
            IEnumerable<OrderedPair<long, string>> staffNamePairs, IEnumerable<Host> eventHosts, IEnumerable<EventCustomer> eventCustomers);
    }
}