using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IEventCustomerCriticalQuestionRepository
    {
        IEnumerable<EventCustomerCriticalQuestion> GetByEventCustomerId(long eventCustomerId);

        void Save(EventCustomerCriticalQuestion domain);

        void DeleteByEventCustomerId(long eventCustomerId);
    }
}
