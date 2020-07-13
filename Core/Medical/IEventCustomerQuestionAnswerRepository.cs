using Falcon.App.Core.Medical.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IEventCustomerQuestionAnswerRepository
    {
        IEnumerable<EventCustomerQuestionAnswer> GetAllByEventCustomerId(long customerId, long eventId, int version = 1);
        long GetLatestVersion(long customerId, long eventId);
        void SaveAnswer(IEnumerable<EventCustomerQuestionAnswer> answers);
        bool DeleteEventCustomerQuestionAnswers(long customerId, long eventId, long orgUserId);
        IEnumerable<EventCustomerQuestionAnswer> GetEventCustomerQuestionAnswer(long customerId);
        IEnumerable<EventCustomerQuestionAnswer> GetAllByCustomerIdEventId(long customerId, long eventId);
        bool DeleteEventCustomerQuestionAnswers(long customerId, long[] eventIds, long orgUserId);
    }
}
