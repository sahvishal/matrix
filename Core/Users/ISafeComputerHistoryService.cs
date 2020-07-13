using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface ISafeComputerHistoryService
    { 
        bool IsSafe(SafeComputerHistory safeComputer);
        bool Save(SafeComputerHistory safeComputer);
    }
}
