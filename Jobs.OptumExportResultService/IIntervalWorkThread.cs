namespace Falcon.Jobs.OptumExportResultService
{
    public interface IIntervalWorkThread
    {
        void Start();
        void Trigger();
        void Stop();
    }
}
