using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface ISafeComputerHistoryRepository
    {
        IEnumerable<SafeComputerHistory> Get(long userLoginId);
        bool Save(SafeComputerHistory loginOtp);
    }
}
