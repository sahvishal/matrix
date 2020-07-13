using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users;
using System.Linq;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PcpSummaryLogReportService : IPcpSummaryLogReportService
    {

        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly IUniqueItemRepository<EventCustomer> _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPcpSummaryLogReportListModelFactory _pcpSummaryLogReportListModelFactory;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IEventRepository _eventRepository;

        public PcpSummaryLogReportService(IShippingDetailRepository shippingDetailRepository, IUniqueItemRepository<EventCustomer> eventCustomerRepository,
            ICustomerRepository customerRepository, IPcpSummaryLogReportListModelFactory pcpResultMailedReportListModelFactory,
            IShippingOptionRepository shippingOptionRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, IEventRepository eventRepository)
        {
            _shippingDetailRepository = shippingDetailRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _pcpSummaryLogReportListModelFactory = pcpResultMailedReportListModelFactory;
            _shippingOptionRepository = shippingOptionRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _eventRepository = eventRepository;
        }


        public ListModelBase<PcpSummaryLogReportModel, PcpSummaryLogReportModelFilter> GetPcpSummaryLogReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var shippingOption = _shippingOptionRepository.GetShippingOptionByProductId((long)Product.UltraSoundImages, true);

            var shippingDetails = _shippingDetailRepository.GetEventCustomerShippingDetailForFilter(pageNumber, pageSize, filter as PcpSummaryLogReportModelFilter, new[] { shippingOption.Id }, out totalRecords);
            if (shippingDetails.IsNullOrEmpty())
                return null;

            var shippingDetailIdEventCustomerIdPairs = _shippingDetailRepository.GetShippingDetailIdEventCustomerIdPairs(shippingDetails.Select(sd => sd.Id).ToArray());

            var eventCustomers = _eventCustomerRepository.GetByIds(shippingDetailIdEventCustomerIdPairs.Select(sdec => sdec.SecondValue).ToArray());

            var customerIds = eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray();

            var customers = _customerRepository.GetCustomers(customerIds);

            var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(customerIds);

            var eventids = eventCustomers.Select(e => e.EventId).Distinct().ToArray();

            var eventCollection = ((IUniqueItemRepository<Event>)_eventRepository).GetByIds(eventids);

            return _pcpSummaryLogReportListModelFactory.Create(shippingDetails, shippingDetailIdEventCustomerIdPairs, eventCustomers, customers, primaryCarePhysicians, eventCollection);
        }
    }
}
