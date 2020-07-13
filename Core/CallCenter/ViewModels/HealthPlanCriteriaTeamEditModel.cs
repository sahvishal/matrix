using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class HealthPlanCriteriaTeamEditModel : ViewModelBase
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsFillEventCallQueue { get; set; }
        public long CriteriaId { get; set; }
        public long CallQueueId { get; set; }
        public long HealthPlanId { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsStartDateEditable { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsEdited { get; set; }

        public IEnumerable<string> Agents { get; set; }
    }
}