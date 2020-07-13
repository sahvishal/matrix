namespace Falcon.Jobs.ResultPdfService
{
    public interface IIntervalWorkThread
    {
        void Start();
        void Stop();
        void Trigger();
    }
}