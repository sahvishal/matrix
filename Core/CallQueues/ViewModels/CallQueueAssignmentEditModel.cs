using System;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueAssignmentEditModel
    {
        public long HealthPlanCriteriaId { get; set; }
        public long CallQueueId { get; set; }
        public long AssignedOrgRoleUserId { get; set; }
        public string Name { get; set; }
        public int Percentage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsExistInOtherCriteria { get; set; }
        public bool IsEdited { get; set; }
    }
}
