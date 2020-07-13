namespace Falcon.App.Core.Scheduling
{
    public interface IScreeningReminderPollingAgent
    {
        void PollforSendingScreeningReminders();
    }
}