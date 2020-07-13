namespace Falcon.Jobs.ExternalProcessService
{
    public interface IIntervalWorkThread
    {
        void Start();
        void Trigger();
        void Stop();
    }
}