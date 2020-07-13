using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public abstract class OrderItem : DomainObjectBase
    {
        public long ItemId { get; set; }
        public abstract OrderItemType OrderItemType { get; }

        protected OrderItem()
        {}

        protected OrderItem(long orderItemId)
            : base(orderItemId)
        {}
    }
}