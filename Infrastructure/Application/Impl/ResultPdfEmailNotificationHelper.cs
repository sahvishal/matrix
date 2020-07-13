using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Interfaces;
using System;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class ResultPdfEmailNotificationHelper : IResultPdfEmailNotificationHelper
    {
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;

        public ResultPdfEmailNotificationHelper(IEmailNotificationModelsFactory emailNotificationModelsFactory, INotifier notifier)
        {
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
        }

        public void SendEmailNotificationForFileNotPosted(string tag, int failedCustomerCount, ILogger logger)
        {
            try
            {
                var fileNotPostedModel = _emailNotificationModelsFactory.GetFileNotPostedViewModel(tag, failedCustomerCount);
                _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.FileNotPosted, EmailTemplateAlias.FileNotPosted, fileNotPostedModel, 0, 1, "File Not Posted");
            }
            catch (Exception ex)
            {
                logger.Error("Error while sending File Not Posted notification");
                logger.Error("Message:" + ex.Message);
                logger.Error("Stack Trace:" + ex.StackTrace);
            }
        }
    }
}
