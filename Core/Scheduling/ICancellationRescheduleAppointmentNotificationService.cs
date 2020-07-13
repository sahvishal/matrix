namespace Falcon.App.Core.Scheduling
{
    public interface ICancellationRescheduleAppointmentNotificationService
    {
        void SendCancellationRescheduleAppointmentMail(bool isCancelAppointment, long customerId, long eventId, long newEventId, string reason, long orgRoleId, string source, string subReason);
    }
}
