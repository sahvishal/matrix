using Falcon.App.Core.Scheduling.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IRescheduleCancelDispositionRepository
    {
        IEnumerable<RescheduleCancelDisposition> GetByLookupIds(long[] lookupIds);
    }
}
