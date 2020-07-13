using System;

namespace Webhook.Models
{
    public class TwilioInvalidFileNameException : Exception
    {
        public TwilioInvalidFileNameException()
            : base("Invalid File Name")
        { }
    }
}