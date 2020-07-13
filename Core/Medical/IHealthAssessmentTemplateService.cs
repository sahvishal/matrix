using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IHealthAssessmentTemplateService
    {
        HealthAssessmentTemplateEditModel SaveTemplate(HealthAssessmentTemplateEditModel model, long organizationRoleUserId);
        HealthAssessmentTemplateEditModel GetHealthAssessmentTemplate(long templateId, long category);
    }
}
