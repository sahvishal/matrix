using System.Collections.Generic;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.InboundReport
{
    public interface ILabsInboundReportFactory
    {
        LabsInboundListModel Create(IEnumerable<CustomerEventTestState> eventTestStates, IEnumerable<CustomerEventScreeningTests> eventScreeningTests, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers,
            IEnumerable<ChaseOutbound> chaseOutbounds, IEnumerable<CustomerChaseCampaign> customerChaseCampaigns, IEnumerable<ChaseCampaign> chaseCampaigns, IEnumerable<Test> tests, IEnumerable<Event> events,
            IEnumerable<EventCustomerResult> eventCustomerResults);
    }
}
