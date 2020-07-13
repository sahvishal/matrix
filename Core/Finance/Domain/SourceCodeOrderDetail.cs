using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Finance.Domain
{
    public class SourceCodeOrderDetail : DomainObjectBase
    {
        public long OrderDetailId { get; set; }
        public long SourceCodeId { get; set; }
        public decimal Amount { get; set; }
        public long OrganizationRoleUserCreatorId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}