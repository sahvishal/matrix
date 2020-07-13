using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    [NoValidationRequired]
    public class OutboundCallQueueFilter : ModelFilterBase
    {
        public long CallQueueId { get; set; }
        public string ZipCode { get; set; }
        public int Radius { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int PageNumber { get; set; }
        public long? EventId { get; set; }
        public string Tag { get; set; }
        public long HealthPlanId { get; set; }
        public string CustomCorporateTag { get; set; }
        public bool UseCustomTagExclusively { get; set; }
        public string[] CorporateTag
        {
            get
            {
                if (string.IsNullOrWhiteSpace(CustomCorporateTag)) return new string[0];

                var customTags = CustomCorporateTag.Split(',');

                return customTags.IsNullOrEmpty() ? new string[0] : customTags.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            }
        }
        public string[] CustomTags { get; set; }
        public long CriteriaId { get; set; }
        public long? CampaignId { get; set; }
        public DateTime? DirectMailStartDate { get; set; }
        public DateTime? DirectMailEndDate { get; set; }

        public DateTime? DirectMailDate { get; set; }
        public long MemberId { get; set; }
        public long CustomerId { get; set; }
        public OutboundCallQueueFilter()
        {
            Radius = 25;
            UseCustomTagExclusively = true;
        }
        public int NumberOfDays { get; set; }

        public int NumberOfDaysForLeftVoiceMail { get; set; }
        public int NumberOfDaysForOthers { get; set; }
        public int NumberOfDaysForRefusedCustomer { get; set; }
        public int MaxAttempt { get; set; }
        public bool IsMaxAttemptPerHealthPlan { get; set; }
        public long NoOfCustomersInCallQueue { get; set; }

        public long DaysForAppointmentConfirmation { get; set; }
        public int ConfirmationBeforeAppointmentMinutes { get; set; }

        public long AgentOrganizationId { get; set; }

        public long AgentOrganizationRoleUserId { get; set; }

        public SuppressionFilterType SuppressionType { get; set; }

        public IEnumerable<long> GmsAccountIds { get; set; }
    }
}