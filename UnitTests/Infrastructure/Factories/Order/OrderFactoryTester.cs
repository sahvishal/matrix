using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.Infrastructure.Factories.Order
{
    [TestFixture]
    public class OrderFactoryTester
    {
        private MockRepository _mocks;
        private IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;
        private IOrderFactory _orderFactory;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _dataRecorderMetaDataFactory = _mocks.StrictMock<IDataRecorderMetaDataFactory>();
            _mocks.StrictMock<IMapper<Falcon.App.Core.Finance.Domain.Order, OrderEntity>>();
            _orderFactory = new OrderFactory(_dataRecorderMetaDataFactory);
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
        }

        [Test]
        public void CreateNewOrderMapsDataRecorderCreatorIdToDataRecorderMetaData()
        {
            const int expectedDataRecorderCreatorId = 3;

            Expect.Call(_dataRecorderMetaDataFactory.
                CreateDataRecorderMetaData(expectedDataRecorderCreatorId)).Return(null);

            _mocks.ReplayAll();
            _orderFactory.CreateNewOrder(OrderType.Retail, expectedDataRecorderCreatorId);
            _mocks.VerifyAll();
        }

        [Test]
        public void CreateNewOrderSetsOrderTypeToGivenOrderType()
        {
            const OrderType expectedOrderType = OrderType.Corporate;

            Expect.Call(_dataRecorderMetaDataFactory.CreateDataRecorderMetaData(0)).
                IgnoreArguments().Return(null);

            _mocks.ReplayAll();
            Falcon.App.Core.Finance.Domain.Order order = _orderFactory.CreateNewOrder(expectedOrderType, 0);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedOrderType, order.OrderType, 
                "Order's OrderType was not mapped correctly.");
        }
    }
}