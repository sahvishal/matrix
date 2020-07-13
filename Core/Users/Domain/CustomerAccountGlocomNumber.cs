using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Users.Domain
{
    public class CustomerAccountGlocomNumber : DomainObjectBase
    {
        public long CallId { get; set; }
        public long CustomerId { get; set; }
        public string GlocomNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
