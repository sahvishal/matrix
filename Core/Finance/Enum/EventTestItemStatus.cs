using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Enum
{
    public sealed class EventTestItemStatus : OrderItemStatus
    {
        public static readonly OrderItemStatus Availed = new EventTestItemStatus(1, "Availed", Core.Enum.OrderStatusState.FinalSuccess);
        public static readonly OrderItemStatus Ordered = new EventTestItemStatus(0, "Ordered", Core.Enum.OrderStatusState.Initial);
        public static readonly OrderItemStatus Cancelled = new EventTestItemStatus(2, "Cancelled", Core.Enum.OrderStatusState.FinalFailure);

        public override string ItemTypeName { get { return "Event Test"; } }

        private EventTestItemStatus(int statusCode, string name, OrderStatusState orderStatusState):
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