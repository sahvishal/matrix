
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class HealthPlanCallQueueCriteriaViewModel
    {
        public string Category { get; set; }
        public int? Radius { get; set; }
        public string Zipcode { get; set; }
        public int? NoOfDays { get; set; }
        public int? RoundOfCalls { get; set; }
        public int? Percentage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CampaignName { get; set; }
        public long CampaignId { get; set; }
        public string CriteriaName { get; set; }
        public bool IsQueueGenerated { get; set; }
        public IEnumerable<DateTime> DirectMailDates { get; set; }
    }
}
