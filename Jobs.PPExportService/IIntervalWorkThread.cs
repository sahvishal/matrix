namespace Falcon.Jobs.PPExportService
{
    public interface IIntervalWorkThread
    {
        void Start();
        void Trigger();
        void Stop();
    }
}
