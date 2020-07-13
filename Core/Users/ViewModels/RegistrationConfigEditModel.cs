using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Falcon.App.Core.Users.ViewModels
{
    public class RegistrationConfigEditModel : ViewModelBase
    {
        public long AccountId { get; set; }

        public bool AllowOnlineRegistration { get; set; }

        [DisplayName("Show Sponsored by Logo")]
        public bool ShowSponsoredByUrl { get; set; }

        public bool CaptureInsuranceId { get; set; }

        public string MemberIdLabel { get; set; }

        public bool InsuranceIdRequired { get; set; }

        public bool SendAppointmentMail { get; set; }

        public long AppointmentReminderMailTemplateId { get; set; }

        public long AppointmentConfirmationMailTemplateId { get; set; }

        public string Tag { get; set; }

        public bool AllowPreQualifiedTestOnly { get; set; }

        public IEnumerable<OrganizationPackageEditModel> DefaultPackages { get; set; }

        public IEnumerable<ShippingOption> ShippingOptions { get; set; }

        public IEnumerable<long> ShippingOptionIds { get; set; }

        public bool ShowRetailPackages { get; set; }

        public long LogoImageId { get; set; }

        public string LogoImagePath { get; set; }

        public string OrganizationName { get; set; }

        public FileModel LogoImage { get; set; }

        public bool AllowVerifiedMemebersOnly { get; set; }

        public bool FirstName { get; set; }

        public bool LastName { get; set; }

        public bool MemberId { get; set; }

        public bool ZipCode { get; set; }

        public bool DateOfBirth { get; set; }

        public bool Email { get; set; }

        public bool IsCustomerTagInUse { get; set; }

        public bool AllowPrePayment { get; set; }

        public bool HicNumberRequired { get; set; }

        [DisplayName("Checkout Phone Number")]
        public PhoneNumber CheckoutPhoneNumber { get; set; }

        public bool RecommendPackage { get; set; }

        public bool AskPreQualificationQuestion { get; set; }

        public bool ShowAskPreQualificationQuestionSetting { get; set; }

        public IEnumerable<OrganizationPackageViewModel> OrganizationPackageList { get; set; }

        public bool SendWelcomeEmail { get; set; }
        public bool CaptureHaf { get; set; }
        public bool CaptureHafOnline { get; set; }

        public bool EnableImageUpsell { get; set; }
        public bool AllowTechnicianUpdatePreQualifiedTests { get; set; }

        public bool AttachQualityAssuranceForm { get; set; }

        public bool GenerateBatchLabel { get; set; }

        public bool AttachCongitiveClockForm { get; set; }
        public bool AttachChronicEvaluationForm { get; set; }
        public bool AttachParicipantConsentForm { get; set; }

        public bool UpsellTest { get; set; }

        public bool AskClinicalQuestions { get; set; }
        public long ClinicalQuestionTemplateId { get; set; }
        public long OldClinicalQuestionTemplateId { get; set; }
        public bool DefaultSelectionBasePackage { get; set; }

        public bool SlotBooking { get; set; }
        public bool BookPcpAppointment { get; set; }
        public int? NumberOfDays { get; set; }
        public bool ScreeningInfo { get; set; }
        public bool PatientWorkSheet { get; set; }
        public bool ShowHafFooter { get; set; }
        public bool CaptureSurvey { get; set; }
        public FileModel SurveyPdf { get; set; }

        public bool AttachGiftCard { get; set; }
        public decimal? GiftCardAmount { get; set; }
        public bool GenerateFluPneuConsentForm { get; set; }

        public IEnumerable<OrganizationTestEditModel> DefaultTests { get; set; }

        public IEnumerable<OrganizationTestViewModel> OrganizationTestList { get; set; }

        public bool LockEvent { get; set; }
        public int? LockEventDaysCount { get; set; }

        public bool IsHealthPlan { get; set; }

        public bool AttachOrderRequisitionForm { get; set; }

        public IEnumerable<OrganizationTestViewModel> TestNotReviewableByPhysician { get; set; }
        public IEnumerable<OrganizationTestViewModel> TestReviewableByPhysicianMasterList { get; set; }

        public IEnumerable<AccountAdditionalFieldsEditModel> AccountAdditionalFields { get; set; }

        public bool IsAdditionalField { get; set; }

        public bool PrintCheckList { get; set; }
        public FileModel CheckListPdf { get; set; }
        public bool ShowBarrier { get; set; }

        public bool PrintPcpAppointmentForBulkHaf { get; set; }

        public bool PrintAceForm { get; set; }
        public bool PrintMipForm { get; set; }

        public bool AllowRegistrationWithImproperTags { get; set; }

        public bool PrintMicroalbuminForm { get; set; }
        public bool PrintIFOBTForm { get; set; }

        public bool EnableSms { get; set; }
        public int? MaxSmsCount { get; set; }
        public int ConfirmationSmsTemplateId { get; set; }
        public int ReminderSmsTemplateId { get; set; }

        public bool PrintLoincLabData { get; set; }

        public IEnumerable<AccountCheckoutPhoneNumberEditModel> AccountCheckoutPhoneNumbers { get; set; }

        public IEnumerable<AccountCallQueueSettingEditModel> AccountCallQueueSettings { get; set; }

        public int? MaxAttempt { get; set; }

        public bool IsMaxAttemptPerHealthPlan { get; set; }

        public bool ShowCallCenterScript { get; set; }
        public FileModel CallCenterScriptPdf { get; set; }
        public FileModel ConfirmationScriptPdf { get; set; }

        public int? EventConfirmationBeforeDays { get; set; }
        public int? ConfirmationBeforeAppointmentMinutes { get; set; }

        public IEnumerable<AccountCallCenterOrganizationEditModel> AccountCallCenterOrganization { get; set; }

        public bool RestrictHealthPlanData { get; set; }

        public bool SendPatientDataToAces { get; set; }
        public string ClientId { get; set; }
        public bool SendConsentData { get; set; }
        public bool ShowGiftCertificateOnEod { get; set; }
        public bool WarmTransfer { get; set; }

        public FileModel InboundCallScriptPdf { get; set; }

        public string AcesClientShortName { get; set; }

        public bool AcesToHipIntake { get; set; }
        public string AcesToHipIntakeShortName { get; set; }

        public QuestionnaireType QuestionnaireType { get; set; }

        public DateTime? ChatStartDate { get; set; }
        public bool HasChatStartDate { get; set; }

        public bool IsShowHraQuestionnaire { get; set; }
        public QuestionnaireType CurrentQuestionnaireType { get; set; }
        public bool ShowChaperonForm { get; set; }
    }
}