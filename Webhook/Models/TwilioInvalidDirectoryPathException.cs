using System;

namespace Webhook.Models
{
    public class TwilioInvalidDirectoryPathException : Exception
    {
        public TwilioInvalidDirectoryPathException()
            : base("Invalid Directory Path")
        { }
    }
}