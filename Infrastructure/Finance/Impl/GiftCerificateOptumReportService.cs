using System.Linq;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class GiftCerificateOptumReportService : IGiftCerificateOptumReportService
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
       
        
        private readonly IEventReportingService _eventReportingService;
        private readonly IGiftCertificateOptumReportFactory _giftCertificateOptumReportFactory;

        public GiftCerificateOptumReportService(IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository, IOrderRepository orderRepository, IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository, IEventReportingService eventReportingService, IGiftCertificateOptumReportFactory giftCertificateOptumReportFactory)
        {
            _customerRepository = customerRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _orderRepository = orderRepository;
            _eventReportingService = eventReportingService;
            _eventCustomerRepository = eventCustomerRepository;
            _giftCertificateOptumReportFactory = giftCertificateOptumReportFactory;
        }
        public ListModelBase<GiftCertificateReportOptumViewModel, GiftCertificateReportFilter> GetGiftCertificateOptumReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetForGiftCertificateReport(pageNumber, pageSize, filter as GiftCertificateReportFilter, out totalRecords);

            if (!eventCustomers.Any()) return null;

            var customerIds = eventCustomers.Select(x => x.CustomerId).ToArray();
            var customers = _customerRepository.GetCustomers(customerIds);

            var model = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).ToArray());

            var eventCustomerIds = eventCustomers.Select(ec => ec.Id).ToArray();

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds);

            var orderIds = orders.Select(o => o.Id).ToArray();
            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orderIds);

            return _giftCertificateOptumReportFactory.Create(customers, eventCustomers, model, orders, orderPackageIdNamePair, orderTestIdNamePair);
        }
    }
}
