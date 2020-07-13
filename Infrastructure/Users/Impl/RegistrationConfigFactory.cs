using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Infrastructure.Users.Impl
{
    [DefaultImplementation]
    public class RegistrationConfigFactory : IRegistrationConfigFactory
    {
        public RegistrationConfigEditModel CreateModel(CorporateAccount account)
        {
            return new RegistrationConfigEditModel
            {
                AccountId = account.Id,
                AllowOnlineRegistration = account.AllowOnlineRegistration,
                AllowPreQualifiedTestOnly = account.AllowPreQualifiedTestOnly,
                AppointmentConfirmationMailTemplateId = account.AppointmentConfirmationMailTemplateId,
                AppointmentReminderMailTemplateId = account.AppointmentReminderMailTemplateId,
                ShowSponsoredByUrl = account.ShowSponsoredByUrl,
                CaptureInsuranceId = account.CaptureInsuranceId,
                InsuranceIdRequired = account.InsuranceIdRequired,
                SendAppointmentMail = account.SendAppointmentMail,
                MemberIdLabel = account.MemberIdLabel,
                Tag = account.Tag,
                AllowVerifiedMemebersOnly = account.AllowVerifiedMembersOnly,
                FirstName = account.FirstName,
                MemberId = true,
                DateOfBirth = true,
                LastName = account.LastName,
                ZipCode = account.ZipCode,
                Email = account.CustomerEmail,
                AllowPrePayment = account.AllowPrePayment,
                HicNumberRequired = account.HicNumberRequired,
                CheckoutPhoneNumber = account.CheckoutPhoneNumber,
                RecommendPackage = account.RecommendPackage,
                AskPreQualificationQuestion = account.AskPreQualificationQuestion,
                SendWelcomeEmail = account.SendWelcomeEmail,
                CaptureHaf = account.CaptureHaf,
                CaptureHafOnline = account.CaptureHafOnline,
                EnableImageUpsell = account.EnableImageUpsell,
                AllowTechnicianUpdatePreQualifiedTests = account.AllowTechnicianUpdatePreQualifiedTests,
                AttachQualityAssuranceForm = account.AttachQualityAssuranceForm,
                GenerateBatchLabel = account.GenerateBatchLabel,
                AttachCongitiveClockForm = account.AttachCongitiveClockForm,
                AttachChronicEvaluationForm = account.AttachChronicEvaluationForm,
                AttachParicipantConsentForm = account.AttachParicipantConsentForm,
                UpsellTest = account.UpsellTest,
                AskClinicalQuestions = account.AskClinicalQuestions,
                ClinicalQuestionTemplateId = account.ClinicalQuestionTemplateId ?? 0,
                DefaultSelectionBasePackage = account.DefaultSelectionBasePackage,
                OldClinicalQuestionTemplateId = account.ClinicalQuestionTemplateId ?? 0,

                SlotBooking = account.SlotBooking,
                BookPcpAppointment = account.BookPcpAppointment,
                NumberOfDays = account.NumberOfDays > 0 ? account.NumberOfDays : (int?)null,
                ScreeningInfo = account.ScreeningInfo,
                PatientWorkSheet = account.PatientWorkSheet,
                ShowHafFooter = account.ShowHafFooter,
                CaptureSurvey = account.CaptureSurvey,
                GenerateFluPneuConsentForm = account.GenerateFluPneuConsentForm,
                LockEvent = account.LockEvent,
                LockEventDaysCount = account.EventLockDaysCount,
                IsHealthPlan = account.IsHealthPlan,
                AttachOrderRequisitionForm = account.AttachOrderRequisitionForm,
                PrintCheckList = account.PrintCheckList,
                ShowBarrier = account.ShowBarrier,
                PrintPcpAppointmentForBulkHaf = account.PrintPcpAppointmentForBulkHaf,
                PrintAceForm = account.PrintAceForm,
                PrintMipForm = account.PrintMipForm,
                AllowRegistrationWithImproperTags = account.AllowRegistrationWithImproperTags,
                PrintMicroalbuminForm = account.PrintMicroalbuminForm,
                PrintIFOBTForm = account.PrintIFOBTForm,
                EnableSms = account.EnableSms,
                MaxSmsCount = account.MaximumSms,
                ConfirmationSmsTemplateId = account.ConfirmationSmsTemplateId.HasValue ? account.ConfirmationSmsTemplateId.Value : -1,
                ReminderSmsTemplateId = account.ReminderSmsTemplateId.HasValue ? account.ReminderSmsTemplateId.Value : -1,
                PrintLoincLabData = account.PrintLoincLabData,
                MaxAttempt = account.MaxAttempt,
                IsMaxAttemptPerHealthPlan = account.IsMaxAttemptPerHealthPlan,
                ShowCallCenterScript = account.ShowCallCenterScript,
                EventConfirmationBeforeDays = account.EventConfirmationBeforeDays,
                ConfirmationBeforeAppointmentMinutes = account.ConfirmationBeforeAppointmentMinutes,
                RestrictHealthPlanData = account.RestrictHealthPlanData,
                ClientId = account.ClientId,
                SendPatientDataToAces = account.SendPatientDataToAces,
                SendConsentData = account.SendConsentData,
                ShowGiftCertificateOnEod = account.ShowGiftCertificateOnEod,
                WarmTransfer = account.WarmTransfer,

                AcesClientShortName = account.AcesClientShortName,
                AcesToHipIntake = account.AcesToHipIntake,
                AcesToHipIntakeShortName = account.AcesToHipIntakeShortName,
                ShowChaperonForm = account.ShowChaperonForm,

            };
        }

        public CorporateAccount CreateDomain(CorporateAccount inpersistence, RegistrationConfigEditModel model)
        {
            inpersistence = inpersistence ?? new CorporateAccount();

            inpersistence.AllowOnlineRegistration = model.AllowOnlineRegistration;
            inpersistence.ShowSponsoredByUrl = model.ShowSponsoredByUrl;
            inpersistence.CaptureInsuranceId = model.CaptureInsuranceId;
            inpersistence.MemberIdLabel = model.MemberIdLabel;
            inpersistence.InsuranceIdRequired = model.InsuranceIdRequired;
            inpersistence.SendAppointmentMail = model.SendAppointmentMail;
            inpersistence.AppointmentConfirmationMailTemplateId = model.AppointmentConfirmationMailTemplateId;
            inpersistence.AppointmentReminderMailTemplateId = model.AppointmentReminderMailTemplateId;
            inpersistence.Tag = model.Tag;

            inpersistence.AllowPreQualifiedTestOnly = model.AllowPreQualifiedTestOnly;
            inpersistence.AllowVerifiedMembersOnly = model.AllowVerifiedMemebersOnly;
            inpersistence.FirstName = model.FirstName;
            inpersistence.MemberId = model.MemberId;
            inpersistence.DateOfBirth = model.DateOfBirth;
            inpersistence.LastName = model.LastName;
            inpersistence.ZipCode = model.ZipCode;
            inpersistence.CustomerEmail = model.Email;
            inpersistence.AllowPrePayment = model.AllowPrePayment;
            inpersistence.HicNumberRequired = model.HicNumberRequired;

            inpersistence.CheckoutPhoneNumber = model.CheckoutPhoneNumber;

            inpersistence.RecommendPackage = model.RecommendPackage;
            inpersistence.AskPreQualificationQuestion = model.AskPreQualificationQuestion;

            inpersistence.SendWelcomeEmail = model.SendWelcomeEmail;
            inpersistence.CaptureHaf = model.CaptureHaf;
            inpersistence.CaptureHafOnline = model.CaptureHafOnline;
            inpersistence.EnableImageUpsell = model.EnableImageUpsell;
            inpersistence.AllowTechnicianUpdatePreQualifiedTests = model.AllowTechnicianUpdatePreQualifiedTests;
            inpersistence.AttachQualityAssuranceForm = model.AttachQualityAssuranceForm;
            inpersistence.GenerateBatchLabel = model.GenerateBatchLabel;
            inpersistence.AttachCongitiveClockForm = model.AttachCongitiveClockForm;
            inpersistence.AttachChronicEvaluationForm = model.AttachChronicEvaluationForm;
            inpersistence.AttachParicipantConsentForm = model.AttachParicipantConsentForm;
            inpersistence.UpsellTest = model.UpsellTest;
            inpersistence.AskClinicalQuestions = model.AskClinicalQuestions;
            inpersistence.ClinicalQuestionTemplateId = model.AskClinicalQuestions ? (model.ClinicalQuestionTemplateId > 0 ? model.ClinicalQuestionTemplateId : (long?)null) : (long?)null;
            inpersistence.DefaultSelectionBasePackage = model.DefaultSelectionBasePackage;

            inpersistence.SlotBooking = model.SlotBooking;
            inpersistence.BookPcpAppointment = model.BookPcpAppointment;
            inpersistence.NumberOfDays = model.NumberOfDays ?? 0;
            inpersistence.ScreeningInfo = model.ScreeningInfo;
            inpersistence.PatientWorkSheet = model.PatientWorkSheet;
            inpersistence.ShowHafFooter = model.ShowHafFooter;
            inpersistence.CaptureSurvey = model.CaptureSurvey;

            inpersistence.AttachGiftCard = model.AttachGiftCard;
            inpersistence.GiftCardAmount = model.AttachGiftCard ? model.GiftCardAmount : null;
            inpersistence.GenerateFluPneuConsentForm = model.GenerateFluPneuConsentForm;
            inpersistence.LockEvent = model.LockEvent;
            inpersistence.EventLockDaysCount = model.LockEvent ? model.LockEventDaysCount : null;
            inpersistence.IsHealthPlan = model.IsHealthPlan;

            inpersistence.AttachOrderRequisitionForm = model.AttachOrderRequisitionForm;
            inpersistence.PrintCheckList = model.PrintCheckList;
            inpersistence.ShowBarrier = model.ShowBarrier;
            inpersistence.PrintPcpAppointmentForBulkHaf = model.PrintPcpAppointmentForBulkHaf;
            inpersistence.PrintAceForm = model.PrintAceForm;
            inpersistence.PrintMipForm = model.PrintMipForm;
            inpersistence.AllowRegistrationWithImproperTags = model.AllowRegistrationWithImproperTags;
            inpersistence.PrintMicroalbuminForm = model.PrintMicroalbuminForm;
            inpersistence.PrintIFOBTForm = model.PrintIFOBTForm;
            inpersistence.EnableSms = model.EnableSms;
            inpersistence.MaximumSms = model.EnableSms ? model.MaxSmsCount : null;
            inpersistence.ConfirmationSmsTemplateId = model.EnableSms && model.ConfirmationSmsTemplateId > 0 ? model.ConfirmationSmsTemplateId : (int?)null;
            inpersistence.ReminderSmsTemplateId = model.EnableSms && model.ReminderSmsTemplateId > 0 ? model.ReminderSmsTemplateId : (int?)null;
            inpersistence.PrintLoincLabData = model.PrintLoincLabData;

            inpersistence.MaxAttempt = model.MaxAttempt;
            inpersistence.IsMaxAttemptPerHealthPlan = model.IsMaxAttemptPerHealthPlan;

            inpersistence.ShowCallCenterScript = model.ShowCallCenterScript;
            inpersistence.EventConfirmationBeforeDays = model.EventConfirmationBeforeDays;
            inpersistence.ConfirmationBeforeAppointmentMinutes = model.ConfirmationBeforeAppointmentMinutes;
            inpersistence.RestrictHealthPlanData = model.RestrictHealthPlanData;

            inpersistence.ClientId = model.SendPatientDataToAces ? model.ClientId : "";
            inpersistence.SendPatientDataToAces = model.SendPatientDataToAces;
            inpersistence.SendConsentData = model.SendConsentData;
            inpersistence.ShowGiftCertificateOnEod = model.ShowGiftCertificateOnEod;
            inpersistence.WarmTransfer = model.WarmTransfer;

            inpersistence.AcesClientShortName = model.AcesClientShortName;
            inpersistence.AcesToHipIntake = model.AcesToHipIntake;
            inpersistence.AcesToHipIntakeShortName = model.AcesToHipIntakeShortName;
            inpersistence.ShowChaperonForm = model.ShowChaperonForm;

            return inpersistence;
        }
    }
}