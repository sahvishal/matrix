using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling
{
   public interface IGapsClosureModelFactory
    {
       GapsClosureListModel Create(IEnumerable<EventCustomerPreApprovedTest> eveventCustomerPreApprovedTests, IEnumerable<EventCustomer> eventCustomerResults, IEnumerable<Customer> customers, IEnumerable<Event> events,
            IEnumerable<CustomerResultStatusViewModel> testResultStatus,IEnumerable<EventCustomerResultTestNotPerformedViewModel> eventCusromerResultIdTestNotPerformedPairs,
            IEnumerable<Test> tests, IEnumerable<Pod> pods, IEnumerable<CorporateAccount> corporateAccountEventPair);
    }
}
