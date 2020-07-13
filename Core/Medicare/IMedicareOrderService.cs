using System.Collections.Generic;

namespace Falcon.App.Core.Medicare
{
    public interface IMedicareOrderService
    {
        bool ChangePackage(long eventId, long customerId, IEnumerable<long> testIds);
        bool AddMissingTestToEvent(long eventId, IEnumerable<long> testIds);
    }
}
