using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class TestUpsellNotificationModel
    {
        public TestUpsellNotificationModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<Test> Tests { get; set; }
    }
}
