using System.Configuration;

namespace Webhook.Models
{
    public class TwilioSettings
    {
        public static string TwilioFilePath { get { return ConfigurationManager.AppSettings.Get("TwilioFilePath"); } }
    }
}