using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.Data.EntityClasses;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Factories.Order;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.Infrastructure.Factories.Order
{
    [TestFixture]
    public class OrderDetailFactoryTester
    {
        private MockRepository _mocks;
        private IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;
        private IOrderItemStatusFactory _orderItemStatusFactory;

        private IOrderDetailFactory _orderDetailFactory;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _dataRecorderMetaDataFactory = _mocks.StrictMock<IDataRecorderMetaDataFactory>();
            _orderItemStatusFactory = _mocks.StrictMock<IOrderItemStatusFactory>();
            _mocks.StrictMock<IMapper<OrderDetail, OrderDetailEntity>>();
            _orderDetailFactory = new OrderDetailFactory(_dataRecorderMetaDataFactory,
                _orderItemStatusFactory);
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
        }

        [Test]
        public void CreateNewOrderDetailCreatesOrderItemStatusInInitialStateWithOrderableOrderItemType()
        {
            var orderable = new FakeOrderable();

            Expect.Call(_orderItemStatusFactory.CreateOrderItemStatus(orderable.OrderItemType,
                (int)OrderStatusState.Initial)).Return(null);
            Expect.Call(_dataRecorderMetaDataFactory.CreateDataRecorderMetaData(0)).IgnoreArguments().
                Return(null);

            _mocks.ReplayAll();
            _orderDetailFactory.CreateNewOrderDetail(orderable, 1, 0, 0, null, null, null);
            _mocks.VerifyAll();
        }

        [Test]
        public void CreateNewOrderDetailMapsDataRecorderCreatorIdToDataRecorderMetaData()
        {
            const int expectedDataRecorderCreatorId = 3;

            Expect.Call(_orderItemStatusFactory.CreateOrderItemStatus(0, 0)).IgnoreArguments().
                Return(null);
            Expect.Call(_dataRecorderMetaDataFactory.
                CreateDataRecorderMetaData(expectedDataRecorderCreatorId)).Return(null);

            _mocks.ReplayAll();
            _orderDetailFactory.CreateNewOrderDetail(new FakeOrderable(), 1, 0,
                                                     expectedDataRecorderCreatorId, null, null, null);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateNewOrderDetailThrowsExceptionWhenGivenNullOrderable()
        {
            _mocks.ReplayAll();
            _orderDetailFactory.CreateNewOrderDetail(null, 1, 0, 0, null, null, null);
            _mocks.VerifyAll();
        }

        [Test]
        public void CreateNewOrderDetailSetsDescriptionToGivenOrderableDescription()
        {
            var orderable = new FakeOrderable();
            string expectedDescription = orderable.Description;

            Expect.Call(_orderItemStatusFactory.CreateOrderItemStatus(0, 0)).IgnoreArguments().Return(null);
            Expect.Call(_dataRecorderMetaDataFactory.CreateDataRecorderMetaData(0)).IgnoreArguments().
                Return(null);

            _mocks.ReplayAll();
            OrderDetail orderDetail = _orderDetailFactory.CreateNewOrderDetail(orderable, 1, 0, 0, null, null, null);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedDescription, orderDetail.Description,
                "OrderDetail's Description does not match orderable Description.");
        }

        [Test]
        public void CreateNewOrderDetailSetsPriceToGivenOrderablePrice()
        {
            var orderable = new FakeOrderable();
            decimal expectedPrice = orderable.Price;

            Expect.Call(_orderItemStatusFactory.CreateOrderItemStatus(0, 0)).IgnoreArguments().Return(null);
            Expect.Call(_dataRecorderMetaDataFactory.CreateDataRecorderMetaData(0)).IgnoreArguments().
                Return(null);

            _mocks.ReplayAll();
            OrderDetail orderDetail = _orderDetailFactory.CreateNewOrderDetail(orderable, 1, 0, 0, null, null, null);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedPrice, orderDetail.Price,
                "OrderDetail's Price does not match orderable Price.");
        }

        [Test]
        public void CreateNewOrderDetailMapsGivenParametersToDesignatedFields()
        {
            const int expectedQuantity = 3;
            const long expectedOrganizationRoleUserId = 38;

            Expect.Call(_orderItemStatusFactory.CreateOrderItemStatus(0, 0)).IgnoreArguments().Return(null);
            Expect.Call(_dataRecorderMetaDataFactory.CreateDataRecorderMetaData(0)).IgnoreArguments().
                Return(null);

            _mocks.ReplayAll();
            OrderDetail orderDetail = _orderDetailFactory.CreateNewOrderDetail
                (new FakeOrderable(), expectedQuantity, expectedOrganizationRoleUserId, 0, null, null, null);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedQuantity, orderDetail.Quantity,
                "OrderDetail's Quantity does not match given Quantity.");
            Assert.AreEqual(expectedOrganizationRoleUserId, orderDetail.ForOrganizationRoleUserId,
                "OrderDetail's OrganizationRoleUserId does not match given OrganizationRoleUserId.");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateNewOrderDetailThrowsExceptionWhenGivenOrderableHasIdOf0()
        {
            const int id = 0;

            _mocks.ReplayAll();
            _orderDetailFactory.CreateNewOrderDetail(new FakeOrderable(id), 4, 2, 3, null, null, null);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateNewOrderDetailThrowsExceptionWhenQuantityOf0Given()
        {
            const int quantity = 0;

            _mocks.ReplayAll();
            _orderDetailFactory.CreateNewOrderDetail(new FakeOrderable(), quantity, 3, 44, null, null, null);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateNewOrderDetailThrowsExceptionWhenQuantityGivenIsNegative()
        {
            const int quantity = -3;

            _mocks.ReplayAll();
            _orderDetailFactory.CreateNewOrderDetail(new FakeOrderable(), quantity, 3, 44, null, null, null);
            _mocks.VerifyAll();
        }

        [Test]
        public void CreateNewOrderDetailSetsEventDetail()
        {
            var orderable = new FakeOrderable();
            var eventCustomer = new EventCustomer(0);
            const long expectedEventCustomerOrderDetail = 0;

            Expect.Call(_orderItemStatusFactory.CreateOrderItemStatus(0, 0)).IgnoreArguments().Return(null);
            Expect.Call(_dataRecorderMetaDataFactory.CreateDataRecorderMetaData(0)).IgnoreArguments().
                Return(null);

            _mocks.ReplayAll();
            OrderDetail orderDetail = _orderDetailFactory.CreateNewOrderDetail(orderable, 1, 0, 0, null, eventCustomer, null);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedEventCustomerOrderDetail, orderDetail.EventCustomerOrderDetail.EventCustomerId,
                "OrderDetail's EventCustomerOrderDetail does not match.");
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CreateNewOrderDetailSetsSourceCodeThrowsExceptionWhenDataRecoderMetadataNotSupplied()
        {
            var orderable = new FakeOrderable();
            var sourceCode = new SourceCode(0);

            Expect.Call(_orderItemStatusFactory.CreateOrderItemStatus(0, 0)).IgnoreArguments().Return(null);
            Expect.Call(_dataRecorderMetaDataFactory.CreateDataRecorderMetaData(0)).IgnoreArguments().
                Return(null);

            _mocks.ReplayAll();
            _orderDetailFactory.CreateNewOrderDetail(orderable, 1, 0, 0, sourceCode, null, null);
            _mocks.VerifyAll();
        }
    }
}