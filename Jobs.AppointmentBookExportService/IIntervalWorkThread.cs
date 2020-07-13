namespace Falcon.Jobs.AppointmentBookExportService
{
    public interface IIntervalWorkThread
    {
        void Start();
        void Trigger();
        void Stop();
    }
}