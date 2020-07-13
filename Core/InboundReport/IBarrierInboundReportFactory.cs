using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.InboundReport
{
    public interface IBarrierInboundReportFactory
    {
        ListModelBase<BarrierInboundViewModel, BarrierInboundFilter> Create(IEnumerable<EventCustomerBarrier> eventCustomerBarriers, IEnumerable<Barrier> barriers, IEnumerable<EventCustomer> eventCustomers, List<Customer> customers,
            IEnumerable<ChaseOutbound> chaseOutbounds, IEnumerable<CustomerChaseCampaign> customerChaseCampaign, IEnumerable<ChaseCampaign> chaseCampaigns);
    }
}
