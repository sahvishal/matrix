using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.Interfaces
{
    public interface IEventCustomerTestNotPerformedNotificationRepository
    {
        EventCustomerTestNotPerformedNotification Save(EventCustomerTestNotPerformedNotification domain);
        IEnumerable<EventCustomerTestNotPerformedNotification> GetbyEventCustomerId(long eventCustomerId);
        void SaveAll(IEnumerable<EventCustomerTestNotPerformedNotification> domain);
    }
}
