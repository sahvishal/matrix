using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class TestPerformedListModelFactory : ITestPerformedListModelFactory
    {
        public TestPerformedListModel Create(IEnumerable<VwGetTestPerformedReport> customerEventTestStates, IEnumerable<CustomerEventScreeningTests> customerEventScreeningTests, IEnumerable<EventCustomerResult> eventCustomerResults,
            IEnumerable<Event> events, IEnumerable<Customer> customers, IEnumerable<Test> tests, IEnumerable<OrderedPair<long, string>> idNamePairs, IEnumerable<Pod> pods, IEnumerable<OrderedPair<long, long>> preApprovedTests,
            IEnumerable<CorporateAccount> accounts, IEnumerable<OrderedPair<long, string>> physicianIdNamePairs, IEnumerable<PhysicianCustomerAssignment> customerPhysicians,
            IEnumerable<PhysicianEventAssignment> eventsPhysicians, IEnumerable<CustomerSkipReview> customerSkiped, IEnumerable<Host> eventHosts, IEnumerable<CorporateAccount> corporateAccounts,
            IEnumerable<AccountAdditionalFields> accountAdditionalFields, IEnumerable<EventCustomerRetest> retests, IEnumerable<EventCustomer> eventCustomers)
        {
            var listModel = new TestPerformedListModel();
            var collection = new List<TestPerformedViewModel>();

            foreach (var customerEventTestState in customerEventTestStates)
            {
                var customerEventScreeningTest = customerEventScreeningTests.Single(ces => ces.Id == customerEventTestState.CustomerEventScreeningTestId);
                var eventCustomerResult = eventCustomerResults.First(ecr => ecr.Id == customerEventScreeningTest.EventCustomerResultId);
                var eventCustomer = eventCustomers.First(ec => ec.Id == customerEventScreeningTest.EventCustomerResultId);
                var theEvent = events.First(e => e.Id == eventCustomerResult.EventId);
                var customer = customers.First(c => c.CustomerId == eventCustomerResult.CustomerId);
                var test = tests.First(t => t.Id == customerEventScreeningTest.TestId);
                var idNamePair = idNamePairs.First(inp => inp.FirstValue == customerEventTestState.ConductedByOrgRoleUserId);
                var isTestPreApproved = preApprovedTests.Any(x => x.FirstValue == eventCustomerResult.Id && x.SecondValue == test.Id);
                var host = eventHosts.First(x => x.Id == theEvent.HostId);
                var podNames = (theEvent.PodIds != null && theEvent.PodIds.Count() > 0) ? string.Join(", ", pods.Where(p => theEvent.PodIds.Contains(p.Id)).Select(p => p.Name)) : string.Empty;

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
                var physicianName = string.Empty;
                var overReadPhysicianName = string.Empty;
                if (customerEventTestState.EvaluationState >= (int)TestResultStateNumber.Evaluated)
                {
                    var skipedcustomer = customerSkiped.Where(m => m.EventCustomerId == eventCustomerResult.Id).FirstOrDefault();
                    if (skipedcustomer == null)
                    {
                        var physicianDetail = customerPhysicians.Where(x => x.EventCustomerId == eventCustomerResult.Id).FirstOrDefault();
                        if (physicianDetail != null)
                        {
                            physicianName = physicianIdNamePairs.First(x => x.FirstValue == physicianDetail.PhysicianId).SecondValue;
                            if (physicianDetail.OverReadPhysicianId.HasValue)
                                overReadPhysicianName = physicianIdNamePairs.First(x => x.FirstValue == physicianDetail.OverReadPhysicianId.Value).SecondValue;
                        }
                        else
                        {
                            var eventPhysician = eventsPhysicians.Where(x => x.EventId == theEvent.Id).FirstOrDefault();
                            if (eventPhysician != null)
                            {
                                physicianName = physicianIdNamePairs.First(x => x.FirstValue == eventPhysician.PhysicianId).SecondValue;
                                if (eventPhysician.OverReadPhysicianId.HasValue)
                                    overReadPhysicianName = physicianIdNamePairs.First(x => x.FirstValue == eventPhysician.OverReadPhysicianId.Value).SecondValue;
                            }
                        }
                    }

                }
                var groupName = "N/A";

                if (!string.IsNullOrEmpty(customer.GroupName))
                {
                    groupName = customer.GroupName;
                }

                var additionalFieldsPairs = new List<OrderedPair<string, string>>();
                if (corporateAccounts != null && corporateAccounts.Any() && !string.IsNullOrEmpty(customer.Tag) && accountAdditionalFields != null && accountAdditionalFields.Any())
                {
                    var corporateAccount = corporateAccounts.FirstOrDefault(a => a.Tag == customer.Tag);

                    if (corporateAccount != null)
                    {
                        var additionalFields = accountAdditionalFields.Where(x => x.AccountId == corporateAccount.Id).ToArray();

                        foreach (var additionalField in additionalFields)
                        {
                            additionalFieldsPairs.Add(new OrderedPair<string, string>(additionalField.DisplayName, GetCustomersAdditionFiledValue(customer, (AdditionalFieldsEnum)additionalField.AdditionalFieldId)));
                        }
                    }
                }

                var eventCustomerRetest = retests.SingleOrDefault(x => x.EventCustomerId == customerEventScreeningTest.EventCustomerResultId && x.TestId == customerEventScreeningTest.TestId);

                var viewModel = new TestPerformedViewModel()
                {
                    TechnicianName = idNamePair.SecondValue,
                    EventId = theEvent.Id,
                    EventDate = theEvent.EventDate,
                    EventName = theEvent.Name,
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.Name.FullName,
                    TestName = test.Name,
                    PodName = podNames,
                    IsPreApprovedTest = isTestPreApproved ? "Yes" : "No",
                    HealthPlan = organizationName,
                    DateOfBirth = customer.DateOfBirth,
                    MemberId = customer.InsuranceId,
                    HICN = customer.Hicn,
                    Physician = physicianName,
                    OverReadPhysician = overReadPhysicianName,
                    IsBillableToHealthPlan = test.IsBillableToHealthPlan.HasValue ? (test.IsBillableToHealthPlan.Value ? "Yes" : "No") : "N/A",
                    State = host.Address.State,
                    GroupName = groupName,
                    AdditionalFields = additionalFieldsPairs,
                    IsPdfGenerated = customerEventTestState.IsPdfGenerated ? "Yes" : "No",
                    IsRetest = eventCustomerRetest != null ? "Yes" : "No",
                    IsOverride = eventCustomer.SingleTestOverride ? "Yes" : "No"
                };

                collection.Add(viewModel);
            }
            listModel.Collection = collection;
            return listModel;
        }

        private string GetCustomersAdditionFiledValue(Customer customer, AdditionalFieldsEnum additionalfiled)
        {
            switch (additionalfiled)
            {
                case AdditionalFieldsEnum.AdditionalField1:
                    return string.IsNullOrEmpty(customer.AdditionalField1) ? "N/A" : customer.AdditionalField1;
                case AdditionalFieldsEnum.AdditionalField2:
                    return string.IsNullOrEmpty(customer.AdditionalField2) ? "N/A" : customer.AdditionalField2;
                case AdditionalFieldsEnum.AdditionalField3:
                    return string.IsNullOrEmpty(customer.AdditionalField3) ? "N/A" : customer.AdditionalField3;
                case AdditionalFieldsEnum.AdditionalField4:
                    return string.IsNullOrEmpty(customer.AdditionalField4) ? "N/A" : customer.AdditionalField4;
            }

            return string.Empty;
        }

    }
}
