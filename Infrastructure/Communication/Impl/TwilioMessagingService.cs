using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Interfaces;
using Twilio;


namespace Falcon.App.Infrastructure.Communication.Impl
{
    [DefaultImplementation]
    public class TwilioMessagingService : ITwilioMessagingService
    {

        public string SystemIdentification { get; set; }
        public string AuthorizationToken { get; set; }
        public string FromNumber { get; set; }
        private readonly ILogger _logger;
        public TwilioMessagingService(ILogManager logManager, ISettings settings)
        {
            SystemIdentification = settings.SmsSystemIdentification;
            AuthorizationToken = settings.SmsAuthorizationToken;
            FromNumber = settings.SmsFromNumber;
            _logger = logManager.GetLogger<TwilioMessagingService>();
        }

        public void SendMessaging(string toNumber, string body)
        {
            var twilio = new TwilioRestClient(SystemIdentification, AuthorizationToken);
            try
            {
                var response = twilio.SendMessage(FromNumber, toNumber, body);
                if (response.Status == null || response.Status != "queued")
                    throw new Exception("message not could not be queued");
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Some error Occured while sending message. Stack Trace :{0}", exception.StackTrace));
                throw;
            }

        }
    }
}
