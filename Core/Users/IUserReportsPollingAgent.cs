namespace Falcon.App.Core.Users
{
    public interface IUserReportsPollingAgent
    {
        void PollForCustomerEventCriticalData();
    }
}
