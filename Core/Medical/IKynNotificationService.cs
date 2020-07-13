using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IKynNotificationService
    {
        KynNotificationViewModel IsApplicableForNotification(EventCustomer eventCustomer);
    }
}
