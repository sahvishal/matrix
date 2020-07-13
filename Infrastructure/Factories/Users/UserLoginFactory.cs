using System;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Users
{
    public class UserLoginFactory : IUserLoginFactory
    {
        private readonly IOneWayHashingService _oneWayHashingService;
        private readonly CryptographyService _cryptographyService = new PasswordCryptographyService();
        public UserLoginFactory(IOneWayHashingService oneWayHashingService)
        {
            _oneWayHashingService = oneWayHashingService;
        }

        public UserLoginEntity CreateUserLoginEntity(UserLogin userLogin, long userId)
        {
            if (userLogin == null)
            {
                throw new ArgumentNullException("userLogin");
            }
            string password = string.Empty;
            string salt = string.Empty;
            if (userId == 0 && !string.IsNullOrEmpty(userLogin.Password) && string.IsNullOrEmpty(userLogin.Salt))
            {
                var secureHash = _oneWayHashingService.CreateHash(userLogin.Password);
                password = secureHash.HashedText;
                salt = secureHash.Salt;
            }
            else
            {
                if (!string.IsNullOrEmpty(userLogin.Password) && string.IsNullOrEmpty(userLogin.Salt))
                {
                    var secureHash = _oneWayHashingService.CreateHash(userLogin.Password);
                    password = secureHash.HashedText;
                    salt = secureHash.Salt;
                }
                else
                {
                    password = userLogin.Password;
                    salt = userLogin.Salt;
                }
            }

            return new UserLoginEntity(userLogin.Id == 0 ? userId : userLogin.Id)
                       {
                           UserName = userLogin.UserName,
                           Password = password,
                           Salt = salt,
                           IsActive = true,
                           DateCreated =
                               userLogin.DateCreated != DateTime.MinValue ? userLogin.DateCreated : DateTime.Now,
                           DateModified = DateTime.Now,
                           IsLocked = userLogin.Locked,
                           LoginAttempts = userLogin.FailedAttempts,
                           UserVerified = userLogin.UserVerified,
                           HintAnswer = !string.IsNullOrEmpty(userLogin.HintAnswer) ? _cryptographyService.Encrypt(userLogin.HintAnswer) : userLogin.HintAnswer,
                           HintQuestion = userLogin.HintQuestion,
                           IsSecurityQuestionVerified = userLogin.IsSecurityQuestionVerified,
                           IsNew = userLogin.Id == 0,
                           LastPasswordChangeDate = userLogin.LastPasswordChangeDate != DateTime.MinValue ? userLogin.LastPasswordChangeDate : DateTime.Now,
                           IsTwoFactorAuthrequired = userLogin.IsTwoFactorAuthrequired
                       };
        }

        public UserLogin CreateUserLogin(UserLoginEntity userLoginEntity)
        {
            NullArgumentChecker.CheckIfNull(userLoginEntity, "userLoginEntity");


            string hintAnswer = string.Empty;

            if (!string.IsNullOrEmpty(userLoginEntity.HintAnswer))
                hintAnswer = _cryptographyService.Decrypt(userLoginEntity.HintAnswer);

            return new UserLogin(userLoginEntity.UserLoginId)
            {
                UserName = userLoginEntity.UserName,
                Password = userLoginEntity.Password,
                Salt = userLoginEntity.Salt,
                Locked = userLoginEntity.IsLocked,
                FailedAttempts = (long)userLoginEntity.LoginAttempts,
                IsSecurityQuestionVerified = userLoginEntity.IsSecurityQuestionVerified,
                UserVerified = userLoginEntity.UserVerified,
                HintAnswer = hintAnswer,
                HintQuestion = userLoginEntity.HintQuestion,
                LastLogged = userLoginEntity.LastLogged,
                DateCreated = userLoginEntity.DateCreated,
                DateModified = userLoginEntity.DateModified,
                IsActive = userLoginEntity.IsActive,
                LastPasswordChangeDate = userLoginEntity.LastPasswordChangeDate,
                IsTwoFactorAuthrequired = userLoginEntity.IsTwoFactorAuthrequired,
                LastLoginAttemptAt = userLoginEntity.LastLoginAttemptAt
            };
        }

    }
}