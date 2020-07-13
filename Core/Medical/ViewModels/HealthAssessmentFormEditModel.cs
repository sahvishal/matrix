using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class HealthAssessmentFormEditModel : ViewModelBase
    {
        public long EventId { get; set; }
        public long CustomerId { get; set; }

        public HealthAssessmentEditModel HealthAssessmentEditModel { get; set; }
        public HealthAssessmentFooterEditModel HealthAssessmentFooterEditModel { get; set; }
        public HealthAssessmentHeaderEditModel HealthAssessmentHeaderEditModel { get; set; }

        public bool Print { get; set; }
        public bool PrintBlank { get; set; }

        public bool OpenforPrint { get; set; }
        public bool LoadLayout { get; set; }
        public bool RedirecttoPrevious { get; set; }

        public string RefrrerUrl { get; set; }

        public string PrintUrl { get; set; }

        public bool IsMammoPurchased { get; set; }

        public bool IsKynPurchased { get; set; }

        public bool IsBulkPrint { get; set; }

        public bool IsPhq9Purchased { get; set; }

        public bool IsFlushotTestPurchased { get; set; }

        public bool ShowConsentForm { get; set; }

        public bool IsQualityMeasuresPurchased { get; set; }

        public AbnConsentViewModel AbnConsentModel { get; set; }

        public AwvPcpConsentViewModel PcpConsentViewModel { get; set; }

        public MammogramHistoryFormViewModel MammogramHistoryFormViewModel { get; set; }

        public QualityAssuranceResultViewModel QualityAssuranceResultViewModel { get; set; }
        public FluVaccinationConsentViewModel FluVaccinationConsentViewModel { get; set; }
        public BloodworksLabelViewModel BloodworksLabelModel { get; set; }
        public PatientWorksheet PatientWorksheetModel { get; set; }
        public EventCustomerPcpAppointmentViewModel PcpAppointmentViewModel { get; set; }

        public bool AttachQualityAssuranceForm { get; set; }
        public bool AttachCongitiveClockForm { get; set; }
        public bool AttachChronicEvaluationForm { get; set; }
        public bool AttachParicipantConsentForm { get; set; }
        public string AccountTag { get; set; }

        public bool PrintKynBasicBiomertic { get; set; }
        public bool PrintLipidBasicBiomertic { get; set; }
        public GiftCertificateViewModel GiftCertificateViewModel { get; set; }

        public OrderRequisitionFormViewModel OrderRequisitionFormViewModel { get; set; }

        public bool ShowHafFooter { get; set; }
        public bool IsHealthPlan { get; set; }
        public bool IsCorporateAccount { get; set; }

        public bool IsCagePurchased { get; set; }

        public HealthAssessmentFormEditModel()
        {
            Print = false;
            PrintBlank = false;
            OpenforPrint = false;
            LoadLayout = true;
        }
        public bool ShowMammogramQuestionnarire { get; set; }

        public CheckListFormEditModel CheckListFormModel { get; set; }
        public bool PrintCheckList { get; set; }

        public LabFormViewModel PrintMicroalbuminFormModel { get; set; }
        public bool PrintMicroalbuminForm { get; set; }

        public LabFormViewModel PrintIFOBTFormModel { get; set; }
        public bool PrintIFOBTForm { get; set; }

        public MonarchAttestaionFormViewModel MonarchAttestaionForm { get; set; }

        public bool PrintLoincLabData { get; set; }
        public LoincLabDataViewModel PrintLoincLabDataModel { get; set; }

        public SurveyFormEditModel SurveyFormModel { get; set; }
        public bool CaptureSurvey { get; set; }

    }

    [DefaultImplementation(Interface = typeof(IValidator<HealthAssessmentFormEditModel>))]
    public class HealthAssessmentFormEditModelValidator : AbstractValidator<HealthAssessmentFormEditModel>
    {

    }


    [DefaultImplementation(Interface = typeof(IValidator<HealthAssessmentHeaderEditModel>))]
    public class HealthAssessmentHeaderEditModelValidator : AbstractValidator<HealthAssessmentHeaderEditModel>
    {

    }

    [DefaultImplementation(Interface = typeof(IValidator<HealthAssessmentFooterEditModel>))]
    public class HealthAssessmentFooterEditModelValidator : AbstractValidator<HealthAssessmentFooterEditModel>
    {

    }
}
