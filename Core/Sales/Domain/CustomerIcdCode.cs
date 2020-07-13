using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class CustomerIcdCode : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public long IcdCodeId { get; set; }
        public bool IsActive { get; set; }
        [IgnoreAudit]
        public DateTime DateCreated { get; set; }
        [IgnoreAudit]
        public long CreatedByOrgRoleUserId { get; set; }
        [IgnoreAudit]
        public DateTime? DateEnd { get; set; }
    }
}