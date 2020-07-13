using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Finance.Impl;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class OrderControllerTester
    {
        private readonly MockRepository _mocks = new MockRepository();
        private IOrderController _orderController;
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;
        private IOrderFactory _orderFactory;
        private IOrderDetailFactory _orderDetailFactory;
        private IOrderItemStatusFactory _orderItemStatusFactory;
        private IOrderSynchronizationService _orderSynchronizationService;
        private IUniqueItemRepository<Refund> _refundRepository;
        private IElectronicProductRepository _electronicProductRepository;
        private IShippingDetailRepository _shippingDetailRepository;
        private IPreApprovedTestRepository _preApprovedTestRepository;
        private IPreApprovedPackageRepository _preApprovedPackageRepository;
        private IOrganizationRoleUserRepository _organizationRoleUserRepository;

        [SetUp]
        protected void SetUp()
        {
            _orderRepository = _mocks.StrictMock<IOrderRepository>();
            _orderItemRepository = _mocks.StrictMock<IOrderItemRepository>();
            _orderFactory = _mocks.StrictMock<IOrderFactory>();
            _orderDetailFactory = _mocks.StrictMock<IOrderDetailFactory>();
            _orderItemStatusFactory = _mocks.StrictMock<IOrderItemStatusFactory>();
            _orderSynchronizationService = _mocks.StrictMock<IOrderSynchronizationService>();
            _refundRepository = _mocks.StrictMock<IUniqueItemRepository<Refund>>();
            _electronicProductRepository = _mocks.StrictMock<IElectronicProductRepository>();
            _shippingDetailRepository = _mocks.StrictMock<IShippingDetailRepository>();
            _preApprovedTestRepository = _mocks.StrictMock<IPreApprovedTestRepository>();
            _preApprovedPackageRepository = _mocks.StrictMock<IPreApprovedPackageRepository>();
            _organizationRoleUserRepository = _mocks.StrictMock<IOrganizationRoleUserRepository>();

            _orderController = new OrderController(_orderRepository, _orderItemRepository, _orderFactory, _orderDetailFactory, _electronicProductRepository, _orderItemStatusFactory,
                                                   _orderSynchronizationService, _refundRepository, _shippingDetailRepository, _preApprovedTestRepository, _preApprovedPackageRepository,
                                                   _organizationRoleUserRepository);
        }

        [TearDown]
        public void TearDown()
        {
            _orderController = null;
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PlaceOrderThrowsExceptionWhenNoOrderDetailsProvided()
        {
            _orderController.PlaceOrder(OrderType.Retail, 0);
        }

        [Test]
        public void PlaceOrderSavesTwoEntitiesWhenOneItemOrdered()
        {
            const int quantity = 1;
            const int forOrganizationRoleUserId = 3;
            const int dataRecorderCreatorId = 4;
            const OrderType typeOfOrderToPlace = OrderType.Retail;
            var fakeOrderable = new FakeOrderable();

            Expect.Call(_orderFactory.CreateNewOrder(typeOfOrderToPlace, dataRecorderCreatorId)).
                Return(new Order { OrderDetails = new List<OrderDetail>() });
            Expect.Call(_orderDetailFactory.CreateNewOrderDetail(fakeOrderable, quantity,
                forOrganizationRoleUserId, dataRecorderCreatorId, null, null, null)).
                Return(new OrderDetail());
            Expect.Call(_orderItemStatusFactory.CreateOrderItemStatus(0, 0)).IgnoreArguments().
                Return(FakeOrderItemStatus.IncompleteFakeStatus);

            // Expecting persistence of two entities.
            Expect.Call(_orderRepository.SaveOrder(null)).IgnoreArguments().
                Return(new Order());
            Expect.Call(_orderItemRepository.SaveOrderItem(fakeOrderable.Id, fakeOrderable.OrderItemType))
                .Return(new FakeOrderItem());

            _mocks.ReplayAll();
            _orderController.AddItem(fakeOrderable, quantity,
                forOrganizationRoleUserId, dataRecorderCreatorId);
            _orderController.PlaceOrder(typeOfOrderToPlace, dataRecorderCreatorId);
            _mocks.VerifyAll();
        }
    }
}