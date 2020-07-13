using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Users.ViewModels
{
    public class ResultConfigEditModel : ViewModelBase
    {
        public long AccountId { get; set; }

        public FileModel FluffLetter { get; set; }

        public bool SendSurveyMail { get; set; }

        public long SurveyMailTemplateId { get; set; }

        public bool SendResultReadyMail { get; set; }

        public long ResultReadyMailTemplateId { get; set; }

        public bool GeneratePcpLetterWithDiagnosisCode { get; set; }

        public bool ShowBasicBiometricPage { get; set; }

        [DisplayName("Allow cobranding in customer portal")]
        public bool AllowCobranding { get; set; }

        public bool AllowCustomerPortalLogin { get; set; }

        [DisplayName("Include Corporate Letter")]
        public bool CorporateWhiteLabeling { get; set; }

        public bool SendResultReadyMailWithFax { get; set; }

        public bool CapturePcpConsent { get; set; }

        public bool CaptureAbnStatus { get; set; }

        public bool GenerateCustomerResult { get; set; }

        public bool IsCustomerResultsTestDependent { get; set; }

        public bool GeneratePcpResult { get; set; }

        public long[] CustomerResultTestDependency { get; set; }

        public long[] PcpResultTestDependency { get; set; }

        public IEnumerable<Test> RecordableTests { get; set; }

        public bool RemoveLongDescription { get; set; }

        public bool AddImagesForAbnormal { get; set; }

        public bool UseHeaderImage { get; set; }

        public bool GeneratePcpLetter { get; set; }

        public FileModel PcpLetterPdf { get; set; }

        public bool AttachScannedDoc { get; set; }

        public long ResultFormatTypeId { get; set; }

        public bool AttachUnreadableTest { get; set; }

        public bool AttachEawvPreventionPlan { get; set; }

        public bool GenerateEawvPreventionPlanReport { get; set; }

        public bool GenerateBmiReport { get; set; }

        public bool EnablePgpEncryption { get; set; }

        public FileModel PublicKeyFile { get; set; }

        public bool GenerateHealthPlanReport { get; set; }

        public long[] HealthPlanResultTestDependency { get; set; }

        public bool AttachAttestationForm { get; set; }

        public FileModel ParticipantLetter { get; set; }

        public bool SendEventResultReadyNotification { get; set; }

        public bool PrintPcpAppointmentForResult { get; set; }

        public bool MarkPennedBack { get; set; }

        public string PennedBackText { get; set; }

        public bool IncludeMemberLetter { get; set; }
        public FileModel MemberLetter { get; set; }

        public int PcpCoverLetterTemplateId { get; set; }
        public int MemberCoverLetterTemplateId { get; set; }

        public bool IsPcpCoverLetterSelected { get; set; }
        public bool IsMemberCoverLetterSelected { get; set; }
    }
}