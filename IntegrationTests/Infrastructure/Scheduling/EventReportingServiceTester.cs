using Falcon.App.Core.Application;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Scheduling.Impl;
using NUnit.Framework;
using Falcon.App.Core.Interfaces;

namespace Falcon.Web.IntegrationTests.Infrastructure.Scheduling
{
    [TestFixture]
    public class EventReportingServiceTester
    {

        private IEventReportingService _eventReportingService;
        public EventReportingServiceTester()
        {
            DependencyRegistrar.RegisterDependencies();
            IoC.Resolve<IAutoMapperBootstrapper>().Bootstrap();

        }

        [Test]
        public void Test_Registration()
        {
            var hostRepo = IoC.Resolve<IHostRepository>();
            var eventRepo = IoC.Resolve<IEventRepository>();
            var podRepository = IoC.Resolve<IPodRepository>();
            var eventVolumeFactory = IoC.Resolve<IEventVolumeFactory>();
            var orderRepo = IoC.Resolve<IOrderRepository>();
            var detailOrderFactory = IoC.Resolve<IDetailOpenOrderModelFactory>();
            var dailyRecapFactory = IoC.Resolve<IDailyRecapModelFactory>();
            var phyEventAssignmentRepo = IoC.Resolve<IPhysicianEventAssignmentRepository>();
            var hospitalPartnerRepository = IoC.Resolve<IHospitalPartnerRepository>();
            var organizationRepository = IoC.Resolve<IOrganizationRepository>();
            var eventAppointmentStatsService = IoC.Resolve<IEventAppointmentStatsService>();
            var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
            var eventStaffAssignmentRepository = IoC.Resolve<IEventStaffAssignmentRepository>();
            var organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            var eventCancellationModelFactory = IoC.Resolve<IEventCancellationModelFactory>();
            var dailyVolumeFactory = IoC.Resolve<IDailyVolumeFactory>();
            var eventAppointmentChangeLogRepository = IoC.Resolve<IEventAppointmentChangeLogRepository>();
            var eventTestrepository = IoC.Resolve<IEventTestRepository>();
            var eventScheduleReportFactory = IoC.Resolve<IEventScheduleReportFactory>();

            _eventReportingService = new EventReportingService(eventRepo, hostRepo, podRepository,
                                                               eventVolumeFactory, orderRepo, detailOrderFactory,
                                                               dailyRecapFactory, phyEventAssignmentRepo,
                                                               hospitalPartnerRepository, organizationRepository, eventAppointmentStatsService, corporateAccountRepository,
                                                               eventStaffAssignmentRepository, organizationRoleUserRepository, eventCancellationModelFactory, dailyVolumeFactory, eventAppointmentChangeLogRepository, eventTestrepository, eventScheduleReportFactory);


            // _eventReportingService.GetDetailOpenOrderModel(1,10,new DetailOpenOrderModelFilter(), )
            Assert.IsNotNull(hostRepo);
            Assert.IsNotNull(eventRepo);
            Assert.IsNotNull(podRepository);
            Assert.IsNotNull(eventVolumeFactory);
            Assert.IsNotNull(orderRepo);
            Assert.IsNotNull(detailOrderFactory);
            Assert.IsNotNull(dailyRecapFactory);


        }


    }
}


/*
 EventReportingService(IEventRepository eventRepository, IHostRepository hostRepository, ITerritoryRepository territoryRepository,
            IPodRepository podRepository, IEventVolumeFactory eventVolumeFactory, IOrderRepository orderRepository, IDetailOpenOrderModelFactory detailOpenOrderModelFactory)
 */