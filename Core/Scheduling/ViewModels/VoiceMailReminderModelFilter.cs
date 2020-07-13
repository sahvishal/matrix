using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class VoiceMailReminderModelFilter : ModelFilterBase
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long CorporateAccountId { get; set; }
        public long HospitalPartnerId { get; set; }
        public long EventId { get; set; }
    }
}
