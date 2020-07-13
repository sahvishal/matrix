using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Core.Finance.Domain
{
    public class Order : DomainObjectBase
    {
        // Order for which Customer, for which Event
        public long CustomerId { get; set; }
        public long? EventId { get; set; } // Can it be a nullable field, in case of products.
        
        private List<OrderDetail> _orderDetails;
        public List<OrderDetail> OrderDetails
        {
            get
            {
                if (_orderDetails == null)
                {
                    _orderDetails = new List<OrderDetail>();
                }
                return _orderDetails;
            }
            set { _orderDetails = value; }
        }
        private List<PaymentInstrument> _paymentsApplied;
        public List<PaymentInstrument> PaymentsApplied
        {
            get
            {
                if (_paymentsApplied == null)
                {
                    _paymentsApplied = new List<PaymentInstrument>();
                }
                return _paymentsApplied;
            }
            set { _paymentsApplied = value; }
        }
        public OrderStatus OrderStatus
        {
            get
            {
                return OrderDetails.IsEmpty() ? OrderStatus.Empty : (OrderDetails.All(od => od.IsCompleted) ?
                    OrderStatus.Closed : OrderStatus.Open);
            }
        }

        public decimal OrderDiscount
        {
            get
            {
                var sourceCodeOrderDetail =
                    _orderDetails.SingleOrDefault(
                        od => od.IsCompleted && od.SourceCodeOrderDetail != null && od.SourceCodeOrderDetail.IsActive);
                if(sourceCodeOrderDetail != null)
                {
                    return sourceCodeOrderDetail.SourceCodeOrderDetail.Amount;
                }
                return 0m;
            }
        }

        // TODO: this is writeen here because we need to show the screening price at many places, but it should not be here because order can be much more.
        public decimal OrderValue
        {
            get
            {
                return
                    OrderDetails.Where(
                        od =>
                        (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem) &&
                        od.IsCompleted).Sum(od => od.Price);
            }
        }

        public decimal? ProductCost
        {
            get
            {
                var electronicProductDetails = OrderDetails.Where(od => (od.DetailType == OrderItemType.ProductItem) && od.IsCompleted).ToList();
                if (electronicProductDetails != null && electronicProductDetails.Count > 0)
                {
                    return electronicProductDetails.Sum(epd => epd.Price);
                }
                return null;
            }
        }

        public decimal UndiscountedTotal
        {
            get
            {
                return
                    OrderDetails.Sum(
                        od =>
                        ((od.DetailType != OrderItemType.RefundItem ? od.Price : (-1) * od.Price) * od.Quantity) +
                        (ShippingDetailAmount(od)));
            }
        }

        public decimal DiscountedTotal
        {
            get
            {
                Func<OrderDetail, decimal> amountOfDiscount = od => od.SourceCodeOrderDetail == null ? 0 : od.SourceCodeOrderDetail.Amount;
                return
                    OrderDetails.Sum(
                        od =>
                        ((od.DetailType != OrderItemType.RefundItem ? od.Price : (-1) * od.Price) * od.Quantity) +
                        (ShippingDetailAmount(od)) - amountOfDiscount(od));
            }
        }

        public decimal TotalAmountPaid
        {
            get
            {
                return PaymentsApplied.Sum(pa => pa.Amount);
            }
        }

        public OrderType OrderType { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public Order()
        { }

        public Order(long orderId)
            : base(orderId)
        { }


        private static decimal ShippingDetailAmount(OrderDetail orderDetail)
        {
            return orderDetail.ShippingDetailOrderDetails != null && !orderDetail.ShippingDetailOrderDetails.IsEmpty()
                       ? orderDetail.ShippingDetailOrderDetails.Sum(sdod => sdod.Amount)
                       : 0;
        }
    }
}