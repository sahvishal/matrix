using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Interfaces
{
    public interface ICustomerProfileHistoryFactory
    {
        CustomerProfileHistoryEntity CustomerProfileHistoryEntity(CustomerProfileEntity customerProfileEntity, UserEntity userEntity, long createdBy, CustomerEligibility customerEligibility, CustomerWarmTransferEntity customerWarmTransfer, CustomerTargetedEntity customerTargeted);
    }
}