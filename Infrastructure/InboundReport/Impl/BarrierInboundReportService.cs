using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.InboundReport;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.InboundReport.Impl
{
    [DefaultImplementation]
    public class BarrierInboundReportService : IBarrierInboundReportService
    {
        private readonly IBarrierInboundReportFactory _barrierInboundReportFactory;
        private readonly IBarrierRepository _barrierRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IChaseOutboundRepository _chaseOutboundRepository;
        private readonly IChaseCampaignRepository _chaseCampaignRepository;

        public BarrierInboundReportService(IBarrierInboundReportFactory barrierInboundReportFactory, IBarrierRepository barrierRepository, IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository,
            IChaseOutboundRepository chaseOutboundRepository, IChaseCampaignRepository chaseCampaignRepository)
        {
            _barrierInboundReportFactory = barrierInboundReportFactory;
            _barrierRepository = barrierRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _chaseOutboundRepository = chaseOutboundRepository;
            _chaseCampaignRepository = chaseCampaignRepository;
        }

        public ListModelBase<BarrierInboundViewModel, BarrierInboundFilter> GetBarrierInboundReportList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            filter = filter ?? new BarrierInboundFilter();

            var eventCustomerBarriers = _barrierRepository.GetForBarrierInboundReport(filter as BarrierInboundFilter, pageNumber, pageSize, out totalRecords);

            var barrierIds = eventCustomerBarriers.Select(x => x.BarrierId).ToArray();
            var barriers = _barrierRepository.GetByIds(barrierIds);

            var eventCustomerIds = eventCustomerBarriers.Select(x => x.EventCustomerId);
            var eventCustomers = _eventCustomerRepository.GetByIds(eventCustomerIds);

            var customerIds = eventCustomers.Select(x => x.CustomerId).ToArray();
            var customers = customerIds.Any() ? _customerRepository.GetCustomers(customerIds) : null;

            var chaseOutbounds = _chaseOutboundRepository.GetByCustomerIds(customerIds);

            var customerChaseCampaigns = _chaseCampaignRepository.GetCustomerChaseCampaignsByCustomerIds(customerIds);
            var chaseCampaignIds = customerChaseCampaigns.Select(x => x.ChaseCampaignId).Distinct();
            var chaseCampaigns = _chaseCampaignRepository.GetByIds(chaseCampaignIds);

            return _barrierInboundReportFactory.Create(eventCustomerBarriers, barriers, eventCustomers, customers, chaseOutbounds, customerChaseCampaigns, chaseCampaigns);
        }
    }
}
