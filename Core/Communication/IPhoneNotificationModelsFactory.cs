using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Communication
{
    public interface IPhoneNotificationModelsFactory
    {
        PhoneNotificationModel GetDummyScreeningReminderSmsNotificationModel();
        PhoneNotificationModel GetScreeningReminderSmsNotificationModel(Customer customer, Event theEvent);
        UserLoginOtpModel GetUserLoginOtpModel(string otp);
        UserLoginOtpModel GetDummyUserLoginOtpModel();
        CustomEventSmsNotificatonViewModel GetCustomEventSmsNotificatonModel(string body);
        CustomEventSmsNotificatonViewModel GetDummyCustomEventSmsNotificatonModel();
        WrongSmsResponseNotificationViewModel GetDummyWrongSmsResponseNotificationViewModel();
        WellcomeSmsNotificationViewModel GetDummyWellcomeSmsNotificationViewModel();
        WrongSmsResponseNotificationViewModel GetWrongSmsResponseNotificationViewModel();
        WellcomeSmsNotificationViewModel GetWellcomeSmsNotificationViewModel();
    }
}
