using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.Users
{
    public interface ICustomerWarmTransferService
    {
        void Save(long customerId, int forYear, bool? isWarmTransfer, long createdBy, ILogger logger, bool isUpload = false);
    }
}
