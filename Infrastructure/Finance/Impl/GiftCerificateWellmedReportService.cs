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
    public class GiftCerificateWellmedReportService : IGiftCerificateWellmedReportService
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
       
        
        private readonly IEventReportingService _eventReportingService;
        private readonly IGiftCertificateWellmedReportFactory _giftCertificateReportWellmedFactory;

        public GiftCerificateWellmedReportService(IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository, IOrderRepository orderRepository, IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository, IEventReportingService eventReportingService, IGiftCertificateWellmedReportFactory giftCertificateReportWellmedFactory)
        {
            _customerRepository = customerRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _orderRepository = orderRepository;
            _eventReportingService = eventReportingService;
            _eventCustomerRepository = eventCustomerRepository;
            _giftCertificateReportWellmedFactory = giftCertificateReportWellmedFactory;
        }
        public ListModelBase<GiftCertificateReportWellmedViewModel, GiftCertificateReportFilter> GetGiftCertificateWellmedReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
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

            return _giftCertificateReportWellmedFactory.Create(customers, eventCustomers, model, orders, orderPackageIdNamePair, orderTestIdNamePair);
        }
    }
}
