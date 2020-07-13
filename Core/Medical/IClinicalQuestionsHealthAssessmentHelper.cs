using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IClinicalQuestionsHealthAssessmentHelper
    {
        void SetRecommendationLogic(long templateId, HealthAssessmentEditModel model);

        void CompleteClinicalQuestionCriteriaInfo(IEnumerable<ClinicalTestQualificationCriteriaViewModel> templateCriteria,
                                    IEnumerable<HealthAssessmentQuestionGroup> clinicalGroups, IEnumerable<long> selectedQuestionIds);
    }
}