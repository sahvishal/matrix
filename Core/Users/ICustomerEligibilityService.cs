using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.Users
{
    public interface ICustomerEligibilityService
    {
        void Save(long customerId, int forYear, bool? isEligible, long createdBy, ILogger logger, bool isUpload = false);
       // bool? GetEligibility(long customerId, int? year = null);
    }
}
