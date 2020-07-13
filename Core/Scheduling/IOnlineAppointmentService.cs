using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IOnlineAppointmentService
    {

        EventAppointmentOnlineListModel GetEventAppointmentSlotOnline(TempCart tempCart);

        EventAppointmentOnlineListModel SaveEventAppointmentSlotOnline(TempCart tempCart);
    }
}
