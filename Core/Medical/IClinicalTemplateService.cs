using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IClinicalTemplateService
    {
        HealthAssessmentTemplateListModel GetClinicalTemplate(HealthAssessmentTemplateListModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        TemplateCriteriaEditModel GetTemplateCriteriaEditModel(long templateId);
        bool IsValidAgeCondition(ClinicalTestQualificationCriteriaEditModel model);
        bool IsValidForPublish(IEnumerable<ClinicalTestQualificationCriteriaEditModel> criterias);
        void SaveCriteria(TemplateCriteriaEditModel templateModel, long orgRoleUserId);
    }
}