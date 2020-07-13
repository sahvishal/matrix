using Falcon.App.Core.Interfaces;
using System;

namespace Falcon.App.Core.Application
{
    public interface IEmailNotificationHelper
    {
        void SendEmailNotificationForFileNotPosted(string tag, int failedCustomerCount, ILogger logger);
    }
}
