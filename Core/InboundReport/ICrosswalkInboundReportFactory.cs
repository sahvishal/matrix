using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.InboundReport
{
    public interface ICrosswalkInboundReportFactory
    {
        List<CrosswalkInboundViewModel> Create(IEnumerable<Customer> customers, IEnumerable<ChaseOutbound> chaseOutbounds, IEnumerable<CustomerChaseCampaign> customerChaseCampaigns, IEnumerable<ChaseCampaign> chaseCampaigns,
            IEnumerable<Relationship> relationships, IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<Event> events, CorporateAccount corporateAccount,
            IEnumerable<CustomerEventScreeningTests> customerEventScreeningTests, IEnumerable<OrderedPair<long, long>> customerEventScreeningTestIdFileIdPairs);

        ListModelBase<CrosswalkLabInboundViewModel, CrosswalkLabInboundFilter> CreateCrosswalkLabInboundList(IEnumerable<Customer> customers, IEnumerable<ChaseOutbound> chaseOutbounds, IEnumerable<CustomerChaseCampaign> customerChaseCampaigns,
            IEnumerable<ChaseCampaign> chaseCampaigns, IEnumerable<Relationship> relationships, IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<Event> events,
            IEnumerable<CustomerEventScreeningTests> customerEventScreeningTests, IEnumerable<OrderedPair<long, long>> customerEventScreeningTestIdFileIdPairs, IEnumerable<File> files);
    }
}
