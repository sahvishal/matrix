using Falcon.App.Core.Application.Attributes;
using System;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class CampaignListModelFilter
    {
        public string Name { get; set; }
        public long? CampaignTypeId { get; set; }
        public long? CampaignModeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsPublished { get; set; }
        public long? AccountId { get; set; }
    }
}
