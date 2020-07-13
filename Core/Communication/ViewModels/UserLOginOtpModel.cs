namespace Falcon.App.Core.Communication.ViewModels
{
    public class UserLoginOtpModel
    {

        public UserLoginOtpModel(PhoneCommunicationViewModelBase smsCommunication)
        {
            SmsCommunication = smsCommunication;
        }
        public PhoneCommunicationViewModelBase SmsCommunication { get; set; }
        public string Otp { get; set; }
    }
}
