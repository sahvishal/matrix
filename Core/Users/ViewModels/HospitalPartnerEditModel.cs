using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users.ViewModels
{
    [NoValidationResolveAtStart]
    public class HospitalPartnerEditModel
    {
        [DisplayName("Associated Phone Number")]
        [UIHint("PhoneNumber")]
        public PhoneNumber AssociatedPhoneNumber { get; set; }

        public IEnumerable<OrderedPair<long, string>> Territories { get; set; }
        public IEnumerable<long> TerritoryIds { get; set; }

        public IEnumerable<OrganizationPackageViewModel> OrganizationPackageList { get; set; }
        public IEnumerable<OrganizationPackageEditModel> DefaultPackages { get; set; }

        [DisplayName("Show Normal Results up to")]
        public int NormalResultValidityPeriod { get; set; }

        [DisplayName("Show Abnormal Results up to")]
        public int AbnormalResultValidityPeriod { get; set; }

        [DisplayName("Show Critical/Urgent Results up to")]
        public int CriticalResultValidityPeriod { get; set; }

        [DisplayName("Mail Transit Days")]
        public int? MailTransitDays { get; set; }

        [DisplayName("Health Assessment Template")]
        public long? HealthAssessmentTemplateId { get; set; }

        [DisplayName("Canned Message")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string CannedMessage { get; set; }

        [DisplayName("Capture SSN")]
        public bool CaptureSsn { get; set; }

        [DisplayName("Recommend Package")]
        public bool RecommendPackage { get; set; }

        public IEnumerable<OrderedPair<long, string>> HospitalFacilities { get; set; }

        public IEnumerable<long> HospitalFacilityIds { get; set; }

        public bool AskPreQualificationQuestion { get; set; }

        public bool ShowAskPreQualificationQuestionSetttings { get; set; }


        public string DeactivedPackages { get; set; }

        public bool AttachDoctorLetter { get; set; }

        public bool RestrictEvaluation { get; set; }

        public bool ShowOnlineShipping { get; set; }

        public IEnumerable<ShippingOption> ShippingOptions { get; set; }

        public IEnumerable<long> ShippingOptionIds { get; set; }

        public HospitalPartnerEditModel()
        {
            RecommendPackage = true;
        }
    }
}
