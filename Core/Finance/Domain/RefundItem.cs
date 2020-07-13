using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class RefundItem : OrderItem
    {
        public RefundItem()
        {}

        public RefundItem(long orderItemId)
            : base(orderItemId)
        {}

        public override OrderItemType OrderItemType
        {
            get { return OrderItemType.RefundItem; }
        }
    }
}