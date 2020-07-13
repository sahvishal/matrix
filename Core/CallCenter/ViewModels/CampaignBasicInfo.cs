using System;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CampaignBasicInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string HealthPlanTag { get; set; }
        public long CriteriaId { get; set; }
    }
}