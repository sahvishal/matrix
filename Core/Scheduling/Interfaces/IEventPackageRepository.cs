using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IEventPackageRepository : IRepository<EventPackage>
    {
        EventPackage GetById(long id);
        IEnumerable<EventPackage> GetByIds(IEnumerable<long> ids);
        EventPackage GetByEventAndPackageIds(long eventId, long packageId);
        IEnumerable<EventPackage> GetPackagesForEventByRole(long eventId, long roleId,long gender = (long) Gender.Unspecified);
        IEnumerable<OrderedPair<long, long>> GetEventPackageIdsForOrder(IEnumerable<long> orderIds);
        EventPackage GetPackageForOrder(long orderId);
        IEnumerable<EventPackage> GetPackagesForEvent(long eventId, long gender = (long) Gender.Unspecified);
        IEnumerable<OrderedPair<long, string>> GetPackageNamesForOrder(IEnumerable<long> orderIds);
        IEnumerable<OrderedPair<long, string>> GetEventPackageIdNamePairs(IEnumerable<long> eventPackageIds);
        IEnumerable<EventPackage> GetbyEventIds(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, long>> GetOrderIdEventPackageTestIdPairsForOrder(IEnumerable<long> orderIds);
    }
}