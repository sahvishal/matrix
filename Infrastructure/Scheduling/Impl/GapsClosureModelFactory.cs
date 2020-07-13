using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class GapsClosureModelFactory : IGapsClosureModelFactory
    {
        public GapsClosureListModel Create(IEnumerable<EventCustomerPreApprovedTest> eveventCustomerPreApprovedTests, IEnumerable<EventCustomer> eventCustomerResults, IEnumerable<Customer> customers, IEnumerable<Event> events,
             IEnumerable<CustomerResultStatusViewModel> resultStatuses,IEnumerable<EventCustomerResultTestNotPerformedViewModel> testNotPerformedCollection,
             IEnumerable<Test> tests, IEnumerable<Pod> pods, IEnumerable<CorporateAccount> corporateAccountEventPair)
        {
            var list = new List<GapsClosureModel>();

            foreach (var ecpat in eveventCustomerPreApprovedTests)
            {
                var ecr = eventCustomerResults.First(x => x.Id == ecpat.EventCustomerId);

                var customer = customers.Single(x => x.CustomerId == ecr.CustomerId);
                var theEvent = events.Single(x => x.Id == ecr.EventId);

                var podNames = (theEvent.PodIds != null && theEvent.PodIds.Count() > 0) ? string.Join(", ", pods.Where(p => theEvent.PodIds.Contains(p.Id)).Select(p => p.Name)) : string.Empty;

                var resultStatus = resultStatuses != null ? resultStatuses.SingleOrDefault(rs => rs.EventCustomerId == ecr.Id) : null;

                var testNotPerformedTestIds = testNotPerformedCollection.Where(x => x.EventCustomerResultId == ecr.Id).Select(x => x.TestId);

                var testPerformedStatus = string.Empty;
                var testNotPerformedReason = string.Empty;
                var testNotPerformedNotes = string.Empty;

                var testPerfomred = new OrderedPair<string, string>();

                if (resultStatus != null && resultStatus.TestResults != null)
                {
                    testPerfomred = (from tr in resultStatus.TestResults
                                         join t in tests on tr.TestId equals t.Id
                                         where !testNotPerformedTestIds.Contains(tr.TestId) && tr.TestId == ecpat.TestId
                                         select new OrderedPair<string, string>(t.Name, tr.TestInterpretation.HasValue ? ((ResultInterpretation)tr.TestInterpretation.Value).ToString() : "N/A")).FirstOrDefault();
                }
                var account = corporateAccountEventPair.Single(x => x.Tag == customer.Tag);

                var testNotPerformedPair = testNotPerformedCollection.Where(x => x.EventCustomerResultId == ecr.Id);

                if (testNotPerformedPair != null && testNotPerformedPair.Any())
                {
                    var testNotPerformed = (from tr in testNotPerformedPair
                                            join t in tests on tr.TestId equals t.Id
                                            where t.Id == ecpat.TestId
                                            select new OrderedPair<string, string>(t.Name, ((TestNotPerformedReasonType)tr.ReasonId).GetDescription())).FirstOrDefault();
                    if (testNotPerformed != null)
                        testNotPerformedReason = testNotPerformed.SecondValue;
                }

                if (testPerfomred != null)
                {
                    testPerformedStatus = "Yes";
                }
                else
                {
                    var testNotPerformedNotesDetails= testNotPerformedCollection.Where(x => x.EventCustomerResultId == ecr.Id && x.TestId == ecpat.TestId).FirstOrDefault();
                    if(testNotPerformedNotesDetails != null)
                    {
                        testNotPerformedNotes = testNotPerformedNotesDetails.Notes; 
                    }
                    testPerformedStatus = "No";
                }

                var testName = tests.Single(x => x.Id == ecpat.TestId).Name;

                list.Add(new GapsClosureModel
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.Name.FirstName,
                    MiddleName = customer.Name.MiddleName,
                    LastName = customer.Name.LastName,
                    MemberId = customer.InsuranceId,
                    Hicn = customer.Hicn,
                    EventId = theEvent.Id,
                    EventDate = theEvent.EventDate,
                    PodNumber = podNames,
                    PreApprovedTest = testName,
                    ResultStatus = testPerformedStatus,
                    Reason = testNotPerformedReason,
                    HealthPlan = account.Name,
                    Notes = testNotPerformedNotes
                });

            }
            var model = new GapsClosureListModel { Collection = list };

            return model;
        }
    }
}
