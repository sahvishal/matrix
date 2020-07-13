using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class CancellationFeeItem : OrderItem
    {
        public CancellationFeeItem()
        {}

        public CancellationFeeItem(long orderItemId)
            : base(orderItemId)
        { }
        public override OrderItemType OrderItemType
        {
            get { return OrderItemType.CancellationFee; }
        }
    }
}
