namespace Falcon.App.Core.CallCenter
{
    public interface ICallQueueCustomerPollingAgent
    {
         void PollForUpdateCustomerFlag();
        void PollForUpdateAppointmentFlag();
        void PollForUpdateCancellationFlag();

    }
}