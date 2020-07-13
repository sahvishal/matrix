using Falcon.App.Core.Scheduling.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Sales
{
    public interface ICustomerOrderHistoryService
    {
        void SaveCustomerOrderHistory(EventCustomer eventCustomer, long corporateUploadId, long oldEventPackageId, long newEventPackageId,
            IEnumerable<long> oldEventTestIds, IEnumerable<long> newEventTestIds);
    }
}
