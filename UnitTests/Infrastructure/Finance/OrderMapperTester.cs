using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Mappers.Orders;
using Falcon.Data.EntityClasses;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class OrderMapperTester
    {
        private readonly MockRepository _mocks = new MockRepository();
        private IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;

        private IMapper<Order, OrderEntity> _mapper;

        [SetUp]
        public void SetUp()
        {
            _dataRecorderMetaDataFactory = _mocks.StrictMock<IDataRecorderMetaDataFactory>();
            _mapper = new OrderMapper(_dataRecorderMetaDataFactory);
        }

        [TearDown]
        public void TearDown()
        {
            _mapper = null;
        }

        private static Order GetValidOrder()
        {
            return GetValidOrder(0);
        }

        private static Order GetValidOrder(long orderId)
        {
            return new Order(orderId)
            {
                DataRecorderMetaData = new DataRecorderMetaData 
                    { DataRecorderCreator = new OrganizationRoleUser() }
            };
        }

        [Test]
        public void MapSetsDataRecorderMetaDataToMetaDataFactoryCallReturnValue()
        {
            var orderEntity = new OrderEntity { OrganizationRoleUserCreatorId = 1, 
                DateCreated = new DateTime(2003, 2, 2) };
            var expectedMetaData = new DataRecorderMetaData();

            Expect.Call(_dataRecorderMetaDataFactory.CreateDataRecorderMetaData(orderEntity.    
                OrganizationRoleUserCreatorId, orderEntity.DateCreated)).Return(expectedMetaData);

            _mocks.ReplayAll();
            Order order = _mapper.Map(orderEntity);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedMetaData, order.DataRecorderMetaData, 
                "Order returned with incorrect DataRecorderMetaData.");
        }

        [Test]
        public void MapSetsOrderIdOfOrderCorrectly()
        {
            const int expectedOrderId = 34;
            var orderEntity = new OrderEntity(expectedOrderId);

            Order order = _mapper.Map(orderEntity);

            Assert.AreEqual(expectedOrderId, order.Id, "The Order's ID was not set correctly.");
        }

        [Test]
        public void MapSetsOrderTypeOfOrderCorrectly()
        {
            const OrderType expectedOrderType = OrderType.Retail;
            var orderEntity = new OrderEntity { Type = (int)expectedOrderType };

            Order order = _mapper.Map(orderEntity);

            Assert.AreEqual(expectedOrderType, order.OrderType, 
                "The Order's OrderType was set incorrectly.");
        }

        [Test]
        public void MapSetsOrderIdOfOrderEntityCorrectly()
        {
            const int expectedId = 23;
            Order order = GetValidOrder(expectedId);

            OrderEntity orderEntity = _mapper.Map(order);

            Assert.AreEqual(expectedId, orderEntity.OrderId, "OrderEntity OrderID set incorrectly.");
        }

        [Test]
        public void MapSetsOrderTypeOfOrderEntityCorrectly()
        {
            const OrderType expectedOrderType = OrderType.Corporate;
            Order order = GetValidOrder();
            order.OrderType = expectedOrderType;

            OrderEntity orderEntity = _mapper.Map(order);

            Assert.AreEqual((short)expectedOrderType, orderEntity.Type, 
                "OrderEntity Type set incorrectly.");
        }

        [Test]
        public void MapSetsCreatorIdOfOrderEntityCorrectly()
        {
            const int expectedCreatorId = 38;
            Order order = GetValidOrder();
            order.DataRecorderMetaData.DataRecorderCreator = new OrganizationRoleUser(expectedCreatorId);

            OrderEntity orderEntity = _mapper.Map(order);

            Assert.AreEqual(expectedCreatorId, orderEntity.OrganizationRoleUserCreatorId, 
                "OrderEntity OrganizationRoleUserCreatorID set incorrectly.");
        }

        [Test]
        public void MapSetsDateCreatedOfOrderEntityCorrectly()
        {
            var expectedDateCreated = new DateTime(2003, 5, 2);
            Order order = GetValidOrder();
            order.DataRecorderMetaData.DateCreated = expectedDateCreated;

            OrderEntity orderEntity = _mapper.Map(order);

            Assert.AreEqual(expectedDateCreated, orderEntity.DateCreated, 
                "OrderEntity DateCreated set incorrectly.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapThrowsExceptionWhenGivenNullOrder()
        {
            _mapper.Map((Order)null);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapThrowsExceptionIfNullDataRecorderMetaDataGiven()
        {
            Order order = GetValidOrder();
            order.DataRecorderMetaData = null;

            _mapper.Map(order);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapThrowsExceptionIfNullDataRecorderCreatorGiven()
        {
            Order order = GetValidOrder();
            order.DataRecorderMetaData.DataRecorderCreator = null;

            _mapper.Map(order);
        }

        [Test]
        public void MapSetsIsNewToTrueWhenGivenOrderIdIs0()
        {
            const int orderId = 0;
            Order order = GetValidOrder(orderId);

            OrderEntity orderEntity = _mapper.Map(order);

            Assert.IsTrue(orderEntity.IsNew, 
                "OrderEntity's IsNew property set to false when given OrderID was 0.");
        }

        [Test]
        public void MapSetsIsNewToFalseWhenGivenOrderIdIsNot0()
        {
            const int orderId = 235;
            Order order = GetValidOrder(orderId);

            OrderEntity orderEntity = _mapper.Map(order);

            Assert.IsFalse(orderEntity.IsNew, 
                "OrderEntity's IsNew property set to true when given OrderID was not 0.");
        }
    }
}