namespace Falcon.App.Core.Scheduling
{
    public interface IAnnualReminderPollingAgent
    {
        void PollforSendingAnnualReminders();
    }
}