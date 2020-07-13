using System;
using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IMedicareQuestionRepository
    {
        IEnumerable<MedicareQuestion> GetAllQuestions();
        IEnumerable<MedicareQuestionGroup> GetAllGroups();
        IEnumerable<MedicareQuestionAnswer> GetAnswersByEventCustomerId(long eventcustomerId);
        IEnumerable<MedicareQuestionsRemark> GetQuestionRemarks();
        IEnumerable<OrderedPair<long, DateTime>> GetEvenetCustomerMedicareSavedDatePair(long eventId);
        void SaveCustomerAnswer(IEnumerable<MedicareQuestionAnswer> customerAnswers, long customerEventId,long createdBy);
    }
}