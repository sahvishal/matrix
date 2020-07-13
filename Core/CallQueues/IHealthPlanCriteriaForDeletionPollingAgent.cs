namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanCriteriaForDeletionPollingAgent
    {
        void PollforCriteriaDeletion();
    }
}