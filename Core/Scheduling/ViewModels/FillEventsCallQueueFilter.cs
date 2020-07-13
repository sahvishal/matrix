﻿using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class FillEventsCallQueueFilter
    {
        public long CallQueueId { get; set; }
        public long CriteriaId { get; set; }

        public long? EventId { get; set; }
        public string Pod { get; set; }
        public long AssignedToOrgRoleUserId { get; set; }
        public int PageNumber { get; set; }
        public long HealthPlanId { get; set; }

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