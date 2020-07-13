using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class EventTestItem : OrderItem
    {
        public EventTestItem()
        { }

        public EventTestItem(long orderItemId)
            : base(orderItemId)
        { }

        public override OrderItemType OrderItemType
        {
            get { return OrderItemType.EventTestItem; }
        }
    }
}