using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Users
{
    public interface ICustomerWarmTransferRepository
    {
        CustomerWarmTransfer GetByCustomerIdAndYear(long customerId, int year);
        void Save(CustomerWarmTransfer customerWarmTransfer);
        IEnumerable<CustomerWarmTransfer> GetByCustomerId(long customerId);
    }
}
