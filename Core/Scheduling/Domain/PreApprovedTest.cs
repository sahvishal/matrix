using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class PreApprovedTest:DomainObjectBase
    {
        public long CustomerId { get; set; }
        public long TestId { get; set; }
        public bool IsActive { get; set; }
        [IgnoreAudit]
        public long CreatedByOrgRoleUserId { get; set; }
        [IgnoreAudit]
        public DateTime DateCreated { get; set; }
        [IgnoreAudit]
        public DateTime? DateEnd { get; set; }
        //[IgnoreAudit]
        //public DataRecorderMetaData DataRecorderMetaData { get; set; }
    }
}
