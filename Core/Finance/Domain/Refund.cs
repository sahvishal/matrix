using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;

namespace Falcon.App.Core.Finance.Domain
{
    public class Refund : DomainObjectBase, IOrderable
    {
        public RefundReason RefundReason { get; set; }
        public string Notes { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public Refund()
        {}

        public Refund(long refundId)
            : base(refundId)
        {}

        public decimal Price { get; set; }

        public string Description
        {
            get { return string.Format("Refund -- {0}", Notes); }            
        }

        public OrderItemType OrderItemType
        {
            get { return OrderItemType.RefundItem; }
        }
    }
}