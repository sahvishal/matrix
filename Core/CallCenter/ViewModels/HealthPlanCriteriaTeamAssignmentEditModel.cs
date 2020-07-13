using System;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class HealthPlanCriteriaTeamAssignmentEditModel
    {
        public long TeamId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long CriteriaId { get; set; }
        public bool IsEdited { get; set; }
    }
}
