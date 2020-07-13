using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Finance.Domain
{
    public class EventCustomerOrderDetail : DomainObjectBase
    {
        public long OrderDetailId { get; set; }
        public long EventCustomerId { get; set; }
        public bool IsActive { get; set; }

    }
}
