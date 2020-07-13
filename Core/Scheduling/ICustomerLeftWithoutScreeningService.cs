using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface ICustomerLeftWithoutScreeningService
    {
        void SendPatientLeftNotification(long eventCustomerId, long? leftWithoutScreeningReasonId, string notes, UserSessionModel currentUser, string source);
    }
}
