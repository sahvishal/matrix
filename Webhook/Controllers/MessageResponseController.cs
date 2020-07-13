using System;
using System.IO;
using System.Web.Http;
using NLog;
using Webhook.Models;

namespace Webhook.Controllers
{
    public class MessageResponseController : ApiController
    {
        // POST: api/MessageResponse
        public void Post([FromBody]TwillioMessageResponse message)
        {
            var logger = LogManager.GetLogger("MessageResponseController");
            try
            {
                logger.Info("getting reply from " + message.From);
                var twilioSerializer = new TwilioXmlSerializer();
                var filePath = Path.Combine(TwilioSettings.TwilioFilePath, DateTime.Now.Ticks + ".xml");
                twilioSerializer.SerializeandSave(filePath, message);
            }
            catch (Exception exception)
            {
                logger.Error("some error occurred");
                logger.Error("Message: " + exception.Message);
                logger.Error("Stack Trace: " + exception.StackTrace);
            }
        }

        public string Get()
        {
            return "Test/Ok";
        }
    }
}
