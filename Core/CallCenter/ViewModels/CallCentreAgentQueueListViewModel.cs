using System.Collections.Generic;
using System;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallCentreAgentQueueListViewModel
    {
        public long? HealthPlanId { get; set; }  //nullable just because data from DB comes in form of NULLABLE LONG.
        public string HealthPlanName { get; set; }
        public string CriteriaName { get; set; }
        public string CallQueueName { get; set; }
        public long CallQueueId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? CapmaignId { get; set; }
        public string CampaignName { get; set; }
        public long CriteriaId { get; set; }
        //public List<HealthPlanCallQueueIdNameViewModel> CallQueueList { get; set; }
        public IEnumerable<OrderedPair<long, string>> AssignedAgents { get; set; }

        public double? DayRemaining
        {
            get
            {
                if (EndDate != null)
                    return Math.Ceiling((EndDate.Value - DateTime.Now).TotalDays);
                else
                    return null;
            }
        }

        public IEnumerable<DateTime> DirectMailDates { get; set; }
    }
}
