using System;

namespace Falcon.App.Core.CallCenter.Domain
{
    public class HealthPlanCriteriaTeamAssignment
    {
        public long HealthPlanCriteriaId { get; set; }
        public long TeamId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        
        public DateTime DateCreated { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
