using System;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System.Linq;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    //TODO: Move this to UserService
    public class UserListModelRepository : PersistenceRepository, IUsersListModelRepository
    {
        private readonly IUserListModelFactory _factory;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IRoleRepository _roleRepository;

        public UserListModelRepository(IUserListModelFactory userListModelFactory, IOrganizationRoleUserRepository organizationRoleUserRepository, IOrganizationRepository organizationRepository,
            IRoleRepository roleRepository)
        {
            _factory = userListModelFactory;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _organizationRepository = organizationRepository;
            _roleRepository = roleRepository;
        }


        public UserListModel GetUserListModelPaged(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var orgQuery = BuildQuery(filter as UserListModelFilter, linqMetaData);

                //var organziationRoleUserEntities = orgQuery.OrderBy(oru => oru.User.FirstName).TakePage(pageNumber, pageSize).ToList(); ... This takes 9 seconds when resolving a prefetch to User table. 
                var organziationRoleUserEntities = orgQuery.TakePage(pageNumber, pageSize).ToList();
                var users =
                    (from u in linqMetaData.User
                     where organziationRoleUserEntities.Select(oru => oru.UserId).Contains(u.UserId)
                     select u).ToArray();

                organziationRoleUserEntities.ForEach(
                    oru => oru.User = users.Where(u => u.UserId == oru.UserId).SingleOrDefault());

                totalRecords = orgQuery.Count();

                var addressIds = organziationRoleUserEntities.Select(oru => oru.User.HomeAddressId).ToList();
                var addresses = linqMetaData.Address.WithPath(pf => pf.Prefetch(a => a.City).Prefetch(a => a.State).Prefetch(a => a.Zip)).Where(address => addressIds.Contains(address.AddressId)).ToList();

                var orgRoleUsers = _organizationRoleUserRepository.GetOrganizationRoleUserByUserIds(organziationRoleUserEntities.Select(oru => oru.UserId).ToArray());
                var otganizations = _organizationRepository.GetOrganizations(orgRoleUsers.Select(oru => oru.OrganizationId).ToArray());
                var roles = _roleRepository.GetAll();

                var userListModel = _factory.Create(organziationRoleUserEntities, addresses, orgRoleUsers, otganizations, roles);
                return userListModel;
            }
        }

        private static IQueryable<OrganizationRoleUserEntity> BuildQuery(UserListModelFilter filter, LinqMetaData linqMetaData)
        {
            var orgQuery = from u in linqMetaData.User
                           join ul in linqMetaData.UserLogin on u.UserId equals ul.UserLoginId
                           join a in linqMetaData.OrganizationRoleUser on u.UserId equals a.UserId
                           where ((filter != null && filter.ActiveUser && !filter.InActiveUser) ? u.IsActive : (filter != null && !filter.ActiveUser && filter.InActiveUser) ? !u.IsActive : true)                                  
                           orderby u.FirstName
                           select new { oru = a, u, ul };

            if (filter != null)
            {
                if (filter.Keyword != null)
                {
                    orgQuery = orgQuery.Where(oru => (oru.u.Email1.Contains(filter.Keyword) || oru.ul.UserName == filter.Keyword || ((oru.u.FirstName + (oru.u.MiddleName.Length > 0 ? " " + oru.u.MiddleName + " " : " ") + oru.u.LastName).Contains(filter.Keyword))));
                }

                if (filter.Roles > 0)
                {
                    orgQuery = orgQuery.Where(oru => oru.oru.RoleId == filter.Roles && oru.oru.IsActive);
                }
                else
                {
                    orgQuery = orgQuery.Where(oru => oru.u.DefaultRoleId == oru.oru.RoleId);
                }

                if (filter.UserType == UserType.CustomerOnly)
                {
                    orgQuery = orgQuery.Where(oru => oru.oru.RoleId == (long)Roles.Customer);
                }
                else if (filter.UserType == UserType.SystemUserOnly)
                {
                    orgQuery = orgQuery.Where(oru => oru.oru.RoleId != (long)Roles.Customer);
                }
            }

            return orgQuery.OrderBy(oru => oru.u.FirstName).Select(oru => oru.oru).WithPath(prefetchPath => prefetchPath.Prefetch(oru => oru.Organization).Prefetch(oru => oru.Role));
        }


        public UserListModel GetUserListModelByRole(Roles type)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var organziationRoleUserEntities = linqMetaData.OrganizationRoleUser.WithPath(
                    prefetchPath => prefetchPath.Prefetch(oru => oru.Organization).Prefetch(oru => oru.User).Prefetch(oru => oru.Role)).Where(
                        oru => oru.RoleId == (long)type && oru.IsActive).ToList();

                var addressIds = organziationRoleUserEntities.Select(oru => oru.User.HomeAddressId).ToList();
                var addresses = linqMetaData.Address.Where(address => addressIds.Contains(address.AddressId)).ToList();

                return _factory.Create(organziationRoleUserEntities, addresses);
            }
        }

        public UserListModel GetUserListModelByRole(Roles type, long organizationId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var organziationRoleUserEntities = linqMetaData.OrganizationRoleUser.WithPath(
                    prefetchPath => prefetchPath.Prefetch(oru => oru.Organization).Prefetch(oru => oru.User).Prefetch(oru => oru.Role)).Where(
                     oru => oru.OrganizationId == organizationId && oru.RoleId == (long)type && oru.IsActive).ToList();

                var addressIds = organziationRoleUserEntities.Select(oru => oru.User.HomeAddressId).ToList();
                var addresses = linqMetaData.Address.Where(address => addressIds.Contains(address.AddressId)).ToList();

                return _factory.Create(organziationRoleUserEntities, addresses);
            }
        }

        public UserListModel GetUserListModelByRolePaged(Roles type, int pageSize, int pageNumber)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var organziationRoleUserEntities = linqMetaData.OrganizationRoleUser.WithPath(
                    prefetchPath => prefetchPath.Prefetch(oru => oru.Organization).Prefetch(oru => oru.User).Prefetch(oru => oru.Role)).Where(
                        oru => oru.RoleId == (long)type && oru.IsActive).Skip(pageSize * pageNumber - 1).Take(pageSize).ToList();

                var totalRecords = linqMetaData.OrganizationRoleUser.WithPath(
                    prefetchPath =>
                    prefetchPath.Prefetch(oru => oru.Organization).Prefetch(oru => oru.User).Prefetch(oru => oru.Role)).
                    Where(
                        oru => oru.RoleId == (long)type).Count();

                var addressIds = organziationRoleUserEntities.Select(oru => oru.User.HomeAddressId).ToList();
                var addresses = linqMetaData.Address.Where(address => addressIds.Contains(address.AddressId)).ToList();

                var userListModel = _factory.Create(organziationRoleUserEntities, addresses);



                return userListModel;

            }
        }


        public UserListModel GetUserListModelByRole(Roles type, string searchCondition)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var filterOrus = (from oru in linqMetaData.OrganizationRoleUser
                                  join u in linqMetaData.User on oru.UserId equals u.UserId
                                  where (u.FirstName + " " + u.MiddleName + " " + u.LastName).
                                            Contains(searchCondition) && oru.RoleId == (long)type && oru.IsActive
                                  select oru);

                var organziationRoleUserEntities = filterOrus.
                    WithPath(prefetchPath =>
                             prefetchPath.Prefetch(oru => oru.Organization).Prefetch(oru => oru.User)).ToList();

                var addressIds = organziationRoleUserEntities.Select(oru => oru.User.HomeAddressId).ToList();
                var addresses = linqMetaData.Address.Where(address => addressIds.Contains(address.AddressId)).ToList();

                return _factory.Create(organziationRoleUserEntities, addresses);
            }
        }

        public UserListModel GetUserListModelByRolePaged(Roles type, string searchCondition, int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}
