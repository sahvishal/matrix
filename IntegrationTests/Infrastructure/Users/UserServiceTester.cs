using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.Web.IntegrationTests.Fakes;
using FluentValidation;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Users
{
    [TestFixture]
    public class UserServiceTester
    {
        private readonly IUserService _userService;
        private readonly IMergeCustomerUploadService _mergeCustomerUploadService;  
        public UserServiceTester()
        {
            DependencyRegistrar.RegisterDependencies();
            IoC.Resolve<IAutoMapperBootstrapper>().Bootstrap();
            IoC.Register<ISessionContext, FakeSessionContext>(); //override the default impl.

            _userService = IoC.Resolve<IUserService>();
            _mergeCustomerUploadService = IoC.Resolve<IMergeCustomerUploadService>();
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public void Save_ThrowsValidationExceptionObjectIsEmpty()
        {
            
            var userCreateModel = new UserEditModel();

            _userService.Save(userCreateModel);
            
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public void Save_ThrowsValidationExceptionWhenPasswordsDoNotMatch()
        {

            var userCreateModel = new UserEditModel
            {
                FullName = new Name("John", "Doe", "K"),
                Email = "john.doe@test.com",
                UserName = "john.doe",
                Password = "123456"
            };

            _userService.Save(userCreateModel);
            
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public void Save_ThrowsInvalidAddressExceptionWhenUserNameAlreadyInUse()
        {

            var userCreateModel = new UserEditModel
                                      {
                                          FullName = new Name("John", "Doe", "K"),
                                          Email = "john.doe@test.com",
                                          UserName = "john.doe",
                                          Password = "123456",
                                          ConfirmPassword = "123456"
                                      };

            _userService.Save(userCreateModel);

        }

        [Test]        
        public void Save_SavesCorrectly()
        {

            var userCreateModel = new UserEditModel
            {
                FullName = new Name("John909090", "Doe898989", "K9"),
                Email = "john909090.doe898989@test.com",
                UserName = "john909090.doe898989",
                Password = "123456",
                ConfirmPassword = "123456"
            };

            _userService.Save(userCreateModel);

        }


        [Test]
        public void Save_UpdatesDefaultRoleCorrectly()
        {           
            
            //arrange
            var validUserIdWithCustomerRole = 2; //John Doe
            var user = _userService.Get(validUserIdWithCustomerRole);
            user.UsersRoles.Where(x => x.IsDefault).First().IsDefault = false;
            user.UsersRoles.Where(x => x.RoleId == (long) Roles.Customer).First().IsDefault = true;

            //act
            user = _userService.Save(user);

            //assert
            Assert.AreEqual(Roles.Customer, (Roles) user.UsersRoles.Where(x => x.IsDefault).First().RoleId);


            //clean up :)...
           user.UsersRoles.Where(x => x.IsDefault).First().IsDefault = false;
           user.UsersRoles.Where(x => x.RoleId == (long)Roles.CallCenterRep).First().IsDefault = true;
           _userService.Save(user);

        }

        [Test]
        public void Invalid_CustomerId()
        {

            //arrange
            var mergeCustomerUpload = new MergeCustomerUploadLog
            {
                CustomerId = 175812915,
                DuplicateCustomerId = "abcd,1758129",
            };
            _mergeCustomerUploadService.ParseMergeCustomerLog(mergeCustomerUpload, 1);

        }

    }
}