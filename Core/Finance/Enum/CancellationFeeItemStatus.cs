using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Enum
{
    public sealed class CancellationFeeItemStatus : OrderItemStatus
    {
        public static readonly OrderItemStatus Availed = new CancellationFeeItemStatus(1, "Availed", OrderStatusState.FinalSuccess);
        public static readonly OrderItemStatus Ordered = new CancellationFeeItemStatus(0, "Ordered", OrderStatusState.Initial);
        public static readonly OrderItemStatus Cancelled = new CancellationFeeItemStatus(2, "Cancelled", OrderStatusState.FinalFailure);

        public override string ItemTypeName { get { return "Cancellation Fee"; } }

        private CancellationFeeItemStatus(int statusCode, string name, OrderStatusState orderStatusState) :
            base(statusCode, name, orderStatusState)
        { }

        // TODO: Somehow pull into OrderItemStatus.
        public static OrderItemStatus GetStatusByStatusCode(int statusCode)
        {
            var orderItemStatuses = new List<OrderItemStatus> { Availed, Ordered, Cancelled };
            return orderItemStatuses.Single(ois => ois.StatusCode == statusCode);
        }
    }
}
