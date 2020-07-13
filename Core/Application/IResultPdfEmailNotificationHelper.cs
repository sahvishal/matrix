using Falcon.App.Core.Interfaces;
using System;

namespace Falcon.App.Core.Application
{
    public interface IResultPdfEmailNotificationHelper
    {
        void SendEmailNotificationForFileNotPosted(string tag, int failedCustomerCount, ILogger logger);
    }
}
