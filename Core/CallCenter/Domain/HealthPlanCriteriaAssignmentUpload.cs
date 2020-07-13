using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallCenter.Domain
{
    public class HealthPlanCriteriaAssignmentUpload : DomainObjectBase
    {
        public long FileId { get; set; }
        public DateTime UploadTime { get; set; }
        public long UploadedByOrgRoleUserId { get; set; }
        public long CriteriaId { get; set; }
    }
}
