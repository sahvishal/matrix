
namespace Falcon.App.Core.CallQueues
{
    public interface IConfirmationCallQueuePollingAgent
    {
        void PollForCallQueue();
    }
}
