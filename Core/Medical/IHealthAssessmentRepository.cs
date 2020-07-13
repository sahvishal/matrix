using System;
using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IHealthAssessmentRepository
    {
        IEnumerable<HealthAssessmentQuestion> GetAllQuestions();
        IEnumerable<HealthAssessmentAnswer> Get(long customerId, long eventId);
        IEnumerable<HealthAssesmentArchiveAnswer> GetArchive(long customerId, long eventId, int versionNumber);
        void Save(IEnumerable<HealthAssessmentAnswer> answer);
        void SaveArchive(IEnumerable<HealthAssessmentAnswer> domainCollection, long versionNumber);
        void Delete(long eventCustomerId);
        long GetLastVersionNumber(long eventCustomerId);
        void Save(HealthAssessmentAnswer answer);
        HealthAssessmentQuestion GetQuestionByLabel(string label);
        IEnumerable<HealthAssessmentAnswer> GetByCustomerIds(IEnumerable<long> customerIds);
        IEnumerable<long> GetCustomerIdsforFilledHealthAssmtFormbyEventId(long eventId);
        IEnumerable<HealthAssessmentQuestionGroup> GetAllQuestionGroupWithQuestion(bool showOnlyClinicalQuestion = false);
        IEnumerable<HealthAssessmentQuestion> GetByIds(IEnumerable<long> ids);

        int GetLastVersionNumberUpdatedByCustomerOrOtherThanTechnician(long eventCustomerId, long customerId);
        IEnumerable<OrderedPair<long, DateTime>> GetHealthAssesmentSavedDatePair(IEnumerable<long> eventCustomerIds);
        IEnumerable<HealthAssessmentQuestionGroup> GetQuestionWithGroupForTemplatId(long templatId);
        
        IEnumerable<HealthAssessmentAnswer> GetAnswerByEventCustomerId(long eventCustomerId);
        IEnumerable<HealthAssessmentAnswer> GetCustomerHealthInfoByEventCustomerIds(IEnumerable<long> eventCustomerIds);
    }
}