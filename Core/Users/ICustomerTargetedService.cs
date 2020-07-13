
namespace Falcon.App.Core.Users
{
    public interface ICustomerTargetedService
    {
        void Save(long customerId, int forYear, bool? isTargeted, long createdBy);//, ILogger logger
    }
}
