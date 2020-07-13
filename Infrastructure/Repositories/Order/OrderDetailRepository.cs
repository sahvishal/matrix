using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Operations;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Mappers.Orders;
using Falcon.App.Infrastructure.Repositories.Shipping;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using Falcon.App.Core.Extensions;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Product = Falcon.App.Core.Enum.Product;


namespace Falcon.App.Infrastructure.Repositories.Order
{
    [DefaultImplementation]
    public class OrderDetailRepository : PersistenceRepository, IOrderDetailRepository
    {
        private readonly IMapper<SourceCodeOrderDetail, SourceCodeOrderDetailEntity> _sourceCodeOrderDetailMapper;

        private readonly IMapper<EventCustomerOrderDetail, EventCustomerOrderDetailEntity> _eventCustomerOrderDetailMapper;

        private readonly IMapper<ShippingDetailOrderDetail, ShippingDetailOrderDetailEntity> _shippingDetailOrderDetailMapper;
        private readonly IMapper<OrderDetail, OrderDetailEntity> _orderDetailMapper;
        private readonly ISourceCodeOrderDetailRepository _sourceCodeOrderDetailRepository;
        private readonly IEventCustomerOrderDetailRepository _eventCustomerOrderDetailRepository;
        private readonly IShippingDetailOrderDetailRepository _shippingDetailOrderDetailRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;

        public OrderDetailRepository()
            : this(new SqlPersistenceLayer(), new SourceCodeOrderDetailMapper(), new EventCustomerOrderDetailMapper(), new ShippingDetailOrderDetailMapper(),
            new SourceCodeOrderDetailRepository(), new EventCustomerOrderDetailRepository(),
            new ShippingDetailOrderDetailRepository(),
            new OrderDetailMapper(new OrderItemStatusFactory(), new DataRecorderMetaDataFactory()), new OrderItemRepository(), new ShippingOptionRepository())
        {
            _sourceCodeOrderDetailMapper = new SourceCodeOrderDetailMapper();
            _eventCustomerOrderDetailMapper = new EventCustomerOrderDetailMapper();
            _shippingDetailOrderDetailMapper = new ShippingDetailOrderDetailMapper();
            _sourceCodeOrderDetailRepository = new SourceCodeOrderDetailRepository();
            _eventCustomerOrderDetailRepository = new EventCustomerOrderDetailRepository();
            _shippingDetailOrderDetailRepository = new ShippingDetailOrderDetailRepository();
        }

        public OrderDetailRepository(IPersistenceLayer persistenceLayer,
            IMapper<SourceCodeOrderDetail, SourceCodeOrderDetailEntity> sourceCodeOrderDetailMapper,
            IMapper<EventCustomerOrderDetail, EventCustomerOrderDetailEntity>
            eventCustomerOrderDetailMapper,
            IMapper<ShippingDetailOrderDetail, ShippingDetailOrderDetailEntity>
            shippingDetailOrderDetailMapper,
            ISourceCodeOrderDetailRepository sourceCodeOrderDetailRepository,
            IEventCustomerOrderDetailRepository eventCustomerOrderDetailRepository,
            IShippingDetailOrderDetailRepository shippingDetailOrderDetailRepository,
            IMapper<OrderDetail, OrderDetailEntity> orderDetailMapper, IOrderItemRepository orderItemRepository, IShippingOptionRepository shippingOptionRepository)
            : base(persistenceLayer)
        {
            _sourceCodeOrderDetailMapper = sourceCodeOrderDetailMapper;
            _eventCustomerOrderDetailMapper = eventCustomerOrderDetailMapper;
            _shippingDetailOrderDetailMapper = shippingDetailOrderDetailMapper;
            _sourceCodeOrderDetailRepository = sourceCodeOrderDetailRepository;
            _eventCustomerOrderDetailRepository = eventCustomerOrderDetailRepository;
            _shippingDetailOrderDetailRepository = shippingDetailOrderDetailRepository;
            _orderDetailMapper = orderDetailMapper;
            _orderItemRepository = orderItemRepository;
            _shippingOptionRepository = shippingOptionRepository;
        }

        public List<OrderDetail> GetOrderDetailsForOrder(long orderId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                IQueryable<OrderDetailEntity> orderDetailEntities =
                    from orderDetail in linqMetaData.OrderDetail.WithPath(path =>
                        path.Prefetch(orderDetail => orderDetail.OrderItem))
                    where orderDetail.OrderId == orderId
                    select orderDetail;

                List<OrderDetail> orderDetails =
                    _orderDetailMapper.MapMultiple(orderDetailEntities).ToList();
                orderDetails.ForEach(od => od.OrderItem = _orderItemRepository.GetOrderItem(od.OrderItemId));

                GetSourceCodeInfo(linqMetaData, orderDetails);
                GetEventCustomerInfo(linqMetaData, orderDetails);
                GetShippingDetailInfo(linqMetaData, orderDetails);
                return orderDetails;
            }
        }

