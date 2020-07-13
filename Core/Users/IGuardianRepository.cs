using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface IGuardianRepository
    {
        GuardianDetails GetbyWithAddressId(long id);
        GuardianDetails GetbyWithoutAddressId(long id);
        IEnumerable<GuardianDetails> GetWithAddressByCustomerId(long customerId, bool isActive = true);
        IEnumerable<GuardianDetails> GetWithoutAddressByCustomerId(long customerId, bool isActive = true);
        GuardianDetails Save(GuardianDetails domainObject);
    }
}
