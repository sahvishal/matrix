using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.InboundReport;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.InboundReport.Impl
{
    [DefaultImplementation]
    public class ConditionInboundReportService : IConditionInboundReportService
    {
        private readonly IConditionInboundReportFactory _conditionInboundReportFactory;
        private readonly IEventCustomerDiagnosisRepository _eventCustomerDiagnosisRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IChaseOutboundRepository _chaseOutboundRepository;
        private readonly IChaseCampaignRepository _chaseCampaignRepository;

        public ConditionInboundReportService(IConditionInboundReportFactory conditionInboundReportFactory, IEventCustomerDiagnosisRepository eventCustomerDiagnosisRepository, IEventCustomerRepository eventCustomerRepository,
            IChaseOutboundRepository chaseOutboundRepository, IChaseCampaignRepository chaseCampaignRepository)
        {
            _conditionInboundReportFactory = conditionInboundReportFactory;
            _eventCustomerDiagnosisRepository = eventCustomerDiagnosisRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _chaseOutboundRepository = chaseOutboundRepository;
            _chaseCampaignRepository = chaseCampaignRepository;
        }

        public ListModelBase<ConditionInboundViewModel, ConditionInboundFilter> GetConditionInboundReportList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            filter = filter ?? new ConditionInboundFilter();

            var diagnosisRecords = _eventCustomerDiagnosisRepository.GetForConditionInboundReport(filter as ConditionInboundFilter, pageNumber, pageSize, out totalRecords);

            if (!diagnosisRecords.Any()) return null;

            var eventCustomerIds = diagnosisRecords.Select(x => x.EventCustomerId).Distinct().ToArray();
            var eventCustomers = _eventCustomerRepository.GetByIds(eventCustomerIds);

            var customerIds = eventCustomers.Select(x => x.CustomerId).Distinct().ToArray();
            var chaseOutbounds = _chaseOutboundRepository.GetByCustomerIds(customerIds);

            var customerChaseCampaigns = _chaseCampaignRepository.GetCustomerChaseCampaignsByCustomerIds(customerIds);
            var chaseCampaignIds = customerChaseCampaigns.Select(x => x.ChaseCampaignId).Distinct();
            var chaseCampaigns = _chaseCampaignRepository.GetByIds(chaseCampaignIds);

            return _conditionInboundReportFactory.Create(diagnosisRecords, eventCustomers, chaseOutbounds, customerChaseCampaigns, chaseCampaigns);
        }
    }
}
