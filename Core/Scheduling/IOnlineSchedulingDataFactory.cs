using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IOnlineSchedulingDataFactory
    {
        OnlineSchedulingProcessAndCartViewModel Create(TempCart tempCart, Customer customer, EventSchedulingSlot appointmentSlot, string sponsoredBy, string checkoutPhoneNumber);
    }
}