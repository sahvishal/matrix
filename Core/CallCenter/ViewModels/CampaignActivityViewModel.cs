using System;
using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Enum;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CampaignActivityViewModel
    {
        public long ActivityId { get; set; }
        public CampaignActivityType ActivityType { get; set; }
        public DateTime ActivityDate { get; set; }
        public string DirectMailType { get; set; }
        public List<string> AssignmentAgent { get; set; }
        public bool IsEditable { get; set; }
    }
}
