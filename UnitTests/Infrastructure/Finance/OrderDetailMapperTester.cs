using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Mappers.Orders;
using Falcon.Data.EntityClasses;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class OrderDetailMapperTester
    {
        private MockRepository _mocks;
        private IOrderItemStatusFactory _mockedOrderItemStatusFactory;
        private IDataRecorderMetaDataFactory _mockedDataRecorderMetaDataFactory;
        
        private IMapper<OrderDetail, OrderDetailEntity> _mapper;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _mockedOrderItemStatusFactory = _mocks.StrictMock<IOrderItemStatusFactory>();
            _mockedDataRecorderMetaDataFactory = _mocks.StrictMock<IDataRecorderMetaDataFactory>();

            _mapper = new OrderDetailMapper(_mockedOrderItemStatusFactory, 
                _mockedDataRecorderMetaDataFactory);
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
            _mapper = null;
        }

        private static OrderDetailEntity GetValidOrderDetailEntity()
        {
            return new OrderDetailEntity { OrderItem = new OrderItemEntity() };
        }

        [Test]
        public void MapSetsIdFieldsCorrectly()
        {
            const int expectedOrderDetailId = 5;
            const int expectedOrderId = 6;
            const int expectedOrderItemId = 77;
            const int expectedOrganizationRoleUserId = 283;

            var orderDetailEntity = new OrderDetailEntity
            {
                OrderDetailId = expectedOrderDetailId,
                OrderId = expectedOrderId,
                ForOrganizationRoleUserId = expectedOrganizationRoleUserId,
                OrderItemId = expectedOrderItemId,
                OrderItem = new OrderItemEntity()
            };
            OrderDetail orderDetail = _mapper.Map(orderDetailEntity);

            Assert.AreEqual(expectedOrderDetailId, orderDetail.Id,
                "The OrderDetail's ID was not set correctly.");
            Assert.AreEqual(expectedOrderId, orderDetail.OrderId,
                "The OrderDetail's OrderID was not set correctly.");
            Assert.AreEqual(expectedOrderItemId, orderDetail.OrderItemId,
                "The OrderDetail's OrderItemID was not set correctly.");
            Assert.AreEqual(expectedOrganizationRoleUserId, orderDetail.ForOrganizationRoleUserId,
                "The OrderDetail's ForOrgizationRoleUserId was not set correctly.");
        }

        [Test]
        public void MapSetsDescriptionQuantityAndPriceFieldsCorrectly()
        {
            const string expectedDescription = "Expected Description";
            const int expectedQuantity = 34;
            const decimal expectedPrice = 234.99m;

            var orderDetailEntity = GetValidOrderDetailEntity();
            orderDetailEntity.Description = expectedDescription;
            orderDetailEntity.Quantity = expectedQuantity;
            orderDetailEntity.Price = expectedPrice;

            OrderDetail orderDetail = _mapper.Map(orderDetailEntity);

            Assert.AreEqual(expectedDescription, orderDetail.Description,
                "The OrderDetail's Description was not set correctly.");
            Assert.AreEqual(expectedQuantity, orderDetail.Quantity,
                "The OrderDetail's Quantity was not set correctly.");
            Assert.AreEqual(expectedPrice, orderDetail.Price,
                "The OrderDetail's Price was not set correctly.");
        }

        [Test]
        public void MapSetsDataRecorderMetaDataToResultOfMetaDataFactoryCall()
        {
            const int organizationRoleUserCreatorId = 23;
            var dateCreated = new DateTime(2001, 1, 1);
            var expectedDataRecorderMetaData = new DataRecorderMetaData();
            var orderDetailEntity = GetValidOrderDetailEntity();
            orderDetailEntity.DateCreated = dateCreated;
            orderDetailEntity.OrganizationRoleUserCreatorId = organizationRoleUserCreatorId;

            Expect.Call(_mockedDataRecorderMetaDataFactory.CreateDataRecorderMetaData
                (organizationRoleUserCreatorId, dateCreated)).
                Return(expectedDataRecorderMetaData);
            Expect.Call(_mockedOrderItemStatusFactory.CreateOrderItemStatus
                ((OrderItemType)orderDetailEntity.OrderItem.Type, orderDetailEntity.Status)).
                Return(FakeOrderItemStatus.StatusZero);

            _mocks.ReplayAll();
            OrderDetail orderDetail = _mapper.Map(orderDetailEntity);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedDataRecorderMetaData, orderDetail.DataRecorderMetaData,
                "The OrderDetail's DataRecorderMetaData was not set correctly.");
        }

        [Test]
        public void MapSetsOrderItemStatusToResultOfItemStatusFactoryCall()
        {
            const int expectedOrderItemType = 1;
            const int expectedOrderDetailStatus = 5;
            OrderItemStatus expectedOrderItemStatus = FakeOrderItemStatus.StatusZero;

            OrderDetailEntity orderDetailEntity = GetValidOrderDetailEntity();
            orderDetailEntity.OrderItem.Type = expectedOrderItemType;
            orderDetailEntity.Status = expectedOrderDetailStatus;
            Expect.Call(_mockedDataRecorderMetaDataFactory.CreateDataRecorderMetaData(0, new DateTime())).
                IgnoreArguments().Return(null);
            Expect.Call(_mockedOrderItemStatusFactory.CreateOrderItemStatus
                ((OrderItemType)orderDetailEntity.OrderItem.Type, orderDetailEntity.Status)).
                Return(expectedOrderItemStatus);

            _mocks.ReplayAll();
            OrderDetail orderDetail = _mapper.Map(orderDetailEntity);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedOrderItemStatus, orderDetail.OrderItemStatus, 
                "The OrderDetail's OrderItemStatus was not set correctly.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapThrowsExceptionWhenOrderItemEntityIsNull()
        {
            _mapper.Map(new OrderDetailEntity { OrderItem = null });
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapThrowsExceptionWhenGivenRefundHasNullMetaData()
        {
            var orderDetail = new OrderDetail { DataRecorderMetaData = null };

            _mapper.Map(orderDetail);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapThrowsExceptionWhenGivenRefundHasNullDataRecorderCreator()
        {
            var orderDetail = new OrderDetail { DataRecorderMetaData = new DataRecorderMetaData 
                { DataRecorderCreator = null } };

            _mapper.Map(orderDetail);
        }

    }
}