        private void GetSourceCodeInfo(LinqMetaData linqMetaData, IEnumerable<OrderDetail> orderDetails)
        {
            IEnumerable<long> orderDetailIds = orderDetails.Select(ode => ode.Id);
            IEnumerable<SourceCodeOrderDetailEntity> sourceCodesInOrder = linqMetaData.
                SourceCodeOrderDetail.Where(scod => orderDetailIds.Contains(scod.OrderDetailId) && scod.IsActive);
            foreach (var sourceCodeOrderDetailEntity in sourceCodesInOrder)
            {
                SourceCodeOrderDetail sourceCodeOrderDetail = _sourceCodeOrderDetailMapper.
                    Map(sourceCodeOrderDetailEntity);
                OrderDetail orderDetail = orderDetails.
                    Where(od => od.Id == sourceCodeOrderDetail.OrderDetailId).Single();
                orderDetail.SourceCodeOrderDetail = sourceCodeOrderDetail;
            }
        }

        private void GetEventCustomerInfo(LinqMetaData linqMetaData, IEnumerable<OrderDetail> orderDetails)
        {
            IEnumerable<long> orderDetailIds = orderDetails.Select(ode => ode.Id);

            IEnumerable<EventCustomerOrderDetailEntity> eventCustomersInOrder = linqMetaData.
                EventCustomerOrderDetail.Where(ecod => orderDetailIds.Contains(ecod.OrderDetailId) && ecod.IsActive);

            foreach (var eventCustomerInOrder in eventCustomersInOrder)
            {
                EventCustomerOrderDetail eventCustomerOrderDetail =
                     _eventCustomerOrderDetailMapper.Map(eventCustomerInOrder);
                OrderDetail orderDetail = orderDetails.
                    Where(od => od.Id == eventCustomerOrderDetail.OrderDetailId).Single();
                orderDetail.EventCustomerOrderDetail = eventCustomerOrderDetail;
            }
        }

        private void GetShippingDetailInfo(LinqMetaData linqMetaData, IEnumerable<OrderDetail> orderDetails)
        {
            IEnumerable<long> orderDetailIds = orderDetails.Select(ode => ode.Id);

            foreach (var orderDetailId in orderDetailIds)
            {
                long id = orderDetailId;

                OrderDetail orderDetail = orderDetails.Where(od => od.Id == id).Single();

                IEnumerable<ShippingDetailOrderDetailEntity> shippingDetailsInOrder =
                    linqMetaData.ShippingDetailOrderDetail.WithPath(
                        prefetchPath => prefetchPath.Prefetch(sdod => sdod.ShippingDetail)).Where(
                        sdod => id == sdod.OrderDetailId && sdod.IsActive);

                foreach (var shippingDetailInOrder in shippingDetailsInOrder)
                {
                    ShippingDetailOrderDetail shippingDetailOrderDetail = _shippingDetailOrderDetailMapper.
                        Map(shippingDetailInOrder);

                    if (orderDetail.ShippingDetailOrderDetails == null)
                        orderDetail.ShippingDetailOrderDetails = new List<ShippingDetailOrderDetail>();

                    orderDetail.ShippingDetailOrderDetails.Add(shippingDetailOrderDetail);
                }
            }
        }

        public OrderDetail SaveOrderDetail(OrderDetail orderDetailToSave)
        {
            var orderDetailEntityToSave = _orderDetailMapper.Map(orderDetailToSave);

            DeactivateExistingSourceCodes(orderDetailToSave.Id);
            if (orderDetailToSave.OrderItemStatus != null && orderDetailToSave.OrderItemStatus.OrderStatusState != OrderStatusState.FinalSuccess)
            {
                DeactivateExistingShippingDetails(orderDetailToSave.Id);
                DeactivateExistingEventCustomer(orderDetailToSave.Id);
            }

            SourceCodeOrderDetail sourceCodeOrderDetail = orderDetailToSave.SourceCodeOrderDetail;
            EventCustomerOrderDetail eventCustomerOrderDetail = orderDetailToSave.EventCustomerOrderDetail;
            List<ShippingDetailOrderDetail> shippingDetailsForOrderDetail = orderDetailToSave.ShippingDetailOrderDetails;

            var shippingDetailsOrderDetail = new List<ShippingDetailOrderDetail>();

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.SaveEntity(orderDetailEntityToSave, true))
                {
                    throw new PersistenceFailureException();
                }

