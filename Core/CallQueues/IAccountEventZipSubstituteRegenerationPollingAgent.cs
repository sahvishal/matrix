namespace Falcon.App.Core.CallQueues
{
    public interface IAccountEventZipSubstituteRegenerationPollingAgent
    {
        void PollForRegeneration();
    }
}
