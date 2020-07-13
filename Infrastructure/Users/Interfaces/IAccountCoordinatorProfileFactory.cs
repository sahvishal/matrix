using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Interfaces
{
    public interface IAccountCoordinatorProfileFactory
    {
        AccountCoordinatorProfile CreateAccountCoordinatorProfile(AccountCoordinatorProfile accountCoordinatorProfile, AccountCoordinatorProfileEntity accountCoordinatorProfileEntity);
        AccountCoordinatorProfileEntity CreateAccountCoordinatorProfileEntity(AccountCoordinatorProfile accountCoordinatorProfile);
    }
}
