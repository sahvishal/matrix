using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class GiftCertificateItem : OrderItem
    {
        public GiftCertificateItem()
        {}

        public GiftCertificateItem(long orderItemId)
            : base(orderItemId)
        {}

        public override OrderItemType OrderItemType
        {
            get { return OrderItemType.GiftCertificateItem; }
        }
    }
}