namespace Falcon.App.Core.CallQueues.ViewModels
{
    public interface IHealthPlanConfirmationQueueNotGeneratedPollingAgent
    {
        void PollForQueueReGeneration();
    }
}
