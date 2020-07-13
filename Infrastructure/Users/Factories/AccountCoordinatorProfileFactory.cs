using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Factories
{
    [DefaultImplementation]
    public class AccountCoordinatorProfileFactory : IAccountCoordinatorProfileFactory
    {
        public AccountCoordinatorProfile CreateAccountCoordinatorProfile(AccountCoordinatorProfile accountCoordinatorProfile, AccountCoordinatorProfileEntity accountCoordinatorProfileEntity)
        {
            accountCoordinatorProfile.AccountCoordinatorId = accountCoordinatorProfileEntity.OrganizationRoleUserId;
            accountCoordinatorProfile.IsClinicalCoordinator = accountCoordinatorProfileEntity.IsClinicalCoordinator;
            return accountCoordinatorProfile;
        }

        public AccountCoordinatorProfileEntity CreateAccountCoordinatorProfileEntity(AccountCoordinatorProfile accountCoordinatorProfile)
        {
            return new AccountCoordinatorProfileEntity()
            {
                OrganizationRoleUserId = accountCoordinatorProfile.AccountCoordinatorId,
                IsClinicalCoordinator = accountCoordinatorProfile.IsClinicalCoordinator,
            };
        }
    }
}
