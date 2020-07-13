namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanConfirmationQueuePollingAgent
    {
        void PollForQueueGeneration();
    }
}
