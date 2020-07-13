using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Enum
{
    public class GiftCertificateItemStatus : OrderItemStatus
    {
        public static readonly OrderItemStatus NotPaidFor = new GiftCertificateItemStatus(0, "Pending", OrderStatusState.Initial);
        public static readonly OrderItemStatus PaidFor = new GiftCertificateItemStatus(1, "Shipped", OrderStatusState.FinalSuccess);

        public override string ItemTypeName { get { return "Gift Certificate"; } }

        private GiftCertificateItemStatus(int statusCode, string name, OrderStatusState orderStatusState) :
            base(statusCode, name, orderStatusState)
        {}

        // TODO: Somehow pull into OrderItemStatus.
        public static OrderItemStatus GetStatusByStatusCode(int statusCode)
        {
            var orderItemStatuses = new List<OrderItemStatus> { NotPaidFor, PaidFor };
            return orderItemStatuses.Single(ois => ois.StatusCode == statusCode);
        }
    }
}