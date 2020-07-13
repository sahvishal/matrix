using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ICustomerCriticalDataRepository
    {
        CustomerCriticalData GetbyId(long  id);
        IEnumerable<CustomerCriticalData> GetbyIds(IEnumerable<long> ids);
        IEnumerable<CustomerCriticalData> Get(long eventId, long customerId);
        CustomerCriticalData Get(long eventId, long customerId, long testId);
        void Delete(long customerId, long eventId, long testId);
        void Delete(long customerId, long eventId);
        IEnumerable<CustomerCriticalData> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds);
        Notes SaveCriticalNotes(long eventCustomerResultId, Notes notes);
        IEnumerable<Notes> GetNotes(long eventCustomerResultId);
        IEnumerable<OrderedPair<long, long>> GetEventCustomerResultIdNotesIdPair(IEnumerable<long> eventCustomerResultIds);
        IEnumerable<OrderedPair<long, bool>> GetCriticalTestIdDataAvaliablePair(long eventId, long customerId);
    }
}