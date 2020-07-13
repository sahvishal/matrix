using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Users
{
    public class UserFactory<UserType> : IUserFactory<UserType>
        where UserType : User
    {
        private readonly IUserLoginFactory _userLoginFactory;
        private readonly IPhoneNumberFactory _phoneNumberFactory;
        private readonly PasswordCryptographyService _cryptographyService = new PasswordCryptographyService();


        public UserFactory()
            : this(new PhoneNumberFactory(), new UserLoginFactory(new OneWayHashingService()))
        { }

        public UserFactory(IPhoneNumberFactory phoneNumberFactory, IUserLoginFactory userLoginFactory)
        {
            _userLoginFactory = userLoginFactory;
            _phoneNumberFactory = phoneNumberFactory;
        }

        public UserType CreateUser(UserEntity userEntity, Address address, bool useUserLoginInfo = true)
        {
            if (userEntity == null)
            {
                throw new ArgumentNullException("userEntity");
            }

            // this workaround is necessary because although C# generics allow a default constructor constraint on a type, they do not allow
            // constraints for parameterized constructors.
            var user = (UserType)Activator.CreateInstance(typeof(UserType), userEntity.UserId);
            user.Address = address;
            user.DateOfBirth = userEntity.Dob;


            user.Email = !string.IsNullOrEmpty(userEntity.Email1) ? new Email(userEntity.Email1) : new Email(string.Empty, string.Empty);
            user.AlternateEmail = !string.IsNullOrEmpty(userEntity.Email2) ? new Email(userEntity.Email2) : new Email(string.Empty, string.Empty);

            user.HomePhoneNumber = _phoneNumberFactory.CreatePhoneNumber(userEntity.PhoneHome, PhoneNumberType.Home);
            user.MobilePhoneNumber = _phoneNumberFactory.CreatePhoneNumber(userEntity.PhoneCell, PhoneNumberType.Mobile);
            user.Name = new Name(userEntity.FirstName, userEntity.MiddleName, userEntity.LastName);
            user.OfficePhoneNumber = _phoneNumberFactory.CreatePhoneNumber(userEntity.PhoneOffice, PhoneNumberType.Office);
            user.PhoneOfficeExtension = userEntity.PhoneOfficeExtension;
            if (useUserLoginInfo)
                user.UserLogin = _userLoginFactory.CreateUserLogin(userEntity.UserLogin);
            if (userEntity.DefaultRoleId != null)
                user.DefaultRole = (Roles)userEntity.DefaultRoleId.Value;

            user.DataRecorderMetaData = new DataRecorderMetaData
                                            {
                                                DateCreated = userEntity.DateCreated,
                                                DateModified = userEntity.DateModified
                                            };
            user.Ssn = !string.IsNullOrEmpty(userEntity.Ssn) ? _cryptographyService.Decrypt(userEntity.Ssn) : string.Empty;

            return user;
        }

        public List<UserType> CreateUsers(List<UserEntity> userEntities, List<Address> addresses)
        {
            if (userEntities == null)
            {
                throw new ArgumentNullException("userEntities", "User entities must be provided.");
            }
            if (addresses == null)
            {
                throw new ArgumentNullException("addresses", "A list of addresses must be provided.");
            }
            var users = new List<UserType>();
            foreach (var userEntity in userEntities)
            {
                Address address;
                try
                {
                    address = addresses.Where(a => a.Id == userEntity.HomeAddressId).Single();
                }
                catch (InvalidOperationException)
                {
                    throw new InvalidOperationException(string.Format("Could not find address for user {0}.",
                                                                      userEntity.UserId));
                }
                UserType user = CreateUser(userEntity, address);
                users.Add(user);
            }
            return users;
        }

        public List<UserType> CreateOnlyUsers(List<UserEntity> userEntities, List<Address> addresses)
        {
            if (userEntities == null)
            {
                throw new ArgumentNullException("userEntities", "User entities must be provided.");
            }
            if (addresses == null)
            {
                throw new ArgumentNullException("addresses", "A list of addresses must be provided.");
            }
            var users = new List<UserType>();
            foreach (var userEntity in userEntities)
            {
                Address address;
                try
                {
                    address = addresses.Where(a => a.Id == userEntity.HomeAddressId).Single();
                }
                catch (InvalidOperationException)
                {
                    throw new InvalidOperationException(string.Format("Could not find address for user {0}.", userEntity.UserId));
                }

                UserType user = CreateUser(userEntity, address, false);
                users.Add(user);
            }
            return users;
        }

        public List<UserType> CreateWithoutAddrss(List<UserEntity> userEntities)
        {
            if (userEntities == null)
            {
                throw new ArgumentNullException("userEntities", "User entities must be provided.");
            }

            return userEntities.Select(userEntity => CreateUser(userEntity, null, false)).ToList();
        }

        public UserEntity CreateUserEntity(UserType userType)
        {
            if (userType == null)
            {
                throw new ArgumentNullException("userType");
            }
            var userEntity = new UserEntity(userType.Id)
                                 {

                                     FirstName = userType.Name != null ? userType.Name.FirstName : string.Empty,
                                     LastName = userType.Name != null ? userType.Name.LastName : string.Empty,
                                     MiddleName = userType.Name != null ? userType.Name.MiddleName : string.Empty,
                                     HomeAddressId = userType.Address.Id,
                                     Dob = userType.DateOfBirth,
                                     Email1 = userType.Email != null ? userType.Email.ToString() : string.Empty,
                                     Email2 = userType.AlternateEmail != null ? userType.AlternateEmail.ToString() : string.Empty,

                                     PhoneCell = userType.MobilePhoneNumber != null ? userType.MobilePhoneNumber.AreaCode + userType.MobilePhoneNumber.Number : string.Empty,
                                     PhoneHome = userType.HomePhoneNumber != null ? userType.HomePhoneNumber.AreaCode + userType.HomePhoneNumber.Number : string.Empty,
                                     PhoneOffice = userType.OfficePhoneNumber != null ? userType.OfficePhoneNumber.AreaCode + userType.OfficePhoneNumber.Number : string.Empty,
                                     PhoneOfficeExtension = userType.PhoneOfficeExtension,
                                     DefaultRoleId = (long)userType.DefaultRole,
                                     CreatedByOrgRoleUserId = (userType.DataRecorderMetaData != null && userType.DataRecorderMetaData.DataRecorderCreator != null) ? userType.DataRecorderMetaData.DataRecorderCreator.Id == 0 ? (long?)null : userType.DataRecorderMetaData.DataRecorderCreator.Id : (long?)null,
                                     ModifiedByOrgRoleUserId = (userType.DataRecorderMetaData != null && userType.DataRecorderMetaData.DataRecorderModifier != null) ? userType.DataRecorderMetaData.DataRecorderModifier.Id == 0 ? (long?)null : userType.DataRecorderMetaData.DataRecorderModifier.Id : (long?)null,
                                     DateCreated = userType.DataRecorderMetaData != null ? userType.DataRecorderMetaData.DateCreated : DateTime.Now,
                                     DateModified = userType.DataRecorderMetaData != null && userType.DataRecorderMetaData.DateModified.HasValue ? userType.DataRecorderMetaData.DateModified.Value : DateTime.Now,
                                     Ssn = !string.IsNullOrEmpty(userType.Ssn) ? _cryptographyService.Encrypt(userType.Ssn) : userType.Ssn,
                                     IsActive = true,
                                     UserLogin = _userLoginFactory.CreateUserLoginEntity(userType.UserLogin, userType.Id),
                                     IsNew = userType.Id <= 0
                                 };

            if (userType.Id == 0)
            {
                userEntity.CreatedByOrgRoleUserId = (userType.DataRecorderMetaData != null)
                                                        ? userType.DataRecorderMetaData.DataRecorderCreator.
                                                              OrganizationId
                                                        : (long?)null;
            }



            return userEntity;
        }


    }
}