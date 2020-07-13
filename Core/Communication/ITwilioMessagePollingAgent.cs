namespace Falcon.App.Core.Communication
{
    public interface ITwilioMessagePollingAgent
    {
        void PollForTwilioResponse();
    }
}