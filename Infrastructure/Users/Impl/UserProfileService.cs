using System.Collections.Generic;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Infrastructure.Users.Impl
{
    [DefaultImplementation]
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IAddressService _addressService;
        private readonly IOneWayHashingService _oneWayHashingService;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ILoginSettingRepository _loginSettingRepository;

        public UserProfileService(IUserRepository<User> userRepository, IAddressService addressService, IOneWayHashingService oneWayHashingService, IConfigurationSettingRepository configurationSettingRepository,
            IRoleRepository roleRepository, ILoginSettingRepository loginSettingRepository)
        {
            _oneWayHashingService = oneWayHashingService;
            _configurationSettingRepository = configurationSettingRepository;
            _roleRepository = roleRepository;
            _loginSettingRepository = loginSettingRepository;
            _userRepository = userRepository;
            _addressService = addressService;
        }

        public ProfileEditModel GetProfileEditModel(long userId)
        {
            var user = _userRepository.GetUser(userId);
            var model = Mapper.Map<User, ProfileEditModel>(user);
            model.IsOtpBySmsEnabled = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpNotificationMediumSms) == "True";
            model.IsOtpByEmailEnabled = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpNotificationMediumEmail) == "True";
            model.IsOtpByAppEnabled = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpByGoogleAuthenticator) == "True";

            var role = _roleRepository.GetByRoleId((long)user.DefaultRole);
            model.IsPinRequiredForRole = role.IsPinRequired;
            bool isTwoFactorAuthrequired;

            var loginSettings = _loginSettingRepository.Get(user.Id);
            if (loginSettings != null)
            {
                model.UseAuthenticator = loginSettings.AuthenticationModeId == (long)AuthenticationMode.AuthenticatorApp;
                model.UseSms = loginSettings.AuthenticationModeId == (long)AuthenticationMode.Sms || loginSettings.AuthenticationModeId == (long)AuthenticationMode.BothSmsEmail;
                model.UseEmail = loginSettings.AuthenticationModeId == (long)AuthenticationMode.Email || loginSettings.AuthenticationModeId == (long)AuthenticationMode.BothSmsEmail;
                model.Secret = loginSettings.GoogleAuthenticatorSecretKey;
            }


            if (model.UseSms || model.UseEmail || model.UseAuthenticator)
            {
                isTwoFactorAuthrequired = user.UserLogin.IsTwoFactorAuthrequired == null ? role.IsTwoFactorAuthrequired : user.UserLogin.IsTwoFactorAuthrequired.Value;
            }
            else
            {
                isTwoFactorAuthrequired = false;
            }

            if (!isTwoFactorAuthrequired)
            {
                model.IsOtpBySmsEnabled = false;
                model.IsOtpByEmailEnabled = false;
                model.IsOtpByAppEnabled = false;
            }

            return model;
        }

        public void SaveProfile(ProfileEditModel profileEditModel)
        {
            var user = Mapper.Map<ProfileEditModel, User>(profileEditModel);
            user.UserLogin.IsSecurityQuestionVerified = true;
            user.UserLogin.UserVerified = true;
            if (profileEditModel.Id > 0 && string.IsNullOrEmpty(profileEditModel.Password))
            {
                var existingUser = _userRepository.GetUser(profileEditModel.Id);
                user.UserLogin.Password = existingUser.UserLogin.Password;
                user.UserLogin.Salt = existingUser.UserLogin.Salt;
            }
            else if (!string.IsNullOrEmpty(profileEditModel.Password))
            {
                var secureHash = _oneWayHashingService.CreateHash(profileEditModel.Password);
                user.UserLogin.Password = secureHash.HashedText;
                user.UserLogin.Salt = secureHash.Salt;
            }

            _addressService.SaveAfterSanitizing(user.Address);

            _userRepository.SaveUser(user);
        }

        public IEnumerable<PatientInformationViewModel> GetPatientListByFilter(PatientSearchFilter filter)
        {
            return new List<PatientInformationViewModel>();
        }
    }
}
