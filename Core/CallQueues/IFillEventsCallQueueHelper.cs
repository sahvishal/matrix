using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface IFillEventsCallQueueHelper
    {
        IEnumerable<Event> GetAllTheEventFilledUnderPecentage(IEnumerable<Event> events, decimal amount);
    }
}
