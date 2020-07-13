namespace Falcon.App.Core.Communication
{
    public interface ITwilioMessagingService
    {
        string SystemIdentification { get; }
        string AuthorizationToken { get; }
        string FromNumber { get; }
        void SendMessaging(string toNumber, string body);
    }
}
