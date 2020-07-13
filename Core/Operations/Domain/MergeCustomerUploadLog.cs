using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class MergeCustomerUploadLog : DomainObjectBase
    {
        public long UploadId { get; set; }
        public long CustomerId { get; set; }
        public string DuplicateCustomerId { get; set; }
        public long StatusId { get; set; }
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
    }
}
