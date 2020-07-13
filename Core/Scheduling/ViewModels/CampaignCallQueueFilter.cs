using System;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class CampaignCallQueueFilter
    {
        public long CallQueueId { get; set; }
        public long? CampaignId { get; set; }
        public long CriteriaId { get; set; }
        public long AssignedToOrgRoleUserId { get; set; }
        public int PageNumber { get; set; }
        public long HealthPlanId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CustomCorporateTag { get; set; }
        public string[] CorporateTag
        {
            get
            {
                if (string.IsNullOrWhiteSpace(CustomCorporateTag)) return new string[0];

                var customTags = CustomCorporateTag.Split(',');

                return !customTags.IsNullOrEmpty() ? new string[0] : customTags.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            }
        }

    }
}