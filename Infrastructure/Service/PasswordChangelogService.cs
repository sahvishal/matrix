using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Service
{
    [DefaultImplementation]
    public class PasswordChangelogService : IPasswordChangelogService
    {
        private readonly IPasswordChangelogRepository _passwordChangelogRepository;
        private readonly IOneWayHashingService _oneWayHashingService;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;

        public PasswordChangelogService(IPasswordChangelogRepository passwordChangelogRepository, IOneWayHashingService oneWayHashingService, IConfigurationSettingRepository configurationSettingRepository)
        {
            _passwordChangelogRepository = passwordChangelogRepository;
            _oneWayHashingService = oneWayHashingService;
            _configurationSettingRepository = configurationSettingRepository;
        }

        public bool IsPasswordRepeated(long userLoginId, string password)
        {
            var countString = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PreviousPasswordNonRepetitionCount);
            var count = Convert.ToInt32(countString);

            var previousPasswordList = _passwordChangelogRepository.GetOldPasswordList(userLoginId);
            if (previousPasswordList == null || !previousPasswordList.Any())
                return false;
            var isPasswordRepeated = false;
            if (previousPasswordList.Count() >= count)
            {
                previousPasswordList = previousPasswordList.OrderByDescending(x => x.Sequence).Take(count); 
            }
            foreach (var passwordChangelog in previousPasswordList)
            {
                if (!_oneWayHashingService.Validate(password, new SecureHash(passwordChangelog.Password, passwordChangelog.Salt)))
                    continue;
                isPasswordRepeated = true; break;
            }
            return isPasswordRepeated;
        }

        public bool Update(long userLoginId, SecureHash usedSecureHash, long createdByOrgRoleUserId)
        {
            var passwordlist = _passwordChangelogRepository.GetOldPasswordList(userLoginId);
            var count = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PreviousPasswordNonRepetitionCount);

            if (passwordlist == null || passwordlist.Count() < Convert.ToInt32(count))
            {
                var passwordChangeLog = new PasswordChangelog()
                {
                    UserLoginId = userLoginId,
                    CreatedByOrgRoleUserId = createdByOrgRoleUserId,
                    Password = usedSecureHash.HashedText,
                    Salt = usedSecureHash.Salt,
                    DateCreated = DateTime.Now,
                    Sequence = passwordlist == null ?1: passwordlist.Count() + 1
                };
                return _passwordChangelogRepository.Save(passwordChangeLog);
            }

            if (passwordlist.Count() > Convert.ToInt32(count))
            {
                var extraInDb = passwordlist.Count() - Convert.ToInt32(count);
                var toBeDeletedList = passwordlist.OrderBy(x => x.Sequence).Take(extraInDb);

                foreach (var passwordChangelog in toBeDeletedList)
                {
                    _passwordChangelogRepository.Delete(passwordChangelog); 
                }
                passwordlist.ToList().ForEach(x => x.Sequence = x.Sequence - extraInDb);
                passwordlist = passwordlist.Where(x => !toBeDeletedList.Select(d => d.Id).Contains(x.Id));
            }

            if (passwordlist.Any())
            {
                var oldestPassword = passwordlist.OrderBy(x => x.Sequence).First();
                passwordlist.ToList().ForEach(x => x.Sequence = x.Sequence - 1);
                oldestPassword.Sequence = Convert.ToInt32(count);
                oldestPassword.UserLoginId = userLoginId;
                oldestPassword.CreatedByOrgRoleUserId = createdByOrgRoleUserId;
                oldestPassword.Password = usedSecureHash.HashedText;
                oldestPassword.Salt = usedSecureHash.Salt;
                oldestPassword.DateCreated = DateTime.Now;

                foreach (var passwordChangeLog in passwordlist)
                {
                    _passwordChangelogRepository.Save(passwordChangeLog);
                }
            }

            return true;
        }
    }
}
