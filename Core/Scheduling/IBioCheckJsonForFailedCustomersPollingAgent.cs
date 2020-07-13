namespace Falcon.App.Core.Scheduling
{
    public interface IBioCheckJsonForFailedCustomersPollingAgent
    {
        void PollForBiomassEvents();
    }
}