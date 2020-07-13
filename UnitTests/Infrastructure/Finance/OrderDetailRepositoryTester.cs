using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.Data.EntityClasses;
using Falcon.Web.UnitTests.Infrastructure.Application;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class OrderDetailRepositoryTester : RepositoryTesterBase
    {
        private IOrderDetailRepository _orderDetailRepository;
        private IMapper<SourceCodeOrderDetail, SourceCodeOrderDetailEntity>
            _mockedSourceCodeOrderDetailMapper;
        private IMapper<EventCustomerOrderDetail, EventCustomerOrderDetailEntity>
           _mockedEventCustomerOrderDetailMapper;

        private IMapper<ShippingDetailOrderDetail, ShippingDetailOrderDetailEntity>
            _mockedShippingDetailOrderDetailMapper;
        private ISourceCodeOrderDetailRepository _sourceCodeOrderDetailRepository;
        private IEventCustomerOrderDetailRepository _eventCustomerOrderDetailRepository;
        private IShippingDetailOrderDetailRepository _shippingDetailOrderDetailRepository;
        private IOrderItemRepository _mockedOrderItemRepository;
        private IMapper<OrderDetail, OrderDetailEntity> _mockedOrderDetailMapper;
        private IShippingOptionRepository _mockShippingOptionRepository;

        protected override void SetUp()
        {
            base.SetUp();
            _mocks.StrictMock<IOrderDetailFactory>();
            _mockedSourceCodeOrderDetailMapper = _mocks.StrictMock
                <IMapper<SourceCodeOrderDetail, SourceCodeOrderDetailEntity>>();
            _mockedEventCustomerOrderDetailMapper =
                _mocks.StrictMock<IMapper<EventCustomerOrderDetail, EventCustomerOrderDetailEntity>>();
            _mockedShippingDetailOrderDetailMapper =
                _mocks.StrictMock<IMapper<ShippingDetailOrderDetail, ShippingDetailOrderDetailEntity>>();
            _sourceCodeOrderDetailRepository = _mocks.StrictMock<ISourceCodeOrderDetailRepository>();
            _eventCustomerOrderDetailRepository = _mocks.StrictMock<IEventCustomerOrderDetailRepository>();
            _shippingDetailOrderDetailRepository = _mocks.StrictMock<IShippingDetailOrderDetailRepository>();
            _mockedOrderDetailMapper = _mocks.StrictMock<IMapper<OrderDetail, OrderDetailEntity>>();
            _mockedOrderItemRepository = _mocks.StrictMock<IOrderItemRepository>();
            _mockShippingOptionRepository = _mocks.StrictMock<IShippingOptionRepository>();

            _orderDetailRepository = new OrderDetailRepository(_persistenceLayer,
                                                               _mockedSourceCodeOrderDetailMapper,
                                                               _mockedEventCustomerOrderDetailMapper,
                                                               _mockedShippingDetailOrderDetailMapper,
                                                               _sourceCodeOrderDetailRepository,
                                                               _eventCustomerOrderDetailRepository,
                                                               _shippingDetailOrderDetailRepository,
                                                               _mockedOrderDetailMapper, _mockedOrderItemRepository, _mockShippingOptionRepository);
        }

        protected override void TearDown()
        {
            base.TearDown();
            _orderDetailRepository = null;
        }

        [Test]
        [ExpectedException(typeof(PersistenceFailureException))]
        public void SaveOrderDetailThrowsExceptionWhenSavingFails()
        {
            const bool saveSuccessful = false;
            var orderDetailToSave = new OrderDetail();

            Expect.Call(_sourceCodeOrderDetailRepository.GetForOrderDetailId(orderDetailToSave.Id)).
                Throw(new ObjectNotFoundInPersistenceException<SourceCodeOrderDetail>());
            Expect.Call(
                _shippingDetailOrderDetailRepository.GetForOrderDetailId(orderDetailToSave.Id)).Throw(
                new ObjectNotFoundInPersistenceException<ShippingDetailOrderDetail>());
            Expect.Call(_mockedOrderDetailMapper.Map(orderDetailToSave)).Return(new OrderDetailEntity());
            ExpectGetDataAccessAdapterAndDispose();
            ExpectSaveEntity(saveSuccessful, true);

            _mocks.ReplayAll();
            _orderDetailRepository.SaveOrderDetail(orderDetailToSave);
            _mocks.VerifyAll();
        }

        [Test]
        public void SourceCodeOrderDetailIsNotCreatedWhenASourceCodeIsNotUsed()
        {
            const bool saveSuccessful = true;
            var orderDetailEntityToSave = new OrderDetailEntity();
            var orderDetailToSave = new OrderDetail { OrderItemStatus = EventPackageItemStatus.Availed };

            Expect.Call(_sourceCodeOrderDetailRepository.GetForOrderDetailId(orderDetailToSave.Id)).
                Throw(new ObjectNotFoundInPersistenceException<SourceCodeOrderDetail>());
            Expect.Call(_mockedOrderDetailMapper.Map(orderDetailToSave)).Return(orderDetailEntityToSave);
            Expect.Call(_mockedOrderDetailMapper.Map(orderDetailEntityToSave)).Return(orderDetailToSave);

            ExpectGetDataAccessAdapterAndDispose();
            ExpectSaveEntity(saveSuccessful, true);

            _mocks.ReplayAll();
            _orderDetailRepository.SaveOrderDetail(orderDetailToSave);
            _mocks.VerifyAll();
        }

        [Test]
        public void SourceCodeOrderDetailIsCreatedWhenASourceCodeIsUsed()
        {
            const bool saveSuccessful = true;
            var orderDetailEntityToSave = new OrderDetailEntity();
            var orderDetailToSave = new OrderDetail
                                        {
                                            OrderItemStatus = EventPackageItemStatus.Availed,
                                            SourceCodeOrderDetail = new SourceCodeOrderDetail
                                                                        {
                                                                            Amount = 0,
                                                                            SourceCodeId = 0
                                                                        },
                                            DetailType = OrderItemType.EventPackageItem
                                        };

            Expect.Call(_sourceCodeOrderDetailRepository.GetForOrderDetailId(orderDetailToSave.Id)).
                Throw(new ObjectNotFoundInPersistenceException<SourceCodeOrderDetail>());
            Expect.Call(
                _sourceCodeOrderDetailRepository.GetForSourceCodeIdAndOrderDetailId(
                    orderDetailToSave.SourceCodeOrderDetail.SourceCodeId, orderDetailToSave.Id)).
                Throw(new ObjectNotFoundInPersistenceException<SourceCodeOrderDetail>());
            Expect.Call(_mockedOrderDetailMapper.Map(orderDetailToSave)).Return(orderDetailEntityToSave);
            Expect.Call(_mockedOrderDetailMapper.Map(orderDetailEntityToSave)).Return(orderDetailToSave);
            Expect.Call(_sourceCodeOrderDetailRepository.Save(null)).IgnoreArguments().Return(null);
            ExpectGetDataAccessAdapterAndDispose();
            ExpectSaveEntity(saveSuccessful, true);

            _mocks.ReplayAll();
            _orderDetailRepository.SaveOrderDetail(orderDetailToSave);
            _mocks.VerifyAll();
        }
    }
}