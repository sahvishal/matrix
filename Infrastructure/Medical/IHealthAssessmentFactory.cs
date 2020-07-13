using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Medical
{
    public interface IHealthAssessmentFactory
    {
        IEnumerable<HealthAssessmentQuestion> MapMultiple(IEnumerable<CustomerHealthQuestionsEntity> entities);
        HealthAssessmentQuestion Map(CustomerHealthQuestionsEntity entity);
        IEnumerable<HealthAssessmentAnswer> MapMultiple(IEnumerable<CustomerHealthInfoEntity> entities);
        HealthAssessmentAnswer Map(CustomerHealthInfoEntity entity);
        IEnumerable<CustomerHealthInfoEntity> MapMultiple(IEnumerable<HealthAssessmentAnswer> healthAssessmentAnswers);
        CustomerHealthInfoEntity Map(HealthAssessmentAnswer domain);
        IEnumerable<HealthAssesmentArchiveAnswer> MapMultiple(IEnumerable<CustomerHealthInfoArchiveEntity> entities);
        HealthAssesmentArchiveAnswer Map(CustomerHealthInfoArchiveEntity entity);
        IEnumerable<CustomerHealthInfoArchiveEntity> MapMultiple(long version, IEnumerable<HealthAssessmentAnswer> healthAssessmentAnswers);
        CustomerHealthInfoArchiveEntity Map(long version, HealthAssessmentAnswer healthAssessmentAnswer);
        IEnumerable<HealthAssessmentQuestionGroup> MapMultiple(IEnumerable<CustomerHealthQuestionGroupEntity> entities);
        HealthAssessmentQuestionGroup Map(CustomerHealthQuestionGroupEntity entity);
    }
}