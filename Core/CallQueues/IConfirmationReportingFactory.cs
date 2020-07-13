using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface IConfirmationReportingFactory
    {
        IEnumerable<ConfirmationReportViewModel> Create(IEnumerable<CallQueueCustomer> callQueueCustomers, IEnumerable<Customer> customers, IEnumerable<EventBasicInfoViewModel> events, IEnumerable<Call> calls,
            IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<CorporateAccount> healthPlans, IEnumerable<OrderedPair<long, string>> restrictionIdNamePairs,
            IEnumerable<OrderedPair<long, string>> confirmedByIdNamePairs, IEnumerable<OrderedPair<long, string>> calledByAgentNameIdPairs, IEnumerable<CallQueueCustomerCall> callQueueCustomerCalls);
    }
}
