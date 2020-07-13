using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Mappers
{
    public class CorporateAccountMapper : DomainEntityMapper<CorporateAccount, AccountEntity>
    {
        private readonly IPhoneNumberFactory _phoneNumberFactory;

        public CorporateAccountMapper(IPhoneNumberFactory phoneNumberFactory)
        {
            _phoneNumberFactory = phoneNumberFactory;
        }

        protected override void MapDomainFields(AccountEntity entity, CorporateAccount domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.AccountId;
            domainObjectToMapTo.ContractNotes = entity.ContractNotes;
            domainObjectToMapTo.ShowSponsoredByUrl = entity.ShowSponsoredByUrl;
            domainObjectToMapTo.Content = entity.Content;
            domainObjectToMapTo.ConvertedHostId = entity.ConvertedHostId;
            domainObjectToMapTo.AccountCode = entity.CorpCode;
            domainObjectToMapTo.AllowCobranding = entity.AllowCobranding;
            domainObjectToMapTo.CorporateWhiteLabeling = entity.CorporateWhiteLabeling;
            domainObjectToMapTo.FluffLetterFileId = entity.FluffLetterFileId != null ? entity.FluffLetterFileId.Value : 0;
            domainObjectToMapTo.CaptureInsuranceId = entity.CaptureInsuranceId;
            domainObjectToMapTo.InsuranceIdRequired = entity.InsuranceIdRequired;
            domainObjectToMapTo.SendAppointmentMail = entity.SendAppointmentMail;

            domainObjectToMapTo.Tag = entity.Tag;
            domainObjectToMapTo.MemberIdLabel = entity.MemberIdLabel;
            domainObjectToMapTo.AllowOnlineRegistration = entity.AllowOnlineRegistration;
            domainObjectToMapTo.AllowPreQualifiedTestOnly = entity.AllowPreQualifiedTestOnly;
            domainObjectToMapTo.AllowCustomerPortalLogin = entity.AllowCustomerPortalLogin;
            domainObjectToMapTo.AppointmentConfirmationMailTemplateId = entity.AppointmentConfirmationMailTemplateId;
            domainObjectToMapTo.AppointmentReminderMailTemplateId = entity.AppointmentReminderMailTemplateId;

            domainObjectToMapTo.SendResultReadyMail = entity.SendResultReadyMail;
            domainObjectToMapTo.GeneratePcpLetterWithDiagnosisCode = entity.GeneratePcpLetterWithDiagnosisCode;
            domainObjectToMapTo.ShowBasicBiometricPage = entity.ShowBasicBiometricPage;
            domainObjectToMapTo.SendSurveyMail = entity.SendSurveyMail;
            domainObjectToMapTo.ResultReadyMailTemplateId = entity.ResultReadyMailTemplateId;
            domainObjectToMapTo.SurveyMailTemplateId = entity.SurveyMailTemplateId;

            domainObjectToMapTo.AllowVerifiedMembersOnly = entity.AllowVerifiedMembersOnly;
            domainObjectToMapTo.FirstName = entity.FirstName;
            domainObjectToMapTo.MemberId = entity.MemberId;
            domainObjectToMapTo.ZipCode = entity.Zipcode;
            domainObjectToMapTo.LastName = entity.LastName;
            domainObjectToMapTo.DateOfBirth = entity.DateOfBirth;
            domainObjectToMapTo.CustomerEmail = entity.Email;
            domainObjectToMapTo.SendResultReadyMailWithFax = entity.SendResultReadyMailWithFax;

            domainObjectToMapTo.CapturePcpConsent = entity.CapturePcpconsent;
            domainObjectToMapTo.CaptureAbnStatus = entity.CaptureAbnstatus;
            domainObjectToMapTo.AllowPrePayment = entity.AllowPrePayment;
            domainObjectToMapTo.HicNumberRequired = entity.HicnumberRequired;

            domainObjectToMapTo.IsCustomerResultsTestDependent = entity.IsCustomerResultsTestDependent;
            domainObjectToMapTo.GenerateCustomerResult = entity.GenerateCustomerResult;
            domainObjectToMapTo.GeneratePcpResult = entity.GeneratePcpResult;
            domainObjectToMapTo.CheckoutPhoneNumber = _phoneNumberFactory.CreatePhoneNumber(entity.CheckoutPhoneNumber, PhoneNumberType.Unknown);

            domainObjectToMapTo.RecommendPackage = entity.RecommendPackage;
            domainObjectToMapTo.AskPreQualificationQuestion = entity.AskPreQualificationQuestion;

            domainObjectToMapTo.SendWelcomeEmail = entity.SendWelcomeEmail;
            domainObjectToMapTo.CaptureHaf = entity.CaptureHaf;
            domainObjectToMapTo.CaptureHafOnline = entity.CaptureHafonline;

            domainObjectToMapTo.EnableImageUpsell = entity.EnableImageUpsell;
            domainObjectToMapTo.AllowTechnicianUpdatePreQualifiedTests = entity.AllowTechUpdateQualifiedTests;
            domainObjectToMapTo.AttachQualityAssuranceForm = entity.AttachQualityAssuranceForm;
            domainObjectToMapTo.RemoveLongDescription = entity.RemoveLongDescription;
            domainObjectToMapTo.GenerateBatchLabel = entity.GenerateBatchLabel;

            domainObjectToMapTo.AttachCongitiveClockForm = entity.AttachCongitiveClockForm;
            domainObjectToMapTo.AttachChronicEvaluationForm = entity.AttachChronicEvaluationForm;
            domainObjectToMapTo.AttachParicipantConsentForm = entity.AttachParicipantConsentForm;
            domainObjectToMapTo.UpsellTest = entity.UpsellTest;
            domainObjectToMapTo.AskClinicalQuestions = entity.AskClinicalQuestions;
            domainObjectToMapTo.ClinicalQuestionTemplateId = entity.ClinicalQuestionTemplateId;
            domainObjectToMapTo.DefaultSelectionBasePackage = entity.DefaultSelectionBasePackage;

            domainObjectToMapTo.SlotBooking = entity.SlotBooking;
            domainObjectToMapTo.AddImagesForAbnormal = entity.AddImagesForAbnormal;
            domainObjectToMapTo.BookPcpAppointment = entity.BookPcpAppointment;
            domainObjectToMapTo.NumberOfDays = entity.NumberOfDays;
            domainObjectToMapTo.ScreeningInfo = entity.ScreeningInfo;
            domainObjectToMapTo.PatientWorkSheet = entity.PatientWorkSheet;
            domainObjectToMapTo.UseHeaderImage = entity.UseHeaderImage;
            domainObjectToMapTo.ShowHafFooter = entity.ShowHafFooter;
            domainObjectToMapTo.CaptureSurvey = entity.CaptureSurvey;
            domainObjectToMapTo.SurveyPdfFileId = entity.SurveyPdfFileId.HasValue ? entity.SurveyPdfFileId.Value : 0;
            domainObjectToMapTo.GeneratePcpLetter = entity.GeneratePcpLetter;
            domainObjectToMapTo.PcpLetterPdfFileId = entity.PcpLetterPdfFileId.HasValue ? entity.PcpLetterPdfFileId.Value : 0;
            domainObjectToMapTo.AttachScannedDoc = entity.AttachScannedDoc;
            domainObjectToMapTo.ResultFormatTypeId = entity.ResultFormatTypeId;
            domainObjectToMapTo.AttachUnreadableTest = entity.AttachUnreadableTest;

            domainObjectToMapTo.AttachGiftCard = entity.AttachGiftCard;
            domainObjectToMapTo.GiftCardAmount = entity.GiftCardAmount;

            domainObjectToMapTo.AttachEawvPreventionPlan = entity.AttachEawvPreventionPlan;
            domainObjectToMapTo.GenerateEawvPreventionPlanReport = entity.GenerateEawvPreventionPlanReport;
            domainObjectToMapTo.GenerateFluPneuConsentForm = entity.GenerateFluPneuConsentForm;

            domainObjectToMapTo.GenerateBmiReport = entity.GenerateBmiReport;

            domainObjectToMapTo.EnablePgpEncryption = entity.EnablePgpEncryption;
            domainObjectToMapTo.PublicKeyFileId = entity.PublicKeyFileId.HasValue ? entity.PublicKeyFileId.Value : 0;

            domainObjectToMapTo.LockEvent = entity.LockEvent;
            domainObjectToMapTo.GenerateHealthPlanReport = entity.GenerateHealthPlanReport;
            domainObjectToMapTo.IsHealthPlan = entity.IsHealthPlan;
            domainObjectToMapTo.AttachAttestationForm = entity.AttachAttestationForm;
            domainObjectToMapTo.EventLockDaysCount = entity.EventLockDaysCount;

            domainObjectToMapTo.AttachOrderRequisitionForm = entity.AttachOrderRequisitionForm;
            domainObjectToMapTo.ParticipantLetterId = entity.ParticipantLetterId.HasValue ? entity.ParticipantLetterId.Value : 0;
            domainObjectToMapTo.FolderName = entity.FolderName;
            if (entity.Organization != null)
                domainObjectToMapTo.Name = entity.Organization.Name;
            domainObjectToMapTo.PrintCheckList = entity.PrintCheckList;
            domainObjectToMapTo.CheckListFileId = entity.CheckListFileId.HasValue ? entity.CheckListFileId.Value : 0;
            domainObjectToMapTo.SendEventResultReadyNotification = entity.SendEventResultReadyNotification;
            domainObjectToMapTo.ShowBarrier = entity.ShowBarrier;
            domainObjectToMapTo.PrintPcpAppointmentForBulkHaf = entity.PrintPcpAppointmentForBulkHaf;
            domainObjectToMapTo.PrintPcpAppointmentForResult = entity.PrintPcpAppointmentForResult;
            domainObjectToMapTo.PrintAceForm = entity.PrintAceForm;
            domainObjectToMapTo.PrintMipForm = entity.PrintMipForm;
            domainObjectToMapTo.AllowRegistrationWithImproperTags = entity.AllowRegistrationWithImproperTags;
            domainObjectToMapTo.PrintMicroalbuminForm = entity.PrintMicroalbuminForm;
            domainObjectToMapTo.PrintIFOBTForm = entity.PrintIfobtform;
            domainObjectToMapTo.EnableSms = entity.EnableSms;
            domainObjectToMapTo.MaximumSms = entity.MaximumSms;
            domainObjectToMapTo.ConfirmationSmsTemplateId = entity.ConfirmationSmsTemplateId;
            domainObjectToMapTo.ReminderSmsTemplateId = entity.ReminderSmsTemplateId;
            domainObjectToMapTo.PrintLoincLabData = entity.PrintLoincLabData;
            domainObjectToMapTo.CheckListTemplateId = entity.CheckListTemplateId;
            domainObjectToMapTo.MaxAttempt = entity.MaxAttempt;
            domainObjectToMapTo.IsMaxAttemptPerHealthPlan = entity.IsMaxAttemptPerHealthPlan;
            domainObjectToMapTo.MarkPennedBack = entity.MarkPennedBack;
            domainObjectToMapTo.PennedBackText = entity.PennedBackText;
            domainObjectToMapTo.ShowCallCenterScript = entity.ShowCallCenterScript;
            domainObjectToMapTo.CallCenterScriptFileId = entity.CallCenterScriptFileId.HasValue ? entity.CallCenterScriptFileId.Value : 0;
            domainObjectToMapTo.ConfirmationScriptFileId = entity.ConfirmationScriptFileId.HasValue ? entity.ConfirmationScriptFileId.Value : 0;
            domainObjectToMapTo.EventConfirmationBeforeDays = entity.EventConfirmationBeforeDays;
            domainObjectToMapTo.ConfirmationBeforeAppointmentMinutes = entity.ConfirmationBeforeAppointmentMinutes;
            domainObjectToMapTo.RestrictHealthPlanData = entity.RestrictHealthPlanData;
            domainObjectToMapTo.ClientId = entity.ClientId;
            domainObjectToMapTo.SendPatientDataToAces = entity.SendPatientDataToAces;
            domainObjectToMapTo.SendConsentData = entity.SendConsentData;
            domainObjectToMapTo.ShowGiftCertificateOnEod = entity.ShowGiftCertificateOnEod;
            domainObjectToMapTo.WarmTransfer = entity.WarmTransfer;
            domainObjectToMapTo.InboundCallScriptFileId = entity.InboundCallScriptFileId.HasValue ? entity.InboundCallScriptFileId.Value : 0;
            domainObjectToMapTo.AcesClientShortName = entity.AcesClientShortName;

            domainObjectToMapTo.IncludeMemberLetter = entity.IncludeMemberLetter;
            domainObjectToMapTo.MemberLetterFileId = entity.MemberLetterFileId.HasValue ? entity.MemberLetterFileId.Value : 0;

            domainObjectToMapTo.PcpCoverLetterTemplateId = entity.PcpCoverLetterTemplateId;
            domainObjectToMapTo.MemberCoverLetterTemplateId = entity.MemberCoverLetterTemplateId;

            domainObjectToMapTo.AcesToHipIntake = entity.AcesToHipIntake;
            domainObjectToMapTo.AcesToHipIntakeShortName = entity.AcesToHipIntakeShortName;

            domainObjectToMapTo.FluConsentTemplateId = entity.FluConsentTemplateId;
            domainObjectToMapTo.ExitInterviewTemplateId = entity.ExitInterviewTemplateId;

            domainObjectToMapTo.SurveyTemplateId = entity.SurveyTemplateId;
            domainObjectToMapTo.ShowChaperonForm = entity.ShowChaperonForm;
        }

        protected override void MapEntityFields(CorporateAccount domainObject, AccountEntity entityToMapTo)
        {
            entityToMapTo.AccountId = domainObject.Id;
            entityToMapTo.ContractNotes = domainObject.ContractNotes;
            entityToMapTo.Fields["ContractNotes"].IsChanged = true;

            entityToMapTo.ShowSponsoredByUrl = domainObject.ShowSponsoredByUrl;

            entityToMapTo.Content = domainObject.Content;
            entityToMapTo.Fields["Content"].IsChanged = true;

            entityToMapTo.ConvertedHostId = domainObject.ConvertedHostId;
            entityToMapTo.CorpCode = domainObject.AccountCode;
            entityToMapTo.AllowCobranding = domainObject.AllowCobranding;
            entityToMapTo.CorporateWhiteLabeling = domainObject.CorporateWhiteLabeling;
            if (domainObject.FluffLetterFileId > 0)
                entityToMapTo.FluffLetterFileId = domainObject.FluffLetterFileId;

            entityToMapTo.Fields["FluffLetterFileId"].IsChanged = true;

            entityToMapTo.CaptureInsuranceId = domainObject.CaptureInsuranceId;
            entityToMapTo.InsuranceIdRequired = domainObject.InsuranceIdRequired;
            entityToMapTo.SendAppointmentMail = domainObject.SendAppointmentMail;

            entityToMapTo.Tag = domainObject.Tag;
            entityToMapTo.MemberIdLabel = domainObject.MemberIdLabel;
            entityToMapTo.AllowOnlineRegistration = domainObject.AllowOnlineRegistration;
            entityToMapTo.AllowPreQualifiedTestOnly = domainObject.AllowPreQualifiedTestOnly;
            entityToMapTo.AllowCustomerPortalLogin = domainObject.AllowCustomerPortalLogin;
            entityToMapTo.AppointmentConfirmationMailTemplateId = domainObject.AppointmentConfirmationMailTemplateId;
            entityToMapTo.AppointmentReminderMailTemplateId = domainObject.AppointmentReminderMailTemplateId;

            entityToMapTo.SendResultReadyMail = domainObject.SendResultReadyMail;
            entityToMapTo.GeneratePcpLetterWithDiagnosisCode = domainObject.GeneratePcpLetterWithDiagnosisCode;
            entityToMapTo.ShowBasicBiometricPage = domainObject.ShowBasicBiometricPage;
            entityToMapTo.SendSurveyMail = domainObject.SendSurveyMail;
            entityToMapTo.ResultReadyMailTemplateId = domainObject.ResultReadyMailTemplateId;
            entityToMapTo.SurveyMailTemplateId = domainObject.SurveyMailTemplateId;

            entityToMapTo.AllowVerifiedMembersOnly = domainObject.AllowVerifiedMembersOnly;
            entityToMapTo.FirstName = domainObject.FirstName;
            entityToMapTo.MemberId = domainObject.MemberId;
            entityToMapTo.Zipcode = domainObject.ZipCode;
            entityToMapTo.LastName = domainObject.LastName;
            entityToMapTo.DateOfBirth = domainObject.DateOfBirth;
            entityToMapTo.Email = domainObject.CustomerEmail;
            entityToMapTo.SendResultReadyMailWithFax = domainObject.SendResultReadyMailWithFax;

            entityToMapTo.CapturePcpconsent = domainObject.CapturePcpConsent;
            entityToMapTo.AllowPrePayment = domainObject.AllowPrePayment;
            entityToMapTo.CaptureAbnstatus = domainObject.CaptureAbnStatus;
            entityToMapTo.HicnumberRequired = domainObject.HicNumberRequired;

            entityToMapTo.IsCustomerResultsTestDependent = domainObject.IsCustomerResultsTestDependent;
            entityToMapTo.GenerateCustomerResult = domainObject.GenerateCustomerResult;
            entityToMapTo.GeneratePcpResult = domainObject.GeneratePcpResult;

            entityToMapTo.CheckoutPhoneNumber = domainObject.CheckoutPhoneNumber != null ? PhoneNumber.ToNumber(domainObject.CheckoutPhoneNumber.ToString()) : string.Empty;
            entityToMapTo.Fields["CheckoutPhoneNumber"].IsChanged = true;

            entityToMapTo.RecommendPackage = domainObject.RecommendPackage;
            entityToMapTo.AskPreQualificationQuestion = domainObject.AskPreQualificationQuestion;

            entityToMapTo.SendWelcomeEmail = domainObject.SendWelcomeEmail;
            entityToMapTo.CaptureHaf = domainObject.CaptureHaf;
            entityToMapTo.CaptureHafonline = domainObject.CaptureHafOnline;

            entityToMapTo.EnableImageUpsell = domainObject.EnableImageUpsell;
            entityToMapTo.AllowTechUpdateQualifiedTests = domainObject.AllowTechnicianUpdatePreQualifiedTests;
            entityToMapTo.AttachQualityAssuranceForm = domainObject.AttachQualityAssuranceForm;
            entityToMapTo.RemoveLongDescription = domainObject.RemoveLongDescription;
            entityToMapTo.GenerateBatchLabel = domainObject.GenerateBatchLabel;

            entityToMapTo.AttachCongitiveClockForm = domainObject.AttachCongitiveClockForm;
            entityToMapTo.AttachChronicEvaluationForm = domainObject.AttachChronicEvaluationForm;
            entityToMapTo.AttachParicipantConsentForm = domainObject.AttachParicipantConsentForm;
            entityToMapTo.UpsellTest = domainObject.UpsellTest;

            entityToMapTo.AskClinicalQuestions = domainObject.AskClinicalQuestions;
            entityToMapTo.ClinicalQuestionTemplateId = domainObject.ClinicalQuestionTemplateId;
            entityToMapTo.Fields["ClinicalQuestionTemplateId"].IsChanged = true;
            entityToMapTo.DefaultSelectionBasePackage = domainObject.DefaultSelectionBasePackage;

            entityToMapTo.SlotBooking = domainObject.SlotBooking;
            entityToMapTo.AddImagesForAbnormal = domainObject.AddImagesForAbnormal;
            entityToMapTo.BookPcpAppointment = domainObject.BookPcpAppointment;
            entityToMapTo.NumberOfDays = domainObject.NumberOfDays;
            entityToMapTo.ScreeningInfo = domainObject.ScreeningInfo;
            entityToMapTo.PatientWorkSheet = domainObject.PatientWorkSheet;
            entityToMapTo.UseHeaderImage = domainObject.UseHeaderImage;
            entityToMapTo.ShowHafFooter = domainObject.ShowHafFooter;
            entityToMapTo.CaptureSurvey = domainObject.CaptureSurvey;

            entityToMapTo.SurveyPdfFileId = domainObject.SurveyPdfFileId > 0 && entityToMapTo.CaptureSurvey ? domainObject.SurveyPdfFileId : (long?)null;
            entityToMapTo.Fields["SurveyPdfFileId"].IsChanged = true;

            entityToMapTo.GeneratePcpLetter = domainObject.GeneratePcpLetter;
            entityToMapTo.PcpLetterPdfFileId = domainObject.PcpLetterPdfFileId > 0 && entityToMapTo.GeneratePcpLetter ? domainObject.PcpLetterPdfFileId : (long?)null;
            entityToMapTo.Fields["PcpLetterPdfFileId"].IsChanged = true;

            entityToMapTo.AttachScannedDoc = domainObject.AttachScannedDoc;
            entityToMapTo.ResultFormatTypeId = domainObject.ResultFormatTypeId > 0 ? domainObject.ResultFormatTypeId : (long)ResultFormatType.PDF;
            entityToMapTo.AttachUnreadableTest = domainObject.AttachUnreadableTest;

            entityToMapTo.AttachGiftCard = domainObject.AttachGiftCard;
            entityToMapTo.GiftCardAmount = domainObject.GiftCardAmount;
            entityToMapTo.Fields["GiftCardAmount"].IsChanged = true;

            entityToMapTo.AttachEawvPreventionPlan = domainObject.AttachEawvPreventionPlan;
            entityToMapTo.GenerateEawvPreventionPlanReport = domainObject.GenerateEawvPreventionPlanReport;
            entityToMapTo.GenerateFluPneuConsentForm = domainObject.GenerateFluPneuConsentForm;
            entityToMapTo.GenerateBmiReport = domainObject.GenerateBmiReport;

            entityToMapTo.EnablePgpEncryption = domainObject.EnablePgpEncryption;
            entityToMapTo.PublicKeyFileId = domainObject.PublicKeyFileId > 0 && entityToMapTo.EnablePgpEncryption ? domainObject.PublicKeyFileId : (long?)null;
            entityToMapTo.Fields["PublicKeyFileId"].IsChanged = true;

            entityToMapTo.LockEvent = domainObject.LockEvent;
            entityToMapTo.GenerateHealthPlanReport = domainObject.GenerateHealthPlanReport;

            entityToMapTo.IsHealthPlan = domainObject.IsHealthPlan;
            entityToMapTo.AttachAttestationForm = domainObject.AttachAttestationForm;
            entityToMapTo.EventLockDaysCount = domainObject.EventLockDaysCount;
            entityToMapTo.Fields["EventLockDaysCount"].IsChanged = true;

            entityToMapTo.AttachOrderRequisitionForm = domainObject.AttachOrderRequisitionForm;

            entityToMapTo.ParticipantLetterId = domainObject.ParticipantLetterId > 0 ? domainObject.ParticipantLetterId : (long?)null;
            entityToMapTo.Fields["ParticipantLetterId"].IsChanged = true;

            entityToMapTo.FolderName = string.IsNullOrEmpty(domainObject.FolderName) ? domainObject.Tag : domainObject.FolderName;
            entityToMapTo.PrintCheckList = domainObject.PrintCheckList;
            entityToMapTo.CheckListFileId = domainObject.CheckListFileId > 0 && entityToMapTo.PrintCheckList ? domainObject.CheckListFileId : (long?)null;
            entityToMapTo.Fields["CheckListFileId"].IsChanged = true;
            entityToMapTo.SendEventResultReadyNotification = domainObject.SendEventResultReadyNotification;
            entityToMapTo.ShowBarrier = domainObject.ShowBarrier;
            entityToMapTo.PrintPcpAppointmentForBulkHaf = domainObject.PrintPcpAppointmentForBulkHaf;
            entityToMapTo.PrintPcpAppointmentForResult = domainObject.PrintPcpAppointmentForResult;
            entityToMapTo.PrintAceForm = domainObject.PrintAceForm;
            entityToMapTo.PrintMipForm = domainObject.PrintMipForm;
            entityToMapTo.AllowRegistrationWithImproperTags = domainObject.AllowRegistrationWithImproperTags;
            entityToMapTo.PrintMicroalbuminForm = domainObject.PrintMicroalbuminForm;
            entityToMapTo.PrintIfobtform = domainObject.PrintIFOBTForm;
            entityToMapTo.EnableSms = domainObject.EnableSms;
            entityToMapTo.MaximumSms = domainObject.MaximumSms;
            entityToMapTo.Fields["MaximumSms"].IsChanged = true;
            entityToMapTo.ConfirmationSmsTemplateId = domainObject.ConfirmationSmsTemplateId;
            entityToMapTo.Fields["ConfirmationSmsTemplateId"].IsChanged = true;
            entityToMapTo.ReminderSmsTemplateId = domainObject.ReminderSmsTemplateId;
            entityToMapTo.Fields["ReminderSmsTemplateId"].IsChanged = true;
            entityToMapTo.PrintLoincLabData = domainObject.PrintLoincLabData;
            entityToMapTo.CheckListTemplateId = domainObject.CheckListTemplateId;
            entityToMapTo.MaxAttempt = domainObject.MaxAttempt;
            entityToMapTo.Fields["MaxAttempt"].IsChanged = true;
            entityToMapTo.IsMaxAttemptPerHealthPlan = domainObject.IsMaxAttemptPerHealthPlan;
            entityToMapTo.MarkPennedBack = domainObject.MarkPennedBack;
            entityToMapTo.PennedBackText = domainObject.PennedBackText;
            entityToMapTo.ShowCallCenterScript = domainObject.ShowCallCenterScript;
            entityToMapTo.CallCenterScriptFileId = domainObject.CallCenterScriptFileId > 0 && entityToMapTo.ShowCallCenterScript ? domainObject.CallCenterScriptFileId : (long?)null;
            entityToMapTo.Fields["CallCenterScriptFileId"].IsChanged = true;
            entityToMapTo.ConfirmationScriptFileId = domainObject.ConfirmationScriptFileId > 0 && entityToMapTo.ShowCallCenterScript ? domainObject.ConfirmationScriptFileId : (long?)null;
            entityToMapTo.Fields["ConfirmationScriptFileId"].IsChanged = true;
            entityToMapTo.EventConfirmationBeforeDays = domainObject.EventConfirmationBeforeDays;
            entityToMapTo.Fields["EventConfirmationBeforeDays"].IsChanged = true;
            entityToMapTo.ConfirmationBeforeAppointmentMinutes = domainObject.ConfirmationBeforeAppointmentMinutes;
            entityToMapTo.Fields["ConfirmationBeforeAppointmentMinutes"].IsChanged = true;
            entityToMapTo.RestrictHealthPlanData = domainObject.RestrictHealthPlanData;
            entityToMapTo.ClientId = domainObject.SendPatientDataToAces ? domainObject.ClientId : "";
            entityToMapTo.Fields["ClientId"].IsChanged = true;
            entityToMapTo.SendPatientDataToAces = domainObject.SendPatientDataToAces;
            entityToMapTo.SendConsentData = domainObject.SendConsentData;
            entityToMapTo.ShowGiftCertificateOnEod = domainObject.ShowGiftCertificateOnEod;
            entityToMapTo.WarmTransfer = domainObject.WarmTransfer;
            entityToMapTo.InboundCallScriptFileId = domainObject.InboundCallScriptFileId > 0 && entityToMapTo.ShowCallCenterScript ? domainObject.InboundCallScriptFileId : (long?)null;
            entityToMapTo.Fields["InboundCallScriptFileId"].IsChanged = true;
            entityToMapTo.AcesClientShortName = domainObject.AcesClientShortName;
            entityToMapTo.Fields["AcesClientShortName"].IsChanged = true;

            entityToMapTo.IncludeMemberLetter = domainObject.IncludeMemberLetter;
            entityToMapTo.MemberLetterFileId = domainObject.MemberLetterFileId > 0 && entityToMapTo.IncludeMemberLetter ? domainObject.MemberLetterFileId : (long?)null;
            entityToMapTo.Fields["MemberLetterFileId"].IsChanged = true;

            entityToMapTo.PcpCoverLetterTemplateId = domainObject.PcpCoverLetterTemplateId;
            entityToMapTo.Fields["PcpCoverLetterTemplateId"].IsChanged = true;

            entityToMapTo.MemberCoverLetterTemplateId = domainObject.MemberCoverLetterTemplateId;
            entityToMapTo.Fields["MemberCoverLetterTemplateId"].IsChanged = true;

            entityToMapTo.AcesToHipIntake = domainObject.AcesToHipIntake;
            entityToMapTo.AcesToHipIntakeShortName = domainObject.AcesToHipIntakeShortName;
            entityToMapTo.Fields["AcesToHipIntakeShortName"].IsChanged = true;


            entityToMapTo.FluConsentTemplateId = domainObject.FluConsentTemplateId;
            entityToMapTo.ExitInterviewTemplateId = domainObject.ExitInterviewTemplateId;

            entityToMapTo.SurveyTemplateId = domainObject.SurveyTemplateId;
            entityToMapTo.Fields["SurveyTemplateId"].IsChanged = true;
            entityToMapTo.ShowChaperonForm = domainObject.ShowChaperonForm;
        }
    }
}