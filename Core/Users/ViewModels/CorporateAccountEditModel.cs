using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Users.ViewModels
{
    public class CorporateAccountEditModel : ViewModelBase
    {
        public long AccountId { get; set; }

        public bool OpenNextTab { get; set; }

        public OrganizationEditModel OrganizationEditModel { get; set; }

        [DataType(DataType.MultilineText)]
        public string ContractNotes { get; set; }

        //Fluent Validator is not resolving the OrderedPair
        //public IEnumerable<OrderedPair<long,string>> DefaultPackages { get; set; }

        public IEnumerable<Package> DefaultPackages { get; set; }

        public bool ShowRetailPackages { get; set; }

        public long? ConvertedHostId { get; set; }

        public bool CreateHost { get; set; }

        [DisplayName("Corp. Code")]
        public string AccountCode { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Content { get; set; }

        [DisplayName("Show Sponsored by Logo")]
        public bool ShowSponsoredByUrl { get; set; }

        [DisplayName("Include Corporate Letter")]
        public bool CorporateWhiteLabeling { get; set; }

        [DisplayName("Allow cobranding in customer portal")]
        public bool AllowCobranding { get; set; }

        public IEnumerable<ShippingOption> ShippingOptions { get; set; }
        public IEnumerable<long> ShippingOptionIds { get; set; }

        public File FluffLetter { get; set; }

        public bool CaptureInsuranceId { get; set; }

        public bool InsuranceIdRequired { get; set; }

        public bool SendAppointmentMail { get; set; }

        public string Tag { get; set; }
        public string MemberIdLabel { get; set; }
        public bool AllowOnlineRegistration { get; set; }
        public bool AllowPreQualifiedTestOnly { get; set; }
        public bool AllowCustomerPortalLogin { get; set; }
        public long AppointmentConfirmationMailTemplateId { get; set; }
        public long AppointmentReminderMailTemplateId { get; set; }

        public bool SendResultReadyMail { get; set; }
        public bool GeneratePcpLetter { get; set; }
        public bool ShowBasicBiometricPage { get; set; }
        public bool SendSurveyMail { get; set; }
        public long ResultReadyMailTemplateId { get; set; }
        public long SurveyMailTemplateId { get; set; }
        public bool AllowVerifiedMembersOnly { get; set; }
        public bool FirstName { get; set; }
        public bool LastName { get; set; }
        public bool DateOfBirth { get; set; }
        public bool CustomerEmail { get; set; }
        public bool MemberId { get; set; }
        public bool ZipCode { get; set; }
        public bool SendResultReadyMailWithFax { get; set; }

        public CorporateAccountEditModel()
        {
            OrganizationEditModel = new OrganizationEditModel();
        }
    }
}