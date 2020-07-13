using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Scheduling.Repositories;

namespace Falcon.App.Infrastructure.Medicare.Impl
{
    [DefaultImplementation]
    public class MedicareOrderService : IMedicareOrderService
    {
        private readonly IOrgRoleUserModelBinder _iOrgRoleUserModelBinder;
        private readonly ISessionContext _sessionContext;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IEventAppointmentService _eventAppointmentService;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IOrderController _orderController;
        private readonly IEventRepository _eventRepository;
        private readonly IEventPodRepository _eventPodRepository;
        private readonly IEventPodRoomRepository _eventPodRoomRepository;


        public MedicareOrderService(IOrgRoleUserModelBinder iOrgRoleUserModelBinder, ISessionContext sessionContext,
            IOrganizationRoleUserRepository organizationRoleUserRepository, IEventAppointmentService eventAppointmentService, IEventPackageRepository eventPackageRepository,
            IEventTestRepository eventTestRepository, IOrderController orderController,IEventRepository eventRepository,IEventPodRepository eventPodRepository,
            IEventPodRoomRepository eventPodRoomRepository)
        {
            _iOrgRoleUserModelBinder = iOrgRoleUserModelBinder;
            _sessionContext = sessionContext;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _eventAppointmentService = eventAppointmentService;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _orderController = orderController;
            _eventRepository = eventRepository;
            _eventPodRepository = eventPodRepository;
            _eventPodRoomRepository = eventPodRoomRepository;
        }


        public bool ChangePackage(long eventId, long customerId, IEnumerable<long> testIds)
        {
            var patientOrder = GetOrder(customerId, eventId);
            if (patientOrder != null && !patientOrder.OrderDetails.IsEmpty())
            {
                var creatorOrganizationRoleUser = GetCreatorOrganizationRoleUser();

                var forOrganizationRoleUser = GetForOrganizationRoleUser(customerId);

                var orderDetail = _orderController.GetActiveOrderDetail(patientOrder);

                var eventTestOrderDetails = patientOrder.OrderDetails.Where(od => od.OrderItem.OrderItemType == OrderItemType.EventTestItem && od.IsCompleted && (od.SourceId.HasValue && od.SourceId.Value != (long)OrderSource.Medicare)).Select(od => od).ToArray();

                var packageId = 0L;
                if (orderDetail.OrderItem.OrderItemType == OrderItemType.EventPackageItem)
                {
                    var eventPackage = _eventPackageRepository.GetById(orderDetail.OrderItem.ItemId);
                    packageId = eventPackage.PackageId;
                }

                var orderables = new List<IOrderable>();
                var selectedTestIds = testIds.ToList();

                if (packageId > 0)
                {
                    IEventPackageRepository eventPackageRepository = new EventPackageRepository();
                    var eventPackage = eventPackageRepository.GetByEventAndPackageIds(eventId, packageId);
                    orderables.Add(eventPackage);

                    RemoveTestsAlreadyInPackage(eventId, packageId, selectedTestIds);
                }

                IEventTestRepository eventTestRepository = new EventTestRepository();
                if (!eventTestOrderDetails.IsNullOrEmpty())
                {
                    var eventTestIds = eventTestOrderDetails.Select(od => od.OrderItem.ItemId).ToArray();
                    var nonMedicareEventTests = eventTestRepository.GetbyIds(eventTestIds);
                    orderables.AddRange(nonMedicareEventTests);
                    var nonMedicareEventTestIds = nonMedicareEventTests.Select(et => et.TestId).ToArray();
                    selectedTestIds = selectedTestIds.Where(x => !nonMedicareEventTestIds.Contains(x)).ToList();
                }

                if (!selectedTestIds.IsNullOrEmpty())
                {
                    
                    var eventTests = eventTestRepository.GetByEventAndTestIds(eventId, selectedTestIds);

                    if (packageId > 0)
                    {
                        foreach (var eventTest in eventTests)
                        {
                            eventTest.Price = eventTest.WithPackagePrice;
                        }
                    }
                    orderables.AddRange(eventTests);
                }

                var eventCustomer = UpdateEventCustomer(orderDetail, false);
                if (eventCustomer == null) return false;

                bool indentedLineItemsAdded = false;

                foreach (var orderable in orderables)
                {
                    if (!indentedLineItemsAdded && (orderable.OrderItemType == OrderItemType.EventPackageItem || orderable.OrderItemType == OrderItemType.EventTestItem))
                    {
                        _orderController.AddItem(orderable, 1, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id, null, null, null, OrderStatusState.FinalSuccess,(long) OrderSource.Medicare);
                        indentedLineItemsAdded = true;
                    }
                    else
                        _orderController.AddItem(orderable, 1, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id, OrderStatusState.FinalSuccess, (long)OrderSource.Medicare);
                }
                
                _orderController.PlaceOrder(patientOrder);
            }
            return true;
        }

