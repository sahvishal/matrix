using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class CurrentMedication:DomainObjectBase
    {
        public long CustomerId { get; set; }
        public long NdcId { get; set; }
        public bool IsActive { get; set; }
        public bool IsPrescribed { get; set; }
        public bool IsOtc { get; set; }

        [IgnoreAudit]
        public DateTime DateCreated { get; set; }
        [IgnoreAudit]
        public long CreatedByOrgRoleUserId { get; set; }
        [IgnoreAudit]
        public DateTime? DateEnd { get; set; }
        //[IgnoreAudit]
        //public DataRecorderMetaData DataRecorderMetaData { get; set; }
    }
}
