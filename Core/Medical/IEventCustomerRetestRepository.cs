using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using System;

namespace Falcon.App.Core.Medical
{
    public interface IEventCustomerRetestRepository
    {
        IEnumerable<EventCustomerRetest> GetByEventCustomerId(long eventCustomerId);

        void SaveEventCustomerRetest(long eventCustomerId, long[] testIds, long createdBy);

        void DeleteByEventCustomerId(long eventCustomerId);

        void DeleteByEventCustomerIdAndTestIds(long eventCustomerId, long[] testIds);

        IEnumerable<long> GetTestIdsByCustomerIdAndEventId(long customerId, long eventId);

        IEnumerable<EventCustomerRetest> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds);

        void UpdateMailSentDate(long eventCustomerId, DateTime? mailSendDate);
    }
}
