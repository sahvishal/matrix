namespace Falcon.Jobs.ReportingService
{
    public interface IIntervalWorkThread
    {
        void Start();
        void Stop();
        void Trigger();
    }
}
