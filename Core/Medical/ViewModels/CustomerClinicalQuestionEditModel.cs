namespace Falcon.App.Core.Medical.ViewModels
{
    public class CustomerClinicalQuestionEditModel
    {
        public HealthAssessmentEditModel HealthAssessmentModel { get; set; }

        public long ClinicalQuestionTemplateId { get; set; }

        public string Guid { get; set; }
    }
}
