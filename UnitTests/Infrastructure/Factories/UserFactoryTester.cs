using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Geo;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Factories.Users;
using NUnit.Framework;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.Infrastructure.Factories
{
    [TestFixture]
    [Ignore]
    public class UserFactoryTester
    {
        private readonly MockRepository _mocks = new MockRepository();
        private IEmailFactory _emailFactory;
        private IUserLoginFactory _userLoginFactory;
        private IPhoneNumberFactory _phoneNumberFactory;

        private IUserFactory<User> _userFactory;

        [SetUp]
        public void SetUp()
        {
            _emailFactory = _mocks.StrictMock<IEmailFactory>();
            _phoneNumberFactory = _mocks.StrictMock<IPhoneNumberFactory>();
            _userLoginFactory = _mocks.StrictMock<IUserLoginFactory>();
            _userFactory = new UserFactory<User>( _phoneNumberFactory, _userLoginFactory);
        }

        [TearDown]
        public void TearDown()
        {
            _emailFactory = null;
            _phoneNumberFactory = null;
            _userFactory = null;
            _userLoginFactory = null;
        }

        private void ExpectFactoryCalls()
        {
            ExpectFactoryCalls(1);
        }

        private void ExpectFactoryCalls(int repeatCount)
        {
            Expect.Call(_emailFactory.CreateEmail(null)).IgnoreArguments()
                .Return(new Email(string.Empty, string.Empty)).Repeat.Times(2 * repeatCount);
            Expect.Call(_phoneNumberFactory.CreatePhoneNumber(null, 0)).IgnoreArguments()
                .Return(new PhoneNumber(null, null, 0)).Repeat.Times(3 * repeatCount);
            Expect.Call(_userLoginFactory.CreateUserLogin(null)).IgnoreArguments()
                .Return(new UserLogin(0)).Repeat.Times(repeatCount);
        }

        [Test]
        public void CreateUserReturnsUser()
        {
            var userEntity = new UserEntity();

            ExpectFactoryCalls();

            _mocks.ReplayAll();
            User user = _userFactory.CreateUser(userEntity, null);
            _mocks.VerifyAll();

            Assert.IsNotNull(user);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateUserThrowsExceptionWhenNullEntityGiven()
        {
            _mocks.ReplayAll();
            _userFactory.CreateUser(null, null);
            _mocks.VerifyAll();
        }

        [Test]
        public void CreateUserSetsUserIdToUserIdOfGivenEntity()
        {
            var userEntity = new UserEntity { UserId = 24 };

            ExpectFactoryCalls();

            _mocks.ReplayAll();
            User user = _userFactory.CreateUser(userEntity, null);
            _mocks.VerifyAll();

            Assert.AreEqual(userEntity.UserId, user.Id);
        }

        [Test]
        public void CreateUserSetsBirthDateToNullWhenEntityDobIsNull()
        {
            var userEntity = new UserEntity { Dob = null };

            ExpectFactoryCalls();

            _mocks.ReplayAll();
            User user = _userFactory.CreateUser(userEntity, null);
            _mocks.VerifyAll();

            Assert.IsNull(user.DateOfBirth);
        }

        [Test]
        public void CreateUserSetsDateOfBirthToValueOfEntityDob()
        {
            var userEntity = new UserEntity { Dob = new DateTime(2003, 4, 5) };

            ExpectFactoryCalls();

            _mocks.ReplayAll();
            User user = _userFactory.CreateUser(userEntity, null);
            _mocks.VerifyAll();

            Assert.IsNotNull(user.DateOfBirth);
            Assert.AreEqual(userEntity.Dob.Value, user.DateOfBirth.Value);
        }

        [Test]
        public void CreateUserCreatesEmailUsingEntityEmail1()
        {
            var userEntity = new UserEntity { Email1 = "email@email.email" };
            var expectedEmail = new Email(string.Empty, string.Empty);

            Expect.Call(_emailFactory.CreateEmail(userEntity.Email1)).Return(expectedEmail);
            Expect.Call(_emailFactory.CreateEmail(userEntity.Email2)).Return(new Email(string.Empty, string.Empty));
            Expect.Call(_phoneNumberFactory.CreatePhoneNumber(null, 0)).IgnoreArguments()
                .Return(new PhoneNumber(null, null, 0)).Repeat.Times(3);
            Expect.Call(_userLoginFactory.CreateUserLogin(null)).IgnoreArguments()
                .Return(new UserLogin(0)).Repeat.Times(1);

            _mocks.ReplayAll();
            User user = _userFactory.CreateUser(userEntity, null);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedEmail, user.Email);
        }

        [Test]
        public void CreateUserSetsNameBasedOnEntityNames()
        {
            var userEntity = new UserEntity { FirstName = "A", MiddleName = "Bc", LastName = "qq" };
            var expectedName = new Name(userEntity.FirstName, userEntity.MiddleName, userEntity.LastName);

            ExpectFactoryCalls();

            _mocks.ReplayAll();
            User user = _userFactory.CreateUser(userEntity, null);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedName.ToString(), user.Name.ToString());
        }

        [Test]
        public void CreateUserSetsUserLoginToUserLoginObject()
        {
            var userEntity = new UserEntity();

            ExpectFactoryCalls();

            _mocks.ReplayAll();
            User user = _userFactory.CreateUser(userEntity, null);
            _mocks.VerifyAll();

            Assert.IsNotNull(user.UserLogin);
        }

        [Test]
        public void CreateUserSetsPhoneNumbersToEntityPhoneNumbers()
        {
            var expectedPhoneNumber = new PhoneNumber(null, null, 0);
            var userEntity = new UserEntity { PhoneCell = "123-3445-333", PhoneHome = "3332228888", PhoneOffice = "18004338888" };

            Expect.Call(_emailFactory.CreateEmail(userEntity.Email1)).Return(new Email(string.Empty, string.Empty));
            Expect.Call(_emailFactory.CreateEmail(userEntity.Email2)).Return(new Email(string.Empty, string.Empty));
            Expect.Call(_phoneNumberFactory.CreatePhoneNumber(userEntity.PhoneCell, PhoneNumberType.Mobile))
                .Return(expectedPhoneNumber);
            Expect.Call(_phoneNumberFactory.CreatePhoneNumber(userEntity.PhoneHome, PhoneNumberType.Home))
                .Return(expectedPhoneNumber);
            Expect.Call(_phoneNumberFactory.CreatePhoneNumber(userEntity.PhoneOffice, PhoneNumberType.Office))
                .Return(expectedPhoneNumber);
            Expect.Call(_userLoginFactory.CreateUserLogin(null)).IgnoreArguments()
                .Return(new UserLogin(0)).Repeat.Times(1);

            _mocks.ReplayAll();
            User user = _userFactory.CreateUser(userEntity, null);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedPhoneNumber, user.HomePhoneNumber);
            Assert.AreEqual(expectedPhoneNumber, user.MobilePhoneNumber);
            Assert.AreEqual(expectedPhoneNumber, user.OfficePhoneNumber);
        }

        [Test]
        public void CreateUserSetsAddressToGivenAddress()
        {
            var expectedAddress = new Address(3);

            ExpectFactoryCalls();

            _mocks.ReplayAll();
            User user = _userFactory.CreateUser(new UserEntity(), expectedAddress);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedAddress, user.Address);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateUsersThrowsExceptionWhenGivenNullUserEntities()
        {
            _mocks.ReplayAll();
            _userFactory.CreateUsers(null, new List<Address>());
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateUsersThrowsExceptionWhenGivenNullAddressList()
        {
            _mocks.ReplayAll();
            _userFactory.CreateUsers(new List<UserEntity>(), null);
            _mocks.VerifyAll();
        }

        [Test]
        public void CreateUsersReturnsEmptyListWhenEmptyEntityCollectionGiven()
        {
            _mocks.ReplayAll();
            List<User> users = _userFactory.CreateUsers(new List<UserEntity>(), new List<Address>());
            _mocks.VerifyAll();

            Assert.IsNotNull(users);
            Assert.IsEmpty(users);
        }

        [Test]
        public void CreateUsersReturnsListWithOneUserWhenOneUserEntityGiven()
        {
            const long homeAddressId = 3;
            var userEntities = new List<UserEntity> { new UserEntity { HomeAddressId = homeAddressId } };
            var addresses = new List<Address> { new Address(homeAddressId) };

            ExpectFactoryCalls();

            _mocks.ReplayAll();
            List<User> users = _userFactory.CreateUsers(userEntities, addresses);
            _mocks.VerifyAll();

            Assert.IsNotNull(users);
            Assert.IsTrue(users.HasSingleItem());
        }

        [Test]
        public void CreateUserReturnsThreeUsersWhenThreeUserEntitiesGiven()
        {
            const long homeAddressId = 3;
            var userEntity = new UserEntity { HomeAddressId = homeAddressId };
            var userEntities = new List<UserEntity> { userEntity, userEntity, userEntity };
            var addresses = new List<Address> { new Address(homeAddressId) };

            ExpectFactoryCalls(3);

            _mocks.ReplayAll();
            List<User> users = _userFactory.CreateUsers(userEntities, addresses);
            _mocks.VerifyAll();

            Assert.IsNotNull(users);
            Assert.AreEqual(userEntities.Count, users.Count);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateUsersThrowsExceptionWhenAddressWithGivenIdNotFoundInGivenAddressList()
        {
            var userEntities = new List<UserEntity> { new UserEntity() };

            _mocks.ReplayAll();
            _userFactory.CreateUsers(userEntities, new List<Address>());
            _mocks.VerifyAll();
        }
    }
}