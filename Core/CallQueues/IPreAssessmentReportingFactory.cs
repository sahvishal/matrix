using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CallQueues
{
   public interface IPreAssessmentReportingFactory
    {
       IEnumerable<PreAssessmentReportViewModel> Create(IEnumerable<PreAssessmentCallCustomer> callQueueCustomers, IEnumerable<Customer> customers, IEnumerable<EventBasicInfoViewModel> events, IEnumerable<Call> calls,
           IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<CorporateAccount> healthPlans, IEnumerable<OrderedPair<long, string>> restrictionIdNamePairs,
           IEnumerable<OrderedPair<long, string>> confirmedByIdNamePairs, IEnumerable<OrderedPair<long, string>> calledByAgentNameIdPairs);
    }
}
