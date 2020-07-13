namespace Falcon.App.Core.Communication.ViewModels
{
    public class WellcomeSmsNotificationViewModel
    {
        public WellcomeSmsNotificationViewModel(PhoneCommunicationViewModelBase smsCommunication)
        {
            SmsCommunication = smsCommunication;
        }

        public PhoneCommunicationViewModelBase SmsCommunication { get; set; }
    }
}