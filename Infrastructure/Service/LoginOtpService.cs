using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Service
{
    [DefaultImplementation]
    public class LoginOtpService : ILoginOtpService
    {
        private readonly ILoginOtpRepository _loginOtpRepository;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly IRandomStringGenerator _randomStringGenerator;
        private readonly INotifier _notifier;
        private readonly IPhoneNotificationModelsFactory _smsNotificationModelsFactory;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly ILoginSettingRepository _loginSettingRepository; 
        private readonly ISessionContext _sessionContext;

        public LoginOtpService(ILoginOtpRepository loginOtpRepository, IConfigurationSettingRepository configurationSettingRepository, IRandomStringGenerator randomStringGenerator,
            INotifier notifier, IPhoneNotificationModelsFactory smsNotificationModelsFactory, IEmailNotificationModelsFactory emailNotificationModelsFactory, ILoginSettingRepository loginSettingRepository,
            ISessionContext sessionContext)
        {
            _loginOtpRepository = loginOtpRepository;
            _configurationSettingRepository = configurationSettingRepository;
            _randomStringGenerator = randomStringGenerator;
            _notifier = notifier;
            _smsNotificationModelsFactory = smsNotificationModelsFactory;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _loginSettingRepository = loginSettingRepository; 
            _sessionContext = sessionContext;
        }

        public bool VerifyOtp(string otp, long userLoginId, out bool isOtpExpired, out bool isAttemptExcceded)
        {
            isOtpExpired = false;
            isAttemptExcceded = false;
            var otpExpireMinsStr = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpExpirationMinutes);
            int otpExpireMins = Convert.ToInt32(otpExpireMinsStr);
            var loginOtp = _loginOtpRepository.Get(userLoginId);
            if (loginOtp.DateCreated.AddMinutes(otpExpireMins) < DateTime.Now)
            {
                isOtpExpired = true;
                return false;
            }
            
            loginOtp.AttemptCount = loginOtp.AttemptCount + 1;
            _loginOtpRepository.Save(loginOtp);
            var maxAttempts = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpMisMatchAttemptCount);

            if (loginOtp.AttemptCount <= Convert.ToInt32(maxAttempts) && loginOtp.Otp == otp)
            {
                return true;
            }
            if (loginOtp.AttemptCount >= Convert.ToInt32(maxAttempts))
            {
                isAttemptExcceded = true;
                return false;
            }
            
            return false;
        }

        public bool GenerateOtp(long userId, string sourceUrl)
        {
            var otp = _randomStringGenerator.GetRandomNumericString(6);
            var userOtp = _loginOtpRepository.Get(userId);
            if (userOtp != null)
            {
                userOtp.Otp = otp;
                userOtp.AttemptCount = 0;
                userOtp.DateCreated = DateTime.Now;
                _loginOtpRepository.Save(userOtp);
            }
            else
            {
                userOtp = new LoginOtp { Otp = otp, DateCreated = DateTime.Now, UserLoginId = userId, AttemptCount = 0 };
                _loginOtpRepository.Save(userOtp);
            }
            var loginSettings = _loginSettingRepository.Get(userId);
            var organizationRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

            var sendOtpBySms = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpNotificationMediumSms);
            if (Convert.ToBoolean(sendOtpBySms) && (loginSettings.AuthenticationModeId == (long)AuthenticationMode.Sms || loginSettings.AuthenticationModeId == (long)AuthenticationMode.BothSmsEmail))
            {
                var smsNotification = _smsNotificationModelsFactory.GetUserLoginOtpModel(otp);
                _notifier.NotifyViaSmsImmediate(NotificationTypeAlias.LoginOtpSmsNotification,EmailTemplateAlias.LoginOtpSmsNotification, (UserLoginOtpModel) smsNotification, userId,organizationRoleUserId, sourceUrl, null, 0, null, true);
            }
            var sendOtpByEmail = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpNotificationMediumEmail);
            if (Convert.ToBoolean(sendOtpByEmail) && (loginSettings.AuthenticationModeId == (long)AuthenticationMode.Email || loginSettings.AuthenticationModeId == (long)AuthenticationMode.BothSmsEmail))
            {
                var otpExpireMinsStr = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpExpirationMinutes);
                var emailNotification = _emailNotificationModelsFactory.GetLoginOtpEmailNotificationViewModel(userId, otp, otpExpireMinsStr);
                _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.LoginOtpEmailNotification, EmailTemplateAlias.LoginOtpEmailNotification, emailNotification, userId, organizationRoleUserId, sourceUrl, null, 0, null);
            }

            return true;
        }

        public bool ResetOtp(long userId)
        {
            var userOtp = _loginOtpRepository.Get(userId);
            if (userOtp != null)
            {
                userOtp.AttemptCount = 1;
                userOtp.Otp = "reset";
                _loginOtpRepository.Save(userOtp);
            }
            return true;
        }
    }
}
