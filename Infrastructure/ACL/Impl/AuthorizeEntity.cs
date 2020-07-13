using System;
using Falcon.App.Core.ACL;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;

namespace Falcon.App.Infrastructure.ACL.Impl
{
    public abstract class AuthorizeEntity<T> : IAuthorizeEntity where T : DomainObjectBase
    {
        public bool AuthorizeAccount(long entityId, Type repositoryType, long accountId)
        {
            if (repositoryType == typeof (IUniqueItemRepository<>))
            {
                //return AuthorizeAccount(ApplicationManager.DependencyInjection.Resolve<IUniqueItemRepository<T>>().GetById(entityId), accountId);
            }
            
            return true;
        }

        public bool AuthorizeSelf(long entityId, Type repositoryType, long organizationRoleUserId)
        {
            if (repositoryType == typeof(IUniqueItemRepository<>))
            {
                //return AuthorizeAccount(ApplicationManager.DependencyInjection.Resolve<IUniqueItemRepository<T>>().GetById(entityId), accountId);
            }

            return true;
        }

        //public virtual bool AuthorizeTeam(long entityId, long accountRoleUserId)
        //{
        //    var patientId = GetPatientId(Repository.Get(entityId));

        //    var careTeamPatient = CareTeamPatientRepository.Get(x => x.Patient.Id == patientId);
        //    if (careTeamPatient == null) return false;

        //    var accountRoleUser = AccountRoleUseRepository.Get(accountRoleUserId);
        //    if (accountRoleUser == null) return false;

        //    return careTeamPatient.CareTeam.Members.Any(
        //            x =>
        //                x.IsActive && x.Person.Id == accountRoleUser.UserId &&
        //                x.MemberType.Id == (long)GetCareTeamMemberType(accountRoleUser));
        //}

        //protected CareTeamMemberType GetCareTeamMemberType(AccountRoleUser accountRoleUser)
        //{
        //    switch (accountRoleUser.RoleType)
        //    {
        //        case Role.Doctor:
        //        case Role.Nurse:
        //            return CareTeamMemberType.Clinician;

        //        case Role.PrimaryCarePhysician:
        //            return CareTeamMemberType.PrimaryCarePhysician;
        //    }

        //    throw new InvalidDataException();
        //}

        protected abstract bool AuthorizeAccount(T entity, long accountId);

        protected abstract long GetPatientId(T entity);
    }
}