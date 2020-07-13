using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Users.Domain
{
    public class CustomerTargeted : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public int ForYear { get; set; }
        public bool? IsTargated { get; set; }
        public long CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
