namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanFillEventCallQueuePollingAgent
    {
        void PollForCallQueue();
    }
}