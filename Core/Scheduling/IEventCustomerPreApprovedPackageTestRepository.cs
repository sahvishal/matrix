using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventCustomerPreApprovedPackageTestRepository
    {
        void DeletePreApprovedPackageTests(long eventcustomerId);
        void Save(long eventcustomerId,long packageId, IEnumerable<long> testIds);
        long GetPreApprovedTestByEventCustomerId(long eventCustomerId);
        IEnumerable<OrderedPair<long, string>> GetCustomerIdPreApprovedPackageTests(IEnumerable<long> eventcustomerId);
    }
}