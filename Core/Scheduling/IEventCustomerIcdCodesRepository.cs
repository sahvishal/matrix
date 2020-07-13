using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventCustomerIcdCodesRepository
    {
        IEnumerable<EventCustomerIcdCodes> GetbyEventCustomerId(long eventCustomerId);
        void SaveAll(long eventCustomerId, IEnumerable<long> icdCollection);
    }
}