
namespace Falcon.App.Core.CallQueues
{
    public interface IDeletePastEventSystemGeneratedCallQueuePollingAgent
    {
        void PollForCallQueueDeletion();
    }
}
