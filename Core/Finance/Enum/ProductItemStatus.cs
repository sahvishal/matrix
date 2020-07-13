using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Enum
{
    public sealed class ProductItemStatus : OrderItemStatus
    {
        //public static readonly OrderItemStatus Pending = new ProductItemStatus(0, "Pending", OrderStatusState.Initial);
        //public static readonly OrderItemStatus Shipped = new ProductItemStatus(1, "Shipped", OrderStatusState.FinalSuccess);

        //public override string ItemTypeName { get { return "Product"; } }

        //private ProductItemStatus(int statusCode, string name, OrderStatusState orderStatusState):
        //    base(statusCode, name, orderStatusState)
        //{}

        //// TODO: Somehow pull into OrderItemStatus.
        //public static OrderItemStatus GetStatusByStatusCode(int statusCode)
        //{
        //    var orderItemStatuses = new List<OrderItemStatus> { Pending, Shipped };
        //    return orderItemStatuses.Single(ois => ois.StatusCode == statusCode);
        //}
        public static readonly OrderItemStatus Availed = new ProductItemStatus(1, "Availed", Core.Enum.OrderStatusState.FinalSuccess);
        public static readonly OrderItemStatus Ordered = new ProductItemStatus(0, "Ordered", Core.Enum.OrderStatusState.Initial);
        public static readonly OrderItemStatus Cancelled = new ProductItemStatus(2, "Cancelled", Core.Enum.OrderStatusState.FinalFailure);

        public override string ItemTypeName { get { return "Product"; } }

        private ProductItemStatus(int statusCode, string name, OrderStatusState orderStatusState) :
            base(statusCode, name, orderStatusState)
        {}

        // TODO: Somehow pull into OrderItemStatus.
        public static OrderItemStatus GetStatusByStatusCode(int statusCode)
        {
            var orderItemStatuses = new List<OrderItemStatus> { Availed, Ordered, Cancelled };
            return orderItemStatuses.Single(ois => ois.StatusCode == statusCode);
        }
    }
}