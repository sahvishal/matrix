using System;
using System.Collections.Generic;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Infrastructure.Factories.Order
{
    // TODO: Find out how to deal with CreateOrderDetail overload.
    public class OrderDetailFactory : IOrderDetailFactory
    {
        private readonly IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;
        private readonly IOrderItemStatusFactory _orderItemStatusFactory;

        public OrderDetailFactory()
            : this(new DataRecorderMetaDataFactory(), new OrderItemStatusFactory())
        { }

        public OrderDetailFactory(IDataRecorderMetaDataFactory dataRecorderMetaDataFactory,
            IOrderItemStatusFactory orderItemStatusFactory)
        {
            _dataRecorderMetaDataFactory = dataRecorderMetaDataFactory;
            _orderItemStatusFactory = orderItemStatusFactory;
        }

        public OrderDetail CreateNewOrderDetail(IOrderable orderable, int quantity,
            long forOrganizationRoleUserId, long dataRecorderCreatorId, SourceCode sourceCode,
            EventCustomer eventCustomer, ShippingDetail shippingDetail, long? sourceId = null)
        {
            if (orderable == null)
            {
                throw new ArgumentNullException("orderable");
            }
            if (orderable.Id == 0)
            {
                throw new InvalidOperationException("itemToOrder must already exist in the database.");
            }
            if (quantity < 1)
            {
                throw new ArgumentOutOfRangeException("quantity", "The quantity must be at least 1.");
            }
            DataRecorderMetaData dataRecorderMetaData = _dataRecorderMetaDataFactory.
                CreateDataRecorderMetaData(dataRecorderCreatorId);
            OrderItemStatus orderItemStatus = _orderItemStatusFactory.CreateOrderItemStatus(orderable.
                OrderItemType, (int)OrderStatusState.Initial);

            decimal price = orderable.Price;

            // TODO: Test source code logic.
            SourceCodeOrderDetail sourceCodeOrderDetail = null;
            if (sourceCode != null)
            {
                sourceCodeOrderDetail = new SourceCodeOrderDetail
                                            {
                                                Amount = sourceCode.CouponValue,
                                                SourceCodeId = sourceCode.Id,
                                                IsActive = true,
                                                OrganizationRoleUserCreatorId =
                                                    dataRecorderMetaData.DataRecorderCreator.Id
                                            };
            }

            EventCustomerOrderDetail eventCustomerOrderDetail = null;
            if (eventCustomer != null)
            {
                eventCustomerOrderDetail = new EventCustomerOrderDetail
                                               {
                                                   EventCustomerId = eventCustomer.Id,
                                                   IsActive = true
                                               };
            }

            ShippingDetailOrderDetail shippingDetailOrderDetail = null;
            if (shippingDetail != null)
            {
                shippingDetailOrderDetail = new ShippingDetailOrderDetail
                                                {
                                                    ShippingDetailId = shippingDetail.Id,
                                                    IsActive = true
                                                };
            }

            return new OrderDetail
                       {
                           Description = orderable.Description,
                           Price = price,
                           Quantity = quantity,
                           DetailType = orderable.OrderItemType,
                           DataRecorderMetaData = dataRecorderMetaData,
                           ForOrganizationRoleUserId = forOrganizationRoleUserId,
                           OrderItemStatus = orderItemStatus,
                           SourceCodeOrderDetail = sourceCodeOrderDetail,
                           EventCustomerOrderDetail = eventCustomerOrderDetail,
                           ShippingDetailOrderDetails = new List<ShippingDetailOrderDetail> { shippingDetailOrderDetail },
                           SourceId = sourceId
                       };
        }

        public OrderDetail CreateNewOrderDetail(OrderDetail existingOrderDetail, long forOrganizationRoleUserId,
            long dataRecorderCreatorId)
        {
            DataRecorderMetaData dataRecorderMetaData = _dataRecorderMetaDataFactory.
                CreateDataRecorderMetaData(dataRecorderCreatorId);
            OrderItemStatus orderItemStatus;
            // Negate the entry for the existing order detail.
            decimal price = existingOrderDetail.Price * (-1);
            if (existingOrderDetail.DetailType != OrderItemType.RefundItem)
            {
                existingOrderDetail.OrderItemStatus =
                    _orderItemStatusFactory.CreateOrderItemStatus(existingOrderDetail.DetailType,
                                                                  (int) OrderStatusState.Initial);
                orderItemStatus =
                    _orderItemStatusFactory.CreateOrderItemStatus(existingOrderDetail.DetailType,
                                                                  (int) OrderStatusState.FinalFailure);
            }
            else
            {
                orderItemStatus =
                    _orderItemStatusFactory.CreateOrderItemStatus(existingOrderDetail.DetailType,
                                                                  (int) OrderStatusState.Initial);
            }
            return new OrderDetail
                       {
                           Description = existingOrderDetail.Description,
                           Price = price,
                           Quantity = existingOrderDetail.Quantity,
                           DataRecorderMetaData = dataRecorderMetaData,
                           ForOrganizationRoleUserId = forOrganizationRoleUserId,
                           OrderItemStatus = orderItemStatus,
                           OrderId = existingOrderDetail.OrderId,
                           OrderItemId = existingOrderDetail.OrderItemId,
                           SourceCodeOrderDetail = null,
                           EventCustomerOrderDetail = null,
                           ShippingDetailOrderDetails = null,
                           DetailType = existingOrderDetail.DetailType,
                           SourceId = existingOrderDetail.SourceId
                       };
        }

        public OrderDetail CreateNewOrderDetailforCanellationItem(decimal cancellationFee, long orderId, long forOrganizationRoleUserId,
            long dataRecorderCreatorId)
        {
            DataRecorderMetaData dataRecorderMetaData = _dataRecorderMetaDataFactory.
                CreateDataRecorderMetaData(dataRecorderCreatorId);

            OrderItemStatus orderItemStatus =
                _orderItemStatusFactory.CreateOrderItemStatus(OrderItemType.CancellationFee,
                                                              (int)OrderStatusState.FinalSuccess); // orFinalFailure

            return new OrderDetail
            {
                Description = "Cancellation fee charged",
                Price = cancellationFee,
                Quantity = 1,
                DataRecorderMetaData = dataRecorderMetaData,
                ForOrganizationRoleUserId = forOrganizationRoleUserId,
                OrderItemStatus = orderItemStatus,
                OrderId = orderId,
                OrderItemId = 0, // Need a new Order Item
                SourceCodeOrderDetail = null,
                EventCustomerOrderDetail = null,
                ShippingDetailOrderDetails = null,
                DetailType = OrderItemType.CancellationFee
            };
        }
    }
}