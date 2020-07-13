namespace Falcon.Jobs.CallQueueService
{
    public interface IIntervalWorkThread
    {
        void Start();
        void Trigger();
        void Stop();
    }
}
