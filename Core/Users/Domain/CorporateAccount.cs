using Falcon.App.Core.ValueTypes;
using System.Collections.Generic;

namespace Falcon.App.Core.Users.Domain
{
    public class CorporateAccount : Organization
    {
        public CorporateAccount()
        { }

        public CorporateAccount(long accountId)
            : base(accountId)
        { }

        public string ContractNotes { get; set; }
        public string Content { get; set; }
        public long? ConvertedHostId { get; set; }
        public string AccountCode { get; set; }
        public bool ShowSponsoredByUrl { get; set; }
        public bool AllowCobranding { get; set; }
        public bool CorporateWhiteLabeling { get; set; }
        public long FluffLetterFileId { get; set; }
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
        public bool GeneratePcpLetterWithDiagnosisCode { get; set; }
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

        public bool CapturePcpConsent { get; set; }
        public bool CaptureAbnStatus { get; set; }
        public bool AllowPrePayment { get; set; }
        public bool HicNumberRequired { get; set; }

        public bool GenerateCustomerResult { get; set; }
        public bool IsCustomerResultsTestDependent { get; set; }
        public bool GeneratePcpResult { get; set; }

        public PhoneNumber CheckoutPhoneNumber { get; set; }

        public bool RecommendPackage { get; set; }

        public bool AskPreQualificationQuestion { get; set; }

        public bool SendWelcomeEmail { get; set; }
        public bool CaptureHaf { get; set; }
        public bool CaptureHafOnline { get; set; }

        public bool EnableImageUpsell { get; set; }
        public bool AllowTechnicianUpdatePreQualifiedTests { get; set; }
        public bool AttachQualityAssuranceForm { get; set; }
        public bool RemoveLongDescription { get; set; }
        public bool GenerateBatchLabel { get; set; }

        public bool AttachCongitiveClockForm { get; set; }
        public bool AttachChronicEvaluationForm { get; set; }
        public bool AttachParicipantConsentForm { get; set; }

        public bool UpsellTest { get; set; }
        public bool AskClinicalQuestions { get; set; }
        public long? ClinicalQuestionTemplateId { get; set; }
        public bool DefaultSelectionBasePackage { get; set; }

        public bool SlotBooking { get; set; }
        public bool AddImagesForAbnormal { get; set; }
        public bool BookPcpAppointment { get; set; }
        public int NumberOfDays { get; set; }
        public bool ScreeningInfo { get; set; }
        public bool PatientWorkSheet { get; set; }
        public bool UseHeaderImage { get; set; }
        public bool ShowHafFooter { get; set; }
        public bool CaptureSurvey { get; set; }
        public long SurveyPdfFileId { get; set; }

        public bool GeneratePcpLetter { get; set; }

        public long PcpLetterPdfFileId { get; set; }

        public long ResultFormatTypeId { get; set; }

        public bool AttachScannedDoc { get; set; }

        public bool AttachUnreadableTest { get; set; }

        public bool AttachGiftCard { get; set; }
        public decimal? GiftCardAmount { get; set; }

        public bool AttachEawvPreventionPlan { get; set; }
        public bool GenerateEawvPreventionPlanReport { get; set; }

        public bool GenerateFluPneuConsentForm { get; set; }
        public bool GenerateBmiReport { get; set; }

        public bool EnablePgpEncryption { get; set; }

        public long PublicKeyFileId { get; set; }

        public bool LockEvent { get; set; }
        public bool GenerateHealthPlanReport { get; set; }
        public bool IsHealthPlan { get; set; }

        public bool AttachAttestationForm { get; set; }
        public int? EventLockDaysCount { get; set; }

        public bool AttachOrderRequisitionForm { get; set; }

        public long ParticipantLetterId { get; set; }

        public string FolderName { get; set; }

        public IEnumerable<AccountAdditionalFields> AccountAdditionalFields { get; set; }

        public bool PrintCheckList { get; set; }
        public long CheckListFileId { get; set; }

        public bool SendEventResultReadyNotification { get; set; }
        public bool ShowBarrier { get; set; }

        public bool PrintPcpAppointmentForBulkHaf { get; set; }
        public bool PrintPcpAppointmentForResult { get; set; }

        public bool PrintAceForm { get; set; }
        public bool PrintMipForm { get; set; }

        public bool AllowRegistrationWithImproperTags { get; set; }

        public bool PrintMicroalbuminForm { get; set; }
        public bool PrintIFOBTForm { get; set; }

        public bool EnableSms { get; set; }
        public int? MaximumSms { get; set; }
        public int? ConfirmationSmsTemplateId { get; set; }
        public int? ReminderSmsTemplateId { get; set; }

        public bool PrintLoincLabData { get; set; }
        public long? CheckListTemplateId { get; set; }

        public int? MaxAttempt { get; set; }
        public bool IsMaxAttemptPerHealthPlan { get; set; }

        public bool MarkPennedBack { get; set; }
        public string PennedBackText { get; set; }

        public bool ShowCallCenterScript { get; set; }
        public long CallCenterScriptFileId { get; set; }
        public long ConfirmationScriptFileId { get; set; }

        public int? EventConfirmationBeforeDays { get; set; }
        public int? ConfirmationBeforeAppointmentMinutes { get; set; }

        public bool RestrictHealthPlanData { get; set; }

        public bool SendPatientDataToAces { get; set; }
        public string ClientId { get; set; }
        public bool SendConsentData { get; set; }
        public bool ShowGiftCertificateOnEod { get; set; }
        public bool WarmTransfer { get; set; }

        public long InboundCallScriptFileId { get; set; }

        public string AcesClientShortName { get; set; }

        public bool IncludeMemberLetter { get; set; }
        public long MemberLetterFileId { get; set; }

        public int? PcpCoverLetterTemplateId { get; set; }
        public int? MemberCoverLetterTemplateId { get; set; }

        public bool AcesToHipIntake { get; set; }
        public string AcesToHipIntakeShortName { get; set; }

        public long? FluConsentTemplateId { get; set; }

        public long? ExitInterviewTemplateId { get; set; }

        public long? SurveyTemplateId { get; set; }

        public bool ShowChaperonForm { get; set; }
    }
}