        public bool AddMissingTestToEvent(long eventId, IEnumerable<long> testIds)
        {
            var eventtests = _eventTestRepository.GetTestsForEvent(eventId);
            var existingtestIds = eventtests.Select(x => x.TestId).ToList();
            var toBeAddedTests = testIds.Where(testId => !existingtestIds.Contains(testId)).ToList();
            if (toBeAddedTests.Any())
            {
                foreach (var tobeAddedTest in toBeAddedTests)
                {
                    _eventTestRepository.Save(new EventTest
                    {
                        TestId = tobeAddedTest,
                        EventId = eventId,
                        WithPackagePrice = (decimal)0.0,
                        Price = (decimal)0.0,
                        RefundPrice = (decimal)0.0,
                        ReimbursementRate = 0,
                        ShowInAlaCarte = true,
                        Gender = (long)Gender.Unspecified,

                        GroupId = (long)TestGroupType.None,
                        DateCreated = System.DateTime.Now,
                        DateModified = System.DateTime.Now
                    });
                }
                var theEvent = _eventRepository.GetById(eventId);
                if (theEvent.IsDynamicScheduling)
                {
                    var eventPods = _eventPodRepository.GetByEventId(eventId);
                    var eventPodIds = eventPods.Select(x => x.Id);
                    var eventPodRooms = _eventPodRoomRepository.GetByEventPodIds(eventPodIds);
                    foreach (var eventPodRoom in eventPodRooms)
                    {
                        _eventPodRoomRepository.SaveEventPodRoomTests(toBeAddedTests, eventPodRoom.Id);
                    }

                }
            }
            return true;
        }

        private void RemoveTestsAlreadyInPackage(long eventId, long packageId, List<long> selectedTestIds)
        {
            var eventPackage = _eventPackageRepository.GetByEventAndPackageIds(eventId, packageId);
            var package = eventPackage != null ? eventPackage.Package : null;


            if (package != null && !selectedTestIds.IsNullOrEmpty())
            {
                var packageTestIds = package.Tests.Select(t => t.Id);
                selectedTestIds.RemoveAll(t => packageTestIds.Contains(t));
            }
        }


        private Order GetOrder(long customerId, long eventId)
        {
            IOrderRepository orderRepository = new OrderRepository();

            return orderRepository.GetOrder(customerId, eventId);
        }

        private OrganizationRoleUser GetCreatorOrganizationRoleUser()
        {
            return _iOrgRoleUserModelBinder.ToDomain(_sessionContext.UserSession.CurrentOrganizationRole, _sessionContext.UserSession.UserId);
        }

        private OrganizationRoleUser GetForOrganizationRoleUser(long customerId)
        {
            var orgRolesUsers = _organizationRoleUserRepository.GetOrganizationRoleUser(customerId);
            if (orgRolesUsers != null)
                return orgRolesUsers;

            return null;
        }

        private EventCustomer UpdateEventCustomer(OrderDetail orderDetail, bool isOrderCancelled)
        {
            IUniqueItemRepository<EventCustomer> itemRepository = new EventCustomerRepository();
            var eventCustomer = itemRepository.GetById(orderDetail.EventCustomerOrderDetail.EventCustomerId);

            if (eventCustomer == null) return null;

            if (isOrderCancelled)
            {
                var eventCustomerRepository = new EventCustomerRepository();
                eventCustomerRepository.UpdateAppointmentId(orderDetail.EventCustomerOrderDetail.EventCustomerId);

                if (eventCustomer.AppointmentId != null)
                    _eventAppointmentService.DeleteAppointment(eventCustomer.AppointmentId.Value);
            }
            return eventCustomer;
        }
    }
}
