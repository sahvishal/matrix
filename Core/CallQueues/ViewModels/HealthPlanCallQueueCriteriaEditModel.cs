using Falcon.App.Core.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class HealthPlanCallQueueCriteriaEditModel : ViewModelBase
    {
        public long Id { get; set; }

        [Display(Name = "Criteria Name")]
        [MinLength(5), MaxLength(255)]
        public string CriteriaName { get; set; }

        public long CallQueueId { get; set; }

        [Display(Name = "Call Queue")]
        public string CallQueue { get; set; }

        [Display(Name = "Health Plan")]
        public long HealthPlanId { get; set; }

        public int? Radius { get; set; }

        public string Zipcode { get; set; }

        public int? NoOfDays { get; set; }

        public int? RoundOfCalls { get; set; }

        public int? NoOfDaysOfEvents { get; set; }

        public int? Percentage { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public long? CampaignId { get; set; }

        public IEnumerable<CallQueueAssignmentEditModel> Assignments { get; set; }

        public IEnumerable<long> Campaigns { get; set; }

        public string UploadFileName { get; set; }

        public bool IsTeamAssignment { get; set; }

        public List<HealthPlanCriteriaTeamAssignmentEditModel> CallCenterTeamAssignments { get; set; }

        public long? LanguageId { get; set; }

        public IEnumerable<CampaignDirectMailDatesEditModel> CampaignDirectMailDates { get; set; }

        public bool IsCriteriaSameAsPervious { get; set; }
    }
}
