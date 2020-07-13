namespace Falcon.App.Core.Scheduling
{
    public interface INoShowCustomerPollingAgent
    {
        void PollForCustomerDoesNotAppearOnEvent();
    }
}