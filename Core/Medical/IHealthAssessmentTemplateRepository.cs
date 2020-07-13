using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IHealthAssessmentTemplateRepository
    {
        HealthAssessmentTemplate GetById(long id);
        IEnumerable<HealthAssessmentTemplate> GetByIds(IEnumerable<long> ids);
        HealthAssessmentTemplate Save(HealthAssessmentTemplate healthAssessmentTemplate);
        IEnumerable<HealthAssessmentTemplate> GetHealthAssessmentTemplate(HealthAssessmentTemplateListModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        HealthAssessmentTemplate GetByName(string name);
        IEnumerable<HealthAssessmentTemplate> GetByType(HealthAssessmentTemplateType type);
        IEnumerable<HealthAssessmentTemplate> GetByCategory(HealthAssessmentTemplateCategory category);
        void PublishTemplate(long templateId);
    }
}
