using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class EventPackageItem : OrderItem
    {
        public EventPackageItem()
        {}

        public EventPackageItem(long orderItemId)
            : base(orderItemId)
        {}

        public override OrderItemType OrderItemType
        {
            get { return OrderItemType.EventPackageItem; }
        }
    }
}