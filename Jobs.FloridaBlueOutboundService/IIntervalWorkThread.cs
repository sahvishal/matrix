namespace Jobs.FloridaBlueOutboundService
{
    public interface IIntervalWorkThread
    {
        void Start();
        void Trigger();
        void Stop();
    }
}
