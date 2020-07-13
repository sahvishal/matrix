using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Web.UnitTests.Infrastructure.Application;
using NUnit.Framework;

namespace Falcon.UnitTests.Infrastructure.Users
{
    [TestFixture]
    public class UserRepositoryTester : RepositoryTesterBase
    {
        private IUserFactory<User> _userFactory;
        private IAddressRepository _addressRepository;

        private IUserRepository<User> _userRepository;

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            _userFactory = _mocks.StrictMock<IUserFactory<User>>();
            _addressRepository = _mocks.StrictMock<IAddressRepository>();

            _userRepository = new UserRepository<User>(_persistenceLayer, _userFactory, _addressRepository);
        }

        [TearDown]
        protected override void TearDown()
        {
            base.TearDown();
            _userFactory = null;
            _addressRepository = null;

            _userRepository = null;
        }

        [Ignore]
        [Test]
        [ExpectedException(typeof(ObjectNotFoundInPersistenceException<User>))]
        public void GetUserThrowsExceptionWhenUserWithGivenIdNotFound()
        {
            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchEntity(false);

            _mocks.ReplayAll();
            _userRepository.GetUser(0);
            _mocks.VerifyAll();
        }
    }
}