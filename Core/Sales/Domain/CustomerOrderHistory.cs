using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class CustomerOrderHistory : DomainObjectBase
    {
        public long UploadId { get; set; }
        public long EventCustomerId { get; set; }
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public long? EventPackageId { get; set; }
        public long? EventTestId { get; set; }
        public long OrderItemStatusId { get; set; }
    }
}
