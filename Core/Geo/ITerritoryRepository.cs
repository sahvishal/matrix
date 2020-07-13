using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Geo
{
    public interface ITerritoryRepository
    {
        Territory GetTerritory(long territoryId);
        long SaveTerritory(Territory territoryToSave);
        List<Territory> GetAllTerritories();
        List<Territory> GetTerritoriesForPod(long podId);
        IEnumerable<OrderedPair<long, string>> GetAllTerritoriesIdNamePair(TerritoryType type);
        IEnumerable<OrderedPair<long, string>> GetMultiplePodTerritoriesIdNamePair(long[] id);
        List<Territory> GetTerritoriesForFranchisee(long franchiseeId);
        List<SalesRepTerritory> GetTerritoriesForSalesRep(long salesRepId);
        List<Territory> GetChildTerritories(long parentTerritoryId);
        List<Territory> GetAllParentTerritories();
        List<string> GetOwnerNamesForTerritory(Territory territory);
        bool UnassignSalesRepOwnerFromTerritory(long salesRepId, long territoryId);
        bool AssignSalesRepOwnerToTerritory(long salesRepId, long territoryId, RegistrationMode eventTypeSetupPermission);
        List<SalesRepTerritory> GetTerritoriesForSalesRepByZipCode(long salesRepId, string zipCode);
        List<Territory> GetTerritories(List<long> territoryIds);
        bool DeleteTerritory(long territoryId);
        bool IsZipCodePresentInTerritory(long organizationRoleUserId, string zipCode);
        List<Territory> GetTerritoriesForZipIds(long[] zipIds);

        IEnumerable<Territory> GetTerritoriesFor(long zipIds, TerritoryType territoryType);

    }
}