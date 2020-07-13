using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.Data.EntityClasses;
using Falcon.Web.UnitTests.Infrastructure.Application;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class OrderRepositoryTester : RepositoryTesterBase
    {
        private IMapper<Falcon.App.Core.Finance.Domain.Order, OrderEntity> _mockedMapper;
        private IOrderDetailRepository _orderDetailRepository;
        private IPaymentRepository _paymentRepository;
        private ICombinedPaymentInstrumentRepository _combinedPaymentInstrumentRepository;

        private IOrderRepository _orderRepository;
        
        protected override void SetUp()
        {
            base.SetUp();
            _mockedMapper = _mocks.StrictMock<IMapper<Falcon.App.Core.Finance.Domain.Order, OrderEntity>>();
            _mocks.StrictMock<IOrderFactory>();
            _orderDetailRepository = _mocks.StrictMock<IOrderDetailRepository>();
            _combinedPaymentInstrumentRepository = _mocks.StrictMock
                <ICombinedPaymentInstrumentRepository>();
            _paymentRepository = _mocks.StrictMock<IPaymentRepository>();
            _orderRepository = new OrderRepository(_persistenceLayer, _orderDetailRepository,
                                                   _combinedPaymentInstrumentRepository, _mockedMapper,
                                                   _paymentRepository);
        }

        protected override void TearDown()
        {
            base.TearDown();
            _orderRepository = null;
        }

        [Test]
        [ExpectedException(typeof(ObjectNotFoundInPersistenceException<Falcon.App.Core.Finance.Domain.Order>))]
        public void GetOrderThrowsExceptionWhenGivenInvalidOrderId()
        {
            ExpectGetDataAccessAdapterAndDispose();
            ExpectLinqFetchEntityCollection();

            _mocks.ReplayAll();
            _orderRepository.GetOrder(0);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(PersistenceFailureException))]
        public void SaveOrderThrowsExceptionWhenEntityDoesNotGetSaved()
        {
            var orderToSave = new Falcon.App.Core.Finance.Domain.Order();

            Expect.Call(_mockedMapper.Map(orderToSave)).Return(new OrderEntity());
            ExpectGetDataAccessAdapterAndDispose();
            ExpectSaveEntity(false, true);

            _mocks.ReplayAll();
            _orderRepository.SaveOrder(orderToSave);
            _mocks.VerifyAll();
        }
    }
}