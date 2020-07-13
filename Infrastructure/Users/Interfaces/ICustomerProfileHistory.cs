using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Interfaces
{
    public interface ICustomerProfileHistory
    {
        CustomerProfileHistoryEntity CustomerProfileHistoryEntity(UserEntity userEntity,CustomerProfileEntity customerProfileEntity, long createdBy);
    }
}