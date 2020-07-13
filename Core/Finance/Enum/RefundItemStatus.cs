using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Enum
{
    public sealed class RefundItemStatus : OrderItemStatus
    {
        public static readonly OrderItemStatus Applied = new RefundItemStatus(1, "Applied", Core.Enum.OrderStatusState.FinalSuccess);
        public static readonly OrderItemStatus NotApplied = new RefundItemStatus(0, "Reverted", Core.Enum.OrderStatusState.Initial);

        public override string ItemTypeName { get { return "Refund"; } }

        private RefundItemStatus(int statusCode, string name, OrderStatusState orderStatusState) :
            base(statusCode, name, orderStatusState)
        {}

        // TODO: Somehow pull into OrderItemStatus.
        public static OrderItemStatus GetStatusByStatusCode(int statusCode)
        {
            var orderItemStatuses = new List<OrderItemStatus> { Applied, NotApplied };
            return orderItemStatuses.Single(ois => ois.StatusCode == statusCode);
        }
    }
}