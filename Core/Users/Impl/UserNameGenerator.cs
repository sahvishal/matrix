using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation]
    public class UserNameGenerator : IUserNameGenerator
    {
        private readonly IUserLoginRepository _userLoginRepository;

        public UserNameGenerator(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }

        public string Generate(Name fullName)
        {
            if (fullName == null) throw new InvalidOperationException("User Name generation Failure! Name not provided.");

            return Generate(fullName.FirstName, fullName.LastName);
        }

        public string Generate(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName)) throw new InvalidOperationException("User Name generation Failure! Name not provided.");

            var username = (firstName + "." + lastName).Trim();
            var isUnique = _userLoginRepository.UniqueUserName(0, username);
            var index = 1;

            while (!isUnique)
            {
                username += index.ToString("000");
                isUnique = _userLoginRepository.UniqueUserName(0, username);
                index++;
            }

            return username;
        }
        
    }
}