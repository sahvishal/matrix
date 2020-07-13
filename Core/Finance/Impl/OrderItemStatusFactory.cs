using System;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation]
    public class OrderItemStatusFactory : IOrderItemStatusFactory
    {
        public OrderItemStatus CreateOrderItemStatus(OrderItemType orderItemType, int orderItemStatus)
        {
            switch (orderItemType)
            {
                case OrderItemType.GiftCertificateItem:
                    return GiftCertificateItemStatus.GetStatusByStatusCode(orderItemStatus);
                case OrderItemType.EventPackageItem:
                    return EventPackageItemStatus.GetStatusByStatusCode(orderItemStatus);
                case OrderItemType.ProductItem:
                    return ProductItemStatus.GetStatusByStatusCode(orderItemStatus);
                case OrderItemType.RefundItem:
                    return RefundItemStatus.GetStatusByStatusCode(orderItemStatus);
                case OrderItemType.EventTestItem:
                    return EventTestItemStatus.GetStatusByStatusCode(orderItemStatus);    
                case OrderItemType.CancellationFee:
                    return CancellationFeeItemStatus.GetStatusByStatusCode(orderItemStatus);
                default:
                    throw new NotSupportedException
                        ("The type of OrderItem this OrderDetail pertains to is not yet supported.");
            }
        }
        
        public OrderItemType GetOrderItemType(OrderItemStatus orderItemStatus)
        {
            Type type = orderItemStatus.GetType();
            if (type == typeof(GiftCertificateItemStatus))
            {
                return OrderItemType.GiftCertificateItem;
            }
            if (type == typeof(EventPackageItemStatus))
            {
                return OrderItemType.EventPackageItem;
            }
            if (type == typeof(ProductItemStatus))
            {
                return OrderItemType.ProductItem;
            }
            if (type == typeof(RefundItemStatus))
            {
                return OrderItemType.RefundItem;
            }
            if (type == typeof(EventTestItemStatus))
            {
                return OrderItemType.EventTestItem;
            }
            if(type == typeof(CancellationFeeItemStatus))
                return OrderItemType.CancellationFee;
            throw new NotSupportedException
                ("The given type of OrderItemStatus does not have a corresponding OrderItemType.");
        }
    }
}