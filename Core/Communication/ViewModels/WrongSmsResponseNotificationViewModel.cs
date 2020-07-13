namespace Falcon.App.Core.Communication.ViewModels
{
    public class WrongSmsResponseNotificationViewModel
    {
        public WrongSmsResponseNotificationViewModel(PhoneCommunicationViewModelBase smsCommunication)
        {
            SmsCommunication = smsCommunication;
        }

        public PhoneCommunicationViewModelBase SmsCommunication { get; set; }
    }
}