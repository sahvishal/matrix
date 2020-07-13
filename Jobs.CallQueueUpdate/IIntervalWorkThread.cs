namespace Falcon.Jobs.CallQueueUpdate
{
    public interface IIntervalWorkThread
    {
        void Start();
        void Trigger();
        void Stop();
    }

}
