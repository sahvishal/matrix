using System.Collections.Generic;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.ViewModels;

namespace Falcon.App.Core.Communication
{
    public interface IEFaxHelperService
    {
        EFaxResponse ServiceNotification(NotificationPhone phone, string emergencyFaxNumber);
        EFaxOutboundResponsStatus WaitForServiceToCompleteSending(NotificationPhone notification);
        Dictionary<string, List<Notification>> CreateGroupByFaxNumber(IEnumerable<Notification> notifications);
    }
}
