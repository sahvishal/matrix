using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.CallCenter
{
    public interface ICallQueueCustomerPublisher
    {
        bool UpdateCustomerDetailOnCallQueueResponse(CallQueueCustomerPubViewModel pub);
        bool UpdateFutreAppointmentFlag(FutureAppointmentFlagViewModel pub);
        bool UpdateAppointmentCancellationFlag(CancelAppointmentFlagViewModel pub);
    }
}
