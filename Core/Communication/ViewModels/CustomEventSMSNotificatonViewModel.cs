namespace Falcon.App.Core.Communication.ViewModels
{
    public class CustomEventSmsNotificatonViewModel
    {
        public CustomEventSmsNotificatonViewModel(PhoneCommunicationViewModelBase smsCommunication)
        {
            SmsCommunication = smsCommunication;
        }
        public PhoneCommunicationViewModelBase SmsCommunication { get; set; }
        public string Body { get; set; }

    }
}
