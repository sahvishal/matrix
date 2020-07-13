using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using Falcon.App.Core.ValueTypes;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{
    public class CallCenterRepRepository : PersistenceRepository, ICallCenterRepRepository
    {
        private readonly IUserRepository<CallCenterRep> _userRepository;
        private readonly IRoleRepository _roleRepository;

        public CallCenterRepRepository()
        {
            _userRepository = new UserRepository<CallCenterRep>();
            _roleRepository = new RoleRepository();
        }

        public CallCenterRepRepository(IPersistenceLayer persistenceLayer, IUserRepository<CallCenterRep> userRepository, IRoleRepository roleRepository)
            : base(persistenceLayer)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public CallCenterRep GetCallCenterRep(long callCenterRepId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var linqMetaData = new LinqMetaData(myAdapter);

                var orgRoleUserEntity = linqMetaData.OrganizationRoleUser.WithPath(prefetchPath => prefetchPath.Prefetch(org => org.CallCenterRepProfile))
                    .Where(oru => (oru.RoleId == (long)Roles.CallCenterRep || oru.Role.ParentId == (long)Roles.CallCenterRep)
                    && callCenterRepId == oru.OrganizationRoleUserId).FirstOrDefault();

                if (orgRoleUserEntity == null)
                    throw new ObjectNotFoundInPersistenceException<CallCenterRep>();

                CallCenterRep callCenterRep = _userRepository.GetUser(orgRoleUserEntity.UserId);
                callCenterRep.CallCenterRepId = orgRoleUserEntity.OrganizationRoleUserId;
                callCenterRep.CanRefund = orgRoleUserEntity.CallCenterRepProfile != null ? orgRoleUserEntity.CallCenterRepProfile.CanRefund : false;
                callCenterRep.CanChangeNotes = orgRoleUserEntity.CallCenterRepProfile != null ? orgRoleUserEntity.CallCenterRepProfile.CanChangeNotes : false;
                return callCenterRep;
            }
        }
         

        public bool CanRefund(long callCenterRepId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var linqMetaData = new LinqMetaData(myAdapter);

                var orgRoleUserEntity = linqMetaData.CallCenterRepProfile.Where(ccp => ccp.CallCenterRepId == callCenterRepId).FirstOrDefault();

                if (orgRoleUserEntity == null)
                    throw new ObjectNotFoundInPersistenceException<CallCenterRep>();

                return orgRoleUserEntity.CanRefund;
            }
        }

        public List<string> GetCallCenterRepsAuthorizedToRefund()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var userNames = (from p in linqMetaData.CallCenterRepProfile
                                 join oru in linqMetaData.OrganizationRoleUser on p.CallCenterRepId equals
                                     oru.OrganizationRoleUserId
                                 join u in linqMetaData.User on oru.UserId equals u.UserId
                                 where p.CanRefund
                                 select new { u.FirstName, u.MiddleName, u.LastName }).ToList();

                if (userNames.Count == 0)
                    throw new EmptyCollectionException();

                var names = new List<String>();
                userNames.ForEach(u => names.Add(new Name(u.FirstName, u.MiddleName, u.LastName).ToString()));

                return names;
            }
        }

        public List<CallCenterRep> GetCallCenterReps(List<long> callCenterRepIds)
        {
            List<OrderedPair<long, long>> orgRolesUsersforCCRep;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                orgRolesUsersforCCRep = linqMetaData.OrganizationRoleUser.Where(oru => (oru.RoleId == (long)Roles.CallCenterRep || oru.Role.ParentId == (long)Roles.CallCenterRep) && callCenterRepIds.Contains(oru.OrganizationRoleUserId)).
                                Select(oru => new OrderedPair<long, long>(oru.UserId, oru.OrganizationRoleUserId)).ToList();
            }

            List<CallCenterRep> callCenterReps = _userRepository.GetUsers(orgRolesUsersforCCRep.Select(oru => oru.FirstValue).ToList());
            foreach (var callCenterRep in callCenterReps)
            {
                CallCenterRep rep = callCenterRep;
                callCenterRep.CallCenterRepId = orgRolesUsersforCCRep.Single(oru => oru.FirstValue == rep.Id).SecondValue;
            }
            return callCenterReps;
        }

        public List<OrderedPair<long, string>> GetCallCenterRepIdNamePair()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var nameIdPairs = linqMetaData.User.Join(linqMetaData.OrganizationRoleUser.Where(oru => (oru.RoleId == (long)Roles.CallCenterRep) || oru.Role.ParentId == (long)Roles.CallCenterRep), u => u.UserId, oru => oru.UserId,
                    (u, oru) => new OrderedPair<long, string>(oru.OrganizationRoleUserId, new Name(u.FirstName, u.MiddleName, u.LastName).ToString())).ToList();

                return nameIdPairs;
            }
        }

        public CallCenterRep Save(CallCenterRep callCenterRep, long organizationRoleUserId)
        {
            //TODO: Temp patch, as from create user callcenter profile is not created.

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                //TODO: remove - Temp Patch to check idf the profile is created or not
                var orgRoleuser = new LinqMetaData(adapter).OrganizationRoleUser
                    .WithPath(prefetchPath => prefetchPath.Prefetch(org => org.CallCenterRepProfile))
                    .Where(
                        oru =>
                            (oru.RoleId == (long) Roles.CallCenterRep) &&
                            callCenterRep.CallCenterRepId == oru.OrganizationRoleUserId)
                    .FirstOrDefault();
                if (orgRoleuser != null && orgRoleuser.CallCenterRepProfile == null)
                {
                    callCenterRep.CallCenterRepId = 0;
                }

                // Might add a mapper class going forward, when there are a number of Profile Attributes. (Sandeep)
                var callCenterRepEntity = new CallCenterRepProfileEntity(organizationRoleUserId)
                {
                    CanRefund = callCenterRep.CanRefund,
                    CanChangeNotes = callCenterRep.CanChangeNotes,
                    IsNew = callCenterRep.CallCenterRepId > 0 ? false : true
                };
                if (!adapter.SaveEntity(callCenterRepEntity)) throw new PersistenceFailureException();

                return callCenterRep;
            }
        }

        public bool CanChangeNotes(long callCenterRepId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var linqMetaData = new LinqMetaData(myAdapter);

                var orgRoleUserEntity = linqMetaData.CallCenterRepProfile.Where(ccp => ccp.CallCenterRepId == callCenterRepId).FirstOrDefault();

                if (orgRoleUserEntity == null)
                    return false;

                return orgRoleUserEntity.CanChangeNotes;
            }
        }
    }
}