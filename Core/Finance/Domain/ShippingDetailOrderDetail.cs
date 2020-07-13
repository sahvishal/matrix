using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Finance.Domain
{
    public class ShippingDetailOrderDetail : DomainObjectBase
    {
        public long OrderDetailId { get; set; }
        public long ShippingDetailId { get; set; }
        public bool IsActive { get; set; }
        public decimal Amount { get; set; }
    }
}
