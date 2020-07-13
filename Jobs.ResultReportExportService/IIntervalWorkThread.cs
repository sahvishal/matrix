namespace Falcon.Jobs.ResultReportExportService
{
    public interface IIntervalWorkThread
    {
        void Start();
        void Trigger();
        void Stop();
    }
}