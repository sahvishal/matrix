using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Users.Mappers;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using Falcon.Data.EntityClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Users
{
    public class OrganizationRoleUserRepository : PersistenceRepository, IOrganizationRoleUserRepository
    {
        private readonly IMapper<OrganizationRoleUser, OrganizationRoleUserEntity> _mapper;

        public OrganizationRoleUserRepository()
            : this(new SqlPersistenceLayer(),
                    new OrganizationRoleUserMapper())
        {
        }

        public OrganizationRoleUserRepository(IPersistenceLayer persistenceLayer,
                                              IMapper<OrganizationRoleUser, OrganizationRoleUserEntity> mapper)
            : base(persistenceLayer)
        {
            _mapper = mapper;
        }

        public OrganizationRoleUser GetOrganizationRoleUser(long userId, Roles role, long organizationId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var organizationRoleUserEntity = linqMetaData.OrganizationRoleUser.
                    Where(oru => oru.UserId == userId && oru.RoleId == (long)role && oru.OrganizationId == organizationId && oru.IsActive).
                    SingleOrDefault();

                return _mapper.Map(organizationRoleUserEntity);
            }
        }

        public OrganizationRoleUser SaveOrganizationRoleUser(OrganizationRoleUser organizationRoleUser)
        {
            OrganizationRoleUserEntity organizationRoleUserEntity = _mapper.Map(organizationRoleUser);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (organizationRoleUser.Id == 0)
                {

                    var linqMetaData = new LinqMetaData(myAdapter);
                    var entity =
                        linqMetaData.OrganizationRoleUser.Where(
                            oru =>
                            oru.OrganizationId == organizationRoleUser.OrganizationId &&
                            oru.RoleId == organizationRoleUser.RoleId && oru.UserId == organizationRoleUser.UserId).
                            FirstOrDefault();

                    if (entity != null)
                    {
                        organizationRoleUserEntity = entity;
                        organizationRoleUserEntity.IsNew = false;
                    }
                }

                organizationRoleUserEntity.IsActive = true;
                if (!myAdapter.SaveEntity(organizationRoleUserEntity, true))
                {
                    throw new PersistenceFailureException();
                }
            }
            return _mapper.Map(organizationRoleUserEntity);
        }

        public bool DeactivateOrganizationRoleUser(long organizationRoleUserId)
        {
            var organizationRoleUserEntity = new OrganizationRoleUserEntity() { IsActive = false };

            IRelationPredicateBucket predicateBucket = new RelationPredicateBucket(OrganizationRoleUserFields.OrganizationRoleUserId == organizationRoleUserId);

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (myAdapter.UpdateEntitiesDirectly(organizationRoleUserEntity, predicateBucket) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }

            return true;
        }

        public void DeactivateAllOrganizationRolesForUser(long userId)
        {
            var organizationRoleUserEntity = new OrganizationRoleUserEntity() { IsActive = false };

            IRelationPredicateBucket predicateBucket = new RelationPredicateBucket(OrganizationRoleUserFields.UserId == userId);

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.UpdateEntitiesDirectly(organizationRoleUserEntity, predicateBucket); //just set to inactive if found, that is all.
            }
        }

        public bool DeactivateAllOrganizationRoleUserForOrganization(long organizationid)
        {
            var organizationRoleUserEntity = new OrganizationRoleUserEntity() { IsActive = false };

            IRelationPredicateBucket predicateBucket = new RelationPredicateBucket(OrganizationRoleUserFields.OrganizationId == organizationid);

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (myAdapter.UpdateEntitiesDirectly(organizationRoleUserEntity, predicateBucket) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
            return true;
        }

        public OrganizationRoleUser GetOrganizationRoleUser<T>(T data, Func<T, long> organizationRoleUserId)
        {
            return GetOrganizationRoleUser(organizationRoleUserId(data));
        }

        public List<long> GetUserIds(List<long> organizationRoleUserIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return
                    linqMetaData.OrganizationRoleUser.Where(
                        oru => organizationRoleUserIds.Contains(oru.OrganizationRoleUserId)).Select(oru => oru.UserId).
                        ToList();
            }
        }

        public OrganizationRoleUser GetOrganizationRoleUser(long organizationRoleUserId)
        {
            OrganizationRoleUserEntity organizationRoleUserEntity;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                organizationRoleUserEntity = linqMetaData.OrganizationRoleUser.
                    Where(oru => organizationRoleUserId == oru.OrganizationRoleUserId).Single();
            }
            return _mapper.Map(organizationRoleUserEntity);
        }

        public List<OrganizationRoleUser> GetOrganizationRoleUsers(IEnumerable<long> organizationRoleUserIds)
        {
            List<OrganizationRoleUserEntity> organizationRoleUserEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                organizationRoleUserEntities = linqMetaData.OrganizationRoleUser.
                    Where(oru => organizationRoleUserIds.Contains(oru.OrganizationRoleUserId)).ToList();
            }
            return _mapper.MapMultiple(organizationRoleUserEntities).ToList();
        }

        //TODO: SRE .... Need to remove this method 
        public OrderedPair<long, long> GetSalesRepUser(OrganizationRoleUser organizationRoleUser)
        {
            //using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            //{
            //    var linqMetaData = new LinqMetaData(myAdapter);
            //    return linqMetaData.FranchiseeUser.
            //        Join(linqMetaData.FranchiseeFranchiseeUser, fu => fu.FranchiseeUserId,
            //             ffu => ffu.FranchiseeUserId, (fu, ffu) => new { ffu, fu }).
            //        Where(
            //        @t =>
            //        //@t.ffu.FranchiseeId == organizationRoleUser.ShellId &&
            //        @t.ffu.RoleId == organizationRoleUser.RoleId && @t.fu.UserId == organizationRoleUser.UserId).
            //        Select(@t => new OrderedPair<long, long>(@t.fu.UserId, @t.ffu.FranchiseeFranchiseeUserId)).Single();
            //}

            return new OrderedPair<long, long>(organizationRoleUser.UserId, organizationRoleUser.Id);
        }

        public OrganizationRoleUserModel GetOrganizationRoleUsermodel(long userid, long roleId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var organizationRoleUser = linqMetaData.OrganizationRoleUser.
                    WithPath(prefetch =>
                        prefetch.Prefetch(orgRoleUser => orgRoleUser.User).
                        Prefetch(orgRoleUser => orgRoleUser.Organization).
                        Prefetch(orgRoleUser => orgRoleUser.Role)).Where(orgRoleUser => orgRoleUser.UserId == userid && orgRoleUser.RoleId == roleId).FirstOrDefault();

                if (organizationRoleUser == null)
                {
                    throw new ObjectNotFoundInPersistenceException<OrganizationRoleUser>(userid);
                }

                var modelMapper = new OrganizationRoleUserModelMapper();
                return modelMapper.Map(organizationRoleUser);
            }
        }

        public OrganizationRoleUser[] GetOrganizationRoleUserCollectionforaUser(long userId)
        {
            List<OrganizationRoleUserEntity> organizationRoleUserEntities = null;

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                organizationRoleUserEntities = linqMetaData.OrganizationRoleUser.Where(oru => userId == oru.UserId && oru.IsActive).ToList();
            }

            return _mapper.MapMultiple(organizationRoleUserEntities).ToArray();
        }

        public OrganizationRoleUser GetDefaultOrgRoleUserforOrganization(long organizationId, long roleId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entity = linqMetaData.OrganizationRoleUser.Where(oru => oru.RoleId == roleId && oru.OrganizationId == organizationId && oru.IsActive).FirstOrDefault();

                return _mapper.Map(entity);
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetNameIdPairofUsers(long[] orgRoleUserIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from u in linqMetaData.User
                        join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                        where orgRoleUserIds.Contains(oru.OrganizationRoleUserId)
                        select new OrderedPair<long, string>(oru.OrganizationRoleUserId, u.FirstName + " " + u.LastName)).OrderBy(o => o.SecondValue)
                    .ToList();
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetNameIdPairofUsersByEventDate(long[] orgRoleUserIds, DateTime? eventDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from u in linqMetaData.User
                        join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                        where orgRoleUserIds.Contains(oru.OrganizationRoleUserId)
                        && ((u.IsActive && oru.IsActive) || (eventDate != null && eventDate.Value <= u.DateModified))
                        select new OrderedPair<long, string>(oru.OrganizationRoleUserId, u.FirstName + " " + u.LastName)).OrderBy(o => o.SecondValue)
                    .ToList();
            }
        }

        public List<long> GetOrganizationRoleUserIdsForRole(long roleId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from oru in linqMetaData.OrganizationRoleUser
                        where oru.RoleId == roleId && oru.IsActive
                        orderby oru.OrganizationRoleUserId
                        select oru.OrganizationRoleUserId).ToList();
            }
        }

        public List<long> GetOrganizationRoleUserIdsByParentRole(long roleId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from oru in linqMetaData.OrganizationRoleUser
                        join role in linqMetaData.Role on oru.RoleId equals role.RoleId
                        where role.ParentId == roleId && oru.IsActive
                        orderby oru.OrganizationRoleUserId
                        select oru.OrganizationRoleUserId).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetIdNamePairofUsersByRole(Roles role)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var roleIds = (from r in linqMetaData.Role
                               where ((r.ParentId.HasValue && r.ParentId.Value == (long)role) || r.RoleId == (long)role)
                               select r.RoleId);

                return (from u in linqMetaData.User
                        join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                        where roleIds.Contains(oru.RoleId) && oru.IsActive && u.IsActive
                        select new OrderedPair<long, string>(oru.OrganizationRoleUserId, u.FirstName + " " + u.LastName)).OrderBy(op => op.SecondValue)
                    .ToList();
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetAllIdNamePairofUsersByRole(Roles role)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from u in linqMetaData.User
                        join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                        where oru.RoleId == (long)role
                        select new OrderedPair<long, string>(oru.OrganizationRoleUserId, u.FirstName + " " + u.LastName)).OrderBy(op => op.SecondValue)
                    .ToList();
            }
        }

        public IEnumerable<OrganizationRoleUser> GetOrganizationRoleUserByUserIds(IEnumerable<long> userIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from oru in linqMetaData.OrganizationRoleUser
                                where userIds.Contains(oru.UserId) //&& oru.IsActive
                                select oru);
                return _mapper.MapMultiple(entities).ToArray();
            }
        }

        public void ActivateAllOrganizationRolesForUser(long userId)
        {
            var organizationRoleUserEntity = new OrganizationRoleUserEntity() { IsActive = true };

            IRelationPredicateBucket predicateBucket = new RelationPredicateBucket(OrganizationRoleUserFields.UserId == userId);

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.UpdateEntitiesDirectly(organizationRoleUserEntity, predicateBucket); //just set to inactive if found, that is all.
            }
        }

        public IEnumerable<OrganizationRoleUser> GetOrganizationRoleUsersByOrganizationId(long organizationId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from oru in linqMetaData.OrganizationRoleUser
                                where oru.OrganizationId == organizationId && oru.IsActive
                                select oru);
                return _mapper.MapMultiple(entities).ToArray();
            }
        }

        public IEnumerable<OrganizationRoleUser> GetOrganizationRoleUsersByOrganizationIdAndRoleId(long organizationId, long roleId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var parentRoleId = (from r in linqMetaData.Role where r.RoleId == roleId select r.ParentId).SingleOrDefault();

                var entities = (from oru in linqMetaData.OrganizationRoleUser
                                where oru.OrganizationId == organizationId && oru.IsActive
                                && (oru.RoleId == roleId || oru.RoleId == parentRoleId)
                                select oru);

                return _mapper.MapMultiple(entities).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetNameIdPairofOrgRoleIdByEmail(IEnumerable<string> emails, long roleId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from u in linqMetaData.User
                        join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                        where emails.Contains(u.Email1) && oru.RoleId == roleId
                        select new OrderedPair<long, string>(oru.OrganizationRoleUserId, u.Email1)).OrderBy(o => o.SecondValue)
                    .ToList();
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetNameIdPairofOrgRoleIdByUserNames(IEnumerable<string> userNames, long roleId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from ul in linqMetaData.UserLogin
                        join oru in linqMetaData.OrganizationRoleUser on ul.UserLoginId equals oru.UserId
                        where userNames.Contains(ul.UserName) && oru.RoleId == roleId
                        select new OrderedPair<long, string>(oru.OrganizationRoleUserId, ul.UserName)).OrderBy(o => o.SecondValue)
                    .ToList();
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetIdNamePairofUsersByRoles(long[] roles)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var roleIds = (from role in linqMetaData.Role
                               where (role.ParentId.HasValue && roles.Contains(role.ParentId.Value) || roles.Contains(role.RoleId))
                               select role.RoleId);

                return (from u in linqMetaData.User
                        join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                        where roleIds.Contains(oru.RoleId) && oru.IsActive && u.IsActive
                        select new OrderedPair<long, string>(oru.OrganizationRoleUserId, u.FirstName + " " + u.LastName + " (" + oru.Role.Name + ")")).OrderBy(op => op.SecondValue)
                    .ToList();
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetIdNamePairofAllUsersByRole(Roles role)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var roleIds = (from r in linqMetaData.Role
                               where ((r.ParentId.HasValue && r.ParentId.Value == (long)role) || r.RoleId == (long)role)
                               select r.RoleId);

                return (from u in linqMetaData.User
                        join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                        where roleIds.Contains(oru.RoleId)
                        select new OrderedPair<long, string>(oru.OrganizationRoleUserId, u.FirstName + " " + u.LastName)).OrderBy(op => op.SecondValue)
                    .ToList();
            }
        }

        /// <summary>
        /// Pass parameter Emails in ToUpper()
        /// </summary>
        /// <param name="emails"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IEnumerable<OrderedPair<long, string>> GetActiveOruIdEmployeeIdPairByEmployeeIdAndRole(IEnumerable<string> employeeIds, long roleId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from sui in linqMetaData.SystemUserInfo
                        join oru in linqMetaData.OrganizationRoleUser on sui.UserId equals oru.UserId
                        where employeeIds.Contains(sui.EmployeeId.ToUpper()) && oru.RoleId == roleId
                        && oru.IsActive
                        select new OrderedPair<long, string>(oru.OrganizationRoleUserId, sui.EmployeeId)).OrderBy(o => o.SecondValue)
                    .ToList();
            }
        }

        public OrganizationRoleUser GetByUserNameAndRoleAlias(string username, string roleAlias)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(roleAlias)) return null;

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from oru in linqMetaData.OrganizationRoleUser
                              join r in linqMetaData.Role on oru.RoleId equals r.RoleId
                              join ul in linqMetaData.UserLogin on oru.UserId equals ul.UserLoginId
                              where r.Alias == roleAlias && ul.UserName == username
                              select oru).FirstOrDefault();

                if (entity == null) return null;

                return _mapper.Map(entity);
            }
        }

        public OrganizationRoleUser GetOrganizationRoleUserByEmployeeIdandRoleId(string employeeId, long roleId)
        {
            if (string.IsNullOrEmpty(employeeId) || roleId <= 0) return null;

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var roleIds =
                    (from r in linqMetaData.Role where (r.RoleId == roleId || r.ParentId == roleId) select r.RoleId);

                var entity = (from oru in linqMetaData.OrganizationRoleUser
                              join sui in linqMetaData.SystemUserInfo on oru.UserId equals sui.UserId
                              where sui.EmployeeId == employeeId && roleIds.Contains(oru.RoleId) && oru.IsActive
                              select oru).FirstOrDefault();

                if (entity == null) return null;
                return _mapper.Map(entity);
            }
        }

        public OrganizationRoleUser GetOrganizationRoleUserByUserIdAndRoleId(long userId, long roleId)
        {
            if (userId <= 0 || roleId <= 0) return null;

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var roleIds =
                    (from r in linqMetaData.Role where (r.RoleId == roleId || r.ParentId == roleId) select r.RoleId);

                var entity = (from oru in linqMetaData.OrganizationRoleUser
                              where oru.UserId == userId && roleIds.Contains(oru.RoleId) && oru.IsActive
                              select oru).FirstOrDefault();

                if (entity == null) return null;
                return _mapper.Map(entity);
            }
        }

    }
}