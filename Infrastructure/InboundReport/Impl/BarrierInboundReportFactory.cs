using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.InboundReport;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.InboundReport.Impl
{
    [DefaultImplementation]
    public class BarrierInboundReportFactory : IBarrierInboundReportFactory
    {
        public ListModelBase<BarrierInboundViewModel, BarrierInboundFilter> Create(IEnumerable<EventCustomerBarrier> eventCustomerBarriers, IEnumerable<Barrier> barriers, IEnumerable<EventCustomer> eventCustomers, List<Customer> customers,
            IEnumerable<ChaseOutbound> chaseOutbounds, IEnumerable<CustomerChaseCampaign> customerChaseCampaigns, IEnumerable<ChaseCampaign> chaseCampaigns)
        {
            var collection = new List<BarrierInboundViewModel>();

            foreach (var eventCustomerBarrier in eventCustomerBarriers)
            {
                var barrier = barriers.First(x => x.Id == eventCustomerBarrier.BarrierId);
                var eventCustomer = eventCustomers.First(x => x.Id == eventCustomerBarrier.EventCustomerId);
                var customer = customers.First(x => x.CustomerId == eventCustomer.CustomerId);
                var chaseOutbound = chaseOutbounds.FirstOrDefault(x => x.CustomerId == customer.CustomerId);

                if (chaseOutbound == null) continue;

                ChaseCampaign campaign = null;
                var customerChaseCampaign = !customerChaseCampaigns.IsNullOrEmpty() ? customerChaseCampaigns.FirstOrDefault(x => x.CustomerId == customer.CustomerId) : null;

                if (customerChaseCampaign != null && !chaseCampaigns.IsNullOrEmpty())
                    campaign = chaseCampaigns.FirstOrDefault(x => x.Id == customerChaseCampaign.ChaseCampaignId);

                var barrierViewModel = new BarrierInboundViewModel
                {
                    TenantId = chaseOutbound.TenantId,
                    ClientId = chaseOutbound.ClientId,
                    CampaignId = campaign != null ? campaign.CampaignId : "",
                    IndividualIDNumber = chaseOutbound.IndividualId,
                    ContractNumber = chaseOutbound.ContractNumber,
                    ContractPersonNumber = chaseOutbound.ContractPersonNumber,
                    ConsumerId = chaseOutbound.ConsumerId,
                    VendorPersonId = customer.CustomerId.ToString(),
                    AppointmentID = eventCustomer.AppointmentId.HasValue ? eventCustomer.AppointmentId.Value.ToString() : "",
                    BarrierId = barrier.Id.ToString(),
                    BarrierCategory = barrier.Name,
                    BarrierReason = eventCustomerBarrier.Reason,
                    BarrierResolution = eventCustomerBarrier.Resolution
                };

                collection.Add(barrierViewModel);
            }

            return new BarrierInboundListModel
            {
                Collection = collection
            };
        }
    }
}
