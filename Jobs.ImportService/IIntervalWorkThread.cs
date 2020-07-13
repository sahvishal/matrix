namespace Falcon.Jobs.ImportService
{
    public interface IIntervalWorkThread
    {
        void Start();
        void Trigger();
        void Stop();
    }
}