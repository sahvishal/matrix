using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories.Users;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Users
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class UserRepositoryTester
    {
        private readonly IUserRepository<User> _userRepository = new UserRepository<User>();
        private const long VALID_USER_ID = 4;
        private const long VALID_USER_ID_2 = 1048;

        [Test]
        public void GetUserReturnsUserWhenValidIdGiven()
        {
            User user = _userRepository.GetUser(VALID_USER_ID);

            Assert.AreEqual(VALID_USER_ID, user.Id);
            Assert.IsNotNull(user);
        }

        [Test]
        public void GetUsersReturnsUsersWhenValidIdsGiven()
        {
            var validUserIds = new List<long> {VALID_USER_ID, VALID_USER_ID_2};
            List<User> users = _userRepository.GetUsers(validUserIds);

            Assert.IsNotNull(users);
            Assert.AreEqual(validUserIds.Count, users.Count);
        }

        [Test]
        public void GetActiveSystemUsers()
        {
            var validUserIds = new List<long> { VALID_USER_ID, VALID_USER_ID_2 };
            List<User> users = _userRepository.GetActiveSystemUsers(validUserIds);

            Assert.IsNotNull(users);
            Assert.AreEqual(validUserIds.Count, users.Count);
        }

        [Test]
        public void GetUsersWithDefaultRoleTester()
        {

            IEnumerable<OrderedPair<long, string>> users = _userRepository.GetUsersWithDefaultRole(Roles.Technician);

            Assert.IsNotNull(users);
        
        }

    }
}