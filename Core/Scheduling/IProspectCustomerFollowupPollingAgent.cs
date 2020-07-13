namespace Falcon.App.Core.Scheduling
{
    public interface IProspectCustomerFollowupPollingAgent
    {
        void PollForSendingProspectCustomerReminders();
    }
}
