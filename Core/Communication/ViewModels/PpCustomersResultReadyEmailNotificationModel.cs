using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class PpCustomersResultReadyEmailNotificationModel
    {
        public PpCustomersResultReadyEmailNotificationModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public Name CustomerName { get; set; }

        public long CustomerId { get; set; }

        public string PcpName { get; set; }

        public string PcpPhone { get; set; }
        
    }
}