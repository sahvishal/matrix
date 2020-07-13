using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class ProductItem : OrderItem
    {
        public ProductItem()
        {}

        public ProductItem(long orderItemId)
            : base(orderItemId)
        {}

        public override OrderItemType OrderItemType
        {
            get { return OrderItemType.ProductItem; }
        }
    }
}