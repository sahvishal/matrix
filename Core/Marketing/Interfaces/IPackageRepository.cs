using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Marketing.Interfaces
{
    public interface IPackageRepository
    {
        IEnumerable<Package> Get(PackageListModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        List<Package> GetAll();
        List<OrderedPair<string, int>> GetPackageCustomerCountForEvent(long eventId);
        IEnumerable<Package> GetPackagesByAccount(long accountId);
        IEnumerable<Package> GetPackagesByHospitalPartner(long hospitalPartnerId);
        IEnumerable<Package> GetPackagesByTerritory(long territoryIds);
        IEnumerable<Package> GetPackagesByEventType(EventType eventType);
        List<Package> GetCorporatePackages();
        IEnumerable<Package> GetAllOpenPackages();
        Package GetById(long packageId);
        IEnumerable<Package> GetByIds(IEnumerable<long> packageIds);
        IEnumerable<long> GetRoleswithGivenPackageAvailability(long packageId);
        void SaveRolesforGivenPackageAvailability(long packageId, IEnumerable<long> roleIds);
        void SetPackageIsActiveState(long packageId, bool isActive);
        Package GetByName(string packageName);
        IEnumerable<Package> GetPackagesByHealthPlanId(long healthPlanId);
    }
}
