using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.Enum;

namespace API.Areas.Scheduling.Models
{
    [NoValidationRequired]
    public class EventCustomerConsents
    {
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public CustomerConsentStatus Hipaa { get; set; }
        public CustomerConsentStatus PartnerRelease { get; set; }
        public CustomerConsentStatus PcpConsent { get; set; }
        public CustomerConsentStatus AbnConsent { get; set; }
        public CustomerConsentStatus InsuranceRelease { get; set; }
    }

    [NoValidationRequired]
    public class CustomerConsentStatus : ResponseBaseModel
    {
        public RegulatoryState Status { get; set; }
    }
}