                if (sourceCodeOrderDetail != null && orderDetailToSave.OrderItemStatus != null && orderDetailToSave.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && !ActivateExistingSourceCode(sourceCodeOrderDetail))
                {
                    sourceCodeOrderDetail.OrderDetailId = orderDetailEntityToSave.OrderDetailId;
                    sourceCodeOrderDetail = _sourceCodeOrderDetailRepository.Save(sourceCodeOrderDetail);
                }

                if (eventCustomerOrderDetail != null && orderDetailToSave.OrderItemStatus != null && orderDetailToSave.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && !ExistingEventCustomerOrderDetail(eventCustomerOrderDetail.EventCustomerId, orderDetailEntityToSave.OrderDetailId))
                {
                    eventCustomerOrderDetail.OrderDetailId = orderDetailEntityToSave.OrderDetailId;
                    eventCustomerOrderDetail = _eventCustomerOrderDetailRepository.Save(eventCustomerOrderDetail);
                }

                if (!shippingDetailsForOrderDetail.IsEmpty())
                {
                    foreach (var shippingDetailOrderDetail in shippingDetailsForOrderDetail)
                    {
                        if (shippingDetailOrderDetail != null && orderDetailToSave.OrderItemStatus != null && orderDetailToSave.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && !ExistingShippingDetailOrderDetail(shippingDetailOrderDetail.ShippingDetailId, orderDetailEntityToSave.OrderDetailId))
                        {
                            shippingDetailOrderDetail.OrderDetailId = orderDetailEntityToSave.OrderDetailId;
                            shippingDetailsOrderDetail.Add(
                                _shippingDetailOrderDetailRepository.Save(shippingDetailOrderDetail));
                        }
                    }
                }
            }

            // HACK
            OrderDetail detailToReturn = CreateOrderDetail(orderDetailToSave, orderDetailEntityToSave);
            detailToReturn.SourceCodeOrderDetail = sourceCodeOrderDetail;
            detailToReturn.EventCustomerOrderDetail = eventCustomerOrderDetail;
            detailToReturn.ShippingDetailOrderDetails = shippingDetailsOrderDetail;
            return detailToReturn;
        }

        private void DeactivateExistingSourceCodes(long orderDetailId)
        {
            try
            {
                IEnumerable<SourceCodeOrderDetail> sourceCodeOrderDetails =
                    _sourceCodeOrderDetailRepository.GetForOrderDetailId(orderDetailId);

                sourceCodeOrderDetails.ToList().ForEach(
                    scod => _sourceCodeOrderDetailRepository.UpdateStatus(scod.SourceCodeId, scod.OrderDetailId, false));

            }
            catch (ObjectNotFoundInPersistenceException<SourceCodeOrderDetail>)
            { }
        }

        private void DeactivateExistingShippingDetails(long orderDetailId)
        {
            try
            {
                IEnumerable<ShippingDetailOrderDetail> shippingDetailOrderDetails =
                    _shippingDetailOrderDetailRepository.GetForOrderDetailId(orderDetailId);

                shippingDetailOrderDetails.ToList().ForEach(
                    sdod =>
                    _shippingDetailOrderDetailRepository.UpdateStatus(sdod.ShippingDetailId, sdod.OrderDetailId, false));

            }
            catch (ObjectNotFoundInPersistenceException<SourceCodeOrderDetail>)
            { }
        }

        private void DeactivateExistingEventCustomer(long orderDetailId)
        {
            try
            {
                IEnumerable<EventCustomerOrderDetail> eventCustomerOrderDetails =
                    _eventCustomerOrderDetailRepository.GetForOrderDetailId(orderDetailId);

                eventCustomerOrderDetails.ToList().ForEach(
                    ecod =>
                    _eventCustomerOrderDetailRepository.UpdateStatus(ecod.EventCustomerId, ecod.OrderDetailId, false));

            }
            catch (ObjectNotFoundInPersistenceException<SourceCodeOrderDetail>)
            { }
        }


        private bool ActivateExistingSourceCode(SourceCodeOrderDetail newSourceCodeOrderDetail)
        {
            try
            {
                SourceCodeOrderDetail sourceCodeOrderDetail =
                    _sourceCodeOrderDetailRepository.GetForSourceCodeIdAndOrderDetailId(
                        newSourceCodeOrderDetail.SourceCodeId, newSourceCodeOrderDetail.OrderDetailId);

                if (sourceCodeOrderDetail != null)
                {
                    _sourceCodeOrderDetailRepository.UpdateStatus(sourceCodeOrderDetail.SourceCodeId,
                                                                  sourceCodeOrderDetail.OrderDetailId, true);
                    _sourceCodeOrderDetailRepository.UpdateAmount(sourceCodeOrderDetail.SourceCodeId,
                                                                  sourceCodeOrderDetail.OrderDetailId,
                                                                  newSourceCodeOrderDetail.Amount,
                                                                  newSourceCodeOrderDetail.OrganizationRoleUserCreatorId);
                    return true;
                }
                return false;
            }
            catch (ObjectNotFoundInPersistenceException<SourceCodeOrderDetail>)
            { return false; }
        }

        private OrderDetail CreateOrderDetail(OrderDetail orderDetailToSave,
            OrderDetailEntity orderDetailEntityToSave)
        {
            IOrderItemStatusFactory orderItemStatusFactory = new OrderItemStatusFactory();
            OrderItemType orderItemType = orderItemStatusFactory.GetOrderItemType
                (orderDetailToSave.OrderItemStatus);
            orderDetailEntityToSave.OrderItem = new OrderItemEntity { Type = (short)orderItemType };
            OrderDetail detailToReturn = _orderDetailMapper.Map(orderDetailEntityToSave);
            return detailToReturn;
        }

        public List<OrderDetail> SaveOrderDetails(IEnumerable<OrderDetail> orderDetails)
        {
            var orderDetailsToReturn = new List<OrderDetail>();
            foreach (var orderDetail in orderDetails)
            {
                orderDetailsToReturn.Add(SaveOrderDetail(orderDetail));
            }
            return orderDetailsToReturn;
        }

        private bool ExistingEventCustomerOrderDetail(long newEventCustomerId, long newOrderDetailId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return
                    linqMetaData.EventCustomerOrderDetail.Any(
                        ecod => ecod.EventCustomerId == newEventCustomerId && ecod.OrderDetailId == newOrderDetailId);
            }

        }

        private bool ExistingShippingDetailOrderDetail(long newShippingDetailId, long newOrderDetailId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return
                    linqMetaData.ShippingDetailOrderDetail.Any(
                        sdod =>
                        sdod.ShippingDetailId == newShippingDetailId && sdod.OrderDetailId == newOrderDetailId &&
                        sdod.IsActive);

            }
        }

        private bool DeleteOrderDetailMappings(OrderDetail orderDetail)
        {
            if (orderDetail.EventCustomerOrderDetail != null)
                _eventCustomerOrderDetailRepository.Delete(orderDetail.EventCustomerOrderDetail);
            if (!orderDetail.ShippingDetailOrderDetails.IsEmpty())
                _shippingDetailOrderDetailRepository.Delete(orderDetail.ShippingDetailOrderDetails);
            return true;
        }

        public IEnumerable<OrderedPair<long, ShipmentStatus>> GetCdImageShippingStatusfortheEventCustomers(long[] eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var queryOrders = from ecod in linqMetaData.EventCustomerOrderDetail
                                  join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                                  where ecod.IsActive && eventCustomerIds.Contains(ecod.EventCustomerId)
                                  select new { ecod.EventCustomerId, od.OrderId };

                var queryOrderswithProduct = (from qo in queryOrders
                                              join od in linqMetaData.OrderDetail on qo.OrderId equals od.OrderId
                                              join poi in linqMetaData.ProductOrderItem on od.OrderItemId equals poi.OrderItemId
                                              where od.Status == (int)OrderStatusState.FinalSuccess
                                              && poi.ProductId == (long)Product.UltraSoundImages
                                              select new { qo.EventCustomerId, qo.OrderId }).ToArray();

                var orderIds = queryOrderswithProduct.Select(q => q.OrderId).ToArray();

                var cdShippingOption = _shippingOptionRepository.GetShippingOptionByProductId((long)Product.UltraSoundImages);

                var orderAndShippingStatusPairs = (from od in linqMetaData.OrderDetail
                                                   join sdod in linqMetaData.ShippingDetailOrderDetail on od.OrderDetailId equals sdod.OrderDetailId
                                                   join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
                                                   where orderIds.Contains(od.OrderId) && sdod.IsActive
                                                   && od.Status == (int)OrderStatusState.FinalSuccess && sd.Status.HasValue
                                                   && (cdShippingOption != null ? sd.ShippingOptionId == cdShippingOption.Id : true)
                                                   select new OrderedPair<long, ShipmentStatus>(od.OrderId, (ShipmentStatus)sd.Status.Value)).Distinct().ToArray();

                return (from qo in queryOrderswithProduct
                        join od in orderAndShippingStatusPairs on qo.OrderId equals od.FirstValue
                        select new OrderedPair<long, ShipmentStatus>(qo.EventCustomerId, od.SecondValue)).ToArray();
            }
        }

        public bool UpdateOrderDetail(long cancelledOrderId, long activeOrderId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new OrderDetailEntity { OrderId = activeOrderId };

                var bucket = new RelationPredicateBucket(OrderDetailFields.OrderId == cancelledOrderId);

                return (adapter.UpdateEntitiesDirectly(entity, bucket) > 0) ? true : false;
            }
        }

    }
}