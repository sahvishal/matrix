using Falcon.App.Core.Scheduling.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IEventProductTypeRepository
    {
        IEnumerable<EventProductType> GetByEventIds(IEnumerable<long> eventIds);
        IEnumerable<EventProductType> GetByEventIdAndCustomerId(long eventId,long customerId);
        long[] GetProductTypeByEventId(long eventId);
    }
}
