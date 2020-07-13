using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Users.Domain
{
    public class CustomerWarmTransfer : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public int WarmTransferYear { get; set; }
        public bool? IsWarmTransfer { get; set; }
        public long CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
