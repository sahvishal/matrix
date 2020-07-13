using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Communication
{
    public interface IQueueCustomerFaxResultNotificationService
    {
        void QueueFaxResultNotification(IEnumerable<EventCustomerResult> eventCustomerResult, string notificationTypeAlias);
    }
}
