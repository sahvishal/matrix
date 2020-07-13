using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Factories.Users;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Users
{
    public class UserRepository<UserType> : PersistenceRepository, IUserRepository<UserType>
        where UserType : User
    {
        private readonly IUserFactory<UserType> _userFactory;
        private readonly IAddressRepository _addressRepository;

        public UserRepository()
        {
            _userFactory = new UserFactory<UserType>();
            _addressRepository = new AddressRepository();
        }

        public UserRepository(IPersistenceLayer persistenceLayer, IUserFactory<UserType> userFactory,
                              IAddressRepository addressRepository)
            : base(persistenceLayer)
        {
            _userFactory = userFactory;
            _addressRepository = addressRepository;
        }

        public bool UserNameExists(string userName)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return linqMetaData.UserLogin.Any(ul => ul.UserName == userName);
            }
        }

        public bool UserNameExists(long excludedUserId, string userName)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return linqMetaData.UserLogin.Any(ul => ul.UserName == userName && ul.UserLoginId != excludedUserId);
            }
        }

        public UserType GetUser(long userId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var userEntity =
                    linqMetaData.User.WithPath(prefetchPath => prefetchPath.Prefetch(u => u.UserLogin)).SingleOrDefault(
                        u => u.UserId == userId);
                if (userEntity == null)
                {
                    throw new ObjectNotFoundInPersistenceException<User>();
                }
                return _userFactory.CreateUser(userEntity, _addressRepository.GetAddress(userEntity.HomeAddressId));
            }
        }

        public List<UserType> GetUsers(List<long> userIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var userEntities =
                    linqMetaData.User.WithPath(prefetchPath => prefetchPath.Prefetch(u => u.UserLogin)).Where(
                        u => userIds.Contains(u.UserId)).ToList();
                if (userEntities.IsEmpty())
                {
                    throw new EmptyCollectionException();
                }
                List<long> addressIds = userEntities.Select(ue => ue.HomeAddressId).ToList();
                return _userFactory.CreateUsers(userEntities, _addressRepository.GetAddresses(addressIds));
            }
        }

        public List<UserType> GetOnlyUserAndAddressInfo(IEnumerable<long> userIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var userEntities = linqMetaData.User.Where(u => userIds.Contains(u.UserId)).ToList();

                if (userEntities.IsEmpty())
                {
                    throw new EmptyCollectionException();
                }
                List<long> addressIds = userEntities.Select(ue => ue.HomeAddressId).ToList();
                return _userFactory.CreateOnlyUsers(userEntities, _addressRepository.GetAddresses(addressIds));
            }
        }

        public List<UserType> GetActiveSystemUsers(List<long> userIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var userEntities =
                     linqMetaData.User.WithPath(prefetchPath => prefetchPath.Prefetch(u => u.UserLogin)).Where(
                         u => userIds.Contains(u.UserId) && u.IsActive && u.UserLogin.IsActive).ToList();
                List<long> addressIds = userEntities.Select(ue => ue.HomeAddressId).ToList();
                return _userFactory.CreateUsers(userEntities, _addressRepository.GetAddresses(addressIds));

            }
        }

        public bool UniqueEmail(string emailAddress)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return !linqMetaData.User.Any(u => u.Email1 == emailAddress);
            }
        }

        public bool UniqueEmail(long excludedUserId, string emailAddress)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return !linqMetaData.User.Any(u => u.UserId != excludedUserId && u.Email1 == emailAddress);
            }
        }

        public UserType SaveUser(UserType user)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = _userFactory.CreateUserEntity(user);

                entity.IsNew = entity.UserLogin.IsNew = (entity.UserId < 1);
                if (!adapter.SaveEntity(entity, true, true))
                {
                    throw new PersistenceFailureException();
                }
                user.Id = entity.UserId;
                return user;
            }
        }

        public void SetUserDefaultRole(long userId, Roles role)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.User.SingleOrDefault(u => u.UserId == userId);
                if (entity == null)
                {
                    throw new ObjectNotFoundInPersistenceException<User>();
                }
                entity.DefaultRoleId = (long)role;
                if (!adapter.SaveEntity(entity, true, true))
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetUsersWithDefaultRole(Roles defaultRole)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from u in linqMetaData.User
                        join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                        where
                            u.IsActive && oru.IsActive && u.DefaultRoleId == (long)defaultRole &&
                            oru.RoleId == (long)defaultRole
                        orderby u.FirstName, u.LastName
                        select new OrderedPair<long, string>(oru.OrganizationRoleUserId, u.FirstName + " " + u.LastName)).ToArray();

            }
        }

        public IEnumerable<OrderedPair<long, string>> GetUsersByRole(Roles role, bool activeUsersOnly = false)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from u in linqMetaData.User
                        join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                        where (!activeUsersOnly || u.IsActive && oru.IsActive) && oru.RoleId == (long)role
                        orderby u.FirstName, u.LastName
                        select new OrderedPair<long, string>(oru.OrganizationRoleUserId, u.FirstName + " " + u.LastName)).ToArray();

            }
        }

        public bool UpdateUserIsActiveStatus(long userId, bool isActive)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var userEntity = new UserEntity(userId) { IsActive = isActive, DateModified = DateTime.Now };
                var bucket = new RelationPredicateBucket(UserFields.UserId == userId);
                try
                {
                    return (adapter.UpdateEntitiesDirectly(userEntity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public List<KeyValuePair<long, string>> SearchUsersByName(string prefix, bool onlyCustomer)
        {
            prefix = prefix.Trim();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var query = from p in linqMetaData.User
                            join oru in linqMetaData.OrganizationRoleUser
                            on p.UserId equals oru.UserId
                            where (p.FirstName + (p.MiddleName.Trim().Length > 0 ? (" " + p.MiddleName + " ") : " ") + p.LastName).Contains(prefix)
                            select new { user = p, oru };

                if (onlyCustomer)
                {
                    query = from p in query
                            where p.user.Role.RoleId == (long)Roles.Customer
                            select p;

                    return query.Select(x => new KeyValuePair<long, string>(x.oru.OrganizationRoleUserId, x.user.FirstName + " " + x.user.LastName)).ToList();
                }

                return query.Select(x => new KeyValuePair<long, string>(x.oru.OrganizationRoleUserId, x.user.FirstName + " " + x.user.LastName + " - " + x.oru.Role.Name + " (" + x.oru.Organization.Name + ")")).ToList();
            }
        }

        public bool UpdateUsePhoneAndEmail(long userId, string phoneCell, string email)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var userEntity = linqMetaData.User.SingleOrDefault(u => u.UserId == userId);

                if (userEntity != null)
                {
                    if (!string.IsNullOrEmpty(phoneCell))
                        userEntity.PhoneCell = phoneCell;
                    if (!string.IsNullOrEmpty(email))
                        userEntity.Email1 = email;

                    return myAdapter.SaveEntity(userEntity, true);
                }
            }
            return false;
        }

        public List<KeyValuePair<long, string>> SearchUsersByNameAndRole(string prefix, Roles role)
        {
            prefix = prefix.Trim();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var query = (from p in linqMetaData.User
                             join oru in linqMetaData.OrganizationRoleUser
                             on p.UserId equals oru.UserId
                             where ((p.FirstName + (p.MiddleName.Trim().Length > 0 ? (" " + p.MiddleName + " ") : " ") + p.LastName).Contains(prefix))
                             && oru.RoleId == (long)Roles.CallCenterRep
                             && oru.IsActive
                             && p.IsActive
                             select new { user = p, oru });

                if (!query.Any())
                {
                    var empty = new List<KeyValuePair<long, string>>
                    {
                        new KeyValuePair<long, string>(0,"No records found")
                    };
                    return empty;
                }

                return query.Select(x => new KeyValuePair<long, string>(x.oru.OrganizationRoleUserId, x.user.FirstName + " " + x.user.LastName)).OrderBy(x => x.Value).ToList();
            }
        }

        public long? SearchUserByEmailAndRole(string emailId, long roleId = (long)Roles.CallCenterRep)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from u in linqMetaData.User
                              join oru in linqMetaData.OrganizationRoleUser
                                  on u.UserId equals oru.UserId
                              where u.Email1.Contains(emailId)
                                    && oru.RoleId == roleId
                                    && oru.IsActive
                                    && u.IsActive
                              select oru).SingleOrDefault();

                if (entity == null)
                    return null;
                return entity.OrganizationRoleUserId;
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetUsersByRoles(IEnumerable<long> roleIds, bool activeUsersOnly = false)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                //var childRoleIds = (from r in linqMetaData.Role where roleIds.Contains(r.RoleId) || (r.ParentId != null && roleIds.Contains(r.ParentId.Value)) select r.RoleId);

                return (from u in linqMetaData.User
                        join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                        where (!activeUsersOnly || u.IsActive && oru.IsActive) && roleIds.Contains(oru.RoleId)
                        orderby u.FirstName, u.LastName
                        select new OrderedPair<long, string>(oru.OrganizationRoleUserId, u.FirstName + " " + u.LastName)).ToArray();

            }
        }

        public List<UserType> GetUserWithoutAddressInfo(IEnumerable<long> userIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var userEntities = linqMetaData.User.Where(u => userIds.Contains(u.UserId)).ToList();

                if (userEntities.IsEmpty())
                {
                    throw new EmptyCollectionException();
                }

                return _userFactory.CreateWithoutAddrss(userEntities);
            }
        }
    }
}