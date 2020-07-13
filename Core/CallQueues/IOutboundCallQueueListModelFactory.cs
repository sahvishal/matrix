using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Call = Falcon.App.Core.CallCenter.Domain.Call;

namespace Falcon.App.Core.CallQueues
{
    public interface IOutboundCallQueueListModelFactory
    {
        OutboundCallQueueListModel Create(IEnumerable<CallQueueCustomer> callQueueCustomers, IEnumerable<Customer> customers, IEnumerable<ProspectCustomer> prospectCustomers, IEnumerable<CallQueueCriteria> callQueueCriterias,
              IEnumerable<Criteria> criterias, IEnumerable<CallQueueCustomerCall> callQueueCustomerCalls, IEnumerable<Call> calls, IEnumerable<CallCenterNotes> callCenterNoteses, IEnumerable<CustomerCallNotes> cutomerCallNotes, IEnumerable<OrderedPair<long, string>> idNamePair);

        OutboundCallQueueListModel SystemGeneratedCallQueueCustomers(IEnumerable<CallQueueCustomer> callQueueCustomers, IEnumerable<Customer> customers, IEnumerable<ProspectCustomer> prospectCustomers,
              IEnumerable<CallQueueCustomerCallViewModel> callQueueCustomerCalls, IEnumerable<CallCenterNotes> callCenterNoteses, IEnumerable<Event> events, IEnumerable<Host> hosts,IEnumerable<CorporateCustomerCustomTag> corporateCustomerCustomTags);

        OutboundCallQueueListModel CallQueueCustomersForUpsellAndConfimration(IEnumerable<CallQueueCustomer> callQueueCustomers, IEnumerable<Customer> customers, IEnumerable<CallQueueCustomerCallViewModel> callQueueCustomerCalls, IEnumerable<CallCenterNotes> callCenterNoteses, IEnumerable<Event> events, IEnumerable<Host> hosts,
                                IEnumerable<Pod> pods, IEnumerable<Appointment> appointments, IEnumerable<EventCustomer> eventCustomers, IEnumerable<OrganizationRoleUser> agents, IEnumerable<Role> roles);
        
    }
}
