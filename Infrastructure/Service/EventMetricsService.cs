using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.Service
{
    [DefaultImplementation]
    public class EventMetricsService : IEventMetricsService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventMetricsViewDataFactory _revenueStatisticsViewDataFactory;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        
        public EventMetricsService(IOrderRepository orderRepository, IEventCustomerRepository eventCustomerRepository,
            IEventMetricsViewDataFactory revenueStatisticsViewDataFactory, IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository)
        {
            _orderRepository = orderRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _revenueStatisticsViewDataFactory = revenueStatisticsViewDataFactory;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
        }


        public EventMetricsViewData GetEventMetricsViewData(long eventId, long orgRoleUserId)
        {
            // TODO: This method really needs refactoring, 
            // TODO: probably every different part of the view data needs to be handled in different factory.
            // TODO: Will revisit this after shopping cart is complete.
            var orders = _orderRepository.GetAllOrdersForEvent(eventId);

            var eventPackages = _eventPackageRepository.GetPackagesForEvent(eventId);
            var eventTests = _eventTestRepository.GetTestsForEvent(eventId);
            var eventCustomers = _eventCustomerRepository.GetEventCustomersbyEventId(eventId);

            IOrganizationRoleUserRepository organizationRoleUserRepository = new OrganizationRoleUserRepository();
            var organizationRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(orgRoleUserId);
            var eventMetricsViewData = _revenueStatisticsViewDataFactory.CreateEventMetricsViewData(orders, eventPackages, eventTests, organizationRoleUser, eventCustomers);
            eventMetricsViewData = _eventCustomerRepository.GetEventCustomerFlagMetrics(eventMetricsViewData, eventId);
            return eventMetricsViewData;
        }

    }
}