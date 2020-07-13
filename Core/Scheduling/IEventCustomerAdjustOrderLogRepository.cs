using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventCustomerAdjustOrderLogRepository
    {
        void Save(EventCustomerAdjustOrderLog model);
        void Update(EventCustomerAdjustOrderLog model);
        IEnumerable<EventCustomerAdjustOrderLog> GetEventCustomerToAdjustOrder();
    }
}