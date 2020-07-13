namespace Falcon.Jobs.FloridaBlueService
{
    public interface IIntervalWorkThread
    {
        void Start();
        void Trigger();
        void Stop();
    }
}
