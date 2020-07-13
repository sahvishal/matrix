using System;
using Falcon.App.Core.Enum;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Finance.Interfaces;

namespace Falcon.App.Infrastructure.Factories.Order
{
    public class OrderItemTraitsFactory : IOrderItemTraitsFactory
    {
        public IOrderItemTraits CreateTraits(OrderItemType orderItemType)
        {
            switch (orderItemType)
            {
                case OrderItemType.GiftCertificateItem:
                    return new GiftCertificateOrderItemTraits();
                case OrderItemType.EventPackageItem:
                    return new EventPackageOrderItemTraits();
                case OrderItemType.ProductItem:
                    return new ProductOrderItemTraits();
                case OrderItemType.RefundItem:
                    return new RefundOrderItemTraits();
                case OrderItemType.EventTestItem:
                    return new EventTestOrderItemTraits();
                case OrderItemType.CancellationFee:
                    return new CancellationFeeOrderItemTraits();
                default:
                    throw new NotSupportedException(string.Format("The OrderType {0} is not yet supported.", orderItemType));
            }
        }
    }
}