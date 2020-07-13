using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class TestNotPerformedFactory : ITestNotPerformedFactory
    {
        public TestNotPerformedListModel Create(IEnumerable<TestNotPerformed> testNotPerformedLists, IEnumerable<CustomerEventScreeningTests> customerEventScreeningTests, IEnumerable<EventCustomerResult> eventCustomerResults,
            IEnumerable<Event> events, IEnumerable<Customer> customers, IEnumerable<Test> tests, IEnumerable<OrderedPair<long, long>> customersPreApprovedTestIds, IEnumerable<CorporateAccount> accounts,
            IEnumerable<Pod> pods, IEnumerable<CustomerEventTestState> customerEventTestStates, IEnumerable<OrderedPair<long, string>> idNamePairs, IEnumerable<OrderedPair<long, long>> staffOrgRoleUserEventsPair,
            IEnumerable<OrderedPair<long, string>> staffNamePairs, IEnumerable<Host> eventHosts, IEnumerable<EventCustomer> eventCustomers)
        {

            var listModel = new TestNotPerformedListModel();
            var collection = new List<TestNotPerformedViewModel>();

            foreach (var testNotPerformed in testNotPerformedLists)
            {
                var customerEventScreeningTest = customerEventScreeningTests.Single(ces => ces.Id == testNotPerformed.CustomerEventScreeningTestId);

                var eventCustomerResult = eventCustomerResults.First(ecr => ecr.Id == customerEventScreeningTest.EventCustomerResultId);

                var eventCustomer = eventCustomers.First(ec => ec.Id == customerEventScreeningTest.EventCustomerResultId);

                var theEvent = events.First(e => e.Id == eventCustomerResult.EventId);
                var customer = customers.First(c => c.CustomerId == eventCustomerResult.CustomerId);
                var test = tests.First(t => t.Id == customerEventScreeningTest.TestId);
                var host = eventHosts.First(x => x.Id == theEvent.HostId);
                var customerEventTestState = customerEventTestStates.Single(x => x.CustomerEventScreeningTestId == testNotPerformed.CustomerEventScreeningTestId);


                var customerTestIds = customersPreApprovedTestIds.Any(x => x.FirstValue == eventCustomerResult.Id && x.SecondValue == test.Id);
                var podNames = (theEvent.PodIds != null && theEvent.PodIds.Count() > 0) ? string.Join(", ", pods.Where(p => theEvent.PodIds.Contains(p.Id)).Select(p => p.Name)) : string.Empty;

                var conductedByPair = idNamePairs.Single(x => x.FirstValue == customerEventTestState.ConductedByOrgRoleUserId.Value);

                var conductedBy = string.Empty;

                if (conductedByPair != null)
                {
                    conductedBy = conductedByPair.SecondValue;
                }
                var organizationName = string.Empty;


                //if (!string.IsNullOrEmpty(customer.Tag) && (accounts != null && accounts.Any()))
                if (theEvent.AccountId.HasValue && theEvent.AccountId > 0 && (accounts != null && accounts.Any()))
                {
                    //var account = accounts.SingleOrDefault(x => x.Tag == customer.Tag);

                    var account = accounts.SingleOrDefault(x => x.Id == theEvent.AccountId);

                    if (account != null)
                    {
                        organizationName = account.Name;
                    }
                }

                var providers = string.Empty;
                if (staffOrgRoleUserEventsPair != null && staffOrgRoleUserEventsPair.Any())
                {
                    var staffOrgRoleUserEventPair = staffOrgRoleUserEventsPair.Where(x => x.SecondValue == theEvent.Id).ToArray();

                    if (staffOrgRoleUserEventPair != null && staffOrgRoleUserEventPair.Any())
                    {
                        var orgIds = staffOrgRoleUserEventPair.Select(x => x.FirstValue);

                        var assignedNPs = staffNamePairs.Where(x => orgIds.Contains(x.FirstValue)).ToArray();

                        if (assignedNPs != null && assignedNPs.Any())
                        {
                            providers = string.Join(", ", assignedNPs.Select(x => x.SecondValue));
                        }
                    }
                }

                var model = new TestNotPerformedViewModel
                {
                    CustomerId = customer.CustomerId,
                    EventId = theEvent.Id,
                    EventDate = theEvent.EventDate,
                    CustomerName = customer.Name.FullName,
                    MemberId = customer.InsuranceId,
                    Notes = string.IsNullOrEmpty(testNotPerformed.Notes) ? "N/A" : testNotPerformed.Notes,
                    Reason = ((TestNotPerformedReasonType)testNotPerformed.TestNotPerformedReasonId).GetDescription(),
                    TestName = test.Name,
                    HealthPlan = organizationName,
                    IsPreApprovedTest = customerTestIds ? "Yes" : "No",
                    EventName = theEvent.Name,
                    PodName = podNames,
                    TechnicianName = conductedBy,
                    ProviderName = providers,
                    State = host.Address.State,
                    IsOverride = eventCustomer.SingleTestOverride ? "Yes" : "No"
                };
                collection.Add(model);
            }

            listModel.Collection = collection;
            return listModel;
        }
    }
}