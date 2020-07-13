using System.Collections.Generic;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Domain.MedicalVendors
{
    public class HospitalPartner : DomainObjectBase
    {
        public string Name { get; set; }
        public PhoneNumber AssociatedPhoneNumber { get; set; }
        public bool IsGlobal { get; set; }
        public long? AdvocateId { get; set; }
        public IEnumerable<long> TerritoryIds { get; set; }
        public IEnumerable<long> PackageIds { get; set; }
        public int NormalResultValidityPeriod { get; set; }
        public int AbnormalResultValidityPeriod { get; set; }
        public int CriticalResultValidityPeriod { get; set; }

        public int? MailTransitDays { get; set; }

        public long? HealthAssessmentTemplateId { get; set; }

        public string CannedMessage { get; set; }

        public bool CaptureSsn { get; set; }

        public bool RecommendPackage { get; set; }

        public IEnumerable<long> HospitalFacilityIds { get; set; }

        public bool AskPreQualificationQuestion { get; set; }

        public bool AttachDoctorLetter { get; set; }

        public bool RestrictEvaluation { get; set; }

        public bool ShowOnlineShipping { get; set; }

        public IEnumerable<long> ShippingOptionIds { get; set; }

        public HospitalPartner()
        { }

        public HospitalPartner(long hospitalPartnerId)
            : base(hospitalPartnerId)
        { }
    }
}