namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanConfirmationQueueNotGeneratedPollingAgent
    {
        void PollForQueueReGeneration();
    }
}
