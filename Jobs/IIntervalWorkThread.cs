namespace Falcon.Jobs
{
    public interface IIntervalWorkThread
    {
        void Start();
        void Trigger();
        void Stop();
    }
}