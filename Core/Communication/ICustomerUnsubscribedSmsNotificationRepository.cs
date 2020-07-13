using System.Collections.Generic;
using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Communication
{
    public interface ICustomerUnsubscribedSmsNotificationRepository
    {
        void SaveUnsubscribedSmsStatus(CustomerUnsubscribedSmsNotification smsReceived);
        IEnumerable<CustomerUnsubscribedSmsNotification> GetSmsReceived(long customerId);
    }
}