using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class HealthPlanCriteriaAssignment : DomainObjectBase
    {
        public long HealthPlanCriteriaId { get; set; }
        public long AssignedToOrgRoleUserId { get; set; }
        public string EventId { get; set; }
        public string CustomTagId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DateTime DateCreated { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
