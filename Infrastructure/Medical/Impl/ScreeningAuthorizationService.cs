using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IScreeningAuthorizationService))]
    public class ScreeningAuthorizationService : IScreeningAuthorizationService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventScreeningAuthorizationEditModelFactory _eventScreeningAuthorizationEditModelFactory;
        private readonly IHostRepository _hostRepository;
        private readonly IPhysicianAssignmentService _physicianAssignmentService;

        public ScreeningAuthorizationService(IEventRepository eventRepository, IEventTestRepository eventTestRepository, IEventCustomerRepository eventCustomerRepository, IEventPackageRepository packageRepository,
            ICustomerRepository customerRepository, IEventScreeningAuthorizationEditModelFactory eventScreeningAuthorizationEditModelFactory, IOrderRepository orderRepository, IHostRepository hostRepository,
            IPhysicianAssignmentService physicianAssignmentService)
        {
            _eventRepository = eventRepository;
            _eventTestRepository = eventTestRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _eventPackageRepository = packageRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _eventScreeningAuthorizationEditModelFactory = eventScreeningAuthorizationEditModelFactory;
            _hostRepository = hostRepository;
            _physicianAssignmentService = physicianAssignmentService;
        }

        public EventScreeningAuthorizationEditModel GetCustomersForAuthorization(long physicianId)
        {
            var eventData = _eventRepository.GetEventForAuthorization(physicianId);
            if (eventData == null)
                return null;
            var host = _hostRepository.GetHostForEvent(eventData.Id);

            var eventTests = _eventTestRepository.GetTestsForEvent(eventData.Id);
            var eventPackages = _eventPackageRepository.GetPackagesForEvent(eventData.Id);

            var eventCustomers = _eventCustomerRepository.GetEventCustomersForAuthorization(eventData.Id);
            if (eventCustomers == null || eventCustomers.Count() < 1)
            {
                return null;
            }

            var eventCustomerIds = eventCustomers.Select(ec => ec.Id).ToArray();

            var assignments = _physicianAssignmentService.GetPhysicianAssignmentsByEventcustomerIds(eventCustomerIds);

            if (!assignments.Any(a => a.Primary.PhysicianId == physicianId))
                return null;

            eventCustomerIds = assignments.Where(a => a.Primary.PhysicianId == physicianId).Select(a => a.EventCustomerId).ToArray();

            eventCustomers = eventCustomers.Where(ec => eventCustomerIds.Contains(ec.Id)).ToArray();

            var orderIdEventCustomerIdPairs = _orderRepository.GetOrderEventCustomerIdPairforEventCustomerIds(eventCustomerIds);
            var orderIds = orderIdEventCustomerIdPairs.Select(p => p.FirstValue).ToArray();

            var orderIdTestIdPairs = _eventTestRepository.GetEventTestIdForOrders(orderIds);
            var orderIdpackageIdPairs = _eventPackageRepository.GetEventPackageIdsForOrder(orderIds);

            var ecIdTestIdPairs = (from ec in orderIdEventCustomerIdPairs join ot in orderIdTestIdPairs on ec.FirstValue equals ot.FirstValue select new OrderedPair<long, long>(ec.SecondValue, ot.SecondValue)).ToArray();
            var ecIdpackageIdPairs = (from ec in orderIdEventCustomerIdPairs join op in orderIdpackageIdPairs on ec.FirstValue equals op.FirstValue select new OrderedPair<long, long>(ec.SecondValue, op.SecondValue)).ToArray();
            
            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            return _eventScreeningAuthorizationEditModelFactory.Create(eventData, eventTests, eventCustomers, customers, eventPackages, ecIdpackageIdPairs, ecIdTestIdPairs, host);
        }
    }
}
